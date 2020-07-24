using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMachine.ZMachineObjects;
using static ZMachine.Structs;

namespace ZMachine
{
    class Parser
    {
   
        MemoryStream _stream;

        ZMachineHeader _header;

        Dictionary<int, string> readWords()
        {
            _stream.Position = _header.dictionaryOffset;
            var wordSeparatorCount = _stream.ReadByte(); // number of separators chars defined (separators break words apart for lexical parsing)
            var wordSeparators = _stream.ReadChars(wordSeparatorCount); // characters that are separators (should be period, comma, quote)

            var wordEntryLength = _stream.ReadByte(); // length of a single word in the dictionary in bytes

            var wordCount = _stream.ReadWordBe(); // number of words in the dictionary

            var list = new Dictionary<int, string>();

            // read the words
            for (int i = 0; i < wordCount; i++)
            {
                // read a word
                var wordBytes = _stream.ReadBytes(wordEntryLength);

                var words1 = Utility.getZCharacters(wordBytes[0], wordBytes[1]);
                var words2 = Utility.getZCharacters(wordBytes[2], wordBytes[3]);

                var wordsCombined = new byte[6];
                wordsCombined[0] = (byte)(words1[0]);
                wordsCombined[1] = (byte)(words1[1]);
                wordsCombined[2] = (byte)(words1[2]);
                wordsCombined[3] = (byte)(words2[0]);
                wordsCombined[4] = (byte)(words2[1]);
                wordsCombined[5] = (byte)(words2[2]);

                var word = Utility.wordFromBytes(wordsCombined);

                list.Add(i, word);
            }

            return list;
        }


        
     

        void readHeader()
        {
            _stream.Position = 0;

            _header = _stream.ReadStructBe<ZMachineHeader>();

            if (_header.version != 3)
            {
                throw new NotSupportedException("We only support version 3.");
            }
        }

        public Parser(MemoryStream stream)
        {
            this._stream = stream;

            readHeader();

            readWords();

            // -1 because offset points to first instruction rather than start of routing
            stream.Position = _header.entryPointOffset - 1;
            new Routine(_stream);
        }
    }
}
