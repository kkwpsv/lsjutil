using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="LONGLONG"/> is a 64-bit signed integer (range: –9223372036854775808 through 9223372036854775807 decimal).
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/e34f8048-e2d0-4f5b-99fd-0b6489ee0295"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct LONGLONG
    {
        [FieldOffset(0)]
        private long _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator long(LONGLONG val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LONGLONG(long val) => new LONGLONG { _value = val };
    }
}
