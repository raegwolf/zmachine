using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;
using ZMachine.V3.Structs;
using static ZMachine.V3.ZProcessor;

namespace ZMachine.V3
{
    class ZUtility
    {
        // thanks to https://www.abandonwaredos.com/docs.php?sf=Zork1_solution.txt&st=walkthrough&sg=Zork+I%3A+The+Great+Underground+Empire&idg=1405
        const string WALKTHOUGH_COMMANDS =
@"(You begin outside a white house) N, E, E, N, W, U (into the tree), GET EGG, D,
S, E, OPEN WINDOW, IN, GET SACK AND BOTTLE, W, GET LAMP AND SWORD, E, U, LIGHT 
LAMP, GET ROPE AND KNIFE, D, W, MOVE RUG (under it is a trapdoor), OPEN
TRAPDOOR, D (someboyd slams the trapdoor shut), N, KILL TROLL WITH SWORD (till
he dies), DROP SWORD, S, S, E, GET PAINTING, W, N, N, W, W, W, U, GET BAG, SW,
E, S, SE, OPEN SACK (you notice some food and a clove of garlic), GIVE LUNCH AND
WATER TO CYCLOPS (he falls asleep), ULYSSES (startled, he runs off and breaks
the door in the process! You ought to save your game here), U (the thief appears
and attacks you), GIVE EGG TO THIEF, KILL THIEF WITH KNIFE (until he dies. You
may then take the chalice and the now open egg), DROP KNIFE AND BOTTLE, GET
CHALICE AND EGG, D, E, E, OPEN CASE, PUT PAINTING IN CASE, PUT CHALICE IN CASE, PUT COINS IN CASE,
TURN OFF LAMP, E, E, E, N, W, WIND UP CANARY (inside the egg. A bird flies into
view and drops a bauble), GET BAUBLE, GET CANARY, S, E, IN, W, PUT EGG IN CASE, PUT BAUBLE IN CASE, PUT CANARY IN CASE,
OPEN TRAPDOOR, D, LIGHT LAMP, N, E, E, SE, E, TIE ROPE TO
RAILING, D, GET TORCH, EXTINGUISH LAMP, S, DROP ALL BUT TORCH, E, OPEN COFFIN
(you find a sceptre), GET COFFIN AND SCEPTRE, W, TEMPLE (you are teleported to
the thief's treasure chamber), D, E, E, PUT COFFIN IN CASE, E, E, E, E, D, D, N,
WAVE SCEPTRE (the rainbow becomes solid), E, W, GET POT (the usual one!), SW, U,
U, W, N, W, IN, W, PUT POT AND SCEPTRE IN CASE, D, N, E, E, E, ECHO (the echo
changes), GET BAR, U, E, N, GET MATCHBOOK, N, GET WRENCH AND SCREWDRIVER, PRESS
YELLOW (the bubble by the dam starts glowing), S, S, TURN BOLT WITH WRENCH (the
water drains away), DROP WRENCH, W, WAIT (5 times. The water level is low enough
for you to cross the river), N, GET TRUNK, N, GET PUMP, S, S, SE, D, W, SE, E,
D, S, TEMPLE (to the treasure chamber), D, E, E, PUT BAR AND TRUNK IN CASE, W,
W, U, TEMPLE (back again), GET ALL (incl. BELL), S, GET BOOK AND CANDLES, BLOW
OUT CANDLES, D, D, RING BELL (the spirits are frightened. You drop the candles),
LIGHT MATCH, LIGHT CANDLES WITH MATCH (the spirits are terrified), READ PRAYER
(they make their escape), S, DROP BOOK AND CANDLES, GET SKULL, N, U, N, N, N, E,
U, E, D, INFLATE BOAT WITH PUMP (the plastic is actually a small boat!), DROP
PUMP, GET IN BOAT, LAUNCH IT, WAIT 10 (you sail down-river to a buoy), GET BUOY,
AND SHOVEL, NE, DIG IN SAND WITH SHOVEL, AGAIN, AGAIN, AGAIN (you uncover a
scarab), DROP SHOVEL, GET SCARAB, SW, S, S, W (across the rainbow), W, SW, U, U,
W, N, W, IN, W, PUT SKULL IN CASE, PUT EMERALD IN CASE, PUT SCARAB IN CASE, D, N, E, N, NE, N, N, N,
GET TRIDENT, U, N, N, W, N, W, GET GARLIC, N (the bat stays away, thanks to the
garlic), E, PUT TORCH AND SCREWDRIVER IN BASKET, N, LIGHT LAMP, D, GET BRACELET,
E, NE, SE, SW, D, D, S, GET COAL, N, U, U, N, E, S, N, U, S, PUT COAL IN BASKET,
LOWER BASKET (to 'Drafty Room'), N, D, E, NE, SE, SW, D, D, W, DROP ALL, W, GET
COAL, GET TORCH, GET SCREWDRIVER, S, OPEN LID, PUT COAL IN MACHINE (to be found again
in \""Zork III\""!), CLOSE LID, TURN SWITCH WITH SCREWDRIVER (the coal turns into a
diamond), OPEN LID, GET DIAMOND, DROP SCREWDRIVER, N, PUT TORCH AND DIAMOND IN
BASKET, E, GET AL BUT TIMBER AND SACK, E, U, U, N, E, S, N, U, S, RAISE BASKET,
GET DIAMOND AND TORCH, W, GET FIGURINE, S, E, S, D(through the slide to
'Cellar'), U, PUT FIGURINE IN CASE, PUT TRIDENT IN CASE, PUT BRACELET IN CASE, PUT DIAMOND IN CASE, PUT TORCH IN CASE (a map
 appears in the case), GET MAP, E, E, S, W, SW (using the secret path), ENTER
 BARROW(""Zork II"" awaits.Later!!)";

        static readonly string[] ALPHABET_MAP ={
            "abcdefghijklmnopqrstuvwxyz",
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            " \n0123456789.,!?_#'\"/\\-:()"
            };

        static List<string> _walkthoughCommands = null;
        public static List<string> WalkthoughCommands
        {
            get
            {
                if (_walkthoughCommands == null)
                {
                    _walkthoughCommands = buildWalkthoughCommands();
                }

                return _walkthoughCommands;
            }
        }

        public static List<string> buildWalkthoughCommands()
        {

            var walkthroughCommands = WALKTHOUGH_COMMANDS.Replace("\r\n", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");

            var commands = new List<string>();

            var currentCommand = "";
            var inBrackets = false;

            foreach (var c in walkthroughCommands)
            {
                switch (c)
                {
                    case '(':
                        if (!inBrackets)
                        {
                            inBrackets = true;
                        }
                        else
                        {
                            throw new Exception();
                        }
                        break;

                    case ')':
                        if (inBrackets)
                        {
                            inBrackets = false;
                        }
                        else
                        {
                            throw new Exception();
                        }
                        break;

                    case ',':
                        if (!inBrackets)
                        {
                            commands.Add(currentCommand.Trim().ToLower());
                            currentCommand = "";
                        }
                        break;

                    default:
                        if (!inBrackets)
                        {
                            currentCommand += c;
                        }
                        break;
                }

            }

            commands.Add(currentCommand.Trim().ToLower());

            return commands;
        }


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
