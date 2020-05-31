using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="UCHAR"/> is an 8-bit integer with the range: 0 through 255 decimal.
    /// Because a <see cref="UCHAR"/> is unsigned, its first bit (Most Significant Bit (MSB)) is not reserved for signing.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/050baef1-f978-4851-a3c7-ad701a90e54a
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public struct UCHAR
    {
        [FieldOffset(0)]
        private byte _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator byte(UCHAR val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator UCHAR(byte val) => new UCHAR { _value = val };
    }
}
