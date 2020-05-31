using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// PTP_CLEANUP_GROUP
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PTP_CLEANUP_GROUP
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(PTP_CLEANUP_GROUP val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PTP_CLEANUP_GROUP(IntPtr val) => new PTP_CLEANUP_GROUP { _value = val };
    }
}
