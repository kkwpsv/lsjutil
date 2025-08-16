using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="AddFontResourceEx"/> flags
    /// </summary>
    public enum AddFontResourceExFlags : uint
    {
        /// <summary>
        /// FR_PRIVATE
        /// </summary>
        FR_PRIVATE = 0x10,

        /// <summary>
        /// FR_NOT_ENUM
        /// </summary>
        FR_NOT_ENUM = 0x20,
    }
}
