using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="FindFirstFileEx"/> flags
    /// </summary>
    [Flags]
    public enum FindFirstFileExFlags
    {
        /// <summary>
        /// FIND_FIRST_EX_CASE_SENSITIVE
        /// </summary>
        FIND_FIRST_EX_CASE_SENSITIVE = 1,

        /// <summary>
        /// FIND_FIRST_EX_LARGE_FETCH
        /// </summary>
        FIND_FIRST_EX_LARGE_FETCH = 2,

        /// <summary>
        /// FIND_FIRST_EX_ON_DISK_ENTRIES_ONLY
        /// </summary>
        FIND_FIRST_EX_ON_DISK_ENTRIES_ONLY = 4,
    }
}
