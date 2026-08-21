using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// GEO_ENUMPROC
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GEO_ENUMPROC
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator EnumGeoInfoProc(GEO_ENUMPROC val) => (EnumGeoInfoProc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(EnumGeoInfoProc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator GEO_ENUMPROC(EnumGeoInfoProc val) => new GEO_ENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(GEO_ENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator GEO_ENUMPROC(nint val) => new GEO_ENUMPROC { _ptr = val };
    }
}
