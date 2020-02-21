using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Defines values that are used with the <see cref="FindFirstFileEx"/> function to specify the type of filtering to perform.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ne-minwinbase-findex_search_ops
    /// </para>
    /// </summary>
    public enum FINDEX_SEARCH_OPS
    {
        /// <summary>
        /// The search for a file that matches a specified file name.
        /// The lpSearchFilter parameter of <see cref="FindFirstFileEx"/> must be NULL when this search operation is used.
        /// </summary>
        FindExSearchNameMatch,

        /// <summary>
        /// This is an advisory flag.
        /// If the file system supports directory filtering, the function searches for a file that matches the specified name and is also a directory.
        /// If the file system does not support directory filtering, this flag is silently ignored.
        /// The lpSearchFilter parameter of the <see cref="FindFirstFileEx"/> function must be NULL when this search value is used.
        /// If directory filtering is desired, this flag can be used on all file systems,
        /// but because it is an advisory flag and only affects file systems that support it,
        /// the application must examine the file attribute data stored in the lpFindFileData parameter of
        /// the <see cref="FindFirstFileEx"/> function to determine whether the function has returned a handle to a directory.
        /// </summary>
        FindExSearchLimitToDirectories,

        /// <summary>
        /// This filtering type is not available.
        /// For more information, see Device Interface Classes.
        /// </summary>
        FindExSearchLimitToDevices,

        /// <summary>
        /// 
        /// </summary>
        FindExSearchMaxSearchOp
    }
}
