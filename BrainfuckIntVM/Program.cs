using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BrainfuckIntLib;

namespace BrainfuckIntVM
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args[0] == "")
            {
                Console.WriteLine("Please specify a brainfuck program to run!");
                Console.WriteLine("EXAMPLE: brainfuckvm.exe path/to/program.bf");

                return;
            }

            BrainfuckIntLib.Program program = new BrainfuckIntLib.Program(new System.IO.FileInfo(args[0]));

            ManualResetEvent mrse = new ManualResetEvent(false);
            new Interpreter(program).RunProgram(mrse);
            mrse.WaitOne();
        }
    }
}
