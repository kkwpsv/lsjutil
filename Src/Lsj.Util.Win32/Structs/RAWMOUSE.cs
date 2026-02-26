using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the state of the mouse.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawmouse"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the mouse has moved, indicated by <see cref="MOUSE_MOVE_RELATIVE"/> or <see cref="MOUSE_MOVE_ABSOLUTE"/>,
    /// <see cref="lLastX"/> and <see cref="lLastY"/> specify information about that movement.
    /// The information is specified as relative or absolute integer values.
    /// </para>
    /// <para>
    /// If <see cref="MOUSE_MOVE_RELATIVE"/> value is specified,
    /// <see cref="lLastX"/> and <see cref="lLastY"/> specify movement relative to the previous mouse event (the last reported position).
    /// Positive values mean the mouse moved right (or down); negative values mean the mouse moved left (or up).
    /// </para>
    /// <para>
    /// If <see cref="MOUSE_MOVE_ABSOLUTE"/> value is specified,
    /// <see cref="lLastX"/> and <see cref="lLastY"/> contain normalized absolute coordinates between 0 and 65,535.
    /// Coordinate (0,0) maps onto the upper-left corner of the display surface;
    /// coordinate (65535,65535) maps onto the lower-right corner.
    /// In a multimonitor system, the coordinates map to the primary monitor.
    /// </para>
    /// <para>
    /// If <see cref="MOUSE_VIRTUAL_DESKTOP"/> is specified in addition to <see cref="MOUSE_MOVE_ABSOLUTE"/>,
    /// the coordinates map to the entire virtual desktop.C++
    /// </para>
    /// <code>
    /// case WM_INPUT:
    /// {
    ///     UINT dwSize = sizeof(RAWINPUT);
    ///     static BYTE lpb[sizeof(RAWINPUT)];
    /// 
    ///     GetRawInputData((HRAWINPUT)lParam, RID_INPUT, lpb, &amp;dwSize, sizeof(RAWINPUTHEADER));
    /// 
    ///     RAWINPUT* raw = (RAWINPUT*)lpb;
    /// 
    ///     if (raw-&gt;header.dwType == RIM_TYPEMOUSE)
    ///     {
    ///         RAWMOUSE&amp; mouse = raw-&gt;data.mouse;
    /// 
    ///         if (mouse.usFlags &amp; MOUSE_MOVE_ABSOLUTE)
    ///         {
    ///             RECT rect;
    ///             if (mouse.usFlags &amp; MOUSE_VIRTUAL_DESKTOP)
    ///             {
    ///                 rect.left = GetSystemMetrics(SM_XVIRTUALSCREEN);
    ///                 rect.top = GetSystemMetrics(SM_YVIRTUALSCREEN);
    ///                 rect.right = GetSystemMetrics(SM_CXVIRTUALSCREEN);
    ///                 rect.bottom = GetSystemMetrics(SM_CYVIRTUALSCREEN);
    ///             }
    ///             else
    ///             {
    ///                 rect.left = 0;
    ///                 rect.top = 0;
    ///                 rect.right = GetSystemMetrics(SM_CXSCREEN);
    ///                 rect.bottom = GetSystemMetrics(SM_CYSCREEN);
    ///             }
    /// 
    ///             int absoluteX = MulDiv(mouse.lLastX, rect.right, USHRT_MAX) + rect.left;
    ///             int absoluteY = MulDiv(mouse.lLastY, rect.bottom, USHRT_MAX) + rect.top;
    ///             ...
    ///         }
    ///         else if (mouse.lLastX != 0 || mouse.lLastY != 0)
    ///         {
    ///             int relativeX = mouse.lLastX;
    ///             int relativeY = mouse.lLastY;
    ///             ...
    ///         }
    ///         ...
    ///     }
    /// 
    ///     return 0;
    /// }
    /// </code>
    /// <para>
    /// In contrast to legacy <see cref="WM_MOUSEMOVE"/> window messages Raw Input mouse events is not subject to the effects
    /// of the mouse speed set in the Control Panel's Mouse Properties sheet.
    /// See Mouse Input Overview for details.
    /// </para>
    /// <para>
    /// If mouse wheel is moved, indicated by <see cref="RI_MOUSE_WHEEL"/> or <see cref="RI_MOUSE_HWHEEL"/> in <see cref="usButtonFlags"/>,
    /// then <see cref="usButtonData"/> contains a signed <see cref="short"/> value that specifies the distance the wheel is rotated.
    /// </para>
    /// <para>
    /// The wheel rotation will be a multiple of <see cref="WHEEL_DELTA"/>, which is set at 120.
    /// This is the threshold for action to be taken, and one such action (for example, scrolling one increment) should occur for each delta.
    /// </para>
    /// <para>
    /// The delta was set to 120 to allow Microsoft or other vendors to build finer-resolution wheels
    /// (a freely-rotating wheel with no notches) to send more messages per rotation, but with a smaller value in each message.
    /// To use this feature, you can either add the incoming delta values until <see cref="WHEEL_DELTA"/> is reached
    /// (so for a delta-rotation you get the same response), or scroll partial lines in response to the more frequent messages.
    /// You can also choose your scroll granularity and accumulate deltas until it is reached.
    /// </para>
    /// <para>
    /// The application could also retrieve the current lines-to-scroll and characters-to-scroll user setting
    /// by using the <see cref="SystemParametersInfo"/> API
    /// with <see cref="SPI_GETWHEELSCROLLLINES"/> or <see cref="SPI_GETWHEELSCROLLCHARS"/> parameter.
    /// </para>
    /// <para>
    /// Here is example of such wheel handling code:
    /// </para>
    /// <code>
    /// RAWMOUSE&amp; mouse = raw-&gt;data.mouse;
    /// 
    /// if ((mouse.usButtonFlags &amp; RI_MOUSE_WHEEL) || (mouse.usButtonFlags &amp; RI_MOUSE_HWHEEL))
    /// {
    ///     short wheelDelta = (short)mouse.usButtonData;
    ///     float scrollDelta = (float)wheelDelta / WHEEL_DELTA;
    /// 
    ///     if (mouse.usButtonFlags &amp; RI_MOUSE_HWHEEL) // Horizontal
    ///     {
    ///         unsigned long scrollChars = 1; // 1 is the default
    ///         SystemParametersInfo(SPI_GETWHEELSCROLLCHARS, 0, &amp;scrollChars, 0);
    ///         scrollDelta *= scrollChars;
    ///         ...
    ///     }
    ///     else // Vertical
    ///     {
    ///         unsigned long scrollLines = 3; // 3 is the default
    ///         SystemParametersInfo(SPI_GETWHEELSCROLLLINES, 0, &amp;scrollLines, 0);
    ///         if (scrollLines != WHEEL_PAGESCROLL)
    ///             scrollDelta *= scrollLines;
    ///         ...
    ///     }
    /// }
    /// </code>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct RAWMOUSE
    {
        /// <summary>
        /// <para>
        /// The mouse state.
        /// This member can be any reasonable combination of the following.
        /// </para>
        /// <para>
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
        /// <see cref="MOUSE_MOVE_RELATIVE"/>
        /// </para>
        /// <para>
        /// 0x00
        /// </para>
        /// </term>
        /// <term>
        /// Mouse movement data is relative to the last mouse position.
        /// For further information about mouse motion, see the following Remarks section.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSE_MOVE_ABSOLUTE"/>
        /// </para>
        /// <para>
        /// 0x01
        /// </para>
        /// </term>
        /// <term>
        /// Mouse movement data is based on absolute position.
        /// For further information about mouse motion, see the following Remarks section.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSE_VIRTUAL_DESKTOP"/>
        /// </para>
        /// <para>
        /// 0x02
        /// </para>
        /// </term>
        /// <term>
        /// Mouse coordinates are mapped to the virtual desktop (for a multiple monitor system).
        /// For further information about mouse motion, see the following Remarks section.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSE_ATTRIBUTES_CHANGED"/>
        /// </para>
        /// <para>
        /// 0x04
        /// </para>
        /// </term>
        /// <term>
        /// Mouse attributes changed; application needs to query the mouse attributes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSE_MOVE_NOCOALESCE"/>
        /// </para>
        /// <para>
        /// 0x08
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// This mouse movement event was not coalesced.
        /// Mouse movement events can be coalesced by default.
        /// </para>
        /// <para>
        /// Windows XP/2000: This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        [FieldOffset(0)]
        public USHORT usFlags;

        /// <summary>
        /// Reserved.
        /// </summary>
        [FieldOffset(2)]
        public ULONG ulButtons;

        /// <summary>
        /// <para>
        /// The transition state of the mouse buttons.
        /// This member can be one or more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="RI_MOUSE_BUTTON_1_DOWN"/>
        /// </para>
        /// <para>
        /// <see cref="RI_MOUSE_LEFT_BUTTON_DOWN"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Left button changed to down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RI_MOUSE_BUTTON_1_UP"/>
        /// </para>
        /// <para>
        /// <see cref="RI_MOUSE_LEFT_BUTTON_UP"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Left button changed to up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RI_MOUSE_BUTTON_2_DOWN"/>
        /// </para>
        /// <para>
        /// <see cref="RI_MOUSE_RIGHT_BUTTON_DOWN"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// Right button changed to down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RI_MOUSE_BUTTON_2_UP"/>
        /// </para>
        /// <para>
        /// <see cref="RI_MOUSE_RIGHT_BUTTON_UP"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// Right button changed to up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RI_MOUSE_BUTTON_3_DOWN"/>
        /// </para>
        /// <para>
        /// <see cref="RI_MOUSE_MIDDLE_BUTTON_DOWN"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// Middle button changed to down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RI_MOUSE_BUTTON_3_UP"/>
        /// </para>
        /// <para>
        /// <see cref="RI_MOUSE_MIDDLE_BUTTON_UP"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// Middle button changed to up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RI_MOUSE_BUTTON_4_DOWN"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// XBUTTON1 changed to down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RI_MOUSE_BUTTON_4_UP"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// XBUTTON1 changed to up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RI_MOUSE_BUTTON_5_DOWN"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// XBUTTON2 changed to down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RI_MOUSE_BUTTON_5_UP"/>
        /// </para>
        /// <para>
        /// 0x0200
        /// </para>
        /// </term>
        /// <term>
        /// XBUTTON2 changed to up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RI_MOUSE_WHEEL"/>
        /// </para>
        /// <para>
        /// 0x0400
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Raw input comes from a mouse wheel.
        /// The wheel delta is stored in <see cref="usButtonData"/>.
        /// </para>
        /// <para>
        /// A positive value indicates that the wheel was rotated forward, away from the user;
        /// a negative value indicates that the wheel was rotated backward, toward the user.
        /// For further information see the following Remarks section.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RI_MOUSE_HWHEEL"/>
        /// </para>
        /// <para>
        /// 0x0800
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Raw input comes from a horizontal mouse wheel.
        /// The wheel delta is stored in <see cref="usButtonData"/>.
        /// </para>
        /// <para>
        /// A positive value indicates that the wheel was rotated to the right;
        /// a negative value indicates that the wheel was rotated to the left.
        /// For further information see the following Remarks section.
        /// </para>
        /// <para>
        /// Windows XP/2000: This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        [FieldOffset(6)]
        public USHORT usButtonFlags;

        /// <summary>
        /// If <see cref="usButtonFlags"/> has <see cref="RI_MOUSE_WHEEL"/> or <see cref="RI_MOUSE_HWHEEL"/>,
        /// this member specifies the distance the wheel is rotated.
        /// For further information see the following Remarks section.
        /// </summary>
        [FieldOffset(6)]
        public USHORT usButtonData;

        /// <summary>
        /// The raw state of the mouse buttons.
        /// The Win32 subsystem does not use this member.
        /// </summary>
        [FieldOffset(8)]
        public ULONG ulRawButtons;

        /// <summary>
        /// The motion in the X direction.
        /// This is signed relative motion or absolute motion, depending on the value of <see cref="usFlags"/>.
        /// </summary>
        [FieldOffset(12)]
        public LONG lLastX;

        /// <summary>
        /// The motion in the Y direction.
        /// This is signed relative motion or absolute motion, depending on the value of <see cref="usFlags"/>.
        /// </summary>
        [FieldOffset(16)]
        public LONG lLastY;

        /// <summary>
        /// Additional device-specific information for the event.
        /// See Distinguishing Pen Input from Mouse and Touch for more info.
        /// </summary>
        [FieldOffset(20)]
        public ULONG ulExtraInformation;
    }
}
