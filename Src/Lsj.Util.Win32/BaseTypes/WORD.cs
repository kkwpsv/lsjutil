using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="WORD"/> is a 16-bit unsigned integer (range: 0 through 65535 decimal). Because a WORD is unsigned,
    /// its first bit (Most Significant Bit (MSB)) is not reserved for signing.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-dtyp/f8573df3-a44a-4a50-b070-ac4c3aa78e3c"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct WORD
    {
        [FieldOffset(0)]
        private ushort _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ushort(WORD val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WORD(ushort val) => new WORD { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator short(WORD val) => unchecked((short)val._value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator WORD(short val) => new WORD { _value = unchecked((ushort)val) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(WORD val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(WORD val) => val._value;
    }
}
