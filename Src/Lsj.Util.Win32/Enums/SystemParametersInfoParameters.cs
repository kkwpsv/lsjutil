using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="SystemParametersInfo"/> Parameters.
    /// </summary>
    public enum SystemParametersInfoParameters
    {
        /// <summary>
        /// SPI_GETACCESSTIMEOUT
        /// </summary>
        SPI_GETACCESSTIMEOUT = 0x003C,

        /// <summary>
        /// SPI_GETAUDIODESCRIPTION
        /// </summary>
        SPI_GETAUDIODESCRIPTION = 0x0074,

        /// <summary>
        /// SPI_GETCLIENTAREAANIMATION
        /// </summary>
        SPI_GETCLIENTAREAANIMATION = 0x1042,

        /// <summary>
        /// SPI_GETDISABLEOVERLAPPEDCONTENT
        /// </summary>
        SPI_GETDISABLEOVERLAPPEDCONTENT = 0x1040,

        /// <summary>
        /// SPI_GETFILTERKEYS
        /// </summary>
        SPI_GETFILTERKEYS = 0x0032,

        /// <summary>
        /// SPI_GETFOCUSBORDERHEIGHT
        /// </summary>
        SPI_GETFOCUSBORDERHEIGHT = 0x2010,

        /// <summary>
        /// SPI_GETFOCUSBORDERWIDTH
        /// </summary>
        SPI_GETFOCUSBORDERWIDTH = 0x200E,

        /// <summary>
        /// SPI_GETHIGHCONTRAST
        /// </summary>
        SPI_GETHIGHCONTRAST = 0x0042,

        /// <summary>
        /// SPI_GETLOGICALDPIOVERRIDE
        /// </summary>
        SPI_GETLOGICALDPIOVERRIDE = 0x009E,

        /// <summary>
        /// SPI_GETMESSAGEDURATION
        /// </summary>
        SPI_GETMESSAGEDURATION = 0x2016,

        /// <summary>
        /// SPI_GETMOUSECLICKLOCK
        /// </summary>
        SPI_GETMOUSECLICKLOCK = 0x101E,

        /// <summary>
        /// SPI_GETMOUSECLICKLOCKTIME
        /// </summary>
        SPI_GETMOUSECLICKLOCKTIME = 0x2008,

        /// <summary>
        /// SPI_GETMOUSEKEYS
        /// </summary>
        SPI_GETMOUSEKEYS = 0x0036,

        /// <summary>
        /// SPI_GETMOUSESONAR
        /// </summary>
        SPI_GETMOUSESONAR = 0x101C,

        /// <summary>
        /// SPI_GETMOUSEVANISH
        /// </summary>
        SPI_GETMOUSEVANISH = 0x1020,

        /// <summary>
        /// SPI_GETSCREENREADER
        /// </summary>
        SPI_GETSCREENREADER = 0x0046,

        /// <summary>
        /// SPI_GETSERIALKEYS
        /// </summary>
        SPI_GETSERIALKEYS = 0x003E,

        /// <summary>
        /// SPI_GETSHOWSOUNDS
        /// </summary>
        SPI_GETSHOWSOUNDS = 0x0038,

        /// <summary>
        /// SPI_GETSOUNDSENTRY
        /// </summary>
        SPI_GETSOUNDSENTRY = 0x0040,

        /// <summary>
        /// SPI_GETSTICKYKEYS
        /// </summary>
        SPI_GETSTICKYKEYS = 0x003A,

        /// <summary>
        /// SPI_GETTOGGLEKEYS
        /// </summary>
        SPI_GETTOGGLEKEYS = 0x0034,

        /// <summary>
        /// SPI_SETACCESSTIMEOUT
        /// </summary>
        SPI_SETACCESSTIMEOUT = 0x003D,

        /// <summary>
        /// SPI_SETAUDIODESCRIPTION
        /// </summary>
        SPI_SETAUDIODESCRIPTION = 0x0075,

        /// <summary>
        /// SPI_SETCLIENTAREAANIMATION
        /// </summary>
        SPI_SETCLIENTAREAANIMATION = 0x1043,

        /// <summary>
        /// SPI_SETDISABLEOVERLAPPEDCONTENT
        /// </summary>
        SPI_SETDISABLEOVERLAPPEDCONTENT = 0x1041,

        /// <summary>
        /// SPI_SETFILTERKEYS
        /// </summary>
        SPI_SETFILTERKEYS = 0x0033,

        /// <summary>
        /// SPI_SETFOCUSBORDERHEIGHT
        /// </summary>
        SPI_SETFOCUSBORDERHEIGHT = 0x2011,

        /// <summary>
        /// SPI_SETFOCUSBORDERWIDTH
        /// </summary>
        SPI_SETFOCUSBORDERWIDTH = 0x200F,

        /// <summary>
        /// SPI_SETHIGHCONTRAST
        /// </summary>
        SPI_SETHIGHCONTRAST = 0x0043,

        /// <summary>
        /// SPI_SETLOGICALDPIOVERRIDE
        /// </summary>
        SPI_SETLOGICALDPIOVERRIDE = 0x009F,

        /// <summary>
        /// SPI_SETMESSAGEDURATION
        /// </summary>
        SPI_SETMESSAGEDURATION = 0x2017,

        /// <summary>
        /// SPI_SETMOUSECLICKLOCK
        /// </summary>
        SPI_SETMOUSECLICKLOCK = 0x101F,

        /// <summary>
        /// SPI_SETMOUSECLICKLOCKTIME
        /// </summary>
        SPI_SETMOUSECLICKLOCKTIME = 0x2009,

        /// <summary>
        /// SPI_SETMOUSEKEYS
        /// </summary>
        SPI_SETMOUSEKEYS = 0x0037,

        /// <summary>
        /// SPI_SETMOUSESONAR
        /// </summary>
        SPI_SETMOUSESONAR = 0x101D,

        /// <summary>
        /// SPI_SETMOUSEVANISH
        /// </summary>
        SPI_SETMOUSEVANISH = 0x1021,

        /// <summary>
        /// SPI_SETSCREENREADER
        /// </summary>
        SPI_SETSCREENREADER = 0x0047,

        /// <summary>
        /// SPI_SETSERIALKEYS
        /// </summary>
        SPI_SETSERIALKEYS = 0x003F,

        /// <summary>
        /// SPI_SETSHOWSOUNDS
        /// </summary>
        SPI_SETSHOWSOUNDS = 0x0039,

        /// <summary>
        /// SPI_SETSOUNDSENTRY
        /// </summary>
        SPI_SETSOUNDSENTRY = 0x0041,

        /// <summary>
        /// SPI_SETSTICKYKEYS
        /// </summary>
        SPI_SETSTICKYKEYS = 0x003B,

        /// <summary>
        /// SPI_SETTOGGLEKEYS
        /// </summary>
        SPI_SETTOGGLEKEYS = 0x0035,

        /// <summary>
        /// SPI_GETCLEARTYPE
        /// </summary>
        SPI_GETCLEARTYPE = 0x1048,

        /// <summary>
        /// SPI_GETDESKWALLPAPER
        /// </summary>
        SPI_GETDESKWALLPAPER = 0x0073,

        /// <summary>
        /// SPI_GETDROPSHADOW
        /// </summary>
        SPI_GETDROPSHADOW = 0x1024,

        /// <summary>
        /// SPI_GETFLATMENU
        /// </summary>
        SPI_GETFLATMENU = 0x1022,

        /// <summary>
        /// SPI_GETFONTSMOOTHING
        /// </summary>
        SPI_GETFONTSMOOTHING = 0x004A,

        /// <summary>
        /// SPI_GETFONTSMOOTHINGCONTRAST
        /// </summary>
        SPI_GETFONTSMOOTHINGCONTRAST = 0x200C,

        /// <summary>
        /// SPI_GETFONTSMOOTHINGORIENTATION
        /// </summary>
        SPI_GETFONTSMOOTHINGORIENTATION = 0x2012,

        /// <summary>
        /// SPI_GETFONTSMOOTHINGTYPE
        /// </summary>
        SPI_GETFONTSMOOTHINGTYPE = 0x200A,

        /// <summary>
        /// SPI_GETWORKAREA
        /// </summary>
        SPI_GETWORKAREA = 0x0030,

        /// <summary>
        /// SPI_SETCLEARTYPE
        /// </summary>
        SPI_SETCLEARTYPE = 0x1049,

        /// <summary>
        /// SPI_SETCURSORS
        /// </summary>
        SPI_SETCURSORS = 0x0057,

        /// <summary>
        /// SPI_SETDESKPATTERN
        /// </summary>
        SPI_SETDESKPATTERN = 0x0015,

        /// <summary>
        /// SPI_SETDESKWALLPAPER
        /// </summary>
        SPI_SETDESKWALLPAPER = 0x0014,

        /// <summary>
        /// SPI_SETDROPSHADOW
        /// </summary>
        SPI_SETDROPSHADOW = 0x1025,

        /// <summary>
        /// SPI_SETFLATMENU
        /// </summary>
        SPI_SETFLATMENU = 0x1023,

        /// <summary>
        /// SPI_SETFONTSMOOTHING
        /// </summary>
        SPI_SETFONTSMOOTHING = 0x004B,

        /// <summary>
        /// SPI_SETFONTSMOOTHINGCONTRAST
        /// </summary>
        SPI_SETFONTSMOOTHINGCONTRAST = 0x200D,

        /// <summary>
        /// SPI_SETFONTSMOOTHINGORIENTATION
        /// </summary>
        SPI_SETFONTSMOOTHINGORIENTATION = 0x2013,

        /// <summary>
        /// SPI_SETFONTSMOOTHINGTYPE
        /// </summary>
        SPI_SETFONTSMOOTHINGTYPE = 0x200B,

        /// <summary>
        /// SPI_SETWORKAREA
        /// </summary>
        SPI_SETWORKAREA = 0x002F,

        /// <summary>
        /// SPI_GETICONMETRICS
        /// </summary>
        SPI_GETICONMETRICS = 0x002D,

        /// <summary>
        /// SPI_GETICONTITLELOGFONT
        /// </summary>
        SPI_GETICONTITLELOGFONT = 0x001F,

        /// <summary>
        /// SPI_GETICONTITLEWRAP
        /// </summary>
        SPI_GETICONTITLEWRAP = 0x0019,

        /// <summary>
        /// SPI_ICONHORIZONTALSPACING
        /// </summary>
        SPI_ICONHORIZONTALSPACING = 0x000D,

        /// <summary>
        /// SPI_ICONVERTICALSPACING
        /// </summary>
        SPI_ICONVERTICALSPACING = 0x0018,

        /// <summary>
        /// SPI_SETICONMETRICS
        /// </summary>
        SPI_SETICONMETRICS = 0x002E,

        /// <summary>
        /// SPI_SETICONS
        /// </summary>
        SPI_SETICONS = 0x0058,

        /// <summary>
        /// SPI_SETICONTITLELOGFONT
        /// </summary>
        SPI_SETICONTITLELOGFONT = 0x0022,

        /// <summary>
        /// SPI_SETICONTITLEWRAP
        /// </summary>
        SPI_SETICONTITLEWRAP = 0x001A,

        /// <summary>
        /// SPI_GETBEEP
        /// </summary>
        SPI_GETBEEP = 0x0001,

        /// <summary>
        /// SPI_GETBLOCKSENDINPUTRESETS
        /// </summary>
        SPI_GETBLOCKSENDINPUTRESETS = 0x1026,

        /// <summary>
        /// SPI_GETCONTACTVISUALIZATION
        /// </summary>
        SPI_GETCONTACTVISUALIZATION = 0x2018,

        /// <summary>
        /// SPI_GETDEFAULTINPUTLANG
        /// </summary>
        SPI_GETDEFAULTINPUTLANG = 0x0059,

        /// <summary>
        /// SPI_GETGESTUREVISUALIZATION
        /// </summary>
        SPI_GETGESTUREVISUALIZATION = 0x201A,

        /// <summary>
        /// SPI_GETKEYBOARDCUES
        /// </summary>
        SPI_GETKEYBOARDCUES = 0x100A,

        /// <summary>
        /// SPI_GETKEYBOARDDELAY
        /// </summary>
        SPI_GETKEYBOARDDELAY = 0x0016,

        /// <summary>
        /// SPI_GETKEYBOARDPREF
        /// </summary>
        SPI_GETKEYBOARDPREF = 0x0044,

        /// <summary>
        /// SPI_GETKEYBOARDSPEED
        /// </summary>
        SPI_GETKEYBOARDSPEED = 0x000A,

        /// <summary>
        /// SPI_GETMOUSE
        /// </summary>
        SPI_GETMOUSE = 0x0003,

        /// <summary>
        /// SPI_GETMOUSEHOVERHEIGHT
        /// </summary>
        SPI_GETMOUSEHOVERHEIGHT = 0x0064,

        /// <summary>
        /// SPI_GETMOUSEHOVERTIME
        /// </summary>
        SPI_GETMOUSEHOVERTIME = 0x0066,

        /// <summary>
        /// SPI_GETMOUSEHOVERWIDTH
        /// </summary>
        SPI_GETMOUSEHOVERWIDTH = 0x0062,

        /// <summary>
        /// SPI_GETMOUSESPEED
        /// </summary>
        SPI_GETMOUSESPEED = 0x0070,

        /// <summary>
        /// SPI_GETMOUSETRAILS
        /// </summary>
        SPI_GETMOUSETRAILS = 0x005E,

        /// <summary>
        /// SPI_GETMOUSEWHEELROUTING
        /// </summary>
        SPI_GETMOUSEWHEELROUTING = 0x201C,

        /// <summary>
        /// SPI_GETPENVISUALIZATION
        /// </summary>
        SPI_GETPENVISUALIZATION = 0x201E,

        /// <summary>
        /// SPI_GETSNAPTODEFBUTTON
        /// </summary>
        SPI_GETSNAPTODEFBUTTON = 0x005F,

        /// <summary>
        /// SPI_GETSYSTEMLANGUAGEBAR
        /// </summary>
        SPI_GETSYSTEMLANGUAGEBAR = 0x1050,

        /// <summary>
        /// SPI_GETTHREADLOCALINPUTSETTINGS
        /// </summary>
        SPI_GETTHREADLOCALINPUTSETTINGS = 0x104E,

        /// <summary>
        /// SPI_GETTOUCHPADPARAMETERS
        /// </summary>
        SPI_GETTOUCHPADPARAMETERS = 0x00AE,

        /// <summary>
        /// SPI_GETWHEELSCROLLCHARS
        /// </summary>
        SPI_GETWHEELSCROLLCHARS = 0x006C,

        /// <summary>
        /// SPI_GETWHEELSCROLLLINES
        /// </summary>
        SPI_GETWHEELSCROLLLINES = 0x0068,

        /// <summary>
        /// SPI_SETBEEP
        /// </summary>
        SPI_SETBEEP = 0x0002,

        /// <summary>
        /// SPI_SETBLOCKSENDINPUTRESETS
        /// </summary>
        SPI_SETBLOCKSENDINPUTRESETS = 0x1027,

        /// <summary>
        /// SPI_SETCONTACTVISUALIZATION
        /// </summary>
        SPI_SETCONTACTVISUALIZATION = 0x2019,

        /// <summary>
        /// SPI_SETDEFAULTINPUTLANG
        /// </summary>
        SPI_SETDEFAULTINPUTLANG = 0x005A,

        /// <summary>
        /// SPI_SETDOUBLECLICKTIME
        /// </summary>
        SPI_SETDOUBLECLICKTIME = 0x0020,

        /// <summary>
        /// SPI_SETDOUBLECLKHEIGHT
        /// </summary>
        SPI_SETDOUBLECLKHEIGHT = 0x001E,

        /// <summary>
        /// SPI_SETDOUBLECLKWIDTH
        /// </summary>
        SPI_SETDOUBLECLKWIDTH = 0x001D,

        /// <summary>
        /// SPI_SETGESTUREVISUALIZATION
        /// </summary>
        SPI_SETGESTUREVISUALIZATION = 0x201B,

        /// <summary>
        /// SPI_SETKEYBOARDCUES
        /// </summary>
        SPI_SETKEYBOARDCUES = 0x100B,

        /// <summary>
        /// SPI_SETKEYBOARDDELAY
        /// </summary>
        SPI_SETKEYBOARDDELAY = 0x0017,

        /// <summary>
        /// SPI_SETKEYBOARDPREF
        /// </summary>
        SPI_SETKEYBOARDPREF = 0x0045,

        /// <summary>
        /// SPI_SETKEYBOARDSPEED
        /// </summary>
        SPI_SETKEYBOARDSPEED = 0x000B,

        /// <summary>
        /// SPI_SETLANGTOGGLE
        /// </summary>
        SPI_SETLANGTOGGLE = 0x005B,

        /// <summary>
        /// SPI_SETMOUSE
        /// </summary>
        SPI_SETMOUSE = 0x0004,

        /// <summary>
        /// SPI_SETMOUSEBUTTONSWAP
        /// </summary>
        SPI_SETMOUSEBUTTONSWAP = 0x0021,

        /// <summary>
        /// SPI_SETMOUSEHOVERHEIGHT
        /// </summary>
        SPI_SETMOUSEHOVERHEIGHT = 0x0065,

        /// <summary>
        /// SPI_SETMOUSEHOVERTIME
        /// </summary>
        SPI_SETMOUSEHOVERTIME = 0x0067,

        /// <summary>
        /// SPI_SETMOUSEHOVERWIDTH
        /// </summary>
        SPI_SETMOUSEHOVERWIDTH = 0x0063,

        /// <summary>
        /// SPI_SETMOUSESPEED
        /// </summary>
        SPI_SETMOUSESPEED = 0x0071,

        /// <summary>
        /// SPI_SETMOUSETRAILS
        /// </summary>
        SPI_SETMOUSETRAILS = 0x005D,

        /// <summary>
        /// SPI_SETMOUSEWHEELROUTING
        /// </summary>
        SPI_SETMOUSEWHEELROUTING = 0x201D,

        /// <summary>
        /// SPI_SETPENVISUALIZATION
        /// </summary>
        SPI_SETPENVISUALIZATION = 0x201F,

        /// <summary>
        /// SPI_SETSNAPTODEFBUTTON
        /// </summary>
        SPI_SETSNAPTODEFBUTTON = 0x0060,

        /// <summary>
        /// SPI_SETSYSTEMLANGUAGEBAR
        /// </summary>
        SPI_SETSYSTEMLANGUAGEBAR = 0x1051,

        /// <summary>
        /// SPI_SETTHREADLOCALINPUTSETTINGS
        /// </summary>
        SPI_SETTHREADLOCALINPUTSETTINGS = 0x104F,

        /// <summary>
        /// SPI_SETTOUCHPADPARAMETERS
        /// </summary>
        SPI_SETTOUCHPADPARAMETERS = 0x00AF,

        /// <summary>
        /// SPI_SETWHEELSCROLLCHARS
        /// </summary>
        SPI_SETWHEELSCROLLCHARS = 0x006D,

        /// <summary>
        /// SPI_SETWHEELSCROLLLINES
        /// </summary>
        SPI_SETWHEELSCROLLLINES = 0x0069,

        /// <summary>
        /// SPI_GETMENUDROPALIGNMENT
        /// </summary>
        SPI_GETMENUDROPALIGNMENT = 0x001B,

        /// <summary>
        /// SPI_GETMENUFADE
        /// </summary>
        SPI_GETMENUFADE = 0x0012,

        /// <summary>
        /// SPI_GETMENUSHOWDELAY
        /// </summary>
        SPI_GETMENUSHOWDELAY = 0x006A,

        /// <summary>
        /// SPI_SETMENUDROPALIGNMENT
        /// </summary>
        SPI_SETMENUDROPALIGNMENT = 0x001C,

        /// <summary>
        /// SPI_SETMENUFADE
        /// </summary>
        SPI_SETMENUFADE = 0x1013,

        /// <summary>
        /// SPI_SETMENUSHOWDELAY
        /// </summary>
        SPI_SETMENUSHOWDELAY = 0x006B,

        /// <summary>
        /// SPI_GETLOWPOWERACTIVE
        /// </summary>
        SPI_GETLOWPOWERACTIVE = 0x0053,

        /// <summary>
        /// SPI_GETLOWPOWERTIMEOUT
        /// </summary>
        SPI_GETLOWPOWERTIMEOUT = 0x004F,

        /// <summary>
        /// SPI_GETPOWEROFFACTIVE
        /// </summary>
        SPI_GETPOWEROFFACTIVE = 0x0054,

        /// <summary>
        /// SPI_GETPOWEROFFTIMEOUT
        /// </summary>
        SPI_GETPOWEROFFTIMEOUT = 0x0050,

        /// <summary>
        /// SPI_SETLOWPOWERACTIVE
        /// </summary>
        SPI_SETLOWPOWERACTIVE = 0x0055,

        /// <summary>
        /// SPI_SETLOWPOWERTIMEOUT
        /// </summary>
        SPI_SETLOWPOWERTIMEOUT = 0x0051,

        /// <summary>
        /// SPI_SETPOWEROFFACTIVE
        /// </summary>
        SPI_SETPOWEROFFACTIVE = 0x0056,

        /// <summary>
        /// SPI_SETPOWEROFFTIMEOUT
        /// </summary>
        SPI_SETPOWEROFFTIMEOUT = 0x0052,

        /// <summary>
        /// SPI_GETSCREENSAVEACTIVE
        /// </summary>
        SPI_GETSCREENSAVEACTIVE = 0x0010,

        /// <summary>
        /// SPI_GETSCREENSAVERRUNNING
        /// </summary>
        SPI_GETSCREENSAVERRUNNING = 0x0072,

        /// <summary>
        /// SPI_GETSCREENSAVESECURE
        /// </summary>
        SPI_GETSCREENSAVESECURE = 0x0076,

        /// <summary>
        /// SPI_GETSCREENSAVETIMEOUT
        /// </summary>
        SPI_GETSCREENSAVETIMEOUT = 0x000E,

        /// <summary>
        /// SPI_SETSCREENSAVEACTIVE
        /// </summary>
        SPI_SETSCREENSAVEACTIVE = 0x0011,

        /// <summary>
        /// SPI_SETSCREENSAVESECURE
        /// </summary>
        SPI_SETSCREENSAVESECURE = 0x0077,

        /// <summary>
        /// SPI_SETSCREENSAVETIMEOUT
        /// </summary>
        SPI_SETSCREENSAVETIMEOUT = 0x000F,

        /// <summary>
        /// SPI_GETHUNGAPPTIMEOUT
        /// </summary>
        SPI_GETHUNGAPPTIMEOUT = 0x0078,

        /// <summary>
        /// SPI_GETWAITTOKILLTIMEOUT
        /// </summary>
        SPI_GETWAITTOKILLTIMEOUT = 0x007A,

        /// <summary>
        /// SPI_GETWAITTOKILLSERVICETIMEOUT
        /// </summary>
        SPI_GETWAITTOKILLSERVICETIMEOUT = 0x007C,

        /// <summary>
        /// SPI_SETHUNGAPPTIMEOUT
        /// </summary>
        SPI_SETHUNGAPPTIMEOUT = 0x0079,

        /// <summary>
        /// SPI_SETWAITTOKILLTIMEOUT
        /// </summary>
        SPI_SETWAITTOKILLTIMEOUT = 0x007B,

        /// <summary>
        /// SPI_SETWAITTOKILLSERVICETIMEOUT
        /// </summary>
        SPI_SETWAITTOKILLSERVICETIMEOUT = 0x007D,

        /// <summary>
        /// SPI_GETCOMBOBOXANIMATION
        /// </summary>
        SPI_GETCOMBOBOXANIMATION = 0x1004,

        /// <summary>
        /// SPI_GETCURSORSHADOW
        /// </summary>
        SPI_GETCURSORSHADOW = 0x101A,

        /// <summary>
        /// SPI_GETGRADIENTCAPTIONS
        /// </summary>
        SPI_GETGRADIENTCAPTIONS = 0x100B,

        /// <summary>
        /// SPI_GETHOTTRACKING
        /// </summary>
        SPI_GETHOTTRACKING = 0x100E,

        /// <summary>
        /// SPI_GETLISTBOXSMOOTHSCROLLING
        /// </summary>
        SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006,

        /// <summary>
        /// SPI_GETMENUANIMATION
        /// </summary>
        SPI_GETMENUANIMATION = 0x1002,

        /// <summary>
        /// SPI_GETMENUUNDERLINES
        /// </summary>
        SPI_GETMENUUNDERLINES = 0x100A,

        /// <summary>
        /// SPI_GETSELECTIONFADE
        /// </summary>
        SPI_GETSELECTIONFADE = 0x1014,

        /// <summary>
        /// SPI_GETTOOLTIPANIMATION
        /// </summary>
        SPI_GETTOOLTIPANIMATION = 0x1016,

        /// <summary>
        /// SPI_GETTOOLTIPFADE
        /// </summary>
        SPI_GETTOOLTIPFADE = 0x1018,

        /// <summary>
        /// SPI_GETUIEFFECTS
        /// </summary>
        SPI_GETUIEFFECTS = 0x103E,

        /// <summary>
        /// SPI_SETCOMBOBOXANIMATION
        /// </summary>
        SPI_SETCOMBOBOXANIMATION = 0x1005,

        /// <summary>
        /// SPI_SETCURSORSHADOW
        /// </summary>
        SPI_SETCURSORSHADOW = 0x101B,

        /// <summary>
        /// SPI_SETGRADIENTCAPTIONS
        /// </summary>
        SPI_SETGRADIENTCAPTIONS = 0x1009,

        /// <summary>
        /// SPI_SETHOTTRACKING
        /// </summary>
        SPI_SETHOTTRACKING = 0x100F,

        /// <summary>
        /// SPI_SETLISTBOXSMOOTHSCROLLING
        /// </summary>
        SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007,

        /// <summary>
        /// SPI_SETMENUANIMATION
        /// </summary>
        SPI_SETMENUANIMATION = 0x1003,

        /// <summary>
        /// SPI_SETMENUUNDERLINES
        /// </summary>
        SPI_SETMENUUNDERLINES = 0x100B,

        /// <summary>
        /// SPI_SETSELECTIONFADE
        /// </summary>
        SPI_SETSELECTIONFADE = 0x1015,

        /// <summary>
        /// SPI_SETTOOLTIPANIMATION
        /// </summary>
        SPI_SETTOOLTIPANIMATION = 0x1017,

        /// <summary>
        /// SPI_SETTOOLTIPFADE
        /// </summary>
        SPI_SETTOOLTIPFADE = 0x1019,

        /// <summary>
        /// SPI_SETUIEFFECTS
        /// </summary>
        SPI_SETUIEFFECTS = 0x103F,

        /// <summary>
        /// SPI_GETACTIVEWINDOWTRACKING
        /// </summary>
        SPI_GETACTIVEWINDOWTRACKING = 0x1000,

        /// <summary>
        /// SPI_GETACTIVEWNDTRKZORDER
        /// </summary>
        SPI_GETACTIVEWNDTRKZORDER = 0x100C,

        /// <summary>
        /// SPI_GETACTIVEWNDTRKTIMEOUT
        /// </summary>
        SPI_GETACTIVEWNDTRKTIMEOUT = 0x2002,

        /// <summary>
        /// SPI_GETANIMATION
        /// </summary>
        SPI_GETANIMATION = 0x0048,

        /// <summary>
        /// SPI_GETBORDER
        /// </summary>
        SPI_GETBORDER = 0x0005,

        /// <summary>
        /// SPI_GETCARETWIDTH
        /// </summary>
        SPI_GETCARETWIDTH = 0x2006,

        /// <summary>
        /// SPI_GETDOCKMOVING
        /// </summary>
        SPI_GETDOCKMOVING = 0x0090,

        /// <summary>
        /// SPI_GETDRAGFROMMAXIMIZE
        /// </summary>
        SPI_GETDRAGFROMMAXIMIZE = 0x008C,

        /// <summary>
        /// SPI_GETDRAGFULLWINDOWS
        /// </summary>
        SPI_GETDRAGFULLWINDOWS = 0x0026,

        /// <summary>
        /// SPI_GETFOREGROUNDFLASHCOUNT
        /// </summary>
        SPI_GETFOREGROUNDFLASHCOUNT = 0x2004,

        /// <summary>
        /// SPI_GETFOREGROUNDLOCKTIMEOUT
        /// </summary>
        SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,

        /// <summary>
        /// SPI_GETMINIMIZEDMETRICS
        /// </summary>
        SPI_GETMINIMIZEDMETRICS = 0x002B,

        /// <summary>
        /// SPI_GETMOUSEDOCKTHRESHOLD
        /// </summary>
        SPI_GETMOUSEDOCKTHRESHOLD = 0x007E,

        /// <summary>
        /// SPI_GETMOUSEDRAGOUTTHRESHOLD
        /// </summary>
        SPI_GETMOUSEDRAGOUTTHRESHOLD = 0x0084,

        /// <summary>
        /// SPI_GETMOUSESIDEMOVETHRESHOLD
        /// </summary>
        SPI_GETMOUSESIDEMOVETHRESHOLD = 0x0088,

        /// <summary>
        /// SPI_GETNONCLIENTMETRICS
        /// </summary>
        SPI_GETNONCLIENTMETRICS = 0x0029,

        /// <summary>
        /// SPI_GETPENDOCKTHRESHOLD
        /// </summary>
        SPI_GETPENDOCKTHRESHOLD = 0x0080,

        /// <summary>
        /// SPI_GETPENDRAGOUTTHRESHOLD
        /// </summary>
        SPI_GETPENDRAGOUTTHRESHOLD = 0x0086,

        /// <summary>
        /// SPI_GETPENSIDEMOVETHRESHOLD
        /// </summary>
        SPI_GETPENSIDEMOVETHRESHOLD = 0x008A,

        /// <summary>
        /// SPI_GETSHOWIMEUI
        /// </summary>
        SPI_GETSHOWIMEUI = 0x006E,

        /// <summary>
        /// SPI_GETSNAPSIZING
        /// </summary>
        SPI_GETSNAPSIZING = 0x008E,

        /// <summary>
        /// SPI_GETWINARRANGING
        /// </summary>
        SPI_GETWINARRANGING = 0x0082,

        /// <summary>
        /// SPI_SETACTIVEWINDOWTRACKING
        /// </summary>
        SPI_SETACTIVEWINDOWTRACKING = 0x1001,

        /// <summary>
        /// SPI_SETACTIVEWNDTRKZORDER
        /// </summary>
        SPI_SETACTIVEWNDTRKZORDER = 0x100D,

        /// <summary>
        /// SPI_SETACTIVEWNDTRKTIMEOUT
        /// </summary>
        SPI_SETACTIVEWNDTRKTIMEOUT = 0x2003,

        /// <summary>
        /// SPI_SETANIMATION
        /// </summary>
        SPI_SETANIMATION = 0x0049,

        /// <summary>
        /// SPI_SETBORDER
        /// </summary>
        SPI_SETBORDER = 0x0006,

        /// <summary>
        /// SPI_SETCARETWIDTH
        /// </summary>
        SPI_SETCARETWIDTH = 0x2007,

        /// <summary>
        /// SPI_SETDOCKMOVING
        /// </summary>
        SPI_SETDOCKMOVING = 0x0091,

        /// <summary>
        /// SPI_SETDRAGFROMMAXIMIZE
        /// </summary>
        SPI_SETDRAGFROMMAXIMIZE = 0x008D,

        /// <summary>
        /// SPI_SETDRAGFULLWINDOWS
        /// </summary>
        SPI_SETDRAGFULLWINDOWS = 0x0025,

        /// <summary>
        /// SPI_SETDRAGHEIGHT
        /// </summary>
        SPI_SETDRAGHEIGHT = 0x004D,

        /// <summary>
        /// SPI_SETDRAGWIDTH
        /// </summary>
        SPI_SETDRAGWIDTH = 0x004C,

        /// <summary>
        /// SPI_SETFOREGROUNDFLASHCOUNT
        /// </summary>
        SPI_SETFOREGROUNDFLASHCOUNT = 0x2005,

        /// <summary>
        /// SPI_SETFOREGROUNDLOCKTIMEOUT
        /// </summary>
        SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001,

        /// <summary>
        /// SPI_SETMINIMIZEDMETRICS
        /// </summary>
        SPI_SETMINIMIZEDMETRICS = 0x002C,

        /// <summary>
        /// SPI_SETMOUSEDOCKTHRESHOLD
        /// </summary>
        SPI_SETMOUSEDOCKTHRESHOLD = 0x007F,

        /// <summary>
        /// SPI_SETMOUSEDRAGOUTTHRESHOLD
        /// </summary>
        SPI_SETMOUSEDRAGOUTTHRESHOLD = 0x0085,

        /// <summary>
        /// SPI_SETMOUSESIDEMOVETHRESHOLD
        /// </summary>
        SPI_SETMOUSESIDEMOVETHRESHOLD = 0x0089,

        /// <summary>
        /// SPI_SETNONCLIENTMETRICS
        /// </summary>
        SPI_SETNONCLIENTMETRICS = 0x002A,

        /// <summary>
        /// SPI_SETPENDOCKTHRESHOLD
        /// </summary>
        SPI_SETPENDOCKTHRESHOLD = 0x0081,

        /// <summary>
        /// SPI_SETPENDRAGOUTTHRESHOLD
        /// </summary>
        SPI_SETPENDRAGOUTTHRESHOLD = 0x0087,

        /// <summary>
        /// SPI_SETPENSIDEMOVETHRESHOLD
        /// </summary>
        SPI_SETPENSIDEMOVETHRESHOLD = 0x008B,

        /// <summary>
        /// SPI_SETSHOWIMEUI
        /// </summary>
        SPI_SETSHOWIMEUI = 0x006F,

        /// <summary>
        /// SPI_SETSNAPSIZING
        /// </summary>
        SPI_SETSNAPSIZING = 0x008F,

        /// <summary>
        /// SPI_SETWINARRANGING
        /// </summary>
        SPI_SETWINARRANGING = 0x0083,
    }
}
