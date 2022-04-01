using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAssetAPI;
using UAssetAPI.PropertyTypes;
using UAssetAPI.StructTypes;
using System.Numerics;

namespace QueenIO
{
    public class ColorData
    {
        public string Name { get; set; } = "Colors";
        public string StructType { get; set; } = "AvatarCustomizeDataTableInnerColor";
        public bool IsSpecialColor { get; set; } = false;
        public string ColorPaletteRowName { get; set; } = "StandardColor_Gray1";
        public string ColorName { get; set; } = "palette_stg_monotone00";

        public ColorData(string Palette = "StandardColor_Gray1", string Color = "palette_stg_monotone00", bool IsSpecial = false)
        {
            IsSpecialColor = IsSpecial;
            ColorPaletteRowName = Palette;
            ColorName = Color;
        }

        public StructPropertyData Make(int index = 0)
        {
            StructPropertyData Color = new StructPropertyData();
            Color.Name = new FName(Name);
            Color.StructType = new FName(StructType);
            Color.Value = new List<PropertyData>();
            Color.Value.Add(new BoolPropertyData() { Name = new FName("IsSpecialColor"), Value = IsSpecialColor });
            Color.Value.Add(new NamePropertyData() { Name = new FName("ColorPaletteRowName"), Value = new FName(ColorPaletteRowName) });
            Color.Value.Add(new NamePropertyData() { Name = new FName("ColorName"), Value = new FName(ColorName) });
            Color.DuplicationIndex = index;
            return Color;
        }

        public void Read(StructPropertyData Color)
        {
            Name = Color.Name.Value.Value;
            IsSpecialColor = ((BoolPropertyData)Color.Value[0]).Value;
            ColorPaletteRowName = ((NamePropertyData)Color.Value[1]).Value.Value.Value;
            ColorName = ((NamePropertyData)Color.Value[2]).Value.Value.Value;
        }

        public bool Equals(ColorData color)
        {
            return Name == color.Name &&
                IsSpecialColor == color.IsSpecialColor &&
                ColorPaletteRowName == color.ColorPaletteRowName &&
                ColorName == color.ColorName;
        }
    }

    public class FlagCheck
    {
        public string Name { get; } = "CheckFlagSymbol";
        public string Value { get; set; }

        public StrPropertyData Make()
        {
            StrPropertyData Str = new StrPropertyData();
            Str.Name = new FName(Name);
            if (Value != null)
                Str.Value = new FString(Value);
            return Str;
        }

        public void Read(StrPropertyData Str)
        {
            if (Str.Value == null)
                Value = null;
            else
                Value = Str.Value.Value;
        }

        public bool Equals(FlagCheck flagCheck)
        {
            return Name == flagCheck.Name &&
                Value == flagCheck.Value;
        }
    }

    public class ScenarioOffsetData
    {
        public string Name { get; } = "ScenarioOffset";
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public StructPropertyData Make()
        {
            StructPropertyData Struct = new StructPropertyData();
            Struct.Name = new FName(Name);
            Struct.StructType = new FName("Vector");
            Struct.Value = new List<PropertyData>();
            Struct.Value.Add(new VectorPropertyData() { Name = new FName(Name), Value = new FVector(X, Y, Z)});
            return Struct;
        }

        public void Read(StructPropertyData structProperty)
        {
            X = ((VectorPropertyData)structProperty.Value[0]).Value.X;
            Y = ((VectorPropertyData)structProperty.Value[0]).Value.Y;
            Z = ((VectorPropertyData)structProperty.Value[0]).Value.Z;
        }

        public bool Equals(ScenarioOffsetData scenarioOffsetData)
        {
            return X == scenarioOffsetData.X && Y == scenarioOffsetData.Y && Z == scenarioOffsetData.Z;
        }
    }

    public class Transform
    {
        public string Name { get; set;}
        public string StructType { get; } = "Transform";
        public Quaternion Rotation { get; set; } = new Quaternion();
        public Vector3 Translation { get; set; } = new Vector3();
        public Vector3 Scale3D { get; set; } = new Vector3() { X = 1, Y = 1, Z = 1};

        public StructPropertyData Make(string name = "Transform")
        {
            StructPropertyData data = new StructPropertyData();
            data.Name = new FName(name);
            data.StructType = new FName(StructType);
            data.Value = new List<PropertyData>();

            StructPropertyData Rot = new StructPropertyData();
            Rot.Name = new FName("Rotation");
            Rot.StructType = new FName("Quat");
            Rot.Value = new List<PropertyData>();
            Rot.Value.Add(new QuatPropertyData() { Name = new FName("Rotation"), Value = new FQuat(Rotation.X, Rotation.Y, Rotation.Z, Rotation.W) });
            data.Value.Add(Rot);

            StructPropertyData Trans = new StructPropertyData();
            Trans.Name = new FName("Translation");
            Trans.StructType = new FName("Vector");
            Trans.Value = new List<PropertyData>();
            Trans.Value.Add(new VectorPropertyData() { Name = new FName("Translation"), Value = new FVector(Translation.X, Translation.Y, Translation.Z) });
            data.Value.Add(Trans);

            StructPropertyData Scale = new StructPropertyData();
            Scale.Name = new FName("Scale3D");
            Scale.StructType = new FName("Vector");
            Scale.Value = new List<PropertyData>();
            Scale.Value.Add(new VectorPropertyData() { Name = new FName("Scale3D"), Value = new FVector(Scale3D.X, Scale3D.Y, Scale3D.Z) });
            data.Value.Add(Scale);

            return data;
        }

        public void Read(StructPropertyData data)
        {
            Quaternion rotation = new Quaternion();
            rotation.W = ((QuatPropertyData)((StructPropertyData)data.Value[0]).Value[0]).Value.W;
            rotation.X = ((QuatPropertyData)((StructPropertyData)data.Value[0]).Value[0]).Value.X;
            rotation.Y = ((QuatPropertyData)((StructPropertyData)data.Value[0]).Value[0]).Value.Y;
            rotation.Z = ((QuatPropertyData)((StructPropertyData)data.Value[0]).Value[0]).Value.Z;
            Rotation = rotation;

            Vector3 translation = new Vector3();
            translation.X = ((VectorPropertyData)((StructPropertyData)data.Value[1]).Value[0]).Value.X;
            translation.Y = ((VectorPropertyData)((StructPropertyData)data.Value[1]).Value[0]).Value.Y;
            translation.Z = ((VectorPropertyData)((StructPropertyData)data.Value[1]).Value[0]).Value.Z;
            Translation = translation;

            Vector3 scale3d = new Vector3();
            scale3d.X = ((VectorPropertyData)((StructPropertyData)data.Value[2]).Value[0]).Value.X;
            scale3d.Y = ((VectorPropertyData)((StructPropertyData)data.Value[2]).Value[0]).Value.Y;
            scale3d.Z = ((VectorPropertyData)((StructPropertyData)data.Value[2]).Value[0]).Value.Z;
            Scale3D = scale3d;
        }

        public bool Equals(Transform transform)
        {
            return Name == transform.Name &&
                Rotation.Equals(transform.Rotation) &&
                Translation.Equals(transform.Translation) &&
                Scale3D.Equals(transform.Scale3D);
        }
    }
}
