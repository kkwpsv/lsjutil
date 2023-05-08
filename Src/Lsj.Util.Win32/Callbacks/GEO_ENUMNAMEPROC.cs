using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// GEO_ENUMNAMEPROC
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GEO_ENUMNAMEPROC
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Geo_EnumNameProc(GEO_ENUMNAMEPROC val) => (Geo_EnumNameProc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Geo_EnumNameProc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator GEO_ENUMNAMEPROC(Geo_EnumNameProc val) => new GEO_ENUMNAMEPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(GEO_ENUMNAMEPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator GEO_ENUMNAMEPROC(IntPtr val) => new GEO_ENUMNAMEPROC { _ptr = val };
    }
}
