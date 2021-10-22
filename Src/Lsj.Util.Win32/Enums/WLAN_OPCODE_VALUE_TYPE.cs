namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="WLAN_OPCODE_VALUE_TYPE"/> enumeration specifies the origin of automatic configuration (auto config) settings.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wlanapi/ne-wlanapi-wlan_opcode_value_type-r1"/>
    /// </para>
    /// </summary>
    public enum WLAN_OPCODE_VALUE_TYPE
    {
        /// <summary>
        /// wlan_opcode_value_type_query_only
        /// </summary>
        wlan_opcode_value_type_query_only = 0,

        /// <summary>
        /// wlan_opcode_value_type_set_by_group_policy
        /// </summary>
        wlan_opcode_value_type_set_by_group_policy,

        /// <summary>
        /// wlan_opcode_value_type_set_by_user
        /// </summary>
        wlan_opcode_value_type_set_by_user,

        /// <summary>
        /// wlan_opcode_value_type_invalid
        /// </summary>
        wlan_opcode_value_type_invalid,
    }
}
