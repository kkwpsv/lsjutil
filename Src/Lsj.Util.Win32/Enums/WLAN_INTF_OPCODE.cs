using static Lsj.Util.Win32.Wlanapi;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Important
    /// </para>
    /// <para>
    /// Some information relates to a prerelease product which may be substantially modified before it's commercially released.
    /// Microsoft makes no warranties, express or implied, with respect to the information provided here.
    /// </para>
    /// <para>
    /// Defines constants that specify various opcodes used to set and query parameters on a wireless interface.
    /// These constants represent the possible opcodes that you can pass in the OpCode parameter
    /// to the <see cref="WlanQueryInterface"/> and <see cref="WlanSetInterface"/> functions to query or set parameters on a wireless interface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_intf_opcode"/>
    /// </para>
    /// </summary>
    public enum WLAN_INTF_OPCODE
    {
        /// <summary>
        /// Not used.
        /// </summary>
        wlan_intf_opcode_autoconf_start = 0x000000000,

        /// <summary>
        /// The opcode used to set or query whether auto config is enabled.
        /// </summary>
        wlan_intf_opcode_autoconf_enabled,

        /// <summary>
        /// <para>
        /// The opcode used to set or query whether background scan is enabled.
        /// </para>
        /// <para>
        /// Background scan can only be disabled when the interface is in the connected state.
        /// Background scan is disabled if at least one client disables it.
        /// </para>
        /// <para>
        /// If the interface gets disconnected, background scan will be enabled automatically.
        /// </para>
        /// </summary>
        wlan_intf_opcode_background_scan_enabled,

        /// <summary>
        /// <para>
        /// The opcode used to set or query the media streaming mode of the driver.
        /// </para>
        /// <para>
        /// The media streaming mode can only be set when the interface is in the connected state.
        /// The media streaming mode is enabled if at least one client enables it.
        /// If the interface gets disconnected, the media streaming mode is disabled automatically
        /// </para>
        /// </summary>
        wlan_intf_opcode_media_streaming_mode,

        /// <summary>
        /// The opcode used to set or query the radio state.
        /// </summary>
        wlan_intf_opcode_radio_state,

        /// <summary>
        /// The opcode used to set or query the BSS type of the interface.
        /// </summary>
        wlan_intf_opcode_bss_type,

        /// <summary>
        /// The opcode used to query the state of the interface.
        /// This opcode can only be used in a query operation with the <see cref="WlanQueryInterface"/> function.
        /// </summary>
        wlan_intf_opcode_interface_state,

        /// <summary>
        /// <para>
        /// The opcode used to query information about the current connection of the interface.
        /// </para>
        /// <para>
        /// This opcode can only be used in a query operation with the <see cref="WlanQueryInterface"/> function.
        /// If the interface is in disconnected or disconnecting state, <see cref="WlanQueryInterface"/> function returns <see cref="ERROR_INVALID_STATE"/>.
        /// </para>
        /// </summary>
        wlan_intf_opcode_current_connection,

        /// <summary>
        /// The opcode used to query the current channel on which the wireless interface is operating.
        /// This opcode can only be used in a query operation with the <see cref="WlanQueryInterface"/> function.
        /// </summary>
        wlan_intf_opcode_channel_number,

        /// <summary>
        /// The opcode used to query the supported auth/cipher pairs for infrastructure mode.
        /// This opcode can only be used in a query operation with the <see cref="WlanQueryInterface"/> function.
        /// </summary>
        wlan_intf_opcode_supported_infrastructure_auth_cipher_pairs,

        /// <summary>
        /// The opcode used to query the supported auth/cipher pairs for ad hoc mode.
        /// This opcode can only be used in a query operation with the <see cref="WlanQueryInterface"/> function.
        /// </summary>
        wlan_intf_opcode_supported_adhoc_auth_cipher_pairs,

        /// <summary>
        /// The opcode used to query the list of supported country or region strings.
        /// This opcode can only be used in a query operation with the <see cref="WlanQueryInterface"/> function.
        /// </summary>
        wlan_intf_opcode_supported_country_or_region_string_list,

        /// <summary>
        /// The opcode used to set or query the current operation mode of the wireless interface.
        /// For more information about operation modes, see Native 802.11 Operation Modes.
        /// </summary>
        wlan_intf_opcode_current_operation_mode,

        /// <summary>
        /// The opcode used to query whether the miniport/NIC combination supports Federal Information Processing Standards (FIPS) mode.
        /// This opcode can only be used in a query operation with the <see cref="WlanQueryInterface"/> function.
        /// FIPS mode is also known as safe mode.
        /// This wireless safe mode is different than the operating system safe mode.
        /// </summary>
        wlan_intf_opcode_supported_safe_mode,

        /// <summary>
        /// The opcode used to query whether the miniport/NIC combination is FIPS certified.
        /// This opcode can only be used in a query operation with the <see cref="WlanQueryInterface"/> function.
        /// </summary>
        wlan_intf_opcode_certified_safe_mode,

        /// <summary>
        /// <para>
        /// The opcode used to query for Hosted Network support in the device driver associated with the Wireless interface.
        /// This opcode can only be used in a query operation with the <see cref="WlanQueryInterface"/> function.
        /// </para>
        /// <para>
        /// The data type returned for this opcode by a query is a Boolean.
        /// A value returned of <see cref="TRUE"/> indicates Hosted Network is supported.
        /// A value of <see cref="FALSE"/> indicates Hosted Network is not supported.
        /// </para>
        /// <para>
        /// This value is an extension to native wireless APIs added to support the wireless Hosted Network
        /// on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
        /// </para>
        /// </summary>
        wlan_intf_opcode_hosted_network_capable,

        /// <summary>
        /// <para>
        /// The opcode used to query whether Management Frame Protection (MFP) is supported
        /// in the device driver associated with the Wireless interface.
        /// This opcode can only be used in a query operation with the <see cref="WlanQueryInterface"/> function.
        /// </para>
        /// <para>
        /// MFP is defined in the IEEE 802.11w-2009 amendment to 802.11 standard.
        /// </para>
        /// <para>
        /// This value is supported on Windows 8 and on Windows Server 2012.
        /// </para>
        /// </summary>
        wlan_intf_opcode_management_frame_protection_capable,

        /// <summary>
        /// Allows clients to query information about the Secondary STA of a given interface.
        /// Returns a <see cref="WLAN_INTERFACE_INFO_LIST"/> of Secondary STAs on the given interface.
        /// </summary>
        wlan_intf_opcode_secondary_sta_interfaces,

        /// <summary>
        /// Opcode used to query whether or not Secondary STA synchronized connections are enabled on the specified interface.
        /// </summary>
        wlan_intf_opcode_secondary_sta_synchronized_connections,

        /// <summary>
        /// <para>
        /// An opcode that allows clients to query attributes that describe the quality of the connection on the given interface.
        /// This API combines fields from various other existing WLAN APIs
        /// (<see cref="wlan_intf_opcode_current_connection"/> and <see cref="WlanGetNetworkBssList"/>),
        /// but it omits location-sensitive information, and for that reason it doesn't require location access privileges.
        /// </para>
        /// <para>
        /// This opcode retrieves a structure that contains attributes that describe the quality of the connection on the given interface.
        /// It will fail if the interface isn't connected.
        /// Your app can use this API to get information about the state and quality of its WiFi connection
        /// (the API has applications to streaming, video conferencing, and other network-quality-sensitive operations.
        /// Apps that currently use <see cref="wlan_intf_opcode_current_connection"/>
        /// and <see cref="WlanGetNetworkBssList"/> to retrieve connection quality information,
        /// but have no desire to request location access, can make use of this API.
        /// </para>
        /// <para>
        /// For more info, see the code example in <see cref="WLAN_REALTIME_CONNECTION_QUALITY"/>.
        /// </para>
        /// </summary>
        wlan_intf_opcode_realtime_connection_quality,

        /// <summary>
        /// <para>
        /// An opcode that allows clients to query the state of the quality-of-service (QoS) features
        /// outlined by the Wi-Fi Alliance's Wi-Fi QoS Management Specification, and defined in the 802.11 spec.
        /// </para>
        /// <para>
        /// This opcode retrieves a structure that contains information about the four features outlined
        /// in the WFA's Wi-Fi QoS Management Specification, and defined in the 802.11 spec.
        /// Your app can use this API to get information about its device's WFA QoS capabilities and,
        /// if connected, the WFA QoS capabilities of its peer and the state of the WFA QoS features configured for its current connection.
        /// An app that currently makes use of the QoS2 or other QoS APIs
        /// can use this to get additional QoS information for performance telemetry or UI display purposes.
        /// Using this API to inform behavior changes isn't its primary purpose.
        /// </para>
        /// <para>
        /// For more info, see the code example in <see cref="WLAN_QOS_INFO"/>.
        /// </para>
        /// </summary>
        wlan_intf_opcode_qos_info,

        /// <summary>
        /// Not used.
        /// </summary>
        wlan_intf_opcode_autoconf_end = 0x0fffffff,

        /// <summary>
        /// Not used.
        /// </summary>
        wlan_intf_opcode_msm_start = 0x10000100,

        /// <summary>
        /// The opcode used to query driver statistics.
        /// This opcode can only be used in a query operation with the <see cref="WlanQueryInterface"/> function.
        /// </summary>
        wlan_intf_opcode_statistics,

        /// <summary>
        /// Opcode used to query the received signal strength.
        /// This opcode can only be used in a query operation with the <see cref="WlanQueryInterface"/> function.
        /// </summary>
        wlan_intf_opcode_rssi,

        /// <summary>
        /// Not used.
        /// </summary>
        wlan_intf_opcode_msm_end = 0x1fffffff,

        /// <summary>
        /// Not used.
        /// </summary>
        wlan_intf_opcode_security_start = 0x20010000,

        /// <summary>
        /// Not used.
        /// </summary>
        wlan_intf_opcode_security_end = 0x2fffffff,

        /// <summary>
        /// Not used.
        /// </summary>
        wlan_intf_opcode_ihv_start = 0x30000000,

        /// <summary>
        /// Not used.
        /// </summary>
        wlan_intf_opcode_ihv_end = 0x3fffffff,
    }
}
