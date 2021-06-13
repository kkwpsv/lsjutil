using Lsj.Util.Win32.Extensions;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A message parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/winprog/windows-data-types"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LPARAM
    {
        private IntPtr _value;

        /// <summary>
        /// Safe Convert To <see cref="int"/>
        /// </summary>
        /// <returns></returns>
        public int SafeToInt32() => _value.SafeToInt32();

        /// <summary>
        /// Safe Convert To <see cref="uint"/>
        /// </summary>
        /// <returns></returns>
        public uint SafeToUInt32() => _value.SafeToUInt32();

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(LPARAM val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPARAM(IntPtr val) => new LPARAM { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPARAM(int val) => new LPARAM { _value = (IntPtr)val };
    }
}
