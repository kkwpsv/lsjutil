using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Color dialog box flags
    /// </summary>
    [Flags]
    public enum ColorDialogFlags : uint
    {
        /// <summary>
        /// CC_ANYCOLOR
        /// </summary>
        CC_ANYCOLOR = 0x00000100,

        /// <summary>
        /// CC_ENABLEHOOK
        /// </summary>
        CC_ENABLEHOOK = 0x00000010,

        /// <summary>
        /// CC_ENABLETEMPLATE
        /// </summary>
        CC_ENABLETEMPLATE = 0x00000020,

        /// <summary>
        /// CC_ENABLETEMPLATEHANDLE
        /// </summary>
        CC_ENABLETEMPLATEHANDLE = 0x00000040,

        /// <summary>
        /// CC_FULLOPEN
        /// </summary>
        CC_FULLOPEN = 0x00000002,

        /// <summary>
        /// CC_PREVENTFULLOPEN
        /// </summary>
        CC_PREVENTFULLOPEN = 0x00000004,

        /// <summary>
        /// CC_RGBINIT
        /// </summary>
        CC_RGBINIT = 0x00000001,

        /// <summary>
        /// CC_SHOWHELP
        /// </summary>
        CC_SHOWHELP = 0x00000008,

        /// <summary>
        /// CC_SOLIDCOLOR
        /// </summary>
        CC_SOLIDCOLOR = 0x00000080,
    }
}
