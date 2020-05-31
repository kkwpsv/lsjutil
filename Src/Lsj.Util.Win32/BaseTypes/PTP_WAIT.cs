using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// PTP_WAIT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PTP_WAIT
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(PTP_WAIT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PTP_WAIT(IntPtr val) => new PTP_WAIT { _value = val };
    }
}
