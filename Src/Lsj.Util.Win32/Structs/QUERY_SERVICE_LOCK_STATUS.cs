using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the lock status of a service control manager database. It is used by the <see cref="QueryServiceLockStatus"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-query_service_lock_statusw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct QUERY_SERVICE_LOCK_STATUS
    {
        /// <summary>
        /// The lock status of the database.
        /// If this member is nonzero, the database is locked. If it is zero, the database is unlocked.
        /// </summary>
        public DWORD fIsLocked;

        /// <summary>
        /// The name of the user who acquired the lock.
        /// </summary>
        public nint lpLockOwner;

        /// <summary>
        /// The time since the lock was first acquired, in seconds.
        /// </summary>
        public DWORD dwLockDuration;
    }
}
