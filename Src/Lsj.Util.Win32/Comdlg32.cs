using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.CHOOSEFONTFlags;
using static Lsj.Util.Win32.Enums.CommDlgExtendedErrorCodes;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Enums.PRINTDLGFlags;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Comdlg32.dll
    /// </summary>
    public static class Comdlg32
    {
        /// <summary>
        /// <para>
        /// Receives messages or notifications intended for the default dialog box procedure of the Print dialog box.
        /// This is an application-defined or library-defined callback function that is used with the <see cref="PrintDlg"/> function.
        /// The <see cref="LPPRINTHOOKPROC"/> type defines a pointer to this callback function.
        /// PrintHookProc is a placeholder for the application-defined or library-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/nc-commdlg-lpprinthookproc
        /// </para>
        /// </summary>
        /// <param name="Arg1"></param>
        /// <param name="Arg2"></param>
        /// <param name="Arg3"></param>
        /// <param name="Arg4"></param>
        /// <returns>
        /// If the hook procedure returns zero, the default dialog box procedure processes the message.
        /// If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.
        /// </returns>
        /// <remarks>
        /// When you use the <see cref="PrintDlg"/> function to create a Print dialog box,
        /// you can provide a PrintHookProc hook procedure to process messages or notifications intended for the dialog box procedure.
        /// To enable the hook procedure, use the <see cref="PRINTDLG"/> structure that you passed to the dialog creation function.
        /// Specify the address of the hook procedure in the <see cref="PRINTDLG.lpfnPrintHook"/> member
        /// and specify the <see cref="PD_ENABLEPRINTHOOK"/> flag in the <see cref="PRINTDLG.Flags"/> member.
        /// The default dialog box procedure processes the <see cref="WM_INITDIALOG"/> message before passing it to the hook procedure.
        /// For all other messages, the hook procedure receives the message first.
        /// Then, the return value of the hook procedure determines whether the default dialog procedure processes the message or ignores it.
        /// If the hook procedure processes the <see cref="WM_CTLCOLORDLG"/> message, it must return a valid brush handle
        /// to painting the background of the dialog box.
        /// In general, if the hook procedure processes any WM_CTLCOLOR* message, it must return a valid brush handle
        /// to painting the background of the specified control.
        /// Do not call the <see cref="EndDialog"/> function from the hook procedure.
        /// Instead, the hook procedure can call the <see cref="PostMessage"/> function to post a <see cref="WM_COMMAND"/> message
        /// with the <see cref="IDABORT"/> value to the dialog box procedure.
        /// Posting <see cref="IDABORT"/> closes the dialog box and causes the dialog box function to return <see cref="FALSE"/>.
        /// If you need to know why the hook procedure closed the dialog box, you must provide your own communication mechanism
        /// between the hook procedure and your application.
        /// You can subclass the standard controls of a common dialog box.
        /// However, the dialog box procedure may also subclass the controls.
        /// Because of this, you should subclass controls when your hook procedure processes the <see cref="WM_INITDIALOG"/> message.
        /// This ensures that your subclass procedure receives the control-specific messages before the subclass procedure set by the dialog box procedure.
        /// </remarks>
        public delegate UINT_PTR LPPRINTHOOKPROC([In]HWND Arg1, [In]UINT Arg2, [In]WPARAM Arg3, [In]LPARAM Arg4);

        /// <summary>
        /// <para>
        /// An application-defined or library-defined callback function used with the <see cref="PrintDlg"/> function.
        /// The hook procedure receives messages or notifications intended for the default dialog box procedure of the Print Setup dialog box.
        /// The <see cref="LPSETUPHOOKPROC"/> type defines a pointer to this callback function.
        /// SetupHookProc is a placeholder for the application-defined or library-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/nc-commdlg-lpsetuphookproc
        /// </para>
        /// </summary>
        /// <param name="Arg1"></param>
        /// <param name="Arg2"></param>
        /// <param name="Arg3"></param>
        /// <param name="Arg4"></param>
        /// <returns>
        /// If the hook procedure returns zero, the default dialog box procedure processes the message.
        /// If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.
        /// </returns>
        /// <remarks>
        /// The Print Setup dialog box has been superseded by the Page Setup dialog box, which should be used by new applications.
        /// However, for compatibility, the <see cref="PrintDlg"/> function continues to support display of the Print Setup dialog box.
        /// You can provide a SetupHookProc hook procedure for the Print Setup dialog box to process messages
        /// or notifications intended for the dialog box procedure.
        /// To enable the hook procedure, use the <see cref="PRINTDLG"/> structure that you passed to the dialog creation function.
        /// Specify the address of the hook procedure in the <see cref="PRINTDLG.lpfnSetupHook"/> member
        /// and specify the <see cref="PD_ENABLESETUPHOOK"/> flag in the <see cref="PRINTDLG.Flags"/> member.
        /// The default dialog box procedure processes the <see cref="WM_INITDIALOG"/> message before passing it to the hook procedure.
        /// For all other messages, the hook procedure receives the message first.
        /// Then, the return value of the hook procedure determines whether the default dialog procedure processes the message or ignores it.
        /// If the hook procedure processes the <see cref="WM_CTLCOLORDLG"/> message,
        /// it must return a valid brush handle to painting the background of the dialog box.
        /// In general, if the hook procedure processes any WM_CTLCOLOR* message,
        /// it must return a valid brush handle to painting the background of the specified control.
        /// Do not call the <see cref="EndDialog"/> function from the hook procedure.
        /// Instead, the hook procedure can call the <see cref="PostMessage"/> function to post
        /// a <see cref="WM_COMMAND"/> message with the <see cref="IDABORT"/> value to the dialog box procedure.
        /// Posting <see cref="IDABORT"/> closes the dialog box and causes the dialog box function to return <see cref="FALSE"/>.
        /// If you need to know why the hook procedure closed the dialog box,
        /// you must provide your own communication mechanism between the hook procedure and your application.
        /// You can subclass the standard controls of a common dialog box.
        /// However, the dialog box procedure may also subclass the controls.
        /// Because of this, you should subclass controls when your hook procedure processes the <see cref="WM_INITDIALOG"/> message.
        /// This ensures that your subclass procedure receives the control-specific messages before the subclass procedure set by the dialog box procedure.
        /// </remarks>
        public delegate UINT_PTR LPSETUPHOOKPROC([In]HWND Arg1, [In]UINT Arg2, [In]WPARAM Arg3, [In]LPARAM Arg4);

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

        /// <summary>
        /// <para>
        /// Displays a Print Dialog Box or a Print Setup dialog box.
        /// The Print dialog box enables the user to specify the properties of a particular print job.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms646940(v=vs.85)
        /// </para>
        /// </summary>
        /// <param name="lppd">
        /// A pointer to a <see cref="PRINTDLG"/> structure that contains information used to initialize the dialog box.
        /// When <see cref="PrintDlg"/> returns, this structure contains information about the user's selections.
        /// </param>
        /// <returns>
        /// If the user clicks the OK button, the return value is <see cref="TRUE"/>.
        /// The members of the <see cref="PRINTDLG"/> structure pointed to by the lppd parameter indicate the user's selections.
        /// If the user canceled or closed the Print or Printer Setup dialog box or an error occurred, the return value is <see cref="FALSE"/>.
        /// To get extended error information, use the <see cref="CommDlgExtendedError"/> function.
        /// If the user canceled or closed the dialog box, <see cref="CommDlgExtendedError"/> returns zero;
        /// otherwise, it returns one of the following values.
        /// <see cref="CDERR_FINDRESFAILURE"/>, <see cref="CDERR_INITIALIZATION"/>, <see cref="CDERR_LOADRESFAILURE"/>,
        /// <see cref="CDERR_LOADSTRFAILURE"/>, <see cref="CDERR_LOCKRESFAILURE"/>, <see cref="CDERR_MEMALLOCFAILURE"/>,
        /// <see cref="CDERR_MEMLOCKFAILURE"/>, <see cref="CDERR_NOHINSTANCE"/>, <see cref="CDERR_NOHOOK"/>,
        /// <see cref="CDERR_NOTEMPLATE"/>, <see cref="CDERR_STRUCTSIZE"/>, <see cref="PDERR_CREATEICFAILURE"/>,
        /// <see cref="PDERR_DEFAULTDIFFERENT"/>, <see cref="PDERR_DNDMMISMATCH"/>, <see cref="PDERR_GETDEVMODEFAIL"/>,
        /// <see cref="PDERR_INITFAILURE"/>, <see cref="PDERR_LOADDRVFAILURE"/>, <see cref="PDERR_NODEFAULTPRN"/>,
        /// <see cref="PDERR_NODEVICES"/>, <see cref="PDERR_PARSEFAILURE"/>, <see cref="PDERR_PRINTERNOTFOUND"/>,
        /// <see cref="PDERR_RETDEFFAILURE"/>
        /// </returns>
        /// <remarks>
        /// If the hook procedure (pointed to by the <see cref="PRINTDLG.lpfnPrintHook"/> or <see cref="PRINTDLG.lpfnSetupHook"/> member
        /// of the <see cref="PRINTDLG"/> structure) processes the <see cref="WM_CTLCOLORDLG"/> message,
        /// the hook procedure must return a handle to the brush that should be used to paint the control background.
        /// Note that the values of hDevMode and hDevNames in <see cref="PRINTDLG"/> may change when they are passed into <see cref="PrintDlg"/>.
        /// This is because these members are filled on both input and output.
        /// To switch printer selection, use <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/>.
        /// Windows Server 2003, Windows XP, and Windows 2000: To switch printer selection, use the Printer button
        /// Known issue: If <see cref="PD_RETURNDC"/> is set but <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> flag is not set,
        /// the <see cref="PrintDlgEx"/> and <see cref="PrintDlg"/> functions return incorrect number of copies.
        /// To get the correct number of copies, ensure that the calling application
        /// always uses <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> with <see cref="PD_RETURNDC"/>.
        /// </remarks>
        [Obsolete("PrintDlg is available for use in the operating systems specified in the Requirements section." +
            "It may be altered or unavailable in subsequent versions. Instead, use PrintDlgEx or PageSetupDlg.")]
        [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "PrintDlgW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PrintDlg([In][Out]ref PRINTDLG lppd);
    }
}
