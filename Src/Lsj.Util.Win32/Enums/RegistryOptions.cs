using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// RegistryOptions
    /// </summary>
    [Flags]
    public enum RegistryOptions : uint
    {
        /// <summary>
        /// REG_OPTION_RESERVED
        /// </summary>
        REG_OPTION_RESERVED = 0x00000000,

        /// <summary>
        /// REG_OPTION_NON_VOLATILE
        /// </summary>
        REG_OPTION_NON_VOLATILE = 0x00000000,

        /// <summary>
        /// REG_OPTION_VOLATILE
        /// </summary>
        REG_OPTION_VOLATILE = 0x00000001,

        /// <summary>
        /// REG_OPTION_CREATE_LINK
        /// </summary>
        REG_OPTION_CREATE_LINK = 0x00000002,

        /// <summary>
        /// REG_OPTION_BACKUP_RESTORE
        /// </summary>
        REG_OPTION_BACKUP_RESTORE = 0x00000004,

        /// <summary>
        /// REG_OPTION_OPEN_LINK
        /// </summary>
        REG_OPTION_OPEN_LINK = 0x00000008,

        /// <summary>
        /// REG_OPTION_DONT_VIRTUALIZE
        /// </summary>
        REG_OPTION_DONT_VIRTUALIZE = 0x00000010,
    }
}
