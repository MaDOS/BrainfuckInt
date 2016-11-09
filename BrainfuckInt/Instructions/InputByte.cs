using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckIntLib.Instructions
{
    public class InputByte : Instruction
    {
        public InputByte(Program program, int location) : base(program, location)
        { }

        public override void Execute()
        {
            this.program.Memory.Data = Convert.ToByte(Console.ReadKey().KeyChar);
        }
    }
}
