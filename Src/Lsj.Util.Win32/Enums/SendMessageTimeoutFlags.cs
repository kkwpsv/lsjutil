using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="SendMessageTimeout"/> flags
    /// </summary>
    public enum SendMessageTimeoutFlags : uint
    {
        /// <summary>
        /// SMTO_ABORTIFHUNG
        /// </summary>
        SMTO_ABORTIFHUNG = 0x0002,

        /// <summary>
        /// SMTO_BLOCK
        /// </summary>
        SMTO_BLOCK = 0x0001,

        /// <summary>
        /// SMTO_NORMAL
        /// </summary>
        SMTO_NORMAL = 0x0000,

        /// <summary>
        /// SMTO_NOTIMEOUTIFNOTHUNG
        /// </summary>
        SMTO_NOTIMEOUTIFNOTHUNG = 0x0008,

        /// <summary>
        /// SMTO_ERRORONEXIT
        /// </summary>
        SMTO_ERRORONEXIT = 0x0020,
    }
}
