using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAssetAPI;
using UAssetAPI.PropertyTypes;
using UAssetAPI.StructTypes;

namespace QueenIO
{
    public class ColorData
    {
        public string Name { get; } = "Colors";
        public string StructType { get; } = "AvatarCustomizeDataTableInnerColor";
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
            Color.Value.Add(new BoolPropertyData() { Name = new FName("IsSpecialColor"), Value = false });
            Color.Value.Add(new NamePropertyData() { Name = new FName("ColorPaletteRowName"), Value = new FName(ColorPaletteRowName) });
            Color.Value.Add(new NamePropertyData() { Name = new FName("ColorName"), Value = new FName(ColorName) });
            Color.DuplicationIndex = index;
            return Color;
        }

        public void Read(StructPropertyData Color)
        {
            IsSpecialColor = ((BoolPropertyData)Color.Value[0]).Value;
            ColorPaletteRowName = ((NamePropertyData)Color.Value[1]).Value.Value.Value;
            ColorName = ((NamePropertyData)Color.Value[2]).Value.Value.Value;
        }
    }

    public class FlagCheck
    {
        public string Name { get; } = "CheckFlagSymbol";
        public string Value { get; set; } = null;

        public FlagCheck(string Flag = "null")
        {
            Value = Flag;
        }

        public StrPropertyData Make()
        {
            StrPropertyData Str = new StrPropertyData();
            Str.Name = new FName(Name);
            Str.Value = new FString(Value);
            return Str;
        }

        public void Read(StrPropertyData Str)
        {
            if (Str.Value == null)
                Value = null;
            else
                Value = Str.Value.ToString();
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
    }
}
