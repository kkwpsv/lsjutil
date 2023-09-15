namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_TOPOLOGY_ID"/> enumeration specifies the type of display topology.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ne-wingdi-displayconfig_topology_id"/>
    /// </para>
    /// </summary>
    public enum DISPLAYCONFIG_TOPOLOGY_ID
    {
        /// <summary>
        /// Indicates that the display topology is an internal configuration.
        /// </summary>
        DISPLAYCONFIG_TOPOLOGY_INTERNAL = 0x00000001,

        /// <summary>
        /// Indicates that the display topology is clone-view configuration.
        /// </summary>
        DISPLAYCONFIG_TOPOLOGY_CLONE = 0x00000002,

        /// <summary>
        /// Indicates that the display topology is an extended configuration.
        /// </summary>
        DISPLAYCONFIG_TOPOLOGY_EXTEND = 0x00000004,

        /// <summary>
        /// Indicates that the display topology is an external configuration.
        /// </summary>
        DISPLAYCONFIG_TOPOLOGY_EXTERNAL = 0x00000008,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// You should not use this value.
        /// </summary>
        DISPLAYCONFIG_TOPOLOGY_FORCE_UINT32 = unchecked((int)0xFFFFFFFF),
    }
}
