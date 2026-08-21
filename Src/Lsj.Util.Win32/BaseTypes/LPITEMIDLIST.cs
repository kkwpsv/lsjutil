using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// LPITEMIDLIST
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPITEMIDLIST
    {
        private nint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(LPITEMIDLIST val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPITEMIDLIST(nint val) => new LPITEMIDLIST { _value = val };
    }
}
