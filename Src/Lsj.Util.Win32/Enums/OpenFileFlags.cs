using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="OpenFile"/> Flags
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-openfile
    /// </para>
    /// </summary>
    [Flags]
    public enum OpenFileFlags : uint
    {
        /// <summary>
        /// Ignored.
        /// To produce a dialog box containing a Cancel button, use <see cref="OF_PROMPT"/>.
        /// </summary>
        OF_CANCEL = 0x00000800,

        /// <summary>
        /// Creates a new file.
        /// If the file exists, it is truncated to zero (0) length.
        /// </summary>
        OF_CREATE = 0x00001000,

        /// <summary>
        /// Deletes a file.
        /// </summary>
        OF_DELETE = 0x00000200,

        /// <summary>
        /// Opens a file and then closes it.
        /// Use this to test for the existence of a file.
        /// </summary>
        OF_EXIST = 0x00004000,

        /// <summary>
        /// Fills the <see cref="OFSTRUCT"/> structure, but does not do anything else.
        /// </summary>
        OF_PARSE = 0x00000100,

        /// <summary>
        /// Displays a dialog box if a requested file does not exist.
        /// A dialog box informs a user that the system cannot find a file, and it contains Retry and Cancel buttons.
        /// The Cancel button directs <see cref="OpenFile"/> to return a file-not-found error message.
        /// </summary>
        OF_PROMPT = 0x00002000,

        /// <summary>
        /// Opens a file for reading only.
        /// </summary>
        OF_READ = 0x00000000,

        /// <summary>
        /// Opens a file with read/write permissions.
        /// </summary>
        OF_READWRITE = 0x00000002,

        /// <summary>
        /// Opens a file by using information in the reopen buffer.
        /// </summary>
        OF_REOPEN = 0x00008000,

        /// <summary>
        /// For MS-DOS–based file systems, opens a file with compatibility mode,
        /// allows any process on a specified computer to open the file any number of times.
        /// Other efforts to open a file with other sharing modes fail.
        /// This flag is mapped to the <see cref="FILE_SHARE_READ"/>|<see cref="FILE_SHARE_WRITE"/> flags of the <see cref="CreateFile"/> function.
        /// </summary>
        OF_SHARE_COMPAT = 0x00000000,

        /// <summary>
        /// Opens a file without denying read or write access to other processes.
        /// On MS-DOS-based file systems, if the file has been opened in compatibility mode by any other process, the function fails.
        /// This flag is mapped to the <see cref="FILE_SHARE_READ"/>|<see cref="FILE_SHARE_WRITE"/> flags of the <see cref="CreateFile"/> function.
        /// </summary>
        OF_SHARE_DENY_NONE = 0x00000040,

        /// <summary>
        /// Opens a file and denies read access to other processes.
        /// On MS-DOS-based file systems, if the file has been opened in compatibility mode, or for read access by any other process, the function fails.
        /// This flag is mapped to the <see cref="FILE_SHARE_WRITE"/> flag of the <see cref="CreateFile"/> function.
        /// </summary>
        OF_SHARE_DENY_READ = 0x00000030,

        /// <summary>
        /// Opens a file and denies write access to other processes.
        /// On MS-DOS-based file systems, if a file has been opened in compatibility mode, or for write access by any other process, the function fails.
        /// This flag is mapped to the <see cref="FILE_SHARE_READ"/> flag of the <see cref="CreateFile"/> function.
        /// </summary>
        OF_SHARE_DENY_WRITE = 0x00000020,

        /// <summary>
        /// Opens a file with exclusive mode, and denies both read/write access to other processes.
        /// If a file has been opened in any other mode for read/write access, even by the current process, the function fails.
        /// </summary>
        OF_SHARE_EXCLUSIVE = 0x00000010,

        /// <summary>
        /// Verifies that the date and time of a file are the same as when it was opened previously.
        /// This is useful as an extra check for read-only files.
        /// </summary>
        OF_VERIFY = 0x00000400,

        /// <summary>
        /// Opens a file for write access only.
        /// </summary>
        OF_WRITE = 0x00000001,
    }
}
