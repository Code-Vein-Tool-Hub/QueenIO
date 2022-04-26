using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAssetAPI;
using UAssetAPI.PropertyTypes;
using UAssetAPI.StructTypes;

namespace QueenIO.Structs
{
    public class InnerPartsVisibility
    {
        public string Name { get; set; }
        public string StructType { get; } = "STR_InnerPartsVisibility";
        public string OuterKey { get; set; } = string.Empty;
        public bool HidePartsA { get; set; } = false;
        public bool HidePartsB { get; set; } = false;
        public bool HidePartsC { get; set; } = false;
        public bool HidePartsD { get; set; } = false;
        public bool HidePartsE { get; set; } = false;
        public bool HidePartsF { get; set; } = false;
        public bool HidePartsG { get; set; } = false;
        public bool HidePartsH { get; set; } = false;
        public bool HideRightArm { get; set; } = false;

        public Dictionary<string, string> Names = new Dictionary<string, string>()
        {
            {"OuterKey", "OuterKey_25_058C977A47EC09FAAF5203956C0B3277" },
            {"HidePartsA", "HidePartsA_1_5866C45A42396FC79F70AD8FB6BF236F" },
            {"HidePartsB", "HidePartsB_3_BA17F0904FF54D282769B68BEBE235D0" },
            {"HidePartsC", "HidePartsC_5_05833D82444C56B2B0E6F2940A142D5E" },
            {"HidePartsD", "HidePartsD_7_DD7E20BB401DCD9B7458A4853A980A17" },
            {"HidePartsE", "HidePartsE_9_746FA300465CB0C947A7CEA79898828E" },
            {"HidePartsF", "HidePartsF_11_6BCE80B14ABF3843D153129C2062C2F5" },
            {"HidePartsG", "HidePartsG_13_4B78552447831622C76D9C8E3FEF70E6" },
            {"HidePartsH", "HidePartsH_15_80FDF526465158C731A5A39B1372CD2D" },
            {"HideRightArm", "HideRightArm_24_295D1E894B7F76312B1941927FF1F99E" }
        };

        public StructPropertyData Make()
        {
            StructPropertyData data = new StructPropertyData();
            data.Name = FName.FromString(Name);
            data.StructType = FName.FromString(StructType);
            data.Value = new List<PropertyData>();
            data.Value.Add(new SoftObjectPropertyData() { Name = FName.FromString(Names["OuterKey"]), Value = new FName(OuterKey) });
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString(Names["HidePartsA"]), Value = HidePartsA });
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString(Names["HidePartsB"]), Value = HidePartsB });
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString(Names["HidePartsC"]), Value = HidePartsC });
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString(Names["HidePartsD"]), Value = HidePartsD });
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString(Names["HidePartsE"]), Value = HidePartsE });
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString(Names["HidePartsF"]), Value = HidePartsF });
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString(Names["HidePartsG"]), Value = HidePartsG });
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString(Names["HidePartsH"]), Value = HidePartsH });
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString(Names["HideRightArm"]), Value = HideRightArm });
            return data;
        }

        public void Read(StructPropertyData data)
        {
            Name = data.Name.ToString();
            OuterKey = ((SoftObjectPropertyData)data.Value[0]).Value.ToString();
            HidePartsA = ((BoolPropertyData)data.Value[1]).Value;
            HidePartsB = ((BoolPropertyData)data.Value[2]).Value;
            HidePartsC = ((BoolPropertyData)data.Value[3]).Value;
            HidePartsD = ((BoolPropertyData)data.Value[4]).Value;
            HidePartsE = ((BoolPropertyData)data.Value[5]).Value;
            HidePartsF = ((BoolPropertyData)data.Value[6]).Value;
            HidePartsG = ((BoolPropertyData)data.Value[7]).Value;
            HidePartsH = ((BoolPropertyData)data.Value[8]).Value;
            HideRightArm = ((BoolPropertyData)data.Value[9]).Value;
        }

        public bool Equals(InnerPartsVisibility visibility)
        {
            return Name == visibility.Name &&
                OuterKey == visibility.OuterKey &&
                HidePartsA == visibility.HidePartsA &&
                HidePartsB == visibility.HidePartsB &&
                HidePartsC == visibility.HidePartsC &&
                HidePartsD == visibility.HidePartsD &&
                HidePartsE == visibility.HidePartsE &&
                HidePartsF == visibility.HidePartsF &&
                HidePartsG == visibility.HidePartsG &&
                HidePartsH == visibility.HidePartsH &&
                HideRightArm == visibility.HideRightArm;
        }
    }
}
