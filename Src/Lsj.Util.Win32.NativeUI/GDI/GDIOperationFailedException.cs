using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.NativeUI.GDI
{
    public class GDIOperationFailedException : Exception
    {
        public GDIOperationFailedException(string methodName) : base($"{methodName} Failed.")
        {

        }
    }
}
