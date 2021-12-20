using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAssetAPI;

namespace QueenIO
{
    public class Blood
    {
        public static Relic Open(string infile)
        {
            Relic relic = new Relic();
            relic.FilePath = infile;
            relic.Read(relic.PathToReader(relic.FilePath));
            return relic;
        }

        public static void Save(Relic relic, string outfile)
        {
            bool loop = true;
            while (loop)
            {
                loop = false;
                try
                {
                    relic.Write(outfile);
                    return;
                }
                catch (NameMapOutOfRangeException ex)
                {
                    try
                    {
                        relic.AddNameReference(ex.RequiredName);
                        loop = true;
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine(ex2.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
