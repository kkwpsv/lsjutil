using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// WAITORTIMERCALLBACK
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms687066(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WAITORTIMERCALLBACK
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Waitortimercallback(WAITORTIMERCALLBACK val) => (Waitortimercallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Waitortimercallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WAITORTIMERCALLBACK(Waitortimercallback val) => new WAITORTIMERCALLBACK { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(WAITORTIMERCALLBACK val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator WAITORTIMERCALLBACK(IntPtr val) => new WAITORTIMERCALLBACK { _ptr = val };
    }
}
