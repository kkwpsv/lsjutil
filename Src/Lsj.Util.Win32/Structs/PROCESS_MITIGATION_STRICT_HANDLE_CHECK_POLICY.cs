using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Used to impose new behavior on handle references that are not valid.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-process_mitigation_strict_handle_check_policy"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// As a general rule, strict handle checking cannot be turned off once it is turned on.
    /// Therefore, when calling the <see cref="SetProcessMitigationPolicy"/> function with this policy,
    /// the values of the <see cref="RaiseExceptionOnInvalidHandleReference"/> and
    /// <see cref="HandleExceptionsPermanentlyEnabled"/> substructure members must be the same.
    /// It is not possible to enable invalid handle exceptions only temporarily.
    /// The exception to the general rule about strict handle checking always being a permanent state
    /// is that debugging tools such as Application Verifier can cause the operating system to enable invalid handle exceptions temporarily.
    /// Under those cases, it is possible for the <see cref="GetProcessMitigationPolicy"/> function
    /// to return with <see cref="RaiseExceptionOnInvalidHandleReference"/> set to 1, but <see cref="HandleExceptionsPermanentlyEnabled"/> set to 0.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_MITIGATION_STRICT_HANDLE_CHECK_POLICY
    {
        /// <summary>
        /// This member is reserved for system use.
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// 
        /// </summary>
        public DWORD RaiseExceptionOnInvalidHandleReference
        {
            get => Flags & 0x00000001;
            set => Flags |= (value & 0x00000001);
        }

        /// <summary>
        /// 
        /// </summary>
        public DWORD HandleExceptionsPermanentlyEnabled
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
