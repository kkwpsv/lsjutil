using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="RegRestoreKey"/> flags
    /// </summary>
    public enum RegRestoreKeyFlags : uint
    {
        /// <summary>
        /// REG_FORCE_RESTORE
        /// </summary>
        REG_FORCE_RESTORE = 8,

        /// <summary>
        /// REG_WHOLE_HIVE_VOLATILE
        /// </summary>
        REG_WHOLE_HIVE_VOLATILE = 1,
    }
}
