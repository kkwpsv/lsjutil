using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SynchronizationObjectAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// CREATE_MUTEX_INITIAL_OWNER
        /// </summary>
        public const uint CREATE_MUTEX_INITIAL_OWNER = 1;

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed mutex object.
        /// To specify an access mask for the object, use the <see cref="CreateMutexEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createmutexw
        /// </para>
        /// </summary>
        /// <param name="lpMutexAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// If this parameter is <see langword="null"/>, the handle cannot be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new mutex.
        /// If <paramref name="lpMutexAttributes"/> is <see langword="null"/>, the mutex gets a default security descriptor.
        /// The ACLs in the default security descriptor for a mutex come from the primary or impersonation token of the creator.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <param name="bInitialOwner">
        /// If this value is <see langword="true"/> and the caller created the mutex, the calling thread obtains initial ownership of the mutex object.
        /// Otherwise, the calling thread does not obtain ownership of the mutex.
        /// To determine if the caller created the mutex, see the Return Values section.
        /// </param>
        /// <param name="lpName">
        /// The name of the mutex object. The name is limited to <see cref="MAX_PATH"/> characters. Name comparison is case sensitive.
        /// If <paramref name="lpName"/> matches the name of an existing named mutex object,
        /// this function requests the <see cref="MUTEX_ALL_ACCESS"/> access right.
        /// In this case, the <paramref name="bInitialOwner"/> parameter is ignored because it has already been set by the creating process.
        /// If the <paramref name="lpMutexAttributes"/> parameter is not <see langword="null"/>, it determines whether the handle can be inherited,
        /// but its security-descriptor member is ignored.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the mutex object is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, semaphore, waitable timer, job, or file-mapping object,
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
        /// If the function succeeds, the return value is a handle to the newly created mutex object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the mutex is a named mutex and the object existed before this function call,
        /// the return value is a handle to the existing object, <see cref="OpenMutex"/> function.
        /// </returns>
        /// <remarks>
        /// The handle returned by <see cref="CreateMutex"/> has the <see cref="MUTEX_ALL_ACCESS"/> access right;
        /// it can be used in any function that requires a handle to a mutex object, provided that the caller has been granted access.
        /// If a mutex is created from a service or a thread that is impersonating a different user,
        /// you can either apply a security descriptor to the mutex when you create it,
        /// or change the default security descriptor for the creating process by changing its default DACL.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// If you are using a named mutex to limit your application to a single instance, a malicious user can create this mutex 
        /// before you do and prevent your application from starting.
        /// To prevent this situation, create a randomly named mutex and store the name so that it can only be obtained by an authorized user.
        /// Alternatively, you can use a file for this purpose.
        /// To limit your application to one instance per user, create a locked file in the user's profile directory.
        /// Any thread of the calling process can specify the mutex-object handle in a call to one of the wait functions.
        /// The single-object wait functions return when the state of the specified object is signaled.
        /// The multiple-object wait functions can be instructed to return either when any one or when all of the specified objects are signaled.
        /// When a wait function returns, the waiting thread is released to continue its execution.
        /// The state of a mutex object is signaled when it is not owned by any thread.
        /// The creating thread can use the <paramref name="bInitialOwner"/> flag to request immediate ownership of the mutex.
        /// Otherwise, a thread must use one of the wait functions to request ownership.
        /// When the mutex's state is signaled, one waiting thread is granted ownership,
        /// the mutex's state changes to nonsignaled, and the wait function returns.
        /// Only one thread can own a mutex at any given time
        /// . The owning thread uses the ReleaseMutex function to release its ownership.
        /// The thread that owns a mutex can specify the same mutex in repeated wait function calls without blocking its execution.
        /// Typically, you would not wait repeatedly for the same mutex,
        /// but this mechanism prevents a thread from deadlocking itself while waiting for a mutex that it already owns.
        /// However, to release its ownership, the thread must call <see cref="ReleaseMutex"/> once for each time that the mutex satisfied a wait.
        /// Two or more processes can call <see cref="CreateMutex"/> to create the same named mutex.
        /// The first process actually creates the mutex, and subsequent processes with sufficient access rights simply open a handle to the existing mutex.
        /// This enables multiple processes to get handles of the same mutex,
        /// while relieving the user of the responsibility of ensuring that the creating process is started first.
        /// When using this technique, you should set the <paramref name="bInitialOwner"/> flag to FALSE;
        /// otherwise, it can be difficult to be certain which process has initial ownership.
        /// Multiple processes can have handles of the same mutex object, enabling use of the object for interprocess synchronization.
        /// The following object-sharing mechanisms are available:
        /// A child process created by the <see cref="CreateProcess"/> function can inherit a handle to a mutex object
        /// if the <paramref name="lpMutexAttributes"/> parameter of <see cref="CreateMutex"/> enabled inheritance.
        /// This mechanism works for both named and unnamed mutexes.
        /// A process can specify the handle to a mutex object in a call to the <see cref="DuplicateHandle"/> function
        /// to create a duplicate handle that can be used by another process.
        /// This mechanism works for both named and unnamed mutexes.
        /// A process can specify a named mutex in a call to the <see cref="OpenMutex"/>
        /// or <see cref="CreateMutex"/> function to retrieve a handle to the mutex object.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The mutex object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateMutexW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateMutex([In]in SECURITY_ATTRIBUTES lpMutexAttributes, [In]BOOL bInitialOwner,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpName);

        /// <summary>
        /// <para>
        /// Creates or opens a named or unnamed mutex object and returns a handle to the object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createmutexexw
        /// </para>
        /// </summary>
        /// <param name="lpMutexAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// If this parameter is <see langword="null"/>, the handle cannot be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new mutex.
        /// If <paramref name="lpMutexAttributes"/> is <see langword="null"/>, the mutex gets a default security descriptor.
        /// The ACLs in the default security descriptor for a mutex come from the primary or impersonation token of the creator.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <param name="lpName">
        /// The name of the mutex object. The name is limited to <see cref="MAX_PATH"/> characters. Name comparison is case sensitive.
        /// If <paramref name="lpName"/> is <see langword="null"/>, the mutex object is created without a name.
        /// If <paramref name="lpName"/> matches the name of an existing event, semaphore, waitable timer, job, or file-mapping object,
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
        /// This parameter can be 0 or the following value.
        /// <see cref="CREATE_MUTEX_INITIAL_OWNER"/>: The object creator is the initial owner of the mutex.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access mask for the mutex object.
        /// For a list of access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created mutex object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the mutex is a named mutex and the object existed before this function call,
        /// the return value is a handle to the existing object, <see cref="OpenMutex"/> function.
        /// </returns>
        /// <remarks>
        /// If you are using a named mutex to limit your application to a single instance, a malicious user can create this mutex 
        /// before you do and prevent your application from starting.
        /// To prevent this situation, create a randomly named mutex and store the name so that it can only be obtained by an authorized user.
        /// Alternatively, you can use a file for this purpose.
        /// To limit your application to one instance per user, create a locked file in the user's profile directory.
        /// Any thread of the calling process can specify the mutex-object handle in a call to one of the wait functions.
        /// The single-object wait functions return when the state of the specified object is signaled.
        /// The multiple-object wait functions can be instructed to return either when any one or when all of the specified objects are signaled.
        /// When a wait function returns, the waiting thread is released to continue its execution.
        /// The state of a mutex object is signaled when it is not owned by any thread.
        /// The creating thread can use the <paramref name="dwFlags "/> flag to request immediate ownership of the mutex.
        /// Otherwise, a thread must use one of the wait functions to request ownership.
        /// When the mutex's state is signaled, one waiting thread is granted ownership,
        /// the mutex's state changes to nonsignaled, and the wait function returns.
        /// Only one thread can own a mutex at any given time
        /// . The owning thread uses the ReleaseMutex function to release its ownership.
        /// The thread that owns a mutex can specify the same mutex in repeated wait function calls without blocking its execution.
        /// Typically, you would not wait repeatedly for the same mutex,
        /// but this mechanism prevents a thread from deadlocking itself while waiting for a mutex that it already owns.
        /// However, to release its ownership, the thread must call <see cref="ReleaseMutex"/> once for each time that the mutex satisfied a wait.
        /// Two or more processes can call <see cref="CreateMutex"/> to create the same named mutex.
        /// The first process actually creates the mutex, and subsequent processes with sufficient access rights simply open a handle to the existing mutex.
        /// This enables multiple processes to get handles of the same mutex,
        /// while relieving the user of the responsibility of ensuring that the creating process is started first.
        /// When using this technique, you should use the <see cref="CREATE_MUTEX_INITIAL_OWNER"/> flag;
        /// otherwise, it can be difficult to be certain which process has initial ownership.
        /// Multiple processes can have handles of the same mutex object, enabling use of the object for interprocess synchronization.
        /// The following object-sharing mechanisms are available:
        /// A child process created by the <see cref="CreateProcess"/> function can inherit a handle to a mutex object
        /// if the <paramref name="lpMutexAttributes"/> parameter of <see cref="CreateMutex"/> enabled inheritance.
        /// This mechanism works for both named and unnamed mutexes.
        /// A process can specify the handle to a mutex object in a call to the <see cref="DuplicateHandle"/> function
        /// to create a duplicate handle that can be used by another process.
        /// This mechanism works for both named and unnamed mutexes.
        /// A process can specify a named mutex in a call to the <see cref="OpenMutex"/>
        /// or <see cref="CreateMutex"/> function to retrieve a handle to the mutex object.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The mutex object is destroyed when its last handle has been closed.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateMutexExW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateMutexEx([In]in SECURITY_ATTRIBUTES lpMutexAttributes, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName,
                [In]uint dwFlags, [In]uint dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Opens an existing named mutex object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-openmutexw
        /// </para>
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// The access to the mutex object.
        /// Only the <see cref="SYNCHRONIZE"/> access right is required to use a mutex;
        /// to change the mutex's security, specify <see cref="MUTEX_ALL_ACCESS"/>.
        /// The function fails if the security descriptor of the specified object does not permit the requested access for the calling process.
        /// For a list of access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <param name="bInheritHandle">
        /// If this value is <see cref="TRUE"/>, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="lpName">
        /// The name of the mutex to be opened.
        /// Name comparisons are case sensitive.
        /// This function can open objects in a private namespace. For more information, see Object Namespaces.
        /// Terminal Services:
        /// The name can have a "Global" or "Local" prefix to explicitly open an object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// Note
        /// Fast user switching is implemented using Terminal Services sessions.
        /// The first user to log on uses session 0, the next user to log on uses session 1, and so on.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the mutex object.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If a named mutex does not exist, the function fails and <see cref="GetLastError"/> returns <see cref="ERROR_FILE_NOT_FOUND"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="OpenMutex"/> function enables multiple processes to open handles of the same mutex object.
        /// The function succeeds only if some process has already created the mutex by using the <see cref="CreateMutex"/> function.
        /// The calling process can use the returned handle in any function that requires a handle to a mutex object, such as the wait functions,
        /// subject to the limitations of the access specified in the <paramref name="dwDesiredAccess"/> parameter.
        /// The handle can be duplicated by using the <see cref="DuplicateHandle"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The mutex object is destroyed when its last handle has been closed.
        /// If your multithreaded application must repeatedly create, open, and close a named mutex object, a race condition can occur.
        /// In this situation, it is better to use <see cref="CreateMutex"/> instead of <see cref="OpenMutex"/>,
        /// because <see cref="CreateMutex"/> opens a mutex if it exists and creates it if it does not.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenMutexW", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE OpenMutex([In]ACCESS_MASK dwDesiredAccess, [In]BOOL bInheritHandle, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName);

        /// <summary>
        /// <para>
        /// Releases ownership of the specified mutex object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-releasemutex
        /// </para>
        /// </summary>
        /// <param name="hMutex">
        /// A handle to the mutex object. The <see cref="CreateMutex"/> or <see cref="OpenMutex"/> function returns this handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The ReleaseMutex function fails if the calling thread does not own the mutex object.
        /// A thread obtains ownership of a mutex either by creating it with the bInitialOwner parameter set to <see cref="TRUE"/>
        /// or by specifying its handle in a call to one of the wait functions.
        /// When the thread no longer needs to own the mutex object,
        /// it calls the <see cref="ReleaseMutex"/> function so that another thread can acquire ownership.
        /// A thread can specify a mutex that it already owns in a call to one of the wait functions without blocking its execution.
        /// This prevents a thread from deadlocking itself while waiting for a mutex that it already owns.
        /// However, to release its ownership, the thread must call <see cref="ReleaseMutex"/> one time for each time
        /// that it obtained ownership (either through <see cref="CreateMutex"/> or a wait function).
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseMutex", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ReleaseMutex([In]HANDLE hMutex);
    }
}
