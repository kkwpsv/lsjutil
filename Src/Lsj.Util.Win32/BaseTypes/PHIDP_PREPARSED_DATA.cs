using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// PHIDP_PREPARSED_DATA
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PHIDP_PREPARSED_DATA
    {
        private nint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(PHIDP_PREPARSED_DATA val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PHIDP_PREPARSED_DATA(nint val) => new PHIDP_PREPARSED_DATA { _value = val };
    }
}
