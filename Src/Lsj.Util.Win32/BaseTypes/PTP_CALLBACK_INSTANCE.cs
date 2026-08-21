using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// PTP_CALLBACK_INSTANCE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PTP_CALLBACK_INSTANCE
    {
        private nint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(PTP_CALLBACK_INSTANCE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PTP_CALLBACK_INSTANCE(nint val) => new PTP_CALLBACK_INSTANCE { _value = val };
    }
}
