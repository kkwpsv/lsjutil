using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// BFFCALLBACK
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb762598(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BFFCALLBACK
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator BrowseCallbackProc(BFFCALLBACK val) => (BrowseCallbackProc)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(BrowseCallbackProc));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator BFFCALLBACK(BrowseCallbackProc val) => new BFFCALLBACK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(BFFCALLBACK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator BFFCALLBACK(IntPtr val) => new BFFCALLBACK { _ptr = val };
    }
}
