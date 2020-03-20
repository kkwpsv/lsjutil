using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// PTP_TIMER
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PTP_CALLBACK_ENVIRON
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(PTP_CALLBACK_ENVIRON val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PTP_CALLBACK_ENVIRON(IntPtr val) => new PTP_CALLBACK_ENVIRON { _value = val };
    }
}
