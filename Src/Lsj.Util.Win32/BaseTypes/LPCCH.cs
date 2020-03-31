using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// LPCCH
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPCCH
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(LPCCH val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPCCH(IntPtr val) => new LPCCH { _value = val };
    }
}
