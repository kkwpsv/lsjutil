using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// LPFIBER_START_ROUTINE
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nc-winbase-pfiber_start_routine"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPFIBER_START_ROUTINE
    {
        private IntPtr _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LpfiberStartRoutine(LPFIBER_START_ROUTINE val) => (LpfiberStartRoutine)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(LpfiberStartRoutine));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPFIBER_START_ROUTINE(LpfiberStartRoutine val) => new LPFIBER_START_ROUTINE { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator IntPtr(LPFIBER_START_ROUTINE val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator LPFIBER_START_ROUTINE(IntPtr val) => new LPFIBER_START_ROUTINE { _ptr = val };
    }
}
