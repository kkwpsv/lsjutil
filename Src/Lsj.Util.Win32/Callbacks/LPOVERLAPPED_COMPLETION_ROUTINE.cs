using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPOVERLAPPED_COMPLETION_ROUTINE
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/nc-minwinbase-lpoverlapped_completion_routine"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPOVERLAPPED_COMPLETION_ROUTINE
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LpoverlappedCompletionRoutine(LPOVERLAPPED_COMPLETION_ROUTINE val) => (LpoverlappedCompletionRoutine)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(LpoverlappedCompletionRoutine));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPOVERLAPPED_COMPLETION_ROUTINE(LpoverlappedCompletionRoutine val) => new LPOVERLAPPED_COMPLETION_ROUTINE { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LPOVERLAPPED_COMPLETION_ROUTINE val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPOVERLAPPED_COMPLETION_ROUTINE(IntPtr val) => new LPOVERLAPPED_COMPLETION_ROUTINE { _ptr = val };
    }
}
