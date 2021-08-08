using System;
using static Lsj.Util.Win32.Enums.CommonControlStyles;
using static Lsj.Util.Win32.Enums.WindowsMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The following window styles are specific to toolbars. They are combined with other window styles when the toolbar is created.
    /// </para>
    /// <para>
    /// <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/toolbar-control-and-button-styles"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum ToolbarControlStyles : uint
    {
        /// <summary>
        /// Allows users to change a toolbar button's position by dragging it while holding down the ALT key.
        /// If this style is not specified, the user must hold down the SHIFT key while dragging a button.
        /// Note that the <see cref="CCS_ADJUSTABLE"/> style must be specified to enable toolbar buttons to be dragged.
        /// </summary>
        TBSTYLE_ALTDRAG = 0x0400,

        /// <summary>
        /// Version 4.70.
        /// Generates <see cref="NM_CUSTOMDRAW"/> notification codes when the toolbar processes <see cref="WM_ERASEBKGND"/> messages.
        /// </summary>
        TBSTYLE_CUSTOMERASE = 0x2000,

        /// <summary>
        /// Version 4.70.
        /// Creates a flat toolbar.
        /// In a flat toolbar, both the toolbar and the buttons are transparent and hot-tracking is enabled.
        /// Button text appears under button bitmaps.
        /// To prevent repainting problems, this style should be set before the toolbar control becomes visible.
        /// </summary>
        TBSTYLE_FLAT = 0x0800,

        /// <summary>
        /// Version 4.70.
        /// Creates a flat toolbar with button text to the right of the bitmap.
        /// Otherwise, this style is identical to <see cref="TBSTYLE_FLAT"/>.
        /// To prevent repainting problems, this style should be set before the toolbar control becomes visible.
        /// </summary>
        TBSTYLE_LIST = 0x1000,

        /// <summary>
        /// Version 4.71.
        /// Generates <see cref="TBN_GETOBJECT"/> notification codes to request drop target objects when the cursor passes over toolbar buttons.
        /// </summary>
        TBSTYLE_REGISTERDROP = 0x4000,

        /// <summary>
        /// Creates a tooltip control that an application can use to display descriptive text for the buttons in the toolbar.
        /// </summary>
        TBSTYLE_TOOLTIPS = 0x0100,

        /// <summary>
        /// Version 4.71.
        /// Creates a transparent toolbar.
        /// In a transparent toolbar, the toolbar is transparent but the buttons are not. Button text appears under button bitmaps.
        /// To prevent repainting problems, this style should be set before the toolbar control becomes visible.
        /// </summary>
        TBSTYLE_TRANSPARENT = 0x8000,

        /// <summary>
        /// Creates a toolbar that can have multiple lines of buttons. 
        /// Toolbar buttons can "wrap" to the next line when the toolbar becomes too narrow to include all buttons on the same line.
        /// When the toolbar is wrapped, the break will occur on either the rightmost separator or the rightmost button if there are no separators on the bar.
        /// This style must be set to display a vertical toolbar control when the toolbar is part of a vertical rebar control.
        /// This style cannot be combined with <see cref="CCS_VERT"/>.
        /// </summary>
        TBSTYLE_WRAPABLE = 0x0200,

        /// <summary>
        /// Version 5.80.
        /// Specifies that the toolbar control should not assign the standard width to the button.
        /// Instead, the button's width will be calculated based on the width of the text plus the image of the button.
        /// Use the equivalent style flag, <see cref="TBSTYLE_AUTOSIZE"/>, for version 4.72 and earlier.
        /// </summary>
        BTNS_AUTOSIZE = 0x0010,

        /// <summary>
        /// Version 5.80.
        /// Creates a standard button. 
        /// Use the equivalent style flag, <see cref="TBSTYLE_BUTTON"/>, for version 4.72 and earlier.
        /// This flag is defined as 0, and should be used to signify that no other flags are set.
        /// </summary>
        BTNS_BUTTON = 0x0000,

        /// <summary>
        /// Version 5.80.
        /// Creates a dual-state push button that toggles between the pressed and nonpressed states each time the user clicks it.
        /// The button has a different background color when it is in the pressed state.
        /// Use the equivalent style flag, <see cref="TBSTYLE_CHECK"/>, for version 4.72 and earlier.
        /// </summary>
        BTNS_CHECK = 0x0002,

        /// <summary>
        /// Version 5.80.
        /// Creates a button that stays pressed until another button in the group is pressed, similar to option buttons (also known as radio buttons).
        /// It is equivalent to combining <see cref="BTNS_CHECK"/> and <see cref="BTNS_GROUP"/>.
        /// Use the equivalent style flag, <see cref="TBSTYLE_CHECKGROUP"/>, for version 4.72 and earlier.
        /// </summary>
        BTNS_CHECKGROUP = BTNS_GROUP | BTNS_CHECK,

        /// <summary>
        /// Version 5.80.
        /// Creates a drop-down style button that can display a list when the button is clicked. 
        /// Instead of the <see cref="WM_COMMAND"/> message used for normal buttons, drop-down buttons send a <see cref="TBN_DROPDOWN"/> notification code.
        /// An application can then have the notification handler display a list of options.
        /// Use the equivalent style flag, <see cref="TBSTYLE_DROPDOWN"/>, for version 4.72 and earlier.
        /// If the toolbar has the <see cref="TBSTYLE_EX_DRAWDDARROWS"/> extended style, drop-down buttons will have a drop-down arrow displayed in a separate section to their right.
        /// If the arrow is clicked, a <see cref="TBN_DROPDOWN"/> notification code will be sent.
        /// If the associated button is clicked, a <see cref="WM_COMMAND"/> message will be sent.
        /// </summary>
        BTNS_DROPDOWN = 0x0008,

        /// <summary>
        /// Version 5.80.
        /// When combined with BTNS_CHECK, creates a button that stays pressed until another button in the group is pressed.
        /// Use the equivalent style flag, <see cref="TBSTYLE_GROUP"/>, for version 4.72 and earlier.
        /// </summary>
        BTNS_GROUP = 0x0004,

        /// <summary>
        /// Version 5.80.
        /// Specifies that the button text will not have an accelerator prefix associated with it.
        /// Use the equivalent style flag, <see cref="TBSTYLE_NOPREFIX"/>, for version 4.72 and earlier.
        /// </summary>
        BTNS_NOPREFIX = 0x0020,

        /// <summary>
        /// Version 5.80.
        /// Creates a separator, providing a small gap between button groups.
        /// A button that has this style does not receive user input.
        /// Use the equivalent style flag, <see cref="TBSTYLE_SEP"/>, for version 4.72 and earlier.
        /// </summary>
        BTNS_SEP = 0x0001,

        /// <summary>
        /// Version 5.81.
        /// Specifies that button text should be displayed.
        /// All buttons can have text, but only those buttons with the <see cref="BTNS_SHOWTEXT"/> button style will display it.
        /// This button style must be used with the <see cref="TBSTYLE_LIST"/> style and the <see cref="TBSTYLE_EX_MIXEDBUTTONS"/> extended style.
        /// If you set text for buttons that do not have the <see cref="BTNS_SHOWTEXT"/> style,
        /// the toolbar control will automatically display it as a tooltip when the cursor hovers over the button.
        /// This feature allows your application to avoid handling the <see cref="TBN_GETINFOTIP"/> or <see cref="TTN_GETDISPINFO"/> notification code for the toolbar.
        /// </summary>
        BTNS_SHOWTEXT = 0x0040,

        /// <summary>
        /// Version 5.80.
        /// Specifies that the button will have a drop-down arrow, but not as a separate section.
        /// Buttons with this style behave the same, regardless of whether the <see cref="TBSTYLE_EX_DRAWDDARROWS"/> extended style is set.
        /// </summary>
        BTNS_WHOLEDROPDOWN = 0x0080,

        /// <summary>
        /// Equivalent to <see cref="BTNS_AUTOSIZE"/>.
        /// Use <see cref="TBSTYLE_AUTOSIZE"/> for version 4.72 and earlier.
        /// </summary>
        [Obsolete]
        TBSTYLE_AUTOSIZE = BTNS_AUTOSIZE,

        /// <summary>
        /// Equivalent to <see cref="BTNS_BUTTON"/>.
        /// Use <see cref="TBSTYLE_BUTTON"/> for version 4.72 and earlier.
        /// </summary>
        [Obsolete]
        TBSTYLE_BUTTON = BTNS_BUTTON,

        /// <summary>
        /// Equivalent to <see cref="BTNS_CHECK"/>.
        /// Use <see cref="TBSTYLE_CHECK"/> for version 4.72 and earlier.
        /// </summary>
        [Obsolete]
        TBSTYLE_CHECK = BTNS_CHECK,

        /// <summary>
        /// Equivalent to <see cref="BTNS_CHECKGROUP"/>.
        /// Use <see cref="TBSTYLE_CHECKGROUP"/> for version 4.72 and earlier.
        /// </summary>
        [Obsolete]
        TBSTYLE_CHECKGROUP = BTNS_CHECKGROUP,

        /// <summary>
        /// Equivalent to <see cref="BTNS_DROPDOWN"/>.
        /// Use <see cref="TBSTYLE_DROPDOWN"/> for version 4.72 and earlier.
        /// </summary>
        [Obsolete]
        TBSTYLE_DROPDOWN = BTNS_DROPDOWN,

        /// <summary>
        /// Equivalent to <see cref="BTNS_GROUP"/>.
        /// Use <see cref="TBSTYLE_GROUP"/> for version 4.72 and earlier.
        /// </summary>
        [Obsolete]
        TBSTYLE_GROUP = BTNS_GROUP,

        /// <summary>
        /// Equivalent to <see cref="BTNS_NOPREFIX"/>.
        /// Use <see cref="TBSTYLE_NOPREFIX"/> for version 4.72 and earlier.
        /// </summary>
        [Obsolete]
        TBSTYLE_NOPREFIX = BTNS_NOPREFIX,

        /// <summary>
        /// Equivalent to <see cref="BTNS_NOPREFIX"/>.
        /// Use <see cref="BTNS_SEP"/> for version 4.72 and earlier.
        /// </summary>
        [Obsolete]
        TBSTYLE_SEP = BTNS_SEP,
    }
}
