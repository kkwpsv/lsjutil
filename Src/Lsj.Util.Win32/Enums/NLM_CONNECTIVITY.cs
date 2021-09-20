namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="NLM_CONNECTIVITY"/> enumeration is a set of flags that provide notification whenever connectivity related parameters have changed.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/netlistmgr/ne-netlistmgr-nlm_connectivity"/>
    /// </para>
    /// </summary>
    public enum NLM_CONNECTIVITY
    {
        /// <summary>
        /// The underlying network interfaces have no connectivity to any network.
        /// </summary>
        NLM_CONNECTIVITY_DISCONNECTED = 0,

        /// <summary>
        /// There is connectivity to a network, but the service cannot detect any IPv4 Network Traffic.
        /// </summary>
        NLM_CONNECTIVITY_IPV4_NOTRAFFIC = 0x1,

        /// <summary>
        /// There is connectivity to a network, but the service cannot detect any IPv6 Network Traffic.
        /// </summary>
        NLM_CONNECTIVITY_IPV6_NOTRAFFIC = 0x2,

        /// <summary>
        /// There is connectivity to the local subnet using the IPv4 protocol.
        /// </summary>
        NLM_CONNECTIVITY_IPV4_SUBNET = 0x10,

        /// <summary>
        /// There is connectivity to a routed network using the IPv4 protocol.
        /// </summary>
        NLM_CONNECTIVITY_IPV4_LOCALNETWORK = 0x20,

        /// <summary>
        /// There is connectivity to the Internet using the IPv4 protocol.
        /// </summary>
        NLM_CONNECTIVITY_IPV4_INTERNET = 0x40,

        /// <summary>
        /// There is connectivity to the local subnet using the IPv6 protocol.
        /// </summary>
        NLM_CONNECTIVITY_IPV6_SUBNET = 0x100,

        /// <summary>
        /// There is connectivity to a local network using the IPv6 protocol.
        /// </summary>
        NLM_CONNECTIVITY_IPV6_LOCALNETWORK = 0x200,

        /// <summary>
        /// There is connectivity to the Internet using the IPv6 protocol.
        /// </summary>
        NLM_CONNECTIVITY_IPV6_INTERNET = 0x400
    }
}
