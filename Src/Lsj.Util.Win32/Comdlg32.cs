using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.CHOOSEFONTFlags;
using static Lsj.Util.Win32.Enums.CommDlgExtendedErrorCodes;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Comdlg32.dll
    /// </summary>
    public static class Comdlg32
    {
        /// <summary>
        /// <para>
        /// Creates a Font dialog box that enables the user to choose attributes for a logical font.
        /// These attributes include a font family and associated font style, a point size, effects (underline, strikeout, and text color),
        /// and a script (or character set).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms646914(v%3Dvs.85)
        /// </para>
        /// </summary>
        /// <param name="lpcf">
        /// A pointer to a <see cref="CHOOSEFONT"/> structure that contains information used to initialize the dialog box.
        /// When <see cref="ChooseFont"/> returns, this structure contains information about the user's font selection.
        /// </param>
        /// <returns>
        /// If the user clicks the OK button of the dialog box, the return value is <see cref="TRUE"/>.
        /// The members of the <see cref="CHOOSEFONT"/> structure indicate the user's selections.
        /// If the user cancels or closes the Font dialog box or an error occurs, the return value is <see langword="false"/>.
        /// To get extended error information, call the <see cref="CommDlgExtendedError"/> function, which can return one of the following values.
        /// <see cref="CDERR_DIALOGFAILURE"/>, <see cref="CDERR_FINDRESFAILURE"/>, <see cref="CDERR_NOHINSTANCE"/>,
        /// <see cref="CDERR_INITIALIZATION"/>, <see cref="CDERR_NOHOOK"/>, <see cref="CDERR_LOCKRESFAILURE"/>,
        /// <see cref="CDERR_NOTEMPLATE"/>, <see cref="CDERR_LOADRESFAILURE"/>, <see cref="CDERR_STRUCTSIZE"/>,
        /// <see cref="CDERR_LOADSTRFAILURE"/>, <see cref="CFERR_MAXLESSTHANMIN"/>, <see cref="CDERR_MEMALLOCFAILURE"/>,
        /// <see cref="CFERR_NOFONTS"/>, <see cref="CDERR_MEMLOCKFAILURE"/>
        /// </returns>
        /// <remarks>
        /// You can provide a <see cref="CFHookProc"/> hook procedure for a Font dialog box.
        /// The hook procedure can process messages sent to the dialog box.
        /// To enable a hook procedure, set the <see cref="CF_ENABLEHOOK"/> flag in the <see cref="CHOOSEFONT.Flags"/> member
        /// of the <see cref="CHOOSEFONT"/> structure and specify the address of the hook procedure in the lpfnHook member.
        /// The hook procedure can send the <see cref="WM_CHOOSEFONT_GETLOGFONT"/>, <see cref="WM_CHOOSEFONT_SETFLAGS"/>,
        /// and <see cref="WM_CHOOSEFONT_SETLOGFONT"/> messages to the dialog box to get and set the current values and flags of the dialog box.
        /// </remarks>
        [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChooseFontW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ChooseFont([In][Out]ref CHOOSEFONT lpcf);
    }
}
