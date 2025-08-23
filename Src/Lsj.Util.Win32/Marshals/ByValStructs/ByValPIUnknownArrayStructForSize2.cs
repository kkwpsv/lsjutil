using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals.ByValStructs
{
    /// <summary>
    /// By val <see cref="IUnknown"/> pointer array struct for size 2
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct ByValPIUnknownArrayStructForSize2
    {
        private P<IUnknown> _0;
        private P<IUnknown> _1;
    }
}
