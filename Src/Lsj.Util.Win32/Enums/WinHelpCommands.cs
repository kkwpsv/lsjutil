using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="WinHelp"/> commands
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-winhelpw"/>
    /// </para>
    /// </summary>
    public enum WinHelpCommands : uint
    {
        /// <summary>
        /// HELP_COMMAND
        /// </summary>
        HELP_COMMAND = 0x0102,

        /// <summary>
        /// HELP_CONTENTS
        /// </summary>
        HELP_CONTENTS = 0x0003,

        /// <summary>
        /// HELP_CONTEXT
        /// </summary>
        HELP_CONTEXT = 0x0001,

        /// <summary>
        /// HELP_CONTEXTMENU
        /// </summary>
        HELP_CONTEXTMENU = 0x000a,

        /// <summary>
        /// HELP_CONTEXTPOPUP
        /// </summary>
        HELP_CONTEXTPOPUP = 0x0008,

        /// <summary>
        /// HELP_FINDER
        /// </summary>
        HELP_FINDER = 0x000b,

        /// <summary>
        /// HELP_FORCEFILE
        /// </summary>
        HELP_FORCEFILE = 0x0009,

        /// <summary>
        /// HELP_HELPONHELP
        /// </summary>
        HELP_HELPONHELP = 0x0004,

        /// <summary>
        /// HELP_INDEX
        /// </summary>
        HELP_INDEX = 0x0003,

        /// <summary>
        /// HELP_KEY
        /// </summary>
        HELP_KEY = 0x0101,

        /// <summary>
        /// HELP_MULTIKEY
        /// </summary>
        HELP_MULTIKEY = 0x0201,

        /// <summary>
        /// HELP_PARTIALKEY
        /// </summary>
        HELP_PARTIALKEY = 0x0105,

        /// <summary>
        /// HELP_QUIT
        /// </summary>
        HELP_QUIT = 0x0002,

        /// <summary>
        /// HELP_SETCONTENTS
        /// </summary>
        HELP_SETCONTENTS = 0x0005,

        /// <summary>
        /// HELP_SETPOPUP_POS
        /// </summary>
        HELP_SETPOPUP_POS = 0x000d,

        /// <summary>
        /// HELP_SETWINPOS
        /// </summary>
        HELP_SETWINPOS = 0x0203,

        /// <summary>
        /// HELP_TCARD
        /// </summary>
        HELP_TCARD = 0x8000,

        /// <summary>
        /// HELP_WM_HELP
        /// </summary>
        HELP_WM_HELP = 0x000c,
    }
}
