using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ZMachine.V3.Objects;

namespace ZMachine.V3
{
    public partial class ZProcessor : ZBase
    { 

        public Stack<CallStackFrame> CallStack { get; set; } = new Stack<CallStackFrame>();

        public CallStackFrame CurrentFrame { get; set; }

        public ZInstruction CurrentInstruction { get; set; }

        Dictionary<ZEnums.Opcodes, MethodInfo> _instructions = new System.Collections.Generic.Dictionary<ZEnums.Opcodes, MethodInfo>();

        public ZProcessor(ZResources resources) : base(resources)
        {
            foreach (var method in this.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod))
            {

                // get the opcode for the method if any
                ZEnums.Opcodes opcode;
                if (!Enum.TryParse<ZEnums.Opcodes>(method.Name, out opcode))
                {
                    continue;
                }

                // cache it
                _instructions.Add(opcode, method);

            }



        }

        /// <summary>
        /// Writes the operand values for the instruction to the operands list
        /// </summary>
        /// <param name="instruction"></param>
        /// <param name="operands"></param>
        public void AssignOperandValues(ZInstruction instruction, object[] operands)
        {
            var method = _instructions[instruction.Opcode];

            for (int i = 0; i < instruction.OperandCount; i++)
            {
                switch (instruction.OperandTypes[i])
                {
                    case ZEnums.OperandTypes.LargeConstant:
                        operands[i] = instruction.Operands[i];
                        break;

                    case ZEnums.OperandTypes.Variable:
                    case ZEnums.OperandTypes.SmallConstant:
                        // bizzarely, small constants are actually a reference to a variable IF the corresponding parameter
                        // on the method is a ref
                        if ((instruction.OperandTypes[i] == ZEnums.OperandTypes.SmallConstant) &&
                            (!method.GetParameters()[i].ParameterType.IsByRef))
                        {
                            operands[i] = (ushort)instruction.Operands[i];
                            break;
                        }

                        // get the variable number we want
                        if (instruction.Operands[i] == 0x0)
                        {
                            // get the top item off the stack
                            operands[i] = this.CurrentFrame.Stack.Pop();
                        }
                        else if (instruction.Operands[i] <= 0xf)
                        {
                            // get the value of the local variable at this index
                            operands[i] = this.CurrentFrame.Locals[instruction.Operands[i] - 1];
                        }
                        else
                        {
                            // get the value of the global variable at this index
                            operands[i] = ZUtility.GetGlobalVariable(Resources.Stream, Resources.Header, instruction.Operands[i] - 0xf - 1);
                        }
                        break;

                    default:
                        throw new Exception("Unexpected operand type encountered.");
                }
            }

        }

        /// <summary>
        /// Writes byref operand values back to the right variables
        /// </summary>
        /// <param name="instruction"></param>
        /// <param name="operands"></param>
        public void ReturnOperandValues(CallStackFrame frame, object[] operands)
        {
            var method = _instructions[CurrentInstruction.Opcode];

            // write any ref parameters back to their original location if they're variable operands
            for (int i = 0; i < CurrentInstruction.OperandCount; i++)
            {
                // is the param passed by ref?
                var isByRef = method.GetParameters()[i].ParameterType.IsByRef;
                if (!isByRef)
                {
                    continue;
                }

                var value = (ushort)operands[i];

                if (CurrentInstruction.Operands[i] == 0x0)
                {
                    // do not push on to the stack here. example of failure - kill troll and still can't go w because says troll blocks your way
                }
                else if (CurrentInstruction.Operands[i] <= 0xf)
                {
                    frame.Locals[CurrentInstruction.Operands[i] - 1] = value;
                }
                else
                {
                    // set the value of the global variable at this index
                    ZUtility.SetGlobalVariable(Resources.Stream, Resources.Header, CurrentInstruction.Operands[i] - 0xf - 1, value);
                }

            }

        }

        /// <summary>
        /// Executes the given instruction with the given operands
        /// </summary>
        /// <param name="opcode"></param>
        /// <param name="operands"></param>
        /// <returns></returns>
        public ushort Execute(ZInstruction instruction, object[] operands)
        {
            // write debug info
            var debugIndent = new string(' ', this.CallStack.Count() * 4);

#if WRITEDEBUGTEXT
            if (instruction.Opcode == ZEnums.Opcodes.call)
            {
                // write the call instruction out before the invoke
                var instructionStr = instruction.ToString();
                var debugStr = $"{instruction.Opcode.ToString()}({string.Join(", ", operands.Select(p => ((ushort)p).ToString("X4")))}) =>";

                ZUtility.WriteDebugLine(debugIndent + instructionStr.PadRight(80, ' ') + debugStr);
            }
#endif

            var method = _instructions[instruction.Opcode];

            // the instruction may have optional parameters, if so, pad the operands list with Type.Missing
            var initialCount = operands.Length;
            var parameterCount = method.GetParameters().Count();
            Array.Resize<object>(ref operands, parameterCount);
            for (int i = initialCount; i < parameterCount; i++)
            {
                operands[i] = Type.Missing;
            }

            // execute the call
            var result = (ushort)method.Invoke(this, operands);

#if WRITEDEBUGTEXT
            // write debug info
            if (instruction.Opcode != ZEnums.Opcodes.call)
            {
                var instructionStr = instruction.ToString();
                var operandStr = string.Join(", ", operands.Where(p => p != null).Select(p => ((ushort)p).ToString("X4")));
                var debugStr = $"{instruction.Opcode.ToString()}({operandStr}) => {result.ToString("X4") }";

                ZUtility.WriteDebugLine(debugIndent + instructionStr.PadRight(80, ' ') + debugStr);
            }
#endif

            return result;

        }

        public ushort handleBranchForCurrentInstruction(bool result)
        {
            return handleBranchForCurrentInstruction(result ?(ushort) 1 :(ushort) 0);
        }

        public ushort handleBranchForCurrentInstruction ( ushort result)
        {
            var instruction = this.CurrentInstruction;

            var branchConditionMet = (instruction.BranchOnTrue == (result != 0));

            if (!branchConditionMet)
            {
                return result;
            }

            if ((instruction.BranchOffset == 0) || (instruction.BranchOffset == 1))
            {
                // acts as a return
                this.CurrentFrame = null;

                return (ushort)instruction.BranchOffset;
            }
            else
            {
                // acts as a branch
                var address = (int)(instruction.InstructionAddress + instruction.InstructionLength + instruction.BranchOffset - 2);

                this.CurrentFrame.PC = address;

                return result;
            }
        }


    }
}
