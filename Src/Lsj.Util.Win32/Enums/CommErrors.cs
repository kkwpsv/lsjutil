namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Comm Errors
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-clearcommerror"/>
    /// </para>
    /// </summary>
    public enum CommErrors : uint
    {
        /// <summary>
        /// The hardware detected a break condition.
        /// </summary>
        CE_BREAK = 0x0010,

        /// <summary>
        /// The hardware detected a framing error.
        /// </summary>
        CE_FRAME = 0x0008,

        /// <summary>
        /// A character-buffer overrun has occurred. The next character is lost.
        /// </summary>
        CE_OVERRUN = 0x0002,

        /// <summary>
        /// An input buffer overflow has occurred.
        /// There is either no room in the input buffer, or a character was received after the end-of-file (EOF) character.
        /// </summary>
        CE_RXOVER = 0x0001,

        /// <summary>
        /// The hardware detected a parity error.
        /// </summary>
        CE_RXPARITY = 0x0004,
    }
}
