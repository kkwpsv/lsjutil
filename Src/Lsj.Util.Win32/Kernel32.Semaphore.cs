using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SynchronizationObjectAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed semaphore object.
        /// To specify an access mask for the object, use the <see cref="CreateSemaphoreEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createsemaphorew
        /// </para>
        /// </summary>
        /// <param name="lpSemaphoreAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// If this parameter is <see langword="null"/>, the handle cannot be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new semaphore.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the semaphore gets a default security descriptor.
        /// The ACLs in the default security descriptor for a semaphore come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="lInitialCount">
        /// The initial count for the semaphore object.
        /// This value must be greater than or equal to zero and less than or equal to <paramref name="lMaximumCount"/>.
        /// The state of a semaphore is signaled when its count is greater than zero and nonsignaled when it is zero.
        /// The count is decreased by one whenever a wait function releases a thread that was waiting for the semaphore.
        /// The count is increased by a specified amount by calling the <see cref="ReleaseSemaphore"/> function.
        /// </param>
        /// <param name="lMaximumCount">
        /// The maximum count for the semaphore object. This value must be greater than zero.
        /// </param>
        /// <param name="lpName">
        /// The name of the semaphore object.
        /// The name is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// Name comparison is case sensitive.
        /// If <paramref name="lpName"/> matches the name of an existing named semaphore object,
        /// this function requests the <see cref="SEMAPHORE_ALL_ACCESS"/> access right.
        /// In this case, the <paramref name="lInitialCount"/> and <paramref name="lMaximumCount"/> parameters are ignored
        /// because they have already been set by the creating process.
        /// If the <paramref name="lpSemaphoreAttributes"/> parameter is not <see langword="null"/>,
        /// it determines whether the handle can be inherited, but its security-descriptor member is ignored.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the semaphore object is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, mutex, waitable timer, job, or file-mapping object,
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
        /// If the function succeeds, the return value is a handle to the semaphore object.
        /// If the named semaphore object existed before the function call, the function returns a handle to the existing object
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The handle returned by <see cref="CreateSemaphore"/> has the <see cref="SEMAPHORE_ALL_ACCESS"/> access right;
        /// it can be used in any function that requires a handle to a semaphore object, provided that the caller has been granted access.
        /// If an semaphore is created from a service or a thread that is impersonating a different user,
        /// you can either apply a security descriptor to the semaphore when you create it,
        /// or change the default security descriptor for the creating process by changing its default DACL.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// The state of a semaphore object is signaled when its count is greater than zero, and nonsignaled when its count is equal to zero.
        /// The <paramref name="lInitialCount"/> parameter specifies the initial count.
        /// The count can never be less than zero or greater than the value specified in the <paramref name="lMaximumCount"/> parameter.
        /// Any thread of the calling process can specify the semaphore-object handle in a call to one of the wait functions.
        /// The single-object wait functions return when the state of the specified object is signaled.
        /// The multiple-object wait functions can be instructed to return either when any one or when all of the specified objects are signaled.
        /// When a wait function returns, the waiting thread is released to continue its execution.
        /// Each time a thread completes a wait for a semaphore object, the count of the semaphore object is decremented by one.
        /// When the thread has finished, it calls the <see cref="ReleaseSemaphore"/> function, which increments the count of the semaphore object.
        /// Multiple processes can have handles of the same semaphore object, enabling use of the object for interprocess synchronization.
        /// The following object-sharing mechanisms are available:
        /// A child process created by the <see cref="CreateProcess"/> function can inherit a handle to a semaphore object
        /// if the <paramref name="lpSemaphoreAttributes"/> parameter of <see cref="CreateSemaphore"/> enabled inheritance.
        /// A process can specify the semaphore-object handle in a call to the <see cref="DuplicateHandle"/> function
        /// to create a duplicate handle that can be used by another process.
        /// A process can specify the name of a semaphore object in a call to the <see cref="OpenSemaphore"/> or <see cref="CreateSemaphore"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The semaphore object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateSemaphoreW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateSemaphore([In] in SECURITY_ATTRIBUTES lpSemaphoreAttributes, [In] LONG lInitialCount,
            [In] LONG lMaximumCount, [MarshalAs(UnmanagedType.LPWStr)][In] string lpName);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed semaphore object.
        /// To specify an access mask for the object, use the <see cref="CreateSemaphoreEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createsemaphoreexw
        /// </para>
        /// </summary>
        /// <param name="lpSemaphoreAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// If this parameter is <see langword="null"/>, the handle cannot be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new semaphore.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the semaphore gets a default security descriptor.
        /// The ACLs in the default security descriptor for a semaphore come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="lInitialCount">
        /// The initial count for the semaphore object.
        /// This value must be greater than or equal to zero and less than or equal to <paramref name="lMaximumCount"/>.
        /// The state of a semaphore is signaled when its count is greater than zero and nonsignaled when it is zero.
        /// The count is decreased by one whenever a wait function releases a thread that was waiting for the semaphore.
        /// The count is increased by a specified amount by calling the <see cref="ReleaseSemaphore"/> function.
        /// </param>
        /// <param name="lMaximumCount">
        /// The maximum count for the semaphore object. This value must be greater than zero.
        /// </param>
        /// <param name="lpName">
        /// The name of the semaphore object.
        /// The name is limited to <see cref="Constants.MAX_PATH"/> characters.
        /// Name comparison is case sensitive.
        /// If <paramref name="lpName"/> matches the name of an existing named semaphore object,
        /// this function requests the <see cref="SEMAPHORE_ALL_ACCESS"/> access right.
        /// In this case, the <paramref name="lInitialCount"/> and <paramref name="lMaximumCount"/> parameters are ignored
        /// because they have already been set by the creating process.
        /// If the <paramref name="lpSemaphoreAttributes"/> parameter is not <see langword="null"/>,
        /// it determines whether the handle can be inherited, but its security-descriptor member is ignored.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the semaphore object is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, mutex, waitable timer, job, or file-mapping object,
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
        /// This parameter is reserved and must be 0.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access mask for the semaphore object.
        /// For a list of access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the semaphore object.
        /// If the named semaphore object existed before the function call, the function returns a handle to the existing object
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The state of a semaphore object is signaled when its count is greater than zero, and nonsignaled when its count is equal to zero.
        /// The <paramref name="lInitialCount"/> parameter specifies the initial count.
        /// The count can never be less than zero or greater than the value specified in the <paramref name="lMaximumCount"/> parameter.
        /// Any thread of the calling process can specify the semaphore-object handle in a call to one of the wait functions.
        /// The single-object wait functions return when the state of the specified object is signaled.
        /// The multiple-object wait functions can be instructed to return either when any one or when all of the specified objects are signaled.
        /// When a wait function returns, the waiting thread is released to continue its execution.
        /// Each time a thread completes a wait for a semaphore object, the count of the semaphore object is decremented by one.
        /// When the thread has finished, it calls the <see cref="ReleaseSemaphore"/> function, which increments the count of the semaphore object.
        /// Multiple processes can have handles of the same semaphore object, enabling use of the object for interprocess synchronization.
        /// The following object-sharing mechanisms are available:
        /// A child process created by the <see cref="CreateProcess"/> function can inherit a handle to a semaphore object
        /// if the <paramref name="lpSemaphoreAttributes"/> parameter of <see cref="CreateSemaphore"/> enabled inheritance.
        /// A process can specify the semaphore-object handle in a call to the <see cref="DuplicateHandle"/> function
        /// to create a duplicate handle that can be used by another process.
        /// A process can specify the name of a semaphore object in a call to the <see cref="OpenSemaphore"/> or <see cref="CreateSemaphore"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The semaphore object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateSemaphoreExW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateSemaphoreEx([In] in SECURITY_ATTRIBUTES lpSemaphoreAttributes, [In] LONG lInitialCount,
            [In] LONG lMaximumCount, [MarshalAs(UnmanagedType.LPWStr)][In] string lpName, [In] DWORD dwFlags, [In] ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Opens an existing named semaphore object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-opensemaphorew
        /// </para>
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// The access to the semaphore object.
        /// The function fails if the security descriptor of the specified object does not permit the requested access for the calling process.
        /// For a list of access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <param name="bInheritHandle">
        /// If this value is <see cref="TRUE"/>, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="lpName">
        /// The name of the semaphore to be opened. Name comparisons are case sensitive.
        /// This function can open objects in a private namespace. For more information, see Object Namespaces.
        /// Terminal Services:  The name can have a "Global" or "Local" prefix to explicitly open an object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// Note Fast user switching is implemented using Terminal Services sessions.
        /// The first user to log on uses session 0, the next user to log on uses session 1, and so on.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the semaphore object.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="OpenSemaphore"/> function enables multiple processes to open handles of the same semaphore object.
        /// The function succeeds only if some process has already created the semaphore by using the <see cref="CreateSemaphore"/> function.
        /// The calling process can use the returned handle in any function that requires a handle to a semaphore object,
        /// such as the wait functions, subject to the limitations of the access specified in the <paramref name="dwDesiredAccess"/> parameter.
        /// The handle can be duplicated by using the <see cref="DuplicateHandle"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The semaphore object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenSemaphoreW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE OpenSemaphore([In] ACCESS_MASK dwDesiredAccess, [In] BOOL bInheritHandle,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpName);

        /// <summary>
        /// <para>
        /// Increases the count of the specified semaphore object by a specified amount.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-releasesemaphore
        /// </para>
        /// </summary>
        /// <param name="hSemaphore">
        /// A handle to the semaphore object.
        /// The <see cref="CreateSemaphore"/> or <see cref="OpenSemaphore"/> function returns this handle.
        /// This handle must have the <see cref="SEMAPHORE_MODIFY_STATE"/> access right.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <param name="lReleaseCount">
        /// The amount by which the semaphore object's current count is to be increased.
        /// The value must be greater than zero.
        /// If the specified amount would cause the semaphore's count to exceed the maximum count that was specified when the semaphore was created,
        /// the count is not changed and the function returns <see cref="FALSE"/>.
        /// </param>
        /// <param name="lpPreviousCount">
        /// A pointer to a variable to receive the previous count for the semaphore.
        /// This parameter can be <see cref="NULL"/> if the previous count is not required.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The state of a semaphore object is signaled when its count is greater than zero and nonsignaled when its count is equal to zero.
        /// The process that calls the CreateSemaphore function specifies the semaphore's initial count.
        /// Each time a waiting thread is released because of the semaphore's signaled state, the count of the semaphore is decreased by one.
        /// Typically, an application uses a semaphore to limit the number of threads using a resource.
        /// Before a thread uses the resource, it specifies the semaphore handle in a call to one of the wait functions.
        /// When the wait function returns, it decreases the semaphore's count by one.
        /// When the thread has finished using the resource, it calls <see cref="ReleaseSemaphore"/> to increase the semaphore's count by one.
        /// Another use of <see cref="ReleaseSemaphore"/> is during an application's initialization.
        /// The application can create a semaphore with an initial count of zero.
        /// This sets the semaphore's state to nonsignaled and blocks all threads from accessing the protected resource.
        /// When the application finishes its initialization, it uses <see cref="ReleaseSemaphore"/> to increase the count to its maximum value,
        /// to permit normal access to the protected resource.
        /// It is not possible to reduce the semaphore object count using <see cref="ReleaseSemaphore"/>,
        /// because <paramref name="lReleaseCount"/> cannot be a negative number.
        /// To temporarily restrict or reduce access, create a loop in which you call the <see cref="WaitForSingleObject"/> function
        /// with a time-out interval of zero until the semaphore count has been reduced sufficiently.
        /// (Note that other threads can reduce the count while this loop is being executed.)
        /// To restore access, call <see cref="ReleaseSemaphore"/> with the release count equal to the number of times
        /// <see cref="WaitForSingleObject"/> was called in the loop.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseSemaphore", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ReleaseSemaphore([In] HANDLE hSemaphore, [In] LONG lReleaseCount, [Out] out LONG lpPreviousCount);
    }
}
