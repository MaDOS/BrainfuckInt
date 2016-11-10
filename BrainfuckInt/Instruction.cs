using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckIntLib
{
    public abstract class Instruction
    {
        protected Program program;
        protected int location;

        public Instruction(Program program, int location)
        {
            this.program = program;
            this.location = location;
        }

        public int Location
        {
            get
            {
                return location;
            }

            protected set
            {
                location = value;
            }
        }

        public abstract void Execute();
    }
}
