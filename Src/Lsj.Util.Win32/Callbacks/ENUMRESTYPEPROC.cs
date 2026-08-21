using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// ENUMRESTYPEPROC 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ENUMRESTYPEPROC
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Enumrestypeproc(ENUMRESTYPEPROC val) => (Enumrestypeproc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Enumrestypeproc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ENUMRESTYPEPROC(Enumrestypeproc val) => new ENUMRESTYPEPROC { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(ENUMRESTYPEPROC val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator ENUMRESTYPEPROC(nint val) => new ENUMRESTYPEPROC { _ptr = val };
    }
}
