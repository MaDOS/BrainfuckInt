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
        public Comment(Program program, int location) : base(program, location)
        { }

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
            Console.WriteLine("I'm a comment I should not be executed!");
        }

        public override string ToString()
        {
            return $"\"{this.message}\" ### {base.ToString()}";
        }
    }
}
