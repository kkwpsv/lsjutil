using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Tab Control Styles
    /// </para>
    /// <para>
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/controls/syslink-control-styles"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The following styles can be modified after the control is created.
    /// <see cref="TCS_BOTTOM"/>, <see cref="TCS_BUTTONS"/>, <see cref="TCS_FIXEDWIDTH"/>,
    /// <see cref="TCS_FLATBUTTONS"/>, <see cref="TCS_FORCEICONLEFT"/>, <see cref="TCS_FORCELABELLEFT"/>,
    /// <see cref="TCS_MULTILINE"/>, <see cref="TCS_OWNERDRAWFIXED"/>, <see cref="TCS_RAGGEDRIGHT"/>,
    /// <see cref="TCS_RIGHT"/>, <see cref="TCS_VERTICAL"/>
    /// </remarks>
    [Flags]
    public enum TabControlStyles : uint
    {
        /// <summary>
        /// Version 4.70.
        /// Tabs appear at the bottom of the control.
        /// This value equals <see cref="TCS_RIGHT"/>.
        /// This style is not supported if you use ComCtl32.dll version 6.
        /// </summary>
        TCS_BOTTOM = 0x0002,

        /// <summary>
        /// Tabs appear as buttons, and no border is drawn around the display area.
        /// </summary>
        TCS_BUTTONS = 0x0100,

        /// <summary>
        /// All tabs are the same width. This style cannot be combined with the <see cref="TCS_RIGHTJUSTIFY"/> style.
        /// </summary>
        TCS_FIXEDWIDTH = 0x0400,

        /// <summary>
        /// Version 4.71.
        /// Selected tabs appear as being indented into the background while other tabs appear as being on the same plane as the background.
        /// This style only affects tab controls with the <see cref="TCS_BUTTONS"/> style.
        /// </summary>
        TCS_FLATBUTTONS = 0x0008,

        /// <summary>
        /// The tab control does not receive the input focus when clicked.
        /// </summary>
        TCS_FOCUSNEVER = 0x8000,

        /// <summary>
        /// The tab control receives the input focus when clicked.
        /// </summary>
        TCS_FOCUSONBUTTONDOWN = 0x1000,

        /// <summary>
        /// Icons are aligned with the left edge of each fixed-width tab.
        /// This style can only be used with the <see cref="TCS_FIXEDWIDTH"/> style.
        /// </summary>
        TCS_FORCEICONLEFT = 0x0010,

        /// <summary>
        /// Labels are aligned with the left edge of each fixed-width tab; that is,
        /// the label is displayed immediately to the right of the icon instead of being centered.
        /// This style can only be used with the <see cref="TCS_FIXEDWIDTH"/> style, and it implies the <see cref="TCS_FORCEICONLEFT"/> style.
        /// </summary>
        TCS_FORCELABELLEFT = 0x0020,

        /// <summary>
        /// Version 4.70.
        /// Items under the pointer are automatically highlighted.
        /// You can check whether hot tracking is enabled by calling <see cref="SystemParametersInfo"/>.
        /// </summary>
        TCS_HOTTRACK = 0x0040,

        /// <summary>
        /// Multiple rows of tabs are displayed, if necessary, so all tabs are visible at once.
        /// </summary>
        TCS_MULTILINE = 0x0200,

        /// <summary>
        /// Version 4.70.
        /// Multiple tabs can be selected by holding down the CTRL key when clicking.
        /// This style must be used with the <see cref="TCS_BUTTONS"/> style.
        /// </summary>
        TCS_MULTISELECT = 0x0004,

        /// <summary>
        /// The parent window is responsible for drawing tabs.
        /// </summary>
        TCS_OWNERDRAWFIXED = 0x2000,

        /// <summary>
        /// Rows of tabs will not be stretched to fill the entire width of the control.
        /// This style is the default.
        /// </summary>
        TCS_RAGGEDRIGHT = 0x0800,

        /// <summary>
        /// Version 4.70.
        /// Tabs appear vertically on the right side of controls that use the <see cref="TCS_VERTICAL"/> style.
        /// This value equals <see cref="TCS_BOTTOM"/>.
        /// This style is not supported if you use visual styles.
        /// </summary>
        TCS_RIGHT = 0x0002,

        /// <summary>
        /// The width of each tab is increased, if necessary, so that each row of tabs fills the entire width of the tab control.
        /// This window style is ignored unless the <see cref="TCS_MULTILINE"/> style is also specified.
        /// </summary>
        TCS_RIGHTJUSTIFY = 0x0000,

        /// <summary>
        /// Version 4.70.
        /// Unneeded tabs scroll to the opposite side of the control when a tab is selected.
        /// </summary>
        TCS_SCROLLOPPOSITE = 0x0001,

        /// <summary>
        /// Only one row of tabs is displayed.
        /// The user can scroll to see more tabs, if necessary. 
        /// This style is the default.
        /// </summary>
        TCS_SINGLELINE = 0x0000,

        /// <summary>
        /// Tabs appear as tabs, and a border is drawn around the display area.
        /// This style is the default.
        /// </summary>
        TCS_TABS = 0x0000,

        /// <summary>
        /// The tab control has a tooltip control associated with it.
        /// </summary>
        TCS_TOOLTIPS = 0x4000,

        /// <summary>
        /// Version 4.70.
        /// Tabs appear at the left side of the control, with tab text displayed vertically.
        /// This style is valid only when used with the <see cref="TCS_MULTILINE"/> style.
        /// To make tabs appear on the right side of the control, also use the <see cref="TCS_RIGHT"/> style. 
        /// This style is not supported if you use ComCtl32.dll version 6.
        /// </summary>
        TCS_VERTICAL = 0x0080,
    }
}
