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
                return this.program.source[this.instructionPointer];
            }
        }

        internal int instructionPointer
        {
            get
            {
                return this.program.PC;
            }
        }


        public async void RunProgram()
        {
            await Task.Factory.StartNew(() => this.Program.Execute());
        }

        public async void RunProgram(ManualResetEvent mrse) //Use this if you need to block your main Thread as long as the programm runs
        {
            await Task.Factory.StartNew(() => this.Program.Execute());
            mrse.Set();
        }

        public void RunWithDebugger()
        {
            this.debuggerThread = new Thread(new ThreadStart(Run));
        }

        private void Run()
        {
            for (this.program.PC = 0; this.program.PC < this.program.source.Count; this.program.PC++)
            {
                this.Step();
            }
        }

        private void Step()
        {
            if (breakPoints.ContainsKey(this.instructionPointer))
            {
                pauseReset.Reset();

                this.BreakPointHit(new BreakPointHitEventArgs()
                {
                    InstructionPointer = this.instructionPointer,
                    NextInstruction = this.nextInstruction,
                    PauseReset = pauseReset
                });
                pauseReset.WaitOne();
            }
        }

        public void Resume()
        {
            pauseReset.Set();
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
