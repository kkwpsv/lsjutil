using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPTHREAD_START_ROUTINE
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms686736(v=vs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPTHREAD_START_ROUTINE
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Lpthreadstartroutine(LPTHREAD_START_ROUTINE val) => (Lpthreadstartroutine)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Lpthreadstartroutine));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPTHREAD_START_ROUTINE(Lpthreadstartroutine val) => new LPTHREAD_START_ROUTINE { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LPTHREAD_START_ROUTINE val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPTHREAD_START_ROUTINE(IntPtr val) => new LPTHREAD_START_ROUTINE { _ptr = val };
    }
}
