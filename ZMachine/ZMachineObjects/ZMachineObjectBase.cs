using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.ZMachineObjects
{
    class ZMachineObjectBase
    {
        protected MemoryStream Stream { get;  set; }

        protected Header Header { get; set; }

        protected List<string> Abbreviations { get; set; } = new List<string>();

        protected Dictionary<ushort, Routine> Routines { get; set; } = new Dictionary<ushort, Routine>();

        public ZMachineObjectBase()
        {
        }

        public ZMachineObjectBase(ZMachineObjectBase source)
        {
            this.Stream = source.Stream;
            this.Header = source.Header;
            this.Abbreviations = source.Abbreviations;
            this.Routines = source.Routines;
        }
    }
}
