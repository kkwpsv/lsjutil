using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="RegSaveKeyEx"/> flags
    /// </summary>
    public enum RegSaveKeyExFlags : uint
    {
        /// <summary>
        /// REG_STANDARD_FORMAT
        /// </summary>
        REG_STANDARD_FORMAT = 1,

        /// <summary>
        /// REG_LATEST_FORMAT
        /// </summary>
        REG_LATEST_FORMAT = 2,

        /// <summary>
        /// REG_NO_COMPRESSION
        /// </summary>
        REG_NO_COMPRESSION = 4,
    }
}
