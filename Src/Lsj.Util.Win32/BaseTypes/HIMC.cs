using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// HIMC
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HIMC : IPointer
    {
        private HANDLE _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(HIMC val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HIMC(IntPtr val) => new HIMC { _value = val };
    }
}
