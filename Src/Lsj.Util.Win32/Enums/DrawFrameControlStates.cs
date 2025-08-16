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
        /// DFCS_BUTTON3STATE
        /// </summary>
        DFCS_BUTTON3STATE = 0x0008,

        /// <summary>
        /// DFCS_BUTTONCHECK
        /// </summary>
        DFCS_BUTTONCHECK = 0x0000,

        /// <summary>
        /// DFCS_BUTTONPUSH
        /// </summary>
        DFCS_BUTTONPUSH = 0x0010,

        /// <summary>
        /// DFCS_BUTTONRADIO
        /// </summary>
        DFCS_BUTTONRADIO = 0x0004,

        /// <summary>
        /// DFCS_BUTTONRADIOIMAGE
        /// </summary>
        DFCS_BUTTONRADIOIMAGE = 0x0001,

        /// <summary>
        /// DFCS_BUTTONRADIOMASK
        /// </summary>
        DFCS_BUTTONRADIOMASK = 0x0002,

        /// <summary>
        /// DFCS_CAPTIONCLOSE
        /// </summary>
        DFCS_CAPTIONCLOSE = 0x0000,

        /// <summary>
        /// DFCS_CAPTIONHELP
        /// </summary>
        DFCS_CAPTIONHELP = 0x0004,

        /// <summary>
        /// DFCS_CAPTIONMAX
        /// </summary>
        DFCS_CAPTIONMAX = 0x0002,

        /// <summary>
        /// DFCS_CAPTIONMIN
        /// </summary>
        DFCS_CAPTIONMIN = 0x0001,

        /// <summary>
        /// DFCS_CAPTIONRESTORE
        /// </summary>
        DFCS_CAPTIONRESTORE = 0x0003,

        /// <summary>
        /// DFCS_MENUARROW
        /// </summary>
        DFCS_MENUARROW = 0x0000,

        /// <summary>
        /// DFCS_MENUARROWRIGHT
        /// </summary>
        DFCS_MENUARROWRIGHT = 0x0004,

        /// <summary>
        /// DFCS_MENUBULLET
        /// </summary>
        DFCS_MENUBULLET = 0x0002,

        /// <summary>
        /// DFCS_MENUCHECK
        /// </summary>
        DFCS_MENUCHECK = 0x0001,

        /// <summary>
        /// DFCS_SCROLLCOMBOBOX
        /// </summary>
        DFCS_SCROLLCOMBOBOX = 0x0005,

        /// <summary>
        /// DFCS_SCROLLDOWN
        /// </summary>
        DFCS_SCROLLDOWN = 0x0001,

        /// <summary>
        /// DFCS_SCROLLLEFT
        /// </summary>
        DFCS_SCROLLLEFT = 0x0002,

        /// <summary>
        /// DFCS_SCROLLRIGHT
        /// </summary>
        DFCS_SCROLLRIGHT = 0x0003,

        /// <summary>
        /// DFCS_SCROLLSIZEGRIP
        /// </summary>
        DFCS_SCROLLSIZEGRIP = 0x0008,

        /// <summary>
        /// DFCS_SCROLLSIZEGRIPRIGHT
        /// </summary>
        DFCS_SCROLLSIZEGRIPRIGHT = 0x0010,

        /// <summary>
        /// DFCS_SCROLLUP
        /// </summary>
        DFCS_SCROLLUP = 0x0000,

        /// <summary>
        /// DFCS_ADJUSTRECT
        /// </summary>
        DFCS_ADJUSTRECT = 0x2000,

        /// <summary>
        /// DFCS_CHECKED
        /// </summary>
        DFCS_CHECKED = 0x0400,

        /// <summary>
        /// DFCS_FLAT
        /// </summary>
        DFCS_FLAT = 0x4000,

        /// <summary>
        /// DFCS_HOT
        /// </summary>
        DFCS_HOT = 0x1000,

        /// <summary>
        /// DFCS_INACTIVE
        /// </summary>
        DFCS_INACTIVE = 0x0100,

        /// <summary>
        /// DFCS_MONO
        /// </summary>
        DFCS_MONO = 0x8000,

        /// <summary>
        /// DFCS_PUSHED
        /// </summary>
        DFCS_PUSHED = 0x0200,

        /// <summary>
        /// DFCS_TRANSPARENT
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
