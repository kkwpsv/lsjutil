using Lsj.Util.Win32.ComInterfaces;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="LOCKTYPE"/> enumeration values indicate the type of locking requested for the specified range of bytes.
    /// The values are used in the <see cref="ILockBytes.LockRegion"/> and <see cref="IStream.LockRegion"/> methods.
    /// </para>
    /// </summary>
    public enum LOCKTYPE
    {
        /// <summary>
        /// If this lock is granted, the specified range of bytes can be opened and read any number of times,
        /// but writing to the locked range is prohibited except for the owner that was granted this lock.
        /// </summary>
        LOCK_WRITE = 1,

        /// <summary>
        /// If this lock is granted, writing to the specified range of bytes is prohibited except by the owner that was granted this lock.
        /// </summary>
        LOCK_EXCLUSIVE = 2,

        /// <summary>
        /// If this lock is granted, no other <see cref="LOCK_ONLYONCE"/> lock can be obtained on the range.
        /// Usually this lock type is an alias for some other lock type.
        /// Thus, specific implementations can have additional behavior associated with this lock type.
        /// </summary>
        LOCK_ONLYONCE = 4
    }
}
