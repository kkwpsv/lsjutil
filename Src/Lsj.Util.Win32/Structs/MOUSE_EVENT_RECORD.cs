using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ConsoleModes;
using static Lsj.Util.Win32.Enums.ControlKeyStates;
using static Lsj.Util.Win32.Enums.MouseButtonStates;
using static Lsj.Util.Win32.Enums.MouseEventRecordFlags;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a mouse input event in a console <see cref="INPUT_RECORD"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/console/mouse-event-record-str"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Mouse events are placed in the input buffer when the console is in mouse mode (<see cref="ENABLE_MOUSE_INPUT"/>).
    /// Mouse events are generated whenever the user moves the mouse, or presses or releases one of the mouse buttons.
    /// Mouse events are placed in a console's input buffer only when the console group has the keyboard focus
    /// and the cursor is within the borders of the console's window.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MOUSE_EVENT_RECORD
    {
        /// <summary>
        /// A <see cref="COORD"/> structure that contains the location of the cursor, in terms of the console screen buffer's character-cell coordinates.
        /// </summary>
        public COORD dwMousePosition;

        /// <summary>
        /// The status of the mouse buttons. The least significant bit corresponds to the leftmost mouse button.
        /// The next least significant bit corresponds to the rightmost mouse button. The next bit indicates the next-to-leftmost mouse button.
        /// The bits then correspond left to right to the mouse buttons. A bit is 1 if the button was pressed.
        /// The following constants are defined for the first five mouse buttons.
        /// <see cref="FROM_LEFT_1ST_BUTTON_PRESSED"/>, <see cref="FROM_LEFT_2ND_BUTTON_PRESSED"/>, <see cref="FROM_LEFT_3RD_BUTTON_PRESSED"/>,
        /// <see cref="FROM_LEFT_4TH_BUTTON_PRESSED"/>, <see cref="RIGHTMOST_BUTTON_PRESSED"/>
        /// </summary>
        public MouseButtonStates dwButtonState;

        /// <summary>
        /// The state of the control keys. This member can be one or more of the following values.
        /// <see cref="CAPSLOCK_ON"/>, <see cref="ENHANCED_KEY"/>, <see cref="LEFT_ALT_PRESSED"/>, <see cref="LEFT_CTRL_PRESSED"/>,
        /// <see cref="NUMLOCK_ON"/>, <see cref="RIGHT_ALT_PRESSED"/>, <see cref="RIGHT_CTRL_PRESSED"/>, <see cref="SCROLLLOCK_ON"/>,
        /// <see cref="SHIFT_PRESSED"/>
        /// </summary>
        public ControlKeyStates dwControlKeyState;

        /// <summary>
        /// The type of mouse event.
        /// If this value is zero, it indicates a mouse button being pressed or released.
        /// Otherwise, this member is one of the following values.
        /// <see cref="DOUBLE_CLICK"/>, <see cref="MOUSE_HWHEELED"/>, <see cref="MOUSE_MOVED"/>, <see cref="MOUSE_WHEELED"/>
        /// </summary>
        public MouseEventRecordFlags dwEventFlags;
    }
}
