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
        public Successor Make()
        {
            Successor successor = new Successor();
            successor.Data = new List<StructPropertyData>();
            foreach (AccessoryData data in Accessories)
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
        public ColorData Color_1 { get; set; } = new ColorData() { Name = "Color", StructType = "AvatarCustomizeDataTableAccessoryColor" };
        public ColorData Color_2 { get; set; } = new ColorData() { Name = "Color", StructType = "AvatarCustomizeDataTableAccessoryColor" };
        public ColorData Color_3 { get; set; } = new ColorData() { Name = "Color", StructType = "AvatarCustomizeDataTableAccessoryColor" };
        public int Cost { get; set; }
        public FlagCheck CheckFlag { get; set; } = new FlagCheck();
        public bool SpaEnable { get; set; }

        public StructPropertyData Make()
        {
            StructPropertyData data = new StructPropertyData();
            data.Name = FName.FromString(Name);
            data.StructType = FName.FromString(StructType);
            data.Value = new List<PropertyData>();
            data.Value.Add(new SoftObjectPropertyData() { Name = FName.FromString("Thumbnail"), Value = FName.FromString(Thumbnail) });
            data.Value.Add(new SoftObjectPropertyData() { Name = FName.FromString("Mesh"), Value = FName.FromString(Mesh) });
            data.Value.Add(new ObjectPropertyData() { Name = FName.FromString("AnimClass"), Value = new FPackageIndex(AnimClass) });
            if (AttachRowName == null)
                data.Value.Add(new NamePropertyData() { Name = FName.FromString("AttachRowName"), Value = FName.FromString("None") });
            else
                data.Value.Add(new NamePropertyData() { Name = FName.FromString("AttachRowName"), Value = FName.FromString(AttachRowName) });
            data.Value.Add(RootTransform.Make("RootTransform"));
            data.Value.Add(OrientTransform.Make("OrientTransform"));
            data.Value.Add(MeshTransform.Make("MeshTransform"));
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString("bTransformable"), Value = Transformable });
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString("bScaleNegate"), Value = ScaleNegate });
            data.Value.Add(new EnumPropertyData() { Name = FName.FromString("MaxColor"), EnumType = FName.FromString("EAvatarCustomizeAccessoryColorSlot"), Value = FName.FromString(MaxColor) });
            data.Value.Add(Color_1.Make(0));
            data.Value.Add(Color_2.Make(1));
            data.Value.Add(Color_3.Make(2));
            data.Value.Add(new IntPropertyData() { Name = FName.FromString("Cost"), Value = Cost });
            data.Value.Add(CheckFlag.Make());
            data.Value.Add(new BoolPropertyData() { Name = FName.FromString("bSpaEnable"), Value = SpaEnable });

            return data;
        }

        public void Read(StructPropertyData data)
        {
            Name = data.Name.ToString();
            Thumbnail = ((SoftObjectPropertyData)data.Value[0]).Value.ToString();
            Mesh = ((SoftObjectPropertyData)data.Value[1]).Value.ToString();
            AnimClass = ((ObjectPropertyData)data.Value[2]).Value.Index;
            AttachRowName = ((NamePropertyData)data.Value[3]).Value.ToString();
            RootTransform.Read((StructPropertyData)data.Value[4]);
            OrientTransform.Read((StructPropertyData)data.Value[5]);
            MeshTransform.Read((StructPropertyData)data.Value[6]);
            Transformable = ((BoolPropertyData)data.Value[7]).Value;
            ScaleNegate = ((BoolPropertyData)data.Value[8]).Value;
            MaxColor = ((EnumPropertyData)data.Value[9]).Value.ToString();
            Color_1.Read((StructPropertyData)data.Value[10]);
            Color_1.StructType = "AvatarCustomizeDataTableAccessoryColor";
            Color_2.Read((StructPropertyData)data.Value[11]);
            Color_2.StructType = "AvatarCustomizeDataTableAccessoryColor";
            Color_3.Read((StructPropertyData)data.Value[12]);
            Color_3.StructType = "AvatarCustomizeDataTableAccessoryColor";
            Cost = ((IntPropertyData)data.Value[13]).Value;
            CheckFlag.Read((StrPropertyData)data.Value[14]);
            SpaEnable = ((BoolPropertyData)data.Value[15]).Value;
        }

        public AccessoryData Clone()
        {
            AccessoryData data = new AccessoryData();
            data.Name = Name;
            data.Thumbnail = Thumbnail;
            data.Mesh = Mesh;
            data.AnimClass = AnimClass;
            data.AttachRowName = AttachRowName;
            data.RootTransform = RootTransform;
            data.OrientTransform = OrientTransform;
            data.MeshTransform = MeshTransform;
            data.Transformable = Transformable;
            data.ScaleNegate = ScaleNegate;
            data.MaxColor = MaxColor;
            data.Color_1 = Color_1;
            data.Color_2 = Color_2;
            data.Color_3 = Color_3;
            data.Cost = Cost;
            data.CheckFlag = CheckFlag;
            data.SpaEnable = SpaEnable;
            return data;
        }

        public bool Equals(AccessoryData data)
        {
            return Name == data.Name &&
                Thumbnail == data.Thumbnail &&
                Mesh == data.Mesh &&
                AnimClass == data.AnimClass &&
                AttachRowName == data.AttachRowName &&
                RootTransform.Equals(data.RootTransform) &&
                OrientTransform.Equals(data.OrientTransform) &&
                MeshTransform.Equals(data.MeshTransform) &&
                Transformable == data.Transformable &&
                ScaleNegate == data.ScaleNegate &&
                MaxColor == data.MaxColor &&
                Color_1.Equals(data.Color_1) &&
                Color_2.Equals(data.Color_2) &&
                Color_3.Equals(data.Color_3) &&
                Cost == data.Cost &&
                CheckFlag.Equals(data.CheckFlag) &&
                SpaEnable == data.SpaEnable;
        }
    }
}
