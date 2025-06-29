using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The CryptoAPI <see cref="CRYPT_INTEGER_BLOB"/> structure is used for an arbitrary array of bytes.
    /// It is declared in Wincrypt.h and provides flexibility for objects that can contain various data types.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_integer_blob"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CERT_NAME_BLOB
    {
        /// <summary>
        /// The count of bytes in the buffer pointed to by <see cref="pbData"/>.
        /// </summary>
        public DWORD cbData;

        /// <summary>
        /// A pointer to a block of data bytes.
        /// </summary>
        public IntPtr pbData;
    }
}
