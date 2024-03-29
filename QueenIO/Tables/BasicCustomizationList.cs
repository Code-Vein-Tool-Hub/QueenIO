﻿using System;
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
        public Successor Make()
        {
            Successor successor = new Successor();
            successor.Data = new List<StructPropertyData>();
            foreach (BasicCustomizationData data in basicCustomizationDatas)
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
            data.Name = FName.FromString(Name);
            data.StructType = FName.FromString(StructType);
            data.Value = new List<PropertyData>();
            data.Value.Add(new TextPropertyData() { Name = FName.FromString("Name"), Value = new FString(TextName == null ? null : TextName, Encoding.ASCII) });
            data.Value.Add(new SoftObjectPropertyData() { Name = FName.FromString("Thumbnail"), Value = FName.FromString(Thumbnail) });
            data.Value.Add(new SoftObjectPropertyData() { Name = FName.FromString("Texture"), Value = FName.FromString(Texture) });
            return data;
        }

        /// <summary>
        /// Read the uasset object's data.
        /// </summary>
        /// <param name="data">Input Structure Property to Read</param>
        public void Read(StructPropertyData data)
        {
            Name = data.Name.ToString();
            if (((TextPropertyData)data.Value[0]).Value == null)
                    TextName = null;
            else
                TextName = ((TextPropertyData)data.Value[0]).Value.ToString();
            Thumbnail = ((SoftObjectPropertyData)data.Value[1]).Value.ToString();
            Texture = ((SoftObjectPropertyData)data.Value[2]).Value.ToString();
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

        public bool Equals(BasicCustomizationData data)
        {
            return Name == data.Name && TextName == data.TextName && Thumbnail == data.Thumbnail && Texture == data.Texture;
        }
    }
}
