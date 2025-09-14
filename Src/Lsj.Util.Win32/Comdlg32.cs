using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ColorDialogFlags;
using static Lsj.Util.Win32.Enums.FontDialogFlags;
using static Lsj.Util.Win32.Enums.CommonDialogExtendedErrorCodes;
using static Lsj.Util.Win32.Enums.CommonDialogBoxNotifications;
using static Lsj.Util.Win32.Enums.DialogBoxCommandIDs;
using static Lsj.Util.Win32.Enums.FindReplaceDialogFlags;
using static Lsj.Util.Win32.Enums.GetWindowLongIndexes;
using static Lsj.Util.Win32.Enums.OpenFileDialogFlags;
using static Lsj.Util.Win32.Enums.PageSetupDialogFlags;
using static Lsj.Util.Win32.Enums.PrintDialogExResults;
using static Lsj.Util.Win32.Enums.PrintDialogFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.DeviceNamesFlags;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.User32;
using Lsj.Util.Win32.Attributes;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Comdlg32.dll
    /// </summary>
    public static class Comdlg32
    {
        /// <summary>
        /// <para>
        /// Receives messages or notifications intended for the default dialog box procedure of the Color dialog box.
        /// This is an application-defined or library-defined callback function
        /// that is used with the <see cref="ChooseColor"/> function.
        /// </para>
        /// <para>
        /// The <see cref="LPCCHOOKPROC"/> type defines a pointer to this callback function.
        /// CCHookProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpcchookproc"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the Color dialog box for which the message is intended.
        /// </param>
        /// <param name="unnamedParam2">
        /// The identifier of the message being received.
        /// </param>
        /// <param name="unnamedParam3">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </param>
        /// <param name="unnamedParam4">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// If the <paramref name="unnamedParam2"/> parameter indicates the <see cref="WM_INITDIALOG"/> message,
        /// then <paramref name="unnamedParam4"/> is a pointer to a <see cref="CHOOSECOLOR"/> structure
        /// containing the values specified when the dialog was created.
        /// </param>
        /// <returns>
        /// <para>
        /// If the hook procedure returns zero, the default dialog box procedure processes the message.
        /// </para>
        /// <para>
        /// If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you use the <see cref="ChooseColor"/> function to create a Color dialog box,
        /// you can provide a CCHookProc hook procedure to process messages or notifications intended for the dialog box procedure.
        /// To enable the hook procedure,
        /// use the <see cref="CHOOSECOLOR"/> structure that you passed to the dialog creation function.
        /// Specify the address of the hook procedure in the <see cref="CHOOSECOLOR.lpfnHook"/> member
        /// and specify the <see cref="CC_ENABLEHOOK"/> flag in the <see cref="CHOOSECOLOR.Flags"/> member.
        /// </para>
        /// <para>
        /// The default dialog box procedure processes the <see cref="WM_INITDIALOG"/> message before passing it to the hook procedure.
        /// For all other messages, the hook procedure receives the message first.
        /// Then, the return value of the hook procedure determines
        /// whether the default dialog procedure processes the message or ignores it.
        /// </para>
        /// <para>
        /// If the hook procedure processes the <see cref="WM_CTLCOLORDLG"/> message,
        /// it must return a valid brush handle to painting the background of the dialog box.
        /// In general, if the hook procedure processes any WM_CTLCOLOR* message,
        /// it must return a valid brush handle to painting the background of the specified control.
        /// </para>
        /// <para>
        /// Do not call the <see cref="EndDialog"/> function from the hook procedure.
        /// Instead, the hook procedure can call the <see cref="PostMessage"/> function
        /// to post a <see cref="WM_COMMAND"/> message with the <see cref="IDABORT"/> value to the dialog box procedure.
        /// Posting <see cref="IDABORT"/> closes the dialog box
        /// and causes the dialog box function to return <see cref="FALSE"/>.
        /// If you need to know why the hook procedure closed the dialog box,
        /// you must provide your own communication mechanism between the hook procedure and your application.
        /// </para>
        /// <para>
        /// You can subclass the standard controls of a common dialog box.
        /// However, the dialog box procedure may also subclass the controls.
        /// Because of this, you should subclass controls when your hook procedure processes the <see cref="WM_INITDIALOG"/> message.
        /// This ensures that your subclass procedure receives the control-specific messages
        /// before the subclass procedure set by the dialog box procedure.
        /// </para>
        /// </remarks>
        public delegate UINT_PTR Lpcchookproc([In] HWND unnamedParam1, [In] UINT unnamedParam2, [In] WPARAM unnamedParam3, [In] LPARAM unnamedParam4);

        /// <summary>
        /// <para>
        /// Receives messages or notifications intended for the default dialog box procedure of the Font dialog box.
        /// This is an application-defined or library-defined callback procedure
        /// that is used with the <see cref="ChooseFont"/> function.
        /// </para>
        /// <para>
        /// The <see cref="LPCFHOOKPROC"/> type defines a pointer to this callback function.
        /// CFHookProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpcfhookproc"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the Font dialog box for which the message is intended.
        /// </param>
        /// <param name="unnamedParam2">
        /// The identifier of the message being received.
        /// </param>
        /// <param name="unnamedParam3">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </param>
        /// <param name="unnamedParam4">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// If the <paramref name="unnamedParam2"/> parameter indicates the <see cref="WM_INITDIALOG"/> message,
        /// <paramref name="unnamedParam4"/> is a pointer to a <see cref="CHOOSEFONT"/> structure
        /// containing the values specified when the dialog box was created.
        /// </param>
        /// <returns>
        /// <para>
        /// If the hook procedure returns zero, the default dialog box procedure processes the message.
        /// </para>
        /// <para>
        /// If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you use the <see cref="ChooseFont"/> function to create a Font dialog box,
        /// you can provide a CFHookProc hook procedure to process messages or notifications intended for the dialog box procedure.
        /// To enable the hook procedure, use the <see cref="CHOOSEFONT"/> structure that you passed to the dialog creation function.
        /// Specify the address of the hook procedure in the <see cref="CHOOSEFONT.lpfnHook"/> member
        /// and specify the <see cref="CF_ENABLEHOOK"/> flag in the <see cref="CHOOSEFONT.Flags"/> member.
        /// </para>
        /// <para>
        /// The default dialog box procedure processes the <see cref="WM_INITDIALOG"/> message before passing it to the hook procedure.
        /// For all other messages, the hook procedure receives the message first.
        /// The return value of the hook procedure determines
        /// whether the default dialog box procedure processes the message or ignores it.
        /// </para>
        /// <para>
        /// If the hook procedure processes the <see cref="WM_CTLCOLORDLG"/> message,
        /// it must return a valid brush handle to paint the background of the dialog box.
        /// In general, if the hook procedure processes any WM_CTLCOLOR* message,
        /// it must return a valid brush handle to paint the background of the specified control.
        /// </para>
        /// <para>
        /// Do not call the <see cref="EndDialog"/> function from the hook procedure.
        /// Instead, the hook procedure can call the <see cref="PostMessage"/> function
        /// to post a <see cref="WM_COMMAND"/> message with the <see cref="IDABORT"/> value to the dialog box procedure.
        /// Posting <see cref="IDABORT"/> closes the dialog box and causes the dialog box function to return <see cref="FALSE"/>.
        /// If you need to know why the hook procedure closed the dialog box,
        /// you must provide your own communication mechanism between the hook procedure and your application.
        /// </para>
        /// <para>
        /// You can subclass the standard controls of a common dialog box.
        /// However, the dialog box procedure may also subclass the controls.
        /// Because of this, you should subclass controls when your hook procedure processes the <see cref="WM_INITDIALOG"/> message.
        /// This ensures that your subclass procedure receives the control-specific messages
        /// before the subclass procedure set by the dialog box procedure.
        /// </para>
        /// </remarks>
        public delegate UINT_PTR Lpcfhookproc([In] HWND unnamedParam1, [In] UINT unnamedParam2, [In] WPARAM unnamedParam3, [In] LPARAM unnamedParam4);

        /// <summary>
        /// <para>
        /// Receives messages or notifications intended for the default dialog box procedure of the Find or Replace dialog box.
        /// The FRHookProc hook procedure is an application-defined or library-defined callback function
        /// that is used with the <see cref="FindText"/> or <see cref="ReplaceText"/> function.
        /// </para>
        /// <para>
        /// The <see cref="LPFRHOOKPROC"/> type defines a pointer to this callback function.
        /// FRHookProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpfrhookproc"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the Find or Replace dialog box for which the message is intended.
        /// </param>
        /// <param name="unnamedParam2">
        /// The identifier of the message being received.
        /// </param>
        /// <param name="unnamedParam3">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </param>
        /// <param name="unnamedParam4">
        /// <para>
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </para>
        /// <para>
        /// If the <paramref name="unnamedParam2"/> parameter indicates the <see cref="WM_INITDIALOG"/> message,
        /// <paramref name="unnamedParam4"/> is a pointer to a <see cref="FINDREPLACE"/> structure
        /// containing the values specified when the dialog box was created.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the hook procedure returns zero, the default dialog box procedure processes the message.
        /// </para>
        /// <para>
        /// If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you use the <see cref="FindText"/> or <see cref="ReplaceText"/> functions to create a Find or Replace dialog box,
        /// you can provide an FRHookProc hook procedure to process messages or notifications intended for the dialog box procedure.
        /// To enable the hook procedure, use the <see cref="FINDREPLACE"/> structure that you passed to the dialog creation function.
        /// Specify the address of the hook procedure in the <see cref="FINDREPLACE.lpfnHook"/> member
        /// and specify the <see cref="FR_ENABLEHOOK"/> flag in the <see cref="FINDREPLACE.Flags"/> member.
        /// </para>
        /// <para>
        /// The default dialog box procedure processes the <see cref="WM_INITDIALOG"/> message before passing it to the hook procedure.
        /// For all other messages, the hook procedure receives the message first.
        /// Then, the return value of the hook procedure determines
        /// whether the default dialog procedure processes the message or ignores it.
        /// </para>
        /// <para>
        /// If the hook procedure processes the <see cref="WM_CTLCOLORDLG"/> message,
        /// it must return a valid brush handle for painting the background of the dialog box.
        /// In general, if the hook procedure processes any WM_CTLCOLOR* message,
        /// it must return a valid brush handle for painting the background of the specified control.
        /// </para>
        /// <para>
        /// Do not call the <see cref="EndDialog"/> function from the hook procedure.
        /// Instead, the hook procedure can call the <see cref="PostMessage"/> function
        /// to post a <see cref="WM_COMMAND"/> message with the <see cref="IDABORT"/> value to the dialog box procedure.
        /// Posting <see cref="IDABORT"/> closes the dialog box
        /// and causes the dialog box function to return <see cref="FALSE"/>.
        /// If you need to know why the hook procedure closed the dialog box,
        /// you must provide your own communication mechanism between the hook procedure and your application.
        /// </para>
        /// <para>
        /// You can subclass the standard controls of a common dialog box.
        /// However, the dialog box procedure may also subclass the controls.
        /// Because of this, you should subclass controls when your hook procedure processes the <see cref="WM_INITDIALOG"/> message.
        /// This ensures that your subclass procedure receives the control-specific messages
        /// before the subclass procedure set by the dialog box procedure.
        /// </para>
        /// </remarks>
        public delegate UINT_PTR Lpfrhookproc([In] HWND unnamedParam1, [In] UINT unnamedParam2, [In] WPARAM unnamedParam3, [In] LPARAM unnamedParam4);

        /// <summary>
        /// <para>
        /// Receives notification messages sent from the dialog box.
        /// The function also receives messages for any additional controls
        /// that you defined by specifying a child dialog template.
        /// </para>
        /// <para>
        /// The OFNHookProc hook procedure is an application-defined or library-defined callback function
        /// that is used with the Explorer-style Open and Save As dialog boxes.
        /// The <see cref="LPOFNHOOKPROC"/> type defines a pointer to this callback function.
        /// OFNHookProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpofnhookproc"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the child dialog box of the Open or Save As dialog box.
        /// Use the GetParent function to get the handle to the Open or Save As dialog box.
        /// </param>
        /// <param name="unnamedParam2">
        /// The identifier of the message being received.
        /// </param>
        /// <param name="unnamedParam3">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </param>
        /// <param name="unnamedParam4">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// If the <paramref name="unnamedParam2"/> parameter indicates the <see cref="WM_INITDIALOG"/> message,
        /// <paramref name="unnamedParam4"/> is a pointer to an <see cref="OPENFILENAME"/> structure
        /// containing the values specified when the dialog box was created.
        /// </param>
        /// <returns>
        /// <para>
        /// If the hook procedure returns zero, the default dialog box procedure processes the message.
        /// </para>
        /// <para>
        /// If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.
        /// </para>
        /// <para>
        /// For the <see cref="CDN_SHAREVIOLATION"/> and <see cref="CDN_FILEOK"/> notification messages,
        /// the hook procedure should return a nonzero value to indicate
        /// that it has used the <see cref="SetWindowLong"/> function to set a nonzero <see cref="DWL_MSGRESULT"/> value.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If you do not specify the <see cref="OFN_EXPLORER"/> flag when you create an Open or Save As dialog box,
        /// and you want a hook procedure, you must use an old-style OFNHookProcOldStyle hook procedure.
        /// In this case, the dialog box will have the old-style user interface.
        /// </para>
        /// <para>
        /// When you use the <see cref="GetOpenFileName"/> or <see cref="GetSaveFileName"/> functions
        /// to create an Explorer-style Open or Save As dialog box, you can provide an OFNHookProc hook procedure.
        /// To enable the hook procedure, use the <see cref="OPENFILENAME"/> structure
        /// that you passed to the dialog creation function.
        /// Specify the pointer to the hook procedure in the <see cref="OPENFILENAME.lpfnHook"/> member
        /// and specify the <see cref="OFN_ENABLEHOOK"/> flag in the <see cref="OPENFILENAME.Flags"/> member.
        /// </para>
        /// <para>
        /// If you provide a hook procedure for an Explorer-style common dialog box,
        /// the system creates a dialog box that is a child of the default dialog box.
        /// The hook procedure acts as the dialog procedure for the child dialog.
        /// This child dialog is based on the template you specified in the <see cref="OPENFILENAME"/> structure,
        /// or it is a default child dialog if no template is specified.
        /// The child dialog is created when the default dialog procedure is processing its <see cref="WM_INITDIALOG"/> message.
        /// After the child dialog processes its own <see cref="WM_INITDIALOG"/> message,
        /// the default dialog procedure moves the standard controls,
        /// if necessary, to make room for any additional controls of the child dialog.
        /// The system then sends the <see cref="CDN_INITDONE"/> notification message to the hook procedure.
        /// </para>
        /// <para>
        /// The hook procedure does not receive messages intended for the standard controls of the default dialog box.
        /// You can subclass the standard controls,
        /// but this is discouraged because it may make your application incompatible with later versions.
        /// However, the Explorer-style common dialog boxes provide a set of messages
        /// that the hook procedure can use to monitor and control the dialog.
        /// These include a set of notification messages sent from the dialog,
        /// as well as messages that you can send to retrieve information from the dialog.
        /// For a complete list of these messages, see Explorer-Style Hook Procedures.
        /// </para>
        /// <para>
        /// If the hook procedure processes the <see cref="WM_CTLCOLORDLG"/> message,
        /// it must return a valid brush handle to painting the background of the dialog box.
        /// In general, if it processes any WM_CTLCOLOR* message,
        /// it must return a valid brush handle to painting the background of the specified control.
        /// </para>
        /// <para>
        /// Do not call the <see cref="EndDialog"/> function from the hook procedure.
        /// Instead, the hook procedure can call the <see cref="PostMessage"/> function
        /// to post a <see cref="WM_COMMAND"/> message with the <see cref="IDCANCEL"/> value to the dialog box procedure.
        /// Posting <see cref="IDCANCEL"/> closes the dialog box
        /// and causes the dialog box function to return <see cref="FALSE"/>.
        /// If you need to know why the hook procedure closed the dialog box,
        /// you must provide your own communication mechanism between the hook procedure and your application.
        /// </para>
        /// </remarks>
        [Obsolete("Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog." +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.")]
        public delegate UINT_PTR Lpofnhookproc([In] HWND unnamedParam1, [In] UINT unnamedParam2, [In] WPARAM unnamedParam3, [In] LPARAM unnamedParam4);

        /// <summary>
        /// <para>
        /// Receives messages that allow you to customize drawing of the sample page in the Page Setup dialog box.
        /// The PagePaintHook hook procedure is an application-defined or library-defined callback function
        /// used with the <see cref="PageSetupDlg"/> function.
        /// </para>
        /// <para>
        /// The <see cref="LPPAGEPAINTHOOK"/> type defines a pointer to this callback function.
        /// PagePaintHook is a placeholder for the application-defined or library-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lppagepainthook"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the Page Setup dialog box.
        /// </param>
        /// <param name="unnamedParam2">
        /// The identifier of the message being received.
        /// </param>
        /// <param name="unnamedParam3">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </param>
        /// <param name="unnamedParam4">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the hook procedure returns <see cref="TRUE"/> for any of the first three messages of a drawing sequence
        /// (<see cref="WM_PSD_PAGESETUPDLG"/>, <see cref="WM_PSD_FULLPAGERECT"/>, or <see cref="WM_PSD_MINMARGINRECT"/>),
        /// the dialog box sends no more messages and does not draw in the sample page
        /// until the next time the system needs to redraw the sample page.
        /// If the hook procedure returns <see cref="FALSE"/> for all three messages,
        /// the dialog box sends the remaining messages of the drawing sequence.
        /// </para>
        /// <para>
        /// If the hook procedure returns <see cref="TRUE"/> for any of the remaining messages in a drawing sequence,
        /// the dialog box does not draw the corresponding portion of the sample page.
        /// If the hook procedure returns <see cref="FALSE"/> for any of these messages,
        /// the dialog box draws that portion of the sample page.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The Page Setup dialog box includes an image of a sample page that shows
        /// how the user's selections affect the appearance of the printed output.
        /// The image consists of a rectangle that represents the selected paper or envelope type,
        /// with a dotted-line rectangle representing the current margins,
        /// and partial (Greek text) characters to show how text looks on the printed page.
        /// When you use the <see cref="PageSetupDlg"/> function to create a Page Setup dialog box,
        /// you can provide a PagePaintHook hook procedure to customize the appearance of the sample page.
        /// </para>
        /// <para>
        /// To enable the hook procedure, use the <see cref="PAGESETUPDLG"/> structure that you passed to the creation function.
        /// Specify the pointer to the hook procedure in the <see cref="PAGESETUPDLG.lpfnPagePaintHook"/> member
        /// and specify the <see cref="PSD_ENABLEPAGEPAINTHOOK"/> flag in the <see cref="PAGESETUPDLG.Flags"/> member.
        /// </para>
        /// <para>
        /// Whenever the dialog box is about to draw the contents of the sample page,
        /// the hook procedure receives the following messages in the order in which they are listed.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Message
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WM_PSD_PAGESETUPDLG"/>
        /// </term>
        /// <term>
        /// The dialog box is about to draw the sample page.
        /// The hook procedure can use this message to prepare to draw the contents of the sample page.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_PSD_FULLPAGERECT"/>
        /// </term>
        /// <term>
        /// The dialog box is about to draw the sample page.
        /// This message specifies the bounding rectangle of the sample page.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_PSD_MINMARGINRECT"/>
        /// </term>
        /// <term>
        /// The dialog box is about to draw the sample page.
        /// This message specifies the margin rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_PSD_MARGINRECT"/>
        /// </term>
        /// <term>
        /// The dialog box is about to draw the margin rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_PSD_GREEKTEXTRECT"/>
        /// </term>
        /// <term>
        /// The dialog box is about to draw the Greek text inside the margin rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_PSD_ENVSTAMPRECT"/>
        /// </term>
        /// <term>
        /// The dialog box is about to draw in the envelope-stamp rectangle of an envelope sample page.
        /// This message is sent for envelopes only.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_PSD_YAFULLPAGERECT"/>
        /// </term>
        /// <term>
        /// The dialog box is about to draw the return address portion of an envelope sample page.
        /// This message is sent for envelopes and other paper sizes.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public delegate UINT_PTR Lppagepainthook([In] HWND unnamedParam1, [In] UINT unnamedParam2, [In] WPARAM unnamedParam3, [In] LPARAM unnamedParam4);

        /// <summary>
        /// <para>
        /// Receives messages or notifications intended for the default dialog box procedure of the Page Setup dialog box.
        /// The PageSetupHook hook procedure is an application-defined or library-defined callback function
        /// used with the <see cref="PageSetupDlg"/> function.
        /// </para>
        /// <para>
        /// The <see cref="LPPAGESETUPHOOK"/> type defines a pointer to this callback function.
        /// PageSetupHook is a placeholder for the application-defined or library-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lppagesetuphook"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the Page Setup dialog box for which the message is intended.
        /// </param>
        /// <param name="unnamedParam2">
        /// The identifier of the message being received.
        /// </param>
        /// <param name="unnamedParam3">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </param>
        /// <param name="unnamedParam4">
        /// <para>
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </para>
        /// <para>
        /// If the <paramref name="unnamedParam2"/> parameter indicates the <see cref="WM_INITDIALOG"/> message,
        /// <paramref name="unnamedParam4"/> is a pointer to a <see cref="PAGESETUPDLG"/> structure
        /// containing the values specified when the dialog box was created.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the hook procedure returns zero, the default dialog box procedure processes the message.
        /// </para>
        /// <para>
        /// If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you use the <see cref="PageSetupDlg"/> function to create a Page Setup dialog box,
        /// you can provide a PageSetupHook hook procedure to process messages or notifications intended for the dialog box procedure.
        /// To enable the hook procedure, use the <see cref="PAGESETUPDLG"/> structure that you passed to the dialog creation function.
        /// Specify the pointer to the hook procedure in the <see cref="PAGESETUPDLG.lpfnPageSetupHook"/> member
        /// and specify the <see cref="PSD_ENABLEPAGESETUPHOOK"/> flag in the <see cref="PAGESETUPDLG.Flags"/> member.
        /// </para>
        /// <para>
        /// The default dialog box procedure processes the <see cref="WM_INITDIALOG"/> message before passing it to the hook procedure.
        /// For all other messages, the hook procedure receives the message first.
        /// Then, the return value of the hook procedure determines
        /// whether the default dialog procedure processes the message or ignores it.
        /// </para>
        /// <para>
        /// If the hook procedure processes the <see cref="WM_CTLCOLORDLG"/> message,
        /// it must return a valid brush handle to painting the background of the dialog box.
        /// In general, if the hook procedure processes any WM_CTLCOLOR* message,
        /// it must return a valid brush handle to painting the background of the specified control.
        /// </para>
        /// <para>
        /// Do not call the <see cref="EndDialog"/> function from the hook procedure.
        /// Instead, the hook procedure can call the <see cref="PostMessage"/> function
        /// to post a <see cref="WM_COMMAND"/> message with the <see cref="IDABORT"/> value to the dialog box procedure.
        /// Posting <see cref="IDABORT"/> closes the dialog box
        /// and causes the dialog box function to return <see cref="FALSE"/>.
        /// If you need to know why the hook procedure closed the dialog box,
        /// you must provide your own communication mechanism between the hook procedure and your application.
        /// </para>
        /// <para>
        /// You can subclass the standard controls of a common dialog box.
        /// However, the dialog box procedure may also subclass the controls.
        /// Because of this, you should subclass controls when your hook procedure processes the <see cref="WM_INITDIALOG"/> message.
        /// This ensures that your subclass procedure receives the control-specific messages
        /// before the subclass procedure set by the dialog box procedure.
        /// </para>
        /// </remarks>
        public delegate UINT_PTR Lppagesetuphook([In] HWND unnamedParam1, [In] UINT unnamedParam2, [In] WPARAM unnamedParam3, [In] LPARAM unnamedParam4);

        /// <summary>
        /// <para>
        /// Receives messages or notifications intended for the default dialog box procedure of the Print dialog box.
        /// This is an application-defined or library-defined callback function
        /// that is used with the <see cref="PrintDlg"/> function.
        /// </para>
        /// <para>
        /// The <see cref="LPPRINTHOOKPROC"/> type defines a pointer to this callback function.
        /// PrintHookProc is a placeholder for the application-defined or library-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpprinthookproc"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the Print dialog box for which the message is intended.
        /// </param>
        /// <param name="unnamedParam2">
        /// The identifier of the message being received.
        /// </param>
        /// <param name="unnamedParam3">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </param>
        /// <param name="unnamedParam4">
        /// <para>
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </para>
        /// <para>
        /// If the <paramref name="unnamedParam2"/> parameter indicates the <see cref="WM_INITDIALOG"/> message,
        /// <paramref name="unnamedParam4"/> is a pointer to a <see cref="PRINTDLG"/> structure
        /// containing the values specified when the dialog box was created.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the hook procedure returns zero, the default dialog box procedure processes the message.
        /// </para>
        /// <para>
        /// If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you use the <see cref="PrintDlg"/> function to create a Print dialog box,
        /// you can provide a PrintHookProc hook procedure to process messages or notifications intended for the dialog box procedure.
        /// To enable the hook procedure, use the <see cref="PRINTDLG"/> structure that you passed to the dialog creation function.
        /// Specify the address of the hook procedure in the <see cref="PRINTDLG.lpfnPrintHook"/> member
        /// and specify the <see cref="PD_ENABLEPRINTHOOK"/> flag in the <see cref="PRINTDLG.Flags"/> member.
        /// </para>
        /// <para>
        /// The default dialog box procedure processes the <see cref="WM_INITDIALOG"/> message before passing it to the hook procedure.
        /// For all other messages, the hook procedure receives the message first.
        /// Then, the return value of the hook procedure determines whether the default dialog procedure processes the message or ignores it.
        /// </para>
        /// <para>
        /// If the hook procedure processes the <see cref="WM_CTLCOLORDLG"/> message,
        /// it must return a valid brush handle to painting the background of the dialog box.
        /// In general, if the hook procedure processes any WM_CTLCOLOR* message,
        /// it must return a valid brush handle to painting the background of the specified control.
        /// </para>
        /// <para>
        /// Do not call the <see cref="EndDialog"/> function from the hook procedure.
        /// Instead, the hook procedure can call the <see cref="PostMessage"/> function
        /// to post a <see cref="WM_COMMAND"/> message with the <see cref="IDABORT"/> value to the dialog box procedure.
        /// Posting <see cref="IDABORT"/> closes the dialog box
        /// and causes the dialog box function to return <see cref="FALSE"/>.
        /// If you need to know why the hook procedure closed the dialog box,
        /// you must provide your own communication mechanism between the hook procedure and your application.
        /// </para>
        /// <para>
        /// You can subclass the standard controls of a common dialog box.
        /// However, the dialog box procedure may also subclass the controls.
        /// Because of this, you should subclass controls when your hook procedure processes the <see cref="WM_INITDIALOG"/> message.
        /// This ensures that your subclass procedure receives the control-specific messages
        /// before the subclass procedure set by the dialog box procedure.
        /// </para>
        /// </remarks>
        public delegate UINT_PTR Lpprinthookproc([In] HWND unnamedParam1, [In] UINT unnamedParam2, [In] WPARAM unnamedParam3, [In] LPARAM unnamedParam4);

        /// <summary>
        /// <para>
        /// An application-defined or library-defined callback function used with the <see cref="PrintDlg"/> function.
        /// The hook procedure receives messages or notifications intended
        /// for the default dialog box procedure of the Print Setup dialog box.
        /// </para>
        /// <para>
        /// The <see cref="LPSETUPHOOKPROC"/> type defines a pointer to this callback function.
        /// SetupHookProc is a placeholder for the application-defined or library-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nc-commdlg-lpsetuphookproc"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the Print Setup dialog box for which the message is intended.
        /// </param>
        /// <param name="unnamedParam2">
        /// The identifier of the message being received.
        /// </param>
        /// <param name="unnamedParam3">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </param>
        /// <param name="unnamedParam4">
        /// Additional information about the message.
        /// The exact meaning depends on the value of the <paramref name="unnamedParam2"/> parameter.
        /// </param>
        /// <returns>
        /// <para>
        /// If the hook procedure returns zero, the default dialog box procedure processes the message.
        /// </para>
        /// <para>
        /// If the hook procedure returns a nonzero value, the default dialog box procedure ignores the message.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The Print Setup dialog box has been superseded by the Page Setup dialog box,
        /// which should be used by new applications.
        /// However, for compatibility, the <see cref="PrintDlg"/> function continues to support display of the Print Setup dialog box.
        /// You can provide a SetupHookProc hook procedure for the Print Setup dialog box
        /// to process messages or notifications intended for the dialog box procedure.
        /// </para>
        /// <para>
        /// To enable the hook procedure, use the <see cref="PRINTDLG"/> structure that you passed to the dialog creation function.
        /// Specify the address of the hook procedure in the <see cref="PRINTDLG.lpfnSetupHook"/> member
        /// and specify the <see cref="PD_ENABLESETUPHOOK"/> flag in the <see cref="PRINTDLG.Flags"/> member.
        /// </para>
        /// <para>
        /// The default dialog box procedure processes the <see cref="WM_INITDIALOG"/> message before passing it to the hook procedure.
        /// For all other messages, the hook procedure receives the message first.
        /// Then, the return value of the hook procedure determines
        /// whether the default dialog procedure processes the message or ignores it.
        /// </para>
        /// <para>
        /// If the hook procedure processes the <see cref="WM_CTLCOLORDLG"/> message,
        /// it must return a valid brush handle to painting the background of the dialog box.
        /// In general, if the hook procedure processes any WM_CTLCOLOR* message,
        /// it must return a valid brush handle to painting the background of the specified control.
        /// </para>
        /// <para>
        /// Do not call the <see cref="EndDialog"/> function from the hook procedure.
        /// Instead, the hook procedure can call the <see cref="PostMessage"/> function
        /// to post a <see cref="WM_COMMAND"/> message with the <see cref="IDABORT"/> value to the dialog box procedure.
        /// Posting <see cref="IDABORT"/> closes the dialog box
        /// and causes the dialog box function to return <see cref="FALSE"/>.
        /// If you need to know why the hook procedure closed the dialog box,
        /// you must provide your own communication mechanism between the hook procedure and your application.
        /// </para>
        /// <para>
        /// You can subclass the standard controls of a common dialog box.
        /// However, the dialog box procedure may also subclass the controls.
        /// Because of this, you should subclass controls when your hook procedure processes the <see cref="WM_INITDIALOG"/> message.
        /// This ensures that your subclass procedure receives the control-specific messages
        /// before the subclass procedure set by the dialog box procedure.
        /// </para>
        /// </remarks>
        public delegate UINT_PTR Lpsetuphookproc([In] HWND unnamedParam1, [In] UINT unnamedParam2, [In] WPARAM unnamedParam3, [In] LPARAM unnamedParam4);


        /// <summary>
        /// <para>
        /// Creates a Color dialog box that enables the user to select a color.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms646912(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lpcc">
        /// A pointer to a <see cref="CHOOSECOLOR"/> structure that contains information used to initialize the dialog box.
        /// When <see cref="ChooseColor"/> returns, this structure contains information about the user's color selection.
        /// </param>
        /// <returns>
        /// <para>
        /// If the user clicks the OK button of the dialog box, the return value is nonzero.
        /// The <see cref="CHOOSECOLOR.rgbResult"/> member of the <see cref="CHOOSECOLOR"/> structure
        /// contains the RGB color value of the color selected by the user.
        /// </para>
        /// <para>
        /// If the user cancels or closes the Color dialog box or an error occurs, the return value is zero.
        /// To get extended error information, call the <see cref="CommDlgExtendedError"/> function,
        /// which can return one of the following values:
        /// </para>
        /// <para>
        /// <see cref="CDERR_DIALOGFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_FINDRESFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_MEMLOCKFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_INITIALIZATION"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_NOHINSTANCE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_NOHOOK"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_LOADRESFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_NOTEMPLATE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_LOADSTRFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_STRUCTSIZE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_MEMALLOCFAILURE"/>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The Color dialog box does not support palettes.
        /// The color choices offered by the dialog box are limited to the system colors and dithered versions of those colors.
        /// </para>
        /// <para>
        /// You can provide a CCHookProc hook procedure for a Color dialog box.
        /// The hook procedure can process messages sent to the dialog box.
        /// To enable a hook procedure, set the <see cref="CC_ENABLEHOOK"/> flag
        /// in the <see cref="CHOOSECOLOR.Flags"/> member of the <see cref="CHOOSECOLOR"/> structure
        /// and specify the address of the hook procedure in the <see cref="CHOOSECOLOR.lpfnHook"/> member.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChooseColorW", ExactSpelling = true)]
        public static extern BOOL ChooseColor([In][Out] CHOOSECOLOR lpcc);

        /// <summary>
        /// <para>
        /// Creates a Font dialog box that enables the user to choose attributes for a logical font.
        /// These attributes include a font family and associated font style, a point size, effects (underline, strikeout, and text color),
        /// and a script (or character set).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms646914(v%3Dvs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lpcf">
        /// A pointer to a <see cref="CHOOSEFONT"/> structure that contains information used to initialize the dialog box.
        /// When <see cref="ChooseFont"/> returns, this structure contains information about the user's font selection.
        /// </param>
        /// <returns>
        /// <para>
        /// If the user clicks the OK button of the dialog box, the return value is <see cref="TRUE"/>.
        /// The members of the <see cref="CHOOSEFONT"/> structure indicate the user's selections.
        /// </para>
        /// <para>
        /// If the user cancels or closes the Font dialog box or an error occurs, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call the <see cref="CommDlgExtendedError"/> function,
        /// which can return one of the following values.
        /// </para>
        /// <para>
        /// <see cref="CDERR_DIALOGFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_FINDRESFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_NOHINSTANCE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_INITIALIZATION"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_NOHOOK"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_LOCKRESFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_NOTEMPLATE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_LOADRESFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_STRUCTSIZE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_LOADSTRFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CFERR_MAXLESSTHANMIN"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_MEMALLOCFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CFERR_NOFONTS"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_MEMLOCKFAILURE"/>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// You can provide a CFHookProc hook procedure for a Font dialog box.
        /// The hook procedure can process messages sent to the dialog box.
        /// To enable a hook procedure, set the <see cref="CF_ENABLEHOOK"/> flag
        /// in the <see cref="CHOOSEFONT.Flags"/> member of the <see cref="CHOOSEFONT"/> structure
        /// and specify the address of the hook procedure in the <see cref="CHOOSEFONT.lpfnHook"/> member.
        /// </para>
        /// <para>
        /// The hook procedure can send the <see cref="WM_CHOOSEFONT_GETLOGFONT"/>, <see cref="WM_CHOOSEFONT_SETFLAGS"/>,
        /// and <see cref="WM_CHOOSEFONT_SETLOGFONT"/> messages to the dialog box
        /// to get and set the current values and flags of the dialog box.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChooseFontW", ExactSpelling = true)]
        public static extern BOOL ChooseFont([In][Out] ref CHOOSEFONT lpcf);

        /// <summary>
        /// <para>
        /// Returns a common dialog box error code.
        /// This code indicates the most recent error to occur during the execution of one of the common dialog box functions.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-commdlgextendederror"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the most recent call to a common dialog box function succeeded, the return value is undefined.
        /// If the common dialog box function returned <see cref="FALSE"/>
        /// because the user closed or canceled the dialog box, the return value is zero.
        /// Otherwise, the return value is a nonzero error code.
        /// </para>
        /// <para>
        /// The <see cref="CommDlgExtendedError"/> function can return general error codes for any of the common dialog box functions.
        /// In addition, there are error codes that are returned only for a specific common dialog box.
        /// All of these error codes are defined in Cderr.h.
        /// The following general error codes can be returned for any of the common dialog box functions.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_DIALOGFAILURE"/>
        /// </para>
        /// <para>
        /// 0xFFFF
        /// </para>
        /// </term>
        /// <term>
        /// The dialog box could not be created.
        /// The common dialog box function's call to the <see cref="DialogBox"/> function failed.
        /// For example, this error occurs if the common dialog box call specifies an invalid window handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_FINDRESFAILURE"/>
        /// </para>
        /// <para>
        /// 0x0006
        /// </para>
        /// </term>
        /// <term>
        /// The common dialog box function failed to find a specified resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_INITIALIZATION"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The common dialog box function failed during initialization.
        /// This error often occurs when sufficient memory is not available.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_LOADRESFAILURE"/>
        /// </para>
        /// <para>
        /// 0x0007
        /// </para>
        /// </term>
        /// <term>
        /// The common dialog box function failed to load a specified resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_LOADSTRFAILURE"/>
        /// </para>
        /// <para>
        /// 0x0005
        /// </para>
        /// </term>
        /// <term>
        /// The common dialog box function failed to load a specified string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_LOCKRESFAILURE"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The common dialog box function failed to lock a specified resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_MEMALLOCFAILURE"/>
        /// </para>
        /// <para>
        /// 0x0009
        /// </para>
        /// </term>
        /// <term>
        /// The common dialog box function was unable to allocate memory for internal structures.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_MEMLOCKFAILURE"/>
        /// </para>
        /// <para>
        /// 0x000A
        /// </para>
        /// </term>
        /// <term>
        /// The common dialog box function was unable to lock the memory associated with a handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_NOHINSTANCE"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The ENABLETEMPLATE flag was set in the Flags member of the initialization structure
        /// for the corresponding common dialog box, but you failed to provide a corresponding instance handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_NOHOOK"/>
        /// </para>
        /// <para>
        /// 0x000B
        /// </para>
        /// </term>
        /// <term>
        /// The ENABLEHOOK flag was set in the Flags member of the initialization structure
        /// for the corresponding common dialog box, but you failed to provide a pointer to a corresponding hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_NOTEMPLATE"/>
        /// </para>
        /// <para>
        /// 0x0003
        /// </para>
        /// </term>
        /// <term>
        /// The ENABLETEMPLATE flag was set in the Flags member of the initialization structure 
        /// for the corresponding common dialog box, but you failed to provide a corresponding template.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_REGISTERMSGFAIL"/>
        /// </para>
        /// <para>
        /// 0x000C
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="RegisterWindowMessage"/> function returned an error code
        /// when it was called by the common dialog box function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CDERR_STRUCTSIZE"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// The lStructSize member of the initialization structure for the corresponding common dialog box is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following error codes can be returned for the <see cref="PrintDlg"/> function.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PDERR_CREATEICFAILURE"/>
        /// </para>
        /// <para>
        /// 0x100A
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="PrintDlg"/> function failed when it attempted to create an information context.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PDERR_DEFAULTDIFFERENT"/>
        /// </para>
        /// <para>
        /// 0x100C
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// You called the <see cref="PrintDlg"/> function with the <see cref="DN_DEFAULTPRN"/> flag
        /// specified in the <see cref="DEVNAMES.wDefault"/> member of the <see cref="DEVNAMES"/> structure,
        /// but the printer described by the other structure members did not match the current default printer.
        /// This error occurs when you store the <see cref="DEVNAMES"/> structure,
        /// and the user changes the default printer by using the Control Panel.
        /// </para>
        /// <para>
        /// To use the printer described by the <see cref="DEVNAMES"/> structure,
        /// clear the <see cref="DN_DEFAULTPRN"/> flag and call <see cref="PrintDlg"/> again.
        /// </para>
        /// <para>
        /// To use the default printer, replace the <see cref="DEVNAMES"/> structure
        /// (and the structure, if one exists) with <see cref="NULL"/>; and call <see cref="PrintDlg"/> again.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PDERR_DNDMMISMATCH"/>
        /// </para>
        /// <para>
        /// 0x1009
        /// </para>
        /// </term>
        /// <term>
        /// The data in the <see cref="DEVMODE"/> and <see cref="DEVNAMES"/> structures describes two different printers.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PDERR_GETDEVMODEFAIL"/>
        /// </para>
        /// <para>
        /// 0x1005
        /// </para>
        /// </term>
        /// <term>
        /// The printer driver failed to initialize a <see cref="DEVMODE"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PDERR_INITFAILURE"/>
        /// </para>
        /// <para>
        /// 0x1006
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="PrintDlg"/> function failed during initialization,
        /// and there is no more specific extended error code to describe the failure.
        /// This is the generic default error code for the function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PDERR_LOADDRVFAILURE"/>
        /// </para>
        /// <para>
        /// 0x1004
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="PrintDlg"/> function failed to load the device driver for the specified printer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PDERR_NODEFAULTPRN"/>
        /// </para>
        /// <para>
        /// 0x1008
        /// </para>
        /// </term>
        /// <term>
        /// A default printer does not exist.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PDERR_NODEVICES"/>
        /// </para>
        /// <para>
        /// 0x1007
        /// </para>
        /// </term>
        /// <term>
        /// No printer drivers were found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PDERR_PARSEFAILURE"/>
        /// </para>
        /// <para>
        /// 0x1002
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="PrintDlg"/> function failed to parse the strings in the [devices] section of the WIN.INI file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PDERR_PRINTERNOTFOUND"/>
        /// </para>
        /// <para>
        /// 0x100B
        /// </para>
        /// </term>
        /// <term>
        /// The [devices] section of the WIN.INI file did not contain an entry for the requested printer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PDERR_RETDEFFAILURE"/>
        /// </para>
        /// <para>
        /// 0x1003
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="PD_RETURNDEFAULT"/> flag was specified in the <see cref="PRINTDLG.Flags"/> member
        /// of the <see cref="PRINTDLG"/> structure,
        /// but the <see cref="PRINTDLG.hDevMode"/> or <see cref="PRINTDLG.hDevNames"/> member was not <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PDERR_SETUPFAILURE"/>
        /// </para>
        /// <para>
        /// 0x1001
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="PrintDlg"/> function failed to load the required resources.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following error codes can be returned for the <see cref="ChooseFont"/> function.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CFERR_MAXLESSTHANMIN"/>
        /// </para>
        /// <para>
        /// 0x2002
        /// </para>
        /// </term>
        /// <term>
        /// The size specified in the <see cref="CHOOSEFONT.nSizeMax"/> member of the <see cref="CHOOSEFONT"/> structure
        /// is less than the size specified in the <see cref="CHOOSEFONT.nSizeMin"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CFERR_NOFONTS"/>
        /// </para>
        /// <para>
        /// 0x2001
        /// </para>
        /// </term>
        /// <term>
        /// No fonts exist.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following error codes can be returned for the <see cref="GetOpenFileName"/> and <see cref="GetSaveFileName"/> functions.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FNERR_BUFFERTOOSMALL"/>
        /// </para>
        /// <para>
        /// 0x3003
        /// </para>
        /// </term>
        /// <term>
        /// The buffer pointed to by the <see cref="OPENFILENAME.lpstrFile"/> member
        /// of the <see cref="OPENFILENAME"/> structure is too small for the file name specified by the user.
        /// The first two bytes of the <see cref="OPENFILENAME.lpstrFile"/> buffer
        /// contain an integer value specifying the size required to receive the full name, in characters.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FNERR_INVALIDFILENAME"/>
        /// </para>
        /// <para>
        /// 0x3002
        /// </para>
        /// </term>
        /// <term>
        /// A file name is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FNERR_SUBCLASSFAILURE"/>
        /// </para>
        /// <para>
        /// 0x3001
        /// </para>
        /// </term>
        /// <term>
        /// An attempt to subclass a list box failed because sufficient memory was not available.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following error code can be returned for the <see cref="FindText"/> and <see cref="ReplaceText"/> functions.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FRERR_BUFFERLENGTHZERO"/>
        /// </para>
        /// <para>
        /// 0x4001
        /// </para>
        /// </term>
        /// <term>
        /// A member of the <see cref="FINDREPLACE"/> structure points to an invalid buffer.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "CommDlgExtendedError", ExactSpelling = true)]
        public static extern CommonDialogExtendedErrorCodes CommDlgExtendedError();

        /// <summary>
        /// <para>
        /// Creates a system-defined modeless Find dialog box that lets the user specify a string
        /// to search for and options to use when searching for text in a document.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-findtextw"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A pointer to a <see cref="FINDREPLACE"/> structure
        /// that contains information used to initialize the dialog box.
        /// The dialog box uses this structure to send information about the user's input to your application.
        /// For more information, see the following Remarks section.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the window handle to the dialog box.
        /// You can use the window handle to communicate with or to close the dialog box.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call the <see cref="CommDlgExtendedError"/> function.
        /// <see cref="CommDlgExtendedError"/> may return one of the following error codes:
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="FindText"/> function does not perform a search operation.
        /// Instead, the dialog box sends <see cref="FINDMSGSTRING"/> registered messages
        /// to the window procedure of the owner window of the dialog box.
        /// When you create the dialog box,
        /// the <see cref="FINDREPLACE.hwndOwner"/> member of the <see cref="FINDREPLACE"/> structure is a handle to the owner window.
        /// </para>
        /// <para>
        /// Before calling <see cref="FindText"/>, you must call the <see cref="RegisterWindowMessage"/> function
        /// to get the identifier for the <see cref="FINDMSGSTRING"/> message.
        /// The dialog box procedure uses this identifier to send messages
        /// when the user clicks the Find Next button, or when the dialog box is closing.
        /// The lParam parameter of the <see cref="FINDMSGSTRING"/> message contains a pointer to a <see cref="FINDREPLACE"/> structure.
        /// The <see cref="FINDREPLACE.Flags"/> member of this structure indicates the event that caused the message.
        /// Other members of the structure indicate the user's input.
        /// </para>
        /// <para>
        /// If you create a Find dialog box, you must also use the <see cref="IsDialogMessage"/> function
        /// in the main message loop of your application to ensure
        /// that the dialog box correctly processes keyboard input, such as the TAB and ESC keys.
        /// <see cref="IsDialogMessage"/> returns a value that indicates whether the Find dialog box processed the message.
        /// </para>
        /// <para>
        /// You can provide an FRHookProc hook procedure for a Find dialog box.
        /// The hook procedure can process messages sent to the dialog box.
        /// To enable a hook procedure, set the <see cref="FR_ENABLEHOOK"/> flag
        /// in the <see cref="FINDREPLACE.Flags"/> member of the <see cref="FINDREPLACE"/> structure
        /// and specify the address of the hook procedure in the <see cref="FINDREPLACE.lpfnHook"/> member.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindTextW", ExactSpelling = true)]
        public static extern HWND FindText([In][Out] ref FINDREPLACE unnamedParam1);

        /// <summary>
        /// <para>
        /// Creates an Open dialog box that lets the user specify the drive, directory, and the name of a file or set of files to be opened.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-getopenfilenamew"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A pointer to an <see cref="OPENFILENAME"/> structure that contains information used to initialize the dialog box.
        /// When <see cref="GetOpenFileName"/> returns, this structure contains information about the user's file selection.
        /// </param>
        /// <returns>
        /// <para>
        /// If the user specifies a file name and clicks the OK button, the return value is nonzero.
        /// The buffer pointed to by the <see cref="OPENFILENAME.lpstrFile"/> member
        /// of the <see cref="OPENFILENAME"/> structure contains the full path and file name specified by the user.
        /// </para>
        /// <para>
        /// If the user cancels or closes the Open dialog box or an error occurs, the return value is zero.
        /// To get extended error information, call the <see cref="CommDlgExtendedError"/> function,
        /// which can return one of the following values.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The Explorer-style Open dialog box provides user-interface features that are similar to the Windows Explorer.
        /// You can provide an OFNHookProc hook procedure for an Explorer-style Open dialog box.
        /// To enable the hook procedure, set the <see cref="OFN_EXPLORER"/> and <see cref="OFN_ENABLEHOOK"/> flags
        /// in the <see cref="OPENFILENAME.Flags"/> member of the <see cref="OPENFILENAME"/> structure
        /// and specify the address of the hook procedure in the <see cref="OPENFILENAME.lpfnHook"/> member.
        /// </para>
        /// <para>
        /// Windows continues to support the old-style Open dialog box for applications
        /// that want to maintain a user-interface consistent with the old-style user-interface.
        /// To display the old-style Open dialog box,
        /// enable an OFNHookProcOldStyle hook procedure and ensure that the <see cref="OFN_EXPLORER"/> flag is not set.
        /// </para>
        /// <para>
        /// To display a dialog box that allows the user to select a directory instead of a file,
        /// call the <see cref="SHBrowseForFolder"/> function.
        /// </para>
        /// <para>
        /// Note, when selecting multiple files, the total character limit for the file names depends on the version of the function.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ANSI: 32k limit
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Unicode: no restriction
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [Obsolete("Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog." +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetOpenFileNameW", ExactSpelling = true)]
        public static extern BOOL GetOpenFileName([In][Out] ref OPENFILENAME unnamedParam1);

        /// <summary>
        /// <para>
        /// Creates a Save dialog box that lets the user specify the drive, directory, and name of a file to save.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-getsavefilenamew"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A pointer to an <see cref="OPENFILENAME"/> structure that contains information used to initialize the dialog box.
        /// When <see cref="GetSaveFileName"/> returns, this structure contains information about the user's file selection.
        /// </param>
        /// <returns>
        /// <para>
        /// If the user specifies a file name and clicks the OK button
        /// and the function is successful, the return value is nonzero.
        /// The buffer pointed to by the <see cref="OPENFILENAME.lpstrFile"/> member
        /// of the <see cref="OPENFILENAME"/> structure contains the full path and file name specified by the user.
        /// </para>
        /// <para>
        /// If the user cancels or closes the Save dialog box or an error
        /// such as the file name buffer being too small occurs, the return value is zero.
        /// To get extended error information, call the <see cref="CommDlgExtendedError"/> function,
        /// which can return one of the following values:
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The Explorer-style Save dialog box that provides user-interface features that are similar to the Windows Explorer.
        /// You can provide an OFNHookProc hook procedure for an Explorer-style Save dialog box.
        /// To enable the hook procedure, set the <see cref="OFN_EXPLORER"/> and <see cref="OFN_ENABLEHOOK"/> flags
        /// in the <see cref="OPENFILENAME.Flags"/> member of the <see cref="OPENFILENAME"/> structure
        /// and specify the address of the hook procedure in the <see cref="OPENFILENAME.lpfnHook"/> member.
        /// </para>
        /// <para>
        /// Windows continues to support old-style Save dialog boxes for applications
        /// that want to maintain a user-interface consistent with the old-style user-interface.
        /// To display the old-style Save dialog box,
        /// enable an OFNHookProcOldStyle hook procedure and ensure that the <see cref="OFN_EXPLORER"/> flag is not set.
        /// </para>
        /// </remarks>
        [Obsolete("Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog." +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSaveFileNameW", ExactSpelling = true)]
        public static extern BOOL GetSaveFileName([In][Out] ref OPENFILENAME unnamedParam1);

        /// <summary>
        /// <para>
        /// Creates a Page Setup dialog box that enables the user to specify the attributes of a printed page.
        /// These attributes include the paper size and source, the page orientation (portrait or landscape), and the width of the page margins.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms646937(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lppsd">
        /// A pointer to a <see cref="PAGESETUPDLG"/> structure that contains information used to initialize the dialog box.
        /// The structure receives information about the user's selections when the function returns.
        /// </param>
        /// <returns>
        /// <para>
        /// If the user clicks the OK button, the return value is nonzero.
        /// The members of the <see cref="PAGESETUPDLG"/> structure pointed to
        /// by the <paramref name="lppsd"/> parameter indicate the user's selections.
        /// </para>
        /// <para>
        /// If the user cancels or closes the Page Setup dialog box or an error occurs, the return value is zero.
        /// To get extended error information, use the <see cref="CommDlgExtendedError"/> function
        /// </para>
        /// <para>
        /// Note that the values of <see cref="PAGESETUPDLG.hDevMode"/> and <see cref="PAGESETUPDLG.hDevNames"/>
        /// in <see cref="PAGESETUPDLG"/> may change when they are passed into <see cref="PageSetupDlg"/>.
        /// This is because these members are filled on both input and output.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Starting with Windows Vista, the <see cref="PageSetupDlg"/> does not contain the Printer button.
        /// To switch printer selection, use <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "PageSetupDlgW", ExactSpelling = true)]
        public static extern BOOL PageSetupDlg([In][Out] ref PAGESETUPDLG lppsd);

        /// <summary>
        /// <para>
        /// Displays a Print Dialog Box or a Print Setup dialog box.
        /// The Print dialog box enables the user to specify the properties of a particular print job.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms646940(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lppd">
        /// A pointer to a <see cref="PRINTDLG"/> structure that contains information used to initialize the dialog box.
        /// When <see cref="PrintDlg"/> returns, this structure contains information about the user's selections.
        /// </param>
        /// <returns>
        /// <para>
        /// If the user clicks the OK button, the return value is nonzero.
        /// The members of the <see cref="PRINTDLG"/> structure pointed to
        /// by the <paramref name="lppd"/> parameter indicate the user's selections.
        /// </para>
        /// <para>
        /// If the user canceled or closed the Print or Printer Setup dialog box or an error occurred, the return value is zero.
        /// To get extended error information, use the <see cref="CommDlgExtendedError"/> function.
        /// If the user canceled or closed the dialog box, <see cref="CommDlgExtendedError"/> returns zero;
        /// otherwise, it returns one of the following values.
        /// </para>
        /// <para>
        /// <see cref="CDERR_FINDRESFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_INITIALIZATION"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_LOADRESFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_LOADSTRFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_LOCKRESFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_MEMALLOCFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_MEMLOCKFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_NOHINSTANCE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_NOHOOK"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_NOTEMPLATE"/>
        /// </para>
        /// <para>
        /// <see cref="CDERR_STRUCTSIZE"/>
        /// </para>
        /// <para>
        /// <see cref="PDERR_CREATEICFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="PDERR_DEFAULTDIFFERENT"/>
        /// </para>
        /// <para>
        /// <see cref="PDERR_DNDMMISMATCH"/>
        /// </para>
        /// <para>
        /// <see cref="PDERR_GETDEVMODEFAIL"/>
        /// </para>
        /// <para>
        /// <see cref="PDERR_INITFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="PDERR_LOADDRVFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="PDERR_NODEFAULTPRN"/>
        /// </para>
        /// <para>
        /// <see cref="PDERR_NODEVICES"/>
        /// </para>
        /// <para>
        /// <see cref="PDERR_PARSEFAILURE"/>
        /// </para>
        /// <para>
        /// <see cref="PDERR_PRINTERNOTFOUND"/>
        /// </para>
        /// <para>
        /// <see cref="PDERR_RETDEFFAILURE"/>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the hook procedure (pointed to by the <see cref="PRINTDLG.lpfnPrintHook"/>
        /// or <see cref="PRINTDLG.lpfnSetupHook"/> member of the <see cref="PRINTDLG"/> structure)
        /// processes the <see cref="WM_CTLCOLORDLG"/> message,
        /// the hook procedure must return a handle to the brush that should be used to paint the control background.
        /// </para>
        /// <para>
        /// Note that the values of <see cref="PRINTDLG.hDevMode"/> and <see cref="PRINTDLG.hDevNames"/>
        /// in <see cref="PRINTDLG"/> may change when they are passed into <see cref="PrintDlg"/>.
        /// This is because these members are filled on both input and output.
        /// </para>
        /// <para>
        /// To switch printer selection, use <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/>.
        /// </para>
        /// <para>
        /// Windows Server 2003, Windows XP, and Windows 2000: To switch printer selection, use the Printer button
        /// </para>
        /// <para>
        /// Known issue:
        /// If <see cref="PD_RETURNDC"/> is set but <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> flag is not set,
        /// the <see cref="PrintDlgEx"/> and <see cref="PrintDlg"/> functions return incorrect number of copies.
        /// To get the correct number of copies,
        /// ensure that the calling application always uses <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> with <see cref="PD_RETURNDC"/>.
        /// </para>
        /// </remarks>
        [Obsolete("PrintDlg is available for use in the operating systems specified in the Requirements section." +
            "It may be altered or unavailable in subsequent versions. Instead, use PrintDlgEx or PageSetupDlg.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "PrintDlgW", ExactSpelling = true)]
        public static extern BOOL PrintDlg([In][Out] ref PRINTDLG lppd);

        /// <summary>
        /// <para>
        /// Displays a Print property sheet that enables the user to specify the properties of a particular print job.
        /// A Print property sheet has a General page that contains controls similar to the Print dialog box.
        /// The property sheet can also have additional application-specific and driver-specific property pages as well as the General page.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms646942(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="lppd">
        /// <para>
        /// A pointer to a <see cref="PRINTDLGEX"/> structure
        /// that contains information used to initialize the property sheet.
        /// When <see cref="PrintDlgEx"/> returns, this structure contains information about the user's selections.
        /// </para>
        /// <para>
        /// This structure must be declared dynamically using a memory allocation function.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="S_OK"/>
        /// and the <see cref="PRINTDLGEX.dwResultAction"/> member
        /// of the <see cref="PRINTDLGEX"/> structure contains one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PD_RESULT_APPLY"/> 2
        /// </term>
        /// <term>
        /// The user clicked the Apply button and later clicked the Cancel button.
        /// This indicates that the user wants to apply the changes made in the property sheet, but does not yet want to print.
        /// The <see cref="PRINTDLGEX"/> structure contains the information
        /// specified by the user at the time the Apply button was clicked.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PD_RESULT_CANCEL"/> 0
        /// </term>
        /// <term>
        /// The user clicked the Cancel button.
        /// The information in the <see cref="PRINTDLGEX"/> structure is unchanged.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PD_RESULT_PRINT"/> 1
        /// </term>
        /// <term>
        /// The user clicked the Print button.
        /// The <see cref="PRINTDLGEX"/> structure contains the information specified by the user.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// If the function fails, the return value may be one of the following COM error codes.
        /// For more information, see Error Handling.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="E_OUTOFMEMORY"/>
        /// </term>
        /// <term>
        /// Insufficient memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// One or more arguments are invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_POINTER"/>
        /// </term>
        /// <term>
        /// Invalid pointer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_HANDLE"/>
        /// </term>
        /// <term>
        /// Invalid handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_FAIL"/>
        /// </term>
        /// <term>
        /// Unspecified error.
        /// </term>
        /// </item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The values of <see cref="PRINTDLGEX.hDevMode"/> and <see cref="PRINTDLGEX.hDevNames"/>
        /// in <see cref="PRINTDLGEX"/> may change when they are passed into <see cref="PrintDlgEx"/>.
        /// This is because these members are filled on both input and output.
        /// Be sure to free the memory allocated for these members
        /// </para>
        /// <para>
        /// If <see cref="PD_RETURNDC"/> is set but <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> flag is not set,
        /// the <see cref="PrintDlg"/> and <see cref="PrintDlgEx"/> functions return incorrect number of copies.
        /// To get the correct number of copies,
        /// ensure that the calling application always uses <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> with <see cref="PD_RETURNDC"/>.
        /// </para>
        /// <para>
        /// For more information, see Print Property Sheet.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "PrintDlgExW", ExactSpelling = true)]
        public static extern HRESULT PrintDlgEx([In][Out] ref PRINTDLGEX lppd);

        /// <summary>
        /// <para>
        /// Creates a system-defined modeless dialog box that lets the user specify a string
        /// to search for and a replacement string, as well as options to control the find and replace operations.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/nf-commdlg-replacetextw"/>
        /// </para>
        /// </summary>
        /// <param name="Arg1">
        /// A pointer to a <see cref="FINDREPLACE"/> structure that contains information used to initialize the dialog box.
        /// The dialog box uses this structure to send information about the user's input to your application.
        /// For more information, see the following Remarks section.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the window handle to the dialog box.
        /// You can use the window handle to communicate with the dialog box or close it.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call the <see cref="CommDlgExtendedError"/> function,
        /// which can return one of the following error codes:
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="ReplaceText"/> function does not perform a text replacement operation.
        /// Instead, the dialog box sends <see cref="FINDMSGSTRING"/> registered messages
        /// to the window procedure of the owner window of the dialog box.
        /// When you create the dialog box, the <see cref="FINDREPLACE.hwndOwner"/> member
        /// of the <see cref="FINDREPLACE"/> structure is a handle to the owner window.
        /// </para>
        /// <para>
        /// Before calling <see cref="ReplaceText"/>,
        /// you must call the <see cref="RegisterWindowMessage"/> function to get the identifier for the <see cref="FINDMSGSTRING"/> message.
        /// The dialog box procedure uses this identifier to send messages when the user clicks the Find Next,
        /// Replace, or Replace All buttons, or when the dialog box is closing.
        /// The lParam parameter of a <see cref="FINDMSGSTRING"/> message contains a pointer to the <see cref="FINDREPLACE"/> structure.
        /// The <see cref="FINDREPLACE.Flags"/> member of this structure indicates the event that caused the message.
        /// Other members of the structure indicate the user's input.
        /// </para>
        /// <para>
        /// If you create a Replace dialog box,
        /// you must also use the <see cref="IsDialogMessage"/> function in the main message loop of your application
        /// to ensure that the dialog box correctly processes keyboard input, such as the TAB and ESC keys.
        /// The <see cref="IsDialogMessage"/> function returns a value
        /// that indicates whether the Replace dialog box processed the message.
        /// </para>
        /// <para>
        /// You can provide an FRHookProc hook procedure for a Replace dialog box.
        /// The hook procedure can process messages sent to the dialog box.
        /// To enable a hook procedure, set the <see cref="FR_ENABLEHOOK"/> flag
        /// in the <see cref="FINDREPLACE.Flags"/> member of the <see cref="FINDREPLACE"/> structure
        /// and specify the address of the hook procedure in the <see cref="FINDREPLACE.lpfnHook"/> member.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Comdlg32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReplaceTextW", ExactSpelling = true)]
        public static extern HWND ReplaceText([In][Out] ref FINDREPLACE Arg1);
    }
}
