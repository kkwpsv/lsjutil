using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// KAFFINITY
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KAFFINITY
    {
        private nuint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator nuint(KAFFINITY val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator KAFFINITY(nuint val) => new KAFFINITY { _value = val };
    }
}
