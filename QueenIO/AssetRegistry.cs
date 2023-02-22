using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAssetAPI;
using GovanifY;
using System.IO;
using UAssetAPI.PropertyTypes;
using Newtonsoft.Json;

namespace QueenIO
{
    public class AssetRegistry
    {
        public byte[] Header { get; set; } //Probably a guid
        public uint Unknown { get; set; }
        public List<FAssetData> fAssetDatas { get; set; } = new List<FAssetData>();
        public Dictionary<FString, uint> keyValuePairs { get; set; } = new Dictionary<FString, uint>();

        public class FAssetData
        {
            public FName ObjectPath { get; set; }
            public FName PackagePath { get; set; }
            public FName AssetClass { get; set; }
            public FName PackageName { get; set; }
            public FName AssetName { get; set; }
            public List<Tuple<FString, FString>> TagAndValue { get; set; } = new List<Tuple<FString, FString>>();
            public List<uint> ChunkIDs { get; set; } = new List<uint>();
            public uint PackageTags { get; set; }

        }

        public void Read(byte[] infile)
        {
            MemoryStream ms = new MemoryStream(infile);
            BinaryStream bs = new BinaryStream(ms);

            List<FString> StringTable = new List<FString>();

            //Read Header Info
            Header = bs.ReadBytes(16);
            Unknown = bs.ReadUInt32();
            long StringOffset = bs.ReadInt64();
            uint EntryCount = bs.ReadUInt32();

            //Move to the string table since this info is needed for AssetData
            bs.Seek(StringOffset, SeekOrigin.Begin);
            uint stringcount = bs.ReadUInt32();

            for (uint i = 0; i < stringcount; i++)
            {
                FString fstring = new FString();
                int stringSize = bs.ReadInt32();
                //Check if string is unicode by seeing if it's negative
                if (stringSize > 0)
                {
                    fstring.Value = Encoding.ASCII.GetString(bs.ReadBytes(stringSize)).Replace("\0","");
                    fstring.Encoding = Encoding.ASCII;
                    uint hash = bs.ReadUInt32();
                }
                else
                {
                    fstring.Value = Encoding.Unicode.GetString(bs.ReadBytes((stringSize * -1) * 2)).Replace("\0", "");
                    fstring.Encoding = Encoding.Unicode;
                    uint hash = bs.ReadUInt32();
                }
                StringTable.Add(fstring);
                keyValuePairs.Add(fstring, i);
            }

            //Read each FAssetData
            bs.Seek(0x20, SeekOrigin.Begin);
            for (uint i = 0; i < EntryCount; i++)
            {
                FAssetData fAssetData   =   new FAssetData();
                fAssetData.ObjectPath   =   new FName() { Value = StringTable[(int)bs.ReadUInt32()], Number = bs.ReadInt32() };
                fAssetData.PackagePath  =   new FName() { Value = StringTable[(int)bs.ReadUInt32()], Number = bs.ReadInt32() };
                fAssetData.AssetClass   =   new FName() { Value = StringTable[(int)bs.ReadUInt32()], Number = bs.ReadInt32() };
                fAssetData.PackageName  =   new FName() { Value = StringTable[(int)bs.ReadUInt32()], Number = bs.ReadInt32() };
                fAssetData.AssetName    =   new FName() { Value = StringTable[(int)bs.ReadUInt32()], Number = bs.ReadInt32() };

                uint mapSize = bs.ReadUInt32();
                for (uint y = 0; y < mapSize; y++)
                {
                    FString Tag = StringTable[(int)bs.ReadUInt64()];
                    FString Value = new FString();
                    int stringSize = bs.ReadInt32();
                    if (stringSize > 0)
                    {
                        Value.Value = Encoding.ASCII.GetString(bs.ReadBytes(stringSize)).Replace("\0", "");
                        Value.Encoding = Encoding.ASCII;
                    }
                    else
                    {
                        Value.Value = Encoding.Unicode.GetString(bs.ReadBytes((stringSize * -1) * 2)).Replace("\0", "");
                        Value.Encoding = Encoding.Unicode;
                    }
                    fAssetData.TagAndValue.Add(new Tuple<FString, FString>(Tag, Value));
                }

                uint chunkIDCount = bs.ReadUInt32();
                for (uint y = 0; y < chunkIDCount; y++)
                {
                    fAssetData.ChunkIDs.Add(bs.ReadUInt32());
                }
                fAssetData.PackageTags = bs.ReadUInt32();
                fAssetDatas.Add(fAssetData);
            }
            bs.Close();
            ms.Close();
        }

