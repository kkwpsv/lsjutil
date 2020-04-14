using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A handle to an internal drop structure.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/winprog/windows-data-types
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HDROP
    {
        private HANDLE _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HANDLE(HDROP val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HDROP(HANDLE val) => new HDROP { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(HDROP val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HDROP(IntPtr val) => new HDROP { _value = val };
    }
}
