using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Used to specify values that are used by <see cref="INetworkListManager.SetSimulatedProfileInfo"/> to override current internet connection profile values
    /// in an RDP Child Session to support the simulation of specific metered internet connection conditions.
    /// </para>
    /// <para>
    /// From: https://learn.microsoft.com/en-us/windows/win32/api/netlistmgr/ns-netlistmgr-nlm_simulated_profile_info
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NLM_SIMULATED_PROFILE_INFO
    {
        /// <summary>
        /// Name for the simulated profile.
        /// </summary>
        public ByValStringStructForSize256 ProfileName;

        /// <summary>
        /// The network cost.
        /// Possible values are defined by <see cref="NLM_CONNECTION_COST"/>.
        /// </summary>
        public NLM_CONNECTION_COST cost;

        /// <summary>
        /// The data usage.
        /// </summary>
        public DWORD UsageInMegabytes;

        /// <summary>
        /// The data limit of the plan.
        /// </summary>
        public DWORD DataLimitInMegabytes;
    }
}
