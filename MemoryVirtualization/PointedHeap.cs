using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryVirtualization
{
    public class PointedHeap<T, U> : IMemory<T> where T : Cell<U>, new()
    {
        protected int heapPointer = 0;

        private List<T> data = new List<T>();
        public List<T> Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public T activeCell
        {
            get
            {
                return this.Data[this.heapPointer];
            }
            set
            {
                this.Data[this.heapPointer] = value;
            }
        }

        public U activeValue
        {
            get
            {
                return activeCell.Value;
            }
            set
            {
                this.activeCell.Value = value;
            }
        }

        public PointedHeap()
        {
            this.Data.Add(new T());
        }

        ~PointedHeap()
        { }

        public void IncrementHP()
        {
            if (this.Data.Count - 1 >= this.heapPointer + 1)
            {
                this.heapPointer++;
            }
            else
            {
                this.Data.Add(new T());
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
                this.Data.Insert(0, new T());
            }
        }

        public void IncrementData()
        {
            this.Data[this.heapPointer].Inc();
        }

        public void DecrementData()
        {
            this.data[this.heapPointer].Dec();
        }
    }
}
