using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="CHAR"/> is an 8-bit block of data that typically contains an ANSI character, as specified in [ISO/IEC-8859-1].
    /// For information on the char keyword, see [C706] section 4.2.9.3.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/77e1033f-b31d-4bd2-b3d5-9f3c9faa22eb"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public struct CHAR
    {
        [FieldOffset(0)]
        private byte _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator byte(CHAR val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator CHAR(byte val) => new CHAR { _value = val };
    }
}
