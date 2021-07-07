using System;
using static Lsj.Util.Win32.Enums.WindowsMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Trackbar Styles
    /// </para>
    /// <para>
    /// <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/trackbar-control-styles"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum TrackbarControlStyles : uint
    {
        /// <summary>
        /// The trackbar control has a tick mark for each increment in its range of values.
        /// </summary>
        TBS_AUTOTICKS = 0x0001,

        /// <summary>
        /// The trackbar control is oriented vertically.
        /// </summary>
        TBS_VERT = 0x0002,

        /// <summary>
        /// The trackbar control is oriented horizontally. This is the default orientation.
        /// </summary>
        TBS_HORZ = 0x0000,

        /// <summary>
        /// The trackbar control displays tick marks above the control.
        /// This style is valid only with <see cref="TBS_HORZ"/>.
        /// </summary>
        TBS_TOP = 0x0004,

        /// <summary>
        /// The trackbar control displays tick marks below the control.
        /// This style is valid only with <see cref="TBS_HORZ"/>.
        /// </summary>
        TBS_BOTTOM = 0x0000,

        /// <summary>
        /// The trackbar control displays tick marks to the left of the control.
        /// This style is valid only with <see cref="TBS_VERT"/>.
        /// </summary>
        TBS_LEFT = 0x0004,

        /// <summary>
        /// The trackbar control displays tick marks to the right of the control.
        /// This style is valid only with <see cref="TBS_VERT"/>.
        /// </summary>
        TBS_RIGHT = 0x0000,

        /// <summary>
        /// The trackbar control displays tick marks on both sides of the control.
        /// This will be both top and bottom when used with <see cref="TBS_HORZ"/> or both left and right if used with <see cref="TBS_VERT"/>.
        /// </summary>
        TBS_BOTH = 0x0008,

        /// <summary>
        /// The trackbar control does not display any tick marks.
        /// </summary>
        TBS_NOTICKS = 0x0010,

        /// <summary>
        /// The trackbar control displays a selection range only.
        /// The tick marks at the starting and ending positions of a selection range are displayed as triangles (instead of vertical dashes), and the selection range is highlighted.
        /// </summary>
        TBS_ENABLESELRANGE = 0x0020,

        /// <summary>
        /// The trackbar control allows the size of the slider to be changed with the <see cref="TBM_SETTHUMBLENGTH"/> message.
        /// </summary>
        TBS_FIXEDLENGTH = 0x0040,

        /// <summary>
        /// The trackbar control does not display a slider.
        /// </summary>
        TBS_NOTHUMB = 0x0080,

        /// <summary>
        /// Version 4.70.
        /// The trackbar control supports tooltips.
        /// When a trackbar control is created using this style, it automatically creates a default tooltip control that displays the slider's current position.
        /// You can change where the tooltips are displayed by using the <see cref="TBM_SETTIPSIDE"/> message.
        /// </summary>
        TBS_TOOLTIPS = 0x0100,

        /// <summary>
        /// Version 5.80.
        /// This style bit is used for "reversed" trackbars, where a smaller number indicates "higher" and a larger number indicates "lower."
        /// It has no effect on the control; it is simply a label that can be checked to determine whether a trackbar is normal or reversed.
        /// </summary>
        TBS_REVERSED = 0x0200,

        /// <summary>
        /// By default, the trackbar control uses down equal to right and up equal to left.
        /// Use the <see cref="TBS_DOWNISLEFT"/> style to reverse the default, making down equal left and up equal right.
        /// </summary>
        TBS_DOWNISLEFT = 0x0400,

        /// <summary>
        /// Version 6.00 and Windows Vista.
        /// Trackbar should notify parent before repositioning the slider due to user action (enables snapping).
        /// </summary>
        TBS_NOTIFYBEFOREMOVE = 0x0800,

        /// <summary>
        /// Version 6.00 and Windows Vista.
        /// Background is painted by the parent via the <see cref="WM_PRINTCLIENT"/> message.
        /// </summary>
        TBS_TRANSPARENTBKGND = 0x1000,
    }
}
