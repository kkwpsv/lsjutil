namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// GDI Escapes
    /// </summary>
    public enum GDIEscapes
    {
        /// <summary>
        /// NEWFRAME
        /// </summary>
        NEWFRAME = 1,

        /// <summary>
        /// ABORTDOC
        /// </summary>
        ABORTDOC = 2,

        /// <summary>
        /// NEXTBAND
        /// </summary>
        NEXTBAND = 3,

        /// <summary>
        /// SETCOLORTABLE
        /// </summary>
        SETCOLORTABLE = 4,

        /// <summary>
        /// GETCOLORTABLE
        /// </summary>
        GETCOLORTABLE = 5,

        /// <summary>
        /// FLUSHOUTPUT
        /// </summary>
        FLUSHOUTPUT = 6,

        /// <summary>
        /// DRAFTMODE
        /// </summary>
        DRAFTMODE = 7,

        /// <summary>
        /// QUERYESCSUPPORT
        /// </summary>
        QUERYESCSUPPORT = 8,

        /// <summary>
        /// SETABORTPROC
        /// </summary>
        SETABORTPROC = 9,

        /// <summary>
        /// STARTDOC
        /// </summary>
        STARTDOC = 10,

        /// <summary>
        /// ENDDOC
        /// </summary>
        ENDDOC = 11,

        /// <summary>
        /// GETPHYSPAGESIZE
        /// </summary>
        GETPHYSPAGESIZE = 12,

        /// <summary>
        /// GETPRINTINGOFFSET
        /// </summary>
        GETPRINTINGOFFSET = 13,

        /// <summary>
        /// GETSCALINGFACTOR
        /// </summary>
        GETSCALINGFACTOR = 14,

        /// <summary>
        /// MFCOMMENT
        /// </summary>
        MFCOMMENT = 15,

        /// <summary>
        /// GETPENWIDTH
        /// </summary>
        GETPENWIDTH = 16,

        /// <summary>
        /// SETCOPYCOUNT
        /// </summary>
        SETCOPYCOUNT = 17,

        /// <summary>
        /// SELECTPAPERSOURCE
        /// </summary>
        SELECTPAPERSOURCE = 18,

        /// <summary>
        /// DEVICEDATA
        /// </summary>
        DEVICEDATA = 19,

        /// <summary>
        /// PASSTHROUGH
        /// </summary>
        PASSTHROUGH = 19,

        /// <summary>
        /// GETTECHNOLGY
        /// </summary>
        GETTECHNOLGY = 20,

        /// <summary>
        /// GETTECHNOLOGY
        /// </summary>
        GETTECHNOLOGY = 20,

        /// <summary>
        /// SETLINECAP
        /// </summary>
        SETLINECAP = 21,

        /// <summary>
        /// SETLINEJOIN
        /// </summary>
        SETLINEJOIN = 22,

        /// <summary>
        /// SETMITERLIMIT
        /// </summary>
        SETMITERLIMIT = 23,

        /// <summary>
        /// BANDINFO
        /// </summary>
        BANDINFO = 24,

        /// <summary>
        /// DRAWPATTERNRECT
        /// </summary>
        DRAWPATTERNRECT = 25,

        /// <summary>
        /// GETVECTORPENSIZE
        /// </summary>
        GETVECTORPENSIZE = 26,

        /// <summary>
        /// GETVECTORBRUSHSIZE
        /// </summary>
        GETVECTORBRUSHSIZE = 27,

        /// <summary>
        /// ENABLEDUPLEX
        /// </summary>
        ENABLEDUPLEX = 28,

        /// <summary>
        /// GETSETPAPERBINS
        /// </summary>
        GETSETPAPERBINS = 29,

        /// <summary>
        /// GETSETPRINTORIENT
        /// </summary>
        GETSETPRINTORIENT = 30,

        /// <summary>
        /// ENUMPAPERBINS
        /// </summary>
        ENUMPAPERBINS = 31,

        /// <summary>
        /// SETDIBSCALING
        /// </summary>
        SETDIBSCALING = 32,

        /// <summary>
        /// EPSPRINTING
        /// </summary>
        EPSPRINTING = 33,

        /// <summary>
        /// ENUMPAPERMETRICS
        /// </summary>
        ENUMPAPERMETRICS = 34,

        /// <summary>
        /// GETSETPAPERMETRICS
        /// </summary>
        GETSETPAPERMETRICS = 35,

        /// <summary>
        /// POSTSCRIPT_DATA
        /// </summary>
        POSTSCRIPT_DATA = 37,

        /// <summary>
        /// POSTSCRIPT_IGNORE
        /// </summary>
        POSTSCRIPT_IGNORE = 38,

        /// <summary>
        /// MOUSETRAILS
        /// </summary>
        MOUSETRAILS = 39,

        /// <summary>
        /// GETDEVICEUNITS
        /// </summary>
        GETDEVICEUNITS = 42,

        /// <summary>
        /// GETEXTENDEDTEXTMETRICS
        /// </summary>
        GETEXTENDEDTEXTMETRICS = 256,

        /// <summary>
        /// GETEXTENTTABLE
        /// </summary>
        GETEXTENTTABLE = 257,

        /// <summary>
        /// GETPAIRKERNTABLE
        /// </summary>
        GETPAIRKERNTABLE = 258,

        /// <summary>
        /// GETTRACKKERNTABLE
        /// </summary>
        GETTRACKKERNTABLE = 259,

        /// <summary>
        /// EXTTEXTOUT
        /// </summary>
        EXTTEXTOUT = 512,

        /// <summary>
        /// GETFACENAME
        /// </summary>
        GETFACENAME = 513,

        /// <summary>
        /// DOWNLOADFACE
        /// </summary>
        DOWNLOADFACE = 514,

        /// <summary>
        /// ENABLERELATIVEWIDTHS
        /// </summary>
        ENABLERELATIVEWIDTHS = 768,

        /// <summary>
        /// ENABLEPAIRKERNING
        /// </summary>
        ENABLEPAIRKERNING = 769,

        /// <summary>
        /// SETKERNTRACK
        /// </summary>
        SETKERNTRACK = 770,

        /// <summary>
        /// SETALLJUSTVALUES
        /// </summary>
        SETALLJUSTVALUES = 771,

        /// <summary>
        /// SETCHARSET
        /// </summary>
        SETCHARSET = 772,

        /// <summary>
        /// STRETCHBLT
        /// </summary>
        STRETCHBLT = 2048,

        /// <summary>
        /// METAFILE_DRIVER
        /// </summary>
        METAFILE_DRIVER = 2049,

        /// <summary>
        /// GETSETSCREENPARAMS
        /// </summary>
        GETSETSCREENPARAMS = 3072,

        /// <summary>
        /// QUERYDIBSUPPORT
        /// </summary>
        QUERYDIBSUPPORT = 3073,

        /// <summary>
        /// BEGIN_PATH
        /// </summary>
        BEGIN_PATH = 4096,

        /// <summary>
        /// CLIP_TO_PATH
        /// </summary>
        CLIP_TO_PATH = 4097,

        /// <summary>
        /// END_PATH
        /// </summary>
        END_PATH = 4098,

        /// <summary>
        /// EXT_DEVICE_CAPS
        /// </summary>
        EXT_DEVICE_CAPS = 4099,

        /// <summary>
        /// RESTORE_CTM
        /// </summary>
        RESTORE_CTM = 4100,

        /// <summary>
        /// SAVE_CTM
        /// </summary>
        SAVE_CTM = 4101,

        /// <summary>
        /// SET_ARC_DIRECTION
        /// </summary>
        SET_ARC_DIRECTION = 4102,

        /// <summary>
        /// SET_BACKGROUND_COLOR
        /// </summary>
        SET_BACKGROUND_COLOR = 4103,

        /// <summary>
        /// SET_POLY_MODE
        /// </summary>
        SET_POLY_MODE = 4104,

        /// <summary>
        /// SET_SCREEN_ANGLE
        /// </summary>
        SET_SCREEN_ANGLE = 4105,

        /// <summary>
        /// SET_SPREAD
        /// </summary>
        SET_SPREAD = 4106,

        /// <summary>
        /// TRANSFORM_CTM
        /// </summary>
        TRANSFORM_CTM = 4107,

        /// <summary>
        /// SET_CLIP_BOX
        /// </summary>
        SET_CLIP_BOX = 4108,

        /// <summary>
        /// SET_BOUNDS
        /// </summary>
        SET_BOUNDS = 4109,

        /// <summary>
        /// SET_MIRROR_MODE
        /// </summary>
        SET_MIRROR_MODE = 4110,

        /// <summary>
        /// OPENCHANNEL
        /// </summary>
        OPENCHANNEL = 4110,

        /// <summary>
        /// DOWNLOADHEADER
        /// </summary>
        DOWNLOADHEADER = 4111,

        /// <summary>
        /// CLOSECHANNEL
        /// </summary>
        CLOSECHANNEL = 4112,

        /// <summary>
        /// POSTSCRIPT_PASSTHROUGH
        /// </summary>
        POSTSCRIPT_PASSTHROUGH = 4115,

        /// <summary>
        /// ENCAPSULATED_POSTSCRIPT
        /// </summary>
        ENCAPSULATED_POSTSCRIPT = 4116,

        /// <summary>
        /// POSTSCRIPT_IDENTIFY
        /// </summary>
        POSTSCRIPT_IDENTIFY = 4117,

        /// <summary>
        /// POSTSCRIPT_INJECTION
        /// </summary>
        POSTSCRIPT_INJECTION = 4118,

        /// <summary>
        /// CHECKJPEGFORMAT
        /// </summary>
        CHECKJPEGFORMAT = 4119,

        /// <summary>
        /// CHECKPNGFORMAT
        /// </summary>
        CHECKPNGFORMAT = 4120,

        /// <summary>
        /// GET_PS_FEATURESETTING
        /// </summary>
        GET_PS_FEATURESETTING = 4121,

        /// <summary>
        /// GDIPLUS_TS_QUERYVER
        /// </summary>
        GDIPLUS_TS_QUERYVER = 4122,

        /// <summary>
        /// GDIPLUS_TS_RECORD
        /// </summary>
        GDIPLUS_TS_RECORD = 4123,
    }
}
