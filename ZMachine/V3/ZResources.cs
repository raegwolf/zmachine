using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public class ZResources
    {
        public ZMemoryStream Stream { get; set; }

        public Objects.ZHeader Header { get; set; }

        public List<string> WordSeparators { get; set; }

        /// <summary>
        /// store address of dictionary word in memory, word text
        /// </summary>
        public Dictionary<ushort, string> Dictionary { get; set; }

        /// <summary>
        /// Provides default values for properties if the property is not provided
        /// </summary>
        public Dictionary<int, ushort> PropertyDefaults { get; set; }

        /// <summary>
        /// We store these in a dictionary because objects are 1-based and having to remember to convert them to 0-base will be a source of bugs!
        /// </summary>
        public Dictionary<int, ZObject> Objects { get; set; }

        public List<string> Abbreviations { get; set; } = new List<string>();

        public List<ZRoutine> Routines { get; set; } = new List<ZRoutine>();

        /// <summary>
        /// Callback to write text to output stream
        /// </summary>
        public Action<string> WriteText { get; set; }

        /// <summary>
        /// Callback to read a command from input stream
        /// </summary>
        public Func<string> ReadText { get; set; }

    }
}
