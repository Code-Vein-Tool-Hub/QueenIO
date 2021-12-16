using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAssetAPI;
using UAssetAPI.PropertyTypes;
using UAssetAPI.StructTypes;
using QueenIO;

namespace CodeVeinOutfitInjector.Tables
{
    public class InnerList
    {
        public List<InnerData> Inners { get; set; }
    }

    public class InnerData
    {
        public string Name { get; set; }
        public string StructType { get; } = "AvatarCustomizeDataTableInnerList";
        public string Thumbnail { get; set; }
        public string Mesh { get; set; }
        public ColorData Color_0 { get; set; }
        public ColorData Color_1 { get; set; }
        public ColorData Color_2 { get; set; }
        public ColorData Color_3 { get; set; }
        public ColorData Color_4 { get; set; }
        public ColorData Color_5 { get; set; }
        public ColorData Color_6 { get; set; }
        public HidePartsTableData HidePartsInfoDetails { get; set; }
        public FlagCheck CheckFlagSymbol { get; set; }

        public StructPropertyData Make()
        {
            StructPropertyData Inner = new StructPropertyData();
            Inner.Name = new FName(Name);
            Inner.StructType = new FName(StructType);
            Inner.Value = new List<PropertyData>();
            Inner.Value.Add(new SoftObjectPropertyData() { Name = new FName("Thumbnail"), Value = new FName(Thumbnail)});
            Inner.Value.Add(new SoftObjectPropertyData() { Name = new FName("Mesh"), Value = new FName(Mesh)});
            Inner.Value.Add(Color_0.Make(0));
            Inner.Value.Add(Color_1.Make(1));
            Inner.Value.Add(Color_2.Make(2));
            Inner.Value.Add(Color_3.Make(3));
            Inner.Value.Add(Color_4.Make(4));
            Inner.Value.Add(Color_5.Make(5));
            Inner.Value.Add(Color_6.Make(6));
            Inner.Value.Add(HidePartsInfoDetails.Make());
            Inner.Value.Add(CheckFlagSymbol.Make());
            return Inner;
        }
    }

    public class HidePartsTableData
    {
        public string Name { get; } = "HidePartsInfoDetails";
        public StructPropertyData DummyStruct { get; } = new StructPropertyData() { Name = new FName("HidePartsInfoDetails"), StructType = new FName("AvatarCustomizeDataTableInnerHidePartsInfoDetail") };
        public List<HidePartsData> HideParts { get; set; }

        public ArrayPropertyData Make()
        {
            throw new NotImplementedException();
        }
    }

    public class HidePartsData
    {
        public string Name { get; } = "HidePartsInfoDetails";
        public string StructType { get; } = "AvatarCustomizeDataTableInnerHidePartsInfoDetail";
        public string Thumbnail { get; set; }
        public string HidePartsName { get; set; }

        public StructPropertyData Make()
        {
            StructPropertyData hidepart = new StructPropertyData();
            hidepart.Name = new FName(Name);
            hidepart.StructType = new FName(StructType);
            return hidepart;
        }
    }
}
