using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.NativeUI.GDI
{
    /// <summary>
    /// GDIOperationFailedException
    /// </summary>
    public class GDIOperationFailedException : Exception
    {
        /// <summary>
        /// GDIOperationFailedException
        /// </summary>
        /// <param name="methodName"></param>
        public GDIOperationFailedException(string methodName) : base($"{methodName} Failed.")
        {

        }
    }
}
