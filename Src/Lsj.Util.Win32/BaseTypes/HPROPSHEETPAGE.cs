using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// HPROPSHEETPAGE
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HPROPSHEETPAGE : IPointer
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
        public static implicit operator HANDLE(HPROPSHEETPAGE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HPROPSHEETPAGE(HANDLE val) => new HPROPSHEETPAGE { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(HPROPSHEETPAGE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HPROPSHEETPAGE(IntPtr val) => new HPROPSHEETPAGE { _value = val };
    }
}
