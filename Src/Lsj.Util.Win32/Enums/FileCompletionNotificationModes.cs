using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// File Completion Notification Modes
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setfilecompletionnotificationmodes"/>
    /// </para>
    /// </summary>
    public enum FileCompletionNotificationModes : byte
    {
        /// <summary>
        /// If the following three conditions are true, the I/O Manager does not queue a completion entry to the port, when it would ordinarily do so.
        /// The conditions are:
        /// A completion port is associated with the file handle.
        /// The file is opened for asynchronous I/O.
        /// A request returns success immediately without returning ERROR_PENDING.
        /// When the FileHandle parameter is a socket, this mode is only compatible with Layered Service Providers (LSP)
        /// that return Installable File Systems (IFS) handles.
        /// To detect whether a non-IFS LSP is installed, use the <see cref="WSAEnumProtocols"/> function
        /// and examine the <see cref="WSAPROTOCOL_INFO.dwServiceFlag1"/> member in each returned <see cref="WSAPROTOCOL_INFO"/> structure.
        /// If the <see cref="XP1_IFS_HANDLES"/> (0x20000) bit is cleared then the specified LSP is not an IFS LSP.
        /// Vendors that have non-IFS LSPs are encouraged to migrate to the Windows Filtering Platform (WFP).
        /// </summary>
        FILE_SKIP_COMPLETION_PORT_ON_SUCCESS = 1,

        /// <summary>
        /// The I/O Manager does not set the event for the file object if a request returns with a success code,
        /// or the error returned is <see cref="ERROR_IO_PENDING"/> and the function that is called is not a synchronous function.
        /// If an explicit event is provided for the request, it is still signaled.
        /// </summary>
        FILE_SKIP_SET_EVENT_ON_HANDLE = 2,
    }
}
