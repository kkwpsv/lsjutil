using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Find String Flags
    /// </summary>
    public enum FindStringFlags : uint
    {
        /// <summary>
        /// FIND_STARTSWITH
        /// </summary>
        FIND_STARTSWITH = 0x00100000,

        /// <summary>
        /// FIND_ENDSWITH
        /// </summary>
        FIND_ENDSWITH = 0x00200000,

        /// <summary>
        /// FIND_FROMSTART
        /// </summary>
        FIND_FROMSTART = 0x00400000,

        /// <summary>
        /// FIND_FROMEND
        /// </summary>
        FIND_FROMEND = 0x00800000,
    }
}
