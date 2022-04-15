using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// Converts an FName into the real string that would be used by the editor
        /// </summary>
        /// <param name="fName"></param>
        /// <returns></returns>
        public static string FNameToString(FName fName)
        {
            if (fName.Number > 0)
                return $"{fName.Value.Value}_{fName.Number - 1}";
            else
                return fName.Value.Value;
        }

        /// <summary>
        /// Converts a string into an FName based on how the editor will
        /// </summary>
        /// <returns></returns>
        public static FName StringToFName(string input)
        {
            //Regular Expression to check if end with an undersore followed by a number
            Regex regex = new Regex("_\\d+$");
            Match match = regex.Match(input);
            FName fName = new FName();

            if (match.Success)
            {
                fName.Value = new FString(input.Substring(0, (input.Length - match.Length)));
                fName.Number = int.Parse(match.Value.Substring(1));
            }
            else
            {
                fName.Value = new FString(input);
                fName.Number = 0;
            }

            return fName;
        }
    }
}
