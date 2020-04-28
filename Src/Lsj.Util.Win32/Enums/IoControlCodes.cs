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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_allow_extended_dasd_io
        /// </para>
        /// </summary>
        FSCTL_ALLOW_EXTENDED_DASD_IO = 0x90083,

        /// <summary>
        /// <para>
        /// Dismounts a volume regardless of whether or not the volume is currently in use.
        /// For more information, see the Remarks section.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_dismount_volume
        /// </para>
        /// </summary>
        FSCTL_DISMOUNT_VOLUME = 0x90020,

        /// <summary>
        /// <para>
        /// Retrieves the current compression state of a file or directory on a volume whose file system supports per-stream compression.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_get_compression
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_lock_volume
        /// </para>
        /// </summary>
        FSCTL_LOCK_VOLUME = 0x90018,

        /// <summary>
        /// <para>
        /// Marks the indicated file as sparse or not sparse.
        /// In a sparse file, large ranges of zeros may not require disk allocation.
        /// Space for nonzero data will be allocated as needed as the file is written.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_set_sparse?redirectedfrom=MSDN
        /// </para>
        /// </summary>
        FSCTL_SET_SPARSE = 0x900c4,

        /// <summary>
        /// <para>
        /// Creates a new miniversion for the specified file. Miniversions allow you to refer to a snapshot of the file during a transaction.
        /// Miniversions are discarded when a transaction is committed or rolled back.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-fsctl_txfs_create_miniversion
        /// </para>
        /// </summary>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            "Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            "Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            "For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        FSCTL_TXFS_CREATE_MINIVERSION = 0x9817C,

        /// <summary>
        /// <para>
        /// Retrieves the physical location of a specified volume on one or more disks.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winioctl/ni-winioctl-ioctl_volume_get_volume_disk_extents
        /// </para>
        /// </summary>
        IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS = 0x560000,
    }
}
