using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPPROGRESS_ROUTINE
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nc-winbase-lpprogress_routine"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPPROGRESS_ROUTINE
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LpprogressRoutine(LPPROGRESS_ROUTINE val) => (LpprogressRoutine)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(LpprogressRoutine));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPPROGRESS_ROUTINE(LpprogressRoutine val) => new LPPROGRESS_ROUTINE { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LPPROGRESS_ROUTINE val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPPROGRESS_ROUTINE(IntPtr val) => new LPPROGRESS_ROUTINE { _ptr = val };
    }
}
