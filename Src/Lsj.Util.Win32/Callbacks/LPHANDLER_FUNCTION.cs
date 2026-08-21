using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPHANDLER_FUNCTION
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nc-winsvc-lphandler_function"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPHANDLER_FUNCTION
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LphandlerFunction(LPHANDLER_FUNCTION val) => (LphandlerFunction)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(LphandlerFunction));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPHANDLER_FUNCTION(LphandlerFunction val) => new LPHANDLER_FUNCTION { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(LPHANDLER_FUNCTION val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPHANDLER_FUNCTION(nint val) => new LPHANDLER_FUNCTION { _ptr = val };
    }
}
