using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="CERT_DSS_PARAMETERS"/> structure contains parameters associated with a Digital Signature Standard (DSS) public key algorithm.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_dss_parameters"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CERT_DSS_PARAMETERS
    {
        /// <summary>
        /// Prime modulus P.
        /// The most significant bit of the most significant byte must always be set to 1.
        /// </summary>
        public CRYPT_UINT_BLOB p;

        /// <summary>
        /// Prime Q. It is 20 bytes in length.
        /// The most significant bit of the most significant byte must be set to 1.
        /// </summary>
        public CRYPT_UINT_BLOB q;

        /// <summary>
        /// Generator G.
        /// Must be the same length as <see cref="p"/> (must be padded with 0x00 bytes if it is less).
        /// </summary>
        public CRYPT_UINT_BLOB g;
    }
}
