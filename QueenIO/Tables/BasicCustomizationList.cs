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
    /// Used for DT_FaceScarList, DT_EyeBaseList, DT_EyeDetailList, DT_EyeHighLightList, DT_EyelashList_Female, and DT_BrowList_Female
    /// </summary>
    public class BasicCustomizationListData
    {
        /// <summary>
        /// List of Objects in Data Table.
        /// </summary>
        public List<BasicCustomizationData> basicCustomizationDatas = new List<BasicCustomizationData>();

        /// <summary>
        /// Makes the Data Table for the uasset file.
        /// </summary>
        /// <returns></returns>
        public UDataTable Make()
        {
            UDataTable dataTable = new UDataTable();
            dataTable.Data = new List<StructPropertyData>();
            foreach (BasicCustomizationData data in basicCustomizationDatas)
            {
                dataTable.Data.Add(data.Make());
            }
            return dataTable;
        }

        /// <summary>
        /// Reads the Data Table from the uasset File.
        /// </summary>
        /// <param name="dataTable"></param>
        public void Read(DataTableExport dataTable)
        {
            basicCustomizationDatas = new List<BasicCustomizationData>();
            foreach (var item in dataTable.Table.Data)
            {
                BasicCustomizationData Data = new BasicCustomizationData();
                Data.Read(item);
                basicCustomizationDatas.Add(Data);
            }
        }
        /// <summary>
        /// Reads the Data Table from the uasset File.
        /// </summary>
        /// <param name="dataTable"></param>
        public void Read(UDataTable dataTable)
        {
            basicCustomizationDatas = new List<BasicCustomizationData>();
            foreach (var item in dataTable.Data)
            {
                BasicCustomizationData Data = new BasicCustomizationData();
                Data.Read(item);
                basicCustomizationDatas.Add(Data);
            }
        }
    }

    /// <summary>
    /// Entry used in BasicCustomizationListData.
    /// </summary>
    public class BasicCustomizationData
    {
        /// <summary>
        /// Entry Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Structure Type Name.
        /// </summary>
        public string StructType { get; } = "AvatarCustomizeDataTableMeshList";
        /// <summary>
        /// Name of the Entry Item.
        /// </summary>
        public string TextName { get; set; }
        /// <summary>
        /// Thumbnail for the UI option of the Item.
        /// </summary>
        public string Thumbnail { get; set; }
        /// <summary>
        /// Texture for the Item to use.
        /// </summary>
        public string Texture { get; set; }

        /// <summary>
        /// Makes the data object for the uasset file.
        /// </summary>
        /// <returns></returns>
        public StructPropertyData Make()
        {
            StructPropertyData data = new StructPropertyData();
            data.Name = new FName(Name);
            data.StructType = new FName(StructType);
            data.Value = new List<PropertyData>();
            data.Value.Add(new TextPropertyData() { Name = new FName("Name"), Value = new FString(TextName == null ? null : TextName, Encoding.ASCII) });
            data.Value.Add(new SoftObjectPropertyData() { Name = new FName("Thumbnail"), Value = new FName(Thumbnail) });
            data.Value.Add(new SoftObjectPropertyData() { Name = new FName("Texture"), Value = new FName(Texture) });
            return data;
        }

        /// <summary>
        /// Read the uasset object's data.
        /// </summary>
        /// <param name="data">Input Structure Property to Read</param>
        public void Read(StructPropertyData data)
        {
            Name = data.Name.Value.Value;
            if (((TextPropertyData)data.Value[0]).Value == null)
                    TextName = null;
            else
                TextName = ((TextPropertyData)data.Value[0]).Value.Value;
            Thumbnail = ((SoftObjectPropertyData)data.Value[1]).Value.Value.Value;
            Texture = ((SoftObjectPropertyData)data.Value[2]).Value.Value.Value;
        }

        public BasicCustomizationData Clone()
        {
            BasicCustomizationData data = new BasicCustomizationData();
            data.Name = Name;
            data.TextName = TextName;
            data.Thumbnail = Thumbnail;
            data.Texture = Texture;
            return data;
        }
    }
}
