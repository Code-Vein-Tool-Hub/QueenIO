using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueenIO.Structs;
using UAssetAPI;
using UAssetAPI.StructTypes;

namespace QueenIO.Tables
{
    public class InnerPartsVisibilityByOuter
    {
        public List<PartsVisibilityByOuter> partsVisibilities { get; set; }

        public Successor Make()
        {
            Successor successor = new Successor();
            successor.Data = new List<StructPropertyData>();
            foreach (PartsVisibilityByOuter data in partsVisibilities)
            {
                successor.Data.Add(data.Make());
            }
            return successor;
        }

        public void Read(DataTableExport dataTable)
        {
            partsVisibilities = new List<PartsVisibilityByOuter>();
            foreach (var item in dataTable.Table.Data)
            {
                PartsVisibilityByOuter parts = new PartsVisibilityByOuter();
                parts.Read(item);
                partsVisibilities.Add(parts);
            }
        }
        public void Read(UDataTable dataTable)
        {
            partsVisibilities = new List<PartsVisibilityByOuter>();
            foreach (var item in dataTable.Data)
            {
                PartsVisibilityByOuter parts = new PartsVisibilityByOuter();
                parts.Read(item);
                partsVisibilities.Add(parts);
            }
        }
    }
}
