using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryVirtualization.Cells
{
    public class _8BitCell : Cell<byte>
    {
        public _8BitCell()
        {
            this.Value = 0;
        }

        public override Cell<byte> Dec()
        {
            this.Value--;
            return this;
        }

        public override Cell<byte> Inc()
        {
            this.Value++;
            return this;
        }
    }
}
