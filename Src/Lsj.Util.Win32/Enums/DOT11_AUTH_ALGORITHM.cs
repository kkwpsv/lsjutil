namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="DOT11_AUTH_ALGORITHM"/> enumerated type defines a wireless LAN authentication algorithm.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/nativewifi/dot11-auth-algorithm"/>
    /// </para>
    /// </summary>
    public enum DOT11_AUTH_ALGORITHM
    {
        /// <summary>
        /// Specifies an IEEE 802.11 Open System authentication algorithm.
        /// </summary>
        DOT11_AUTH_ALGO_80211_OPEN = 1,

        /// <summary>
        /// Specifies an 802.11 Shared Key authentication algorithm
        /// that requires the use of a pre-shared Wired Equivalent Privacy (WEP) key for the 802.11 authentication.
        /// </summary>
        DOT11_AUTH_ALGO_80211_SHARED_KEY = 2,

        /// <summary>
        /// Specifies a Wi-Fi Protected Access (WPA) algorithm.
        /// IEEE 802.1X port authentication is performed by the supplicant, authenticator, and authentication server.
        /// Cipher keys are dynamically derived through the authentication process.
        /// This algorithm is valid only for BSS types of dot11_BSS_type_infrastructure.
        /// When the WPA algorithm is enabled, the 802.11 station will associate only with an access point
        /// whose beacon or probe responses contain the authentication suite of type 1 (802.1X) within the WPA information element (IE).
        /// </summary>
        DOT11_AUTH_ALGO_WPA = 3,

        /// <summary>
        /// Specifies a WPA algorithm that uses preshared keys (PSK).
        /// IEEE 802.1X port authentication is performed by the supplicant and authenticator.
        /// Cipher keys are dynamically derived through a preshared key that is used on both the supplicant and authenticator.
        /// This algorithm is valid only for BSS types of dot11_BSS_type_infrastructure.
        /// When the WPA PSK algorithm is enabled, the 802.11 station will associate only with an access point whose
        /// beacon or probe responses contain the authentication suite of type 2 (preshared key) within the WPA IE.
        /// </summary>
        DOT11_AUTH_ALGO_WPA_PSK = 4,

        /// <summary>
        /// This value is not supported.
        /// </summary>
        DOT11_AUTH_ALGO_WPA_NONE = 5,

        /// <summary>
        /// Specifies an 802.11i Robust Security Network Association (RSNA) algorithm.
        /// WPA2 is one such algorithm.
        /// IEEE 802.1X port authentication is performed by the supplicant, authenticator, and authentication server.
        /// Cipher keys are dynamically derived through the authentication process.
        /// This algorithm is valid only for BSS types of dot11_BSS_type_infrastructure.
        /// When the RSNA algorithm is enabled, the 802.11 station will associate only with an access point
        /// whose beacon or probe responses contain the authentication suite of type 1 (802.1X) within the RSN IE.
        /// </summary>
        DOT11_AUTH_ALGO_RSNA = 6,

        /// <summary>
        /// Specifies an 802.11i RSNA algorithm that uses PSK.
        /// IEEE 802.1X port authentication is performed by the supplicant and authenticator.
        /// Cipher keys are dynamically derived through a preshared key that is used on both the supplicant and authenticator.
        /// This algorithm is valid only for BSS types of dot11_BSS_type_infrastructure.
        /// When the RSNA PSK algorithm is enabled, the 802.11 station will associate only with an access point
        /// whose beacon or probe responses contain the authentication suite of type 2(preshared key) within the RSN IE.
        /// </summary>
        DOT11_AUTH_ALGO_RSNA_PSK = 7,

        /// <summary>
        /// 
        /// </summary>
        DOT11_AUTH_ALGO_WPA3 = 8,

        /// <summary>
        /// 
        /// </summary>
        DOT11_AUTH_ALGO_WPA3_SAE = 9,

        /// <summary>
        /// 
        /// </summary>
        DOT11_AUTH_ALGO_OWE = 10,

        /// <summary>
        /// Indicates the start of the range that specifies proprietary authentication algorithms that are developed by an IHV.
        /// The <see cref="DOT11_AUTH_ALGO_IHV_START"/> enumerator is valid only when the miniport driver is operating in Extensible Station (ExtSTA) mode.
        /// </summary>
        DOT11_AUTH_ALGO_IHV_START = unchecked((int)0x80000000),

        /// <summary>
        /// Indicates the end of the range that specifies proprietary authentication algorithms that are developed by an IHV.
        /// The <see cref="DOT11_AUTH_ALGO_IHV_END"/> enumerator is valid only when the miniport driver is operating in ExtSTA mode.
        /// </summary>
        DOT11_AUTH_ALGO_IHV_END = unchecked((int)0xffffffff),
    }
}
