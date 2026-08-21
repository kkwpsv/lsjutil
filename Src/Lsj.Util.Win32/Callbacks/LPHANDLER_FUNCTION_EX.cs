using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPHANDLER_FUNCTION_EX
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nc-winsvc-lphandler_function_ex"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPHANDLER_FUNCTION_EX
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LphandlerFunctionEx(LPHANDLER_FUNCTION_EX val) => (LphandlerFunctionEx)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(LphandlerFunctionEx));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPHANDLER_FUNCTION_EX(LphandlerFunctionEx val) => new LPHANDLER_FUNCTION_EX { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(LPHANDLER_FUNCTION_EX val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPHANDLER_FUNCTION_EX(nint val) => new LPHANDLER_FUNCTION_EX { _ptr = val };
    }
}
