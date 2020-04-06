﻿using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// File Flags
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-createfilew
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createnamedpipea
    /// </para>
    /// </summary>
    public enum FileFlags : uint
    {
        /// <summary>
        /// The file is being opened or created for a backup or restore operation.
        /// The system ensures that the calling process overrides file security checks
        /// when the process has <see cref="SE_BACKUP_NAME"/> and <see cref="SE_RESTORE_NAME"/> privileges.
        /// For more information, see Changing Privileges in a Token.
        /// You must set this flag to obtain a handle to a directory.
        /// A directory handle can be passed to some functions instead of a file handle.
        /// For more information, see the Remarks section.
        /// </summary>
        FILE_FLAG_BACKUP_SEMANTICS = 0x02000000,

        /// <summary>
        /// The file is to be deleted immediately after all of its handles are closed,
        /// which includes the specified handle and any other open or duplicated handles.
        /// If there are existing open handles to a file,
        /// the call fails unless they were all opened with the <see cref="FileShareModes.FILE_SHARE_DELETE"/> share mode.
        /// Subsequent open requests for the file fail, unless the <see cref="FileShareModes.FILE_SHARE_DELETE"/> share mode is specified.
        /// </summary>
        FILE_FLAG_DELETE_ON_CLOSE = 0x04000000,

        /// <summary>
        /// The file or device is being opened with no system caching for data reads and writes.
        /// This flag does not affect hard disk caching or memory mapped files.
        /// There are strict requirements for successfully working with files
        /// opened with <see cref="CreateFile"/> using the <see cref="FILE_FLAG_NO_BUFFERING"/> flag, for details see File Buffering.
        /// </summary>
        FILE_FLAG_NO_BUFFERING = 0x20000000,

        /// <summary>
        /// The file data is requested, but it should continue to be located in remote storage.
        /// It should not be transported back to local storage.
        /// This flag is for use by remote storage systems.
        /// </summary>
        FILE_FLAG_OPEN_NO_RECALL = 0x00100000,

        /// <summary>
        /// Normal reparse point processing will not occur; <see cref="CreateFile"/> will attempt to open the reparse point.
        /// When a file is opened, a file handle is returned, whether or not the filter that controls the reparse point is operational.
        /// This flag cannot be used with the <see cref="FileCreationDispositions.CREATE_ALWAYS"/> flag.
        /// If the file is not a reparse point, then this flag is ignored.
        /// For more information, see the Remarks section.
        /// </summary>
        FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000,

        /// <summary>
        /// The file or device is being opened or created for asynchronous I/O.
        /// When subsequent I/O operations are completed on this handle,
        /// the event specified in the <see cref="OVERLAPPED"/> structure will be set to the signaled state.
        /// If this flag is specified, the file can be used for simultaneous read and write operations.
        /// If this flag is not specified, then I/O operations are serialized,
        /// even if the calls to the read and write functions specify an <see cref="OVERLAPPED"/> structure.
        /// For information about considerations when using a file handle created with this flag,
        /// see the Synchronous and Asynchronous I/O Handles section of this topic.
        /// </summary>
        FILE_FLAG_OVERLAPPED = 0x40000000,

        /// <summary>
        /// Access will occur according to POSIX rules.
        /// This includes allowing multiple files with names, differing only in case, for file systems that support that naming.
        /// Use care when using this option, because files created with this flag may not be accessible
        /// by applications that are written for MS-DOS or 16-bit Windows.
        /// </summary>
        FILE_FLAG_POSIX_SEMANTICS = 0x0100000,

        /// <summary>
        /// Access is intended to be random. The system can use this as a hint to optimize file caching.
        /// This flag has no effect if the file system does not support cached I/O and <see cref="FILE_FLAG_NO_BUFFERING"/>.
        /// For more information, see the Caching Behavior section of this topic.
        /// </summary>
        FILE_FLAG_RANDOM_ACCESS = 0x10000000,

        /// <summary>
        /// The file or device is being opened with session awareness.
        /// If this flag is not specified, then per-session devices (such as a device using RemoteFX USB Redirection)
        /// cannot be opened by processes running in session 0.
        /// This flag has no effect for callers not in session 0. This flag is supported only on server editions of Windows.
        /// Windows Server 2008 R2 and Windows Server 2008:  This flag is not supported before Windows Server 2012.
        /// </summary>
        FILE_FLAG_SESSION_AWARE = 0x00800000,

        /// <summary>
        /// Access is intended to be sequential from beginning to end. The system can use this as a hint to optimize file caching.
        /// This flag should not be used if read-behind (that is, reverse scans) will be used.
        /// This flag has no effect if the file system does not support cached I/O and <see cref="FILE_FLAG_NO_BUFFERING"/>.
        /// For more information, see the Caching Behavior section of this topic.
        /// </summary>
        FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000,

        /// <summary>
        /// Write operations will not go through any intermediate cache, they will go directly to disk.
        /// For additional information, see the Caching Behavior section of this topic.
        /// </summary>
        FILE_FLAG_WRITE_THROUGH = 0x80000000,

        /// <summary>
        /// If you attempt to create multiple instances of a pipe with this flag, creation of the first instance succeeds,
        /// but creation of the next instance fails with <see cref="SystemErrorCodes.ERROR_ACCESS_DENIED"/>.
        /// </summary>
        FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000,
    }
}
