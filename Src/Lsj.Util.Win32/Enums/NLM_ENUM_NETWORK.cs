namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="NLM_ENUM_NETWORK"/> enumeration contains a set of flags that specify what types of networks are enumerated.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/netlistmgr/ne-netlistmgr-nlm_enum_network"/>
    /// </para>
    /// </summary>
    public enum NLM_ENUM_NETWORK
    {
        /// <summary>
        /// Returns connected networks
        /// </summary>
        NLM_ENUM_NETWORK_CONNECTED = 0x1,

        /// <summary>
        /// Returns disconnected networks
        /// </summary>
        NLM_ENUM_NETWORK_DISCONNECTED = 0x2,

        /// <summary>
        /// Returns connected and disconnected networks
        /// </summary>
        NLM_ENUM_NETWORK_ALL = 0x3
    }
}
