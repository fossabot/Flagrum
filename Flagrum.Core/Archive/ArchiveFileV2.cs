﻿using System;
using System.IO;
using System.Linq;
using Flagrum.Core.Utilities;
using ZLibNet;

namespace Flagrum.Core.Archive;

public class ArchiveFileV2
{
    public const ulong KeyMultiplier = 1103515245;
    public const ulong KeyAdditive = 12345;

    public const uint HeaderSize = 40;
    public const ulong HeaderHash = 14695981039346656037;

    private ArchiveDataSource _dataSource;

    public ArchiveFileV2() { }

    public ArchiveFileV2(string uri)
    {
        RelativePath = uri.Replace("data://", "");
        FixRelativePath();

        var newUri = uri
            .Replace(".gmdl.gfxbin", ".gmdl")
            .Replace(".gmtl.gfxbin", ".gmtl")
            .Replace(".exml", ".ebex");

        Uri = newUri;

        var tokens = RelativePath.Split('\\', '/');
        var fileName = tokens.Last();
        var index = fileName.IndexOf('.');
        var type = index < 0 ? "" : fileName[(index + 1)..];

        UriHash = Cryptography.Hash64(Uri);
        TypeHash = Cryptography.Hash64(type);

        UriAndTypeHash = (ulong)(((long)UriHash & 17592186044415L) | (((long)TypeHash << 44) & -17592186044416L));

        Flags = GetDefaultBinmodFlags();
    }

    public ArchiveFileV2(string uri, string relativePath, uint size, ArchiveFileFlag flags, byte localizationType,
        byte locale, ushort key)
    {
        RelativePath = relativePath;
        Uri = uri;
        Size = size;
        Flags = flags;
        LocalizationType = localizationType;
        Locale = locale;
        Key = key;

        var tokens = RelativePath.Split('\\', '/');
        var fileName = tokens.Last();
        var index = fileName.IndexOf('.');
        var type = index < 0 ? "" : fileName[(index + 1)..];

        UriHash = Cryptography.Hash64(Uri);
        TypeHash = Cryptography.Hash64(type);
        UriAndTypeHash = (ulong)(((long)UriHash & 17592186044415L) | (((long)TypeHash << 44) & -17592186044416L));
    }

    public ulong TypeHash { get; set; }
    public ulong UriAndTypeHash { get; set; }
    public string Uri { get; set; }
    public ulong UriHash { get; set; }
    public uint UriOffset { get; set; }
    public string RelativePath { get; set; }
    public uint RelativePathOffset { get; set; }
    public ulong DataOffset { get; set; }
    public uint Size { get; set; }
    public uint ProcessedSize { get; set; }
    public ArchiveFileFlag Flags { get; set; }
    public byte LocalizationType { get; set; }
    public byte Locale { get; set; }

    public ushort Key { get; set; }

    public bool HasData => _dataSource != null;
    public bool IsDataEncrypted { get; set; }
    public bool IsDataCompressed { get; set; }

    public Stream GetDataForExport()
    {
        if (_dataSource == null)
        {
            throw new Exception("Case not supported.");
        }

        if (!IsDataEncrypted && Flags.HasFlag(ArchiveFileFlag.Encrypted))
        {
            throw new Exception("Case not supported.");
        }

        if (!IsDataCompressed && Flags.HasFlag(ArchiveFileFlag.Compressed))
        {
            throw new Exception("Case not supported.");
        }

        var stream = _dataSource.GetDataStream();
        ProcessedSize = (uint)stream.Length;
        return stream;
    }

    public void SetDataByFlags(ArchiveDataSource dataSource)
    {
        _dataSource = dataSource;
        IsDataCompressed = Flags.HasFlag(ArchiveFileFlag.Compressed);
        IsDataEncrypted = Flags.HasFlag(ArchiveFileFlag.Encrypted);
    }

    private ArchiveFileFlag GetDefaultBinmodFlags()
    {
        var flags = ArchiveFileFlag.Autoload;

        if (Uri.EndsWith(".modmeta") || Uri.EndsWith(".bin"))
        {
            flags |= ArchiveFileFlag.MaskProtected;
        }
        else
        {
            flags |= ArchiveFileFlag.Encrypted;
        }

        return flags;
    }

    /// <summary>
    /// This is needed if using parameterless constructor to deconstruct the UriAndTypeHash
    /// </summary>
    public void DeconstructUriAndTypeHash()
    {
        FixRelativePath();
        var tokens = RelativePath.Split('\\', '/');
        var fileName = tokens.Last();
        var index = fileName.IndexOf('.');
        var type = index < 0 ? "" : fileName.Substring(index + 1);

        UriHash = Cryptography.Hash64(Uri);
        TypeHash = Cryptography.Hash64(type);
    }

