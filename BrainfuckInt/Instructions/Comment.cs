using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckIntLib.Instructions
{
    public class Comment : Instruction
    {
        public Comment(Program program, int location) : base(program, location)
        { }

        public override void Execute()
        {
            
        }
    }
}
