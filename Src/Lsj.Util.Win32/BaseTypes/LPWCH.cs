using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// LPWCH
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPWCH
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(LPWCH val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPWCH(IntPtr val) => new LPWCH { _value = val };
    }
}
