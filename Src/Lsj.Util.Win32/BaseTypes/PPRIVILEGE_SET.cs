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
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(PPRIVILEGE_SET val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PPRIVILEGE_SET(IntPtr val) => new PPRIVILEGE_SET { _value = val };
    }
}
