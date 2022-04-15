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

        public SortedDictionary<int, Import> GetImports()
        {
            SortedDictionary<int, Import> imports = new SortedDictionary<int, Import>();

            for (int i = 0; i < Imports.Count; i++)
            {
                Import import = new Import();
                import.Read(Imports[i]);
                imports.Add((i - (i * 2)) - 1, import);
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
