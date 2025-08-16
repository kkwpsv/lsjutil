using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.PrintDialogFlags;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Common dialog extended error codes
    /// </summary>
    public enum CommonDialogExtendedErrorCodes : uint
    {
        /// <summary>
        /// CDERR_DIALOGFAILURE
        /// </summary>
        CDERR_DIALOGFAILURE = 0xFFFF,

        /// <summary>
        /// CDERR_FINDRESFAILURE
        /// </summary>
        CDERR_FINDRESFAILURE = 0x0006,

        /// <summary>
        /// CDERR_INITIALIZATION
        /// </summary>
        CDERR_INITIALIZATION = 0x0002,

        /// <summary>
        /// CDERR_LOADRESFAILURE
        /// </summary>
        CDERR_LOADRESFAILURE = 0x0007,

        /// <summary>
        /// CDERR_LOADSTRFAILURE
        /// </summary>
        CDERR_LOADSTRFAILURE = 0x0005,

        /// <summary>
        /// CDERR_LOCKRESFAILURE
        /// </summary>
        CDERR_LOCKRESFAILURE = 0x0008,

        /// <summary>
        /// CDERR_MEMALLOCFAILURE
        /// </summary>
        CDERR_MEMALLOCFAILURE = 0x0009,

        /// <summary>
        /// CDERR_MEMLOCKFAILURE
        /// </summary>
        CDERR_MEMLOCKFAILURE = 0x000A,

        /// <summary>
        /// CDERR_NOHINSTANCE
        /// </summary>
        CDERR_NOHINSTANCE = 0x0004,

        /// <summary>
        /// CDERR_NOHOOK
        /// </summary>
        CDERR_NOHOOK = 0x000B,

        /// <summary>
        /// CDERR_NOTEMPLATE
        /// </summary>
        CDERR_NOTEMPLATE = 0x0003,

        /// <summary>
        /// CDERR_REGISTERMSGFAIL
        /// </summary>
        CDERR_REGISTERMSGFAIL = 0x000C,

        /// <summary>
        /// CDERR_STRUCTSIZE
        /// </summary>
        CDERR_STRUCTSIZE = 0x0001,

        /// <summary>
        /// PDERR_CREATEICFAILURE
        /// </summary>
        PDERR_CREATEICFAILURE = 0x100A,

        /// <summary>
        /// PDERR_DEFAULTDIFFERENT
        /// </summary>
        PDERR_DEFAULTDIFFERENT = 0x100C,

        /// <summary>
        /// PDERR_DNDMMISMATCH
        /// </summary>
        PDERR_DNDMMISMATCH = 0x1009,

        /// <summary>
        /// PDERR_GETDEVMODEFAIL
        /// </summary>
        PDERR_GETDEVMODEFAIL = 0x1005,

        /// <summary>
        /// PDERR_INITFAILURE
        /// </summary>
        PDERR_INITFAILURE = 0x1006,

        /// <summary>
        /// PDERR_LOADDRVFAILURE
        /// </summary>
        PDERR_LOADDRVFAILURE = 0x1004,

        /// <summary>
        /// PDERR_NODEFAULTPRN
        /// </summary>
        PDERR_NODEFAULTPRN = 0x1008,

        /// <summary>
        /// PDERR_NODEVICES
        /// </summary>
        PDERR_NODEVICES = 0x1007,

        /// <summary>
        /// PDERR_PARSEFAILURE
        /// </summary>
        PDERR_PARSEFAILURE = 0x1002,

        /// <summary>
        /// PDERR_PRINTERNOTFOUND
        /// </summary>
        PDERR_PRINTERNOTFOUND = 0x100B,

        /// <summary>
        /// PDERR_RETDEFFAILURE
        /// </summary>
        PDERR_RETDEFFAILURE = 0x1003,

        /// <summary>
        /// PDERR_SETUPFAILURE
        /// </summary>
        PDERR_SETUPFAILURE = 0x1001,

        /// <summary>
        /// CFERR_MAXLESSTHANMIN
        /// </summary>
        CFERR_MAXLESSTHANMIN = 0x2002,

        /// <summary>
        /// CFERR_NOFONTS
        /// </summary>
        CFERR_NOFONTS = 0x2001,

        /// <summary>
        /// FNERR_BUFFERTOOSMALL
        /// </summary>
        FNERR_BUFFERTOOSMALL = 0x3003,

        /// <summary>
        /// FNERR_INVALIDFILENAME
        /// </summary>
        FNERR_INVALIDFILENAME = 0x3002,

        /// <summary>
        /// FNERR_SUBCLASSFAILURE
        /// </summary>
        FNERR_SUBCLASSFAILURE = 0x3001,

        /// <summary>
        /// FRERR_BUFFERLENGTHZERO
        /// </summary>
        FRERR_BUFFERLENGTHZERO = 0x4001,
    }
}
