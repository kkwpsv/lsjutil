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
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(LPITEMIDLIST val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPITEMIDLIST(IntPtr val) => new LPITEMIDLIST { _value = val };
    }
}
