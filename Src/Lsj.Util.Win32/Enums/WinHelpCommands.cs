using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="WinHelp"/> Commands
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-winhelpw
    /// </para>
    /// </summary>
    public enum WinHelpCommands : uint
    {
        /// <summary>
        /// Executes a Help macro or macro string.
        /// </summary>
        HELP_COMMAND = 0x0102,

        /// <summary>
        /// Displays the topic specified by the Contents option in the [OPTIONS] section of the .hpj file.
        /// This command is for backward compatibility.
        /// New applications should provide a .cnt file and use the HELP_FINDER command.
        /// </summary>
        HELP_CONTENTS = 0x0003,

        /// <summary>
        /// Displays the topic identified by the specified context identifier defined in the [MAP] section of the .hpj file.
        /// </summary>
        HELP_CONTEXT = 0x0001,

        /// <summary>
        /// Displays the Help menu for the selected window, then displays the topic for the selected control in a pop-up window.
        /// </summary>
        HELP_CONTEXTMENU = 0x000a,

        /// <summary>
        /// Displays the topic identified by the specified context identifier defined in the [MAP] section of the .hpj file in a pop-up window.
        /// </summary>
        HELP_CONTEXTPOPUP = 0x0008,

        /// <summary>
        /// Displays the Help Topics dialog box.
        /// </summary>
        HELP_FINDER = 0x000b,

        /// <summary>
        /// Ensures that Windows Help is displaying the correct Help file.
        /// If the incorrect Help file is being displayed, Windows Help opens the correct one; otherwise, there is no action.
        /// </summary>
        HELP_FORCEFILE = 0x0009,

        /// <summary>
        /// Displays help on how to use Windows Help, if the Winhlp32.hlp file is available.
        /// </summary>
        HELP_HELPONHELP = 0x0004,

        /// <summary>
        /// Displays the topic specified by the Contents option in the [OPTIONS] section of the .hpj file.
        /// This command is for backward compatibility.
        /// New applications should use the <see cref="HELP_FINDER"/> command.
        /// </summary>
        HELP_INDEX = 0x0003,

        /// <summary>
        /// Displays the topic in the keyword table that matches the specified keyword, if there is an exact match.
        /// If there is more than one match, displays the Index with the topics listed in the Topics Found list box.
        /// </summary>
        HELP_KEY = 0x0101,

        /// <summary>
        /// Displays the topic specified by a keyword in an alternative keyword table.
        /// </summary>
        HELP_MULTIKEY = 0x0201,

        /// <summary>
        /// Displays the topic in the keyword table that matches the specified keyword, if there is an exact match.
        /// If there is more than one match, displays the Topics Found dialog box.
        /// To display the index without passing a keyword, use a pointer to an empty string.
        /// </summary>
        HELP_PARTIALKEY = 0x0105,

        /// <summary>
        /// Informs Windows Help that it is no longer needed.
        /// If no other applications have asked for help, Windows closes Windows Help.
        /// </summary>
        HELP_QUIT = 0x0002,

        /// <summary>
        /// Specifies the Contents topic.
        /// Windows Help displays this topic when the user clicks the Contents button if the Help file does not have an associated .cnt file.
        /// </summary>
        HELP_SETCONTENTS = 0x0005,

        /// <summary>
        /// Sets the position of the subsequent pop-up window.
        /// </summary>
        HELP_SETPOPUP_POS = 0x000d,

        /// <summary>
        /// Displays the Windows Help window, if it is minimized or in memory, and sets its size and position as specified.
        /// </summary>
        HELP_SETWINPOS = 0x0203,

        /// <summary>
        /// Indicates that a command is for a training card instance of Windows Help.
        /// Combine this command with other commands using the bitwise OR operator.
        /// </summary>
        HELP_TCARD = 0x8000,

        /// <summary>
        /// Displays the topic for the control identified by the hWndMain parameter in a pop-up window.
        /// </summary>
        HELP_WM_HELP = 0x000c,
    }
}
