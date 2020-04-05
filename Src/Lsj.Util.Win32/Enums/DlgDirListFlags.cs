using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DlgDirList"/>, <see cref="DlgDirListComboBox"/> Flags
    /// </summary>
    [Flags]
    public enum DlgDirListFlags
    {
        /// <summary>
        /// DDL_READWRITE
        /// </summary>
        DDL_READWRITE = 0x0000,

        /// <summary>
        /// DDL_READONLY
        /// </summary>
        DDL_READONLY = 0x0001,

        /// <summary>
        /// DDL_HIDDEN
        /// </summary>
        DDL_HIDDEN = 0x0002,

        /// <summary>
        /// DDL_SYSTEM
        /// </summary>
        DDL_SYSTEM = 0x0004,

        /// <summary>
        /// DDL_DIRECTORY
        /// </summary>
        DDL_DIRECTORY = 0x0010,

        /// <summary>
        /// DDL_ARCHIVE
        /// </summary>
        DDL_ARCHIVE = 0x0020,

        /// <summary>
        /// DDL_POSTMSGS
        /// </summary>
        DDL_POSTMSGS = 0x2000,

        /// <summary>
        /// DDL_DRIVES
        /// </summary>
        DDL_DRIVES = 0x4000,

        /// <summary>
        /// DDL_EXCLUSIVE
        /// </summary>
        DDL_EXCLUSIVE = 0x8000,
    }
}
