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
        /// 
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
        /// 
        /// </summary>
        public DWORD ReservedFlags
        {
            get => Flags >> 2;
            set => Flags |= (value << 2);
        }
    }
}
