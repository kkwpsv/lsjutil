using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// HMETAFILEPICT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HMETAFILEPICT
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(HMETAFILEPICT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HMETAFILEPICT(IntPtr val) => new HMETAFILEPICT { _value = val };
    }
}
