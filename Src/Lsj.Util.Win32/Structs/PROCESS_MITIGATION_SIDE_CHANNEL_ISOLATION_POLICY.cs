using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// This data structure provides the status of process policies that are related to the mitigation of side channels.
    /// This can include side channel attacks involving speculative execution and page combining.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-process_mitigation_side_channel_isolation_policy"/>
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
        /// Prevent branch target pollution cross-SMT-thread in user mode.
        /// </summary>
        public DWORD SmtBranchTargetIsolation
        {
            get => Flags & 0x00000001;
            set => Flags |= (value & 0x00000001);
        }

        /// <summary>
        /// Isolate this process into a distinct security domain, even from other processes running as the same security context.
        /// This prevents branch target injection cross-process.
        /// Page combining is limited to processes within the same security domain.
        /// This flag effectively limits the process to only combining internally to the process itself,
        /// except for common pages and unless further restricted by the <see cref="DisablePageCombine"/> policy.
        /// </summary>
        public DWORD IsolateSecurityDomain
        {
            get => (Flags & 0x00000002) >> 1;
            set => Flags |= ((value & 0x00000001) << 1);
        }

        /// <summary>
        /// Disable all page combining for this process, even internally to the process itself, except for common pages.
        /// </summary>
        public DWORD DisablePageCombine
        {
            get => (Flags & 0x00000004) >> 2;
            set => Flags |= ((value & 0x00000001) << 2);
        }

        /// <summary>
        /// Memory Disambiguation Disable.
        /// </summary>
        public DWORD SpeculativeStoreBypassDisable
        {
            get => (Flags & 0x00000008) >> 3;
            set => Flags |= ((value & 0x00000001) << 3);
        }

        /// <summary>
        /// 
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
