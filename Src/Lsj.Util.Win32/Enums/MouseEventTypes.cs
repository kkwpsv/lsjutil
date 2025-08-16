namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Mouse event types
    /// </summary>
    public enum MouseEventTypes : uint
    {
        /// <summary>
        /// MOUSE_MOVED
        /// </summary>
        MOUSE_MOVED = 0x0001,

        /// <summary>
        /// DOUBLE_CLICK
        /// </summary>
        DOUBLE_CLICK = 0x0002,

        /// <summary>
        /// MOUSE_WHEELED
        /// </summary>
        MOUSE_WHEELED = 0x0004,

        /// <summary>
        /// MOUSE_HWHEELED
        /// </summary>
        MOUSE_HWHEELED = 0x0008,
    }
}
