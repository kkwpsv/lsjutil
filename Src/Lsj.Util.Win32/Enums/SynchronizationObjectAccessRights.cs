using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The Windows security model enables you to control access to event, mutex, semaphore, and waitable timer objects.
    /// Timer queues, interlocked variables, and critical section objects are not securable.
    /// For more information, see Access-Control Model.
    /// </para>
    /// <para>
    /// You can specify a security descriptor for an interprocess synchronization object
    /// when you call the <see cref="CreateEvent"/>, <see cref="CreateMutex"/>,
    /// <see cref="CreateSemaphore"/>, or <see cref="CreateWaitableTimer"/> function.
    /// If you specify <see cref="NULL"/>, the object gets a default security descriptor.
    /// The Access-Control Lists (ACLs) in the default security descriptor
    /// for a synchronization object come from the primary or impersonation token of the creator.
    /// </para>
    /// <para>
    /// To get or set the security descriptor of an event, mutex, semaphore, or waitable timer object,
    /// call the <see cref="GetNamedSecurityInfo"/>, <see cref="SetNamedSecurityInfo"/>,
    /// <see cref="GetSecurityInfo"/>, or <see cref="SetSecurityInfo"/> functions.
    /// </para>
    /// <para>
    /// The handles returned by <see cref="CreateEvent"/>, <see cref="CreateMutex"/>, <see cref="CreateSemaphore"/>,
    /// and <see cref="CreateWaitableTimer"/> have full access to the new object.
    /// When you call the <see cref="OpenEvent"/>, <see cref="OpenMutex"/>, <see cref="OpenSemaphore"/>, and <see cref="OpenWaitableTimer"/> functions,
    /// the system checks the requested access rights against the object's security descriptor.
    /// </para>
    /// <para>
    /// The valid access rights for the interprocess synchronization objects
    /// include the standard access rights and some object-specific access rights.
    /// The following table lists the standard access rights used by all objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/sync/synchronization-object-security-and-access-rights"/>
    /// </para>
    /// </summary>
    public enum SynchronizationObjectAccessRights : uint
    {
        /// <summary>
        /// All possible access rights for an event object.
        /// Use this right only if your application requires access beyond that granted by the standard access rights and <see cref="EVENT_MODIFY_STATE"/>.
        /// Using this access right increases the possibility that your application must be run by an Administrator.
        /// </summary>
        EVENT_ALL_ACCESS = 0x1F0003,

        /// <summary>
        /// Modify state access, which is required for the <see cref="SetEvent"/>, <see cref="ResetEvent"/> and <see cref="PulseEvent"/> functions.
        /// </summary>
        EVENT_MODIFY_STATE = 0x0002,

        /// <summary>
        /// All possible access rights for a mutex object.
        /// Use this right only if your application requires access beyond that granted by the standard access rights.
        /// Using this access right increases the possibility that your application must be run by an Administrator.
        /// </summary>
        MUTEX_ALL_ACCESS = 0x1F0001,

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        MUTEX_MODIFY_STATE = 0x0001,

        /// <summary>
        /// All possible access rights for a semaphore object.
        /// Use this right only if your application requires access beyond that granted
        /// by the standard access rights and <see cref="SEMAPHORE_MODIFY_STATE"/>.
        /// Using this access right increases the possibility that your application must be run by an Administrator.
        /// </summary>
        SEMAPHORE_ALL_ACCESS = 0x1F0003,

        /// <summary>
        /// Modify state access, which is required for the <see cref="ReleaseSemaphore"/> function.
        /// </summary>
        SEMAPHORE_MODIFY_STATE = 0x0002,

        /// <summary>
        /// All possible access rights for a waitable timer object.
        /// Use this right only if your application requires access beyond that granted by the standard access rights and <see cref="TIMER_MODIFY_STATE"/>.
        /// Using this access right increases the possibility that your application must be run by an Administrator.
        /// </summary>
        TIMER_ALL_ACCESS = 0x1F0003,

        /// <summary>
        /// Modify state access, which is required for the <see cref="SetWaitableTimer"/> and <see cref="CancelWaitableTimer"/> functions.
        /// </summary>
        TIMER_MODIFY_STATE = 0x0002,

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        TIMER_QUERY_STATE = 0x0001,
    }
}
