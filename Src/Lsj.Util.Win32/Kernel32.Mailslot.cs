﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FileShareModes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// MAILSLOT_WAIT_FOREVER
        /// </summary>
        public const uint MAILSLOT_WAIT_FOREVER = unchecked((uint)-1);


        /// <summary>
        /// <para>
        /// Creates a mailslot with the specified name and returns a handle that a mailslot server can use to perform operations on the mailslot.
        /// The mailslot is local to the computer that creates it. An error occurs if a mailslot with the specified name already exists.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-createmailslotw"/>
        /// </para>
        /// </summary>
        /// <param name="lpName">
        /// The name of the mailslot. This name must have the following form:
        /// \.\mailslot[path]name
        /// The name field must be unique. The name may include multiple levels of pseudo directories separated by backslashes.
        /// For example, both \.\mailslot\example_mailslot_name and \.\mailslot\abc\def\ghi are valid names.
        /// </param>
        /// <param name="nMaxMessageSize">
        /// The maximum size of a single message that can be written to the mailslot, in bytes.
        /// To specify that the message can be of any size, set this value to zero.
        /// </param>
        /// <param name="lReadTimeout">
        /// The time a read operation can wait for a message to be written to the mailslot before a time-out occurs, in milliseconds.
        /// The following values have special meanings.
        /// 0: Returns immediately if no message is present. (The system does not treat an immediate return as an error.)
        /// <see cref="MAILSLOT_WAIT_FOREVER"/>: Waits forever for a message.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// The <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member of the structure determines whether the returned handle
        /// can be inherited by child processes.
        /// If <paramref name="lpSecurityAttributes"/> is <see langword="null"/>, the handle cannot be inherited.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the mailslot, for use in server mailslot operations.
        /// The handle returned by this function is asynchronous, or overlapped.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The mailslot exists until one of the following conditions is true:
        /// The last (possibly inherited or duplicated) handle to it is closed using the <see cref="CloseHandle"/> function.
        /// The process owning the last (possibly inherited or duplicated) handle exits.
        /// The system uses the second method to destroy mailslots.
        /// To write a message to a mailslot, a process uses the <see cref="CreateFile"/> function,
        /// specifying the mailslot name by using one of the following formats.
        /// \\.\mailslot\name: Retrieves a client handle to a local mailslot.
        /// \\computername\mailslot\name: Retrieves a client handle to a remote mailslot.
        /// \\domainname\mailslot\name: Retrieves a client handle to all mailslots with the specified name in the specified domain.
        /// \\*\mailslot\name: Retrieves a client handle to all mailslots with the specified name in the system's primary domain.
        /// If <see cref="CreateFile"/> specifies a domain or uses the asterisk format to specify the system's primary domain,
        /// the application cannot write more than 424 bytes at a time to the mailslot.
        /// If the application attempts to do so, the <see cref="WriteFile"/> function fails and
        /// <see cref="GetLastError"/> returns <see cref="ERROR_BAD_NETPATH"/>.
        /// An application must specify the <see cref="FILE_SHARE_READ"/> flag
        /// when using <see cref="CreateFile"/> to retrieve a client handle to a mailslot.
        /// If <see cref="CreateFile"/> is called to access a non-existent mailslot,
        /// the <see cref="ERROR_FILE_NOT_FOUND"/> error code will be set.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateMailslotW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateMailslot([MarshalAs(UnmanagedType.LPWStr)][In] string lpName, [In] DWORD nMaxMessageSize,
            [In] DWORD lReadTimeout, [In] in SECURITY_ATTRIBUTES lpSecurityAttributes);

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
        /// The time a read operation can wait for a message to be written to the mailslot before a time-out occurs, in milliseconds.
        /// The following values have special meanings.
        /// 0: Returns immediately if no message is present. (The system does not treat an immediate return as an error.)
        /// <see cref="MAILSLOT_WAIT_FOREVER"/>: Waits forever for a message.
        /// This time-out value applies to all subsequent read operations and to all inherited mailslot handles.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The initial time-out value used by a mailslot for a read operation is typically set
        /// by <see cref="CreateMailslot"/> when the mailslot is created.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMailslotInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetMailslotInfo([In] HANDLE hMailslot, [In] DWORD lReadTimeout);
    }
}
