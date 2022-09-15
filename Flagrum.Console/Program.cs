﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Flagrum.Console.Ps4;
using Flagrum.Console.Ps4.Porting;
using Flagrum.Console.Utilities;
using Flagrum.Core.Animation;
using Flagrum.Core.Ebex.Xmb2;
using Flagrum.Core.Utilities;
using Flagrum.Desktop.Services;
using Flagrum.Web.Persistence;
using Flagrum.Web.Services;
using Newtonsoft.Json;

// var uri = "data://level/dlc_ex/feather/feather/duscae_lestallum_i_feather/map_du_le_i_env_feather.ebex";
// using var context = Ps4Utilities.NewContext();
// var data = Ps4Utilities.GetFileByUri(context, uri);
//
// if (uri.EndsWith(".ebex") || uri.EndsWith(".prefab"))
// {
//     var output = new StringBuilder();
//     Xmb2Document.Dump(data, output);
//     data = Encoding.UTF8.GetBytes(output.ToString());
// }
// else if (uri.EndsWith(".amdl"))
// {
//     data = AnimationModel.ToPC(data);
// }
//
// File.WriteAllBytes($@"C:\Modding\Chocomog\Testing\XML\{uri.Split('/').Last()}", data);
// return;


// foreach (var file in Directory.EnumerateFiles(@"C:\Users\Kieran\Desktop\XMB2"))
// {
//     var builder = new StringBuilder();
//     Xmb2Document.Dump(File.ReadAllBytes(file), builder);
//     File.WriteAllText(file.Replace(".exml", ".xml"), builder.ToString());
// }
// return;

// new Ps4Indexer().RegenerateMap();
// return;

var packer = new Ps4EnvironmentPacker(new ConsoleLogger<Program>("Logger", () => new ConsoleLoggerConfiguration()), new SettingsService());
packer.Pack("data://level/dlc_ex/feather/area_duscae_feather.ebex", @"C:\Users\Kieran\Desktop\ACFest\area_duscae_feather.fed");
return;

//Console.WriteLine(Cryptography.HashFileUri64("data://environment/dungeon/d04/sourceimages/d04_ar_factoryfencea_net_n.tif"));
//return;

//new Ps4AssetAggregator().Run();
//new Ps4MonolithBuilder().Run();
//return;

// var builder = new StringBuilder();
// Xmb2Document.Dump(File.ReadAllBytes(@"C:\Users\Kieran\Desktop\level\dlc_ex\mog\area_ravettrice_mog\map_ravettrice_altisia_npc_mog_i.exml"), builder);
// File.WriteAllText(@"C:\Users\Kieran\Desktop\level\dlc_ex\mog\area_ravettrice_mog\map_ravettrice_altisia_npc_mog_i.xml", builder.ToString());
// return;

// Asset references are not being added to the single earc correctly so the test can't be validated
// Need to get that working to see if the missing NPCs issue is being caused by
// improper script referencing
// using var unpacker =
//     new Unpacker(
//         @"C:\Program Files (x86)\Steam\steamapps\common\FINAL FANTASY XV\datas\level\dlc_ex\mog\area_ravettrice_mog.earc");
// var matches = unpacker.Files.Where(f => f.Uri.Contains("uw20"));
// foreach (var match in matches)
// {
//     Console.WriteLine(match.Uri);
// }
//
// return;

//new Ps4EarcPorter().ReferenceTest();
//return;
new Ps4Porter().Run();
return;

// new FileFinder().FindByQuery(file => file.Uri == "data://data/ai/interactions/town/alt_mog/system/autoexternal.ebex@",
//     (earc, file) => System.Console.WriteLine(earc + " - " + file.Uri),
//     false);
// return;

//FileFinder.FindStringInAllFiles("uw05_100_hair01_mog.ebex");
//FileFinder.FindStringInExml("SequenceActionCheckPhotoCount");
//FileFinder.FindBytesInAllFiles(BitConverter.GetBytes((uint)17109819));
return;

// using var context = Ps4Utilities.NewContext();
// var json = File.ReadAllText(@$"{Ps4PorterConfiguration.StagingDirectory}\assets.json");
// var assets = JsonConvert.DeserializeObject<List<string>>(json)!;
//
// foreach (var asset in assets.Where(a => a.EndsWith(".ani")))
// {
//     var animation = Ps4Utilities.GetFileByUri(context, asset);
//     if (animation.Length > 0)
//     {
//         File.WriteAllBytes($@"C:\Modding\Chocomog\Testing\AnimationDump\{asset.Split('/').Last()}", animation);
//     }
// }
//
// return;

