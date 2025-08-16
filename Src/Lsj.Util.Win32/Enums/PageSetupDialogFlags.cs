using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Page setup dialog flags
    /// </summary>
    [Flags]
    public enum PageSetupDialogFlags : uint
    {
        /// <summary>
        /// PSD_DEFAULTMINMARGINS
        /// </summary>
        PSD_DEFAULTMINMARGINS = 0x00000000,

        /// <summary>
        /// PSD_DISABLEMARGINS
        /// </summary>
        PSD_DISABLEMARGINS = 0x00000010,

        /// <summary>
        /// PSD_DISABLEORIENTATION
        /// </summary>
        PSD_DISABLEORIENTATION = 0x00000100,

        /// <summary>
        /// PSD_DISABLEPAGEPAINTING
        /// </summary>
        PSD_DISABLEPAGEPAINTING = 0x00080000,

        /// <summary>
        /// PSD_DISABLEPAPER
        /// </summary>
        PSD_DISABLEPAPER = 0x00000200,

        /// <summary>
        /// PSD_DISABLEPRINTER
        /// </summary>
        [Obsolete]
        PSD_DISABLEPRINTER = 0x00000020,

        /// <summary>
        /// PSD_ENABLEPAGEPAINTHOOK
        /// </summary>
        PSD_ENABLEPAGEPAINTHOOK = 0x00040000,

        /// <summary>
        /// PSD_ENABLEPAGESETUPHOOK
        /// </summary>
        PSD_ENABLEPAGESETUPHOOK = 0x00002000,

        /// <summary>
        /// PSD_ENABLEPAGESETUPTEMPLATE
        /// </summary>
        PSD_ENABLEPAGESETUPTEMPLATE = 0x00008000,

        /// <summary>
        /// PSD_ENABLEPAGESETUPTEMPLATEHANDLE
        /// </summary>
        PSD_ENABLEPAGESETUPTEMPLATEHANDLE = 0x00020000,

        /// <summary>
        /// PSD_INHUNDREDTHSOFMILLIMETERS
        /// </summary>
        PSD_INHUNDREDTHSOFMILLIMETERS = 0x00000008,

        /// <summary>
        /// PSD_INTHOUSANDTHSOFINCHES
        /// </summary>
        PSD_INTHOUSANDTHSOFINCHES = 0x00000004,

        /// <summary>
        /// PSD_INWININIINTLMEASURE
        /// </summary>
        PSD_INWININIINTLMEASURE = 0x00000000,

        /// <summary>
        /// PSD_MARGINS
        /// </summary>
        PSD_MARGINS = 0x00000002,

        /// <summary>
        /// PSD_MINMARGINS
        /// </summary>
        PSD_MINMARGINS = 0x00000001,

        /// <summary>
        /// PSD_NONETWORKBUTTON
        /// </summary>
        PSD_NONETWORKBUTTON = 0x00200000,

        /// <summary>
        /// PSD_NOWARNING
        /// </summary>
        PSD_NOWARNING = 0x00000080,

        /// <summary>
        /// PSD_RETURNDEFAULT
        /// </summary>
        PSD_RETURNDEFAULT = 0x00000400,

        /// <summary>
        /// PSD_SHOWHELP
        /// </summary>
        PSD_SHOWHELP = 0x00000800,
    }
}
