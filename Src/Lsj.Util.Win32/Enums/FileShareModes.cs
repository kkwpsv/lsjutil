using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// File Share Modes
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-createfilew
    /// </para>
    /// </summary>
    public enum FileShareModes
    {
        /// <summary>
        /// Prevents other processes from opening a file or device if they request delete, read, or write access.
        /// </summary>
        None = 0,

        /// <summary>
        /// Enables subsequent open operations on a file or device to request delete access.
        /// Otherwise, other processes cannot open the file or device if they request delete access.
        /// If this flag is not specified, but the file or device has been opened for delete access, the function fails.
        /// Delete access allows both delete and rename operations.
        /// </summary>
        FILE_SHARE_DELETE = 0x00000004,

        /// <summary>
        /// Enables subsequent open operations on a file or device to request read access.
        /// Otherwise, other processes cannot open the file or device if they request read access.
        /// If this flag is not specified, but the file or device has been opened for read access, the function fails.
        /// </summary>
        FILE_SHARE_READ = 0x00000001,

        /// <summary>
        /// Enables subsequent open operations on a file or device to request write access.
        /// Otherwise, other processes cannot open the file or device if they request write access.
        /// If this flag is not specified, but the file or device has been opened for write access
        /// or has a file mapping with write access, the function fails.
        /// </summary>
        FILE_SHARE_WRITE = 0x00000002,
    }
}
