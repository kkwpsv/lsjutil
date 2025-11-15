using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DuplicateHandleOptions;
using static Lsj.Util.Win32.Enums.FileFlags;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.HANDLE_FLAG;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-closehandle"/>
        /// </para>
        /// </summary>
        /// <param name="hObject">
        /// A valid handle to an open object.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If the application is running under a debugger, the function will throw an exception
        /// if it receives either a handle value that is not valid or a pseudo-handle value.
        /// This can happen if you close a handle twice, or if you call <see cref="CloseHandle"/> on a handle
        /// returned by the <see cref="FindFirstFile"/> function instead of calling the <see cref="FindClose"/> function.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CloseHandle"/> function closes handles to the following objects:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Access token
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Communications device
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Console input
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Console screen buffer
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Event
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// File
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// File mapping
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// I/O completion port
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Job
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mailslot
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Memory resource notification
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mutex
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Named pipe
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Pipe
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Process
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Semaphore
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Thread
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Transaction
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Waitable timer
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The documentation for the functions that create these objects indicate
        /// s that <see cref="CloseHandle"/> should be used when you are finished with the object,
        /// and what happens to pending operations on the object after the handle is closed.
        /// In general, <see cref="CloseHandle"/> invalidates the specified object handle,
        /// decrements the object's handle count, and performs object retention checks.
        /// After the last handle to an object is closed, the object is removed from the system.
        /// For a summary of the creator functions for these objects, see Kernel Objects.
        /// </para>
        /// <para>
        /// Generally, an application should call <see cref="CloseHandle"/> once for each handle it opens.
        /// It is usually not necessary to call <see cref="CloseHandle"/> if a function that uses a handle fails with <see cref="ERROR_INVALID_HANDLE"/>,
        /// because this error usually indicates that the handle is already invalidated.
        /// However, some functions use <see cref="ERROR_INVALID_HANDLE"/> to indicate that the object itself is no longer valid.
        /// For example, a function that attempts to use a handle to a file on a network
        /// might fail with <see cref="ERROR_INVALID_HANDLE"/> if the network connection is severed, because the file object is no longer available.
        /// In this case, the application should close the handle.
        /// </para>
        /// <para>
        /// If a handle is transacted, all handles bound to a transaction should be closed before the transaction is committed.
        /// If a transacted handle was opened by calling <see cref="CreateFileTransacted"/> with the <see cref="FILE_FLAG_DELETE_ON_CLOSE"/> flag,
        /// the file is not deleted until the application closes the handle and calls <see cref="CommitTransaction"/>.
        /// For more information about transacted objects, see Working With Transactions.
        /// </para>
        /// <para>
        /// Closing a thread handle does not terminate the associated thread or remove the thread object.
        /// Closing a process handle does not terminate the associated process or remove the process object.
        /// To remove a thread object, you must terminate the thread, then close all handles to the thread.
        /// For more information, see Terminating a Thread.
        /// To remove a process object, you must terminate the process, then close all handles to the process.
        /// For more information, see Terminating a Process.
        /// </para>
        /// <para>
        /// Closing a handle to a file mapping can succeed even when there are file views that are still open.
        /// For more information, see Closing a File Mapping Object.
        /// </para>
        /// <para>
        /// Do not use the <see cref="CloseHandle"/> function to close a socket.
        /// Instead, use the <see cref="closesocket"/> function,
        /// which releases all resources associated with the socket including the handle to the socket object.
        /// For more information, see Socket Closure.
        /// </para>
        /// <para>
        /// Do not use the <see cref="CloseHandle"/> function to close a handle to an open registry key.
        /// Instead, use the <see cref="RegCloseKey"/> function.
        /// <see cref="CloseHandle"/> does not close the handle to the registry key, but does not return an error to indicate this failure.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseHandle", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CloseHandle([In] HANDLE hObject);

        /// <summary>
        /// <para>
        /// Duplicates an object handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-duplicatehandle"/>
        /// </para>
        /// </summary>
        /// <param name="hSourceProcessHandle">
        /// <para>
        /// A handle to the process with the handle to be duplicated.
        /// </para>
        /// <para>
        /// The handle must have the <see cref="PROCESS_DUP_HANDLE"/> access right.
        /// For more information, see Process Security and Access Rights.
        /// </para>
        /// </param>
        /// <param name="hSourceHandle">
        /// <para>
        /// The handle to be duplicated.
        /// This is an open object handle that is valid in the context of the source process.
        /// For a list of objects whose handles can be duplicated, see the following Remarks section.
        /// </para>
        /// <para>
        /// If <paramref name="hSourceHandle"/> is a pseudo handle returned by <see cref="GetCurrentProcess"/> or <see cref="GetCurrentThread"/>,
        /// <paramref name="hSourceProcessHandle"/> should be a handle to the process calling <see cref="DuplicateHandle"/>.
        /// </para>
        /// </param>
        /// <param name="hTargetProcessHandle">
        /// <para>
        /// A handle to the process that is to receive the duplicated handle.
        /// The handle must have the <see cref="PROCESS_DUP_HANDLE"/> access right.
        /// </para>
        /// <para>
        /// This parameter is optional and can be specified as <see cref="NULL"/>
        /// if the <see cref="DUPLICATE_CLOSE_SOURCE"/> flag is set in <paramref name="dwOptions"/>.
        /// </para>
        /// </param>
        /// <param name="lpTargetHandle">
        /// <para>
        /// A pointer to a variable that receives the duplicate handle.
        /// This handle value is valid in the context of the target process.
        /// </para>
        /// <para>
        /// If <paramref name="hSourceHandle"/> is a pseudo handle returned by <see cref="GetCurrentProcess"/> or <see cref="GetCurrentThread"/>,
        /// <see cref="DuplicateHandle"/> converts it to a real handle to a process or thread, respectively.
        /// </para>
        /// <para>
        /// If <paramref name="lpTargetHandle"/> is <see cref="NULL"/>, the function duplicates the handle,
        /// but does not return the duplicate handle value to the caller.
        /// This behavior exists only for backward compatibility with previous versions of this function.
        /// You should not use this feature, as you will lose system resources until the target process terminates.
        /// </para>
        /// <para>
        /// This parameter is ignored if <paramref name="hTargetProcessHandle"/> is <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="dwDesiredAccess">
        /// <para>
        /// The access requested for the new handle.
        /// For the flags that can be specified for each object type, see the following Remarks section.
        /// </para>
        /// <para>
        /// This parameter is ignored if the <paramref name="dwOptions"/> parameter specifies the <see cref="DUPLICATE_SAME_ACCESS"/> flag.
        /// Otherwise, the flags that can be specified depend on the type of object whose handle is to be duplicated.
        /// </para>
        /// <para>
        /// This parameter is ignored if <paramref name="hTargetProcessHandle"/> is <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="bInheritHandle">
        /// <para>
        /// A variable that indicates whether the handle is inheritable.
        /// If <see cref="TRUE"/>, the duplicate handle can be inherited by new processes created by the target process.
        /// If <see cref="FALSE"/>, the new handle cannot be inherited.
        /// </para>
        /// <para>
        /// This parameter is ignored if <paramref name="hTargetProcessHandle"/> is <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="dwOptions">
        /// <para>
        /// Optional actions.
        /// This parameter can be zero, or any combination of the following values.
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
        /// <para>
        /// <see cref="DUPLICATE_CLOSE_SOURCE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Closes the source handle. This occurs regardless of any error status returned.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="DUPLICATE_SAME_ACCESS"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Ignores the <paramref name="dwDesiredAccess"/> parameter.
        /// The duplicate handle has the same access as the source handle.
        /// </term>
        /// </item>
        /// </list>
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
        /// <para>
        /// The duplicate handle refers to the same object as the original handle.
        /// Therefore, any changes to the object are reflected through both handles.
        /// For example, if you duplicate a file handle, the current file position is always the same for both handles.
        /// For file handles to have different file positions,
        /// use the <see cref="CreateFile"/> function to create file handles that share access to the same file.
        /// </para>
        /// <para>
        /// <see cref="DuplicateHandle"/> can be called by either the source process or the target process
        /// (or a process that is both the source and target process).
        /// For example, a process can use <see cref="DuplicateHandle"/> to create a noninheritable duplicate of an inheritable handle,
        /// or a handle with different access than the original handle.
        /// </para>
        /// <para>
        /// The source process uses the <see cref="GetCurrentProcess"/> function to get a handle to itself.
        /// This handle is a pseudo handle, but <see cref="DuplicateHandle"/> converts it to a real process handle.
        /// To get the target process handle, it may be necessary to use some form of interprocess communication
        /// (for example, a named pipe or shared memory) to communicate the process identifier to the source process.
        /// The source process can use this identifier in the <see cref="OpenProcess"/> function to obtain a handle to the target process.
        /// </para>
        /// <para>
        /// If the process that calls <see cref="DuplicateHandle"/> is not also the target process,
        /// the source process must use interprocess communication to pass the value of the duplicate handle to the target process.
        /// </para>
        /// <para>
        /// <see cref="DuplicateHandle"/> can be used to duplicate a handle between a 32-bit process and a 64-bit process.
        /// The resulting handle is appropriately sized to work in the target process.
        /// For more information, see Process Interoperability.
        /// </para>
        /// <para>
        /// <see cref="DuplicateHandle"/> can duplicate handles to the following types of objects.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Object
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Access token
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateRestrictedToken"/>, <see cref="DuplicateToken"/>,
        /// <see cref="DuplicateTokenEx"/>, <see cref="OpenProcessToken"/>, or <see cref="OpenThreadToken"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Change notification
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="FindFirstChangeNotification"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Communications device
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateFile"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Console input
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateFile"/> function when CONIN$ is specified,
        /// or by the <see cref="GetStdHandle"/> function when <see cref="STD_INPUT_HANDLE"/> is specified.
        /// Console handles can be duplicated for use only in the same process.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Console screen buffer
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateFile"/> function when CONOUT$ is specified,
        /// or by the <see cref="GetStdHandle"/> function when <see cref="STD_OUTPUT_HANDLE"/> is specified.
        /// Console handles can be duplicated for use only in the same process.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Desktop
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="GetThreadDesktop"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Event
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateEvent"/> or <see cref="OpenEvent"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// File
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateFile"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// File mapping
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateFileMapping"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Job
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateJobObject"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Mailslot
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateMailslot"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Mutex
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateMutex"/> or <see cref="OpenMutex"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Pipe
        /// </term>
        /// <term>
        /// A named pipe handle is returned by the <see cref="CreateNamedPipe"/> or <see cref="CreateFile"/> function.
        /// An anonymous pipe handle is returned by the <see cref="CreatePipe"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Process
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateProcess"/>, <see cref="GetCurrentProcess"/>, or <see cref="OpenProcess"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Registry key
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="RegCreateKey"/>, <see cref="RegCreateKeyEx"/>,
        /// <see cref="RegOpenKey"/>, or <see cref="RegOpenKeyEx"/> function.
        /// Note that registry key handles returned by the <see cref="RegConnectRegistry"/> function
        /// cannot be used in a call to <see cref="DuplicateHandle"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Semaphore
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateSemaphore"/> or <see cref="OpenSemaphore"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Thread
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateProcess"/>, <see cref="CreateThread"/>,
        /// <see cref="CreateRemoteThread"/>, or <see cref="GetCurrentThread"/> function
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Timer
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateWaitableTimer"/> or <see cref="OpenWaitableTimer"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Transaction
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="CreateTransaction"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Window station
        /// </term>
        /// <term>
        /// The handle is returned by the <see cref="GetProcessWindowStation"/> function.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// You should not use <see cref="DuplicateHandle"/> to duplicate handles to the following objects:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// I/O completion ports.
        /// No error is returned, but the duplicate handle cannot be used.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Sockets.
        /// No error is returned, but the duplicate handle may not be recognized by Winsock at the target process.
        /// Also, using <see cref="DuplicateHandle"/> interferes with internal reference counting on the underlying object.
        /// To duplicate a socket handle, use the <see cref="WSADuplicateSocket"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Pseudo-handles other than the ones returned by the <see cref="GetCurrentProcess"/> or <see cref="GetCurrentThread"/> functions.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <paramref name="dwDesiredAccess"/> parameter specifies the new handle's access rights.
        /// All objects support the standard access rights.
        /// Objects may also support additional access rights depending on the object type.
        /// For more information, see the following topics:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Desktop Security and Access Rights
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// File Security and Access Rights
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// File-Mapping Security and Access Rights
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Job Object Security and Access Rights
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Process Security and Access Rights
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Registry Key Security and Access Rights
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Synchronization Object Security and Access Rights
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Thread Security and Access Rights
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Window-Station Security and Access Rights
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// In some cases, the new handle can have more access rights than the original handle.
        /// However, in other cases, <see cref="DuplicateHandle"/> cannot create a handle with more access rights than the original.
        /// For example, a file handle created with the <see cref="GENERIC_READ"/> access right
        /// cannot be duplicated so that it has both the <see cref="GENERIC_READ"/> and <see cref="GENERIC_WRITE"/> access right.
        /// </para>
        /// <para>
        /// Normally the target process closes a duplicated handle when that process is finished using the handle.
        /// To close a duplicated handle from the source process, call <see cref="DuplicateHandle"/> with the following parameters:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Set <paramref name="hSourceProcessHandle"/> to the target process from the <see cref="DuplicateHandle"/> call that created the handle.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Set <paramref name="hSourceHandle"/> to the duplicated handle to close.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Set <paramref name="hTargetProcessHandle"/> to <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Set <paramref name="dwOptions"/> to <see cref="DUPLICATE_CLOSE_SOURCE"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DuplicateHandle", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DuplicateHandle([In] HANDLE hSourceProcessHandle, [In] HANDLE hSourceHandle, [In] HANDLE hTargetProcessHandle,
            [Out] out HANDLE lpTargetHandle, [In] ACCESS_MASK dwDesiredAccess, [In] BOOL bInheritHandle, [In] DuplicateHandleOptions dwOptions);

        /// <summary>
        /// <para>
        /// Retrieves certain properties of an object handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-gethandleinformation"/>
        /// </para>
        /// </summary>
        /// <param name="hObject">
        /// <para>
        /// A handle to an object whose information is to be retrieved.
        /// </para>
        /// <para>
        /// You can specify a handle to one of the following types of objects: access token, console input buffer,
        /// console screen buffer, event, file, file mapping, job, mailslot, mutex, pipe, printer, process,
        /// registry key, semaphore, serial communication device, socket, thread, or waitable timer.
        /// </para>
        /// </param>
        /// <param name="lpdwFlags">
        /// <para>
        /// A pointer to a variable that receives a set of bit flags that specify properties of the object handle or 0. The following values are defined.
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
        /// <para>
        /// <see cref="HANDLE_FLAG_INHERIT"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, a child process created with the <c>bInheritHandles</c> parameter of <see cref="CreateProcess"/>
        /// set to <see cref="TRUE"/> will inherit the object handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HANDLE_FLAG_PROTECT_FROM_CLOSE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, calling the <see cref="CloseHandle"/> function will not close the object handle.
        /// </term>
        /// </item>
        /// </list>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetHandleInformation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetHandleInformation([In] HANDLE hObject, [Out] out HANDLE_FLAG lpdwFlags);

        /// <summary>
        /// <para>
        /// Sets certain properties of an object handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/handleapi/nf-handleapi-sethandleinformation"/>
        /// </para>
        /// </summary>
        /// <param name="hObject">
        /// <para>
        /// A handle to an object whose information is to be set.
        /// </para>
        /// <para>
        /// You can specify a handle to one of the following types of objects: access token, console input buffer,
        /// console screen buffer, event, file, file mapping, job, mailslot, mutex, pipe, printer, process,
        /// registry key, semaphore, serial communication device, socket, thread, or waitable timer.
        /// </para>
        /// </param>
        /// <param name="dwMask">
        /// A mask that specifies the bit flags to be changed.
        /// Use the same constants shown in the description of <paramref name="dwFlags"/>.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// Set of bit flags that specifies properties of the object handle. This parameter can be 0 or one or more of the following values.
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
        /// <para>
        /// <see cref="HANDLE_FLAG_INHERIT"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, a child process created with the <c>bInheritHandles</c> parameter of <see cref="CreateProcess"/>
        /// set to <see cref="TRUE"/> will inherit the object handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="HANDLE_FLAG_PROTECT_FROM_CLOSE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, calling the <see cref="CloseHandle"/> function will not close the object handle.
        /// </term>
        /// </item>
        /// </list>
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
        /// To set or clear the associated bit flag in <paramref name="dwFlags"/>,
        /// you must set a change mask bit flag in <paramref name="dwMask"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetHandleInformation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetHandleInformation([In] HANDLE hObject, [In] HANDLE_FLAG dwMask, [In] HANDLE_FLAG dwFlags);
    }
}
