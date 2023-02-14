using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PFLS_CALLBACK_FUNCTION
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/nc-winnt-pfls_callback_function"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PFLS_CALLBACK_FUNCTION
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PflsCallbackFunction(PFLS_CALLBACK_FUNCTION val) => (PflsCallbackFunction)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(PflsCallbackFunction));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PFLS_CALLBACK_FUNCTION(PflsCallbackFunction val) => new PFLS_CALLBACK_FUNCTION { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PFLS_CALLBACK_FUNCTION val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PFLS_CALLBACK_FUNCTION(IntPtr val) => new PFLS_CALLBACK_FUNCTION { _ptr = val };
    }
}
