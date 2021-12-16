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

        public void Read(StructPropertyData inner)
        {
            Name = inner.Name.Value.Value;
            Thumbnail = ((SoftObjectPropertyData)inner.Value[0]).Value.Value.Value;
            Mesh = ((SoftObjectPropertyData)inner.Value[1]).Value.Value.Value;
            Color_0.Read((StructPropertyData)inner.Value[2]);
            Color_1.Read((StructPropertyData)inner.Value[3]);
            Color_2.Read((StructPropertyData)inner.Value[4]);
            Color_3.Read((StructPropertyData)inner.Value[5]);
            Color_4.Read((StructPropertyData)inner.Value[6]);
            Color_5.Read((StructPropertyData)inner.Value[7]);
            Color_6.Read((StructPropertyData)inner.Value[8]);
            HidePartsInfoDetails.Read((ArrayPropertyData)inner.Value[9]);
            CheckFlagSymbol.Read((StrPropertyData)inner.Value[10]);
        }
    }

    public class HidePartsTableData
    {
        public string Name { get; } = "HidePartsInfoDetails";
        public StructPropertyData DummyStruct { get; } = new StructPropertyData() { Name = new FName("HidePartsInfoDetails"), StructType = new FName("AvatarCustomizeDataTableInnerHidePartsInfoDetail") };
        public List<HidePartsData> HideParts { get; set; }

        public ArrayPropertyData Make()
        {
            ArrayPropertyData array = new ArrayPropertyData();
            array.Name = new FName(Name);
            array.DummyStruct = DummyStruct;
            List<PropertyData> propertyDatas = new List<PropertyData>();
            foreach (var item in HideParts)
            {
                propertyDatas.Add(item.Make());
            }
            array.Value = propertyDatas.ToArray();
            return array;
        }

        public void Read(ArrayPropertyData array)
        {
            foreach (var item in array.Value)
            {
                HidePartsData hidePartsData = new HidePartsData();
                hidePartsData.Read((StructPropertyData)item);
                HideParts.Add(hidePartsData);
            }
        }
    }

    public class HidePartsData
    {
        public string Name { get; } = "HidePartsInfoDetails";
        public string StructType { get; } = "AvatarCustomizeDataTableInnerHidePartsInfoDetail";
        public string Thumbnail { get; set; }
        public string HidePartsName { get; set; }

        public HidePartsData(string thumbnail = "null", string hidePartsName = "null")
        {
            Thumbnail = thumbnail;
            HidePartsName = hidePartsName;
        }

        public StructPropertyData Make()
        {
            StructPropertyData hidepart = new StructPropertyData();
            hidepart.Name = new FName(Name);
            hidepart.StructType = new FName(StructType);
            hidepart.Value = new List<PropertyData>();
            hidepart.Value.Add(new SoftObjectPropertyData() { Name = new FName("Thumbnail"), Value = new FName(Thumbnail) });
            hidepart.Value.Add(new SoftObjectPropertyData() { Name = new FName("HidePartsName"), Value = new FName(HidePartsName) });
            return hidepart;
        }

        public void Read(StructPropertyData hidepart)
        {
            Thumbnail = ((SoftObjectPropertyData)hidepart.Value[0]).Value.Value.Value;
            HidePartsName = ((SoftObjectPropertyData)hidepart.Value[1]).Value.Value.Value;
        }
    }
}
