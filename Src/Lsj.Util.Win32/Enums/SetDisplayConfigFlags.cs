using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="SetDisplayConfig"/> Flags
    /// </summary>
    public enum SetDisplayConfigFlags : uint
    {
        /// <summary>
        /// SDC_TOPOLOGY_INTERNAL
        /// </summary>
        SDC_TOPOLOGY_INTERNAL = 0x00000001,

        /// <summary>
        /// SDC_TOPOLOGY_CLONE
        /// </summary>
        SDC_TOPOLOGY_CLONE = 0x00000002,

        /// <summary>
        /// SDC_TOPOLOGY_EXTEND
        /// </summary>
        SDC_TOPOLOGY_EXTEND = 0x00000004,

        /// <summary>
        /// SDC_TOPOLOGY_EXTERNAL
        /// </summary>
        SDC_TOPOLOGY_EXTERNAL = 0x00000008,

        /// <summary>
        /// SDC_TOPOLOGY_SUPPLIED
        /// </summary>
        SDC_TOPOLOGY_SUPPLIED = 0x00000010,

        /// <summary>
        /// SDC_USE_DATABASE_CURRENT
        /// </summary>
        SDC_USE_DATABASE_CURRENT = (SDC_TOPOLOGY_INTERNAL | SDC_TOPOLOGY_CLONE | SDC_TOPOLOGY_EXTEND | SDC_TOPOLOGY_EXTERNAL),

        /// <summary>
        /// SDC_USE_SUPPLIED_DISPLAY_CONFIG
        /// </summary>
        SDC_USE_SUPPLIED_DISPLAY_CONFIG = 0x00000020,

        /// <summary>
        /// SDC_VALIDATE
        /// </summary>
        SDC_VALIDATE = 0x00000040,

        /// <summary>
        /// SDC_APPLY
        /// </summary>
        SDC_APPLY = 0x00000080,

        /// <summary>
        /// SDC_NO_OPTIMIZATION
        /// </summary>
        SDC_NO_OPTIMIZATION = 0x00000100,

        /// <summary>
        /// SDC_SAVE_TO_DATABASE
        /// </summary>
        SDC_SAVE_TO_DATABASE = 0x00000200,

        /// <summary>
        /// SDC_ALLOW_CHANGES
        /// </summary>
        SDC_ALLOW_CHANGES = 0x00000400,

        /// <summary>
        /// SDC_PATH_PERSIST_IF_REQUIRED
        /// </summary>
        SDC_PATH_PERSIST_IF_REQUIRED = 0x00000800,

        /// <summary>
        /// SDC_FORCE_MODE_ENUMERATION
        /// </summary>
        SDC_FORCE_MODE_ENUMERATION = 0x00001000,

        /// <summary>
        /// SDC_ALLOW_PATH_ORDER_CHANGES
        /// </summary>
        SDC_ALLOW_PATH_ORDER_CHANGES = 0x00002000,

        /// <summary>
        /// SDC_ALLOW_PATH_ORDER_CHANGES
        /// </summary>
        SDC_VIRTUAL_MODE_AWARE = 0x00008000,

        /// <summary>
        /// SDC_VIRTUAL_REFRESH_RATE_AWARE
        /// </summary>
        SDC_VIRTUAL_REFRESH_RATE_AWARE = 0x00020000,
    }
}
