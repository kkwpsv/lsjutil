namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// File share modes
    /// </summary>
    public enum FileShareModes : uint
    {
        /// <summary>
        /// FILE_SHARE_DELETE
        /// </summary>
        FILE_SHARE_DELETE = 0x00000004,

        /// <summary>
        /// FILE_SHARE_READ
        /// </summary>
        FILE_SHARE_READ = 0x00000001,

        /// <summary>
        /// FILE_SHARE_WRITE
        /// </summary>
        FILE_SHARE_WRITE = 0x00000002,
    }
}
