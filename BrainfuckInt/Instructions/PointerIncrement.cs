using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckIntLib.Instructions
{
    public class PointerIncrement : Instruction
    {
        public PointerIncrement(Program program, int location) : base(program, location)
        { }

        public override void Execute()
        {
            this.program.Memory.IncrementHP();
        }
    }
}
