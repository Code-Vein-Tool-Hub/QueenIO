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
    public class AccessoryListData
    {
        public List<AccessoryData> Accessories { get; set; }

        /// <summary>
        /// Makes the Data Table for the uasset file.
        /// </summary>
        /// <returns></returns>
        public UDataTable Make()
        {
            UDataTable dataTable = new UDataTable();
            dataTable.Data = new List<StructPropertyData>();
            foreach (AccessoryData data in Accessories)
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
            Accessories = new List<AccessoryData>();
            foreach (var item in dataTable.Table.Data)
            {
                AccessoryData Data = new AccessoryData();
                Data.Read(item);
                Accessories.Add(Data);
            }
        }
        /// <summary>
        /// Reads the Data Table from the uasset File.
        /// </summary>
        /// <param name="dataTable"></param>
        public void Read(UDataTable dataTable)
        {
            Accessories = new List<AccessoryData>();
            foreach (var item in dataTable.Data)
            {
                AccessoryData Data = new AccessoryData();
                Data.Read(item);
                Accessories.Add(Data);
            }
        }
    }

    public class AccessoryData
    {
        public string Name { get; set; }
        public string StructType { get; } = "AvatarCustomizeDataTableAccessoryPreset";
        public string Thumbnail { get; set; }
        public string Mesh { get; set; }
        public int AnimClass { get; set; }
        public string AttachRowName { get; set; }
        public Transform RootTransform { get; set; } = new Transform();
        public Transform OrientTransform {  get; set; } = new Transform();
        public Transform MeshTransform {  get; set; } = new Transform();
        public bool Transformable { get; set; }
        public bool ScaleNegate { get; set; }
        public string MaxColor { get; set; }
        public ColorData Color_1 { get; set; } = new ColorData();
        public ColorData Color_2 { get; set; } = new ColorData();
        public ColorData Color_3 { get; set; } = new ColorData();
        public int Cost { get; set; }
        public FlagCheck CheckFlag { get; set; } = new FlagCheck();
        public bool SpaEnable { get; set; }

        public StructPropertyData Make()
        {
            StructPropertyData data = new StructPropertyData();
            data.Name = new FName(Name);
            data.StructType = new FName(StructType);
            data.Value = new List<PropertyData>();
            data.Value.Add(new SoftObjectPropertyData() { Name = new FName("Thumbnail"), Value = new FName(Thumbnail)});
            data.Value.Add(new SoftObjectPropertyData() { Name = new FName("Mesh"), Value = new FName(Mesh) });
            data.Value.Add(new ObjectPropertyData() { Name = new FName("AnimClass"), Value = new FPackageIndex(AnimClass) });
            data.Value.Add(new NamePropertyData() { Name = new FName("AttachRowName"), Value = new FName(AttachRowName) });
            data.Value.Add(RootTransform.Make());
            data.Value.Add(OrientTransform.Make());
            data.Value.Add(MeshTransform.Make());
            data.Value.Add(new BoolPropertyData() { Name = new FName("bTransformable"), Value = Transformable });
            data.Value.Add(new BoolPropertyData() { Name = new FName("bScaleNegate"), Value = ScaleNegate });
            data.Value.Add(new EnumPropertyData() { Name = new FName("MaxColor"), Value = new FName(MaxColor) });
            data.Value.Add(Color_1.Make(0));
            data.Value.Add(Color_2.Make(1));
            data.Value.Add(Color_3.Make(2));
            data.Value.Add(new IntPropertyData() { Name = new FName("Cost"), Value = Cost });
            data.Value.Add(CheckFlag.Make());
            data.Value.Add(new BoolPropertyData() { Name = new FName("bSpaEnable"), Value = SpaEnable });

            return data;
        }

        public void Read(StructPropertyData data)
        {
            Name = data.Name.Value.Value;
            Thumbnail = ((SoftObjectPropertyData)data.Value[0]).Value.Value.Value;
            Mesh = ((SoftObjectPropertyData)data.Value[1]).Value.Value.Value;
            AnimClass = ((ObjectPropertyData)data.Value[2]).Value.Index;
            AttachRowName = ((NamePropertyData)data.Value[3]).Value.Value.Value;
            RootTransform.Read((StructPropertyData)data.Value[4]);
            OrientTransform.Read((StructPropertyData)data.Value[5]);
            MeshTransform.Read((StructPropertyData)data.Value[6]);
            Transformable = ((BoolPropertyData)data.Value[7]).Value;
            ScaleNegate = ((BoolPropertyData)data.Value[8]).Value;
            MaxColor = ((EnumPropertyData)data.Value[9]).Value.Value.Value;
            Color_1.Read((StructPropertyData)data.Value[10]);
            Color_2.Read((StructPropertyData)data.Value[11]);
            Color_3.Read((StructPropertyData)data.Value[12]);
            Cost = ((IntPropertyData)data.Value[13]).Value;
            CheckFlag.Read((StrPropertyData)data.Value[14]);
            SpaEnable = ((BoolPropertyData)data.Value[15]).Value;
        }
    }
}
