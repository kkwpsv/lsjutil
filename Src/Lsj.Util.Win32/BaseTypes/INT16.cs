using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// An <see cref="INT16"/> is a 16-bit signed integer (range: –32768 through 32767 decimal).
    /// The first bit (Most Significant Bit (MSB)) is the signing bit.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/c19c7f85-a511-4407-a7bf-5da9fa79d026
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct INT16
    {
        [FieldOffset(0)]
        private short _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator short(INT16 val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator INT16(short val) => new INT16 { _value = val };
    }
}
