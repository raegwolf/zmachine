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
        public MemoryStream Stream { get; set; }

        public Structs.ZHeader Header { get; set; }

        /// <summary>
        /// Provides default values for properties if the property is not provided
        /// </summary>
        public Dictionary<int, ushort> PropertyDefaults { get; set; }

        /// <summary>
        /// We store these in a dictionary because objects are 1-based and having to remember to convert them to 0-base will be a source of bugs!
        /// </summary>
        public Dictionary<int, ZObject> Objects { get; set; }

        public List<ushort> GlobalVariables { get; set; } = new List<ushort>();

        public List<string> Abbreviations { get; set; } = new List<string>();

        public List<ZRoutine> Routines { get; set; } = new List<ZRoutine>();

        public ZProcessor Processor { get; set; }

    }
}
