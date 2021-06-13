using System;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="ReplaceFile"/> Flags.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-replacefilew"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum ReplaceFileFlags : uint
    {
        /// <summary>
        /// This value is not supported.
        /// </summary>
        REPLACEFILE_WRITE_THROUGH = 0x00000001,

        /// <summary>
        /// Ignores errors that occur while merging information (such as attributes and ACLs) from the replaced file to the replacement file.
        /// Therefore, if you specify this flag and do not have <see cref="WRITE_DAC"/> access, the function succeeds but the ACLs are not preserved.
        /// </summary>
        REPLACEFILE_IGNORE_MERGE_ERRORS = 0x00000002,

        /// <summary>
        /// Ignores errors that occur while merging ACL information from the replaced file to the replacement file.
        /// Therefore, if you specify this flag and do not have <see cref="WRITE_DAC"/> access, the function succeeds but the ACLs are not preserved.
        /// To compile an application that uses this value, define the _WIN32_WINNT macro as 0x0600 or later.
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// </summary>
        REPLACEFILE_IGNORE_ACL_ERRORS = 0x00000004,
    }
}
