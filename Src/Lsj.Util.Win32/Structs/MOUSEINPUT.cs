using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.MouseEventFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a simulated mouse event.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mouseinput"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the mouse has moved, indicated by <see cref="MOUSEEVENTF_MOVE"/>,
    /// <see cref="dx"/> and <see cref="dy"/> specify information about that movement.
    /// The information is specified as absolute or relative integer values.
    /// </para>
    /// <para>
    /// If <see cref="MOUSEEVENTF_ABSOLUTE"/> value is specified,
    /// <see cref="dx"/> and <see cref="dy"/> contain normalized absolute coordinates between 0 and 65,535.
    /// The event procedure maps these coordinates onto the display surface.
    /// Coordinate (0,0) maps onto the upper-left corner of the display surface; coordinate (65535,65535) maps onto the lower-right corner.
    /// In a multimonitor system, the coordinates map to the primary monitor.
    /// </para>
    /// <para>
    /// If <see cref="MOUSEEVENTF_VIRTUALDESK"/> is specified, the coordinates map to the entire virtual desktop.
    /// </para>
    /// <para>
    /// If the <see cref="MOUSEEVENTF_ABSOLUTE"/> value is not specified,
    /// <see cref="dx"/> and <see cref="dy"/> specify movement relative to the previous mouse event (the last reported position).
    /// Positive values mean the mouse moved right (or down); negative values mean the mouse moved left (or up).
    /// </para>
    /// <para>
    /// Relative mouse motion is subject to the effects of the mouse speed and the two-mouse threshold values.
    /// A user sets these three values with the Pointer Speed slider of the Control Panel's Mouse Properties sheet.
    /// You can obtain and set these values using the <see cref="SystemParametersInfo"/> function.
    /// </para>
    /// <para>
    /// The system applies two tests to the specified relative mouse movement.
    /// If the specified distance along either the x or y axis is greater than the first mouse threshold value,
    /// and the mouse speed is not zero, the system doubles the distance.
    /// If the specified distance along either the x or y axis is greater than the second mouse threshold value,
    /// and the mouse speed is equal to two, the system doubles the distance that resulted from applying the first threshold test.
    /// It is thus possible for the system to multiply specified relative mouse movement along the x or y axis by up to four times.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MOUSEINPUT
    {
        /// <summary>
        /// The absolute position of the mouse, or the amount of motion since the last mouse event was generated,
        /// depending on the value of the <see cref="dwFlags"/> member.
        /// Absolute data is specified as the x coordinate of the mouse; relative data is specified as the number of pixels moved.
        /// </summary>
        public LONG dx;

        /// <summary>
        /// The absolute position of the mouse, or the amount of motion since the last mouse event was generated,
        /// depending on the value of the <see cref="dwFlags"/> member.
        /// Absolute data is specified as the y coordinate of the mouse; relative data is specified as the number of pixels moved.
        /// </summary>
        public LONG dy;

        /// <summary>
        /// <para>
        /// If <see cref="dwFlags"/> contains <see cref="MOUSEEVENTF_WHEEL"/>, then <see cref="mouseData"/> specifies the amount of wheel movement.
        /// A positive value indicates that the wheel was rotated forward, away from the user;
        /// a negative value indicates that the wheel was rotated backward, toward the user.
        /// One wheel click is defined as <see cref="WHEEL_DELTA"/>, which is 120.
        /// </para>
        /// <para>
        /// Windows Vista: If <see cref="dwFlags"/> contains <see cref="MOUSEEVENTF_HWHEEL"/>, then <see cref="mouseData"/> specifies the amount of wheel movement.
        /// A positive value indicates that the wheel was rotated to the right; a negative value indicates that the wheel was rotated to the left.
        /// One wheel click is defined as <see cref="WHEEL_DELTA"/>, which is 120.
        /// </para>
        /// <para>
        /// If <see cref="dwFlags"/> does not contain <see cref="MOUSEEVENTF_WHEEL"/>, <see cref="MOUSEEVENTF_XDOWN"/>,
        /// or <see cref="MOUSEEVENTF_XUP"/>, then <see cref="mouseData"/> should be zero.
        /// </para>
        /// <para>
        /// If <see cref="dwFlags"/> contains <see cref="MOUSEEVENTF_XDOWN"/> or <see cref="MOUSEEVENTF_XUP"/>,
        /// then <see cref="mouseData"/> specifies which X buttons were pressed or released.
        /// This value may be any combination of the following flags.
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
        /// <para>
        /// <see cref="XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Set if the first X button is pressed or released.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Set if the second X button is pressed or released.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public DWORD mouseData;

        /// <summary>
        /// <para>
        /// A set of bit flags that specify various aspects of mouse motion and button clicks.
        /// The bits in this member can be any reasonable combination of the following values.
        /// </para>
        /// <para>
        /// The bit flags that specify mouse button status are set to indicate changes in status, not ongoing conditions.
        /// For example, if the left mouse button is pressed and held down,
        /// <see cref="MOUSEEVENTF_LEFTDOWN"/> is set when the left button is first pressed, but not for subsequent motions.
        /// Similarly <see cref="MOUSEEVENTF_LEFTUP"/> is set only when the button is first released.
        /// </para>
        /// <para>
        /// You cannot specify both the <see cref="MOUSEEVENTF_WHEEL"/> flag and either <see cref="MOUSEEVENTF_XDOWN"/>
        /// or <see cref="MOUSEEVENTF_XUP"/> flags simultaneously in the <see cref="dwFlags"/> parameter,
        /// because they both require use of the <see cref="mouseData"/> field.
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
        /// <para>
        /// <see cref="MOUSEEVENTF_MOVE"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Movement occurred.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_LEFTDOWN"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The left button was pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_LEFTUP"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The left button was released.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_RIGHTDOWN"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The right button was pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_RIGHTUP"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The right button was released.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_MIDDLEDOWN"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The middle button was pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_MIDDLEUP"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The middle button was released.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_XDOWN"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// An X button was pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_XUP"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// An X button was released.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_WHEEL"/>
        /// </para>
        /// <para>
        /// 0x0800
        /// </para>
        /// </term>
        /// <term>
        /// The wheel was moved, if the mouse has a wheel.
        /// The amount of movement is specified in <see cref="mouseData"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_HWHEEL"/>
        /// </para>
        /// <para>
        /// 0x1000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The wheel was moved horizontally, if the mouse has a wheel.
        /// The amount of movement is specified in <see cref="mouseData"/>.
        /// </para>
        /// <para>
        /// Windows XP/2000: This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_MOVE_NOCOALESCE"/>
        /// </para>
        /// <para>
        /// 0x2000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <see cref="WM_MOUSEMOVE"/> messages will not be coalesced.
        /// The default behavior is to coalesce <see cref="WM_MOUSEMOVE"/> messages.
        /// </para>
        /// <para>
        /// Windows XP/2000: This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_VIRTUALDESK"/>
        /// </para>
        /// <para>
        /// 0x4000
        /// </para>
        /// </term>
        /// <term>
        /// Maps coordinates to the entire desktop.
        /// Must be used with <see cref="MOUSEEVENTF_ABSOLUTE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_ABSOLUTE"/>
        /// </para>
        /// <para>
        /// 0x8000
        /// </para>
        /// </term>
        /// <term>
        /// The dx and dy members contain normalized absolute coordinates.
        /// If the flag is not set, dxand dy contain relative data (the change in position since the last reported position).
        /// This flag can be set, or not set, regardless of what kind of mouse or other pointing device, if any, is connected to the system.
        /// For further information about relative mouse motion, see the following Remarks section.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public MouseEventFlags dwFlags;

        /// <summary>
        /// The time stamp for the event, in milliseconds.
        /// If this parameter is 0, the system will provide its own time stamp.
        /// </summary>
        public DWORD time;

        /// <summary>
        /// An additional value associated with the mouse event.
        /// An application calls <see cref="GetMessageExtraInfo"/> to obtain this extra information.
        /// </summary>
        public ULONG_PTR dwExtraInfo;
    }
}
