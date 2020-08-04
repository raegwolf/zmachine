using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    {
        // auto commands used for debugging. these will automatically execute
        string[] _autoCommands = new string[] { "n", "e", "open window", "w", "w", "take lantern", "light lantern", "e" };
        int _autoCommandIndex = 0;

        public ushort print(CallState state)
        {
            ZUtility.Write(state.Instruction.Text, false);

            return 0;
        }

        public ushort print_ret(CallState state)
        {
            ZUtility.Write(state.Instruction.Text + "\r\n", false);

            return 0;
        }

        public ushort print_num(ushort value, CallState state)
        {
            ZUtility.Write(value.ToString(), false);

            return 0;
        }

        public ushort print_char(ushort value, CallState state)
        {
            ZUtility.Write(((char)value).ToString(), false);

            return 0;
        }

        public ushort new_line(CallState state)
        {
            ZUtility.WriteLine("", false);

            return 0;
        }

        public ushort print_obj(ushort obj, CallState state)
        {
            ZUtility.Write(Resources.Objects[obj].Name, false);

            return 0;
        }

        public ushort print_addr(ushort address, CallState state)
        {
            Resources.Stream.Position = address;

            var isEnd = false;
            var zcharacters = new List<byte>();

            while (!isEnd)
            {
                zcharacters.AddRange(ZUtility.ZCharactersFromBytes((byte)Resources.Stream.ReadByte(), (byte)Resources.Stream.ReadByte(), out isEnd));
            }
            var text = ZUtility.TextFromZCharacters(zcharacters.ToArray(), Resources.Abbreviations);

            ZUtility.Write(text, false);

            return 0;
        }

        public ushort print_paddr(ushort packedAddress, CallState state)
        {
            Resources.Stream.Position = packedAddress * 2;

            var isEnd = false;
            var zcharacters = new List<byte>();

            while (!isEnd)
            {
                zcharacters.AddRange(ZUtility.ZCharactersFromBytes((byte)Resources.Stream.ReadByte(), (byte)Resources.Stream.ReadByte(), out isEnd));
            }
            var text = ZUtility.TextFromZCharacters(zcharacters.ToArray(), Resources.Abbreviations);

            ZUtility.Write(text, false);

            return 0;
        }

        

        public ushort sread(ushort text, ushort parse, CallState state)
        {   

            Resources.Stream.Position = text;
            var maxCommandLength = Resources.Stream.ReadByte();
            var command = "";

            if (_autoCommandIndex < _autoCommands.Length)
            {
                command = _autoCommands[_autoCommandIndex];
                _autoCommandIndex++;
            }
            else
            {
                command = Console.ReadLine().ToLower().Trim();
            }

            // TODO: trim command to max length
            // TODO: validate we're not exceeding permitted length for parse
            var words = command.Split(new string[] { " " }, StringSplitOptions.None);
            var wordCharOffset = 0;

            // write the command to the text buffer from byte 1 onwards
            //command = command.Replace(" ", "");
            var commandBytes = System.Text.Encoding.UTF8.GetBytes(command + new string('\0', maxCommandLength - command.Length - 1));
            Resources.Stream.WriteBytes(commandBytes);

            // write the number of words into byte 1 of the address of parse
            Resources.Stream.Position = parse;
            var maxParseLength = Resources.Stream.ReadByte();
            Resources.Stream.WriteByte((byte)words.Length);

            for (int i = 0; i < words.Length; i++)
            {
                var matchWord = words[i];

                // words can only be 6 chars so trim if necessary
                if (matchWord.Length > 6)
                {
                    matchWord = matchWord.Substring(0, 6);
                }

                // look up the address of the word in the dicitonary
                var match = Resources.Dictionary.FirstOrDefault(f => f.Value.Equals(matchWord));

                if (match.Value == null)
                {
                    // word not in dictionary? write 0
                    Resources.Stream.WriteWord(0);
                }
                else
                {
                    // word in dictionary? write address of the word in the dictionary
                    Resources.Stream.WriteWord((ushort)(match.Key));
                }

                // write number of letters in word
                Resources.Stream.WriteByte((byte)(words[i].Length));

                Resources.Stream.WriteByte((byte)(wordCharOffset + 1));

                wordCharOffset += words[i].Length + 1;
            }

            return 0;
        }



    }
}
