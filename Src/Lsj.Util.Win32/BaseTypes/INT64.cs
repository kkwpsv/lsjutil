using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// An <see cref="INT64"/> is a 64-bit signed integer (range: –9223372036854775808 through 9223372036854775807 decimal).
    /// The first bit (Most Significant Bit (MSB)) is the signing bit.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-dtyp/cfb2030b-0d7a-4808-8539-32f35bd9325f"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct INT64
    {
        [FieldOffset(0)]
        private long _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator long(INT64 val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator INT64(long val) => new INT64 { _value = val };
    }
}
