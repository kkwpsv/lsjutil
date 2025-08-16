using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="INPUT_RECORD"/> event type
    /// </summary>
    public enum InputRecordEventTypes : ushort
    {
        /// <summary>
        /// KEY_EVENT
        /// </summary>
        KEY_EVENT = 0x0001,

        /// <summary>
        /// MOUSE_EVENT
        /// </summary>
        MOUSE_EVENT = 0x0002,

        /// <summary>
        /// WINDOW_BUFFER_SIZE_EVENT
        /// </summary>
        WINDOW_BUFFER_SIZE_EVENT = 0x0004,

        /// <summary>
        /// MENU_EVENT
        /// </summary>
        MENU_EVENT = 0x0008,

        /// <summary>
        /// FOCUS_EVENT
        /// </summary>
        FOCUS_EVENT = 0x0010,
    }
}
