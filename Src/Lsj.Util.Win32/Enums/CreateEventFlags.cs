namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Create event flags
    /// </summary>
    public enum CreateEventFlags : uint
    {
        /// <summary>
        /// CREATE_EVENT_INITIAL_SET
        /// </summary>
        CREATE_EVENT_INITIAL_SET = 0x00000002,

        /// <summary>
        /// CREATE_EVENT_MANUAL_RESET
        /// </summary>
        CREATE_EVENT_MANUAL_RESET = 0x00000001,
    }
}
