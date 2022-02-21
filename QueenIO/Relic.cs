using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAssetAPI;

namespace QueenIO
{
    public class Relic : UAsset
    {
        public Relic()
        {
            EngineVersion = UE4Version.VER_UE4_18;
        }

        public DataTableExport GetDataTable()
        {
            return (DataTableExport)Exports[0];
        }

        public void WriteDataTable(UDataTable table)
        {
            ((DataTableExport)Exports[0]).Table = table;
        }

        public SortedDictionary<int, string> GetImports()
        {
            SortedDictionary<int, string> imports = new SortedDictionary<int, string>();

            imports.Add(0, "none");
            imports.Add(1, Exports[0].ObjectName.Value.Value);
            for (int i = 0; i < Imports.Count; i++)
            {
                string name = Imports[i].ObjectName.Value.Value;
                if (Imports[i].ObjectName.Number > 0)
                    imports.Add((i - (i * 2)) - 1, $"{name}_{Imports[i].ObjectName.Number - 1}");
                else
                    imports.Add((i - (i * 2)) - 1, name);
            }

            return imports;
        }
    }

    public class Successor : UDataTable
    {
        public object Table { get; set; }

        public UDataTable TableExport()
        {
            return this;
        }
    }
}
