using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Print dialog flags
    /// </summary>
    [Flags]
    public enum PrintDialogFlags : uint
    {
        /// <summary>
        /// PD_ALLPAGES
        /// </summary>
        PD_ALLPAGES = 0x00000000,

        /// <summary>
        /// PD_COLLATE
        /// </summary>
        PD_COLLATE = 0x00000010,

        /// <summary>
        /// PD_CURRENTPAGE
        /// </summary>
        PD_CURRENTPAGE = 0x00400000,

        /// <summary>
        /// PD_DISABLEPRINTTOFILE
        /// </summary>
        PD_DISABLEPRINTTOFILE = 0x00080000,

        /// <summary>
        /// PD_ENABLEPRINTHOOK
        /// </summary>
        PD_ENABLEPRINTHOOK = 0x00001000,

        /// <summary>
        /// PD_ENABLEPRINTTEMPLATE
        /// </summary>
        PD_ENABLEPRINTTEMPLATE = 0x00004000,

        /// <summary>
        /// PD_ENABLEPRINTTEMPLATEHANDLE
        /// </summary>
        PD_ENABLEPRINTTEMPLATEHANDLE = 0x00010000,

        /// <summary>
        /// PD_ENABLESETUPHOOK
        /// </summary>
        PD_ENABLESETUPHOOK = 0x00002000,

        /// <summary>
        /// PD_ENABLESETUPTEMPLATE
        /// </summary>
        PD_ENABLESETUPTEMPLATE = 0x00008000,

        /// <summary>
        /// PD_ENABLESETUPTEMPLATEHANDLE
        /// </summary>
        PD_ENABLESETUPTEMPLATEHANDLE = 0x00020000,

        /// <summary>
        /// PD_EXCLUSIONFLAGS
        /// </summary>
        PD_EXCLUSIONFLAGS = 0x01000000,

        /// <summary>
        /// PD_HIDEPRINTTOFILE
        /// </summary>
        PD_HIDEPRINTTOFILE = 0x00100000,

        /// <summary>
        /// PD_NOCURRENTPAGE
        /// </summary>
        PD_NOCURRENTPAGE = 0x00800000,

        /// <summary>
        /// PD_NONETWORKBUTTON
        /// </summary>
        PD_NONETWORKBUTTON = 0x00200000,

        /// <summary>
        /// PD_NOPAGENUMS
        /// </summary>
        PD_NOPAGENUMS = 0x00000008,

        /// <summary>
        /// PD_NOSELECTION
        /// </summary>
        PD_NOSELECTION = 0x00000004,

        /// <summary>
        /// PD_NOWARNING
        /// </summary>
        PD_NOWARNING = 0x00000080,

        /// <summary>
        /// PD_PAGENUMS
        /// </summary>
        PD_PAGENUMS = 0x00000002,

        /// <summary>
        /// PD_PRINTSETUP
        /// </summary>
        PD_PRINTSETUP = 0x00000040,

        /// <summary>
        /// PD_PRINTTOFILE
        /// </summary>
        PD_PRINTTOFILE = 0x00000020,

        /// <summary>
        /// PD_RETURNDC
        /// </summary>
        PD_RETURNDC = 0x00000100,

        /// <summary>
        /// PD_RETURNDEFAULT
        /// </summary>
        PD_RETURNDEFAULT = 0x00000400,

        /// <summary>
        /// PD_RETURNIC
        /// </summary>
        PD_RETURNIC = 0x00000200,

        /// <summary>
        /// PD_SELECTION
        /// </summary>
        PD_SELECTION = 0x00000001,

        /// <summary>
        /// PD_SHOWHELP
        /// </summary>
        PD_SHOWHELP = 0x00000800,

        /// <summary>
        /// PD_USEDEVMODECOPIES
        /// </summary>
        PD_USEDEVMODECOPIES = 0x00040000,

        /// <summary>
        /// PD_USEDEVMODECOPIESANDCOLLATE
        /// </summary>
        PD_USEDEVMODECOPIESANDCOLLATE = 0x00040000,

        /// <summary>
        /// PD_USELARGETEMPLATE
        /// </summary>
        PD_USELARGETEMPLATE = 0x10000000,
    }
}
