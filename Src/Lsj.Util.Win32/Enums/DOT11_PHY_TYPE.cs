namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="DOT11_PHY_TYPE"/> enumeration defines an 802.11 PHY and media type.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/nativewifi/dot11-phy-type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// An IHV can assign a value for its proprietary PHY types from <see cref="dot11_phy_type_IHV_start"/> through <see cref="dot11_phy_type_IHV_end"/>.
    /// The IHV must assign a unique number from this range for each of its proprietary PHY types.
    /// </remarks>
    public enum DOT11_PHY_TYPE
    {
        /// <summary>
        /// Specifies an unknown or uninitialized PHY type.
        /// </summary>
        dot11_phy_type_unknown = 0,

        /// <summary>
        /// Specifies any PHY type.
        /// </summary>
        dot11_phy_type_any = dot11_phy_type_unknown,

        /// <summary>
        /// Specifies a frequency-hopping spread-spectrum (FHSS) PHY.
        /// Bluetooth devices can use FHSS or an adaptation of FHSS.
        /// </summary>
        dot11_phy_type_fhss = 1,

        /// <summary>
        /// Specifies a direct sequence spread spectrum (DSSS) PHY type.
        /// </summary>
        dot11_phy_type_dsss = 2,

        /// <summary>
        /// Specifies an infrared (IR) baseband PHY type.
        /// </summary>
        dot11_phy_type_irbaseband = 3,

        /// <summary>
        /// Specifies an orthogonal frequency division multiplexing (OFDM) PHY type. 802.11a devices can use OFDM.
        /// </summary>
        dot11_phy_type_ofdm = 4,

        /// <summary>
        /// Specifies a high-rate DSSS (HRDSSS) PHY type.
        /// </summary>
        dot11_phy_type_hrdsss = 5,

        /// <summary>
        /// Specifies an extended rate PHY type (ERP).
        /// 802.11g devices can use ERP.
        /// </summary>
        dot11_phy_type_erp = 6,

        /// <summary>
        /// Specifies the 802.11n PHY type.
        /// </summary>
        dot11_phy_type_ht = 7,

        /// <summary>
        /// Specifies the 802.11ac PHY type.
        /// This is the very high throughput PHY type specified in IEEE 802.11ac.
        /// This value is supported on Windows 8.1, Windows Server 2012 R2, and later.
        /// </summary>
        dot11_phy_type_vht = 8,

        /// <summary>
        /// 
        /// </summary>
        dot11_phy_type_dmg = 9,

        /// <summary>
        /// 
        /// </summary>
        dot11_phy_type_he = 10,

        /// <summary>
        /// Specifies the start of the range that is used to define PHY types that are developed by an independent hardware vendor (IHV).
        /// </summary>
        dot11_phy_type_IHV_start = unchecked((int)0x80000000),

        /// <summary>
        /// Specifies the start of the range that is used to define PHY types that are developed by an independent hardware vendor (IHV).
        /// </summary>
        dot11_phy_type_IHV_end = unchecked((int)0xffffffff),
    }
}
