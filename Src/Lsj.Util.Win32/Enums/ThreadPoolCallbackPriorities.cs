namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Thread pool callback priorities
    /// </summary>
    public enum ThreadPoolCallbackPriorities
    {
        /// <summary>
        /// TP_CALLBACK_PRIORITY_HIGH
        /// </summary>
        TP_CALLBACK_PRIORITY_HIGH,

        /// <summary>
        /// TP_CALLBACK_PRIORITY_NORMAL
        /// </summary>
        TP_CALLBACK_PRIORITY_NORMAL,

        /// <summary>
        /// TP_CALLBACK_PRIORITY_LOW
        /// </summary>
        TP_CALLBACK_PRIORITY_LOW,

        /// <summary>
        /// TP_CALLBACK_PRIORITY_INVALID
        /// </summary>
        TP_CALLBACK_PRIORITY_INVALID,

        /// <summary>
        /// TP_CALLBACK_PRIORITY_COUNT
        /// </summary>
        TP_CALLBACK_PRIORITY_COUNT = TP_CALLBACK_PRIORITY_INVALID,
    }
}
