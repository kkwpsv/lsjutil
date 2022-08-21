using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains process mitigation policy settings for restricting dynamic code generation and modification.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-process_mitigation_dynamic_code_policy"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_MITIGATION_DYNAMIC_CODE_POLICY
    {
        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// Set (0x1) to prevent the process from generating dynamic code or modifying existing executable code; otherwise leave unset (0x0).
        /// </summary>
        public DWORD ProhibitDynamicCode
        {
            get => Flags & 0x00000001;
            set => Flags |= (value & 0x00000001);
        }

        /// <summary>
        /// Set (0x1) to allow threads to opt out of the restrictions on dynamic code generation
        /// by calling the <see cref="SetThreadInformation"/> function with the ThreadInformation parameter set to ThreadDynamicCodePolicy;
        /// otherwise leave unset (0x0).
        /// You should not use the <see cref="AllowThreadOptOut"/> and ThreadDynamicCodePolicy settings together to provide strong security.
        /// These settings are only intended to enable applications to adapt their code more easily for full dynamic code restrictions.
        /// </summary>
        public DWORD AllowThreadOptOut
        {
            get => (Flags & 0x00000002) >> 1;
            set => Flags |= ((value & 0x00000001) << 1);
        }

        /// <summary>
        /// Set (0x1) to allow non-AppContainer processes to modify all of the dynamic code settings for the calling process,
        /// including relaxing dynamic code restrictions after they have been set.
        /// </summary>
        public DWORD AllowRemoteDowngrade
        {
            get => (Flags & 0x00000004) >> 2;
            set => Flags |= ((value & 0x00000001) << 2);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD AuditProhibitDynamicCode
        {
            get => (Flags & 0x00000008) >> 3;
            set => Flags |= ((value & 0x00000001) << 3);
        }

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        public DWORD ReservedFlags
        {
            get => Flags >> 4;
            set => Flags |= (value << 4);
        }
    }
}
