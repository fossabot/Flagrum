//----------------------
// <auto-generated>
// This file was automatically generated. Any changes to it will be lost if and when the file is regenerated.
// </auto-generated>
//----------------------
#pragma warning disable

using System;
using SQEX.Luminous.Core.Object;
using System.Collections.Generic;
using CodeDom = System.CodeDom;

namespace SQEX.Luminous.InputDevice
{
    [Serializable, CodeDom.Compiler.GeneratedCode("Luminaire", "0.1")]
    public partial class PadRecord
    {
        new public static ObjectType ObjectType { get; private set; }
        private static PropertyContainer fieldProperties;
		
		public List<SQEX.Luminous.InputDevice.PadRecordItem> items_= new List<SQEX.Luminous.InputDevice.PadRecordItem>();
		
        
        new public static void SetupObjectType()
        {
            if (ObjectType != null)
            {
                return;
            }

            var dummy = new PadRecord();
            var properties = dummy.GetFieldProperties();

            ObjectType = new ObjectType("SQEX.Luminous.InputDevice.PadRecord", 0, SQEX.Luminous.InputDevice.PadRecord.ObjectType, null, properties, 0, 16);
        }
		
        public  ObjectType GetObjectType()
        {
            return ObjectType;
        }

        protected  PropertyContainer GetFieldProperties()
        {
            if (fieldProperties != null)
            {
                return fieldProperties;
            }

            fieldProperties = new PropertyContainer("SQEX.Luminous.InputDevice.PadRecord", null, -828597274, -106467037);
            
			
			
			fieldProperties.AddProperty(new Property("items_", 3704393840, "Std.DynamicArray< SQEX.Luminous.InputDevice.PadRecordItem* >", 0, 16, 1, Property.PrimitiveType.PointerArray, 0, (char)2));
			
			
			return fieldProperties;
        }

		
    }
}