namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Comm provider settable parameters.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-commprop"/>
    /// </para>
    /// </summary>
    public enum SP : uint
    {
        /// <summary>
        /// Parity
        /// </summary>
        SP_PARITY = 0x0001,

        /// <summary>
        /// Baud rate
        /// </summary>
        SP_BAUD = 0x0002,

        /// <summary>
        /// Data bits
        /// </summary>
        SP_DATABITS = 0x0004,

        /// <summary>
        /// Stop bits
        /// </summary>
        SP_STOPBITS = 0x0008,

        /// <summary>
        /// Handshaking (flow control)
        /// </summary>
        SP_HANDSHAKING = 0x0010,

        /// <summary>
        /// Parity checking
        /// </summary>
        SP_PARITY_CHECK = 0x0020,

        /// <summary>
        /// RLSD (receive-line-signal-detect)
        /// </summary>
        SP_RLSD = 0x0040,
    }
}
