using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckIntLib.Instructions
{
    public class LoopEnd : Instruction
    {
        private LoopReference loopReference;
        public LoopEnd(Program program, int location, LoopReference loopReference) : base(program, location)
        {
            this.loopReference = loopReference;
        }

        public override void Execute()
        {
            if(this.program.Memory.Data != 0)
            {
                this.program.InstructionPointer = this.loopReference.Start;
            }
        }

        public override string ToString()
        {
            return "]";
        }
    }
}
