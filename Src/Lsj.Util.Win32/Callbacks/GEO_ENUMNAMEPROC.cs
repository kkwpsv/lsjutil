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
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator GeoEnumnameproc(GEO_ENUMNAMEPROC val) => (GeoEnumnameproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(GeoEnumnameproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator GEO_ENUMNAMEPROC(GeoEnumnameproc val) => new GEO_ENUMNAMEPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(GEO_ENUMNAMEPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator GEO_ENUMNAMEPROC(nint val) => new GEO_ENUMNAMEPROC { _ptr = val };
    }
}
