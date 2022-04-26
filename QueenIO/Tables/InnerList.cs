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

namespace QueenIO.Tables
{
    /// <summary>
    /// Used by DT_InnerList_[Female/Male]
    /// </summary>
    public class InnerList
    {
        /// <summary>
        /// List of Objects in Data Table.
        /// </summary>
        public List<InnerData> Inners { get; set; }

        /// <summary>
        /// Makes the Data Table for the uasset file.
        /// </summary>
        /// <returns></returns>
        public Successor Make()
        {
            Successor successor = new Successor();
            successor.Data = new List<StructPropertyData>();
            foreach (InnerData data in Inners)
            {
                successor.Data.Add(data.Make());
            }
            return successor;
        }

        /// <summary>
        /// Reads the Data Table from the uasset File.
        /// </summary>
        /// <param name="dataTable"></param>
        public void Read(DataTableExport dataTable)
        {
            Inners = new List<InnerData>();
            foreach (var item in dataTable.Table.Data)
            {
                InnerData innerData = new InnerData();
                innerData.Read(item);
                Inners.Add(innerData);
            }
        }
        /// <summary>
        /// Reads the Data Table from the uasset File.
        /// </summary>
        /// <param name="dataTable"></param>
        public void Read(UDataTable dataTable)
        {
            Inners = new List<InnerData>();
            foreach (var item in dataTable.Data)
            {
                InnerData innerData = new InnerData();
                innerData.Read(item);
                Inners.Add(innerData);
            }
        }
    }

    /// <summary>
    /// Entry used in InnerList.
    /// </summary>
    public class InnerData
    {
        public string Name { get; set; }
        public string StructType { get; } = "AvatarCustomizeDataTableInnerList";
        public string Thumbnail { get; set; }
        public string Mesh { get; set; }
        public ColorData Color_0 { get; set; } = new ColorData();
        public ColorData Color_1 { get; set; } = new ColorData();
        public ColorData Color_2 { get; set; } = new ColorData();
        public ColorData Color_3 { get; set; } = new ColorData();
        public ColorData Color_4 { get; set; } = new ColorData();
        public ColorData Color_5 { get; set; } = new ColorData();
        public ColorData Color_6 { get; set; } = new ColorData();
        public HidePartsTableData HidePartsInfoDetails { get; set; } = new HidePartsTableData();
        public FlagCheck CheckFlagSymbol { get; set; } = new FlagCheck();

        public StructPropertyData Make()
        {
            StructPropertyData Inner = new StructPropertyData();
            Inner.Name = FName.FromString(Name);
            Inner.StructType = FName.FromString(StructType);
            Inner.Value = new List<PropertyData>();
            Inner.Value.Add(new SoftObjectPropertyData() { Name = FName.FromString("Thumbnail"), Value = FName.FromString(Thumbnail)});
            Inner.Value.Add(new SoftObjectPropertyData() { Name = FName.FromString("Mesh"), Value = FName.FromString(Mesh)});
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
            Thumbnail = ((SoftObjectPropertyData)inner.Value[0]).Value.ToString();
            Mesh = ((SoftObjectPropertyData)inner.Value[1]).Value.ToString();
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

        public InnerData Clone()
        {
            InnerData inner = new InnerData();
            inner.Name = Name;
            inner.Thumbnail = Thumbnail;
            inner.Mesh = Mesh;
            inner.Color_0 = Color_0;
            inner.Color_1 = Color_1;
            inner.Color_2 = Color_2;
            inner.Color_3 = Color_3;
            inner.Color_4 = Color_4;
            inner.Color_5 = Color_5;
            inner.Color_6 = Color_6;
            inner.HidePartsInfoDetails = HidePartsInfoDetails;
            inner.CheckFlagSymbol = CheckFlagSymbol;
            return inner;
        }

        public bool Equals(InnerData inner)
        {
            return Name == inner.Name &&
                Thumbnail == inner.Thumbnail &&
                Mesh == inner.Mesh &&
                Color_0.Equals(inner.Color_0) &&
                Color_1.Equals(inner.Color_1) &&
                Color_2.Equals(inner.Color_2) &&
                Color_3.Equals(inner.Color_3) &&
                Color_4.Equals(inner.Color_4) &&
                Color_5.Equals(inner.Color_5) &&
                Color_6.Equals(inner.Color_6) &&
                HidePartsInfoDetails.Equals(inner.HidePartsInfoDetails) &&
                CheckFlagSymbol.Equals(inner.CheckFlagSymbol);
        }
    }

    public class HidePartsTableData
    {
        public string Name { get; } = "HidePartsInfoDetails";
        public StructPropertyData DummyStruct { get; } = new StructPropertyData() { Name = new FName("HidePartsInfoDetails"), StructType = new FName("AvatarCustomizeDataTableInnerHidePartsInfoDetail"), Value = new List<PropertyData>() };
        public List<HidePartsData> HideParts { get; set; } = new List<HidePartsData>();

        public ArrayPropertyData Make()
        {
            ArrayPropertyData array = new ArrayPropertyData();
            array.Name = FName.FromString(Name);
            array.ArrayType = FName.FromString("StructProperty");
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
            HideParts = new List<HidePartsData>();
            foreach (var item in array.Value)
            {
                HidePartsData hidePartsData = new HidePartsData();
                hidePartsData.Read((StructPropertyData)item);
                HideParts.Add(hidePartsData);
            }
        }

        public bool Equals(HidePartsTableData hide)
        {
            if (HideParts.Count != hide.HideParts.Count)
                return false;

            for (int i = 0; i < HideParts.Count; i++)
            {
                if (!HideParts[i].Equals(hide.HideParts[i]))
                    return false;
            }
            return true;
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
            hidepart.Name = FName.FromString(Name);
            hidepart.StructType = FName.FromString(StructType);
            hidepart.Value = new List<PropertyData>();
            hidepart.Value.Add(new SoftObjectPropertyData() { Name = FName.FromString("Thumbnail"), Value = FName.FromString(Thumbnail) });
            hidepart.Value.Add(new NamePropertyData() { Name = FName.FromString("HidePartsName"), Value = FName.FromString(HidePartsName) });
            return hidepart;
        }

        public void Read(StructPropertyData hidepart)
        {
            Thumbnail = ((SoftObjectPropertyData)hidepart.Value[0]).Value.ToString();
            HidePartsName = ((NamePropertyData)hidepart.Value[1]).Value.ToString();
        }

        public bool Equals(HidePartsData parts)
        {
            return Thumbnail == parts.Thumbnail && HidePartsName == parts.HidePartsName;
        }
    }
}
