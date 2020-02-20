using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CreateEventExFlags;
using static Lsj.Util.Win32.Enums.SynchronizationObjectAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed event object.
        /// To specify an access mask for the object, use the <see cref="CreateEventEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createeventw
        /// </para>
        /// </summary>
        /// <param name="lpEventAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the handle cannot be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new event.
        /// If <paramref name="lpEventAttributes"/> is <see cref="IntPtr.Zero"/>, the event gets a default security descriptor.
        /// The ACLs in the default security descriptor for an event come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="bManualReset">
        /// If this parameter is <see langword="true"/>, the function creates a manual-reset event object,
        /// which requires the use of the <see cref="ResetEvent"/> function to set the event state to nonsignaled.
        /// If this parameter is <see langword="false"/>, the function creates an auto-reset event object,
        /// and system automatically resets the event state to nonsignaled after a single waiting thread has been released.
        /// </param>
        /// <param name="bInitialState">
        /// If this parameter is <see langword="true"/>, the initial state of the event object is signaled; otherwise, it is nonsignaled.
        /// </param>
        /// <param name="lpName">
        /// The name of the event object. The name is limited to <see cref="MAX_PATH"/> characters. Name comparison is case sensitive.
        /// If <paramref name="lpName"/> matches the name of an existing named event object,
        /// this function requests the <see cref="EVENT_ALL_ACCESS"/> access right.
        /// In this case, the <paramref name="bManualReset"/> and <paramref name="bInitialState"/> parameters are ignored
        /// because they have already been set by the creating process.
        /// If the <paramref name="lpEventAttributes"/> parameter is not <see cref="IntPtr.Zero"/>,
        /// it determines whether the handle can be inherited, but its security-descriptor member is ignored.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the event object is created without a name.
        /// If <paramref name="lpName"/> matches the name of another kind of object in the same namespace
        /// (such as an existing semaphore, mutex, waitable timer, job, or file-mapping object),
        /// the function fails and the <see cref="GetLastError"/> function returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace. For more information, see Object Namespaces.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the event object.
        /// If the named event object existed before the function call, the function returns a handle to the existing object
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The handle returned by <see cref="CreateEvent"/> has the <see cref="EVENT_ALL_ACCESS"/> access right;
        /// it can be used in any function that requires a handle to an event object, provided that the caller has been granted access.
        /// If an event is created from a service or a thread that is impersonating a different user,
        /// you can either apply a security descriptor to the event when you create it,
        /// or change the default security descriptor for the creating process by changing its default DACL.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// Any thread of the calling process can specify the event-object handle in a call to one of the wait functions.
        /// The single-object wait functions return when the state of the specified object is signaled.
        /// The multiple-object wait functions can be instructed to return either when any one or when all of the specified objects are signaled.
        /// When a wait function returns, the waiting thread is released to continue its execution.
        /// The initial state of the event object is specified by the <paramref name="bInitialState"/> parameter.
        /// Use the <see cref="SetEvent"/> function to set the state of an event object to signaled.
        /// Use the <see cref="ResetEvent"/> function to reset the state of an event object to nonsignaled.
        /// When the state of a manual-reset event object is signaled, it remains signaled until it is explicitly reset
        /// to nonsignaled by the <see cref="ResetEvent"/> function.
        /// Any number of waiting threads, or threads that subsequently begin wait operations for the specified event object,
        /// can be released while the object's state is signaled.
        /// When the state of an auto-reset event object is signaled, it remains signaled until a single waiting thread is released;
        /// the system then automatically resets the state to nonsignaled.
        /// If no threads are waiting, the event object's state remains signaled.
        /// Multiple processes can have handles of the same event object, enabling use of the object for interprocess synchronization.
        /// The following object-sharing mechanisms are available:
        /// A child process created by the <see cref="CreateProcess"/> function can inherit a handle to an event object
        /// if the <paramref name="lpEventAttributes"/> parameter of <see cref="CreateEvent"/> enabled inheritance.
        /// A process can specify the event-object handle in a call to the <see cref="DuplicateHandle"/> function to create a duplicate handle
        /// that can be used by another process.
        /// A process can specify the name of an event object in a call to the <see cref="OpenEvent"/> or <see cref="CreateEvent"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The event object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEventW", SetLastError = true)]
        public static extern IntPtr CreateEvent(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpEventAttributes, [MarshalAs(UnmanagedType.Bool)][In]bool bManualReset,
            [MarshalAs(UnmanagedType.Bool)][In]bool bInitialState, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed event object and returns a handle to the object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createeventexw
        /// </para>
        /// </summary>
        /// <param name="lpEventAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// If <paramref name="lpEventAttributes"/> is <see langword="null"/>, the event handle cannot be inherited by child processes.
        /// The <paramref name="lpEventAttributes"/> member of the structure specifies a security descriptor for the new event.
        /// If <paramref name="lpEventAttributes"/> is <see langword="null"/>, the event gets a default security descriptor.
        /// The ACLs in the default security descriptor for an event come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="lpName">
        /// The name of the event object. The name is limited to <see cref="MAX_PATH"/> characters. Name comparison is case sensitive.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the event object is created without a name.
        /// If <paramref name="lpName"/> matches the name of another kind of object in the same namespace
        /// (such as an existing semaphore, mutex, waitable timer, job, or file-mapping object),
        /// the function fails and the <see cref="GetLastError"/> function returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace. For more information, see Object Namespaces.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be one or more of the following values.
        /// <see cref="CREATE_EVENT_INITIAL_SET"/>, <see cref="CREATE_EVENT_MANUAL_RESET"/>
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access mask for the event object.
        /// For a list of access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the event object.
        /// If the named event object existed before the function call, the function returns a handle to the existing object
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Any thread of the calling process can specify the event-object handle in a call to one of the wait functions.
        /// The single-object wait functions return when the state of the specified object is signaled.
        /// The multiple-object wait functions can be instructed to return either when any one or when all of the specified objects are signaled.
        /// When a wait function returns, the waiting thread is released to continue its execution.
        /// The initial state of the event object is specified by the <paramref name="dwFlags"/> parameter.
        /// Use the <see cref="SetEvent"/> function to set the state of an event object to signaled.
        /// Use the <see cref="ResetEvent"/> function to reset the state of an event object to nonsignaled.
        /// When the state of a manual-reset event object is signaled, it remains signaled until it is explicitly reset
        /// to nonsignaled by the <see cref="ResetEvent"/> function.
        /// Any number of waiting threads, or threads that subsequently begin wait operations for the specified event object,
        /// can be released while the object's state is signaled.
        /// Multiple processes can have handles of the same event object, enabling use of the object for interprocess synchronization.
        /// The following object-sharing mechanisms are available:
        /// A child process created by the <see cref="CreateProcess"/> function can inherit a handle to an event object
        /// if the <paramref name="lpEventAttributes"/> parameter of <see cref="CreateEvent"/> enabled inheritance.
        /// A process can specify the event-object handle in a call to the <see cref="DuplicateHandle"/> function
        /// to create a duplicate handle that can be used by another process.
        /// A process can specify the name of an event object in a call to the <see cref="OpenEvent"/> or <see cref="CreateEvent"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The event object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEventExW", SetLastError = true)]
        public static extern IntPtr CreateEventEx(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpEventAttributes, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName,
            [In]CreateEventExFlags dwFlags, [In]uint dwDesiredAccess);
    }
}
