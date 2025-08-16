using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Find replace dialog flags
    /// </summary>
    [Flags]
    public enum FindReplaceDialogFlags : uint
    {
        /// <summary>
        /// FR_DIALOGTERM
        /// </summary>
        FR_DIALOGTERM = 0x00000040,

        /// <summary>
        /// FR_DOWN
        /// </summary>
        FR_DOWN = 0x00000001,

        /// <summary>
        /// FR_ENABLEHOOK
        /// </summary>
        FR_ENABLEHOOK = 0x00000100,

        /// <summary>
        /// FR_ENABLETEMPLATE
        /// </summary>
        FR_ENABLETEMPLATE = 0x00000200,

        /// <summary>
        /// FR_ENABLETEMPLATEHANDLE
        /// </summary>
        FR_ENABLETEMPLATEHANDLE = 0x00002000,

        /// <summary>
        /// FR_FINDNEXT
        /// </summary>
        FR_FINDNEXT = 0x00000008,

        /// <summary>
        /// FR_HIDEUPDOWN
        /// </summary>
        FR_HIDEUPDOWN = 0x00004000,

        /// <summary>
        /// FR_HIDEMATCHCASE
        /// </summary>
        FR_HIDEMATCHCASE = 0x00008000,

        /// <summary>
        /// FR_HIDEWHOLEWORD
        /// </summary>
        FR_HIDEWHOLEWORD = 0x00010000,

        /// <summary>
        /// FR_MATCHCASE
        /// </summary>
        FR_MATCHCASE = 0x00000004,

        /// <summary>
        /// FR_NOMATCHCASE
        FR_NOMATCHCASE = 0x00000800,

        /// <summary>
        /// FR_NOUPDOWN
        /// </summary>
        FR_NOUPDOWN = 0x00000400,

        /// <summary>
        /// FR_NOWHOLEWORD
        /// </summary>
        FR_NOWHOLEWORD = 0x00001000,

        /// <summary>
        /// FR_REPLACE
        /// </summary>
        FR_REPLACE = 0x00000010,

        /// <summary>
        /// FR_REPLACEALL
        /// </summary>
        FR_REPLACEALL = 0x00000020,

        /// <summary>
        /// FR_SHOWHELP
        /// </summary>
        FR_SHOWHELP = 0x00000080,

        /// <summary>
        /// FR_WHOLEWORD
        /// </summary>
        FR_WHOLEWORD = 0x00000002,
    }
}
