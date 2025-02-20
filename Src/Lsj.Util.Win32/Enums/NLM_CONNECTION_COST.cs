namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="NLM_CONNECTION_COST"/> enumeration specifies a set of cost levels and cost flags supported in Windows 8 Cost APIs.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/netlistmgr/ne-netlistmgr-nlm_connection_cost"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The value returned by the <see cref="INetworkConnectionCost.GetCost"/> method can have multiple bits set with the values specified by this enumeration.
    /// </remarks>
    public enum NLM_CONNECTION_COST
    {
        /// <summary>
        /// The cost is unknown.
        /// </summary>
        NLM_CONNECTION_COST_UNKNOWN = 0,

        /// <summary>
        /// The connection is unlimited and is considered to be unrestricted of usage charges and capacity constraints.
        /// </summary>
        NLM_CONNECTION_COST_UNRESTRICTED = 0x1,

        /// <summary>
        /// The use of this connection is unrestricted up to a specific data transfer limit.
        /// </summary>
        NLM_CONNECTION_COST_FIXED = 0x2,

        /// <summary>
        /// This connection is regulated on a per byte basis.
        /// </summary>
        NLM_CONNECTION_COST_VARIABLE = 0x4,

        /// <summary>
        /// The connection is currently in an OverDataLimit state as it has exceeded the carrier specified data transfer limit.
        /// </summary>
        NLM_CONNECTION_COST_OVERDATALIMIT = 0x10000,

        /// <summary>
        /// The network is experiencing high traffic load and is congested.
        /// </summary>
        NLM_CONNECTION_COST_CONGESTED = 0x20000,

        /// <summary>
        /// The connection is roaming outside the network and affiliates of the home provider.
        /// </summary>
        NLM_CONNECTION_COST_ROAMING = 0x40000,

        /// <summary>
        /// The connection is approaching the data limit specified by the carrier.
        /// </summary>
        NLM_CONNECTION_COST_APPROACHINGDATALIMIT = 0x80000,
    }
}
