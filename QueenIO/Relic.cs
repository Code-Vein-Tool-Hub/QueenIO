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
        public new UE4Version EngineVersion = UE4Version.VER_UE4_18;
        public DataTableExport GetDataTable()
        {
            return (DataTableExport)Exports[0];
        }

        public void WriteDataTable(UDataTable table)
        {
            ((DataTableExport)Exports[0]).Table = table;
        }
    }
}
