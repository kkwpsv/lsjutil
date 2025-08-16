using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Suite masks
    /// </summary>
    [Flags]
    public enum SuiteMasks : uint
    {
        /// <summary>
        /// VER_SUITE_BACKOFFICE
        /// </summary>
        VER_SUITE_BACKOFFICE = 0x00000004,

        /// <summary>
        /// VER_SUITE_BLADE
        /// </summary>
        VER_SUITE_BLADE = 0x00000400,

        /// <summary>
        /// VER_SUITE_COMPUTE_SERVER
        /// </summary>
        VER_SUITE_COMPUTE_SERVER = 0x00004000,

        /// <summary>
        /// VER_SUITE_DATACENTER
        /// </summary>
        VER_SUITE_DATACENTER = 0x00000080,

        /// <summary>
        /// VER_SUITE_ENTERPRISE
        /// </summary>
        VER_SUITE_ENTERPRISE = 0x00000002,

        /// <summary>
        /// VER_SUITE_EMBEDDEDNT
        /// </summary>
        VER_SUITE_EMBEDDEDNT = 0x00000040,

        /// <summary>
        /// VER_SUITE_PERSONAL
        /// </summary>
        VER_SUITE_PERSONAL = 0x00000200,

        /// <summary>
        /// VER_SUITE_SINGLEUSERTS
        /// </summary>
        VER_SUITE_SINGLEUSERTS = 0x00000100,

        /// <summary>
        /// VER_SUITE_SMALLBUSINESS
        /// </summary>
        VER_SUITE_SMALLBUSINESS = 0x00000001,

        /// <summary>
        /// VER_SUITE_SMALLBUSINESS_RESTRICTED
        /// </summary>
        VER_SUITE_SMALLBUSINESS_RESTRICTED = 0x00000020,

        /// <summary>
        /// VER_SUITE_STORAGE_SERVER
        /// </summary>
        VER_SUITE_STORAGE_SERVER = 0x00002000,

        /// <summary>
        /// VER_SUITE_TERMINAL
        /// </summary>
        VER_SUITE_TERMINAL = 0x00000010,

        /// <summary>
        /// VER_SUITE_WH_SERVER
        /// </summary>
        VER_SUITE_WH_SERVER = 0x00008000,

        /// <summary>
        /// VER_SUITE_MULTIUSERTS
        /// </summary>
        VER_SUITE_MULTIUSERTS = 0x00020000,
    }
}
