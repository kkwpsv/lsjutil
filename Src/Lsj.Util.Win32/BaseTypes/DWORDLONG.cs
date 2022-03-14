using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A <see cref="DWORDLONG"/> is a 64-bit unsigned integer (range: 0 through 18446744073709551615 decimal).
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/c575fb47-166c-48cd-a37c-e44cac05c3d6"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct DWORDLONG
    {
        [FieldOffset(0)]
        private ulong _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ulong(DWORDLONG val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DWORDLONG(ulong val) => new DWORDLONG { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator long(DWORDLONG val) => unchecked((long)val._value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator DWORDLONG(long val) => new DWORDLONG { _value = unchecked((ulong)val) };
    }
}
