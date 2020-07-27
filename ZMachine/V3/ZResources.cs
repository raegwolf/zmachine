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

        public ZHeader Header { get; set; }

        public List<ushort> GlobalVariables { get; set; } = new List<ushort>();

        public List<string> Abbreviations { get; set; } = new List<string>();

        public List<ZRoutine> Routines { get; set; } = new List<ZRoutine>();

        public ZProcessor Processor { get; set; }

    }
}
