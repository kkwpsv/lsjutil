namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The RTS (request-to-send) flow control.
    /// </para>
    /// <para>
    /// <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-dcb"/>
    /// </para>
    /// </summary>
    public enum RTS_CONTROL : uint
    {
        /// <summary>
        /// Disables the RTS line when the device is opened and leaves it disabled.
        /// </summary>
        RTS_CONTROL_DISABLE = 0x00,

        /// <summary>
        /// Enables the RTS line when the device is opened and leaves it on.
        /// </summary>
        RTS_CONTROL_ENABLE = 0x01,

        /// <summary>
        /// Enables RTS handshaking.
        /// The driver raises the RTS line when the "type-ahead" (input) buffer is less than one-half full and lowers the RTS line
        /// when the buffer is more than three-quarters full.
        /// If handshaking is enabled, it is an error for the application to adjust the line by using the <see cref="EscapeCommFunction"/> function.
        /// </summary>
        RTS_CONTROL_HANDSHAKE = 0x02,

        /// <summary>
        /// Specifies that the RTS line will be high if bytes are available for transmission.
        /// sAfter all buffered bytes have been sent, the RTS line will be low.
        /// </summary>
        RTS_CONTROL_TOGGLE = 0x03,
    }
}
