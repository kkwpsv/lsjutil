namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Driver Types
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getdrivetypew"/>
    /// </para>
    /// </summary>
    public enum DriveTypes : uint
    {
        /// <summary>
        /// The drive type cannot be determined.
        /// </summary>
        DRIVE_UNKNOWN = 0,

        /// <summary>
        /// The root path is invalid; for example, there is no volume mounted at the specified path.
        /// </summary>
        DRIVE_NO_ROOT_DIR = 1,

        /// <summary>
        /// The drive has removable media; for example, a floppy drive, thumb drive, or flash card reader.
        /// </summary>
        DRIVE_REMOVABLE = 2,

        /// <summary>
        /// The drive has fixed media; for example, a hard disk drive or flash drive.
        /// </summary>
        DRIVE_FIXED = 3,

        /// <summary>
        /// The drive is a remote (network) drive.
        /// </summary>
        DRIVE_REMOTE = 4,

        /// <summary>
        /// The drive is a CD-ROM drive.
        /// </summary>
        DRIVE_CDROM = 5,

        /// <summary>
        /// The drive is a RAM disk.
        /// </summary>
        DRIVE_RAMDISK = 6,
    }
}
