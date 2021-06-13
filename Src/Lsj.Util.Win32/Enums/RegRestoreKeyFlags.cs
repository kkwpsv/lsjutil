using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.HKEY;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="RegRestoreKey"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winreg/nf-winreg-regrestorekeyw"/>
    /// </para>
    /// </summary>
    public enum RegRestoreKeyFlags : uint
    {
        /// <summary>
        /// If specified, the restore operation is executed even if open handles exist at or beneath the location
        /// in the registry hierarchy to which the hKey parameter points. 
        /// </summary>
        REG_FORCE_RESTORE = 8,

        /// <summary>
        /// If specified, a new, volatile (memory only) set of registry information, or hive, is created.
        /// If <see cref="REG_WHOLE_HIVE_VOLATILE"/> is specified, the key identified by the hKey parameter
        /// must be either the <see cref="HKEY_USERS"/> or <see cref="HKEY_LOCAL_MACHINE"/> value. 
        /// </summary>
        REG_WHOLE_HIVE_VOLATILE = 1,
    }
}
