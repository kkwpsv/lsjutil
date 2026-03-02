namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The type of device that sent the input message.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-input_message_device_type"/>
    /// </para>
    /// </summary>
    public enum INPUT_MESSAGE_DEVICE_TYPE
    {
        /// <summary>
        /// The device type isn't identified.
        /// </summary>
        IMDT_UNAVAILABLE = 0x00000000,

        /// <summary>
        /// Keyboard input.
        /// </summary>
        IMDT_KEYBOARD = 0x00000001,

        /// <summary>
        /// Mouse input.
        /// </summary>
        IMDT_MOUSE = 0x00000002,

        /// <summary>
        /// Touch input.
        /// </summary>
        IMDT_TOUCH = 0x00000004,

        /// <summary>
        /// Pen or stylus input.
        /// </summary>
        IMDT_PEN = 0x00000008,

        /// <summary>
        /// Touchpad input (Windows 8.1 and later).
        /// </summary>
        IMDT_TOUCHPAD = 0x00000010
    }
}
