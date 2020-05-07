namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Cert Encoding Types
    /// </summary>
    public enum CertEncodingTypes : uint
    {
        /// <summary>
        /// CRYPT_ASN_ENCODING
        /// </summary>
        CRYPT_ASN_ENCODING = 0x00000001,

        /// <summary>
        /// CRYPT_NDR_ENCODING
        /// </summary>
        CRYPT_NDR_ENCODING = 0x00000002,

        /// <summary>
        /// X509_ASN_ENCODING
        /// </summary>
        X509_ASN_ENCODING = 0x00000001,

        /// <summary>
        /// X509_NDR_ENCODING
        /// </summary>
        X509_NDR_ENCODING = 0x00000002,

        /// <summary>
        /// PKCS_7_ASN_ENCODING
        /// </summary>
        PKCS_7_ASN_ENCODING = 0x00010000,

        /// <summary>
        /// PKCS_7_NDR_ENCODING
        /// </summary>
        PKCS_7_NDR_ENCODING = 0x00020000,
    }
}
