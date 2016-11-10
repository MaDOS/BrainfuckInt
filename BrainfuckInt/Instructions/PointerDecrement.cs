using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckIntLib.Instructions
{
    public class PointerDecrement : Instruction
    {
        public PointerDecrement(Program program, int location) : base(program, location)
        { }

        public override void Execute()
        {
            this.program.Memory.DecrementHP();
        }

        public override string ToString()
        {
            return "<";
        }
    }
}
