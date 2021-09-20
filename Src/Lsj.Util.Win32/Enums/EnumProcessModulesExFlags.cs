using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="EnumProcessModulesEx"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/psapi/nf-psapi-enumprocessmodulesex"/>
    /// </para>
    /// </summary>
    public enum EnumProcessModulesExFlags : uint
    {
        /// <summary>
        /// Use the default behavior.
        /// </summary>
        LIST_MODULES_DEFAULT = 0x0,

        /// <summary>
        /// List the 32-bit modules.
        /// </summary>
        LIST_MODULES_32BIT = 0x01,

        /// <summary>
        /// List the 64-bit modules.
        /// </summary>
        LIST_MODULES_64BIT = 0x02,

        /// <summary>
        /// List all modules.
        /// </summary>
        LIST_MODULES_ALL = LIST_MODULES_32BIT | LIST_MODULES_64BIT,
    }
}
