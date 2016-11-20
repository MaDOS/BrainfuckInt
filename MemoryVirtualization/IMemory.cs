using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryVirtualization
{
    interface IMemory<T>
    {
        List<T> Data
        {
            get;
            set;
        }
    }
}
