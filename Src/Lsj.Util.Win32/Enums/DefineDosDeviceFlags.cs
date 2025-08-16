using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DefineDosDevice"/> flags
    /// </summary>
    public enum DefineDosDeviceFlags : uint
    {
        /// <summary>
        /// DDD_RAW_TARGET_PATH
        /// </summary>
        DDD_RAW_TARGET_PATH = 0x00000001,

        /// <summary>
        /// DDD_REMOVE_DEFINITION
        /// </summary>
        DDD_REMOVE_DEFINITION = 0x00000002,

        /// <summary>
        /// DDD_EXACT_MATCH_ON_REMOVE
        /// </summary>
        DDD_EXACT_MATCH_ON_REMOVE = 0x00000004,

        /// <summary>
        /// DDD_NO_BROADCAST_SYSTEM
        /// </summary>
        DDD_NO_BROADCAST_SYSTEM = 0x00000008,
    }
}
