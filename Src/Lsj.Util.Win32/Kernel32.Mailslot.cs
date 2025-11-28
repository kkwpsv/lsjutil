using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FileShareModes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Creates a mailslot with the specified name and returns a handle
        /// that a mailslot server can use to perform operations on the mailslot.
        /// The mailslot is local to the computer that creates it.
        /// An error occurs if a mailslot with the specified name already exists.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-createmailslotw"/>
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// <para>
        /// The name of the mailslot.
        /// This name must have the following form:
        /// </para>
        /// <para>
        /// <c>\\.\mailslot\[path]name</c>
        /// </para>
        /// <para>
        /// The name field must be unique.
        /// The name may include multiple levels of pseudo directories separated by backslashes.
        /// For example, both \\.\mailslot\example_mailslot_name and \\.\mailslot\abc\def\ghi are valid names.
        /// </para>
        /// </param>
        /// <param name="nMaxMessageSize">
        /// The maximum size of a single message that can be written to the mailslot, in bytes.
        /// To specify that the message can be of any size, set this value to zero.
        /// </param>
        /// <param name="lReadTimeout">
        /// <para>
        /// The time a read operation can wait for a message to be written to the mailslot before a time-out occurs, in milliseconds.
        /// The following values have special meanings.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// Returns immediately if no message is present.
        /// (The system does not treat an immediate return as an error.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MAILSLOT_WAIT_FOREVER"/>
        /// </para>
        /// <para>
        /// <c>((DWORD)-1)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Waits forever for a message.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This time-out value applies to all subsequent read operations and all inherited mailslot handles.
        /// </para>
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// The <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member of the structure
        /// determines whether the returned handle can be inherited by child processes.
        /// If <paramref name="lpSecurityAttributes"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the handle cannot be inherited.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the mailslot, for use in server mailslot operations.
        /// The handle returned by this function is asynchronous, or overlapped.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The mailslot exists until one of the following conditions is true:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The last (possibly inherited or duplicated) handle to it is closed using the <see cref="CloseHandle"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The process owning the last (possibly inherited or duplicated) handle exits.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The system uses the second method to destroy mailslots.
        /// </para>
        /// <para>
        /// To write a message to a mailslot, a process uses the <see cref="CreateFile"/> function,
        /// specifying the mailslot name by using one of the following formats.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Format
        /// </term>
        /// <term>
        /// Usage
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <c>\\.\mailslot\name</c>
        /// </term>
        /// <term>
        /// Retrieves a client handle to a local mailslot.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>\\computername\mailslot\name</c>
        /// </term>
        /// <term>
        /// Retrieves a client handle to a remote mailslot.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>\\domainname\mailslot\name</c>
        /// </term>
        /// <term>
        /// Retrieves a client handle to all mailslots with the specified name in the specified domain.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>\\*\mailslot\name</c>
        /// </term>
        /// <term>
        /// Retrieves a client handle to all mailslots with the specified name in the system's primary domain.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <see cref="CreateFile"/> specifies a domain or uses the asterisk format to specify the system's primary domain,
        /// the application cannot write more than 424 bytes at a time to the mailslot.
        /// If the application attempts to do so, the <see cref="WriteFile"/> function fails
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_BAD_NETPATH"/>.
        /// </para>
        /// <para>
        /// An application must specify the <see cref="FILE_SHARE_READ"/> flag
        /// when using <see cref="CreateFile"/> to retrieve a client handle to a mailslot.
        /// </para>
        /// <para>
        /// If <see cref="CreateFile"/> is called to access a non-existent mailslot,
        /// the <see cref="ERROR_FILE_NOT_FOUND"/> error code will be set.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateMailslotW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateMailslot([In] LPCWSTR lpName, [In] DWORD nMaxMessageSize, [In] DWORD lReadTimeout,
            [In] in SECURITY_ATTRIBUTES lpSecurityAttributes);

        /// <summary>
        /// <para>
        /// Sets the time-out value used by the specified mailslot for a read operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setmailslotinfo"/>
        /// </para>
        /// </summary>
        /// <param name="hMailslot">
        /// A handle to a mailslot.
        /// The <see cref="CreateMailslot"/> function must create this handle.
        /// </param>
        /// <param name="lReadTimeout">
        /// <para>
        /// The time a read operation can wait for a message to be written to the mailslot before a time-out occurs, in milliseconds.
        /// The following values have special meanings.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// Returns immediately if no message is present.
        /// (The system does not treat an immediate return as an error.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MAILSLOT_WAIT_FOREVER"/>
        /// </para>
        /// <para>
        /// <c>((DWORD)-1)</c>
        /// </para>
        /// </term>
        /// <term>
        /// Waits forever for a message.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This time-out value applies to all subsequent read operations and to all inherited mailslot handles.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The initial time-out value used by a mailslot for a read operation is typically set
        /// by <see cref="CreateMailslot"/> when the mailslot is created.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMailslotInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetMailslotInfo([In] HANDLE hMailslot, [In] DWORD lReadTimeout);
    }
}
