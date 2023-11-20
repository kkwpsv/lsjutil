using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// HPCON 
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct HPCON
    {
        [FieldOffset(0)]
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(HPCON val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HPCON(IntPtr val) => new HPCON { _value = val };
    }
}
