using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// ICMENUMPROC
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ICMENUMPROC
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Icmenumproc(ICMENUMPROC val) => (Icmenumproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Icmenumproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ICMENUMPROC(Icmenumproc val) => new ICMENUMPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(ICMENUMPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator ICMENUMPROC(nint val) => new ICMENUMPROC { _ptr = val };
    }
}
