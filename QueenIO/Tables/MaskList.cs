using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAssetAPI;
using UAssetAPI.PropertyTypes;
using UAssetAPI.StructTypes;

namespace QueenIO.Tables
{
    public class MaskListData
    {
        public List<MaskData> Masks { get; set; } = new List<MaskData>();

        public UDataTable Make()
        {
            UDataTable dataTable = new UDataTable();
            dataTable.Data = new List<StructPropertyData>();
            foreach (MaskData data in Masks)
            {
                dataTable.Data.Add(data.Make());
            }
            return dataTable;
        }

        public void Read(DataTableExport dataTable)
        {
            Masks = new List<MaskData>();
            foreach (var item in dataTable.Table.Data)
            {
                MaskData maskData = new MaskData();
                maskData.Read(item);
                Masks.Add(maskData);
            }
        }
        public void Read(UDataTable dataTable)
        {
            Masks = new List<MaskData>();
            foreach (var item in dataTable.Data)
            {
                MaskData maskData = new MaskData();
                maskData.Read(item);
                Masks.Add(maskData);
            }
        }
    }

    public class MaskData
    {
        public string Name { get; set; }
        public string StructType { get; } = "ToxicGuardMaskDataTableMesh";
        public string Thumbnail { get; set; }
        public string Mesh { get; set; }
        public int AnimClass { get; set; } = -2;
        public FlagCheck CheckFlagSymbol { get; set; } = new FlagCheck();
        public ScenarioOffsetData ScenarioOffset { get; set; } = new ScenarioOffsetData();
        public bool FaceHide { get; set; } = false;
        public bool HairHide { get; set; } = false;

        public StructPropertyData Make()
        {
            StructPropertyData data = new StructPropertyData();
            data.Name = new FName(Name);
            data.StructType = new FName(StructType);
            data.Value = new List<PropertyData>();
            data.Value.Add(new SoftObjectPropertyData() { Name = new FName("Thumbnail"), Value = new FName(Thumbnail) });
            data.Value.Add(new SoftObjectPropertyData() { Name = new FName("Mesh"), Value = new FName(Mesh) });
            data.Value.Add(new ObjectPropertyData() { Name = new FName("AnimClass"), Value = new FPackageIndex(AnimClass) });
            data.Value.Add(CheckFlagSymbol.Make());
            data.Value.Add(ScenarioOffset.Make());
            data.Value.Add(new BoolPropertyData() { Name = new FName("bShouldFaceHidden"), Value = FaceHide });
            data.Value.Add(new BoolPropertyData() { Name = new FName("bShouldHairHidden"), Value = HairHide });
            return data;
        }

        public void Read(StructPropertyData Mask)
        {
            Name = Mask.Name.Value.Value;
            Thumbnail = ((SoftObjectPropertyData)Mask.Value[0]).Value.Value.Value;
            Mesh = ((SoftObjectPropertyData)Mask.Value[1]).Value.Value.Value;
            AnimClass = ((ObjectPropertyData)Mask.Value[2]).Value.Index;
            CheckFlagSymbol.Read((StrPropertyData)Mask.Value[3]);
            ScenarioOffset.Read((StructPropertyData)Mask.Value[4]);
            FaceHide = ((BoolPropertyData)Mask.Value[5]).Value;
            HairHide = ((BoolPropertyData)Mask.Value[6]).Value;
        }
    }
}
