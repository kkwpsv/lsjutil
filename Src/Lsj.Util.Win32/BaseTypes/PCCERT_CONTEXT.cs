using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// PCCERT_CONTEXT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PCCERT_CONTEXT
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(PCCERT_CONTEXT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator PCCERT_CONTEXT(IntPtr val) => new PCCERT_CONTEXT { _value = val };
    }
}
