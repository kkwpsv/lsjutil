namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Settable Stop and Parity bits.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-commprop"/>
    /// </para>
    /// </summary>
    public enum StopAndParityBits : ushort
    {
        /// <summary>
        /// 1 stop bit
        /// </summary>
        STOPBITS_10 = 0x0001,

        /// <summary>
        /// 1.5 stop bits
        /// </summary>
        STOPBITS_15 = 0x0002,

        /// <summary>
        /// 2 stop bits
        /// </summary>
        STOPBITS_20 = 0x0004,

        /// <summary>
        /// No parity
        /// </summary>
        PARITY_NONE = 0x0100,

        /// <summary>
        /// Odd parity
        /// </summary>
        PARITY_ODD = 0x0200,

        /// <summary>
        /// Odd parity
        /// </summary>
        PARITY_EVEN = 0x0400,

        /// <summary>
        /// Mark parity
        /// </summary>
        PARITY_MARK = 0x0800,

        /// <summary>
        /// Space parity
        /// </summary>
        PARITY_SPACE = 0x1000,
    }
}
