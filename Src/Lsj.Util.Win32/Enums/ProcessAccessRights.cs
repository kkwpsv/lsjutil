using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Process Access Rights
    /// The valid access rights for process objects include the standard access rights and some process-specific access rights.
    /// The following table lists the standard access rights used by all objects.
    /// <see cref="DELETE"/>, <see cref="READ_CONTROL"/>, <see cref="SYNCHRONIZE"/>, <see cref="WRITE_DAC"/>, <see cref="WRITE_OWNER"/>
    /// </para>
    /// </summary>
    public enum ProcessAccessRights : uint
    {
        /// <summary>
        /// All possible access rights for a process object.
        /// Windows Server 2003 and Windows XP:
        /// The size of the <see cref="PROCESS_ALL_ACCESS"/> flag increased on Windows Server 2008 and Windows Vista.
        /// If an application compiled for Windows Server 2008 and Windows Vista is run on Windows Server 2003 or Windows XP,
        /// the <see cref="PROCESS_ALL_ACCESS"/> flag is too large and the function specifying this flag fails with <see cref="ERROR_ACCESS_DENIED"/>.
        /// To avoid this problem, specify the minimum set of access rights required for the operation.
        /// If PROCESS_ALL_ACCESS must be used, set _WIN32_WINNT to the minimum operating system targeted by your application
        /// (for example, #define _WIN32_WINNT _WIN32_WINNT_WINXP).
        /// For more information, see Using the Windows Headers.
        /// </summary>
        PROCESS_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFFF,

        /// <summary>
        /// Required to create a process.
        /// </summary>
        PROCESS_CREATE_PROCESS = 0x0080,

        /// <summary>
        /// Required to create a thread.
        /// </summary>
        PROCESS_CREATE_THREAD = 0x0002,

        /// <summary>
        /// Required to duplicate a handle using <see cref="DuplicateHandle"/>.
        /// </summary>
        PROCESS_DUP_HANDLE = 0x0040,

        /// <summary>
        /// Required to retrieve certain information about a process, such as its token, exit code, and priority class (see <see cref="OpenProcessToken"/>).
        /// </summary>
        PROCESS_QUERY_INFORMATION = 0x0400,

        /// <summary>
        /// Required to retrieve certain information about a process (see <see cref="GetExitCodeProcess"/>, <see cref="GetPriorityClass"/>,
        /// <see cref="IsProcessInJob"/>, <see cref="QueryFullProcessImageName"/>).
        /// A handle that has the <see cref="PROCESS_QUERY_INFORMATION"/> access right is automatically granted <see cref="PROCESS_QUERY_LIMITED_INFORMATION"/>.
        /// Windows Server 2003 and Windows XP: This access right is not supported.
        /// </summary>
        PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,

        /// <summary>
        /// Required to set certain information about a process, such as its priority class (see <see cref="SetPriorityClass"/>).
        /// </summary>
        PROCESS_SET_INFORMATION = 0x0200,

        /// <summary>
        /// Required to set memory limits using <see cref="SetProcessWorkingSetSize"/>.
        /// </summary>
        PROCESS_SET_QUOTA = 0x0100,

        /// <summary>
        /// Required to suspend or resume a process.
        /// </summary>
        PROCESS_SUSPEND_RESUME = 0x0800,

        /// <summary>
        /// Required to terminate a process using <see cref="TerminateProcess"/>.
        /// </summary>
        PROCESS_TERMINATE = 0x0001,

        /// <summary>
        /// Required to perform an operation on the address space of a process (see <see cref="VirtualProtectEx"/> and <see cref="WriteProcessMemory"/>).
        /// </summary>
        PROCESS_VM_OPERATION = 0x0008,

        /// <summary>
        /// Required to read memory in a process using <see cref="ReadProcessMemory"/>.
        /// </summary>
        PROCESS_VM_READ = 0x0010,

        /// <summary>
        /// Required to write to memory in a process using <see cref="WriteProcessMemory"/>.
        /// </summary>
        PROCESS_VM_WRITE = 0x0020,

        /// <summary>
        /// Required to wait for the process to terminate using the wait functions.
        /// </summary>
        SYNCHRONIZE = 0x00100000,
    }
}
