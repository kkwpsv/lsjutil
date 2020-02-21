namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Ctrl Event Flags
    /// </para>
    /// </summary>
    public enum CtrlEventFlags : uint
    {
        /// <summary>
        /// CTRL_C_EVENT
        /// </summary>
        CTRL_C_EVENT = 0,

        /// <summary>
        /// CTRL_BREAK_EVENT
        /// </summary>
        CTRL_BREAK_EVENT = 1,

        /// <summary>
        /// CTRL_CLOSE_EVENT
        /// </summary>
        CTRL_CLOSE_EVENT = 2,

        /// <summary>
        /// CTRL_LOGOFF_EVENT
        /// </summary>
        CTRL_LOGOFF_EVENT = 5,

        /// <summary>
        /// CTRL_SHUTDOWN_EVENT
        /// </summary>
        CTRL_SHUTDOWN_EVENT = 6,
    }
}
