using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// ENUMRESNAMEPROC 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ENUMRESNAMEPROC
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Enumresnameprocw(ENUMRESNAMEPROC val) => (Enumresnameprocw)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Enumresnameprocw));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ENUMRESNAMEPROC(Enumresnameprocw val) => new ENUMRESNAMEPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(ENUMRESNAMEPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator ENUMRESNAMEPROC(nint val) => new ENUMRESNAMEPROC { _ptr = val };
    }
}
