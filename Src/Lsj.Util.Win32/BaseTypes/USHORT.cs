using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="USHORT"/> is a 16-bit unsigned integer (range: 0 through 65535 decimal).
    /// Because a <see cref="USHORT"/> is unsigned, its first bit (Most Significant Bit (MSB)) is not reserved for signing.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/c0618c5b-362b-4e06-9cb0-8720d240cf12
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct USHORT
    {
        /// <summary>
        /// MAXUSHORT
        /// </summary>
        public static USHORT MAXUSHORT = 0xffff;

        [FieldOffset(0)]
        private ushort _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ushort(USHORT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator USHORT(ushort val) => new USHORT { _value = val };
    }
}