        public byte[] Make()
        {
            MemoryStream ms = new MemoryStream();
            BinaryStream bs = new BinaryStream(ms);

            bs.Write(Header);
            bs.Write(Unknown);
            bs.Write((long)0);
            bs.Write((uint)fAssetDatas.Count);

            foreach (var fassdata in fAssetDatas)
            {
                bs.Write(GetKey(fassdata.ObjectPath.Value));
                bs.Write(fassdata.ObjectPath.Number);
                bs.Write(GetKey(fassdata.PackagePath.Value));
                bs.Write(fassdata.PackagePath.Number);
                bs.Write(GetKey(fassdata.AssetClass.Value));
                bs.Write(fassdata.AssetClass.Number);
                bs.Write(GetKey(fassdata.PackageName.Value));
                bs.Write(fassdata.PackageName.Number);
                bs.Write(GetKey(fassdata.AssetName.Value));
                bs.Write(fassdata.AssetName.Number);

                bs.Write((uint)fassdata.TagAndValue.Count);
                foreach (var tagvalue in fassdata.TagAndValue)
                {
                    bs.Write((long)GetKey(tagvalue.Item1));
                    if (tagvalue.Item2.Encoding == Encoding.ASCII)
                    {
                        bs.Write((int)tagvalue.Item2.Value.Length + 1);
                        bs.Write(Encoding.ASCII.GetBytes(tagvalue.Item2.Value));
                        bs.Write((byte)0x0);
                    }
                    else
                    {
                        bs.Write((int)(tagvalue.Item2.Value.Length + 1) * -1);
                        bs.Write(Encoding.Unicode.GetBytes(tagvalue.Item2.Value));
                        bs.Write((short)0x0);
                    }
                }

                bs.Write((uint)fassdata.ChunkIDs.Count);
                foreach (var ChunkID in fassdata.ChunkIDs)
                {
                    bs.Write((uint)ChunkID);
                }
                bs.Write((uint)fassdata.PackageTags);
            }

            //Random 8 bytes between the FAssetData array and the String table, why???
            bs.Write((long)0);

            long stringTablePOS = bs.Tell();
            bs.Write(keyValuePairs.Values.Count);
            foreach (var fstring in keyValuePairs.Keys)
            {
                if (fstring.Encoding == Encoding.ASCII)
                {
                    bs.Write((int)fstring.Value.Length + 1);
                    bs.Write(Encoding.ASCII.GetBytes(fstring.Value));
                    bs.Write((byte)0x0);
                    bs.Write(CRCGenerator.GenerateHash(fstring));
                }
                else
                {
                    bs.Write((int)(fstring.Value.Length + 1) * -1);
                    bs.Write(Encoding.Unicode.GetBytes(fstring.Value));
                    bs.Write((short)0x0);
                    bs.Write(CRCGenerator.GenerateHash(fstring));
                }
            }

            bs.Seek(0x14, SeekOrigin.Begin);
            bs.Write(stringTablePOS);

            byte[] file = ms.ToArray();
            bs.Close();
            ms.Close();
            return file;
        }

        private uint GetKey(FString fString)
        {
            uint value;
            try
            {
                value = keyValuePairs[fString];
            }
            catch (KeyNotFoundException e)
            {
                keyValuePairs.Add(fString, (uint)keyValuePairs.Count);
                value = keyValuePairs[fString];
            }
            return value;
        }
    }
}
