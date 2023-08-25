using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals.ByValStructs
{
    /// <summary>
    /// By Val <see cref="IntPtr"/> Array Struct For Size 2
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct ByValIntPtrArrayStructForSize2
    {
        private IntPtr _0;
        private IntPtr _1;
    }
}
