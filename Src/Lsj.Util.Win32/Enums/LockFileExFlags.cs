using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="LockFileEx"/> flags
    /// </summary>
    [Flags]
    public enum LockFileExFlags : uint
    {
        /// <summary>
        /// LOCKFILE_EXCLUSIVE_LOCK
        /// </summary>
        LOCKFILE_EXCLUSIVE_LOCK = 0x00000002,

        /// <summary>
        /// LOCKFILE_FAIL_IMMEDIATELY
        /// </summary>
        LOCKFILE_FAIL_IMMEDIATELY = 0x00000001,
    }
}
