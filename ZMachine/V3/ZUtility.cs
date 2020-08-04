using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZMachine.V3.Structs;
using static ZMachine.V3.ZProcessor;

namespace ZMachine.V3
{
    class ZUtility
    {
        static readonly string[] ALPHABET_MAP ={
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
        public static void WriteLine(string text, bool isDebug)
        {
            Write(text + "\r\n", isDebug);
        }

        public static void Write(string text, bool isDebug)
        {
            Debug.Write(text);

            if (isDebug)
            {

                //Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            else
            {
                Console.Write(text);
                //   Console.ForegroundColor = ConsoleColor.White;
            }

            //  Console.Write(text);

            // Console.ResetColor();
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

            ZUtility.WriteLine("Dumped memory", true);
        }

        public static void PrintObjects(ZMemoryStream stream, Dictionary<int, ZObject> objects, int parent)
        {
            printObjectsInternal(stream, objects, parent, 0);

        }

        private static void printObjectsInternal(ZMemoryStream stream, Dictionary<int, ZObject> objects, int obj, int depth)
        {
            // print the details of this object
            Console.WriteLine($"{new string(' ', depth * 2)}{obj.ToString("X4")} \"{objects[obj].Name}\"");

            // get all children (child + siblings)
            var entry = objects[obj].GetObjectEntry(stream);

            var currentChild = entry.child;

            if (currentChild == 0)
            {
                return;
            }

            var children = new List<int>();

            while (currentChild > 0)
            {
                children.Add(currentChild);
                entry = objects[currentChild].GetObjectEntry(stream);
                currentChild = entry.sibling;
            }

            // recurse into them
            foreach (var child in children)
            {
                printObjectsInternal(stream, objects, child, depth + 1);
            }

        }

     

    }
}