//FileFinder.FindStringInExml("luchil");
//return;

// var results = new Dictionary<string, bool>();
// new FileFinder().FindByQuery(file => file.Uri.Contains("/nh00/") && file.Uri.EndsWith(".gmdl"),
//     (earc, file) =>
//     {
//         Console.WriteLine($"Reading {file.Uri}");
//         try
//         {
//             using var context = new FlagrumDbContext(new SettingsService());
//             var gmdl = file.GetReadableData();
//             var gpubin = context.GetFileByUri(file.Uri.Replace(".gmdl", ".gpubin"));
//             var model = new ModelReader(gmdl, gpubin).Read();
//             foreach (var part in model.Parts)
//             {
//                 results.TryAdd(part.Name, true);
//             }
//         }
//         catch
//         {
//             Console.WriteLine("Model read failed");
//         }
//         
//     }, 
//     true);
//
// Console.WriteLine("");
// foreach (var (name, _) in results)
// {
//     Console.WriteLine(name);
// }
// return;

// new FileFinder().FindByQuery(file => file.Uri.Contains("altc_mog_kenny", StringComparison.OrdinalIgnoreCase),
//     (earc, file) =>
//     {
//         Console.WriteLine($"{file.Uri} - {earc}");
//     }, 
//     false);
// return;

// using var context = Ps4Utilities.NewContext();
// var files = Ps4Utilities.GetFilesByUri(context, "data://character/uw/common/anim/graph/uw_011_facial_mog.anmgph");
// foreach (var (earc, data) in files)
// {
//     var path = $@"C:\Modding\Chocomog\Testing\AnimationDump\{earc.Replace('\\', '-')}";
//     File.WriteAllBytes(path, data);
// }

//return;

// var clip = AnimationClip.FromData(
//     //File.ReadAllBytes(@"C:\Users\Kieran\Desktop\Models2\um02\um02.amdl"),
//     //File.ReadAllBytes(@"C:\Modding\EarcMods\TalkBasicFacialTest\talk_basic_facial.ani"));
//     File.ReadAllBytes(@"C:\Users\Kieran\Desktop\Models2\nh00\nh00.amdl"),
//     //File.ReadAllBytes(@"C:\Modding\AnimationProject\nh00_basemove\0.ani"));
//     File.ReadAllBytes(@"C:\Modding\AnimationProject\r_cc_c_lp_0000a.ani"));
//     //File.ReadAllBytes(@"C:\Users\Kieran\Desktop\r_cc_a2_lp_0000a_facial.ani"));
// return;

//FileFinder.FindStringInExml("armiger");
//return;

//FileFinder.FindBytesInAllFiles(BitConverter.GetBytes((uint)16817550));
//return;

//
// var directory = @"C:\Users\Kieran\Downloads\mdl";
// foreach (var gmdl in Directory.GetFiles(directory, "*.gmdl.gfxbin", SearchOption.AllDirectories))
// {
//     PlatinumDemoGmdl.Convert(gmdl);
// }
//
// return;

//
// foreach (var file in Directory.GetFiles(directory, "*.btex", SearchOption.AllDirectories))
// {
//     var btex = Btex.FromData(File.ReadAllBytes(file));
//     btex.Bitmap.Save(file.Replace(".btex", ".png"), ImageFormat.Png);
// }
//
// return;

// using var context = new FlagrumDbContext(new SettingsService());
// var gmdl = context.GetFileByUri("data://environment/leide/props/le_ar_gqshop1/models/le_ar_gqshop1_jettya.gmdl");
// var gpubin = context.GetFileByUri("data://environment/leide/props/le_ar_gqshop1/models/le_ar_gqshop1_jettya.gpubin");
// var gmdl = File.ReadAllBytes(@"C:\Users\Kieran\Downloads\TEX_EDIT\WE01_000\restored\we01_000.gmdl.gfxbin");
// var gpubin = File.ReadAllBytes(@"C:\Users\Kieran\Downloads\TEX_EDIT\WE01_000\restored\we01_000.gpubin");
// var model = new ModelReader(gmdl, gpubin).Read();
// var (gmdlOut, gpubinOut) = new ModelWriter(model).Write();
// File.WriteAllBytes(@"C:\Users\Kieran\Downloads\TEX_EDIT\WE01_000\restored\we01_000.gmdl.gfxbin", gmdlOut);
// File.WriteAllBytes(@"C:\Users\Kieran\Downloads\TEX_EDIT\WE01_000\restored\we01_000.gpubin", gpubinOut);
// return;

