using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// TP_POOL_STACK_INFORMATION
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TP_POOL_STACK_INFORMATION
    {
        /// <summary>
        /// StackReserve
        /// </summary>
        public SIZE_T StackReserve;

        /// <summary>
        /// StackCommit
        /// </summary>
        public SIZE_T StackCommit;
    }
}
