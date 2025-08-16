using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ConsoleModes;
using static Lsj.Util.Win32.Enums.ConsoleControlKeyStates;
using static Lsj.Util.Win32.Enums.MouseButtonStates;
using static Lsj.Util.Win32.Enums.MouseEventTypes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes a mouse input event in a console <see cref="INPUT_RECORD"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/mouse-event-record-str"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Mouse events are placed in the input buffer when the console is in mouse mode (<see cref="ENABLE_MOUSE_INPUT"/>).
    /// </para>
    /// <para>
    /// Mouse events are generated whenever the user moves the mouse, or presses or releases one of the mouse buttons.
    /// Mouse events are placed in a console's input buffer only when the console group has the keyboard focus
    /// and the cursor is within the borders of the console's window.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MOUSE_EVENT_RECORD
    {
        /// <summary>
        /// A <see cref="COORD"/> structure that contains the location of the cursor, in terms of the console screen buffer's character-cell coordinates.
        /// </summary>
        public COORD dwMousePosition;

        /// <summary>
        /// <para>
        /// The status of the mouse buttons.
        /// The least significant bit corresponds to the leftmost mouse button.
        /// The next least significant bit corresponds to the rightmost mouse button.
        /// The next bit indicates the next-to-leftmost mouse button.
        /// The bits then correspond left to right to the mouse buttons.
        /// A bit is 1 if the button was pressed.
        /// </para>
        /// <para>
        /// The following constants are defined for the first five mouse buttons.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="FROM_LEFT_1ST_BUTTON_PRESSED"/> 0x0001
        /// </term>
        /// <term>
        /// The leftmost mouse button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FROM_LEFT_2ND_BUTTON_PRESSED"/> 0x0004
        /// </term>
        /// <term>
        /// The second button fom the left.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FROM_LEFT_3RD_BUTTON_PRESSED"/> 0x0008
        /// </term>
        /// <term>
        /// The third button from the left.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FROM_LEFT_4TH_BUTTON_PRESSED"/> 0x0010
        /// </term>
        /// <term>
        /// The fourth button from the left.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RIGHTMOST_BUTTON_PRESSED"/> 0x0002
        /// </term>
        /// <term>
        /// The rightmost mouse button.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public MouseButtonStates dwButtonState;

        /// <summary>
        /// <para>
        /// The state of the control keys. This member can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="CAPSLOCK_ON"/> 0x0080
        /// </term>
        /// <term>
        /// The CAPS LOCK light is on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ENHANCED_KEY"/> 0x0100
        /// </term>
        /// <term>
        /// The key is enhanced. See remarks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LEFT_ALT_PRESSED"/> 0x0002
        /// </term>
        /// <term>
        /// The left ALT key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LEFT_CTRL_PRESSED"/> 0x0008
        /// </term>
        /// <term>
        /// The left CTRL key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NUMLOCK_ON"/> 0x0020
        /// </term>
        /// <term>
        /// The NUM LOCK light is on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RIGHT_ALT_PRESSED"/> 0x0001
        /// </term>
        /// <term>
        /// The right ALT key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RIGHT_CTRL_PRESSED"/> 0x0004
        /// </term>
        /// <term>
        /// The right CTRL key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SCROLLLOCK_ON"/> 0x0040
        /// </term>
        /// <term>
        /// The SCROLL LOCK light is on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SHIFT_PRESSED"/> 0x0010
        /// </term>
        /// <term>
        /// The SHIFT key is pressed.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public ConsoleControlKeyStates dwControlKeyState;

        /// <summary>
        /// <para>
        /// The type of mouse event.
        /// If this value is zero, it indicates a mouse button being pressed or released.
        /// Otherwise, this member is one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="DOUBLE_CLICK"/> 0x0002
        /// </term>
        /// <term>
        /// The second click (button press) of a double-click occurred.
        /// The first click is returned as a regular button-press event.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MOUSE_HWHEELED"/> 0x0008
        /// </term>
        /// <term>
        /// <para>
        /// The horizontal mouse wheel was moved.
        /// </para>
        /// <para>
        /// If the high word of the <see cref="dwButtonState"/> member contains a positive value, the wheel was rotated to the right. Otherwise, the wheel was rotated to the left.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MOUSE_MOVED"/> 0x0001
        /// </term>
        /// <term>
        /// A change in mouse position occurred.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MOUSE_WHEELED"/> 0x0004
        /// </term>
        /// <term>
        /// <para>
        /// The vertical mouse wheel was moved.
        /// </para>
        /// <para>
        /// If the high word of the <see cref="dwButtonState"/> member contains a positive value, the wheel was rotated forward, away from the user.
        /// Otherwise, the wheel was rotated backward, toward the user.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public MouseEventTypes dwEventFlags;
    }
}