// using var context = Ps4Utilities.NewContext();
// var gmtl = Ps4Utilities.GetFileByUri(context, "data://character/uw/uw20/model_160/materials/uw20_160_uhcloth_01_mat.gmtl");
// var material = new MaterialReader(gmtl).Read();
// return;

// using var innerContext = Ps4Utilities.NewContext();
// var uri = "data://menu/common/window/vfx/epp_blur_bg.vfx";
// var data = Ps4Utilities.GetFileByUri(innerContext, uri);
// var dataString = Encoding.UTF8.GetString(data);
//
// Console.WriteLine(dataString);
//
// //dataString = "data://effects/Resource/Texture/NonLinear/VC/White_vc.tif  ";
// var matches = Regex.Matches(dataString, @"data:\/\/.+?\..+?" + (char)0x00);
// foreach (Match match in matches)
// {
//     Console.WriteLine(match.Value[..^1]);
// }
//
// return;

// var paths = new Dictionary<string, string>
// {
//     {"character/we/we04/entry/we04_000.exml", "data://character/we/we04/entry/we04_000.ebex"},
//     {"character/we/we04/entry/we04_100.exml", "data://character/we/we04/entry/we04_100.ebex"},
//     {"character/we/we04/entry/we04_200.exml", "data://character/we/we04/entry/we04_200.ebex"}
// };
//
// foreach (var (path, uri) in paths)
// {
//     var tokens = path.Split('\\', '/');
//     var fileName = tokens.Last();
//     var index = fileName.IndexOf('.');
//     var type = index < 0 ? "" : fileName[(index + 1)..];
//
//     var UriHash = Cryptography.Hash64(uri);
//     var TypeHash = Cryptography.Hash64(type);
//
//     var UriAndTypeHash = (ulong)(((long)UriHash & 17592186044415L) | (((long)TypeHash << 44) & -17592186044416L));
//     Console.WriteLine($"{path}\t{uri}\t{UriAndTypeHash:x16}");
// }
//
// return;

// var file = @"C:\Users\Kieran\Downloads\message(3).txt";
// var lines = File.ReadAllLines(file);
// var builder = new StringBuilder();
// var counter = 0;
// foreach (var line in lines)
// {
//     builder.Append($"\"{line}\"");
//     
//     if (line != lines.Last())
//     {
//         builder.Append(", ");
//     }
//
//     if (counter == 7)
//     {
//         builder.Append("\n");
//         counter = 0;
//     }
//
//     counter++;
// }
// Console.WriteLine(builder.ToString());
// return;

// var gmdl = @"C:\Mega\Modding\CutContent\nh00_retailps4\model_050\nh00_050.gmdl.gfxbin";
// var gpubin = @"C:\Mega\Modding\CutContent\nh00_retailps4\model_050\nh00_050.gpubin";
// // var gmdl2 = @"C:\Users\Kieran\Desktop\Models2\nh00\model_010\nh00_010.gmdl.gfxbin";
// // var gpubin2 = @"C:\Users\Kieran\Desktop\Models2\nh00\model_010\nh00_010.gpubin";
var amdl = File.ReadAllBytes(@"C:\Users\Kieran\Desktop\Models2\nh00\nh00.amdl");
var animationModel = AnimationModel.FromData(amdl, false);
// //File.WriteAllBytes(@"C:\Mega\Modding\CutContent\nh00_retailps4\nh00_retailps4.amdl", AnimationModel.ToPC(amdl));
// //return;
// //gmdl = @"C:\Users\Kieran\Downloads\model_000(1)\nh00_000.gmdl.gfxbin";
// //gpubin = @"C:\Users\Kieran\Downloads\model_000(1)\nh00_000.gpubin";
// var model = new ModelReader(File.ReadAllBytes(gmdl), File.ReadAllBytes(gpubin)).Read();
// foreach (var bone in model.BoneHeaders)
// {
//     boneMap.TryGetValue(bone.Name, out var replacement);
//     if (replacement != null)
//     {
//         bone.Name = replacement;
//     }
// }
// // var bone131 = model.BoneHeaders.FirstOrDefault(b => b.UniqueIndex == 131);
// // var model2 = new ModelReader(File.ReadAllBytes(gmdl2), File.ReadAllBytes(gpubin2)).Read();
// foreach (var bone in model.BoneHeaders)
// {
//     var match = animationModel.BoneNames.FirstOrDefault(b => b.Equals(bone.Name, StringComparison.OrdinalIgnoreCase));
//     if (match == null)
//     {
//         System.Console.WriteLine(bone.Name);
//     }
// }
//
// return;

