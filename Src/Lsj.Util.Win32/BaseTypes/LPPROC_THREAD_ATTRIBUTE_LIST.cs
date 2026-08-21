using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// LPPROC_THREAD_ATTRIBUTE_LIST
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPPROC_THREAD_ATTRIBUTE_LIST
    {
        private nint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(LPPROC_THREAD_ATTRIBUTE_LIST val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPPROC_THREAD_ATTRIBUTE_LIST(nint val) => new LPPROC_THREAD_ATTRIBUTE_LIST { _value = val };
    }
}
