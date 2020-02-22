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
        /// Creates a new miniversion for the specified file. Miniversions allow you to refer to a snapshot of the file during a transaction.
        /// Miniversions are discarded when a transaction is committed or rolled back.
        /// </summary>
        [Obsolete("Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs." +
            "Many scenarios that TxF was developed for can be achieved through simpler and more readily available techniques." +
            "Furthermore, TxF may not be available in future versions of Microsoft Windows." +
            "For more information, and alternatives to TxF, please see Alternatives to using Transactional NTFS.")]
        FSCTL_TXFS_CREATE_MINIVERSION = 0x9817C,
    }
}
