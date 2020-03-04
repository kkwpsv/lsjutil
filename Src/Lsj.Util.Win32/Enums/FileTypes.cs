namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// File Type
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/fileapi/nf-fileapi-getfiletype
    /// </para>
    /// </summary>
    public enum FileTypes : uint
    {
        /// <summary>
        /// The specified file is a character file, typically an LPT device or a console.
        /// </summary>
        FILE_TYPE_CHAR = 0x0002,

        /// <summary>
        /// The specified file is a disk file.
        /// </summary>
        FILE_TYPE_DISK = 0x0001,

        /// <summary>
        /// The specified file is a socket, a named pipe, or an anonymous pipe.
        /// </summary>
        FILE_TYPE_PIPE = 0x0003,

        /// <summary>
        /// Unused.
        /// </summary>
        FILE_TYPE_REMOTE = 0x8000,

        /// <summary>
        /// Either the type of the specified file is unknown, or the function failed.
        /// </summary>
        FILE_TYPE_UNKNOWN = 0x0000,
    }
}
