using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryVirtualization
{
    public abstract class Cell<T>
    {
        T value;

        public T Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public abstract Cell<T> Dec();

        public abstract Cell<T> Inc();       

        public static bool operator ==(Cell<T> op1, T op2)
        {
            return op1.Value.Equals(op2);
        }
        public static bool operator !=(Cell<T> op1, T op2)
        {
            return !(op1 == op2);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
