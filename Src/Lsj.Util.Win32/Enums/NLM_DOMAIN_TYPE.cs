namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="NLM_DOMAIN_TYPE"/> enumeration is a set of flags that specify the domain type of a network.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/netlistmgr/ne-netlistmgr-nlm_domain_type"/>
    /// </para>
    /// </summary>
    public enum NLM_DOMAIN_TYPE
    {
        /// <summary>
        /// The Network is not an Active Directory Network.
        /// </summary>
        NLM_DOMAIN_TYPE_NON_DOMAIN_NETWORK = 0,

        /// <summary>
        /// The Network is an Active Directory Network, but this machine is not authenticated against it.
        /// </summary>
        NLM_DOMAIN_TYPE_DOMAIN_NETWORK = 0x1,

        /// <summary>
        /// The Network is an Active Directory Network, and this machine is authenticated against it.
        /// </summary>
        NLM_DOMAIN_TYPE_DOMAIN_AUTHENTICATED = 0x2
    }
}
