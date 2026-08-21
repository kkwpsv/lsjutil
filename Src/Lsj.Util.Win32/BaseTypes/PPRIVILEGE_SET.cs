using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// PPRIVILEGE_SET
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PPRIVILEGE_SET
    {
        private nint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(PPRIVILEGE_SET val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PPRIVILEGE_SET(nint val) => new PPRIVILEGE_SET { _value = val };
    }
}
