using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PENUM_PAGE_FILE_CALLBACK 
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/nc-psapi-penum_page_file_callbackw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PENUM_PAGE_FILE_CALLBACK
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PenumPageFileCallbackw(PENUM_PAGE_FILE_CALLBACK val) => (PenumPageFileCallbackw)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(PenumPageFileCallbackw));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PENUM_PAGE_FILE_CALLBACK(PenumPageFileCallbackw val) => new PENUM_PAGE_FILE_CALLBACK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(PENUM_PAGE_FILE_CALLBACK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PENUM_PAGE_FILE_CALLBACK(nint val) => new PENUM_PAGE_FILE_CALLBACK { _ptr = val };
    }
}
