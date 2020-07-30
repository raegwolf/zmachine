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

        public static ushort GetGlobalVariable(MemoryStream stream, ZHeader header, int index)
        {
            stream.Position = header.globalVariablesTableAddress + (index * 2);

            return (ushort)stream.ReadWordBe();
        }


        public static void SetGlobalVariable(MemoryStream stream, ZHeader header, int index, ushort value)
        {
            stream.Position = header.globalVariablesTableAddress + (index * 2);
            stream.WriteWordBe(value);
        }

        public static void DumpMemoryToFile(MemoryStream stream, string path)
        {
            if (File.Exists(path)) File.Delete(path);

            File.WriteAllBytes(path, stream.ToArray());

            Console.WriteLine("Dumped memory");
        }

        
    }
}
