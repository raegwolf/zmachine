using System;
using System.Collections.Generic;
using System.Text;
using ZMachine.V3;

namespace ZMachine.V3.Objects
{
    public class GameState
    {
        public byte[] CompressedMemory { get; set; }

        public Stack<CallStackFrame> CallStack { get; set; }
    }
}
