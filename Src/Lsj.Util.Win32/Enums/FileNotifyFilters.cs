using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// File Notify Filters
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-readdirectorychangesw"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum FileNotifyFilters : uint
    {
        /// <summary>
        /// Any file name change in the watched directory or subtree causes a change notification wait operation to return.
        /// Changes include renaming, creating, or deleting a file name.
        /// </summary>
        FILE_NOTIFY_CHANGE_FILE_NAME = 0x00000001,

        /// <summary>
        /// Any directory-name change in the watched directory or subtree causes a change notification wait operation to return.
        /// Changes include creating or deleting a directory.
        /// </summary>
        FILE_NOTIFY_CHANGE_DIR_NAME = 0x00000002,

        /// <summary>
        /// Any attribute change in the watched directory or subtree causes a change notification wait operation to return.
        /// </summary>
        FILE_NOTIFY_CHANGE_ATTRIBUTES = 0x00000004,

        /// <summary>
        /// Any file-size change in the watched directory or subtree causes a change notification wait operation to return.
        /// The operating system detects a change in file size only when the file is written to the disk.
        /// For operating systems that use extensive caching, detection occurs only when the cache is sufficiently flushed.
        /// </summary>
        FILE_NOTIFY_CHANGE_SIZE = 0x00000008,

        /// <summary>
        /// Any change to the last write-time of files in the watched directory or subtree causes a change notification wait operation to return.
        /// The operating system detects a change to the last write-time only when the file is written to the disk.
        /// For operating systems that use extensive caching, detection occurs only when the cache is sufficiently flushed.
        /// </summary>
        FILE_NOTIFY_CHANGE_LAST_WRITE = 0x00000010,

        /// <summary>
        /// Any change to the last access time of files in the watched directory or subtree causes a change notification wait operation to return. 
        /// </summary>
        FILE_NOTIFY_CHANGE_LAST_ACCESS = 0x00000020,

        /// <summary>
        /// Any change to the creation time of files in the watched directory or subtree causes a change notification wait operation to return. 
        /// </summary>
        FILE_NOTIFY_CHANGE_CREATION = 0x00000040,

        /// <summary>
        /// Any security-descriptor change in the watched directory or subtree causes a change notification wait operation to return.
        /// </summary>
        FILE_NOTIFY_CHANGE_SECURITY = 0x00000100,
    }
}
