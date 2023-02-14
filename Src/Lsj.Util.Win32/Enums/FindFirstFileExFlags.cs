using System;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="FindFirstFileEx"/> flags.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-findfirstfileexw"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum FindFirstFileExFlags
    {
        /// <summary>
        /// Searches are case-sensitive.
        /// </summary>
        FIND_FIRST_EX_CASE_SENSITIVE = 1,

        /// <summary>
        /// Uses a larger buffer for directory queries, which can increase performance of the find operation.
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported until Windows Server 2008 R2 and Windows 7.
        /// </summary>
        FIND_FIRST_EX_LARGE_FETCH = 2,

        /// <summary>
        /// Limits the results to files that are physically on disk.
        /// This flag is only relevant when a file virtualization filter is present.
        /// </summary>
        FIND_FIRST_EX_ON_DISK_ENTRIES_ONLY = 4,
    }
}
