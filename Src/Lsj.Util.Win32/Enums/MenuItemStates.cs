using System;
using static Lsj.Util.Win32.Enums.MenuFlags;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Menu item states
    /// </summary>
    [Flags]
    public enum MenuItemStates : uint
    {
        /// <summary>
        /// MFS_GRAYED
        /// </summary>
        MFS_GRAYED = 0x00000003,

        /// <summary>
        /// MFS_DISABLED
        /// </summary>
        MFS_DISABLED = MFS_GRAYED,

        /// <summary>
        /// MFS_CHECKED
        /// </summary>
        MFS_CHECKED = MF_CHECKED,

        /// <summary>
        /// MFS_HILITE
        /// </summary>
        MFS_HILITE = MF_HILITE,

        /// <summary>
        /// MFS_ENABLED
        /// </summary>
        MFS_ENABLED = MF_ENABLED,

        /// <summary>
        /// MFS_UNCHECKED
        /// </summary>
        MFS_UNCHECKED = MF_UNCHECKED,

        /// <summary>
        /// MFS_UNHILITE
        /// </summary>
        MFS_UNHILITE = MF_UNHILITE,

        /// <summary>
        /// MFS_DEFAULT
        /// </summary>
        MFS_DEFAULT = MF_DEFAULT,
    }
}
