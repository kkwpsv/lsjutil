using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Crypt32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="CERT_INFO"/> structure contains the information of a certificate.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wincrypt/ns-wincrypt-cert_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CERT_INFO
    {
        /// <summary>
        /// Version 1
        /// </summary>
        public const uint CERT_V1 = 0;

        /// <summary>
        /// Version 2
        /// </summary>
        public const uint CERT_V2 = 1;

        /// <summary>
        /// Version 3
        /// </summary>
        public const uint CERT_V3 = 2;

        /// <summary>
        /// The version number of a certificate.
        /// This member can be one of the following version numbers.
        /// <see cref="CERT_V1"/>, <see cref="CERT_V2"/>, <see cref="CERT_V3"/>
        /// </summary>
        public DWORD dwVersion;

        /// <summary>
        /// A BLOB that contains the serial number of a certificate.
        /// The least significant byte is the zero byte of the pbData member of SerialNumber.
        /// The index for the last byte of pbData, is one less than the value of the cbData member of <see cref="SerialNumber"/>.
        /// The most significant byte is the last byte of pbData. Leading 0x00 or 0xFF bytes are removed.
        /// For more information, see <see cref="CertCompareIntegerBlob"/>.
        /// </summary>
        public CRYPT_INTEGER_BLOB SerialNumber;

        /// <summary>
        /// A <see cref="CRYPT_ALGORITHM_IDENTIFIER"/> structure that contains the signature algorithm type and encoded additional encryption parameters.
        /// </summary>
        public CRYPT_ALGORITHM_IDENTIFIER SignatureAlgorithm;

        /// <summary>
        /// The name, in encoded form, of the issuer of the certificate.
        /// </summary>
        public CERT_NAME_BLOB Issuer;

        /// <summary>
        /// Date and time before which the certificate is not valid.
        /// For dates between 1950 and 2049 inclusive, the date and time is encoded Coordinated Universal Time (Greenwich Mean Time) format in the form YYMMDDHHMMSS.
        /// This member uses a two-digit year and is precise to seconds.
        /// For dates before 1950 or after 2049, encoded generalized time is used.
        /// Encoded generalized time is in the form YYYYMMDDHHMMSSMMM, using a four-digit year, and is precise to milliseconds.
        /// Even though generalized time supports millisecond resolution, the NotBefore time is only precise to seconds.
        /// </summary>
        public FILETIME NotBefore;

        /// <summary>
        /// Date and time after which the certificate is not valid.
        /// For dates between 1950 and 2049 inclusive, the date and time is encoded Coordinated Universal Time format in the form YYMMDDHHMMSS.
        /// This member uses a two-digit year and is precise to seconds.
        /// For dates before 1950 or after 2049, encoded generalized time is used.
        /// Encoded generalized time is in the form YYYYMMDDHHMMSSMMM, using a four-digit year, and is precise to milliseconds.
        /// Even though generalized time supports millisecond resolution, the <see cref="NotAfter"/> time is only precise to seconds.
        /// </summary>
        public FILETIME NotAfter;

        /// <summary>
        /// The encoded name of the subject of the certificate.
        /// </summary>
        public CERT_NAME_BLOB Subject;

        /// <summary>
        /// A <see cref="CERT_PUBLIC_KEY_INFO"/> structure that contains the encoded public key and its algorithm.
        /// The <see cref="CERT_PUBLIC_KEY_INFO.PublicKey"/> member of the <see cref="CERT_PUBLIC_KEY_INFO"/> structure
        /// contains the encoded public key as a <see cref="CRYPT_BIT_BLOB"/>,
        /// and the <see cref="CERT_PUBLIC_KEY_INFO.Algorithm"/> member contains the encoded algorithm as a <see cref="CRYPT_ALGORITHM_IDENTIFIER"/>.
        /// </summary>
        public CERT_PUBLIC_KEY_INFO SubjectPublicKeyInfo;

        /// <summary>
        /// A BLOB that contains a unique identifier of the issuer.
        /// </summary>
        public CRYPT_BIT_BLOB IssuerUniqueId;

        /// <summary>
        /// A BLOB that contains a unique identifier of the subject.
        /// </summary>
        public CRYPT_BIT_BLOB SubjectUniqueId;

        /// <summary>
        /// The number of elements in the <see cref="rgExtension"/> array.
        /// </summary>
        public DWORD cExtension;

        /// <summary>
        /// An array of pointers to <see cref="CERT_EXTENSION"/> structures, each of which contains extension information about the certificate.
        /// </summary>
        public P<CERT_EXTENSION> rgExtension;
    }
}
