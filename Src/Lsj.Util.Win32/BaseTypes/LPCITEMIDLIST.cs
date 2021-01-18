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
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(LPCITEMIDLIST val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPCITEMIDLIST(IntPtr val) => new LPCITEMIDLIST { _value = val };
    }
}
