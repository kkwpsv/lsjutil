using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents a decimal data type that provides a sign and scale for a number (as in coordinates.)
    /// Decimal variables are stored as 96-bit(12-byte) unsigned integers scaled by a variable power of 10.
    /// The power of 10 scaling factor specifies the number of digits to the right of the decimal point, and ranges from 0 to 28.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wtypes/ns-wtypes-decimal-r1"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct DECIMAL
    {
        /// <summary>
        /// Reserved.
        /// </summary>
        [FieldOffset(0)]
        public USHORT wReserved;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public USHORT signscale;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public BYTE scale;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(1)]
        public BYTE sign;

        /// <summary>
        /// The high 32 bits of the number.
        /// </summary>
        [FieldOffset(0)]
        public ULONG Hi32;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public ULONG Lo32;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(4)]
        public ULONG Mid32;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public ULONGLONG Lo64;
    }
}
