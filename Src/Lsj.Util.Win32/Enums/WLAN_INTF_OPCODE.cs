namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="WLAN_INTF_OPCODE"/> enumerated type defines various opcodes used to set and query parameters on a wireless interface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_intf_opcode-r1"/>
    /// </para>
    /// </summary>
    public enum WLAN_INTF_OPCODE
    {
        /// <summary>
        /// wlan_intf_opcode_autoconf_start
        /// </summary>
        wlan_intf_opcode_autoconf_start = 0x000000000,

        /// <summary>
        /// wlan_intf_opcode_autoconf_enabled
        /// </summary>
        wlan_intf_opcode_autoconf_enabled,

        /// <summary>
        /// wlan_intf_opcode_background_scan_enabled
        /// </summary>
        wlan_intf_opcode_background_scan_enabled,

        /// <summary>
        /// wlan_intf_opcode_media_streaming_mode
        /// </summary>
        wlan_intf_opcode_media_streaming_mode,

        /// <summary>
        /// wlan_intf_opcode_radio_state
        /// </summary>
        wlan_intf_opcode_radio_state,

        /// <summary>
        /// wlan_intf_opcode_bss_type
        /// </summary>
        wlan_intf_opcode_bss_type,

        /// <summary>
        /// wlan_intf_opcode_interface_state
        /// </summary>
        wlan_intf_opcode_interface_state,

        /// <summary>
        /// wlan_intf_opcode_current_connection
        /// </summary>
        wlan_intf_opcode_current_connection,

        /// <summary>
        /// wlan_intf_opcode_channel_number
        /// </summary>
        wlan_intf_opcode_channel_number,

        /// <summary>
        /// wlan_intf_opcode_supported_infrastructure_auth_cipher_pairs
        /// </summary>
        wlan_intf_opcode_supported_infrastructure_auth_cipher_pairs,

        /// <summary>
        /// wlan_intf_opcode_supported_adhoc_auth_cipher_pairs
        /// </summary>
        wlan_intf_opcode_supported_adhoc_auth_cipher_pairs,

        /// <summary>
        /// wlan_intf_opcode_supported_country_or_region_string_list
        /// </summary>
        wlan_intf_opcode_supported_country_or_region_string_list,

        /// <summary>
        /// wlan_intf_opcode_current_operation_mode
        /// </summary>
        wlan_intf_opcode_current_operation_mode,

        /// <summary>
        /// wlan_intf_opcode_supported_safe_mode
        /// </summary>
        wlan_intf_opcode_supported_safe_mode,

        /// <summary>
        /// wlan_intf_opcode_certified_safe_mode
        /// </summary>
        wlan_intf_opcode_certified_safe_mode,

        /// <summary>
        /// wlan_intf_opcode_hosted_network_capable
        /// </summary>
        wlan_intf_opcode_hosted_network_capable,

        /// <summary>
        /// wlan_intf_opcode_management_frame_protection_capable
        /// </summary>
        wlan_intf_opcode_management_frame_protection_capable,

        /// <summary>
        /// wlan_intf_opcode_autoconf_end
        /// </summary>
        wlan_intf_opcode_autoconf_end = 0x0fffffff,

        /// <summary>
        /// wlan_intf_opcode_msm_start
        /// </summary>
        wlan_intf_opcode_msm_start = 0x10000100,

        /// <summary>
        /// wlan_intf_opcode_statistics
        /// </summary>
        wlan_intf_opcode_statistics,

        /// <summary>
        /// wlan_intf_opcode_rssi
        /// </summary>
        wlan_intf_opcode_rssi,

        /// <summary>
        /// wlan_intf_opcode_msm_end
        /// </summary>
        wlan_intf_opcode_msm_end = 0x1fffffff,

        /// <summary>
        /// wlan_intf_opcode_security_start
        /// </summary>
        wlan_intf_opcode_security_start = 0x20010000,

        /// <summary>
        /// wlan_intf_opcode_security_end
        /// </summary>
        wlan_intf_opcode_security_end = 0x2fffffff,

        /// <summary>
        /// wlan_intf_opcode_ihv_start
        /// </summary>
        wlan_intf_opcode_ihv_start = 0x30000000,

        /// <summary>
        /// wlan_intf_opcode_ihv_end
        /// </summary>
        wlan_intf_opcode_ihv_end = 0x3fffffff,
    }
}
