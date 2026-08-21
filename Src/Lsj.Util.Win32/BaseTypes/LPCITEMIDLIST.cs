using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// LPCITEMIDLIST
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPCITEMIDLIST
    {
        private nint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nint(LPCITEMIDLIST val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPCITEMIDLIST(nint val) => new LPCITEMIDLIST { _value = val };
    }
}
