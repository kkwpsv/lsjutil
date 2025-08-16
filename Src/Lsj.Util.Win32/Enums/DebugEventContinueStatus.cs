namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Debug event continue status
    /// </summary>
    public enum DebugEventContinueStatus : uint
    {
        /// <summary>
        /// DBG_CONTINUE
        /// </summary>
        DBG_CONTINUE = 0x00010002,

        /// <summary>
        /// DBG_EXCEPTION_NOT_HANDLED
        /// </summary>
        DBG_EXCEPTION_NOT_HANDLED = 0x80010001,

        /// <summary>
        /// DBG_REPLY_LATER
        /// </summary>
        DBG_REPLY_LATER = 0x40010001,
    }
}
