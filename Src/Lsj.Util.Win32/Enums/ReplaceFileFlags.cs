using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="ReplaceFile"/> flags
    /// </summary>
    [Flags]
    public enum ReplaceFileFlags : uint
    {
        /// <summary>
        /// REPLACEFILE_WRITE_THROUGH
        /// </summary>
        REPLACEFILE_WRITE_THROUGH = 0x00000001,

        /// <summary>
        /// REPLACEFILE_IGNORE_MERGE_ERRORS
        /// </summary>
        REPLACEFILE_IGNORE_MERGE_ERRORS = 0x00000002,

        /// <summary>
        /// REPLACEFILE_IGNORE_ACL_ERRORS
        /// </summary>
        REPLACEFILE_IGNORE_ACL_ERRORS = 0x00000004,
    }
}
