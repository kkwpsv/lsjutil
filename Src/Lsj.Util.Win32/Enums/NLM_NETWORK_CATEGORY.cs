namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="NLM_NETWORK_CATEGORY"/> enumeration is a set of flags that specify the category type of a network.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/netlistmgr/ne-netlistmgr-nlm_network_category"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The private or public network categories must never be used to assume which Windows Firewall ports are open,
    /// as the user can change the default settings of these categories.
    /// Instead, Firewall APIs should be called to ensure the ports that the required ports are open.
    /// </remarks>
    public enum NLM_NETWORK_CATEGORY
    {
        /// <summary>
        /// The network is a public (untrusted) network.
        /// </summary>
        NLM_NETWORK_CATEGORY_PUBLIC = 0,

        /// <summary>
        /// The network is a private (trusted) network.
        /// </summary>
        NLM_NETWORK_CATEGORY_PRIVATE = 0x1,

        /// <summary>
        /// The network is authenticated against an Active Directory domain.
        /// </summary>
        NLM_NETWORK_CATEGORY_DOMAIN_AUTHENTICATED = 0x2
    }
}
