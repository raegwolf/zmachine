using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.ZMachineObjects
{
    class Routine : ZMachineObjectBase
    {
        public int RoutineNumber { get; set; }

        public int RoutineAddress { get; set; }

        public byte LocalVariableCount { get; set; }

        public ushort[] LocalVariables { get; set; }

        public List<Instruction> Instructions { get; set; } = new List<Instruction>();

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format(
                "Routine #{0} at {1}",
                RoutineNumber,
                RoutineAddress.ToString("X4")
                ));

            foreach (var instruction in Instructions)
            {
                sb.AppendLine(instruction.ToString());
            }

            return sb.ToString();
        }

        public void Parse()
        {
            parseRoutine();
        }

        public Routine(ZMachineObjectBase source, int routineNumber) : base(source)
        {
            this.RoutineNumber = routineNumber;
        }

        void parseRoutine()
        {
            this.RoutineAddress = (int)this.Stream.Position;

            this.LocalVariableCount = (byte)this.Stream.ReadByte();

            this.LocalVariables = this.Stream.ReadWordsBe(this.LocalVariableCount);

            Console.WriteLine(this.ToString());

            while (!reachedEndOfRoutine())
            {
                var instruction = new Instruction(this, this.Instructions.Count());

                this.Instructions.Add(instruction);

                instruction.Parse();
            }

            Console.WriteLine();

        }

        /// <summary>
        /// statically determines whether we've reached the end of the routine
        /// </summary>
        /// <returns></returns>
        private bool reachedEndOfRoutine()
        {
      
            // have we parsed any instructions yet? if not, we're not done
            if (this.Instructions.Count == 0)
            {
                return false;
            }

            // get detail of the last instruction
            var last = this.Instructions.Last();
            var type = Enums.InstructionMetadata[last.Opcode];

            // if the current command is a branch (conditional jump), then there must be at least one more instruction
            if ((type & Enums.InstructionSpecialTypes.Branch) == Enums.InstructionSpecialTypes.Branch)
            {
                return false;
            }

            // have we reached the highest known branch address for the instruction?
            if (hasKnownUnreachedAddress())
            {
                return false;
            }

            // if it is a return instruction or a branch/jump instruction, we're done.
            // technically, we should only consider branch/jump instructions that point to an earlier address BUT we
            // don't need to assert this because hasKnownUnreachedAddress() already looked for instructions that
            // jump/branch to a later instruction and our execution wouldn't have got here if it found one
            if ((type & Enums.InstructionSpecialTypes.Return) == Enums.InstructionSpecialTypes.Return)
            {
                return true;
            }

            if ((type & Enums.InstructionSpecialTypes.Jump) == Enums.InstructionSpecialTypes.Jump)
            {
                return true;
            }

            return false;

        }

        /// <summary>
        ///  iterates the currently known list of instructions to obtain the highest known branch address for any 
        ///  opcode of type branch
        /// </summary>
        /// <returns></returns>
        bool hasKnownUnreachedAddress()
        {
            var highestBranchAddress = Instructions.Last().InstructionAddress;

            foreach (var instruction in Instructions)
            {
                var type = Enums.InstructionMetadata[instruction.Opcode];

                // only consider branch/jump instructions
                if (((type & Enums.InstructionSpecialTypes.Branch) == Enums.InstructionSpecialTypes.Branch) ||
                        ((type & Enums.InstructionSpecialTypes.Jump) == Enums.InstructionSpecialTypes.Jump))
                {
                    // does this instruction branch to an instruction at an address we haven't yet parsed?
                    // if so, there is at least one more instruction
                    if (instruction.GetBranchOrJumpInstructionAddress() > highestBranchAddress)
                    {
                        return true;
                    }
                }
            }

            return false;

        }


    }
}
