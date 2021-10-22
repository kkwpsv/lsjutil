namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// he <see cref="DOT11_CIPHER_ALGORITHM"/> enumerated type defines a cipher algorithm for data encryption and decryption.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/nativewifi/dot11-cipher-algorithm"/>
    /// </para>
    /// </summary>
    public enum DOT11_CIPHER_ALGORITHM
    {
        /// <summary>
        /// Specifies that no cipher algorithm is enabled or supported.
        /// </summary>
        DOT11_CIPHER_ALGO_NONE = 0x00,

        /// <summary>
        /// Specifies a Wired Equivalent Privacy (WEP) algorithm, which is the RC4-based algorithm that is specified in the 802.11-1999 standard.
        /// This enumerator specifies the WEP cipher algorithm with a 40-bit cipher key.
        /// </summary>
        DOT11_CIPHER_ALGO_WEP40 = 0x01,

        /// <summary>
        /// Specifies a Temporal Key Integrity Protocol (TKIP) algorithm, which is the RC4-based cipher suite
        /// that is based on the algorithms that are defined in the WPA specification and IEEE 802.11i-2004 standard.
        /// This cipher also uses the Michael Message Integrity Code (MIC) algorithm for forgery protection.
        /// </summary>
        DOT11_CIPHER_ALGO_TKIP = 0x02,

        /// <summary>
        /// Specifies an AES-CCMP algorithm, as specified in the IEEE 802.11i-2004 standard and RFC 3610.
        /// Advanced Encryption Standard (AES) is the encryption algorithm defined in FIPS PUB 197.
        /// </summary>
        DOT11_CIPHER_ALGO_CCMP = 0x04,

        /// <summary>
        /// Specifies a WEP cipher algorithm with a 104-bit cipher key.
        /// </summary>
        DOT11_CIPHER_ALGO_WEP104 = 0x05,

        /// <summary>
        /// 
        /// </summary>
        DOT11_CIPHER_ALGO_BIP = 0x06,

        /// <summary>
        /// 
        /// </summary>
        DOT11_CIPHER_ALGO_GCMP = 0x08,

        /// <summary>
        /// 
        /// </summary>
        DOT11_CIPHER_ALGO_GCMP_256 = 0x09,

        /// <summary>
        /// 
        /// </summary>
        DOT11_CIPHER_ALGO_CCMP_256 = 0x0a,

        /// <summary>
        /// 
        /// </summary>
        DOT11_CIPHER_ALGO_BIP_GMAC_128 = 0x0b,

        /// <summary>
        /// 
        /// </summary>
        DOT11_CIPHER_ALGO_BIP_GMAC_256 = 0x0c,

        /// <summary>
        /// 
        /// </summary>
        DOT11_CIPHER_ALGO_BIP_CMAC_256 = 0x0d,

        /// <summary>
        /// Specifies a Wi-Fi Protected Access (WPA) Use Group Key cipher suite.
        /// For more information about the Use Group Key cipher suite, refer to Clause 7.3.2.25.1 of the IEEE 802.11i-2004 standard.
        /// </summary>
        DOT11_CIPHER_ALGO_WPA_USE_GROUP = 0x100,

        /// <summary>
        /// Specifies a Robust Security Network (RSN) Use Group Key cipher suite.
        /// For more information about the Use Group Key cipher suite, refer to Clause 7.3.2.25.1 of the IEEE 802.11i-2004 standard.
        /// </summary>
        DOT11_CIPHER_ALGO_RSN_USE_GROUP = 0x100,

        /// <summary>
        /// Specifies a WEP cipher algorithm with a cipher key of any length.
        /// </summary>
        DOT11_CIPHER_ALGO_WEP = 0x101,

        /// <summary>
        /// Specifies the start of the range that is used to define proprietary cipher algorithms that are developed by an independent hardware vendor (IHV).
        /// </summary>
        DOT11_CIPHER_ALGO_IHV_START = unchecked((int)0x80000000),

        /// <summary>
        /// Specifies the end of the range that is used to define proprietary cipher algorithms that are developed by an IHV.
        /// </summary>
        DOT11_CIPHER_ALGO_IHV_END = unchecked((int)0xffffffff),
    }
}
