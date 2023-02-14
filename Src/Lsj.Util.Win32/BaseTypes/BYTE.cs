using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="BYTE"/> is an 8-bit unsigned value that corresponds to a single octet in a network protocol.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-dtyp/d7edc080-e499-4219-a837-1bc40b64bb04"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public struct BYTE
    {
        [FieldOffset(0)]
        private byte _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator byte(BYTE val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator BYTE(byte val) => new BYTE { _value = val };
    }
}
