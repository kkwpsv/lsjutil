using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A handle to a font.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/winprog/windows-data-types
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HFONT
    {
        private HANDLE _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HANDLE(HFONT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HFONT(HANDLE val) => new HFONT { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(HFONT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HFONT(IntPtr val) => new HFONT { _value = val };
    }
}
