using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// PCOPYFILE2_PROGRESS_ROUTINE
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nc-winbase-pcopyfile2_progress_routine"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PCOPYFILE2_PROGRESS_ROUTINE
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Pcopyfile2ProgressRoutine(PCOPYFILE2_PROGRESS_ROUTINE val) => (Pcopyfile2ProgressRoutine)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Pcopyfile2ProgressRoutine));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PCOPYFILE2_PROGRESS_ROUTINE(Pcopyfile2ProgressRoutine val) => new PCOPYFILE2_PROGRESS_ROUTINE { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(PCOPYFILE2_PROGRESS_ROUTINE val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator PCOPYFILE2_PROGRESS_ROUTINE(IntPtr val) => new PCOPYFILE2_PROGRESS_ROUTINE { _ptr = val };
    }
}
