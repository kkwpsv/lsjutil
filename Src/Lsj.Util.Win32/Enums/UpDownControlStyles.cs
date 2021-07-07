using System;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.WindowsMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// UpDown Styles
    /// </para>
    /// <para>
    /// <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/up-down-control-styles"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum UpDownControlStyles : uint
    {
        /// <summary>
        /// Positions the up-down control next to the left edge of the buddy window.
        /// The buddy window is moved to the right, and its width is decreased to accommodate the width of the up-down control.
        /// </summary>
        UDS_ALIGNLEFT = 0x0008,

        /// <summary>
        /// Positions the up-down control next to the right edge of the buddy window.
        /// The width of the buddy window is decreased to accommodate the width of the up-down control.
        /// </summary>
        UDS_ALIGNRIGHT = 0x0004,

        /// <summary>
        /// Causes the up-down control to increment and decrement the position when the UP ARROW and DOWN ARROW keys are pressed.
        /// </summary>
        UDS_ARROWKEYS = 0x0020,

        /// <summary>
        /// Automatically selects the previous window in the z-order as the up-down control's buddy window.
        /// </summary>
        UDS_AUTOBUDDY = 0x0010,

        /// <summary>
        /// Causes the up-down control's arrows to point left and right instead of up and down.
        /// </summary>
        UDS_HORZ = 0x0040,

        /// <summary>
        /// Causes the control to exhibit "hot tracking" behavior.
        /// That is, it highlights the UP ARROW and DOWN ARROW on the control as the pointer passes over them. 
        /// This style requires Windows 98 or Windows 2000.
        /// If the system is running Windows 95 or Windows NT 4.0, the flag is ignored.
        /// To check whether hot tracking is enabled, call <see cref="SystemParametersInfo"/>.
        /// </summary>
        UDS_HOTTRACK = 0x0100,

        /// <summary>
        /// Does not insert a thousands separator between every three decimal digits.
        /// </summary>
        UDS_NOTHOUSANDS = 0x0080,

        /// <summary>
        /// Causes the up-down control to set the text of the buddy window (using the <see cref="WM_SETTEXT"/> message) when the position changes.
        /// The text consists of the position formatted as a decimal or hexadecimal string.
        /// </summary>
        UDS_SETBUDDYINT = 0x0002,

        /// <summary>
        /// Causes the position to "wrap" if it is incremented or decremented beyond the ending or beginning of the range.
        /// </summary>
        UDS_WRAP = 0x0001,
    }
}
