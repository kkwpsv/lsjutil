using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// FARPROC
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct FARPROC
    {
        [FieldOffset(0)]
        private INT_PTR _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator INT_PTR(FARPROC val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator FARPROC(INT_PTR val) => new FARPROC { _value = val };
    }
}
