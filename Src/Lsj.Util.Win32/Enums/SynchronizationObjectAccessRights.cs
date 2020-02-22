using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Synchronization Object Access Rights
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/sync/synchronization-object-security-and-access-rights
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
