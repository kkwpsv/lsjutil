using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="CRYPT_ALGORITHM_IDENTIFIER"/> structure specifies an algorithm used to encrypt a private key.
    /// The structure includes the object identifier (OID) of the algorithm and any needed parameters for that algorithm.
    /// The parameters contained in its <see cref="CRYPT_OBJID_BLOB"/> are encoded.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wincrypt/ns-wincrypt-crypt_algorithm_identifier"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CRYPT_ALGORITHM_IDENTIFIER
    {
        /// <summary>
        /// An OID of an algorithm.
        /// This member can be one of the following values.
        /// This list is only representative.
        /// New algorithms are being defined by various users.
        /// </summary>
        public IntPtr pszObjId;

        /// <summary>
        /// A BLOB that provides encoded algorithm-specific parameters.
        /// In many cases, there are no parameters.
        /// This is indicated by setting the <see cref="CRYPT_OBJID_BLOB.cbData"/> member of the Parameters BLOB to zero.
        /// The following algorithms have the specified encoded parameters.
        /// For more information, see Constants for <see cref="CryptEncodeObject"/> and <see cref="CryptDecodeObject"/>.
        /// szOID_OIWSEC_dsa: A <see cref="CERT_DSS_PARAMETERS"/> structure.
        /// szOID_RSA_RC2CBC: A <see cref="CRYPT_RC2_CBC_PARAMETERS"/> structure.
        /// szOID_OIWSEC_desCBC: A <see cref="CRYPT_DATA_BLOB"/> that contains an initialization vector in the form of an octet string.
        /// szOID_RSA_DES_EDE3_CBC: A <see cref="CRYPT_DATA_BLOB"/> that contains an initialization vector in the form of an octet string.
        /// szOID_RSA_RC4: A <see cref="CRYPT_DATA_BLOB"/> that contains an initialization vector in the form of an octet string.
        /// szOID_RSA_SSA_PSS: A <see cref="CRYPT_RSA_SSA_PSS_PARAMETERS"/> structure.
        /// szOID_ECDSA_SPECIFIED: A <see cref="CRYPT_ALGORITHM_IDENTIFIER"/> structure.
        /// </summary>
        public CRYPT_OBJID_BLOB Parameters;
    }
}
