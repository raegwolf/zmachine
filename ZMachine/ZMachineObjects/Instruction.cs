using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.ZMachineObjects
{
 

    class Instruction : ZMachineObjectBase
    {


        public long InstructionAddress { get; set; }

        public Enums.Opcodes Opcode { get; set; }

        public byte OperandCount { get; set; }

        public Enums.OperandTypes[] OperandTypes { get; set; }

        public ushort[] Operands { get; set; }

        /// <summary>
        /// For store instructions (i.e. those that store a result), provides the index of the variable the result should be stored in
        /// </summary>
        public byte Store { get; set; }

        /// <summary>
        /// For branch instructions, indicates whether a branch should occur on true or false
        /// </summary>
        public bool BranchOnFalse { get; set; }

        /// <summary>
        /// For branch instructions, provides the offset to branch to
        /// </summary>
        public short BranchOffset { get; set; }

        /// <summary>
        /// For text instructions, provides the text that should be printed
        /// </summary>
        public string Text { get; set; }


        public Instruction(MemoryStream stream) : base(stream)
        {
            parseInstruction();

        }

        void parseInstruction()
        {
            InstructionAddress = base.Stream.Position;

            parseOpcodeAndOperandTypes();

            parseOperands();

            // parse components that are dependent on the opcode

            if (!Enums.InstructionMetadata.ContainsKey(this.Opcode))
            {
                throw new Exception("Opcode is missing from metadata lookup.");
            }

            switch (Enums.InstructionMetadata[this.Opcode])
            {
                case Enums.InstructionSpecialTypes.None:
                    break;

                case Enums.InstructionSpecialTypes.Store:
                    parseStoreParameter();
                    break;

                case Enums.InstructionSpecialTypes.Branch:
                    parseBranchParameter();
                    break;

                case Enums.InstructionSpecialTypes.StoreAndBranch:
                    parseStoreParameter();
                    parseBranchParameter();
                    break;

                case Enums.InstructionSpecialTypes.Text:
                    parseTextParameter();
                    break;

                default:
                    throw new Exception("Unknown instruction special type.");
            }


        }

        void parseOpcodeAndOperandTypes()
        {
            this.Opcode = (Enums.Opcodes)this.Stream.ReadByte();

            if (((int)this.Opcode & 0b11000000) == 0b11000000)
            {
                // variable
                if (((int)this.Opcode & 0b100000) == 0)
                {
                    // 2OP
                    this.OperandCount = 2;
                    throw new NotImplementedException();
                }
                else
                {
                    // var count
                    var operandTypesByte = this.Stream.ReadByte();

                    this.OperandTypes = new Enums.OperandTypes[4];

                    var count = 4;
                    // up to 4 operands are stuffed into a byte (2 bits each). if 0b11 is encountered, that marks the end of the operands
                    for (var i = 0; i < 4; i++)
                    {
                        count = i;
                        var shift = (3 - i) * 2;
                        this.OperandTypes[i] = (Enums.OperandTypes)(byte)((operandTypesByte & (0b11 << shift)) >> shift);
                        if (this.OperandTypes[i] == Enums.OperandTypes.Omitted)
                        {
                            break;
                        }
                    }
                    this.OperandCount = (byte)count;
                }
            }
            else if (((int)this.Opcode & 0b10000000) == 0b10000000)
            {
                // short
                throw new NotImplementedException();
            }
            else
            {
                // long
                throw new NotImplementedException();
            }
        }

        void parseOperands()
        {
            // read the operands
            this.Operands = new ushort[this.OperandCount];

            for (int i = 0; i < this.OperandCount; i++)
            {
                switch (this.OperandTypes[i])
                {
                    case Enums.OperandTypes.LargeConstant:
                        this.Operands[i] = (ushort)this.Stream.ReadWordBe();
                        break;

                    case Enums.OperandTypes.SmallConstant:
                    case Enums.OperandTypes.Variable:
                        this.Operands[i] = (ushort)this.Stream.ReadByte();
                        break;

                    default:
                        throw new Exception("Unexpected operand type.");
                }
            }

        }
        void parseStoreParameter()
        {

            this.Store = (byte)this.Stream.ReadByte();

        }

        void parseBranchParameter()
        {
            throw new NotImplementedException();
        }

        void parseTextParameter()
        {
            throw new NotImplementedException();
        }
    }
}
