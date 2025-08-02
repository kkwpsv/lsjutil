using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Used to impose restrictions on what system calls can be invoked by a process.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-process_mitigation_system_call_disable_policy"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_MITIGATION_SYSTEM_CALL_DISABLE_POLICY
    {
        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// When set to 1, the process is not permitted to perform GUI system calls.
        /// </summary>
        public DWORD DisallowWin32kSystemCalls
        {
            get => Flags & 0x00000001;
            set => Flags |= (value & 0x00000001);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD AuditDisallowWin32kSystemCalls
        {
            get => (Flags & 0x00000002) >> 1;
            set => Flags |= ((value & 0x00000001) << 1);
        }

        /// <summary>
        /// <para>
        /// When set to 1, the process is not be able to successfully make NtFsControlFile system calls, with the following FsControlCode exceptions.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// FSCTL_IS_VOLUME_MOUNTED
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// FSCTL_PIPE_IMPERSONATE
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// FSCTL_PIPE_LISTEN
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// FSCTL_PIPE_DISCONNECT
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// FSCTL_PIPE_TRANSCEIVE
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// FSCTL_PIPE_WAIT
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// FSCTL_PIPE_GET_PIPE_ATTRIBUTE
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// FSCTL_PIPE_GET_CONNECTION_ATTRIBUTE
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// FSCTL_PIPE_GET_HANDLE_ATTRIBUTE
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// FSCTL_PIPE_PEEK
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// FSCTL_PIPE_EVENT_SELECT
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// FSCTL_PIPE_EVENT_ENUM
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public DWORD DisallowFsctlSystemCalls
        {
            get => (Flags & 0x00000004) >> 2;
            set => Flags |= ((value & 0x00000001) << 2);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD AuditDisallowFsctlSystemCalls
        {
            get => (Flags & 0x00000008) >> 3;
            set => Flags |= ((value & 0x00000008) << 3);
        }

        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD ReservedFlags
        {
            get => Flags >> 4;
            set => Flags |= (value << 4);
        }
    }
}
