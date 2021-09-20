using Lsj.Util.Win32.Extensions;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// Signed result of message processing.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/winprog/windows-data-types"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LRESULT
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(LRESULT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LRESULT(IntPtr val) => new LRESULT { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LRESULT(int val) => new LRESULT { _value = (IntPtr)val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static explicit operator int(LRESULT val) => val.SafeToInt32();
    }
}
