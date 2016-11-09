using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckIntLib
{
    public class LoopReference
    {
        private int start;
        private int end;

        public int Start
        {
            get
            {
                return start;
            }

            set
            {
                start = value;
            }
        }

        public int End
        {
            get
            {
                return end;
            }

            set
            {
                end = value;
            }
        }
    }
}
