using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DuplicateHandleOptions;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Ktmw32;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Ws2_32;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {

        /// <summary>
        /// <para>
        /// Closes an open object handle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/handleapi/nf-handleapi-closehandle
        /// </para>
        /// </summary>
        /// <param name="hObject">
        /// A valid handle to an open object.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the application is running under a debugger, the function will throw an exception if it receives either a handle value
        /// that is not valid or a pseudo-handle value.
        /// This can happen if you close a handle twice, or if you call <see cref="CloseHandle"/> on a handle returned
        /// by the <see cref="FindFirstFile"/> function instead of calling the <see cref="FindClose"/> function.
        /// </returns>
        /// <remarks>
        /// The CloseHandle function closes handles to the following objects:
        /// Access token, Communications device, Console input, Console screen buffer, Event, File, File mapping, I/O completion port, 
        /// Job, Mailslot, Memory resource notification, Mutex, Named pipe, Pipe, Process, Semaphore, Thread, Transaction, Waitable timer.
        /// The documentation for the functions that create these objects indicates that <see cref="CloseHandle"/> should be used
        /// when you are finished with the object, and what happens to pending operations on the object after the handle is closed.
        /// In general, <see cref="CloseHandle"/> invalidates the specified object handle, decrements the object's handle count,
        /// and performs object retention checks. After the last handle to an object is closed, the object is removed from the system.
        /// For a summary of the creator functions for these objects, see Kernel Objects.
        /// Generally, an application should call <see cref="CloseHandle"/> once for each handle it opens.
        /// It is usually not necessary to call <see cref="CloseHandle"/> if a function that uses a handle
        /// fails with <see cref="ERROR_INVALID_HANDLE"/>, because this error usually indicates that the handle is already invalidated.
        /// However, some functions use <see cref="ERROR_INVALID_HANDLE"/> to indicate that the object itself is no longer valid.
        /// For example, a function that attempts to use a handle to a file on a network might fail
        /// with <see cref="ERROR_INVALID_HANDLE"/> if the network connection is severed,
        /// because the file object is no longer available. In this case, the application should close the handle.
        /// If a handle is transacted, all handles bound to a transaction should be closed before the transaction is committed.
        /// If a transacted handle was opened by calling <see cref="CreateFileTransacted"/> with the <see cref="FILE_FLAG_DELETE_ON_CLOSE"/> flag,
        /// the file is not deleted until the application closes the handle and calls <see cref="CommitTransaction"/>.
        /// For more information about transacted objects, see Working With Transactions.
        /// Closing a thread handle does not terminate the associated thread or remove the thread object.
        /// Closing a process handle does not terminate the associated process or remove the process object.
        /// To remove a thread object, you must terminate the thread, then close all handles to the thread.
        /// For more information, see Terminating a Thread.
        /// To remove a process object, you must terminate the process, then close all handles to the process.
        /// For more information, see Terminating a Process.
        /// Closing a handle to a file mapping can succeed even when there are file views that are still open.
        /// For more information, see Closing a File Mapping Object.
        /// Do not use the <see cref="CloseHandle"/> function to close a socket. Instead, use the <see cref="closesocket"/> function,
        /// which releases all resources associated with the socket including the handle to the socket object.
        /// For more information, see Socket Closure.
        /// Do not use the <see cref="CloseHandle"/> function to close a handle to an open registry key.
        /// Instead, use the <see cref="RegCloseKey"/> function.
        /// <see cref="CloseHandle"/> does not close the handle to the registry key, but does not return an error to indicate this failure.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseHandle", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle([In]IntPtr hObject);

        /// <summary>
        /// <para>
        /// Duplicates an object handle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/handleapi/nf-handleapi-duplicatehandle
        /// </para>
        /// </summary>
        /// <param name="hSourceProcessHandle">
        /// A handle to the process with the handle to be duplicated.
        /// The handle must have the <see cref="PROCESS_DUP_HANDLE"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="hSourceHandle">
        /// The handle to be duplicated.
        /// This is an open object handle that is valid in the context of the source process.
        /// For a list of objects whose handles can be duplicated, see the following Remarks section.
        /// </param>
        /// <param name="hTargetProcessHandle">
        /// A handle to the process that is to receive the duplicated handle.
        /// The handle must have the <see cref="PROCESS_DUP_HANDLE"/> access right.
        /// </param>
        /// <param name="lpTargetHandle">
        /// A pointer to a variable that receives the duplicate handle.
        /// This handle value is valid in the context of the target process.
        /// If <paramref name="hSourceHandle"/> is a pseudo handle returned by <see cref="GetCurrentProcess"/> or <see cref="GetCurrentThread"/>,
        /// <see cref="DuplicateHandle"/> converts it to a real handle to a process or thread, respectively.
        /// If <paramref name="lpTargetHandle"/> is <see langword="null"/>, the function duplicates the handle,
        /// but does not return the duplicate handle value to the caller.
        /// This behavior exists only for backward compatibility with previous versions of this function.
        /// You should not use this feature, as you will lose system resources until the target process terminates.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access requested for the new handle.
        /// For the flags that can be specified for each object type, see the following Remarks section.
        /// This parameter is ignored if the <paramref name="dwOptions"/> parameter specifies the <see cref="DUPLICATE_SAME_ACCESS"/> flag.
        /// Otherwise, the flags that can be specified depend on the type of object whose handle is to be duplicated.
        /// </param>
        /// <param name="bInheritHandle">
        /// A variable that indicates whether the handle is inheritable.
        /// If <see langword="true"/>, the duplicate handle can be inherited by new processes created by the target process.
        /// If <see langword="false"/>, the new handle cannot be inherited.
        /// </param>
        /// <param name="dwOptions">
        /// Optional actions.
        /// This parameter can be zero, or any combination of the following values.
        /// <see cref="DUPLICATE_CLOSE_SOURCE"/>, <see cref="DUPLICATE_SAME_ACCESS"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The duplicate handle refers to the same object as the original handle.
        /// Therefore, any changes to the object are reflected through both handles
        /// . For example, if you duplicate a file handle, the current file position is always the same for both handles.
        /// For file handles to have different file positions, use the <see cref="CreateFile"/> function to
        /// create file handles that share access to the same file.
        /// <see cref="DuplicateHandle"/> can be called by either the source process or the target process
        /// (or a process that is both the source and target process).
        /// For example, a process can use <see cref="DuplicateHandle"/> to create a noninheritable duplicate of an inheritable handle,
        /// or a handle with different access than the original handle.
        /// The source process uses the <see cref="GetCurrentProcess"/> function to get a handle to itself.
        /// This handle is a pseudo handle, but <see cref="DuplicateHandle"/> converts it to a real process handle.
        /// To get the target process handle, it may be necessary to use some form of interprocess communication
        /// (for example, a named pipe or shared memory) to communicate the process identifier to the source process.
        /// The source process can use this identifier in the <see cref="OpenProcess"/> function to obtain a handle to the target process.
        /// If the process that calls <see cref="DuplicateHandle"/> is not also the target process,
        /// the source process must use interprocess communication to pass the value of the duplicate handle to the target process.
        /// <see cref="DuplicateHandle"/> can be used to duplicate a handle between a 32-bit process and a 64-bit process.
        /// The resulting handle is appropriately sized to work in the target process.
        /// For more information, see Process Interoperability.
        /// <see cref="DuplicateHandle"/> can duplicate handles to the following types of objects.
        /// Access token:
        /// The handle is returned by the <see cref="CreateRestrictedToken"/>, <see cref="DuplicateToken"/>, <see cref="DuplicateTokenEx"/>,
        /// <see cref="OpenProcessToken"/>, or <see cref="OpenThreadToken"/> function.
        /// Change notification:
        /// The handle is returned by the <see cref="FindFirstChangeNotification"/> function.
        /// Communications device:
        /// The handle is returned by the <see cref="CreateFile"/> function.
        /// Console input:
        /// The handle is returned by the <see cref="CreateFile"/> function when CONIN$ is specified,
        /// or by the <see cref="GetStdHandle"/> function when <see cref="STD_INPUT_HANDLE"/> is specified.
        /// Console handles can be duplicated for use only in the same process.
        /// Console screen buffer:
        /// The handle is returned by the <see cref="CreateFile"/> function when CONOUT$ is specified,
        /// or by the <see cref="GetStdHandle"/> function when <see cref="STD_OUTPUT_HANDLE"/> is specified.
        /// Console handles can be duplicated for use only in the same process.
        /// Desktop:
        /// The handle is returned by the <see cref="GetThreadDesktop"/> function.
        /// Event:
        /// The handle is returned by the <see cref="CreateEvent"/> or <see cref="OpenEvent"/> function.
        /// File:
        /// The handle is returned by the <see cref="CreateFile"/> function.
        /// File mapping:
        /// The handle is returned by the <see cref="CreateFileMapping"/> function.
        /// Job:
        /// The handle is returned by the <see cref="CreateJobObject"/> function.
        /// Mailslot:
        /// The handle is returned by the <see cref="CreateMailslot"/> function.
        /// Mutex:
        /// The handle is returned by the <see cref="CreateMutex"/> or <see cref="OpenMutex"/> function.
        /// Pipe:
        /// A named pipe handle is returned by the <see cref="CreateNamedPipe"/> or <see cref="CreateFile"/> function.
        /// An anonymous pipe handle is returned by the <see cref="CreatePipe"/> function.
        /// Process:
        /// The handle is returned by the <see cref="CreateProcess"/>, <see cref="GetCurrentProcess"/>, or <see cref="OpenProcess"/> function.
        /// Registry key:
        /// The handle is returned by the <see cref="RegCreateKey"/>, <see cref="RegCreateKeyEx"/>,
        /// <see cref="RegOpenKey"/>, or <see cref="RegOpenKeyEx"/> function.
        /// Note that registry key handles returned by the <see cref="RegConnectRegistry"/> function
        /// cannot be used in a call to <see cref="DuplicateHandle"/>.
        /// Semaphore:
        /// The handle is returned by the <see cref="CreateSemaphore"/> or <see cref="OpenSemaphore"/> function.
        /// Thread:
        /// The handle is returned by the <see cref="CreateProcess"/>, <see cref="CreateThread"/>,
        /// <see cref="CreateRemoteThread"/>, or <see cref="GetCurrentThread"/> function.
        /// Timer:
        /// The handle is returned by the <see cref="CreateWaitableTimer"/> or <see cref="OpenWaitableTimer"/> function.
        /// Transaction:
        /// The handle is returned by the <see cref="CreateTransaction"/> function.
        /// Window station:
        /// The handle is returned by the <see cref="GetProcessWindowStation"/> function.
        /// You should not use <see cref="DuplicateHandle"/> to duplicate handles to the following objects:
        /// I/O completion ports. No error is returned, but the duplicate handle cannot be used.
        /// Sockets. No error is returned, but the duplicate handle may not be recognized by Winsock at the target process.
        /// Also, using <see cref="DuplicateHandle"/> interferes with internal reference counting on the underlying object.
        /// To duplicate a socket handle, use the <see cref="WSADuplicateSocket"/> function.
        /// Pseudo-handles other than the ones returned by the <see cref="GetCurrentProcess"/> or <see cref="GetCurrentThread"/> functions.
        /// The dwDesiredAccess parameter specifies the new handle's access rights. All objects support the standard access rights.
        /// Objects may also support additional access rights depending on the object type.
        /// For more information, see the following topics:
        /// Desktop Security and Access Rights
        /// File Security and Access Rights
        /// File-Mapping Security and Access Rights
        /// Job Object Security and Access Rights
        /// Process Security and Access Rights
        /// Registry Key Security and Access Rights
        /// Synchronization Object Security and Access Rights
        /// Thread Security and Access Rights
        /// Window-Station Security and Access Rights
        /// In some cases, the new handle can have more access rights than the original handle.
        /// However, in other cases, <see cref="DuplicateHandle"/> cannot create a handle with more access rights than the original.
        /// For example, a file handle created with the <see cref="GENERIC_READ"/> access right cannot be duplicated
        /// so that it has both the <see cref="GENERIC_READ"/> and <see cref="GENERIC_WRITE"/> access right.
        /// Normally the target process closes a duplicated handle when that process is finished using the handle.
        /// To close a duplicated handle from the source process, call <see cref="DuplicateHandle"/> with the following parameters:
        /// Set <paramref name="hSourceProcessHandle"/> to the target process from the <see cref="DuplicateHandle"/> call that created the handle.
        /// Set <paramref name="hSourceHandle"/> to the duplicated handle to close.
        /// Set <paramref name="lpTargetHandle"/> to NULL.
        /// Set <paramref name="dwOptions"/> to <see cref="DUPLICATE_CLOSE_SOURCE"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DuplicateHandle", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DuplicateHandle([In]IntPtr hSourceProcessHandle, [In]IntPtr hSourceHandle, [In]IntPtr hTargetProcessHandle,
            [Out]out IntPtr lpTargetHandle, [In]uint dwDesiredAccess, [In]bool bInheritHandle, [In]DuplicateHandleOptions dwOptions);
    }
}
