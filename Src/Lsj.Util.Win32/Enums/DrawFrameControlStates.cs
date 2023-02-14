using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="DrawFrameControl"/> States
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-drawframecontrol"/>
    /// </para>
    /// </summary>
    public enum DrawFrameControlStates : uint
    {
        /// <summary>
        /// Three-state button
        /// </summary>
        DFCS_BUTTON3STATE = 0x0008,

        /// <summary>
        /// Check box
        /// </summary>
        DFCS_BUTTONCHECK = 0x0000,

        /// <summary>
        /// Push button
        /// </summary>
        DFCS_BUTTONPUSH = 0x0010,

        /// <summary>
        /// Radio button
        /// </summary>
        DFCS_BUTTONRADIO = 0x0004,

        /// <summary>
        /// Image for radio button (nonsquare needs image)
        /// </summary>
        DFCS_BUTTONRADIOIMAGE = 0x0001,

        /// <summary>
        /// Mask for radio button (nonsquare needs mask)
        /// </summary>
        DFCS_BUTTONRADIOMASK = 0x0002,

        /// <summary>
        /// Close button
        /// </summary>
        DFCS_CAPTIONCLOSE = 0x0000,

        /// <summary>
        /// Help button
        /// </summary>
        DFCS_CAPTIONHELP = 0x0004,

        /// <summary>
        /// Maximize button
        /// </summary>
        DFCS_CAPTIONMAX = 0x0002,

        /// <summary>
        /// Minimize button
        /// </summary>
        DFCS_CAPTIONMIN = 0x0001,

        /// <summary>
        /// Restore button
        /// </summary>
        DFCS_CAPTIONRESTORE = 0x0003,

        /// <summary>
        /// Submenu arrow
        /// </summary>
        DFCS_MENUARROW = 0x0000,

        /// <summary>
        /// Submenu arrow pointing left.
        /// This is used for the right-to-left cascading menus used with right-to-left languages such as Arabic or Hebrew.
        /// </summary>
        DFCS_MENUARROWRIGHT = 0x0004,

        /// <summary>
        /// Bullet
        /// </summary>
        DFCS_MENUBULLET = 0x0002,

        /// <summary>
        /// Check mark
        /// </summary>
        DFCS_MENUCHECK = 0x0001,

        /// <summary>
        /// Combo box scroll bar
        /// </summary>
        DFCS_SCROLLCOMBOBOX = 0x0005,

        /// <summary>
        /// Down arrow of scroll bar
        /// </summary>
        DFCS_SCROLLDOWN = 0x0001,

        /// <summary>
        /// Left arrow of scroll bar
        /// </summary>
        DFCS_SCROLLLEFT = 0x0002,

        /// <summary>
        /// Right arrow of scroll bar
        /// </summary>
        DFCS_SCROLLRIGHT = 0x0003,

        /// <summary>
        /// Size grip in lower-right corner of window
        /// </summary>
        DFCS_SCROLLSIZEGRIP = 0x0008,

        /// <summary>
        /// Size grip in lower-left corner of window.
        /// This is used with right-to-left languages such as Arabic or Hebrew.
        /// </summary>
        DFCS_SCROLLSIZEGRIPRIGHT = 0x0010,

        /// <summary>
        /// Up arrow of scroll bar
        /// </summary>
        DFCS_SCROLLUP = 0x0000,

        /// <summary>
        /// Bounding rectangle is adjusted to exclude the surrounding edge of the push button.
        /// </summary>
        DFCS_ADJUSTRECT = 0x2000,

        /// <summary>
        /// Button is checked.
        /// </summary>
        DFCS_CHECKED = 0x0400,

        /// <summary>
        /// Button has a flat border.
        /// </summary>
        DFCS_FLAT = 0x4000,

        /// <summary>
        /// Button is hot-tracked.
        /// </summary>
        DFCS_HOT = 0x1000,

        /// <summary>
        /// Button is inactive (grayed).
        /// </summary>
        DFCS_INACTIVE = 0x0100,

        /// <summary>
        /// Button has a monochrome border.
        /// </summary>
        DFCS_MONO = 0x8000,

        /// <summary>
        /// Button is pushed.
        /// </summary>
        DFCS_PUSHED = 0x0200,

        /// <summary>
        /// The background remains untouched.
        /// This flag can only be combined with <see cref="DFCS_MENUARROWUP"/> or <see cref="DFCS_MENUARROWDOWN"/>.
        /// </summary>
        DFCS_TRANSPARENT = 0x0800,

        /// <summary>
        /// DFCS_MENUARROWDOWN
        /// </summary>
        DFCS_MENUARROWDOWN = 0x0008,

        /// <summary>
        /// DFCS_MENUARROWUP
        /// </summary>
        DFCS_MENUARROWUP = 0x0010,
    }
}
