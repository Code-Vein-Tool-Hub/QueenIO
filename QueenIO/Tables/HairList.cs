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
    /// Used By DT_HairList_[Female/Male]
    /// </summary>
    public class HairListData
    {
        public List<HairData> HairDataList { get; set; } = new List<HairData>();

        public UDataTable Make()
        {
            UDataTable dataTable = new UDataTable();
            dataTable.Data = new List<StructPropertyData>();
            foreach (HairData data in HairDataList)
            {
                dataTable.Data.Add(data.Make());
            }
            return dataTable;
        }

        public void Read(DataTableExport dataTable)
        {
            HairDataList = new List<HairData>();
            foreach (var item in dataTable.Table.Data)
            {
                HairData hairData = new HairData();
                hairData.Read(item);
                HairDataList.Add(hairData);
            }
        }
        public void Read(UDataTable dataTable)
        {
            HairDataList = new List<HairData>();
            foreach (var item in dataTable.Data)
            {
                HairData hairData = new HairData();
                hairData.Read(item);
                HairDataList.Add(hairData);
            }
        }
    }

    public class HairData
    {
        public string Name { get; set; }
        public string StructType { get; } = "AvatarCustomizeDataTableMeshList";
        public string TextName { get; set; }
        public string Thumbnail { get; set; }
        public string Mesh { get; set; }
        public int AnimClass { get; set; } = -2;

        public StructPropertyData Make()
        {
            StructPropertyData data = new StructPropertyData();
            data.Name = new FName(Name);
            data.StructType = new FName(StructType);
            data.Value = new List<PropertyData>();
            data.Value.Add(new TextPropertyData() { Name = new FName("Name"), Value = new FString(TextName == null ? null : TextName) });
            data.Value.Add(new SoftObjectPropertyData() { Name = new FName("Thumbnail"), Value = new FName(Thumbnail) });
            data.Value.Add(new SoftObjectPropertyData() { Name = new FName("Mesh"), Value = new FName(Mesh) });
            data.Value.Add(new ObjectPropertyData() { Name = new FName("AnimClass"), Value = new FPackageIndex(AnimClass) });
            return data;
        }

        public void Read(StructPropertyData data)
        {
            Name = data.Name.Value.Value;
            TextName = ((TextPropertyData)data.Value[0]).Value.Value;
            Thumbnail = ((SoftObjectPropertyData)data.Value[1]).Value.Value.Value;
            Mesh = ((SoftObjectPropertyData)data.Value[2]).Value.Value.Value;
            AnimClass = ((ObjectPropertyData)data.Value[3]).Value.Index;
        }
    }
}
