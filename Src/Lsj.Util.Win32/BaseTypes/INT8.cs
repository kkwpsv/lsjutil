using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// An <see cref="INT8"/> is an 8-bit signed integer (range: –128 through 127 decimal).
    /// The first bit (Most Significant Bit (MSB)) is the signing bit.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-dtyp/fc85cdcc-92f3-46ef-a2aa-501f44d0968a"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public struct INT8
    {
        [FieldOffset(0)]
        private sbyte _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator sbyte(INT8 val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator INT8(sbyte val) => new INT8 { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator byte(INT8 val) => unchecked((byte)val._value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator INT8(byte val) => new INT8 { _value = unchecked((sbyte)val) };
    }
}
