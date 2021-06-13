using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="MOUSE_EVENT_RECORD"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/console/mouse-event-record-str"/>
    /// </para>
    /// </summary>
    public enum MouseEventRecordFlags : uint
    {
        /// <summary>
        /// The second click (button press) of a double-click occurred.
        /// The first click is returned as a regular button-press event.
        /// </summary>
        MOUSE_MOVED = 0x0001,

        /// <summary>
        /// The horizontal mouse wheel was moved.
        /// If the high word of the <see cref="MOUSE_EVENT_RECORD.dwButtonState"/> member contains a positive value, the wheel was rotated to the right.
        /// Otherwise, the wheel was rotated to the left.
        /// </summary>
        DOUBLE_CLICK = 0x0002,

        /// <summary>
        /// A change in mouse position occurred.
        /// </summary>
        MOUSE_WHEELED = 0x0004,

        /// <summary>
        /// The vertical mouse wheel was moved.
        /// If the high word of the <see cref="MOUSE_EVENT_RECORD.dwButtonState"/> member contains a positive value, 
        /// the wheel was rotated forward, away from the user. Otherwise, the wheel was rotated backward, toward the user.
        /// </summary>
        MOUSE_HWHEELED = 0x0008,
    }
}
