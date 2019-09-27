using System;
using System.Collections.Generic;
using System.Text;

namespace Neo.ASML.Node
{
    public struct ASMOpCode
    {
        public Neo.VM.OpCode? opcodeVM
        {
            get;
            private set;
        }
        public bool isPush
        {
            get;
            private set;
        }
        public override string ToString()
        {
            if (isPush) return "PUSH";
            return opcodeVM.ToString();
        }
        public static ASMOpCode Create(Neo.VM.OpCode opcode)
        {
            ASMOpCode code = new ASMOpCode();
            code.isPush = false;
            code.opcodeVM = opcode;
            return code;
        }
        public static ASMOpCode CreatePush()
        {
            ASMOpCode code = new ASMOpCode();
            code.isPush = true;
            code.opcodeVM = null;
            return code;
        }

        public static ASMOpCode Parse(string text)
        {
            if (text == "PUSH")
            {
                return new ASMOpCode() { isPush = true, opcodeVM = null };
            }
            else
            {
                VM.OpCode code = Enum.Parse<VM.OpCode>(text);
                return new ASMOpCode() { isPush = false, opcodeVM = code };
            }
        }
    }
}
