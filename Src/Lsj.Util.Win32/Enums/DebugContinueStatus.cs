namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// DebugContinueStatus
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/debugapi/nf-debugapi-continuedebugevent
    /// </para>
    /// </summary>
    public enum DebugContinueStatus : uint
    {
        /// <summary>
        /// If the thread specified by the dwThreadId parameter previously reported an <see cref="EXCEPTION_DEBUG_EVENT"/> debugging event,
        /// the function stops all exception processing and continues the thread and the exception is marked as handled.
        /// For any other debugging event, this flag simply continues the thread.
        /// </summary>
        DBG_CONTINUE = 0x00010002,

        /// <summary>
        /// If the thread specified by dwThreadId previously reported an <see cref="EXCEPTION_DEBUG_EVENT"/> debugging event,
        /// the function continues exception processing.
        /// If this is a first-chance exception event, the search and dispatch logic of the structured exception handler is used;
        /// otherwise, the process is terminated. For any other debugging event, this flag simply continues the thread.
        /// </summary>
        DBG_EXCEPTION_NOT_HANDLED = 0x80010001,

        /// <summary>
        /// Supported in Windows 10, version 1507 or above, this flag causes dwThreadId to replay the existing breaking event after the target continues.
        /// By calling the <see cref="SuspendThread"/> API against dwThreadId,
        /// a debugger can resume other threads in the process and later return to the breaking.
        /// </summary>
        DBG_REPLY_LATER = 0x40010001,
    }
}
