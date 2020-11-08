namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Shell File Operations
    /// </summary>
    public enum ShellFileOperations : uint
    {
        /// <summary>
        /// FO_MOVE
        /// </summary>
        FO_MOVE = 0x0001,

        /// <summary>
        /// FO_COPY
        /// </summary>
        FO_COPY = 0x0002,

        /// <summary>
        /// FO_DELETE
        /// </summary>
        FO_DELETE = 0x0003,

        /// <summary>
        /// FO_RENAME
        /// </summary>
        FO_RENAME = 0x0004,
    }
}
