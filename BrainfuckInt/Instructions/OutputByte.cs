using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckIntLib.Instructions
{
    public class OutputByte : Instruction
    {
        public OutputByte(Program program, int location) : base(program, location)
        { }

        public override void Execute()
        {
            Console.Write(Convert.ToChar(this.program.Memory.Data));
        }
    }
}
