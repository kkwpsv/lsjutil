using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="ULONGLONG"/> is a 64-bit unsigned integer (range: 0 through 18446744073709551615 decimal).
    /// Because a <see cref="ULONGLONG"/> is unsigned, its first bit (Most Significant Bit (MSB)) is not reserved for signing.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/c57d9fba-12ef-4853-b0d5-a6f472b50388
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct ULONGLONG
    {
        [FieldOffset(0)]
        private ulong _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ulong(ULONGLONG val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ULONGLONG(ulong val) => new ULONGLONG { _value = val };
    }
}
