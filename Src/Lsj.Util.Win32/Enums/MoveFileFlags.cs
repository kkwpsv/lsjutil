using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// MoveFile Flags
    /// </summary>
    [Flags]
    public enum MoveFileFlags : uint
    {
        /// <summary>
        /// MOVEFILE_COPY_ALLOWED
        /// </summary>
        MOVEFILE_COPY_ALLOWED = 0x2,

        /// <summary>
        /// MOVEFILE_CREATE_HARDLINK
        /// </summary>
        MOVEFILE_CREATE_HARDLINK = 0x10,

        /// <summary>
        /// MOVEFILE_DELAY_UNTIL_REBOOT
        /// </summary>
        MOVEFILE_DELAY_UNTIL_REBOOT = 0x4,

        /// <summary>
        /// MOVEFILE_FAIL_IF_NOT_TRACKABLE
        /// </summary>
        MOVEFILE_FAIL_IF_NOT_TRACKABLE = 0x20,

        /// <summary>
        /// MOVEFILE_REPLACE_EXISTING
        /// </summary>
        MOVEFILE_REPLACE_EXISTING = 0x1,

        /// <summary>
        /// MOVEFILE_WRITE_THROUGH
        /// </summary>
        MOVEFILE_WRITE_THROUGH = 0x8,
    }
}
