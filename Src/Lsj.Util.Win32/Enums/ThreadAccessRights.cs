using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Thread Access Rights
    /// The valid access rights for thread objects include the standard access rights and some thread-specific access rights.
    /// The following table lists the standard access rights used by all objects.
    /// <see cref="DELETE "/>, <see cref="READ_CONTROL"/>, <see cref="SYNCHRONIZE"/>, <see cref="WRITE_DAC"/>, <see cref="WRITE_OWNER"/>
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/procthread/thread-security-and-access-rights"/>
    /// </para>
    /// </summary>
    public enum ThreadAccessRights : uint
    {
        /// <summary>
        /// Enables the use of the thread handle in any of the wait functions.
        /// </summary>
        SYNCHRONIZE = 0x00100000,

        /// <summary>
        /// All possible access rights for a thread object.
        /// Windows Server 2003 and Windows XP:
        /// The value of the <see cref="THREAD_ALL_ACCESS"/> flag increased on Windows Server 2008 and Windows Vista.
        /// If an application compiled for Windows Server 2008 and Windows Vista is run on Windows Server 2003 or Windows XP,
        /// the <see cref="THREAD_ALL_ACCESS"/> flag contains access bits that are not supported
        /// and the function specifying this flag fails with <see cref="ERROR_ACCESS_DENIED"/>.
        /// To avoid this problem, specify the minimum set of access rights required for the operation.
        /// If <see cref="THREAD_ALL_ACCESS"/> must be used, set _WIN32_WINNT to the minimum operating system targeted by your application
        /// (for example, #define _WIN32_WINNT _WIN32_WINNT_WINXP).
        /// For more information, see Using the Windows Headers.
        /// </summary>
        THREAD_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFFF,

        /// <summary>
        /// Required for a server thread that impersonates a client.
        /// </summary>
        THREAD_DIRECT_IMPERSONATION = 0x0200,

        /// <summary>
        /// Required to read the context of a thread using <see cref="GetThreadContext"/>.
        /// </summary>
        THREAD_GET_CONTEXT = 0x0008,

        /// <summary>
        /// Required to use a thread's security information directly without calling it by using a communication mechanism that provides impersonation services.
        /// </summary>
        THREAD_IMPERSONATE = 0x0100,

        /// <summary>
        /// Required to read certain information from the thread object, such as the exit code (see <see cref="GetExitCodeThread"/>).
        /// </summary>
        THREAD_QUERY_INFORMATION = 0x0040,

        /// <summary>
        /// Required to read certain information from the thread objects (see <see cref="GetProcessIdOfThread"/>).
        /// A handle that has the <see cref="THREAD_QUERY_INFORMATION"/> access right is automatically granted <see cref="THREAD_QUERY_LIMITED_INFORMATION"/>.
        /// Windows Server 2003 and Windows XP: This access right is not supported.
        /// </summary>
        THREAD_QUERY_LIMITED_INFORMATION = 0x0800,

        /// <summary>
        /// Required to write the context of a thread using <see cref="SetThreadContext"/>.
        /// </summary>
        THREAD_SET_CONTEXT = 0x0010,

        /// <summary>
        /// Required to set certain information in the thread object.
        /// </summary>
        THREAD_SET_INFORMATION = 0x0020,

        /// <summary>
        /// Required to set certain information in the thread object.
        /// A handle that has the <see cref="THREAD_SET_INFORMATION"/> access right is automatically granted <see cref="THREAD_SET_LIMITED_INFORMATION"/>.
        /// Windows Server 2003 and Windows XP: This access right is not supported.
        /// </summary>
        THREAD_SET_LIMITED_INFORMATION = 0x0400,

        /// <summary>
        /// Required to set the impersonation token for a thread using <see cref="SetThreadToken"/>.
        /// </summary>
        THREAD_SET_THREAD_TOKEN = 0x0080,

        /// <summary>
        /// Required to suspend or resume a thread (see <see cref="SuspendThread"/> and <see cref="ResumeThread"/>).
        /// </summary>
        THREAD_SUSPEND_RESUME = 0x0002,

        /// <summary>
        /// Required to terminate a thread using <see cref="TerminateThread"/>.
        /// </summary>
        THREAD_TERMINATE = 0x0001,
    }
}
