using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains process mitigation policy settings for user-mode Hardware-enforced Stack Protection (HSP). 
    /// The <see cref="GetProcessMitigationPolicy"/> and <see cref="SetProcessMitigationPolicy"/> functions use this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-process_mitigation_user_shadow_stack_policy"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_MITIGATION_USER_SHADOW_STACK_POLICY
    {
        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// If <see cref="TRUE"/>, user-mode Hardware-enforced Stack Protection is enabled for the process in compatibility mode.
        /// This means that the CPU verifies function return addresses at runtime by employing a shadow stack mechanism, if supported by the hardware.
        /// In compatibility mode, only shadow stack violations occurring in modules that are considered compatible with shadow stacks (CETCOMPAT) are fatal.
        /// For a module to be considered CETCOMPAT, it needs to be either compiled with CETCOMPAT for binaries,
        /// or marked using <see cref="SetProcessDynamicEnforcedCetCompatibleRanges"/> for dynamic code.
        /// This field cannot be changed via <see cref="SetProcessMitigationPolicy"/>.
        /// </summary>
        public DWORD EnableUserShadowStack
        {
            get => Flags & 0x00000001;
            set => Flags |= (value & 0x00000001);
        }

        /// <summary>
        /// If TRUE, shadow stack violations that would have been fatal are instead treated as not fatal and diagnostic events are logged in the Event Log.
        /// When this field is TRUE, <see cref="EnableUserShadowStack"/> must be <see cref="TRUE"/>
        /// and <see cref="EnableUserShadowStackStrictMode"/> may be <see cref="TRUE"/>,
        /// depending on whether compatibility mode is being audited or strict mode is being audited.
        /// This field cannot be changed via <see cref="SetProcessMitigationPolicy"/>.
        /// </summary>
        public DWORD AuditUserShadowStack
        {
            get => (Flags & 0x00000002) >> 1;
            set => Flags |= ((value & 0x00000001) << 1);
        }

        /// <summary>
        /// If TRUE, when calling APIs that modify the execution context of a thread
        /// such as <see cref="SetThreadContext"/> and <see cref="RtlRestoreContext"/>,
        /// validation is performed on the Instruction Pointer specified in the new execution context.
        /// This field cannot be changed via <see cref="SetProcessMitigationPolicy"/>.
        /// </summary>
        public DWORD SetContextIpValidation
        {
            get => (Flags & 0x00000004) >> 2;
            set => Flags |= ((value & 0x00000001) << 2);
        }

        /// <summary>
        /// If <see cref="TRUE"/>, Instruction Pointers that would have caused the validation
        /// to fail are instead allowed and diagnostic events are logged in the Event Log.
        /// When this field is <see cref="TRUE"/>, <see cref="SetContextIpValidation"/> must be <see cref="TRUE"/>
        /// and <see cref="SetContextIpValidationRelaxedMode"/> may be <see cref="TRUE"/>,
        /// depending on which mode the Instruction Pointer validation is currently operating in. 
        /// This field cannot be changed via <see cref="SetProcessMitigationPolicy"/>.
        /// </summary>
        public DWORD AuditSetContextIpValidation
        {
            get => (Flags & 0x00000008) >> 3;
            set => Flags |= ((value & 0x00000001) << 3);
        }

        /// <summary>
        /// If <see cref="TRUE"/>, user-mode Hardware-enforced Stack Protection is enabled for the process in strict mode.
        /// All shadow stack violations are fatal.
        /// When this field is <see cref="TRUE"/>, <see cref="EnableUserShadowStack"/> must be <see cref="TRUE"/>.
        /// If HSP is enabled in compatibility mode, it can be upgraded to strict mode
        /// at runtime by setting this field to <see cref="TRUE"/> and calling <see cref="SetProcessMitigationPolicy"/>.
        /// HSP cannot be downgraded or disabled via <see cref="SetProcessMitigationPolicy"/>.
        /// If HSP is disabled, it cannot be enabled via <see cref="SetProcessMitigationPolicy"/>.
        /// </summary>
        public DWORD EnableUserShadowStackStrictMode
        {
            get => (Flags & 0x0000000c) >> 4;
            set => Flags |= ((value & 0x00000001) << 4);
        }

        /// <summary>
        /// If <see cref="TRUE"/>, binaries that are not compiled with CETCOMPAT are blocked from being loaded into the process.
        /// This policy can be enabled after a process has started by calling <see cref="SetProcessMitigationPolicy"/>.
        /// It cannot be disabled once enabled.
        /// </summary>
        public DWORD BlockNonCetBinaries
        {
            get => (Flags & 0x00000010) >> 5;
            set => Flags |= ((value & 0x00000001) << 5);
        }

        /// <summary>
        /// If TRUE, binaries that are not compiled with CETCOMPAT or do not contain exception handling
        /// continuation metadata (/guard:ehcont) are blocked from being loaded into the process.
        /// When this field is <see cref="TRUE"/>, <see cref="BlockNonCetBinaries"/> must be <see cref="TRUE"/>.
        /// This policy can be enabled after a process has started by calling <see cref="SetProcessMitigationPolicy"/>.
        /// It cannot be disabled or downgraded once enabled.
        /// </summary>
        public DWORD BlockNonCetBinariesNonEhcont
        {
            get => (Flags & 0x00000020) >> 6;
            set => Flags |= ((value & 0x00000001) << 6);
        }

        /// <summary>
        /// If <see cref="TRUE"/>, binary loads that would have been blocked are instead allowed and diagnostic events are logged in the Event Log.
        /// When this field is <see cref="TRUE"/>, <see cref="BlockNonCetBinaries"/> must be <see cref="TRUE"/>
        /// and <see cref="BlockNonCetBinariesNonEhcont"/> may be <see cref="TRUE"/>,
        /// depending on which types of binaries are currently being blocked from being loaded into the process.
        /// This field cannot be changed via <see cref="SetProcessMitigationPolicy"/>.
        /// </summary>
        public DWORD AuditBlockNonCetBinaries
        {
            get => (Flags & 0x00000040) >> 7;
            set => Flags |= ((value & 0x00000001) << 7);
        }

        /// <summary>
        /// If <see cref="TRUE"/>, certain HSP APIs used to specify security properties of dynamic code
        /// can only be called from outside of the process for security purposes.
        /// These APIs are <see cref="SetProcessDynamicEHContinuationTargets"/> and <see cref="SetProcessDynamicEnforcedCetCompatibleRanges"/>.
        /// This policy can be enabled after a process has started by calling <see cref="SetProcessMitigationPolicy"/>.
        /// It cannot be disabled once enabled.
        /// </summary>
        public DWORD CetDynamicApisOutOfProcOnly
        {
            get => (Flags & 0x00000080) >> 8;
            set => Flags |= ((value & 0x00000001) << 8);
        }

        /// <summary>
        /// If <see cref="TRUE"/>, the process's Instruction Pointer validation is downgraded to relaxed mode,
        /// which allows all Instruction Pointers that are in dynamic code or in binaries that do not contain exception handling continuation metadata.
        /// When this field is <see cref="TRUE"/>, <see cref="SetContextIpValidation"/> must be <see cref="TRUE"/>.
        /// The process can be upgraded from relaxed mode to normal mode at runtime
        /// by setting this field to <see cref="FALSE"/> and calling <see cref="SetProcessMitigationPolicy"/>.
        /// </summary>
        public DWORD SetContextIpValidationRelaxedMode
        {
            get => (Flags & 0x000000c0) >> 9;
            set => Flags |= ((value & 0x00000001) << 9);
        }

        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD ReservedFlags
        {
            get => Flags >> 10;
            set => Flags |= (value << 10);
        }
    }
}
