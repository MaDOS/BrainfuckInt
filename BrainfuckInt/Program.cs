using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BrainfuckIntLib
{
    public class Program
    {
        public int PC = 0;
        public List<Instruction> source = new List<Instruction>();
        public Heap Memory = new Heap();

        public Program(FileInfo inputSource)
        {
            this.Parse(inputSource);
        }
        public void Parse(FileInfo inputSource)
        {
            char chr;
            int position = 0;
            StreamReader sr = new StreamReader(inputSource.FullName);
            Stack<LoopReference> loopRefStack = new Stack<LoopReference>();
            LoopReference currLoopRef;

            while (!sr.EndOfStream)
            {
                position = this.source.Count;
                chr = (char)sr.Read();
                Instruction instruction;

                switch (chr)
                {
                    case '+':
                        instruction = new Instructions.Increment(this, position);
                        break;
                    case '-':
                        instruction = new Instructions.Decrement(this, position);
                        break;
                    case '>':
                        instruction = new Instructions.PointerIncrement(this, position);
                        break;
                    case '<':
                        instruction = new Instructions.PointerDecrement(this, position);
                        break;
                    case '.':
                        instruction = new Instructions.OutputByte(this, position);
                        break;
                    case ',':
                        instruction = new Instructions.InputByte(this, position);
                        break;
                    case '[':
                        currLoopRef = new LoopReference() { Start = position };
                        loopRefStack.Push(currLoopRef);

                        instruction = new Instructions.LoopStart(this, position, currLoopRef);
                        break;
                    case ']':
                        currLoopRef = loopRefStack.Pop();
                        currLoopRef.End = position;

                        instruction = new Instructions.LoopEnd(this, position, currLoopRef);
                        break;
                    default:
                        instruction = null;
                        break;
                }

                if (instruction != null)
                {
                    this.source.Add(instruction);
                }
            }            
        }

        public void Execute()
        {
            for(PC = 0; PC < this.source.Count; PC++)
            {
                this.source[PC].Execute();
            }
        }
    }
}
