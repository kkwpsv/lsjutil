namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Process creation desktop app polices
    /// </summary>
    public enum ProcessCreationDesktopAppPolices : uint
    {
        /// <summary>
        /// PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_ENABLE_PROCESS_TREE
        /// </summary>
        PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_ENABLE_PROCESS_TREE = 0x01,

        /// <summary>
        /// PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_DISABLE_PROCESS_TREE
        /// </summary>
        PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_DISABLE_PROCESS_TREE = 0x02,

        /// <summary>
        /// PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_OVERRIDE
        /// </summary>
        PROCESS_CREATION_DESKTOP_APP_BREAKAWAY_OVERRIDE = 0x04,
    }
}