// foreach (var dependency in model.Header.Dependencies)
// {
//     if (ulong.TryParse(dependency.PathHash, out var hash))
//     {
//         var originalHashIndex = model.Header.Hashes.IndexOf(hash);
//         var newHash = Cryptography.HashFileUri64(dependency.Path);
//         dependency.PathHash = newHash.ToString();
//         model.Header.Hashes[originalHashIndex] = newHash;
//         
//         if (dependency.Path.EndsWith(".gmtl"))
//         {
//             var mesh = model.MeshObjects.Select(mo => mo.Meshes.FirstOrDefault(m => m.DefaultMaterialHash == hash)).FirstOrDefault()!;
//             mesh.DefaultMaterialHash = newHash;
//         }
//     }
//
//     dependency.Path = dependency.Path.Replace("model_020", "model_010").Replace("nh00_020", "nh00_010");
// }
//
// var (gmdlOut, gpubinOut) = new ModelWriter(model).Write();
// File.WriteAllBytes(@"C:\Mega\Modding\CutContent\model_010\nh00_010.gmdl.gfxbin", gmdlOut);
// File.WriteAllBytes(@"C:\Mega\Modding\CutContent\model_010\nh00_010.gpubin", gpubinOut);

// foreach (var path in Directory.GetFiles(@"C:\Mega\Modding\CutContent\sourceimages", "*.btex"))
// {
//     var data = File.ReadAllBytes(path);
//     Btex.FromData(data).Bitmap.Save(path.Replace(".btex", ".png"), ImageFormat.Png);
// }
//
// return;

// using Flagrum.Console.Ps4.Festivals;
// using Flagrum.Core.Animation;
//
// var amdlData = File.ReadAllBytes(@"C:\Users\Kieran\Desktop\Models2\nh02\nh02.amdl");
// var amdl = AnimationModel.FromData(amdlData, false);
// File.WriteAllBytes(@"C:\Users\Kieran\Desktop\Models2\nh02\nh02_modified.amdl", AnimationModel.ToData(amdl));
// return;

//
// var info = (LmSkeletalAnimInfo)amdl.CustomUserData.CustomUserDatas[0];
// for (var i = 0; i < info.ChildInfoOffset.Length; i++)
// {
//     if (info.ChildInfoOffset[i] >= 40)
//     {
//         info.ChildInfoOffset[i] -= 40;
//     }
// }
//
// for (var i = 0; i < info.MaybeParentIndexOffsets.Length; i++)
// {
//     if (info.MaybeParentIndexOffsets[i] >= 40)
//     {
//         info.MaybeParentIndexOffsets[i] -= 40;
//     }
// }
//
// var data = AnimationModel.ToData(amdl);
// File.WriteAllBytes(@"C:\Modding\Chocomog\Testing\XML\nh02.amdl", data);
//File.WriteAllBytes(@"C:\Modding\Chocomog\Testing\XML\ds33_000_modified.amdl", AnimationModel.ToPC(amdlData));
//return;
// var x = true;

// var packer = new Ps4EnvironmentPacker(new ConsoleLogger("Logger", () => new ConsoleLoggerConfiguration()),
//     new SettingsService());
// packer.Pack("data://level/dlc_ex/mog/area_ravettrice_mog.ebex",
//     @"C:\Modding\Chocomog\Testing\Environment\area_ravettrice_mog.fed");

//var packer = new EnvironmentPacker(new ConsoleLogger<EnvironmentPacker>("Test", () => new ConsoleLoggerConfiguration()),
//    new SettingsService());
//packer.Pack("data://level/dlc_ex/mog/area_ravettrice_mog.ebex", @"C:\Modding\Chocomog\Testing\Environment\area_ravettrice_mog.fed");

// foreach (var file in Directory.EnumerateFiles(@"C:\Modding\Chocomog\Testing\XML"))
// {
//     var data = File.ReadAllBytes(file);
//     var result = AnimationModel.ToPC(data);
//     File.WriteAllBytes(file.Replace(".amdl", "_modified.amdl"), result);
// }
//
// return;

