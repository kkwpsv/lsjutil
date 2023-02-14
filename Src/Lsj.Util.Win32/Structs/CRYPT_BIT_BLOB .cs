using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="CRYPT_BIT_BLOB"/> structure contains a set of bits represented by an array of bytes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_bit_blob"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Because the smallest chunk of memory that can normally be allocated is a byte,
    /// the <see cref="CRYPT_BIT_BLOB"/> structure allows the last byte in the array to contain zero to seven unused bits.
    /// The number of unused bits in the array is contained in the <see cref="cUnusedBits"/> member of this structure.
    /// The number of meaningful bits in the pbData member is calculated with the formula ((cbData × 8) –cUnusedBits).
    /// For example, if you need to represent 10 bits, you would allocate an array of 2 bytes and set <see cref="cUnusedBits"/> to 6.
    /// If you view the array as contiguous bits from left to right, the left 10 bits would be meaningful, and the right 6 bits would be unused.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CRYPT_BIT_BLOB
    {
        /// <summary>
        /// The number of bytes in the <see cref="pbData"/> array.
        /// </summary>
        public DWORD cbData;

        /// <summary>
        /// A pointer to an array of bytes that represents the bits.
        /// </summary>
        public IntPtr pbData;

        /// <summary>
        /// The number of unused bits in the last byte of the array.
        /// The unused bits are always the least significant bits in the last byte of the array.
        /// </summary>
        public DWORD cUnusedBits;
    }
}
