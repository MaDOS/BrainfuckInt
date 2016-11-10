using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckIntLib.Instructions
{
    public class Comment : Instruction
    {
        private string message;
        public Comment(Program program, int location, string message) : base(program, location)
        {
            this.message = message;
        }

        public string Message
        {
            get
            {
                return message;
            }

            protected set
            {
                message = value;
            }
        }

        public override void Execute()
        {
            Console.WriteLine($"I'm a comment I should not be executed! Comment Message:{this.message}");
        }

        public override string ToString()
        {
            return this.message;
        }
    }
}