// FileFinder.FindUriByString("al_pr_mogcho_gameGate.gmdl");
// return;
//
// using var context = new FlagrumDbContext(new SettingsService());
// var location =
//     @"C:\Modding\Chocomog\Final Fantasy XV - RAW PS4\datas\CUSA01633-patch_115\CUSA01633-patch\patch\patch2_initial\common\first_packages_all.earc";
// using var unpacker = new Unpacker(location);
// var item = unpacker.UnpackFileByQuery("menuswfentity_title_special.ebex", out _);
// File.WriteAllBytes(@"C:\Modding\Chocomog\Testing\menuswfentity_title_special.ebex", item);
// return;
//
// var btex = Btex.FromData(item);
// btex.Bitmap.Save(@"C:\Modding\Chocomog\Testing\swf_mogchoco.png", ImageFormat.Png);
// return;
//
// var dds = btex.ToDds();
//
// var pinnedData = GCHandle.Alloc(dds, GCHandleType.Pinned);
// var pointer = pinnedData.AddrOfPinnedObject();
//
// var image = TexHelper.Instance.LoadFromDDSMemory(pointer, dds.Length, DDS_FLAGS.NONE);
//
// pinnedData.Free();
//
// using var stream = new MemoryStream();
// using var ddsStream = image.SaveToDDSMemory(DDS_FLAGS.NONE);
// ddsStream.CopyTo(stream);
// File.WriteAllBytes(
//     @"C:\Modding\Chocomog\Scout\character\nh\nh24\model_000\sourceimages\nh24_000_skin_00_n.dds",
//     stream.ToArray());
//
// var x = true;

void GenerateDiff()
{
    using var ps4Context = Ps4Utilities.NewContext();
    using var pcContext = new FlagrumDbContext(new SettingsService());

    var diff = new List<string>();
    foreach (var uri in ps4Context.Ps4AssetUris.Where(a =>
                     !a.Uri.EndsWith("@") && !a.Uri.EndsWith(".htpk") && !a.Uri.EndsWith(".tif") &&
                     !a.Uri.EndsWith(".sb"))
                 .Select(a => a.Uri))
        //foreach (var uri in ps4Context.Ps4AssetUris.Where(a => a.Uri.EndsWith(".ebex")).Select(a => a.Uri))
    {
        if (!pcContext.AssetUris.Any(a => a.Uri == uri))
        {
            diff.Add(uri);
        }
    }

    File.WriteAllText(@"C:\Users\Kieran\Desktop\diff.json",
        JsonConvert.SerializeObject(diff.Distinct().OrderBy(d => d), Formatting.Indented));
}

void GenerateFixidCsv()
{
    var lockObject = new object();
    var results = new Dictionary<uint, List<string>>();
    new FileFinder().FindByQuery(file => file.Uri.EndsWith(".ebex") || file.Uri.EndsWith(".prefab"),
        (earc, file) =>
        {
            var data = file.GetReadableData();
            var output = new StringBuilder();
            Xmb2Document.Dump(data, output);

            var xml = output.ToString();
            var matches = Regex.Matches(xml, "type=\"Fixid\" fixid=\"(\\d+?)\">(.+?)<", RegexOptions.Multiline);

            if (matches.Any())
            {
                foreach (Match match in matches)
                {
                    var fixid = uint.Parse(match.Groups[1].Value);

                    if (fixid == 0)
                    {
                        continue;
                    }

                    var name = match.Groups[2].Value.ToUpper().Trim(' ', '\r', '\n');

                    lock (lockObject)
                    {
                        if (results.TryGetValue(fixid, out var list))
                        {
                            if (!list.Contains(name))
                            {
                                list.Add(name);
                            }
                        }
                        else
                        {
                            list = new List<string> {name};
                            results.Add(fixid, list);
                        }
                    }
                }
            }
        },
        true);

    var builder = new StringBuilder();
    var extraColumns = results.Max(r => r.Value.Count);
    builder.Append("FixID");

    for (var i = 0; i < extraColumns; i++)
    {
        builder.Append($",Usage {i + 1}");
    }

    foreach (var (fixid, names) in results.OrderBy(r => r.Key))
    {
        if (names.Count > 2)
        {
            Console.WriteLine($"{fixid}");
        }

        builder.Append("\r\n" + fixid);
        var orderedNames = names.OrderBy(n => n.Length).ToList();

        for (var i = 0; i < extraColumns; i++)
        {
            if (i < orderedNames.Count)
            {
                builder.Append("," + orderedNames.ElementAt(i));
            }
            else
            {
                builder.Append(',');
            }
        }
    }

    File.WriteAllText(@"C:\Users\Kieran\Desktop\fixids.csv", builder.ToString());
}