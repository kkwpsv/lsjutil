using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="UINT64"/> is a 64-bit unsigned integer (range: 0 through 18446744073709551615 decimal).
    /// Because a <see cref="UINT64"/> is unsigned, its first bit (Most Significant Bit (MSB)) is not reserved for signing.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-dtyp/a7b7720f-87eb-4add-9bcb-c6ff652778ae"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct UINT64
    {
        [FieldOffset(0)]
        private ulong _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ulong(UINT64 val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator UINT64(ulong val) => new UINT64 { _value = val };
    }
}
