using System;
using System.Collections.Generic;
using System.Text;

namespace ZMachine.V3
{
    public class CallStackFrame
    {
        public const int PC_EXIT = -1;

        public int RoutineAddress { get; set; } = 0;

        public int PC { get; set; } = PC_EXIT;

        public List<ushort> Locals { get; set; } = new List<ushort>();

        public Stack<ushort> Stack { get; set; } = new Stack<ushort>();

        /// <summary>
        /// When true, indicates that we are returning to this frame (i.e. a call has returned)
        /// </summary>
        public bool IsReturn { get; set; }

        /// <summary>
        /// When we leave a routine to call another, this stores where the result from the child routine should be placed when it returns
        /// </summary>
        public byte ReturnStore { get; set; }

    }
}
