using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{
    public class ZRoutine : ZBase
    {
        public int RoutineNumber { get; set; }

        public int RoutineAddress { get; set; }

        public byte LocalVariableCount { get; set; }

        public ushort[] InitialLocalVariables { get; set; }

        public List<ZInstruction> Instructions { get; set; } = new List<ZInstruction>();


        public string ToString(bool headerOnly = false)
        {
            var header = string.Format(
                "Routine #{0} at {1}",
                RoutineNumber,
                RoutineAddress.ToString("X4")
                );
            if (headerOnly)
            {
                return header;
            }

            var sb = new StringBuilder();

            sb.AppendLine(header);

            foreach (var instruction in Instructions)
            {
                sb.AppendLine(instruction.ToString());
            }

            sb.AppendLine();

            return sb.ToString();
        }

        public void Parse()
        {
            parseRoutine();
        }

        public ZRoutine(ZResources sharedBase, int routineNumber) : base(sharedBase)
        {
            this.RoutineNumber = routineNumber;
        }

        void parseRoutine()
        {
            this.RoutineAddress = (int)Resources.Stream.Position;

            this.LocalVariableCount = (byte)Resources.Stream.ReadByte();

            this.InitialLocalVariables = Resources.Stream.ReadWords(this.LocalVariableCount);

            while (!reachedEndOfRoutine())
            {
                var instruction = new ZInstruction(Resources, Instructions.Count());

                this.Instructions.Add(instruction);

                instruction.Parse();
            }

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
            var type = ZEnums.InstructionMetadata[last.Opcode];

            // if the current command is a branch (conditional jump), then there must be at least one more instruction
            if ((type & ZEnums.InstructionSpecialTypes.Branch) == ZEnums.InstructionSpecialTypes.Branch)
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
            if ((type & ZEnums.InstructionSpecialTypes.Return) == ZEnums.InstructionSpecialTypes.Return)
            {
                return true;
            }

            if ((type & ZEnums.InstructionSpecialTypes.Jump) == ZEnums.InstructionSpecialTypes.Jump)
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
                var type = ZEnums.InstructionMetadata[instruction.Opcode];

                // only consider branch/jump instructions
                if (((type & ZEnums.InstructionSpecialTypes.Branch) == ZEnums.InstructionSpecialTypes.Branch) ||
                        ((type & ZEnums.InstructionSpecialTypes.Jump) == ZEnums.InstructionSpecialTypes.Jump))
                {
                    // does this instruction branch to an instruction at an address we haven't yet parsed?
                    // if so, there is at least one more instruction
                    if (instruction.GetBranchOrJumpInstructionAddress(false) > highestBranchAddress)
                    {
                        return true;
                    }
                }
            }

            return false;

        }


    }
}
