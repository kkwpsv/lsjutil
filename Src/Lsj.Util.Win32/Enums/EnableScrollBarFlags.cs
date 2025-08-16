using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="EnableScrollBar"/> flags
    /// </summary>
    public enum EnableScrollBarFlags : uint
    {
        /// <summary>
        /// ESB_ENABLE_BOTH
        /// </summary>
        ESB_ENABLE_BOTH = 0x0000,

        /// <summary>
        /// ESB_DISABLE_BOTH
        /// </summary>
        ESB_DISABLE_BOTH = 0x0003,

        /// <summary>
        /// ESB_DISABLE_LEFT
        /// </summary>
        ESB_DISABLE_LEFT = 0x0001,

        /// <summary>
        /// ESB_DISABLE_RIGHT
        /// </summary>
        ESB_DISABLE_RIGHT = 0x0002,

        /// <summary>
        /// ESB_DISABLE_UP
        /// </summary>
        ESB_DISABLE_UP = 0x0001,

        /// <summary>
        /// ESB_DISABLE_DOWN
        /// </summary>
        ESB_DISABLE_DOWN = 0x0002,

        /// <summary>
        /// ESB_DISABLE_LTUP
        /// </summary>
        ESB_DISABLE_LTUP = ESB_DISABLE_LEFT,

        /// <summary>
        /// ESB_DISABLE_RTDN
        /// </summary>
        ESB_DISABLE_RTDN = ESB_DISABLE_RIGHT,
    }
}
