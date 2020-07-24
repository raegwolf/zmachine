using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.ZMachineObjects
{
    class Routine : ZMachineObjectBase
    {
        public long RoutineAddress { get; set; }

        public byte LocalVariableCount { get; set; }

        public ushort[] LocalVariables { get; set; }

        public List<Instruction> Instructions { get; set; } = new List<Instruction>();

        public Routine(MemoryStream stream) : base(stream)
        {
            parseRoutine();
        }

        void parseRoutine()
        {
            this.RoutineAddress = this.Stream.Position;

            this.LocalVariableCount = (byte)this.Stream.ReadByte();

            this.LocalVariables = this.Stream.ReadWordsBe(this.LocalVariableCount);

            this.Instructions.Add(new Instruction(this.Stream));
            this.Instructions.Add(new Instruction(this.Stream));
            this.Instructions.Add(new Instruction(this.Stream));

        }

    }
}
