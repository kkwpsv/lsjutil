using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="GetSystemMetrics"/> indexes
    /// </summary>
    public enum SystemMetricIndexes : int
    {
        /// <summary>
        /// SM_ARRANGE
        /// </summary>
        SM_ARRANGE = 56,

        /// <summary>
        /// SM_CLEANBOOT
        /// </summary>
        SM_CLEANBOOT = 67,

        /// <summary>
        /// SM_CMONITORS
        /// </summary>
        SM_CMONITORS = 80,

        /// <summary>
        /// SM_CMOUSEBUTTONS
        /// </summary>
        SM_CMOUSEBUTTONS = 43,

        /// <summary>
        /// SM_CONVERTIBLESLATEMODE
        /// </summary>
        SM_CONVERTIBLESLATEMODE = 0x2003,

        /// <summary>
        /// SM_CXBORDER
        /// </summary>
        SM_CXBORDER = 5,

        /// <summary>
        /// SM_CXCURSOR
        /// </summary>
        SM_CXCURSOR = 13,

        /// <summary>
        /// SM_CXDLGFRAME
        /// </summary>
        SM_CXDLGFRAME = 7,

        /// <summary>
        /// SM_CXDOUBLECLK
        /// </summary>
        SM_CXDOUBLECLK = 36,

        /// <summary>
        /// SM_CXDRAG
        /// </summary>
        SM_CXDRAG = 68,

        /// <summary>
        /// SM_CXEDGE
        /// </summary>
        SM_CXEDGE = 45,

        /// <summary>
        /// SM_CXFIXEDFRAME
        /// </summary>
        SM_CXFIXEDFRAME = 7,

        /// <summary>
        /// SM_CXFOCUSBORDER
        /// </summary>
        SM_CXFOCUSBORDER = 83,

        /// <summary>
        /// SM_CXFRAME
        /// </summary>
        SM_CXFRAME = 32,

        /// <summary>
        /// SM_CXFULLSCREEN
        /// </summary>
        SM_CXFULLSCREEN = 16,

        /// <summary>
        /// SM_CXHSCROLL
        /// </summary>
        SM_CXHSCROLL = 21,

        /// <summary>
        /// SM_CXHTHUMB
        /// </summary>
        SM_CXHTHUMB = 10,

        /// <summary>
        /// SM_CXICON
        /// </summary>
        SM_CXICON = 11,

        /// <summary>
        /// SM_CXICONSPACING
        /// </summary>
        SM_CXICONSPACING = 38,

        /// <summary>
        /// SM_CXMAXIMIZED
        /// </summary>
        SM_CXMAXIMIZED = 61,

        /// <summary>
        /// SM_CXMAXTRACK
        /// </summary>
        SM_CXMAXTRACK = 59,

        /// <summary>
        /// SM_CXMENUCHECK
        /// </summary>
        SM_CXMENUCHECK = 71,

        /// <summary>
        /// SM_CXMENUSIZE
        /// </summary>
        SM_CXMENUSIZE = 54,

        /// <summary>
        /// SM_CXMIN
        /// </summary>
        SM_CXMIN = 28,

        /// <summary>
        /// SM_CXMINIMIZED
        /// </summary>
        SM_CXMINIMIZED = 57,

        /// <summary>
        /// SM_CXMINSPACING
        /// </summary>
        SM_CXMINSPACING = 47,

        /// <summary>
        /// SM_CXMINTRACK
        /// </summary>
        SM_CXMINTRACK = 34,

        /// <summary>
        /// SM_CXPADDEDBORDER
        /// </summary>
        SM_CXPADDEDBORDER = 92,

        /// <summary>
        /// SM_CXSCREEN
        /// </summary>
        SM_CXSCREEN = 0,

        /// <summary>
        /// SM_CXSIZE
        /// </summary>
        SM_CXSIZE = 30,

        /// <summary>
        /// SM_CXSIZEFRAME
        /// </summary>
        SM_CXSIZEFRAME = 32,

        /// <summary>
        /// SM_CXSMICON
        /// </summary>
        SM_CXSMICON = 49,

        /// <summary>
        /// SM_CXSMSIZE
        /// </summary>
        SM_CXSMSIZE = 52,

        /// <summary>
        /// SM_CXVIRTUALSCREEN
        /// </summary>
        SM_CXVIRTUALSCREEN = 78,

        /// <summary>
        /// SM_CXVSCROLL
        /// </summary>
        SM_CXVSCROLL = 2,

        /// <summary>
        /// SM_CYBORDER
        /// </summary>
        SM_CYBORDER = 6,

        /// <summary>
        /// SM_CYCAPTION
        /// </summary>
        SM_CYCAPTION = 4,

        /// <summary>
        /// SM_CYCURSOR
        /// </summary>
        SM_CYCURSOR = 14,

        /// <summary>
        /// SM_CYDLGFRAME
        /// </summary>
        SM_CYDLGFRAME = 8,

        /// <summary>
        /// SM_CYDOUBLECLK
        /// </summary>
        SM_CYDOUBLECLK = 37,

        /// <summary>
        /// SM_CYDRAG
        /// </summary>
        SM_CYDRAG = 69,

        /// <summary>
        /// SM_CYEDGE
        /// </summary>
        SM_CYEDGE = 46,

        /// <summary>
        /// SM_CYFIXEDFRAME
        /// </summary>
        SM_CYFIXEDFRAME = 8,

        /// <summary>
        /// SM_CYFOCUSBORDER
        /// </summary>
        SM_CYFOCUSBORDER = 84,

        /// <summary>
        /// SM_CYFRAME
        /// </summary>
        SM_CYFRAME = 33,

        /// <summary>
        /// SM_CYFULLSCREEN
        /// </summary>
        SM_CYFULLSCREEN = 17,

        /// <summary>
        /// SM_CYHSCROLL
        /// </summary>
        SM_CYHSCROLL = 3,

        /// <summary>
        /// SM_CYICON
        /// </summary>
        SM_CYICON = 12,

        /// <summary>
        /// SM_CYICONSPACING
        /// </summary>
        SM_CYICONSPACING = 39,

        /// <summary>
        /// SM_CYKANJIWINDOW
        /// </summary>
        SM_CYKANJIWINDOW = 18,

        /// <summary>
        /// SM_CYMAXIMIZED
        /// </summary>
        SM_CYMAXIMIZED = 62,

        /// <summary>
        /// SM_CYMAXTRACK
        /// </summary>
        SM_CYMAXTRACK = 60,

        /// <summary>
        /// SM_CYMENU
        /// </summary>
        SM_CYMENU = 15,

        /// <summary>
        /// SM_CYMENUCHECK
        /// </summary>
        SM_CYMENUCHECK = 72,

        /// <summary>
        /// SM_CYMENUSIZE
        /// </summary>
        SM_CYMENUSIZE = 55,

        /// <summary>
        /// SM_CYMIN
        /// </summary>
        SM_CYMIN = 29,

        /// <summary>
        /// SM_CYMINIMIZED
        /// </summary>
        SM_CYMINIMIZED = 58,

        /// <summary>
        /// SM_CYMINSPACING
        /// </summary>
        SM_CYMINSPACING = 48,

        /// <summary>
        /// SM_CYMINTRACK
        /// </summary>
        SM_CYMINTRACK = 35,

        /// <summary>
        /// SM_CYSCREEN
        /// </summary>
        SM_CYSCREEN = 1,

        /// <summary>
        /// SM_CYSIZE
        /// </summary>
        SM_CYSIZE = 31,

        /// <summary>
        /// SM_CYSIZEFRAME
        /// </summary>
        SM_CYSIZEFRAME = 33,

        /// <summary>
        /// SM_CYSMCAPTION
        /// </summary>
        SM_CYSMCAPTION = 51,

        /// <summary>
        /// SM_CYSMICON
        /// </summary>
        SM_CYSMICON = 50,

        /// <summary>
        /// SM_CYSMSIZE
        /// </summary>
        SM_CYSMSIZE = 53,

        /// <summary>
        /// SM_CYVIRTUALSCREEN
        /// </summary>
        SM_CYVIRTUALSCREEN = 79,

        /// <summary>
        /// SM_CYVSCROLL
        /// </summary>
        SM_CYVSCROLL = 20,

        /// <summary>
        /// SM_CYVTHUMB
        /// </summary>
        SM_CYVTHUMB = 9,

        /// <summary>
        /// SM_DBCSENABLED
        /// </summary>
        SM_DBCSENABLED = 42,

        /// <summary>
        /// SM_DEBUG
        /// </summary>
        SM_DEBUG = 22,

        /// <summary>
        /// SM_DIGITIZER
        /// </summary>
        SM_DIGITIZER = 94,

        /// <summary>
        /// SM_IMMENABLED
        /// </summary>
        SM_IMMENABLED = 82,

        /// <summary>
        /// SM_MAXIMUMTOUCHES
        /// </summary>
        SM_MAXIMUMTOUCHES = 95,

        /// <summary>
        /// SM_MEDIACENTER
        /// </summary>
        SM_MEDIACENTER = 87,

        /// <summary>
        /// SM_MENUDROPALIGNMENT
        /// </summary>
        SM_MENUDROPALIGNMENT = 40,

        /// <summary>
        /// SM_MIDEASTENABLED
        /// </summary>
        SM_MIDEASTENABLED = 74,

        /// <summary>
        /// SM_MOUSEPRESENT
        /// </summary>
        SM_MOUSEPRESENT = 19,

        /// <summary>
        /// SM_MOUSEHORIZONTALWHEELPRESENT
        /// </summary>
        SM_MOUSEHORIZONTALWHEELPRESENT = 91,

        /// <summary>
        /// SM_MOUSEWHEELPRESENT
        /// </summary>
        SM_MOUSEWHEELPRESENT = 75,

        /// <summary>
        /// SM_NETWORK
        /// </summary>
        SM_NETWORK = 63,

        /// <summary>
        /// SM_PENWINDOWS
        /// </summary>
        SM_PENWINDOWS = 41,

        /// <summary>
        /// SM_REMOTECONTROL
        /// </summary>
        SM_REMOTECONTROL = 0x2001,

        /// <summary>
        /// SM_REMOTESESSION
        /// </summary>
        SM_REMOTESESSION = 0x1000,

        /// <summary>
        /// SM_SAMEDISPLAYFORMAT
        /// </summary>
        SM_SAMEDISPLAYFORMAT = 81,

        /// <summary>
        /// SM_SECURE
        /// </summary>
        SM_SECURE = 44,

        /// <summary>
        /// SM_SERVERR2
        /// </summary>
        SM_SERVERR2 = 89,

        /// <summary>
        /// SM_SHOWSOUNDS
        /// </summary>
        SM_SHOWSOUNDS = 70,

        /// <summary>
        /// SM_SHUTTINGDOWN
        /// </summary>
        SM_SHUTTINGDOWN = 0x2000,

        /// <summary>
        /// SM_SLOWMACHINE
        /// </summary>
        SM_SLOWMACHINE = 73,

        /// <summary>
        /// SM_STARTER
        /// </summary>
        SM_STARTER = 88,

        /// <summary>
        /// SM_SWAPBUTTON
        /// </summary>
        SM_SWAPBUTTON = 23,

        /// <summary>
        /// SM_SYSTEMDOCKED
        /// </summary>
        SM_SYSTEMDOCKED = 0x2004,

        /// <summary>
        /// SM_TABLETPC
        /// </summary>
        SM_TABLETPC = 86,

        /// <summary>
        /// SM_XVIRTUALSCREEN
        /// </summary>
        SM_XVIRTUALSCREEN = 76,

        /// <summary>
        /// SM_YVIRTUALSCREEN
        /// </summary>
        SM_YVIRTUALSCREEN = 77,
    }
}
