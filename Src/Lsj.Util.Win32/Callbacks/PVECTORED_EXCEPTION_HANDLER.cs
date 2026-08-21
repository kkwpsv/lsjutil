using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PVECTORED_EXCEPTION_HANDLER
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nc-winnt-pvectored_exception_handler"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PVECTORED_EXCEPTION_HANDLER
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PvectoredExceptionHandler(PVECTORED_EXCEPTION_HANDLER val) => (PvectoredExceptionHandler)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(PvectoredExceptionHandler));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PVECTORED_EXCEPTION_HANDLER(PvectoredExceptionHandler val) => new PVECTORED_EXCEPTION_HANDLER { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(PVECTORED_EXCEPTION_HANDLER val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PVECTORED_EXCEPTION_HANDLER(nint val) => new PVECTORED_EXCEPTION_HANDLER { _ptr = val };
    }
}
