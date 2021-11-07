using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PTIMERAPCROUTINE
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nc-synchapi-ptimerapcroutine"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PTIMERAPCROUTINE
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Ptimerapcroutine(PTIMERAPCROUTINE val) => (Ptimerapcroutine)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Ptimerapcroutine));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PTIMERAPCROUTINE(Ptimerapcroutine val) => new PTIMERAPCROUTINE { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PTIMERAPCROUTINE val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PTIMERAPCROUTINE(IntPtr val) => new PTIMERAPCROUTINE { _ptr = val };
    }
}
