using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZMachine.V3.Objects;
using static ZMachine.V3.ZProcessor;

namespace ZMachine.V3
{
    class ZUtility
    {
        
        static readonly string[] ALPHABET_MAP = {
            "abcdefghijklmnopqrstuvwxyz",
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            " \n0123456789.,!?_#'\"/\\-:()"
            };

      

        public static byte[] ZCharactersFromBytes(byte[] array)
        {
            var zcharacters = new List<byte>();

            var isEnd = false;

            for (int i = 0; i < array.Length; i += 2)
            {
                zcharacters.AddRange(ZCharactersFromBytes(array[i], array[i + 1], out isEnd));
            }

            return zcharacters.ToArray();
        }

        public static byte[] ZCharactersFromBytes(byte byte1, byte byte2, out bool isEnd)
        {
            var chars = new byte[3];

            chars[0] = (byte)((byte1 & 0b01111100) >> 2);
            chars[1] = (byte)(((byte1 & 0b00000011) << 3) + ((byte2 & 0b11100000) >> 5));
            chars[2] = (byte)(byte2 & 0b0011111);

            isEnd = ((byte1 & 0b10000000) == 0b10000000);

            return chars;

        }

        public static string TextFromZCharacters(byte[] zcharacters, List<string> abbreviations)
        {

            var alphabetIndex = 0;
            var s = "";

            var i = 0;
            while (i < zcharacters.Length)
            {
                switch (zcharacters[i])
                {
                    case 0:
                        s += " ";
                        break;

                    case 1:
                    case 2:
                    case 3:
                        if (abbreviations == null)
                        {
                            throw new Exception("Request for abbreviations was encountered but abbreviations weren't provided.");
                        }

                        // look up in abbreviations table
                        var z = zcharacters[i];
                        i++;
                        var x = zcharacters[i];

                        var abbreviationIndex = (32 * (z - 1)) + x;
                        if (abbreviations.Count() < abbreviationIndex)
                        {
                            throw new Exception("Abbreviation doesn't exist.");
                        }
                        s += abbreviations[abbreviationIndex];
                        alphabetIndex = 0; // reset alphabet table after abbreviation
                        break;

                    case 4:
                        alphabetIndex = 1;
                        break;

                    case 5:
                        alphabetIndex = 2;
                        break;

                    case 6:
                        // two subsequent chars specify a 10bit ZSCII char code.
                        // only applies if we're in alphabet 2 (A2)
                        if (alphabetIndex == 2)
                        {
                            var b1 = zcharacters[i + 1];
                            var b2 = zcharacters[i + 2];
                            var c = (b1 << 5) + b2;
                            s += ((char)c).ToString();
                            i += 2;
                        }
                        else
                        {
                            s += ALPHABET_MAP[alphabetIndex][zcharacters[i] - 6];
                            alphabetIndex = 0;
                        }
                        break;

                    default:
                        s += ALPHABET_MAP[alphabetIndex][zcharacters[i] - 6];
                        alphabetIndex = 0;
                        break;
                }

                i++;
            }

            return s;
        }

        public static ushort GetGlobalVariable(ZMemoryStream stream, ZHeader header, int index)
        {
            stream.Position = header.globalVariablesTableAddress + (index * 2);
            return (ushort)stream.ReadWord();
        }

        public static void SetGlobalVariable(ZMemoryStream stream, ZHeader header, int index, ushort value)
        {
            stream.Position = header.globalVariablesTableAddress + (index * 2);
            stream.WriteWord(value);
        }

        public static void DumpMemoryToFile(ZMemoryStream stream, string path)
        {
            if (File.Exists(path)) File.Delete(path);

            File.WriteAllBytes(path, stream.ToArray());

            ZUtility.WriteDebugLine("Dumped memory");
        }

        public static void PrintObjects(ZMemoryStream stream, Dictionary<int, ZObject> objects, bool includeProperties, int parent)
        {

            var sb = new StringBuilder();

            printObjectsInternal(stream, objects, includeProperties, parent, 0, sb);

            ZUtility.WriteConsole(sb.ToString());

        }

        private static void printObjectsInternal(ZMemoryStream stream, Dictionary<int, ZObject> objects, bool includeProperties, int obj, int depth, StringBuilder sb)
        {
            var name = obj == 0 ? "(Root)" : objects[obj].Name;

            // print the details of this object
            sb.AppendLine($"{new string(' ', depth * 2)}{obj.ToString("X4")} \"{name}\"");

            if ((includeProperties) && (obj > 0))
            {
                stream.Position = objects[obj].FirstPropertyAddress;

                var propertyHeader = stream.ReadByte();

                // scan downwards through properties (they're ordered ascending) until we reach the desired one
                while (propertyHeader != 0)
                {
                    // top 3 bits contain the length of the property value - 1 (that's why we add + 1 to the number of bytes we need to read)
                    var propertyLength = (byte)(((propertyHeader & 0b11100000) >> 5) + 1);

                    // bottom 5 bits indicate property number
                    var propertyNumber = (propertyHeader & 0b11111);

                    var propertyData = stream.ReadBytes(propertyLength);

                    sb.AppendLine($"{new string(' ', depth * 2)}  Property {propertyNumber.ToString("X2")}: {BitConverter.ToString(propertyData).Replace("-", " ")}");

                    propertyHeader = stream.ReadByte();

                }

            }

            // get all children (child + siblings)
            var children = new List<int>();
            foreach (var testChild in objects)
            {
                var entry = objects[testChild.Key].GetObjectEntry(stream);

                if (entry.parent != obj)
                {
                    continue;
                }

                children.Add(testChild.Key);
            }

            // recurse into them
            foreach (var child in children)
            {
                printObjectsInternal(stream, objects, includeProperties, child, depth + 1, sb);
            }

        }

        public static void WriteDebugLine(string text)
        {
            Debug.WriteLine(text);
        }

        public static void WriteConsole(string text)
        {
            Debug.WriteLine(text);
            Console.Write(text);
        }

    }
}
