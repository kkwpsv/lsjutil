namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The DTR (data-terminal-ready) flow control.
    /// </para>
    /// <para>
    /// <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-dcb"/>
    /// </para>
    /// </summary>
    public enum DTR_CONTROL : uint
    {
        /// <summary>
        /// Disables the DTR line when the device is opened and leaves it disabled.
        /// </summary>
        DTR_CONTROL_DISABLE = 0x00,

        /// <summary>
        /// Enables the DTR line when the device is opened and leaves it on.
        /// </summary>
        DTR_CONTROL_ENABLE = 0x01,

        /// <summary>
        /// Enables DTR handshaking.
        /// If handshaking is enabled, it is an error for the application to adjust the line by using the <see cref="EscapeCommFunction"/> function.
        /// </summary>
        DTR_CONTROL_HANDSHAKE = 0x02,
    }
}
