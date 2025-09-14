using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// LPCWCH
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPCWCH
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(LPCWCH val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPCWCH(IntPtr val) => new LPCWCH { _value = val };
    }
}