    private byte[] CompressData(byte[] data)
    {
        var currentPosition = 0;
        const int chunkSize = 128 * 1024;
        var encryptionKey = Key;
        using var dataStream = new MemoryStream(data);
        using var memoryStream = new MemoryStream();
        using var temporaryMemoryStream = new MemoryStream();

        while (currentPosition < dataStream.Length)
        {
            var sizeBefore = temporaryMemoryStream.Length;

            using var compressionStream = new ZLibStream(temporaryMemoryStream, CompressionMode.Compress,
                CompressionLevel.BestCompression, true);

            var remainingBytes = dataStream.Length - currentPosition;
            var size = (int)(remainingBytes > chunkSize ? chunkSize : remainingBytes);
            var buffer = new byte[size];

            dataStream.Seek(currentPosition, SeekOrigin.Begin);
            dataStream.Read(buffer, 0, size);
            compressionStream.Write(buffer, 0, size);
            compressionStream.Flush();

            var compressedSize = temporaryMemoryStream.Length - sizeBefore;

            if (encryptionKey != 0)
            {
                var key = (encryptionKey * 1103515245UL + 12345UL) * 1103515245UL + 12345UL;
                memoryStream.Write(BitConverter.GetBytes((int)compressedSize ^ (uint)(key >> 32)), 0, 4);
                memoryStream.Write(BitConverter.GetBytes(size ^ (uint)key), 0, 4);
                encryptionKey = 0;
            }
            else
            {
                memoryStream.Write(BitConverter.GetBytes((int)compressedSize), 0, 4);
                memoryStream.Write(BitConverter.GetBytes(size), 0, 4);
            }

            memoryStream.Write(temporaryMemoryStream.ToArray(),
                (int)(temporaryMemoryStream.Length - compressedSize),
                (int)compressedSize);

            var alignment = (int)(memoryStream.Length % 4);
            if (alignment > 0)
            {
                memoryStream.Write(BitConverter.GetBytes(0), 0, 4 - alignment);
            }

            currentPosition += size;
        }

        return memoryStream.ToArray();
    }

    private byte[] DecompressData(byte[] data)
    {
        const int chunkSize = 128 * 1024;
        var chunks = Size / chunkSize;

        // If the integer division wasn't even, add 1 more chunk
        if (Size % chunkSize != 0)
        {
            chunks++;
        }

        using var memoryStream = new MemoryStream(data);
        using var outStream = new MemoryStream();
        using var writer = new BinaryWriter(outStream);

        for (var index = 0; index < chunks; index++)
        {
            // Skip padding
            if (index > 0)
            {
                var offset = 4 - (int)(memoryStream.Position % 4);
                if (offset > 3)
                {
                    offset = 0;
                }

                memoryStream.Seek(offset, SeekOrigin.Current);
            }

            // Read the data sizes
            var buffer = new byte[4];
            memoryStream.Read(buffer, 0, 4);
            var compressedSize = BitConverter.ToUInt32(buffer);
            buffer = new byte[4];
            memoryStream.Read(buffer, 0, 4);
            var decompressedSize = BitConverter.ToUInt32(buffer);

            // Decompress the current chunk and write to the output stream
            buffer = new byte[compressedSize];
            memoryStream.Read(buffer, 0, (int)compressedSize);
            using var stream = new MemoryStream(buffer);
            using var zlibStream = new ZLibStream(stream, CompressionMode.Decompress);
            var decompressedBuffer = new byte[decompressedSize];
            zlibStream.Read(decompressedBuffer, 0, (int)decompressedSize);
            writer.Write(decompressedBuffer);
        }

        return outStream.ToArray();
    }

    private void FixRelativePath()
    {
        if (RelativePath.EndsWith(".tga") || RelativePath.EndsWith(".tif") || RelativePath.EndsWith(".dds") ||
            RelativePath.EndsWith(".png"))
        {
            RelativePath = RelativePath
                .Replace(".tga", ".btex")
                .Replace(".tif", ".btex")
                .Replace(".dds", ".btex")
                .Replace(".png", ".btex");
        }
        else if (RelativePath.EndsWith(".gmtl"))
        {
            RelativePath = RelativePath.Replace(".gmtl", ".gmtl.gfxbin");
        }
        else if (RelativePath.EndsWith(".gmdl"))
        {
            RelativePath = RelativePath.Replace(".gmdl", ".gmdl.gfxbin");
        }
        else if (RelativePath.EndsWith(".ebex"))
        {
            RelativePath = RelativePath.Replace(".ebex", ".exml");
        }
        else if (RelativePath.EndsWith(".ebex@"))
        {
            RelativePath = RelativePath.Replace(".ebex@", ".earc");
        }
        else if (RelativePath.EndsWith(".prefab@"))
        {
            RelativePath = RelativePath.Replace(".prefab@", ".earc");
        }
        else if (RelativePath.EndsWith(".htpk"))
        {
            RelativePath = RelativePath.Replace(".htpk", ".earc");
        }
        else if (RelativePath.EndsWith(".max"))
        {
            RelativePath = RelativePath.Replace(".max", ".win.mab");
        }
        else if (RelativePath.EndsWith(".sax"))
        {
            RelativePath = RelativePath.Replace(".sax", ".win.sab");
        }
    }
}