namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Mouse Event Flags
    /// </summary>
    public enum MouseEventFlags : uint
    {
        /// <summary>
        /// MOUSEEVENTF_MOVE
        /// </summary>
        MOUSEEVENTF_MOVE = 0x0001,

        /// <summary>
        /// MOUSEEVENTF_LEFTDOWN
        /// </summary>
        MOUSEEVENTF_LEFTDOWN = 0x0002,

        /// <summary>
        /// MOUSEEVENTF_LEFTUP
        /// </summary>
        MOUSEEVENTF_LEFTUP = 0x0004,

        /// <summary>
        /// MOUSEEVENTF_RIGHTDOWN
        /// </summary>
        MOUSEEVENTF_RIGHTDOWN = 0x0008,

        /// <summary>
        /// MOUSEEVENTF_RIGHTUP
        /// </summary>
        MOUSEEVENTF_RIGHTUP = 0x0010,

        /// <summary>
        /// MOUSEEVENTF_MIDDLEDOWN
        /// </summary>
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,

        /// <summary>
        /// MOUSEEVENTF_MIDDLEUP
        /// </summary>
        MOUSEEVENTF_MIDDLEUP = 0x0040,

        /// <summary>
        /// MOUSEEVENTF_XDOWN
        /// </summary>
        MOUSEEVENTF_XDOWN = 0x0080,

        /// <summary>
        /// MOUSEEVENTF_XUP
        /// </summary>
        MOUSEEVENTF_XUP = 0x0100,

        /// <summary>
        /// MOUSEEVENTF_WHEEL
        /// </summary>
        MOUSEEVENTF_WHEEL = 0x0800,

        /// <summary>
        /// MOUSEEVENTF_HWHEEL
        /// </summary>
        MOUSEEVENTF_HWHEEL = 0x01000,

        /// <summary>
        /// MOUSEEVENTF_MOVE_NOCOALESCE
        /// </summary>
        MOUSEEVENTF_MOVE_NOCOALESCE = 0x2000,

        /// <summary>
        /// MOUSEEVENTF_VIRTUALDESK
        /// </summary>
        MOUSEEVENTF_VIRTUALDESK = 0x4000,

        /// <summary>
        /// MOUSEEVENTF_ABSOLUTE
        /// </summary>
        MOUSEEVENTF_ABSOLUTE = 0x8000,
    }
}
