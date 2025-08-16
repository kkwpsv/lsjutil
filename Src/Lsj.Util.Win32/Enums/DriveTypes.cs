namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Driver types
    /// </summary>
    public enum DriveTypes : uint
    {
        /// <summary>
        /// DRIVE_UNKNOWN
        /// </summary>
        DRIVE_UNKNOWN = 0,

        /// <summary>
        /// DRIVE_NO_ROOT_DIR
        /// </summary>
        DRIVE_NO_ROOT_DIR = 1,

        /// <summary>
        /// DRIVE_REMOVABLE
        /// </summary>
        DRIVE_REMOVABLE = 2,

        /// <summary>
        /// DRIVE_FIXED
        /// </summary>
        DRIVE_FIXED = 3,

        /// <summary>
        /// DRIVE_REMOTE
        /// </summary>
        DRIVE_REMOTE = 4,

        /// <summary>
        /// DRIVE_CDROM
        /// </summary>
        DRIVE_CDROM = 5,

        /// <summary>
        /// DRIVE_RAMDISK
        /// </summary>
        DRIVE_RAMDISK = 6,
    }
}
