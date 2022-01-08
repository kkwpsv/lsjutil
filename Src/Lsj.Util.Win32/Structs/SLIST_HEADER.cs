using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// SLIST_HEADER
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SLIST_HEADER
    {
        private IntPtr _padding1;
        private IntPtr _padding2;
    }
}
