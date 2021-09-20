namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Provider capabilities flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-commprop"/>
    /// </para>
    /// </summary>
    public enum PCF : uint
    {
        /// <summary>
        /// DTR (data-terminal-ready)/DSR (data-set-ready) supported
        /// </summary>
        PCF_DTRDSR = 0x0001,

        /// <summary>
        /// RTS (request-to-send)/CTS (clear-to-send) supported
        /// </summary>
        PCF_RTSCTS = 0x0002,

        /// <summary>
        /// RLSD (receive-line-signal-detect) supported
        /// </summary>
        PCF_RLSD = 0x0004,

        /// <summary>
        /// Parity checking supported
        /// </summary>
        PCF_PARITY_CHECK = 0x0008,

        /// <summary>
        /// XON/XOFF flow control supported
        /// </summary>
        PCF_XONXOFF = 0x0010,

        /// <summary>
        /// Settable XON/XOFF supported
        /// </summary>
        PCF_SETXCHAR = 0x0020,

        /// <summary>
        /// The total (elapsed) time-outs supported
        /// </summary>
        PCF_TOTALTIMEOUTS = 0x0040,

        /// <summary>
        /// Interval time-outs supported
        /// </summary>
        PCF_INTTIMEOUTS = 0x0080,

        /// <summary>
        /// Special character support provided
        /// </summary>
        PCF_SPECIALCHARS = 0x0100,

        /// <summary>
        /// Special 16-bit mode supported
        /// </summary>
        PCF_16BITMODE = 0x0200,
    }
}
