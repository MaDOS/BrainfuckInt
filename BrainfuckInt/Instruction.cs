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
        protected long location;

        public Instruction(Program program, long location)
        {
            this.program = program;
            this.location = location;
        }

        public long Location
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
