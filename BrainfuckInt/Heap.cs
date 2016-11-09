using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckIntLib
{
    public class Heap
    {
        protected List<byte> data = new List<byte>();
        protected int heapPointer = 0;
        
        public byte Data
        {
            get
            {
                return this.data[this.heapPointer];
            }
            set
            {
                this.data[this.heapPointer] = value;
            }
        }

        public Heap()
        {
            this.data.Add(0);
        }

        ~Heap()
        { }

        public void IncrementHP()
        {
            if (this.data.Count - 1 >= this.heapPointer + 1)
            {
                this.heapPointer++;
            }
            else
            {
                this.data.Add(0);
                this.heapPointer++;
            }
        }
        
        public void DecrementHP()
        {
            if (this.heapPointer > 0)
            {
                this.heapPointer--;
            }
            else
            {
                this.data.Insert(0, 0);
            }
        }

        public void IncrementData()
        {
            this.data[this.heapPointer]++;
        }

        public void DecrementData()
        {
            this.data[this.heapPointer]--;
        }
    }
}
