using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains process mitigation policy settings for Control Flow Guard (CFG).
    /// The <see cref="GetProcessMitigationPolicy"/> and <see cref="SetProcessMitigationPolicy"/> functions use this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-process_mitigation_control_flow_guard_policy"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_MITIGATION_CONTROL_FLOW_GUARD_POLICY
    {
        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// CFG is enabled for the process if this flag is set.
        /// This field cannot be changed via <see cref="SetProcessMitigationPolicy"/>.
        /// </summary>
        public DWORD EnableControlFlowGuard
        {
            get => Flags & 0x00000001;
            set => Flags |= (value & 0x00000001);
        }

        /// <summary>
        /// If <see cref="TRUE"/>, exported functions will be treated as invalid indirect call targets by default.
        /// Exported functions only become valid indirect call targets if they are dynamically resolved via <see cref="GetProcAddress"/>.
        /// This field cannot be changed via <see cref="SetProcessMitigationPolicy"/>.
        /// </summary>
        public DWORD EnableExportSuppression
        {
            get => (Flags & 0x00000002) >> 1;
            set => Flags |= ((value & 0x00000001) << 1);
        }

        /// <summary>
        /// If <see cref="TRUE"/>, all DLLs that are loaded must enable CFG.
        /// If a DLL does not enable CFG then the image will fail to load.
        /// This policy can be enabled after a process has started by calling <see cref="SetProcessMitigationPolicy"/>.
        /// It cannot be disabled once enabled.
        /// </summary>
        public DWORD StrictMode
        {
            get => (Flags & 0x00000004) >> 2;
            set => Flags |= ((value & 0x00000001) << 2);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD EnableXfg
        {
            get => (Flags & 0x00000008) >> 3;
            set => Flags |= ((value & 0x00000001) << 3);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD EnableXfgAuditMode
        {
            get => (Flags & 0x0000000c) >> 4;
            set => Flags |= ((value & 0x00000001) << 4);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD ReservedFlags
        {
            get => Flags >> 5;
            set => Flags |= (value << 5);
        }
    }
}
