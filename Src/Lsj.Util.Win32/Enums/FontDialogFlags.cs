using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Font dialog flags
    /// </summary>
    [Flags]
    public enum FontDialogFlags : uint
    {
        /// <summary>
        /// CF_APPLY
        /// </summary>
        CF_APPLY = 0x00000200,

        /// <summary>
        /// CF_ANSIONLY
        /// </summary>
        CF_ANSIONLY = 0x00000400,

        /// <summary>
        /// CF_BOTH
        /// </summary>
        CF_BOTH = 0x00000003,

        /// <summary>
        /// CF_EFFECTS
        /// </summary>
        CF_EFFECTS = 0x00000100,

        /// <summary>
        /// CF_ENABLEHOOK
        /// </summary>
        CF_ENABLEHOOK = 0x00000008,

        /// <summary>
        /// CF_ENABLETEMPLATE
        /// </summary>
        CF_ENABLETEMPLATE = 0x00000010,

        /// <summary>
        /// CF_ENABLETEMPLATEHANDLE
        /// </summary>
        CF_ENABLETEMPLATEHANDLE = 0x00000020,

        /// <summary>
        /// CF_FIXEDPITCHONLY
        /// </summary>
        CF_FIXEDPITCHONLY = 0x00004000,

        /// <summary>
        /// CF_FORCEFONTEXIST
        /// </summary>
        CF_FORCEFONTEXIST = 0x00010000,

        /// <summary>
        /// CF_INACTIVEFONTS
        /// </summary>
        CF_INACTIVEFONTS = 0x02000000,

        /// <summary>
        /// CF_INITTOLOGFONTSTRUCT
        /// </summary>
        CF_INITTOLOGFONTSTRUCT = 0x00000040,

        /// <summary>
        /// CF_LIMITSIZE
        /// </summary>
        CF_LIMITSIZE = 0x00002000,

        /// <summary>
        /// CF_NOOEMFONTS
        /// </summary>
        CF_NOOEMFONTS = 0x00000800,

        /// <summary>
        /// CF_NOFACESEL
        /// </summary>
        CF_NOFACESEL = 0x00080000,

        /// <summary>
        /// CF_NOSCRIPTSEL
        /// </summary>
        CF_NOSCRIPTSEL = 0x00800000,

        /// <summary>
        /// CF_NOSIMULATIONS
        /// </summary>
        CF_NOSIMULATIONS = 0x00001000,

        /// <summary>
        /// CF_NOSIZESEL
        /// </summary>
        CF_NOSIZESEL = 0x00200000,

        /// <summary>
        /// CF_NOSTYLESEL
        /// </summary>
        CF_NOSTYLESEL = 0x00100000,

        /// <summary>
        /// CF_NOVECTORFONTS
        /// </summary>
        CF_NOVECTORFONTS = 0x00000800,

        /// <summary>
        /// CF_NOVERTFONTS
        /// </summary>
        CF_NOVERTFONTS = 0x01000000,

        /// <summary>
        /// CF_PRINTERFONTS
        /// </summary>
        CF_PRINTERFONTS = 0x00000002,

        /// <summary>
        /// CF_SCALABLEONLY
        /// </summary>
        CF_SCALABLEONLY = 0x00020000,

        /// <summary>
        /// CF_SCREENFONTS
        /// </summary>
        CF_SCREENFONTS = 0x00000001,

        /// <summary>
        /// CF_SCRIPTSONLY
        /// </summary>
        CF_SCRIPTSONLY = 0x00000400,

        /// <summary>
        /// CF_SELECTSCRIPT
        /// </summary>
        CF_SELECTSCRIPT = 0x00400000,

        /// <summary>
        /// CF_SHOWHELP
        /// </summary>
        CF_SHOWHELP = 0x00000004,

        /// <summary>
        /// CF_TTONLY
        /// </summary>
        CF_TTONLY = 0x00040000,

        /// <summary>
        /// CF_USESTYLE
        /// </summary>
        CF_USESTYLE = 0x00000080,

        /// <summary>
        /// CF_WYSIWYG
        /// </summary>
        CF_WYSIWYG = 0x00008000,
    }
}
