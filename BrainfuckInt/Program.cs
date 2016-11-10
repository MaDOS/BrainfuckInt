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
        public List<Instruction> source = new List<Instruction>();
        public Dictionary<int, List<Instructions.Comment>> DebugInformation = new Dictionary<int, List<Instructions.Comment>>();
        public Heap Memory = new Heap();

        private int pc = 0;
        private string name;
        private bool loadDebugInfo = false;

        public bool DebugEnabled
        {
            get
            {
                return loadDebugInfo;
            }
        }

        public int PC
        {
            get
            {
                return pc;
            }

            internal set
            {
                pc = value;
                PCChanged();
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            protected set
            {
                name = value;
            }
        }

        public int InstructionCount
        {
            get
            {
                return this.source.Count;
            }
        }

        public delegate void PCChangedEventHandler();
        public event PCChangedEventHandler PCChanged;

        public Program(FileInfo inputSource)
        {
            this.Name = inputSource.Name;
            this.Parse(inputSource);
        }

        public Program(FileInfo inputSource, bool loadDebugInfo)
        {
            this.Name = inputSource.Name;
            this.Parse(inputSource);
            this.loadDebugInfo = loadDebugInfo;
        }

        public void Parse(FileInfo inputSource)
        {
            char chr;
            int position = 0;
            string commentBuffer = "";
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
                    default: //Basically comments are being parsed here to add get debug info
                        if(!this.loadDebugInfo)
                        {
                            instruction = null;
                            break;
                        }

                        commentBuffer = "";
                        while(sr.Peek() != '+' && 
                                sr.Peek() != '-' && 
                                sr.Peek() != '>' && 
                                sr.Peek() != '<' && 
                                sr.Peek() != '.' && 
                                sr.Peek() != ',' && 
                                sr.Peek() != '[' && 
                                sr.Peek() != ']' && 
                                sr.Peek() != '\r' &&
                                sr.Peek() != '\n' &&
                                sr.Peek() != '\t' &&
                                !sr.EndOfStream)
                        {
                            commentBuffer += chr;
                            chr = (char)sr.Read();
                        }
                        commentBuffer += chr;

                        commentBuffer = commentBuffer.TrimStart(' ', '\r', '\n', '\t').TrimEnd(Environment.NewLine.ToCharArray());

                        if (commentBuffer != "")
                        {
                            instruction = new Instructions.Comment(this, position, commentBuffer);
                            break;
                        }

                        instruction = null;
                        break;
                }

                if (instruction != null && instruction.GetType() != typeof(Instructions.Comment))
                {
                    this.source.Add(instruction);
                }
                else if(instruction?.GetType() == typeof(Instructions.Comment))
                {
                    if (DebugInformation.ContainsKey(position))
                    {
                        this.DebugInformation[position].Add((Instructions.Comment)instruction);
                    }
                    else
                    {
                        this.DebugInformation.Add(position, new List<Instructions.Comment>());
                        this.DebugInformation[position].Add((Instructions.Comment)instruction);
                    }
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

        public void Step()
        {
            if(PC < this.source.Count)
            {
                this.source[PC].Execute();
                PC++;
            }
        }
    }
}
