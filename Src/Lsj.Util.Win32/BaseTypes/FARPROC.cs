using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// FARPROC
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct FARPROC
    {
        [FieldOffset(0)]
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(FARPROC val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator FARPROC(IntPtr val) => new FARPROC { _value = val };
    }
}
