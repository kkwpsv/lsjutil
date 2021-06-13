using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Io Control Codes
    /// </summary>
    public enum IoControlCodes : uint
    {
        /// <summary>
        /// <para>
        /// Signals the file system driver not to perform any I/O boundary checks on partition read or write calls.
        /// Instead, boundary checks are performed by the device driver.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_allow_extended_dasd_io"/>
        /// </para>
        /// </summary>
        FSCTL_ALLOW_EXTENDED_DASD_IO = 0x90083,

        /// <summary>
        /// <para>
        /// Dismounts a volume regardless of whether or not the volume is currently in use.
        /// For more information, see the Remarks section.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_dismount_volume"/>
        /// </para>
        /// </summary>
        FSCTL_DISMOUNT_VOLUME = 0x90020,

        /// <summary>
        /// <para>
        /// Retrieves the current compression state of a file or directory on a volume whose file system supports per-stream compression.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_get_compression"/>
        /// </para>
        /// </summary>
        FSCTL_GET_COMPRESSION = 0x9003c,

        /// <summary>
        /// <para>
        /// Locks a volume if it is not in use.
        /// A locked volume can be accessed only through handles to the file object (*hDevice) that locks the volume.
        /// For more information, see the Remarks section.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_lock_volume"/>
        /// </para>
        /// </summary>
        FSCTL_LOCK_VOLUME = 0x90018,

        /// <summary>
        /// <para>
        /// Scans a file or alternate stream looking for ranges that may contain nonzero data.
        /// Only compressed or sparse files can have zeroed ranges known to the operating system.
        /// For other files, the output buffer will contain only a single entry that contains the starting point and the length requested.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_query_allocated_ranges"/>
        /// </para>
        /// </summary>
        FSCTL_QUERY_ALLOCATED_RANGES = 0x940cf,

        /// <summary>
        /// Sets the compression state of a file or directory on a volume whose file system supports per-file and per-directory compression.
        /// You can use <see cref="FSCTL_SET_COMPRESSION"/> to compress or uncompress a file or directory on such a volume.
        /// </summary>
        FSCTL_SET_COMPRESSION = 0x9c040,

        /// <summary>
        /// Sets a reparse point on a file or directory.
        /// </summary>
        FSCTL_SET_REPARSE_POINT = 0x000900a4,

        /// <summary>
        /// <para>
        /// Marks the indicated file as sparse or not sparse.
        /// In a sparse file, large ranges of zeros may not require disk allocation.
        /// Space for nonzero data will be allocated as needed as the file is written.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_set_sparse?redirectedfrom=MSDN"/>
        /// </para>
        /// </summary>
        FSCTL_SET_SPARSE = 0x900c4,

        /// <summary>
        /// <para>
        /// Fills a specified range of a file with zeros (0).
        /// If the file is sparse or compressed, the NTFS file system may deallocate disk space in the file.
        /// This sets the range of bytes to zeros (0) without extending the file size.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_set_zero_data?redirectedfrom=MSDN"/>
        /// </para>
        /// </summary>
        FSCTL_SET_ZERO_DATA = 0x980c8,

        /// <summary>
        /// <para>
        /// Creates a new miniversion for the specified file. Miniversions allow you to refer to a snapshot of the file during a transaction.
        /// Miniversions are discarded when a transaction is committed or rolled back.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_txfs_create_miniversion"/>
        /// </para>
        /// </summary>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            "Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            "Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            "For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        FSCTL_TXFS_CREATE_MINIVERSION = 0x9817C,

        /// <summary>
        /// <para>
        /// Retrieves the length of the specified disk, volume, or partition.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_get_length_info"/>
        /// </para>
        /// </summary>
        IOCTL_DISK_GET_LENGTH_INFO = 0x7405C,

        /// <summary>
        /// <para>
        /// Retrieves the physical location of a specified volume on one or more disks.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-ioctl_volume_get_volume_disk_extents"/>
        /// </para>
        /// </summary>
        IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS = 0x560000,
    }
}
