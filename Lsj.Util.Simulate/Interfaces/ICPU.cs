using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Simulate.Interfaces
{
    public interface ICPU
    {
        VirtualMachine machine
        {
            get;
            set;
        }
    }
}
