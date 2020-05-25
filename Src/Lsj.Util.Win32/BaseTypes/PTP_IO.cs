using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// PTP_IO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PTP_IO
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(PTP_IO val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PTP_IO(IntPtr val) => new PTP_IO { _value = val };
    }
}
