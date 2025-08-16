using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="EnumProcessModulesEx"/> Flags
    /// </summary>
    public enum EnumProcessModulesExFlags : uint
    {
        /// <summary>
        /// LIST_MODULES_DEFAULT
        /// </summary>
        LIST_MODULES_DEFAULT = 0x0,

        /// <summary>
        /// LIST_MODULES_32BIT
        /// </summary>
        LIST_MODULES_32BIT = 0x01,

        /// <summary>
        /// LIST_MODULES_64BIT
        /// </summary>
        LIST_MODULES_64BIT = 0x02,

        /// <summary>
        /// LIST_MODULES_ALL
        /// </summary>
        LIST_MODULES_ALL = LIST_MODULES_32BIT | LIST_MODULES_64BIT,
    }
}
