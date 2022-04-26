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
    /// <summary>
    /// Used by DT_InnerFrameList_[Female/Male] and DT_OuterMaskList_[Female/Male]
    /// </summary>
    public class MaskListData
    {
        /// <summary>
        /// List of Objects in Data Table.
        /// </summary>
        public List<MaskData> Masks { get; set; } = new List<MaskData>();

        /// <summary>
        /// Makes the Data Table for the uasset file.
        /// </summary>
        /// <returns></returns>
        public Successor Make()
        {
            Successor successor = new Successor();
            successor.Data = new List<StructPropertyData>();
            foreach (MaskData data in Masks)
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
            Masks = new List<MaskData>();
            foreach (var item in dataTable.Table.Data)
            {
                MaskData maskData = new MaskData();
                maskData.Read(item);
                Masks.Add(maskData);
            }
        }
        /// <summary>
        /// Reads the Data Table from the uasset File.
        /// </summary>
        /// <param name="dataTable"></param>
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

    /// <summary>
    /// Entry used in MaskListData.
    /// </summary>
    public class MaskData
    {
        public string Name { get; set; }
        public string StructType { get; } = "ToxicGuardMaskDataTableMesh";
        public string Thumbnail { get; set; }
        public string Mesh { get; set; }
        public int AnimClass { get; set; } = -2;
        public FlagCheck CheckFlagSymbol { get; set; } = new FlagCheck();
        public ScenarioOffsetData ScenarioOffset { get; set; } = new ScenarioOffsetData() { Z = -150 };
        public bool FaceHide { get; set; } = false;
        public bool HairHide { get; set; } = false;

        public StructPropertyData Make()
        {
            StructPropertyData data = new StructPropertyData();
            data.Name = FName.FromString(Name);
            data.StructType = FName.FromString(StructType);
            data.Value = new List<PropertyData>();
            data.Value.Add(new SoftObjectPropertyData() { Name = FName.FromString("Thumbnail"), Value = FName.FromString(Thumbnail) });
            data.Value.Add(new SoftObjectPropertyData() { Name = FName.FromString("Mesh"), Value = FName.FromString(Mesh) });
            data.Value.Add(new ObjectPropertyData() { Name = FName.FromString("AnimClass"), Value = new FPackageIndex(AnimClass) });
            data.Value.Add(CheckFlagSymbol.Make());
            data.Value.Add(ScenarioOffset.Make());
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString("bShouldFaceHidden"), Value = FaceHide });
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString("bShouldHairHidden"), Value = HairHide });
            return data;
        }

        public void Read(StructPropertyData Mask)
        {
            Name = Mask.Name.Value.Value;
            Thumbnail = ((SoftObjectPropertyData)Mask.Value[0]).Value.ToString();
            Mesh = ((SoftObjectPropertyData)Mask.Value[1]).Value.ToString();
            AnimClass = ((ObjectPropertyData)Mask.Value[2]).Value.Index;
            CheckFlagSymbol.Read((StrPropertyData)Mask.Value[3]);
            ScenarioOffset.Read((StructPropertyData)Mask.Value[4]);
            try { FaceHide = ((BoolPropertyData)Mask.Value[5]).Value; } catch(ArgumentOutOfRangeException e) { Console.WriteLine("Hide Face property missing"); }
            try { HairHide = ((BoolPropertyData)Mask.Value[6]).Value; } catch (ArgumentOutOfRangeException e) { Console.WriteLine("Hide Hair property missing"); }
        }

        public MaskData Clone()
        {
            MaskData data = new MaskData();
            data.Name = Name;
            data.Thumbnail = Thumbnail;
            data.Mesh = Mesh;
            data.AnimClass = AnimClass;
            data.CheckFlagSymbol = CheckFlagSymbol;
            data.ScenarioOffset = ScenarioOffset;
            data.FaceHide = FaceHide;
            data.HairHide = HairHide;
            return data;
        }

        public bool Equals(MaskData mask)
        {
            return Name == mask.Name &&
                Thumbnail == mask.Thumbnail &&
                Mesh == mask.Mesh &&
                AnimClass == mask.AnimClass &&
                CheckFlagSymbol.Equals(mask.CheckFlagSymbol) &&
                ScenarioOffset.Equals(mask.ScenarioOffset) &&
                FaceHide == mask.FaceHide &&
                HairHide == mask.HairHide;
        }
    }
}
