using QueenIO.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAssetAPI.StructTypes;
using UAssetAPI;
using UAssetAPI.PropertyTypes;
using System.Reflection;

namespace QueenIO.Mods
{
    public class ModControlFrameworkListData
    {
        public List<ModControlFrameworkData> SpawnerList { get; set; }

        public Successor Make()
        {
            Successor successor = new Successor();
            successor.Data = new List<StructPropertyData>();
            foreach (ModControlFrameworkData data in SpawnerList)
            {
                successor.Data.Add(data.Make());
            }
            return successor;
        }

        public void Read(DataTableExport dataTable)
        {
            SpawnerList = new List<ModControlFrameworkData>();
            foreach (var item in dataTable.Table.Data)
            {
                ModControlFrameworkData Data = new ModControlFrameworkData();
                Data.Read(item);
                SpawnerList.Add(Data);
            }
        }

        public void Read(UDataTable dataTable)
        {
            SpawnerList = new List<ModControlFrameworkData>();
            foreach (var item in dataTable.Data)
            {
                ModControlFrameworkData Data = new ModControlFrameworkData();
                Data.Read(item);
                SpawnerList.Add(Data);
            }
        }
    }

    public class ModControlFrameworkData
    {
        public string Name { get; set; }
        public string StructType { get; } = "STR_Spawners";
        public Key Key { get; set; } = new Key();
        public string Spawner { get; set; }

        public StructPropertyData Make()
        {
            StructPropertyData data = new StructPropertyData();
            data.Name = FName.FromString(Name);
            data.StructType = FName.FromString(StructType);
            data.Value = new List<PropertyData>
            {
                Key.Make("Key_2_5889D6384413CE94CB77A8A04D9557F5"),
                new SoftObjectPropertyData() { Name = FName.FromString("Spawner_18_220BE5D9463C7845ABB75D808A4F15EA"), Value = FName.FromString(Spawner) }
            };
            return data;
        }

        public void Read(StructPropertyData data)
        {
            Name = data.Name.ToString();
            Key.Read(((StructPropertyData)data.Value[0]));
            Spawner = ((SoftObjectPropertyData)data.Value[1]).Value.ToString();
        }
    }
}
