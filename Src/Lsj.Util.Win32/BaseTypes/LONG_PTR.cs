using Lsj.Util.Win32.Extensions;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="LONG_PTR"/> is a long type used for pointer precision.
    /// It is used when casting a pointer to a long type to perform pointer arithmetic.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/bbcfb0af-8349-4e98-ad26-957e1363f714
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LONG_PTR
    {
        private IntPtr _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(LONG_PTR val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LONG_PTR(IntPtr val) => new LONG_PTR { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int SafeToInt32() => _value.SafeToInt32();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public uint SafeToUInt32() => _value.SafeToUInt32();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long SafeToInt64() => _value.SafeToInt64();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ulong SafeToUInt64() => _value.SafeToUInt64();
    }
}
