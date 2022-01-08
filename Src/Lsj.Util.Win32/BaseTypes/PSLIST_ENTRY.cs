using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// PSLIST_ENTRY
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PSLIST_ENTRY
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(PSLIST_ENTRY val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PSLIST_ENTRY(IntPtr val) => new PSLIST_ENTRY { _value = val };
    }
}
