using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckIntLib.Instructions
{
    public class Decrement : Instruction
    {
        public Decrement(Program program, int location) : base(program, location)
        { }

        public override void Execute()
        {
            this.program.Memory.DecrementData();
        }

        public override string ToString()
        {
            return "-";
        }
    }
}
