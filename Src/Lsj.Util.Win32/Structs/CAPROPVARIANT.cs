using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CAPROPVARIANT
    {
        /// <summary>
        /// 
        /// </summary>
        public ULONG cElems;

        private IntPtr _val;

#pragma warning disable IDE1006
        /// <summary>
        /// 
        /// </summary>
        public P<PROPVARIANT> pElems
        {
            get => _val;
            set => _val = value;
        }
#pragma warning restore IDE1006
    }
}
