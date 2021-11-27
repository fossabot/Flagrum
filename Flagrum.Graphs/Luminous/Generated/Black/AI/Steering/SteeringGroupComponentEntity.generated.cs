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

namespace Black.AI.Steering
{
    [Serializable, CodeDom.Compiler.GeneratedCode("Luminaire", "0.1")]
    public partial class SteeringGroupComponentEntity : SQEX.Ebony.Framework.Entity.Entity
    {
        new public static ObjectType ObjectType { get; private set; }
        private static PropertyContainer fieldProperties;
		
		public int type_;
		public float maxSpeed_;
		public float speed_;
		public float minSpeed_;
		public float desiredSideDistance_;
		public float desiredFrontDistance_;
		public float minDistance_;
		public int maxAgentsPerLine_;
		public float cohesionSteepness_;
		public float cohesionMinRadius_;
		public float cohesionMaxRadius_;
		public float cohesionWeight_;
		public float mahalaThreshold_;
		public float euclideanThreshold_;
		public int minTargetDelay_;
		public int maxTargetDelay_;
		
        
        new public static void SetupObjectType()
        {
            if (ObjectType != null)
            {
                return;
            }

            var dummy = new SteeringGroupComponentEntity();
            var properties = dummy.GetFieldProperties();

            ObjectType = new ObjectType("Black.AI.Steering.SteeringGroupComponentEntity", 0, Black.AI.Steering.SteeringGroupComponentEntity.ObjectType, Construct, properties, 0, 128);
        }
		
        public override ObjectType GetObjectType()
        {
            return ObjectType;
        }

        protected override PropertyContainer GetFieldProperties()
        {
            if (fieldProperties != null)
            {
                return fieldProperties;
            }

            fieldProperties = new PropertyContainer("Black.AI.Steering.SteeringGroupComponentEntity", base.GetFieldProperties(), 1152478087, 479315012);
            
			
			
			fieldProperties.AddProperty(new Property("type_", 3554705238, "Black.AI.Steering.SteeringGroupComponentEntity.ComponentType", 64, 4, 1, Property.PrimitiveType.Enum, 0, (char)0));
			fieldProperties.AddProperty(new Property("maxSpeed_", 3235919937, "float", 68, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddProperty(new Property("speed_", 1253745677, "float", 72, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddProperty(new Property("minSpeed_", 3377264999, "float", 76, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddProperty(new Property("desiredSideDistance_", 1986893822, "float", 80, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddProperty(new Property("desiredFrontDistance_", 487512788, "float", 84, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddProperty(new Property("minDistance_", 462922493, "float", 88, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddProperty(new Property("maxAgentsPerLine_", 1711407949, "int", 92, 4, 1, Property.PrimitiveType.Int32, 0, (char)0));
			fieldProperties.AddProperty(new Property("cohesionSteepness_", 1278422712, "float", 96, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddProperty(new Property("cohesionMinRadius_", 2788860370, "float", 100, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddProperty(new Property("cohesionMaxRadius_", 3230018724, "float", 104, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddProperty(new Property("cohesionWeight_", 2780148286, "float", 108, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddProperty(new Property("mahalaThreshold_", 3986545143, "float", 112, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddProperty(new Property("euclideanThreshold_", 800962807, "float", 116, 4, 1, Property.PrimitiveType.Float, 0, (char)0));
			fieldProperties.AddProperty(new Property("minTargetDelay_", 2730842534, "int", 120, 4, 1, Property.PrimitiveType.Int32, 0, (char)0));
			fieldProperties.AddProperty(new Property("maxTargetDelay_", 3751898076, "int", 124, 4, 1, Property.PrimitiveType.Int32, 0, (char)0));
			
			
			return fieldProperties;
        }

		
        private static BaseObject Construct()
        {
            return new SteeringGroupComponentEntity();
        }
		
    }
}