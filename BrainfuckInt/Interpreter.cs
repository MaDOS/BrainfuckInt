using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BrainfuckIntLib
{
    public class Interpreter
    {
        private Program program;
        private Thread debuggerThread;
        private Dictionary<int, BreakPoint> breakPoints = new Dictionary<int, BreakPoint>();
        private ManualResetEvent pauseReset = new ManualResetEvent(false);

        public event BreakPointHitEventHandler BreakPointHit;
        public delegate void BreakPointHitEventHandler(BreakPointHitEventArgs eventArgs);

        public Interpreter(Program program)
        {
            this.program = program;
        }

        public Program Program
        {
            get
            {
                return program;
            }
        }

        internal Instruction nextInstruction
        {
            get
            {
                return this.program.source[this.InstructionPointer];
            }
        }

        public int InstructionPointer
        {
            get
            {
                return this.program.InstructionPointer;
            }
            protected set
            {
                this.program.InstructionPointer = value;
            }
        }

        public async void RunProgram()
        {
            await Task.Factory.StartNew(() => this.Execute());
        }

        public async void RunProgram(ManualResetEvent mrse) //Use this if you need to block your main Thread as long as the programm runs
        {
            await Task.Factory.StartNew(() => this.Execute());
            mrse.Set();
        }

        public void RunWithDebugger()
        {
            this.debuggerThread = new Thread(new ThreadStart(Run));
        }

        private void Run()
        {
            for (this.InstructionPointer = 0; this.InstructionPointer < this.Program.source.Count; this.InstructionPointer++)
            {
                this.Step();
            }
        }

        private void Step()
        {
            if (breakPoints.ContainsKey(this.InstructionPointer))
            {
                pauseReset.Reset();

                this.BreakPointHit(new BreakPointHitEventArgs()
                {
                    InstructionPointer = this.InstructionPointer,
                    NextInstruction = this.nextInstruction,
                    PauseReset = pauseReset
                });
                pauseReset.WaitOne();
            }

            if (this.InstructionPointer < this.Program.source.Count)
            {
                this.Program.source[this.InstructionPointer].Execute();
                this.InstructionPointer++;
            }
        }

        public void Resume()
        {
            pauseReset.Set();
        }

        public void Pause()
        {
            pauseReset.Reset();
        }

        internal void Execute()
        {
            for (this.InstructionPointer = 0; this.InstructionPointer < this.Program.source.Count; this.InstructionPointer++)
            {
                this.Program.source[this.InstructionPointer].Execute();
            }
        }

        public void AddBreakPoint(BreakPoint breakPoint)
        {
            this.breakPoints.Add(breakPoint.InstructionPointer, breakPoint);
        }

        public class BreakPointHitEventArgs : EventArgs
        {
            private int instructionPointer;
            private Instruction nextInstruction;
            private ManualResetEvent pauseReset;

            public int InstructionPointer
            {
                get
                {
                    return instructionPointer;
                }

                set
                {
                    instructionPointer = value;
                }
            }

            public Instruction NextInstruction
            {
                get
                {
                    return nextInstruction;
                }

                set
                {
                    nextInstruction = value;
                }
            }

            public ManualResetEvent PauseReset
            {
                get
                {
                    return pauseReset;
                }

                set
                {
                    pauseReset = value;
                }
            }
        }

        public class BreakPoint //maybe i want to support conditional breaking etc later so I figured a class might be the right thing to do here instead of just saving integers
        {
            int instructionPointer;

            public BreakPoint(int instructionPointer)
            {

            }

            public int InstructionPointer
            {
                get
                {
                    return instructionPointer;
                }

                set
                {
                    instructionPointer = value;
                }
            }
        }
    }
}
