using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.V3
{


    public class ZInstruction : ZBase
    {

        public int InstructionAddress { get; set; }

        public int InstructionNumber { get; set; }

        /// <summary>
        /// Length of instruction in bytes
        /// </summary>
        public ushort InstructionLength { get; set; }

        public ZEnums.Opcodes Opcode { get; set; }

        public byte OperandCount { get; set; }

        public ZEnums.OperandTypes[] OperandTypes { get; set; }

        public ushort[] Operands { get; set; }

        /// <summary>
        /// For store instructions (i.e. those that store a result), provides the index of the variable the result should be stored in
        /// </summary>
        public byte Store { get; set; }

        /// <summary>
        /// For branch instructions, indicates whether a branch should occur on true or false
        /// </summary>
        public bool BranchOnTrue { get; set; }

        /// <summary>
        /// For branch instructions, provides the offset to branch to
        /// </summary>
        public short BranchOffset { get; set; }

        /// <summary>
        /// For text instructions, provides the text that should be printed
        /// </summary>
        public string Text { get; set; }

        public override string ToString()
        {
            var s = string.Format(
                "  0x{0} 0x{1}  {2}",
                InstructionNumber.ToString("X2"),
                InstructionAddress.ToString("X4"),
                Opcode.ToString().PadRight(15));

            if ((ZEnums.InstructionMetadata[Opcode] & ZEnums.InstructionSpecialTypes.Jump) == ZEnums.InstructionSpecialTypes.Jump)
            {
                // unconditional jump instructions just have one operand which needs to be converted to the jump address
                s += this.GetBranchOrJumpInstructionAddress(true).ToString("X4");
            }
            else
            {
                // for other instructions, write out the operands

                for (var i = 0; i < OperandCount; i++)
                {
                    s += (i > 0 ? ", " : "");

                    switch (OperandTypes[i])
                    {
                        case ZEnums.OperandTypes.LargeConstant:
                            // seem to be signed
                            s += "#" + (Operands[i] < 0 ? "-" + (-Operands[i]).ToString("X4") : Operands[i].ToString("X4"));
                            break;

                        case ZEnums.OperandTypes.SmallConstant:
                            s += "#" + Operands[i].ToString("X2");
                            break;

                        case ZEnums.OperandTypes.Variable:
                            // 0x0=top of stack, 0x1 - 0xf refer to routine vars, >0xf refer to global vars
                            if (Operands[i] == 0x0)
                            {
                                s += "(SP)";
                            }
                            else if (Operands[i] <= 0xf)
                            {
                                s += "L" + (Operands[i] - 1).ToString("X2");
                            }
                            else
                            {
                                s += "G" + (Operands[i] - 0xf - 1).ToString("X2");
                            }
                            break;
                    }
                }
            }

            if ((ZEnums.InstructionMetadata[Opcode] & ZEnums.InstructionSpecialTypes.Store) == ZEnums.InstructionSpecialTypes.Store)
            {
                // 0x0=top of stack, 0x1 - 0xf refer to routine vars, >0xf refer to global vars
                if (Store == 0x0)
                {
                    s += " -> (SP)";
                }
                else if (Store <= 0xf)
                {
                    s += " -> L" + (Store - 1).ToString("X2");
                }
                else
                {
                    s += " -> G" + (Store - 0xf - 1).ToString("X2");
                }
            }

            if ((ZEnums.InstructionMetadata[Opcode] & ZEnums.InstructionSpecialTypes.Branch) == ZEnums.InstructionSpecialTypes.Branch)
            {
                var branchAddress = "";
                switch (this.BranchOffset)
                {
                    case 0: // means return false from routine
                        branchAddress = "RFALSE";
                        break;

                    case 1: // means return true from routine
                        branchAddress = "RTRUE";
                        break;

                    default: // provides address to jump to
                        branchAddress = this.GetBranchOrJumpInstructionAddress(true).ToString("X4");
                        break;
                }

                s += string.Format(
                    " ={0} ? {1} ",
                    BranchOnTrue ? "True" : "False",
                    branchAddress);
            }

            if ((ZEnums.InstructionMetadata[Opcode] & ZEnums.InstructionSpecialTypes.Text) == ZEnums.InstructionSpecialTypes.Text)
            {
                s += "\"" + Text + "\"";
            }

            return s;
        }

        /// <summary>
        /// Returns the address of the instruction this instruction will jump/branch to
        /// </summary>
        /// <returns></returns>
        public int GetBranchOrJumpInstructionAddress(bool throwErrorIfBranchIsReturn)
        {
            var type = ZEnums.InstructionMetadata[this.Opcode];

            if ((type & ZEnums.InstructionSpecialTypes.Branch) == ZEnums.InstructionSpecialTypes.Branch)
            {
                if ((BranchOffset == 0) || (BranchOffset == 1))
                {
                    if (throwErrorIfBranchIsReturn)
                    {
                        throw new Exception("BranchOffset contains a routine return NOT an address.");
                    }
                    else
                    {
                        return 0;
                    }
                }

                // for branch instructions, use the branch offset (which appeared after the operands) to calculate
                // the branch/jump address
                return (int)(InstructionAddress + InstructionLength + BranchOffset - 2);
            }
            else if ((type & ZEnums.InstructionSpecialTypes.Jump) == ZEnums.InstructionSpecialTypes.Jump)
            {
                // for jump instructions, use the first operand to calculate the branch/jump address
                return (int)(InstructionAddress + InstructionLength + ((short)Operands[0]) - 2);
            }
            else
            {
                throw new Exception("Not a branch/jump instruction.");
            }
        }

        /// <summary>
        /// Returns the address the call instruction should invoke (this is the entry point of a routine).
        /// By default this will return the statically known call address but some call calls have their
        /// address set from a parameter instead
        /// </summary>
        /// <returns></returns>
        public int GetCallRoutineAddress(ushort dynamicAddress)
        {
            // nb: this method returns an unpacked address which may overflow ushort (0xffff) and therefore must return an int
            var type = ZEnums.InstructionMetadata[this.Opcode];

            if ((type & ZEnums.InstructionSpecialTypes.Call) == ZEnums.InstructionSpecialTypes.Call)
            {
                if (Operands[0] == 0)
                {
                    return ((int)dynamicAddress * 2);
                }
                else
                {
                    return ((int)Operands[0] * 2);
                }
            }
            else
            {
                throw new Exception("Not a call instruction.");
            }
        }

        public void Parse()
        {
            parseInstruction();
        }

        public ushort Run(List<ushort> localVariables, Stack<ushort> stack, int callDepth)
        {
            if (this.InstructionAddress == 0x10105)
            {
                Debugger.Break();
            }

            var method = Resources.Processor.GetType().GetMethod(this.Opcode.ToString());

            if (method == null)
            {
                throw new NotImplementedException($"Instruction '{this.Opcode.ToString()}' has not been implemented.");
            }

            // prepare the payload
            var parameters = new List<object>();

            for (int i = 0; i < this.OperandCount; i++)
            {
                switch (OperandTypes[i])
                {
                    case ZEnums.OperandTypes.LargeConstant:
                        parameters.Add(Operands[i]);
                        break;

                    case ZEnums.OperandTypes.Variable:
                    case ZEnums.OperandTypes.SmallConstant:
                        // bizzarely, small constants are actually a reference to a variable IF the corresponding parameter
                        // on the method is a ref
                        if ((OperandTypes[i] == ZEnums.OperandTypes.SmallConstant) &&
                            (!method.GetParameters()[i].ParameterType.IsByRef))
                        {
                            parameters.Add(Operands[i]);
                            break;
                        }

                        // get the variable number we want
                        if (Operands[i] == 0x0)
                        {
                            // get the top item off the stack
                            parameters.Add(stack.Pop());
                        }
                        else if (Operands[i] <= 0xf)
                        {
                            // get the value of the local variable at this index
                            parameters.Add(localVariables[Operands[i] - 1]);
                        }
                        else
                        {
                            // get the value of the global variable at this index
                            parameters.Add(ZUtility.GetGlobalVariable(Resources.Stream, Resources.Header, Operands[i] - 0xf - 1));
                        }
                        break;

                    default:
                        throw new Exception("Unexpected operand type encountered.");
                }
            }

            if (this.Opcode == ZEnums.Opcodes.call)
            {
                // write the call instruction out before the invoke
                var instructionStr = this.ToString();
                var debugStr = $"{Opcode.ToString()}({string.Join(", ", parameters.Select(p => ((ushort)p).ToString("X4")))}) =>";

                ZUtility.WriteDebugLine(new string(' ', callDepth * 4) + instructionStr.PadRight(80, ' ') + debugStr);
            }

            // we may be short on parameters, add them if they're missing
            while (parameters.Count() < method.GetParameters().Count() - 1)
            {
                parameters.Add((ushort)0);
            }

            parameters.Add(new ZProcessor.CallState()
            {
                Instruction = this,
                Stack = stack,
                CallDepth = callDepth
            });

            var parametersAsArray = parameters.ToArray();

            var result = (ushort)method.Invoke(Resources.Processor, parametersAsArray);

            // store the result (this should happen before we update var by ref but can't remember what bug this resolved!)
            // if this is a store instruction, store the result
            var type = ZEnums.InstructionMetadata[Opcode];
            if ((type & ZEnums.InstructionSpecialTypes.Store) == ZEnums.InstructionSpecialTypes.Store)
            {
                if (Store == 0x0)
                {
                    // push the result on to the stack
                    stack.Push(result);
                }
                else if (Store <= 0xf)
                {
                    // set the value to the local variable at this index
                    localVariables[Store - 1] = result;
                }
                else
                {
                    // set the value to the global variable at this index
                    ZUtility.SetGlobalVariable(Resources.Stream, Resources.Header, Store - 0xf - 1, result);
                }
            }

            // write any ref parameters back to their original location if they're variable operands
            for (int i = 0; i < OperandCount; i++)
            {
                // is the param passed by ref?
                var isByRef = method.GetParameters()[i].ParameterType.IsByRef;
                if (!isByRef)
                {
                    continue;
                }

                var value = (ushort)parametersAsArray[i];

                if (Operands[i] == 0x0)
                {
                    // do not push on to the stack here. example of failure - kill troll and still can't go w because says troll blocks your way

                }
                else if (Operands[i] <= 0xf)
                {

                    localVariables[Operands[i] - 1] = value;
                }
                else
                {
                    // set the value of the global variable at this index
                    ZUtility.SetGlobalVariable(Resources.Stream, Resources.Header, Operands[i] - 0xf - 1, value);
                }

            }

            parameters.RemoveAt(parameters.Count() - 1); // strip off state parameter for logging

            // print the result
            if (this.Opcode == ZEnums.Opcodes.call) {
                ZUtility.WriteDebugLine(new string(' ', callDepth * 4) + "  => " + result.ToString("X4"));
                ZUtility.WriteDebugLine("");
            }
            else
            {
                var instructionStr = this.Opcode == ZEnums.Opcodes.call ? "" : this.ToString();
                var debugStr = $"{Opcode.ToString()}({string.Join(", ", parameters.Select(p => ((ushort)p).ToString("X4")))}) => {result.ToString("X4") }";

                ZUtility.WriteDebugLine(new string(' ', callDepth * 4) + instructionStr.PadRight(80, ' ') + debugStr);
            }

            return result;

        }

        public ZInstruction(ZResources sharedBase, int instructionNumber) : base(sharedBase)
        {
            this.InstructionNumber = instructionNumber;

        }

        void parseInstruction()
        {

            InstructionAddress = (int)Resources.Stream.Position;

            // debug to break on specific instruction being parsed
            if (this.InstructionAddress == 0x00)
            {
                Debugger.Break();
            }

            parseOpcodeAndOperandTypes();

            parseOperands();

            // parse components that are dependent on the opcode
            if (!ZEnums.InstructionMetadata.ContainsKey(this.Opcode))
            {
                throw new Exception("Opcode is missing from metadata lookup.");
            }

            var type = ZEnums.InstructionMetadata[this.Opcode];

            if ((type & ZEnums.InstructionSpecialTypes.Store) == ZEnums.InstructionSpecialTypes.Store)
            {
                parseStoreParameter();
            }

            if ((type & ZEnums.InstructionSpecialTypes.Branch) == ZEnums.InstructionSpecialTypes.Branch)
            {
                parseBranchParameter();
            }

            if ((type & ZEnums.InstructionSpecialTypes.Text) == ZEnums.InstructionSpecialTypes.Text)
            {
                parseTextParameter();
            }

            InstructionLength = (ushort)(Resources.Stream.Position - this.InstructionAddress);

        }

        void parseOpcodeAndOperandTypes()
        {
            this.Opcode = (ZEnums.Opcodes)Resources.Stream.ReadByte();

            if (((int)this.Opcode & 0b11000000) == 0b11000000)
            {
                var operandTypesByte = Resources.Stream.ReadByte();

                this.OperandTypes = new ZEnums.OperandTypes[4];

                this.OperandCount = 4;

                // variable
                if (((int)this.Opcode & 0b100000) == 0)
                {
                    // 2OP

                    // supposed to be 2OP but sometimes contains more than 2, therefore we use the same 
                    // implementation as VAR but treat the opcode as being only in the first 5 bits
                    for (var i = 0; i < 4; i++)
                    {
                        var shift = (3 - i) * 2;
                        this.OperandTypes[i] = (ZEnums.OperandTypes)(byte)((operandTypesByte & (0b11 << shift)) >> shift);
                        if (this.OperandTypes[i] == ZEnums.OperandTypes.Omitted)
                        {
                            this.OperandCount = (byte)i;
                            break;
                        }
                    }

                    this.Opcode = (ZEnums.Opcodes)((int)this.Opcode & 0b11111);
                }
                else
                {
                    // VAR
                    // up to 4 operands are stuffed into a byte (2 bits each). if 0b11 is encountered, that marks the end of the operands
                    for (var i = 0; i < 4; i++)
                    {
                        var shift = (3 - i) * 2;
                        this.OperandTypes[i] = (ZEnums.OperandTypes)(byte)((operandTypesByte & (0b11 << shift)) >> shift);
                        if (this.OperandTypes[i] == ZEnums.OperandTypes.Omitted)
                        {
                            this.OperandCount = (byte)i;
                            break;
                        }
                    }
                }
            }
            else if (((int)this.Opcode & 0b10000000) == 0b10000000)
            {
                // short

                // operand type is encoded in bits 4 & 5
                var operandType = ((int)Opcode & 0b110000) >> 4;

                if (operandType == 0b11)
                {
                    OperandCount = 0;
                }
                else
                {
                    OperandCount = 1;
                    OperandTypes = new ZEnums.OperandTypes[1];
                    OperandTypes[0] = (ZEnums.OperandTypes)operandType;

                    this.Opcode = (ZEnums.Opcodes)((int)this.Opcode & 0b10001111);
                }

            }
            else
            {
                // long
                OperandCount = 2;
                this.OperandTypes = new ZEnums.OperandTypes[2];

                // bit 6 gives first operand type, bit 5 gives second
                // a value of 1 means variable, a value of 0 means small constant
                this.OperandTypes[0] = (((int)this.Opcode & 0b1000000) == 0b1000000) ? ZEnums.OperandTypes.Variable : ZEnums.OperandTypes.SmallConstant;
                this.OperandTypes[1] = (((int)this.Opcode & 0b100000) == 0b100000) ? ZEnums.OperandTypes.Variable : ZEnums.OperandTypes.SmallConstant;

                // opcode for long is bottom 5 bits
                this.Opcode = (ZEnums.Opcodes)((int)this.Opcode & 0b11111);


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
                    case ZEnums.OperandTypes.LargeConstant:
                        this.Operands[i] = (ushort)Resources.Stream.ReadWord();
                        break;

                    case ZEnums.OperandTypes.SmallConstant:
                    case ZEnums.OperandTypes.Variable:
                        this.Operands[i] = (ushort)Resources.Stream.ReadByte();
                        break;

                    default:
                        throw new Exception("Unexpected operand type.");
                }
            }

        }
        void parseStoreParameter()
        {

            this.Store = (byte)Resources.Stream.ReadByte();

        }

        void parseBranchParameter()
        {
            var branch1 = (byte)Resources.Stream.ReadByte();

            // bit 7 of first branch byte determines whether to branch on true or false
            this.BranchOnTrue = ((branch1 & 0b10000000) == 0b10000000);

            // bit 6 determines whether the branch is 1 or 2 bytes
            var oneByteBranch = ((branch1 & 0b1000000) == 0b1000000);

            if (oneByteBranch)
            {
                BranchOffset = (sbyte)(branch1 & 0b111111);
            }
            else
            {
                branch1 = (byte)(branch1 & 0b111111);


                // signed 14 bit number made up of bottom 6 bits of first byte + 8 bits of second byte.
                // bit 5 will signal sign, bit 0..3 make up MSB of the number
                var branch2 = (byte)Resources.Stream.ReadByte();
                short offset;

                // if bit 5 is set, this is a negative number
                if ((branch1 & 0b100000) == 0b100000)
                {
                    offset = (short)((branch1 << 8) + branch2 + (0b1100000000000000));
                }
                else
                {
                    offset = (short)((branch1 << 8) + branch2);
                }

                BranchOffset = (short)offset;

            }

        }

        void parseTextParameter()
        {
            var isEnd = false;
            List<byte> zcharacters = new List<byte>();
            while (!isEnd)
            {
                var byte1 = (byte)Resources.Stream.ReadByte();
                var byte2 = (byte)Resources.Stream.ReadByte();

                zcharacters.AddRange(ZUtility.ZCharactersFromBytes(byte1, byte2, out isEnd));
            }

            this.Text = ZUtility.TextFromZCharacters(zcharacters.ToArray(), Resources.Abbreviations);

        }
    }
}