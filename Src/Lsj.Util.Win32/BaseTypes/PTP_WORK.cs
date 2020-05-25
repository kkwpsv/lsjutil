using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// PTP_WORK
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PTP_WORK
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(PTP_WORK val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PTP_WORK(IntPtr val) => new PTP_WORK { _value = val };
    }
}
