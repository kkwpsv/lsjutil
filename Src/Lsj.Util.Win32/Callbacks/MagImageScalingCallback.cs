using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Magnification;

namespace Lsj.Util.Win32.Callbacks
{
    /// <summary>
    /// <para>
    /// MagImageScalingCallback
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/magnification/nc-magnification-magimagescalingcallback"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MagImageScalingCallback
    {
        private nint _ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator Magimagescalingcallback(MagImageScalingCallback val) => (Magimagescalingcallback)Marshal.GetDelegateForFunctionPointer(val._ptr, typeof(Magimagescalingcallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator MagImageScalingCallback(Magimagescalingcallback val) => new MagImageScalingCallback { _ptr = Marshal.GetFunctionPointerForDelegate(val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator nint(MagImageScalingCallback val) => val._ptr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator MagImageScalingCallback(nint val) => new MagImageScalingCallback { _ptr = val };
    }
}
