using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// This data structure provides the status of process policies that are related to the mitigation of side channels.
    /// This can include side channel attacks involving speculative execution and page combining.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-process_mitigation_side_channel_isolation_policy"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_MITIGATION_SIDE_CHANNEL_ISOLATION_POLICY
    {
        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// <para>
        /// If <see cref="TRUE"/> then, while this process is executing in user-mode,
        /// requests the application of hardware mitigations to prevent cross-SMT-thread branch target pollution.
        /// </para>
        /// <para>
        /// If the hardware doesn't provide support for such a mitigation,
        /// or the mitigation has been disabled system-wide, then this policy has no effect.
        /// </para>
        /// <para>
        /// To enable this policy after a process has started, you can call <see cref="SetProcessMitigationPolicy"/>.
        /// It can't be disabled once enabled.
        /// </para>
        /// </summary>
        public DWORD SmtBranchTargetIsolation
        {
            get => Flags & 0x00000001;
            set => Flags |= (value & 0x00000001);
        }

        /// <summary>
        /// <para>
        /// If <see cref="TRUE"/>, isolates this process into a distinct security domain,
        /// even from other processes running as the same security context.
        /// That prevents branch target injection cross-process.
        /// </para>
        /// <para>
        /// Page-combining is limited to processes within the same security domain.
        /// This flag effectively limits the process to only combining internally to the process itself,
        /// except for common pages and unless further restricted by the <see cref="DisablePageCombine"/> policy.
        /// </para>
        /// <para>
        /// To enable this policy after a process has started, you can call <see cref="SetProcessMitigationPolicy"/>.
        /// It can't be disabled once enabled.
        /// </para>
        /// </summary>
        public DWORD IsolateSecurityDomain
        {
            get => (Flags & 0x00000002) >> 1;
            set => Flags |= ((value & 0x00000001) << 1);
        }

        /// <summary>
        /// <para>
        /// If <see cref="TRUE"/>, disables all page-combining for this process,
        /// even internally to the process itself, except for common pages (pages of entirely 0s or entirely 1s).
        /// </para>
        /// <para>
        /// To enable this policy after a process has started, you can call <see cref="SetProcessMitigationPolicy"/>.
        /// It can't be disabled once enabled.
        /// </para>
        /// </summary>
        public DWORD DisablePageCombine
        {
            get => (Flags & 0x00000004) >> 2;
            set => Flags |= ((value & 0x00000001) << 2);
        }

        /// <summary>
        /// <para>
        /// If <see cref="TRUE"/> then, while this process is executing in user-mode,
        /// and in order to mitigate intra-process SSB, requests that hardware mitigations for Speculative Store Bypass (SSB) be enabled.
        /// </para>
        /// <para>
        /// If the hardware doesn't provide support for such a mitigation,
        /// or the mitigation has been disabled system-wide, then this policy has no effect.
        /// </para>
        /// <para>
        /// To enable this policy after a process has started, you can call <see cref="SetProcessMitigationPolicy"/>.
        /// It can't be disabled once enabled.
        /// </para>
        /// </summary>
        public DWORD SpeculativeStoreBypassDisable
        {
            get => (Flags & 0x00000008) >> 3;
            set => Flags |= ((value & 0x00000001) << 3);
        }

        /// <summary>
        /// <para>
        /// If <see cref="TRUE"/>, the CPU scheduler prevents threads within this process
        /// from being scheduled to the same core as threads from another security domain.
        /// </para>
        /// <para>
        /// This policy can't be enabled on systems where the scheduler is incapable of providing this guarantee.
        /// For example, this policy can't be enabled for processes in a virtual machine unless the hypervisor reports the absence of non-architectural core sharing.
        /// </para>
        /// <para>
        /// To enable this policy after a process has started, you can call <see cref="SetProcessMitigationPolicy"/>.
        /// It can't be disabled once enabled.
        /// </para>
        /// </summary>
        public DWORD RestrictCoreSharing
        {
            get => (Flags & 0x0000000c) >> 4;
            set => Flags |= ((value & 0x00000001) << 4);
        }

        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD ReservedFlags
        {
            get => Flags >> 5;
            set => Flags |= (value << 5);
        }
    }
}
