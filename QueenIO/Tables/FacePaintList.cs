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
    public class FacePaintList
    {
        public List<FacePaintData> FacePaints { get; set; } = new List<FacePaintData>();

        /// <summary>
        /// Makes the Data Table for the uasset file.
        /// </summary>
        /// <returns></returns>
        public UDataTable Make()
        {
            UDataTable dataTable = new UDataTable();
            dataTable.Data = new List<StructPropertyData>();
            foreach (FacePaintData data in FacePaints)
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
            FacePaints = new List<FacePaintData>();
            foreach (var item in dataTable.Table.Data)
            {
                FacePaintData Data = new FacePaintData();
                Data.Read(item);
                FacePaints.Add(Data);
            }
        }
        /// <summary>
        /// Reads the Data Table from the uasset File.
        /// </summary>
        /// <param name="dataTable"></param>
        public void Read(UDataTable dataTable)
        {
            FacePaints = new List<FacePaintData>();
            foreach (var item in dataTable.Data)
            {
                FacePaintData Data = new FacePaintData();
                Data.Read(item);
                FacePaints.Add(Data);
            }
        }
    }

    public class FacePaintData
    {
        public string Name { get; set; }
        public string StructType { get; } = "AvatarCustomizeDataTableFacePaintMaskPreset";
        public string Thumbnail { get; set; }
        public bool IsSpecialColor { get; set; }
        public string ColorPaletteRowName { get; set; }
        public string ColorName { get; set; }
        public float Opacity { get; set; }
        public string Texture { get; set; }
        public float OffsetV { get; set; }
        public float OffsetU { get; set; }
        public float Rotate { get; set; }
        public float Scale { get; set; }
        public bool Symmetry { get; set; }
        public FlagCheck CheckFlag { get; set; } = new FlagCheck();

        public StructPropertyData Make()
        {
            StructPropertyData data = new StructPropertyData();

            data.Name = new FName(Name);
            data.StructType = new FName(StructType);
            data.Value = new List<PropertyData>();
            data.Value.Add(new SoftObjectPropertyData() { Name = new FName("Thumbnail"), Value = new FName(Thumbnail) });
            data.Value.Add(new BoolPropertyData() { Name = new FName("IsSpecialColor"), Value = IsSpecialColor });
            data.Value.Add(new NamePropertyData() { Name = new FName("ColorPaletteRowName"), Value = new FName(ColorPaletteRowName) });
            data.Value.Add(new NamePropertyData() { Name = new FName("ColorName"), Value = new FName(ColorName) });
            data.Value.Add(new FloatPropertyData() {  Name = new FName("Opacity"), Value = Opacity });
            data.Value.Add(new SoftObjectPropertyData() { Name = new FName("Texture"), Value = new FName(Texture) });
            data.Value.Add(new FloatPropertyData() { Name = new FName("OffsetV"), Value = OffsetV });
            data.Value.Add(new FloatPropertyData() { Name = new FName("OffsetU"), Value = OffsetU });
            data.Value.Add(new FloatPropertyData() { Name = new FName("Rotate"), Value = Rotate });
            data.Value.Add(new FloatPropertyData() { Name = new FName("Scale"), Value = Scale });
            data.Value.Add(new BoolPropertyData() { Name = new FName("Symmetry"), Value = Symmetry });
            data.Value.Add(CheckFlag.Make());

            return data;
        }

        public void Read(StructPropertyData data)
        {
            Name = data.Name.Value.Value;
            Thumbnail = ((SoftObjectPropertyData)data.Value[0]).Value.Value.Value;
            IsSpecialColor = ((BoolPropertyData)data.Value[1]).Value;
            ColorPaletteRowName = ((NamePropertyData)data.Value[2]).Value.Value.Value;
            ColorName = ((NamePropertyData)data.Value[3]).Value.Value.Value;
            Opacity = ((FloatPropertyData)data.Value[4]).Value;
            Texture = ((SoftObjectPropertyData)data.Value[5]).Value.Value.Value;
            OffsetU = ((FloatPropertyData)data.Value[6]).Value;
            OffsetV = ((FloatPropertyData)data.Value[7]).Value;
            Rotate = ((FloatPropertyData)data.Value[8]).Value;
            Scale = ((FloatPropertyData)data.Value[9]).Value;
            Symmetry = ((BoolPropertyData)data.Value[10]).Value;
            CheckFlag.Read((StrPropertyData)data.Value[11]);
        }

        public FacePaintData Clone()
        {
            FacePaintData data = new FacePaintData();
            data.Name = Name;
            data.Thumbnail = Thumbnail;
            data.IsSpecialColor = IsSpecialColor;
            data.ColorPaletteRowName = ColorPaletteRowName;
            data.ColorName = ColorName;
            data.Opacity = Opacity;
            data.Texture = Texture;
            data.OffsetU = OffsetU;
            data.OffsetV = OffsetV;
            data.Rotate = Rotate;
            data.Scale = Scale;
            data.Symmetry = Symmetry;
            data.CheckFlag = CheckFlag;
            return data;
        }
    }
}
