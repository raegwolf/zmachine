using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ZMachine.ZMachineObjects
{


    class Enums
    {
        public enum Opcodes : byte
        {
            // 2OP
            je = 0x01,
            jl = 0x02,
            jg = 0x03,
            dec_chk = 0x04,
            inc_chk = 0x05,
            jin = 0x06,
            test = 0x07,
            or = 0x08,
            and = 0x09,
            test_attr = 0x0A,
            set_attr = 0x0B,
            clear_attr = 0x0C,
            store = 0x0D,
            insert_obj = 0x0E,
            loadw = 0x0F,
            loadb = 0x10,
            get_prop = 0x11,
            get_prop_addr = 0x12,
            get_next_prop = 0x13,
            add = 0x14,
            sub = 0x15,
            mul = 0x16,
            div = 0x17,
            mod = 0x18,

            // 1OP
            jz = 0x80,
            get_sibling = 0x81,
            get_child = 0x82,
            get_parent = 0x83,
            get_prop_len = 0x84,
            inc = 0x85,
            dec = 0x86,
            print_addr = 0x87,
            remove_obj = 0x89,
            print_obj = 0x8A,
            ret = 0x8B,
            jump = 0x8C,
            print_paddr = 0x8D,
            load = 0x8E,

            // 0OP
            rtrue = 0xB0,
            rfalse = 0xB1,
            print = 0xB2,
            print_ret = 0xB3,
            save = 0xB5,
            restore = 0xB6,
            restart = 0xB7,
            ret_popped = 0xB8,
            pop = 0xB9,
            quit = 0xBA,
            new_line = 0xBB,
            show_status = 0xBC,
            verify = 0xBD,

            // VAR
            call = 0xE0,
            storew = 0xE1,
            storeb = 0xE2,
            put_prop = 0xE3,
            sread = 0xE4,
            print_char = 0xE5,
            print_num = 0xE6,
            random = 0xE7,
            push = 0xE8,
            pull = 0xE9,
            split_window = 0xEA,
            set_window = 0xEB,
            output_stream = 0xF3,
            input_stream = 0xF4,


        }

        public enum OperandTypes : byte
        {
            LargeConstant = 0b00, // operand is 2 bytes
            SmallConstant = 0b01, // operand is 1 byte
            Variable = 0b10, // operand is 1 byte
            Omitted = 0b11 // omitted
        }

        public enum InstructionSpecialTypes
        {
            None = 0b00000,
            /// <summary>
            /// Store instructions include a value following the operands that indicate the variable
            /// number that the result should be stored in
            /// </summary>
            Store = 0b00001,
            /// <summary>
            /// Branch instructions cause execution to jump to a different location (should be in the same
            /// routine). The jump location is specified after the operands.
            /// These instructions are parsed during static analysis to determine the number of instructions in a routine
            /// </summary>
            Branch = 0b00010,
            /// <summary>
            /// Text instructions include an encoded text string following the end of the operands
            /// </summary>
            Text = 0b00100,
            /// <summary>
            /// Call instructions invoke a routine. 
            /// These instructions are parsed during static analysis to determine the number of instructions in a routine
            /// </summary>
            Call = 0b01000,
            /// <summary>
            /// Return instructions return control back to the calling routine. 
            /// These instructions are parsed during static analysis to determine the number of instructions in a routine
            /// </summary>
            Return = 0b10000,
            /// <summary>
            /// Like branch in that it moves execution to a different instruction BUT the offset for the branch calc
            /// is the first operand
            /// </summary>
            Jump = 0b100000
        }

        /// <summary>
        /// Maps whether an opcode has additional payload at the end of the operands
        /// </summary>
        public static Dictionary<Opcodes, InstructionSpecialTypes> InstructionMetadata = new Dictionary<Opcodes, InstructionSpecialTypes>()
        {

            { Opcodes.je, InstructionSpecialTypes.Branch},
            { Opcodes.jl, InstructionSpecialTypes.Branch},
            { Opcodes.jg, InstructionSpecialTypes.Branch},
            { Opcodes.dec_chk, InstructionSpecialTypes.Branch},
            { Opcodes.inc_chk, InstructionSpecialTypes.Branch},
            { Opcodes.jin, InstructionSpecialTypes.Branch},
            { Opcodes.test, InstructionSpecialTypes.Branch},
            { Opcodes.or, InstructionSpecialTypes.Store},
            { Opcodes.and, InstructionSpecialTypes.Store},
            { Opcodes.test_attr, InstructionSpecialTypes.Branch},
            { Opcodes.set_attr, InstructionSpecialTypes.None},
            { Opcodes.clear_attr, InstructionSpecialTypes.None},
            { Opcodes.store, InstructionSpecialTypes.None},
            { Opcodes.insert_obj, InstructionSpecialTypes.None},
            { Opcodes.loadw, InstructionSpecialTypes.Store},
            { Opcodes.loadb, InstructionSpecialTypes.Store},
            { Opcodes.get_prop, InstructionSpecialTypes.Store},
            { Opcodes.get_prop_addr, InstructionSpecialTypes.Store},
            { Opcodes.get_next_prop, InstructionSpecialTypes.Store},
            { Opcodes.add, InstructionSpecialTypes.Store},
            { Opcodes.sub, InstructionSpecialTypes.Store},
            { Opcodes.mul, InstructionSpecialTypes.Store},
            { Opcodes.div, InstructionSpecialTypes.Store},
            { Opcodes.mod, InstructionSpecialTypes.Store},
            { Opcodes.jz, InstructionSpecialTypes.Branch},
            { Opcodes.get_sibling, InstructionSpecialTypes.Store | InstructionSpecialTypes.Branch},
            { Opcodes.get_child, InstructionSpecialTypes.Store |InstructionSpecialTypes.Branch},
            { Opcodes.get_parent, InstructionSpecialTypes.Store},
            { Opcodes.get_prop_len, InstructionSpecialTypes.Store},
            { Opcodes.inc, InstructionSpecialTypes.None},
            { Opcodes.dec, InstructionSpecialTypes.None},
            { Opcodes.print_addr, InstructionSpecialTypes.None},
            { Opcodes.remove_obj, InstructionSpecialTypes.None},
            { Opcodes.print_obj, InstructionSpecialTypes.None},
            { Opcodes.ret, InstructionSpecialTypes.Return},
            { Opcodes.jump, InstructionSpecialTypes.Jump},
            { Opcodes.print_paddr, InstructionSpecialTypes.None},
            { Opcodes.load, InstructionSpecialTypes.Store},
            { Opcodes.rtrue, InstructionSpecialTypes.Return},
            { Opcodes.rfalse, InstructionSpecialTypes.Return},
            { Opcodes.print, InstructionSpecialTypes.Text},
            { Opcodes.print_ret, InstructionSpecialTypes.Text|InstructionSpecialTypes.Return},
            { Opcodes.save, InstructionSpecialTypes.Branch},
            { Opcodes.restore, InstructionSpecialTypes.Branch},
            { Opcodes.restart, InstructionSpecialTypes.None},
            { Opcodes.ret_popped, InstructionSpecialTypes.Return},
            { Opcodes.pop, InstructionSpecialTypes.None},
            { Opcodes.quit, InstructionSpecialTypes.Return},
            { Opcodes.new_line, InstructionSpecialTypes.None},
            { Opcodes.show_status, InstructionSpecialTypes.None},
            { Opcodes.verify, InstructionSpecialTypes.Branch},
            { Opcodes.call, InstructionSpecialTypes.Store|InstructionSpecialTypes.Call},
            { Opcodes.storew, InstructionSpecialTypes.None},
            { Opcodes.storeb, InstructionSpecialTypes.None},
            { Opcodes.put_prop, InstructionSpecialTypes.None},
            { Opcodes.sread, InstructionSpecialTypes.None},
            { Opcodes.print_char, InstructionSpecialTypes.None},
            { Opcodes.print_num, InstructionSpecialTypes.None},
            { Opcodes.random, InstructionSpecialTypes.Store},
            { Opcodes.push, InstructionSpecialTypes.None},
            { Opcodes.pull, InstructionSpecialTypes.None},
            { Opcodes.split_window, InstructionSpecialTypes.None},
            { Opcodes.set_window, InstructionSpecialTypes.None},
            { Opcodes.output_stream, InstructionSpecialTypes.None},
            { Opcodes.input_stream, InstructionSpecialTypes.None}
        };

    }
}
