using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.HKEY;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="RegSaveKeyEx"/> Flags
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regsavekeyexw
    /// </para>
    /// </summary>
    public enum RegSaveKeyExFlags : uint
    {
        /// <summary>
        /// The key or hive is saved in standard format.
        /// The standard format is the only format supported by Windows 2000. 
        /// </summary>
        REG_STANDARD_FORMAT = 1,

        /// <summary>
        /// The key or hive is saved in the latest format.
        /// The latest format is supported starting with Windows XP.
        /// After the key or hive is saved in this format, it cannot be loaded on an earlier system. 
        /// </summary>
        REG_LATEST_FORMAT = 2,

        /// <summary>
        /// The hive is saved with no compression, for faster save operations.
        /// The hKey parameter must specify the root of a hive under <see cref="HKEY_LOCAL_MACHINE"/> or <see cref="HKEY_USERS"/>.
        /// For example, HKLM\SOFTWARE is the root of a hive. 
        /// </summary>
        REG_NO_COMPRESSION = 4,
    }
}
