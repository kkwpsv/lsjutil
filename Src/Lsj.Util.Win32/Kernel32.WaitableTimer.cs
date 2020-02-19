using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// CREATE_WAITABLE_TIMER_MANUAL_RESET
        /// </summary>
        public const uint CREATE_WAITABLE_TIMER_MANUAL_RESET = 1;

        /// <summary>
        /// <para>
        /// Creates or opens a waitable timer object.
        /// To specify an access mask for the object, use the <see cref="CreateWaitableTimerEx"/> function.
        /// </para>
        /// </summary>
        /// <param name="lpTimerAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor
        /// for the new timer object and determines whether child processes can inherit the returned handle.
        /// If <paramref name="lpTimerAttributes"/> is <see langword="null"/>,
        /// the timer object gets a default security descriptor and the handle cannot be inherited.
        /// The ACLs in the default security descriptor for a timer come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="bManualReset">
        /// If this parameter is <see langword="true"/>, the timer is a manual-reset notification timer.
        /// Otherwise, the timer is a synchronization timer.
        /// </param>
        /// <param name="lpTimerName">
        /// The name of the timer object. The name is limited to MAX_PATH characters. Name comparison is case sensitive.
        /// If <param ref="lpTimerName"/> is <see langword="null"/>, the timer object is created without a name.
        /// If <param ref="lpTimerName"/> matches the name of an existing event, semaphore, mutex, job, or file-mapping object,
        /// the function fails and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace.
        /// For more information, see Object Namespaces.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the timer object.
        /// If the named timer object exists before the function call, the function returns a handle to the existing object
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The handle returned by <see cref="CreateWaitableTimer"/> is created with the <see cref="TIMER_ALL_ACCESS"/> access right;
        /// it can be used in any function that requires a handle to a timer object, provided that the caller has been granted access.
        /// If a timer is created from a service or thread that is impersonating a different user,
        /// you can either apply a security descriptor to the timer when you create it,
        /// or change the default security descriptor for the creating process by changing its default DACL.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// Any thread of the calling process can specify the timer object handle in a call to one of the wait functions.
        /// Multiple processes can have handles to the same timer object, enabling use of the object for interprocess synchronization.
        /// A process created by the <see cref="CreateProcess"/> function can inherit a handle to a timer object
        /// if the <paramref name="lpTimerAttributes"/> parameter of <see cref="CreateWaitableTimer"/> enables inheritance.
        /// A process can specify the timer object handle in a call to the <see cref="DuplicateHandle"/> function.
        /// The resulting handle can be used by another process.
        /// A process can specify the name of a timer object in a call
        /// to the <see cref="OpenWaitableTimer"/> or <see cref="CreateWaitableTimer"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The timer object is destroyed when its last handle has been closed.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// To associate a timer with a window, use the <see cref="SetTimer"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWaitableTimerW", SetLastError = true)]
        public static extern IntPtr CreateWaitableTimer(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpTimerAttributes, [In]bool bManualReset,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpTimerName);

        /// <summary>
        /// <para>
        /// Creates or opens a waitable timer object and returns a handle to the object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createwaitabletimerexw
        /// </para>
        /// </summary>
        /// <param name="lpTimerAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor
        /// for the new timer object and determines whether child processes can inherit the returned handle.
        /// If <paramref name="lpTimerAttributes"/> is <see langword="null"/>,
        /// the timer object gets a default security descriptor and the handle cannot be inherited.
        /// The ACLs in the default security descriptor for a timer come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="lpTimerName">
        /// The name of the timer object. The name is limited to MAX_PATH characters. Name comparison is case sensitive.
        /// If <param ref="lpTimerName"/> is <see langword="null"/>, the timer object is created without a name.
        /// If <param ref="lpTimerName"/> matches the name of an existing event, semaphore, mutex, job, or file-mapping object,
        /// the function fails and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace.
        /// For more information, see Object Namespaces.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be 0 or the following value.
        /// <see cref="CREATE_WAITABLE_TIMER_MANUAL_RESET"/>:
        /// The timer must be manually reset. Otherwise, the system automatically resets the timer after releasing a single waiting thread.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access mask for the timer object.
        /// For a list of access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the timer object.
        /// If the named timer object exists before the function call, the function returns a handle to the existing object
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Any thread of the calling process can specify the timer object handle in a call to one of the wait functions.
        /// Multiple processes can have handles to the same timer object, enabling use of the object for interprocess synchronization.
        /// A process created by the <see cref="CreateProcess"/> function can inherit a handle to a timer object
        /// if the <paramref name="lpTimerAttributes"/> parameter of <see cref="CreateWaitableTimer"/> enables inheritance.
        /// A process can specify the timer object handle in a call to the <see cref="DuplicateHandle"/> function.
        /// The resulting handle can be used by another process.
        /// A process can specify the name of a timer object in a call
        /// to the <see cref="OpenWaitableTimer"/> or <see cref="CreateWaitableTimer"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The timer object is destroyed when its last handle has been closed.
        /// To associate a timer with a window, use the <see cref="SetTimer"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWaitableTimerExW", SetLastError = true)]
        public static extern IntPtr CreateWaitableTimerEx(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpTimerAttributes, [MarshalAs(UnmanagedType.LPWStr)][In]string lpTimerName,
            [In]IntPtr dwFlags, [In]IntPtr dwDesiredAccess);
    }
}
