using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// PVOID64
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct PVOID64
    {
        [FieldOffset(0)]
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(PVOID64 val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PVOID64(IntPtr val) => new PVOID64 { _value = val };
    }
}
