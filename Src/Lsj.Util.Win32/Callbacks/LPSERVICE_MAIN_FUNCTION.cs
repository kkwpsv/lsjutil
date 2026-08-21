using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPSERVICE_MAIN_FUNCTION
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nc-winsvc-lpservice_main_functionw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPSERVICE_MAIN_FUNCTION
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LpserviceMainFunction(LPSERVICE_MAIN_FUNCTION val) => (LpserviceMainFunction)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(LpserviceMainFunction));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPSERVICE_MAIN_FUNCTION(LpserviceMainFunction val) => new LPSERVICE_MAIN_FUNCTION { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(LPSERVICE_MAIN_FUNCTION val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPSERVICE_MAIN_FUNCTION(nint val) => new LPSERVICE_MAIN_FUNCTION { _ptr = val };
    }
}
