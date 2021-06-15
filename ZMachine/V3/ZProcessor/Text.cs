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

        public ushort print()
        {
            this.Resources.WriteText(this.CurrentInstruction.Text);

            return 0;
        }

        public ushort print_ret()
        {

            this.Resources.WriteText(this.CurrentInstruction.Text + "\r\n");

            this.CurrentFrame = null;

            return 1;
        }

        public ushort print_num(ushort value)
        {
            this.Resources.WriteText(value.ToString());

            return 0;
        }

        public ushort print_char(ushort value)
        {
            this.Resources.WriteText(((char)value).ToString());

            return 0;
        }

        public ushort new_line()
        {
            this.Resources.WriteText("\r\n");

            return 0;
        }

        public ushort print_obj(ushort obj)
        {
            this.Resources.WriteText(Resources.Objects[obj].Name);

            return 0;
        }

        public ushort print_addr(ushort address)
        {
            Resources.Stream.Position = address;

            var isEnd = false;
            var zcharacters = new List<byte>();

            while (!isEnd)
            {
                zcharacters.AddRange(ZUtility.ZCharactersFromBytes((byte)Resources.Stream.ReadByte(), (byte)Resources.Stream.ReadByte(), out isEnd));
            }
            var text = ZUtility.TextFromZCharacters(zcharacters.ToArray(), Resources.Abbreviations);

            this.Resources.WriteText(text);

            return 0;
        }

        public ushort print_paddr(ushort packedAddress)
        {
            Resources.Stream.Position = packedAddress * 2;

            var isEnd = false;
            var zcharacters = new List<byte>();

            while (!isEnd)
            {
                zcharacters.AddRange(ZUtility.ZCharactersFromBytes((byte)Resources.Stream.ReadByte(), (byte)Resources.Stream.ReadByte(), out isEnd));
            }
            var text = ZUtility.TextFromZCharacters(zcharacters.ToArray(), Resources.Abbreviations);

            this.Resources.WriteText(text);

            return 0;
        }

        public ushort sread(ushort text, ushort parse)
        {
            var command = Resources.ReadText();
            

            if (command == null)
            {
                // return value of null signals that we should exit the game.
                // this code is the same as quit()
                this.CurrentFrame = null;
                this.CallStack.Clear();

                return 0;
            }

            command = command.ToLower();

            Resources.Stream.Position = text;
            var maxCommandLength = Resources.Stream.ReadByte();
            if (command.Length > maxCommandLength)
            {
                command = command.Substring(0, maxCommandLength);
            }

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
