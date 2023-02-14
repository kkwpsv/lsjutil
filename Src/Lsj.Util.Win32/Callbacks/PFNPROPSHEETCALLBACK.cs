using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comctl32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PFNPROPSHEETCALLBACK 
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/prsht/nc-prsht-pfnpropsheetcallback"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PFNPROPSHEETCALLBACK
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Pfnpropsheetcallback(PFNPROPSHEETCALLBACK val) => (Pfnpropsheetcallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Pfnpropsheetcallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PFNPROPSHEETCALLBACK(Pfnpropsheetcallback val) => new PFNPROPSHEETCALLBACK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PFNPROPSHEETCALLBACK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PFNPROPSHEETCALLBACK(IntPtr val) => new PFNPROPSHEETCALLBACK { _ptr = val };
    }
}
