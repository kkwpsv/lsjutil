namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Winmm callback types
    /// </summary>
    public enum WinmmCallbackTypes : uint
    {
        /// <summary>
        /// CALLBACK_NULL
        /// </summary>
        CALLBACK_NULL = 0x00000000,

        /// <summary>
        /// CALLBACK_WINDOW
        /// </summary>
        CALLBACK_WINDOW = 0x00010000,

        /// <summary>
        /// CALLBACK_TASK
        /// </summary>
        CALLBACK_TASK = 0x00020000,

        /// <summary>
        /// CALLBACK_FUNCTION
        /// </summary>
        CALLBACK_FUNCTION = 0x00030000,

        /// <summary>
        /// CALLBACK_THREAD
        /// </summary>
        CALLBACK_THREAD = CALLBACK_TASK,

        /// <summary>
        /// CALLBACK_EVENT
        /// </summary>
        CALLBACK_EVENT = 0x00050000,
    }
}
