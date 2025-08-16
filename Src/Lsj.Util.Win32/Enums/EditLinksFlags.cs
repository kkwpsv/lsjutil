using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Edit links flags
    /// </summary>
    [Flags]
    public enum EditLinksFlags : uint
    {
        /// <summary>
        /// ELF_SHOWHELP
        /// </summary>
        ELF_SHOWHELP = 0x00000001,

        /// <summary>
        /// ELF_DISABLEUPDATENOW
        /// </summary>
        ELF_DISABLEUPDATENOW = 0x00000002,

        /// <summary>
        /// ELF_DISABLEOPENSOURCE
        /// </summary>
        ELF_DISABLEOPENSOURCE = 0x00000004,

        /// <summary>
        /// ELF_DISABLECHANGESOURCE
        /// </summary>
        ELF_DISABLECHANGESOURCE = 0x00000008,

        /// <summary>
        /// ELF_DISABLECANCELLINK
        /// </summary>
        ELF_DISABLECANCELLINK = 0x00000010,
    }
}
