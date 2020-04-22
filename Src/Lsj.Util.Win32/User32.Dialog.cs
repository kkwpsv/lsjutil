using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ComboBoxControlMessages;
using static Lsj.Util.Win32.Enums.ComboBoxStyles;
using static Lsj.Util.Win32.Enums.DialogBoxMessages;
using static Lsj.Util.Win32.Enums.DialogBoxStyles;
using static Lsj.Util.Win32.Enums.DlgDirListFlags;
using static Lsj.Util.Win32.Enums.GetWindowLongIndexes;
using static Lsj.Util.Win32.Enums.ListBoxMessages;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.WindowStylesEx;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// DLGWINDOWEXTRA
        /// </summary>
        public const int DLGWINDOWEXTRA = 30;

        /// <summary>
        /// <para>
        /// Retrieves the return value of a message processed in the dialog box procedure.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowlongptrw
        /// </para>
        /// </summary>
        public static readonly GetWindowLongIndexes DWLP_MSGRESULT = 0;

        /// <summary>
        /// <para>
        /// Retrieves the pointer to the dialog box procedure, or a handle representing the pointer to the dialog box procedure.
        /// You must use the <see cref="CallWindowProc"/> function to call the dialog box procedure.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowlongptrw
        /// </para>
        /// </summary>
        public static readonly GetWindowLongIndexes DWLP_DLGPROC = DWLP_MSGRESULT + IntPtr.Size;

        /// <summary>
        /// <para>
        /// Retrieves extra information private to the application, such as handles or pointers.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowlongptrw
        /// </para>
        /// </summary>
        public static readonly GetWindowLongIndexes DWLP_USER = DWLP_DLGPROC + IntPtr.Size;

        /// <summary>
        /// <para>
        /// Application-defined callback function used with the <see cref="CreateDialog"/> and <see cref="DialogBox"/> families of functions.
        /// It processes messages sent to a modal or modeless dialog box.
        /// The <see cref="DLGPROC"/> type defines a pointer to this callback function.
        /// DialogProc is a placeholder for the application-defined function name.
        /// Typically, the dialog box procedure should return <code>(IntPtr)1</code> if it processed the message,
        /// and <see cref="IntPtr.Zero"/> if it did not.
        /// If the dialog box procedure returns <see cref="IntPtr.Zero"/>,
        /// the dialog manager performs the default dialog operation in response to the message.
        /// If the dialog box procedure processes a message that requires a specific return value,
        /// the dialog box procedure should set the desired return value by
        /// calling <code>SetWindowLong(hwndDlg, DWL_MSGRESULT, lResult)</code> immediately before returning <code>(IntPtr)1</code>.
        /// Note that you must call <see cref="SetWindowLong"/> immediately before returning <code>(IntPtr)1</code>;
        /// doing so earlier may result in the <see cref="DWL_MSGRESULT"/> value being overwritten by a nested dialog box message.
        /// The following messages are exceptions to the general rules stated above.
        /// Consult the documentation for the specific message for details on the semantics of the return value.
        /// <see cref="WM_CHARTOITEM"/>, <see cref="WM_COMPAREITEM"/>, <see cref="WM_CTLCOLORBTN"/>,
        /// <see cref="WM_CTLCOLORDLG"/>, <see cref="WM_CTLCOLOREDIT"/>, <see cref="WM_CTLCOLORLISTBOX"/>,
        /// <see cref="WM_CTLCOLORSCROLLBAR"/>, <see cref="WM_CTLCOLORSTATIC"/>,
        /// <see cref="WM_INITDIALOG"/>, <see cref="WM_QUERYDRAGICON"/>, <see cref="WM_VKEYTOITEM"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nc-winuser-dlgproc
        /// </para>
        /// </summary>
        /// <param name="Arg1">
        /// A handle to the dialog box.
        /// </param>
        /// <param name="Arg2">
        /// The message.
        /// </param>
        /// <param name="Arg3">
        /// Additional message-specific information.
        /// </param>
        /// <param name="Arg4">
        /// Additional message-specific information.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// You should use the dialog box procedure only if you use the dialog box class for the dialog box.
        /// This is the default class and is used when no explicit class is specified in the dialog box template.
        /// Although the dialog box procedure is similar to a window procedure,
        /// it must not call the <see cref="DefWindowProc"/> function to process unwanted messages.
        /// Unwanted messages are processed internally by the dialog box window procedure.
        /// </remarks>
        public delegate IntPtr DLGPROC([In]IntPtr Arg1, [In]WindowsMessages Arg2, [In]UIntPtr Arg3, [In]IntPtr Arg4);

        /// <summary>
        /// <para>
        /// Creates a modeless dialog box from a dialog box template resource.
        /// The <see cref="CreateDialog"/> macro uses the <see cref="CreateDialogParam"/> function.
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module which contains the dialog box template.
        /// If this parameter is <see cref="IntPtr.Zero"/>, then the current executable is used.
        /// </param>
        /// <param name="lpName">
        /// The dialog box template.
        /// This parameter is either the pointer to a null-terminated character string that
        /// specifies the name of the dialog box template or
        /// an integer value that specifies the resource identifier of the dialog box template.
        /// If the parameter specifies a resource identifier, its high-order word must be zero and its low-order word must contain the identifier.
        /// You can use the <see cref="MAKEINTRESOURCE"/> macro to create this value.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the window that owns the dialog box.
        /// </param>
        /// <param name="lpDialogFunc">
        /// A pointer to the dialog box procedure. For more information about the dialog box procedure, see DialogProc.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The <see cref="CreateDialog"/> function uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="CreateDialog"/> then sends a <see cref="WM_INITDIALOG"/> message
        /// (and a <see cref="WM_SETFONT"/> message if the template specifies
        /// the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style) to the dialog box procedure.
        /// The function displays the dialog box if the template specifies the <see cref="WS_VISIBLE"/> style.
        /// Finally, <see cref="CreateDialog"/> returns the window handle to the dialog box.
        /// After <see cref="CreateDialog"/> returns, the application displays the dialog box
        /// (if it is not already displayed) by using the <see cref="ShowWindow"/> function.
        /// The application destroys the dialog box by using the <see cref="DestroyWindow"/> function.
        /// To support keyboard navigation and other dialog box functionality,
        /// the message loop for the dialog box must call the <see cref="IsDialogMessage"/> function.
        /// </remarks>
        public static HWND CreateDialog(HINSTANCE hInstance, StringHandle lpName, HWND hWndParent, DLGPROC lpDialogFunc) =>
            CreateDialogParam(hInstance, lpName, hWndParent, lpDialogFunc, IntPtr.Zero);

        /// <summary>
        /// <para>
        /// Creates a modeless dialog box from a dialog box template in memory.
        /// The <see cref="CreateDialogIndirect"/> macro uses the <see cref="CreateDialogIndirectParam"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createdialogindirectw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module that creates the dialog box.
        /// </param>
        /// <param name="lpTemplate">
        /// A template that <see cref="CreateDialogIndirect"/> uses to create the dialog box.
        /// A dialog box template consists of a header that describes the dialog box,
        /// followed by one or more additional blocks of data that describe each of the controls in the dialog box.
        /// The template can use either the standard format or the extended format.
        /// In a standard template, the header is a <see cref="DLGTEMPLATE"/> structure followed by additional variable-length arrays.
        /// The data for each control consists of a <see cref="DLGITEMTEMPLATE"/> structure followed by additional variable-length arrays.
        /// In an extended dialog box template, the header uses the <see cref="DLGTEMPLATEEX"/> format
        /// and the control definitions use the <see cref="DLGITEMTEMPLATEEX"/> format.
        /// After <see cref="CreateDialogIndirect"/> returns, you can free the template, which is only used to get the dialog box started.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the window that owns the dialog box.
        /// </param>
        /// <param name="lpDialogFunc">
        /// A pointer to the dialog box procedure.
        /// For more information about the dialog box procedure, see <see cref="DLGPROC"/>.
        /// </param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateDialogIndirect"/> macro uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="CreateDialogIndirect"/> then sends a <see cref="WM_INITDIALOG"/> message to the dialog box procedure.
        /// If the template specifies the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style,
        /// the function also sends a <see cref="WM_SETFONT"/> message to the dialog box procedure.
        /// The function displays the dialog box if the template specifies the <see cref="WS_VISIBLE"/> style.
        /// Finally, <see cref="CreateDialogIndirect"/> returns the window handle to the dialog box.
        /// After <see cref="CreateDialogIndirect"/> returns, you can use the <see cref="ShowWindow"/> function
        /// to display the dialog box (if it is not already visible).
        /// To destroy the dialog box, use the <see cref="DestroyWindow"/> function.
        /// To support keyboard navigation and other dialog box functionality,
        /// the message loop for the dialog box must call the <see cref="IsDialogMessage"/> function.
        /// In a standard dialog box template, the <see cref="DLGTEMPLATE"/> structure
        /// and each of the <see cref="DLGITEMTEMPLATE"/> structures must be aligned on <see cref="DWORD"/> boundaries.
        /// The creation data array that follows a <see cref="DLGITEMTEMPLATE"/> structure must also be aligned on a <see cref="DWORD"/> boundary.
        /// All of the other variable-length arrays in the template must be aligned on <see cref="WORD"/> boundaries.
        /// In an extended dialog box template, the <see cref="DLGTEMPLATEEX"/> header
        /// and each of the <see cref="DLGITEMTEMPLATEEX"/> control definitions must be aligned on <see cref="DWORD"/> boundaries.
        /// The creation data array, if any, that follows a <see cref="DLGITEMTEMPLATEEX"/> structure must also be aligned on a <see cref="DWORD"/> boundary.
        /// All of the other variable-length arrays in the template must be aligned on <see cref="WORD"/> boundaries.
        /// All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.
        /// Use the <see cref="MultiByteToWideChar"/> function to generate Unicode strings from ANSI strings.
        /// </remarks>
        public static HWND CreateDialogIndirect([In]HINSTANCE hInstance, [In]in DLGTEMPLATE lpTemplate, [In]HWND hWndParent,
            [In]DLGPROC lpDialogFunc) => CreateDialogIndirectParam(hInstance, lpTemplate, hWndParent, lpDialogFunc, NULL);

        /// <summary>
        /// <para>
        /// Creates a modeless dialog box from a dialog box template in memory.
        /// Before displaying the dialog box, the function passes an application-defined value to the dialog box procedure
        /// as the <see cref="MSG.lParam"/> parameter of the <see cref="WM_INITDIALOG"/> message.
        /// An application can use this value to initialize dialog box controls.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createdialogindirectparamw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module which contains the dialog box template.
        /// If this parameter is <see cref="NULL"/>, then the current executable is used.
        /// </param>
        /// <param name="lpTemplate">
        /// The template <see cref="CreateDialogIndirectParam"/> uses to create the dialog box.
        /// A dialog box template consists of a header that describes the dialog box,
        /// followed by one or more additional blocks of data that describe each of the controls in the dialog box.
        /// The template can use either the standard format or the extended format.
        /// In a standard template, the header is a <see cref="DLGTEMPLATE"/> structure followed by additional variable-length arrays.
        /// The data for each control consists of a <see cref="DLGITEMTEMPLATE"/> structure followed by additional variable-length arrays.
        /// In an extended dialog box template, the header uses the <see cref="DLGTEMPLATEEX"/> format
        /// and the control definitions use the <see cref="DLGITEMTEMPLATEEX"/> format.
        /// After <see cref="CreateDialogIndirectParam"/> returns, you can free the template, which is only used to get the dialog box started.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the window that owns the dialog box.
        /// </param>
        /// <param name="lpDialogFunc">
        /// A pointer to the dialog box procedure.
        /// For more information about the dialog box procedure, see <see cref="DLGPROC"/>.
        /// </param>
        /// <param name="dwInitParam">
        /// The value to pass to the dialog box in the <see cref="MSG.lParam"/> parameter of the <see cref="WM_INITDIALOG"/> message.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the window handle to the dialog box.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateDialogIndirectParam"/> function uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="CreateDialogIndirectParam"/> then sends a <see cref="WM_INITDIALOG"/> message to the dialog box procedure.
        /// If the template specifies the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style,
        /// the function also sends a <see cref="WM_SETFONT"/> message to the dialog box procedure.
        /// The function displays the dialog box if the template specifies the <see cref="WS_VISIBLE"/> style.
        /// Finally, <see cref="CreateDialogIndirectParam"/> returns the window handle to the dialog box.
        /// After <see cref="CreateDialogIndirectParam"/> returns, you can use the <see cref="ShowWindow"/> function
        /// to display the dialog box(if it is not already visible).
        /// To destroy the dialog box, use the <see cref="DestroyWindow"/> function.
        /// To support keyboard navigation and other dialog box functionality,
        /// the message loop for the dialog box must call the <see cref="IsDialogMessage"/> function.
        /// In a standard dialog box template, the <see cref="DLGTEMPLATE"/> structure
        /// and each of the <see cref="DLGITEMTEMPLATE"/> structures must be aligned on <see cref="DWORD"/> boundaries.
        /// The creation data array that follows a <see cref="DLGITEMTEMPLATE"/> structure must also be aligned on a <see cref="DWORD"/> boundary.
        /// All of the other variable-length arrays in the template must be aligned on <see cref="WORD"/> boundaries.
        /// In an extended dialog box template, the <see cref="DLGTEMPLATEEX"/> header
        /// and each of the <see cref="DLGITEMTEMPLATEEX"/> control definitions must be aligned on <see cref="DWORD"/> boundaries.
        /// The creation data array, if any, that follows a <see cref="DLGITEMTEMPLATEEX"/> structure must also be aligned on a <see cref="DWORD"/> boundary.
        /// All of the other variable-length arrays in the template must be aligned on <see cref="WORD"/> boundaries.
        /// All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDialogIndirectParamW", ExactSpelling = true, SetLastError = true)]
        public static extern HWND CreateDialogIndirectParam([In]HINSTANCE hInstance, [In]in DLGTEMPLATE lpTemplate, [In]HWND hWndParent,
            [In]DLGPROC lpDialogFunc, [In]LPARAM dwInitParam);

        /// <summary>
        /// <para>
        /// Creates a modeless dialog box from a dialog box template resource.
        /// Before displaying the dialog box, the function passes an application-defined value to the dialog box procedure
        /// as the lParam parameter of the <see cref="WM_INITDIALOG"/> message.
        /// An application can use this value to initialize dialog box controls.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createdialogparamw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module which contains the dialog box template.
        /// If this parameter is <see cref="IntPtr.Zero"/>, then the current executable is used.
        /// </param>
        /// <param name="lpTemplateName">
        /// The dialog box template.
        /// This parameter is either the pointer to a null-terminated character string that specifies the name of the dialog box template
        /// or an integer value that specifies the resource identifier of the dialog box template.
        /// If the parameter specifies a resource identifier, its high-order word must be zero and low-order word must contain the identifier.
        /// You can use the <see cref="MAKEINTRESOURCE"/> macro to create this value.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the window that owns the dialog box.
        /// </param>
        /// <param name="lpDialogFunc">
        /// A pointer to the dialog box procedure.
        /// For more information about the dialog box procedure, see <see cref="DLGPROC"/>.
        /// </param>
        /// <param name="dwInitParam">
        /// The value to be passed to the dialog box procedure in the lParam parameter in the <see cref="WM_INITDIALOG"/> message.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the window handle to the dialog box.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CreateDialogParam"/> function uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="CreateDialogParam"/> then sends a <see cref="WM_INITDIALOG"/> message
        /// (and a <see cref="WM_SETFONT"/> message if the template specifies
        /// the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style) to the dialog box procedure.
        /// The function displays the dialog box if the template specifies the <see cref="WS_VISIBLE"/> style.
        /// Finally, <see cref="CreateDialogParam"/> returns the window handle of the dialog box.
        /// After <see cref="CreateDialogParam"/> returns, the application displays the dialog box
        /// (if it is not already displayed) using the <see cref="ShowWindow"/> function.
        /// The application destroys the dialog box by using the <see cref="DestroyWindow"/> function.
        /// To support keyboard navigation and other dialog box functionality,
        /// the message loop for the dialog box must call the <see cref="IsDialogMessage"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDialogParamW", ExactSpelling = true, SetLastError = true)]
        public static extern HWND CreateDialogParam([In]HINSTANCE hInstance, [In]StringHandle lpTemplateName, [In]HWND hWndParent,
            [In]DLGPROC lpDialogFunc, [In]LPARAM dwInitParam);

        /// <summary>
        /// <para>
        /// Calls the default dialog box window procedure to provide default processing for any window messages
        /// that a dialog box with a private window class does not process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-defdlgprocw
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box.
        /// </param>
        /// <param name="Msg">
        /// The message.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// The return value specifies the result of the message processing and depends on the message sent.
        /// </returns>
        /// <remarks>
        /// The <see cref="DefDlgProc"/> function is the window procedure for the predefined class of dialog box.
        /// This procedure provides internal processing for the dialog box by forwarding messages to the dialog box procedure
        /// and carrying out default processing for any messages that the dialog box procedure returns as <see cref="FALSE"/>.
        /// Applications that create custom window procedures for their custom dialog boxes often use <see cref="DefDlgProc"/>
        /// instead of the <see cref="DefWindowProc"/> function to carry out default message processing.
        /// Applications create custom dialog box classes by filling a <see cref="WNDCLASS"/> structure with appropriate information
        /// and registering the class with the <see cref="RegisterClass"/> function.
        /// Some applications fill the structure by using the <see cref="GetClassInfo"/> function, specifying the name of the predefined dialog box.
        /// In such cases, the applications modify at least the <see cref="WNDCLASS.lpszClassName"/> member before registering.
        /// In all cases, the <see cref="WNDCLASS.cbWndExtra"/> member of <see cref="WNDCLASS"/> for a custom dialog box class
        /// must be set to at least <see cref="DLGWINDOWEXTRA"/>.
        /// The <see cref="DefDlgProc"/> function must not be called by a dialog box procedure; doing so results in recursive execution.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefDlgProcW", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT DefDlgProc([In]HWND hDlg, [In]WindowsMessages Msg, [In]WPARAM wParam, [In]LPARAM lParam);

        /// <summary>
        /// <para>
        /// Creates a modal dialog box from a dialog box template resource.
        /// <see cref="DialogBox"/> does not return control until the specified callback function terminates the modal dialog box
        /// by calling the <see cref="EndDialog"/> function.
        /// <see cref="DialogBox"/> is implemented as a call to the <see cref="DialogBoxParam"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-dialogboxw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module which contains the dialog box template.
        /// If this parameter is <see cref="IntPtr.Zero"/>, then the current executable is used.
        /// </param>
        /// <param name="lpTemplate">
        /// The dialog box template.
        /// This parameter is either the pointer to a null-terminated character string that specifies the name of the dialog box template
        /// or an integer value that specifies the resource identifier of the dialog box template.
        /// If the parameter specifies a resource identifier, its high-order word must be zero and its low-order word must contain the identifier.
        /// You can use the <see cref="MAKEINTRESOURCE"/> macro to create this value.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the window that owns the dialog box.
        /// </param>
        /// <param name="lpDialogFunc">
        /// A pointer to the dialog box procedure. For more information about the dialog box procedure, see <see cref="DLGPROC"/>.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The <see cref="DialogBox"/> macro uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="DialogBox"/> then sends a <see cref="WM_INITDIALOG"/> message 
        /// (and a <see cref="WM_SETFONT"/> message if the template specifies the <see cref="DS_SETFONT"/>
        /// or <see cref="DS_SHELLFONT"/> style) to the dialog box procedure.
        /// The function displays the dialog box (regardless of whether the template specifies the <see cref="WS_VISIBLE"/> style),
        /// disables the owner window, and starts its own message loop to retrieve and dispatch messages for the dialog box.
        /// When the dialog box procedure calls the <see cref="EndDialog"/> function, <see cref="DialogBoxParam"/> destroys the dialog box,
        /// ends the message loop, enables the owner window (if previously enabled), and returns the nResult parameter specified
        /// by the dialog box procedure when it called <see cref="EndDialog"/>.
        /// </remarks>
        public static INT_PTR DialogBox(HINSTANCE hInstance, StringHandle lpTemplate, HWND hWndParent, DLGPROC lpDialogFunc) =>
            DialogBoxParam(hInstance, lpTemplate, hWndParent, lpDialogFunc, NULL);

        /// <summary>
        /// <para>
        /// Creates a modal dialog box from a dialog box template in memory.
        /// <see cref="DialogBoxIndirect"/> does not return control until the specified callback function
        /// terminates the modal dialog box by calling the <see cref="EndDialog"/> function.
        /// <see cref="DialogBoxIndirect"/> is implemented as a call to the <see cref="DialogBoxIndirectParam"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-dialogboxindirectw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module which contains the dialog box template.
        /// If this parameter is <see cref="IntPtr.Zero"/>, then the current executable is used.
        /// </param>
        /// <param name="lpTemplate">
        /// The template that <see cref="DialogBoxIndirectParam"/> uses to create the dialog box.
        /// A dialog box template consists of a header that describes the dialog box, followed by one or more additional blocks 
        /// of data that describe each of the controls in the dialog box.
        /// The template can use either the standard format or the extended format.
        /// In a standard template for a dialog box, the header is a <see cref="DLGTEMPLATE"/> structure followed by additional variable-length arrays.
        /// The data for each control consists of a <see cref="DLGITEMTEMPLATE"/> structure followed by additional variable-length arrays.
        /// In an extended template for a dialog box, the header uses the <see cref="DLGTEMPLATEEX"/> format
        /// and the control definitions use the <see cref="DLGITEMTEMPLATEEX"/> format.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the window that owns the dialog box.
        /// </param>
        /// <param name="lpDialogFunc">
        /// A pointer to the dialog box procedure.
        /// For more information about the dialog box procedure, see <see cref="DLGPROC"/>.
        /// </param>
        /// <remarks>
        /// The <see cref="DialogBoxIndirect"/> macro uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="DialogBoxIndirect"/> then sends a <see cref="WM_INITDIALOG"/> message to the dialog box procedure.
        /// If the template specifies the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style,
        /// the function also sends a <see cref="WM_SETFONT"/> message to the dialog box procedure.
        /// The function displays the dialog box (regardless of whether the template specifies the <see cref="WS_VISIBLE"/> style),
        /// disables the owner window, and starts its own message loop to retrieve and dispatch messages for the dialog box.
        /// When the dialog box procedure calls the <see cref="EndDialog"/> function, <see cref="DialogBoxIndirect"/> destroys the dialog box,
        /// ends the message loop, enables the owner window (if previously enabled), and returns the nResult parameter specified
        /// by the dialog box procedure when it called <see cref="EndDialog"/>.
        /// In a standard dialog box template, the <see cref="DLGTEMPLATE"/> structure and each of the <see cref="DLGITEMTEMPLATE"/> structures
        /// must be aligned on DWORD boundaries.
        /// The creation data array that follows a <see cref="DLGITEMTEMPLATE"/> structure must also be aligned on a DWORD boundary.
        /// All of the other variable-length arrays in the template must be aligned on WORD boundaries.
        /// In an extended dialog box template, the <see cref="DLGTEMPLATEEX"/> header and each of the <see cref="DLGITEMTEMPLATEEX"/> control
        /// definitions must be aligned on DWORD boundaries.
        /// The creation data array, if any, that follows a <see cref="DLGITEMTEMPLATEEX"/> structure must also be aligned on a DWORD boundary.
        /// All of the other variable-length arrays in the template must be aligned on WORD boundaries.
        /// All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.
        /// Use the <see cref="MultiByteToWideChar"/> function to generate Unicode strings from ANSI strings.
        /// </remarks>
        public static INT_PTR DialogBoxIndirect(HINSTANCE hInstance, in DLGTEMPLATE lpTemplate, HWND hWndParent, DLGPROC lpDialogFunc) =>
            DialogBoxIndirectParam(hInstance, lpTemplate, hWndParent, lpDialogFunc, NULL);

        /// <summary>
        /// <para>
        /// Creates a modal dialog box from a dialog box template in memory.
        /// Before displaying the dialog box, the function passes an application-defined value to the dialog box procedure
        /// as the lParam parameter of the <see cref="WM_INITDIALOG"/> message.
        /// An application can use this value to initialize dialog box controls.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-dialogboxindirectparamw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module that creates the dialog box.
        /// </param>
        /// <param name="lpTemplateName">
        /// The template that <see cref="DialogBoxIndirectParam"/> uses to create the dialog box.
        /// A dialog box template consists of a header that describes the dialog box, followed by one or more additional blocks 
        /// of data that describe each of the controls in the dialog box.
        /// The template can use either the standard format or the extended format.
        /// In a standard template for a dialog box, the header is a <see cref="DLGTEMPLATE"/> structure followed by additional variable-length arrays.
        /// The data for each control consists of a <see cref="DLGITEMTEMPLATE"/> structure followed by additional variable-length arrays.
        /// In an extended template for a dialog box, the header uses the <see cref="DLGTEMPLATEEX"/> format
        /// and the control definitions use the <see cref="DLGITEMTEMPLATEEX"/> format.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the window that owns the dialog box.
        /// </param>
        /// <param name="lpDialogFunc">
        /// A pointer to the dialog box procedure.
        /// For more information about the dialog box procedure, see <see cref="DLGPROC"/>.
        /// </param>
        /// <param name="dwInitParam">
        /// The value to pass to the dialog box in the lParam parameter of the <see cref="WM_INITDIALOG"/> message.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the nResult parameter specified in the call to
        /// the <see cref="EndDialog"/> function that was used to terminate the dialog box.
        /// If the function fails because the <paramref name="hWndParent"/> parameter is invalid, the return value is <see cref="IntPtr.Zero"/>.
        /// The function returns zero in this case for compatibility with previous versions of Windows.
        /// If the function fails for any other reason, the return value is –1.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DialogBoxIndirectParam"/> function uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="DialogBoxIndirectParam"/> then sends a <see cref="WM_INITDIALOG"/> message to the dialog box procedure.
        /// If the template specifies the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style,
        /// the function also sends a <see cref="WM_SETFONT"/> message to the dialog box procedure.
        /// The function displays the dialog box (regardless of whether the template specifies the <see cref="WS_VISIBLE"/> style),
        /// disables the owner window, and starts its own message loop to retrieve and dispatch messages for the dialog box.
        /// When the dialog box procedure calls the <see cref="EndDialog"/> function, <see cref="DialogBoxIndirectParam"/> destroys the dialog box,
        /// ends the message loop, enables the owner window (if previously enabled), and returns the nResult parameter specified
        /// by the dialog box procedure when it called <see cref="EndDialog"/>.
        /// In a standard dialog box template, the <see cref="DLGTEMPLATE"/> structure and each of the <see cref="DLGITEMTEMPLATE"/> structures
        /// must be aligned on DWORD boundaries.
        /// The creation data array that follows a <see cref="DLGITEMTEMPLATE"/> structure must also be aligned on a DWORD boundary.
        /// All of the other variable-length arrays in the template must be aligned on WORD boundaries.
        /// In an extended dialog box template, the <see cref="DLGTEMPLATEEX"/> header and each of the <see cref="DLGITEMTEMPLATEEX"/> control
        /// definitions must be aligned on DWORD boundaries.
        /// The creation data array, if any, that follows a <see cref="DLGITEMTEMPLATEEX"/> structure must also be aligned on a DWORD boundary.
        /// All of the other variable-length arrays in the template must be aligned on WORD boundaries.
        /// All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DialogBoxIndirectParamW", ExactSpelling = true, SetLastError = true)]
        public static extern INT_PTR DialogBoxIndirectParam([In]HINSTANCE hInstance, [In]in DLGTEMPLATE lpTemplateName, [In]HWND hWndParent,
            [In]DLGPROC lpDialogFunc, [In]LPARAM dwInitParam);

        /// <summary>
        /// <para>
        /// Creates a modal dialog box from a dialog box template resource.
        /// Before displaying the dialog box, the function passes an application-defined value to the dialog box procedure
        /// as the lParam parameter of the <see cref="WM_INITDIALOG"/> message.
        /// An application can use this value to initialize dialog box controls.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-dialogboxparamw
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module which contains the dialog box template.
        /// If this parameter is <see cref="IntPtr.Zero"/>, then the current executable is used.
        /// </param>
        /// <param name="lpTemplateName">
        /// The dialog box template.
        /// This parameter is either the pointer to a null-terminated character string that specifies the name of the dialog box template
        /// or an integer value that specifies the resource identifier of the dialog box template.
        /// If the parameter specifies a resource identifier, its high-order word must be zero and its low-order word must contain the identifier.
        /// You can use the <see cref="MAKEINTRESOURCE"/> macro to create this value.
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the window that owns the dialog box.
        /// </param>
        /// <param name="lpDialogFunc">
        /// A pointer to the dialog box procedure. For more information about the dialog box procedure, see <see cref="DLGPROC"/>.
        /// </param>
        /// <param name="dwInitParam">
        /// The value to pass to the dialog box in the lParam parameter of the <see cref="WM_INITDIALOG"/> message.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the value of the nResult parameter specified
        /// in the call to the <see cref="EndDialog"/> function used to terminate the dialog box.
        /// If the function fails because the <paramref name="hWndParent"/> parameter is invalid, the return value is <see cref="IntPtr.Zero"/>.
        /// The function returns <see cref="IntPtr.Zero"/> in this case for compatibility with previous versions of Windows.
        /// If the function fails for any other reason, the return value is –1.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DialogBoxParam"/> function uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="DialogBoxParam"/> then sends a <see cref="WM_INITDIALOG"/> message 
        /// (and a <see cref="WM_SETFONT"/> message if the template specifies the <see cref="DS_SETFONT"/>
        /// or <see cref="DS_SHELLFONT"/> style) to the dialog box procedure.
        /// The function displays the dialog box (regardless of whether the template specifies the <see cref="WS_VISIBLE"/> style),
        /// disables the owner window, and starts its own message loop to retrieve and dispatch messages for the dialog box.
        /// When the dialog box procedure calls the <see cref="EndDialog"/> function, <see cref="DialogBoxParam"/> destroys the dialog box,
        /// ends the message loop, enables the owner window (if previously enabled), and returns the nResult parameter specified
        /// by the dialog box procedure when it called <see cref="EndDialog"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DialogBoxParamW", ExactSpelling = true, SetLastError = true)]
        public static extern INT_PTR DialogBoxParam([In]HINSTANCE hInstance, [In]StringHandle lpTemplateName, [In]HWND hWndParent,
            [In] DLGPROC lpDialogFunc, [In]LPARAM dwInitParam);

        /// <summary>
        /// <para>
        /// Replaces the contents of a list box with the names of the subdirectories and files in a specified directory.
        /// You can filter the list of names by specifying a set of file attributes.
        /// The list can optionally include mapped drives.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-dlgdirlistw
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box that contains the list box.
        /// </param>
        /// <param name="lpPathSpec">
        /// A pointer to a buffer containing a null-terminated string that specifies an absolute path, relative path, or filename.
        /// An absolute path can begin with a drive letter (for example, d:) or a UNC name (for example, \ machinename sharename).
        /// The function splits the string into a directory and a filename.
        /// The function searches the directory for names that match the filename.
        /// If the string does not specify a directory, the function searches the current directory.
        /// If the string includes a filename, the filename must contain at least one wildcard character (? or ).
        /// If the string does not include a filename, the function behaves as if you had specified the asterisk wildcard character () as the filename.
        /// All names in the specified directory that match the filename and
        /// have the attributes specified by the <paramref name="uFileType"/> parameter are added to the list box.
        /// </param>
        /// <param name="nIDListBox">
        /// The identifier of a list box in the <paramref name="hDlg"/> dialog box.
        /// If this parameter is zero, <see cref="DlgDirList"/> does not try to fill a list box.
        /// </param>
        /// <param name="nIDStaticPath">
        /// The identifier of a static control in the <paramref name="hDlg"/> dialog box.
        /// <see cref="DlgDirList"/> sets the text of this control to display the current drive and directory.
        /// This parameter can be zero if you do not want to display the current drive and directory.
        /// </param>
        /// <param name="uFileType">
        /// Specifies the attributes of the files or directories to be added to the list box.
        /// This parameter can be one or more of the following values.
        /// <see cref="DDL_ARCHIVE"/>:
        /// Includes archived files.
        /// <see cref="DDL_DIRECTORY"/>:
        /// Includes subdirectories. Subdirectory names are enclosed in square brackets ([ ]).
        /// <see cref="DDL_DRIVES"/>:
        /// All mapped drives are added to the list. Drives are listed in the form [- x-], where x is the drive letter.
        /// <see cref="DDL_EXCLUSIVE"/>:
        /// Includes only files with the specified attributes.
        /// By default, read/write files are listed even if <see cref="DDL_READWRITE"/> is not specified.
        /// <see cref="DDL_HIDDEN"/>:
        /// Includes hidden files.
        /// <see cref="DDL_READONLY"/>:
        /// Includes read-only files.
        /// <see cref="DDL_READWRITE"/>:
        /// Includes read/write files with no additional attributes.
        /// This is the default setting.
        /// <see cref="DDL_SYSTEM"/>:
        /// Includes system files.
        /// <see cref="DDL_POSTMSGS"/>:
        /// If set, <see cref="DlgDirList"/> uses the <see cref="PostMessage"/> function to send messages to the list box.
        /// If not set, <see cref="DlgDirList"/> uses the <see cref="SendMessage"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// For example, if the string specified by <paramref name="lpPathSpec"/> is not a valid path, the function fails.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If <paramref name="lpPathSpec"/> specifies a directory, <see cref="DlgDirListComboBox"/> changes the current directory
        /// to the specified directory before filling the list box.
        /// The text of the static control identified by the <paramref name="nIDStaticPath"/> parameter is set to the name of the new current directory.
        /// <see cref="DlgDirList"/> sends the <see cref="LB_RESETCONTENT"/> and <see cref="LB_DIR"/> messages to the list box.
        /// If <paramref name="uFileType"/> includes the <see cref="DDL_DIRECTORY"/> flag
        /// and <paramref name="lpPathSpec"/> specifies a first-level directory, such as C:\TEMP,
        /// the list box will always include a ".." entry for the root directory.
        /// This is true even if the root directory has hidden or system attributes
        /// and the <see cref="DDL_HIDDEN"/> and <see cref="DDL_SYSTEM"/> flags are not specified.
        /// The root directory of an NTFS volume has hidden and system attributes.
        /// The directory listing displays long filenames, if any.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DlgDirListW", ExactSpelling = true, SetLastError = true)]
        public static extern int DlgDirList([In]HWND hDlg, [MarshalAs(UnmanagedType.LPWStr)][In]string lpPathSpec, [In]int nIDListBox,
            [In]int nIDStaticPath, [In]DlgDirListFlags uFileType);

        /// <summary>
        /// <para>
        /// Replaces the contents of a combo box with the names of the subdirectories and files in a specified directory.
        /// You can filter the list of names by specifying a set of file attributes.
        /// The list of names can include mapped drive letters.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-dlgdirlistcomboboxw
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box that contains the combo box.
        /// </param>
        /// <param name="lpPathSpec">
        /// A pointer to a buffer containing a null-terminated string that specifies an absolute path, relative path, or file name.
        /// An absolute path can begin with a drive letter (for example, d:) or a UNC name (for example, \machinename sharename).
        /// The function splits the string into a directory and a file name.
        /// The function searches the directory for names that match the file name.
        /// If the string does not specify a directory, the function searches the current directory.
        /// If the string includes a file name, the file name must contain at least one wildcard character (? or ).
        /// If the string does not include a file name, the function behaves as if you had specified the asterisk wildcard character () as the file name.
        /// All names in the specified directory that match the file name and have the attributes
        /// specified by the <paramref name="uFileType"/> parameter are added to the list displayed in the combo box.
        /// </param>
        /// <param name="nIDComboBox">
        /// The identifier of a combo box in the <paramref name="hDlg"/> dialog box.
        /// If this parameter is zero, <see cref="DlgDirListComboBox"/> does not try to fill a combo box.
        /// </param>
        /// <param name="nIDStaticPath">
        /// The identifier of a static control in the <paramref name="hDlg"/> dialog box.
        /// <see cref="DlgDirListComboBox"/> sets the text of this control to display the current drive and directory.
        /// This parameter can be zero if you do not want to display the current drive and directory.
        /// </param>
        /// <param name="uFileType">
        /// A set of bit flags that specifies the attributes of the files or directories to be added to the combo box.
        /// This parameter can be a combination of the following values.
        /// <see cref="DDL_ARCHIVE"/>:
        /// Includes archived files.
        /// <see cref="DDL_DIRECTORY"/>:
        /// Includes subdirectories. Subdirectory names are enclosed in square brackets ([ ]).
        /// <see cref="DDL_DRIVES"/>:
        /// All mapped drives are added to the list. Drives are listed in the form [- x-], where x is the drive letter.
        /// <see cref="DDL_EXCLUSIVE"/>:
        /// Includes only files with the specified attributes.
        /// By default, read/write files are listed even if <see cref="DDL_READWRITE"/> is not specified.
        /// <see cref="DDL_HIDDEN"/>:
        /// Includes hidden files.
        /// <see cref="DDL_READONLY"/>:
        /// Includes read-only files.
        /// <see cref="DDL_READWRITE"/>:
        /// Includes read/write files with no additional attributes.
        /// This is the default setting.
        /// <see cref="DDL_SYSTEM"/>:
        /// Includes system files.
        /// <see cref="DDL_POSTMSGS"/>:
        /// If set, <see cref="DlgDirListComboBox"/> uses the <see cref="PostMessage"/> function to send messages to the list box.
        /// If not set, <see cref="DlgDirListComboBox"/> uses the <see cref="SendMessage"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// For example, if the string specified by <paramref name="lpPathSpec"/> is not a valid path, the function fails.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If <paramref name="lpPathSpec"/> specifies a directory, <see cref="DlgDirListComboBox"/> changes the current directory
        /// to the specified directory before filling the combo box.
        /// The text of the static control identified by the <paramref name="nIDStaticPath"/> parameter is set to the name of the new current directory.
        /// <see cref="DlgDirListComboBox"/> sends the <see cref="CB_RESETCONTENT"/> and <see cref="CB_DIR"/> messages to the combo box.
        /// Microsoft Windows NT 4.0 and later:
        /// If <paramref name="uFileType"/> includes the <see cref="DDL_DIRECTORY"/> flag and <paramref name="lpPathSpec"/> specifies a first-level directory,
        /// such as C:\TEMP, the combo box will always include a ".." entry for the root directory.
        /// This is true even if the root directory has hidden or system attributes and the <see cref="DDL_HIDDEN"/> 
        /// and <see cref="DDL_SYSTEM"/> flags are not specified.
        /// The root directory of an NTFS volume has hidden and system attributes.
        /// Security Warning:
        /// Using this function incorrectly might compromise the security of your program.
        /// Incorrect use of this function includes having <paramref name="lpPathSpec"/> indicate a non-writeable buffer,
        /// or a buffer without a null-termination.
        /// You should review the Security Considerations: Microsoft Windows Controls before continuing.
        /// Microsoft Windows NT 4.0 and later:
        /// The list displays long file names, if any.
        /// Windows 95 or later:
        /// The list displays short file names (the 8.3 form).
        /// You can use the <see cref="SHGetFileInfo"/> or <see cref="GetFullPathName"/> functions to get the corresponding long file name.
        /// Windows 95 or later:
        /// <see cref="DlgDirListComboBox"/> is supported by the Microsoft Layer for Unicode.
        /// To use this, you must add certain files to your application, as outlined in Microsoft Layer for Unicode on Windows Me/98/95 Systems.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DlgDirListComboBoxW", ExactSpelling = true, SetLastError = true)]
        public static extern int DlgDirListComboBox([In]HWND hDlg, [MarshalAs(UnmanagedType.LPWStr)][In]string lpPathSpec, [In]int nIDComboBox,
             [In]int nIDStaticPath, [In]DlgDirListFlags uFileType);

        /// <summary>
        /// <para>
        /// Retrieves the current selection from a combo box filled by using the <see cref="DlgDirListComboBox"/> function.
        /// The selection is interpreted as a drive letter, a file, or a directory name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-dlgdirselectcomboboxexw
        /// </para>
        /// </summary>
        /// <param name="hwndDlg">
        /// A handle to the dialog box that contains the combo box.
        /// </param>
        /// <param name="lpString">
        /// A pointer to the buffer that receives the selected path.
        /// </param>
        /// <param name="cchOut">
        /// The length, in characters, of the buffer pointed to by the <paramref name="lpString"/> parameter.
        /// </param>
        /// <param name="idComboBox">
        /// The integer identifier of the combo box control in the dialog box.
        /// </param>
        /// <returns>
        /// If the current selection is a directory name, the return value is <see cref="TRUE"/>.
        /// If the current selection is not a directory name, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the current selection specifies a directory name or drive letter,
        /// the <see cref="DlgDirSelectComboBoxEx"/> function removes the enclosing square brackets (and hyphens for drive letters)
        /// so the name or letter is ready to be inserted into a new path or file name.
        /// If there is no selection, the contents of the buffer pointed to by <paramref name="lpString"/> do not change.
        /// The <see cref="DlgDirSelectComboBoxEx"/> function does not allow more than one file name to be returned from a combo box.
        /// If the string is as long or longer than the buffer, the buffer contains the truncated string with a terminating null character.
        /// <see cref="DlgDirSelectComboBoxEx"/> sends <see cref="CB_GETCURSEL"/> and <see cref="CB_GETLBTEXT"/> messages to the combo box.
        /// You can use this function with all three types of combo boxes (<see cref="CBS_SIMPLE"/>, <see cref="CBS_DROPDOWN"/>,
        /// and <see cref="CBS_DROPDOWNLIST"/>).
        /// Security Warning:
        /// Improper use of this function can cause problems for your application.
        /// For instance, the <paramref name="cchOut"/> parameter should be set properly for both ANSI and Unicode versions.
        /// Failure to do so could lead to a buffer overflow.
        /// You should review Security Considerations: Microsoft Windows Controls before continuing.
        /// Windows 95 or later:
        /// <see cref="DlgDirSelectComboBoxEx"/> is supported by the Microsoft Layer for Unicode (MSLU).
        /// To use this, you must add certain files to your application, as outlined in Microsoft Layer for Unicode on Windows Me/98/95 Systems.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DlgDirSelectComboBoxExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DlgDirSelectComboBoxEx([In]HWND hwndDlg, [Out]StringBuilder lpString, [In]int cchOut, [In]int idComboBox);

        /// <summary>
        /// <para>
        /// Retrieves the current selection from a single-selection list box.
        /// It assumes that the list box has been filled by the <see cref="DlgDirList"/> function
        /// and that the selection is a drive letter, filename, or directory name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-dlgdirselectexw
        /// </para>
        /// </summary>
        /// <param name="hwndDlg">
        /// A handle to the dialog box that contains the list box.
        /// </param>
        /// <param name="lpString">
        /// A pointer to a buffer that receives the selected path.
        /// </param>
        /// <param name="chCount">
        /// The length, in TCHARs, of the buffer pointed to by lpString.
        /// </param>
        /// <param name="idListBox">
        /// The identifier of a list box in the dialog box.
        /// </param>
        /// <returns>
        /// If the current selection is a directory name, the return value is <see cref="TRUE"/>.
        /// If the current selection is not a directory name, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DlgDirSelectEx"/> function copies the selection to the buffer pointed to by the <paramref name="lpString"/> parameter.
        /// If the current selection is a directory name or drive letter, <see cref="DlgDirSelectEx"/> removes the enclosing square brackets
        /// (and hyphens, for drive letters), so that the name or letter is ready to be inserted into a new path.
        /// If there is no selection, <paramref name="lpString"/> does not change.
        /// If the string is as long or longer than the buffer, the buffer will contain the truncated string with a terminating null character.
        /// <see cref="DlgDirSelectEx"/> sends <see cref="LB_GETCURSEL"/> and <see cref="LB_GETTEXT"/> messages to the list box.
        /// The function does not allow more than one filename to be returned from a list box.
        /// The list box must not be a multiple-selection list box.
        /// If it is, this function does not return a zero value and <paramref name="lpString"/> remains unchanged.
        /// Windows 95 or later:
        /// <see cref="DlgDirSelectEx"/> is supported by the Microsoft Layer for Unicode.
        /// To use this, you must add certain files to your application, as outlined in Microsoft Layer for Unicode on Windows Me/98/95 Systems.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DlgDirSelectExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DlgDirSelectEx([In]HWND hwndDlg, [Out]StringBuilder lpString, [In]int chCount, [In]int idListBox);

        /// <summary>
        /// <para>
        /// Destroys a modal dialog box, causing the system to end any processing for the dialog box.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enddialog
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box to be destroyed.
        /// </param>
        /// <param name="nResult">
        /// The value to be returned to the application from the function that created the dialog box.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Dialog boxes created by the <see cref="DialogBox"/>, <see cref="DialogBoxParam"/>, <see cref="DialogBoxIndirect"/>,
        /// and <see cref="DialogBoxIndirectParam"/> functions must be destroyed using the <see cref="EndDialog"/> function.
        /// An application calls <see cref="EndDialog"/> from within the dialog box procedure; the function must not be used for any other purpose.
        /// A dialog box procedure can call <see cref="EndDialog"/> at any time, even during the processing of the <see cref="WM_INITDIALOG"/> message.
        /// If your application calls the function while <see cref="WM_INITDIALOG"/> is being processed,
        /// the dialog box is destroyed before it is shown and before the input focus is set.
        /// <see cref="EndDialog"/> does not destroy the dialog box immediately.
        /// Instead, it sets a flag and allows the dialog box procedure to return control to the system.
        /// The system checks the flag before attempting to retrieve the next message from the application queue.
        /// If the flag is set, the system ends the message loop, destroys the dialog box, and uses the value in <paramref name="nResult"/>
        /// as the return value from the function that created the dialog box.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndDialog", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EndDialog([In]HWND hDlg, [In]INT_PTR nResult);

        /// <summary>
        /// <para>
        /// Retrieves the system's dialog base units, which are the average width and height of characters in the system font.
        /// For dialog boxes that use the system font, you can use these values to convert between dialog template units,
        /// as specified in dialog box templates, and pixels.
        /// For dialog boxes that do not use the system font, the conversion from dialog template units to pixels depends on the font used by the dialog box.
        /// For either type of dialog box, it is easier to use the <see cref="MapDialogRect"/> function to perform the conversion.
        /// <see cref="MapDialogRect"/> takes the font into account and correctly converts a rectangle from dialog template units into pixels.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdialogbaseunits
        /// </para>
        /// </summary>
        /// <returns>
        /// The function returns the dialog base units.
        /// The low-order word of the return value contains the horizontal dialog box base unit,
        /// and the high-order word contains the vertical dialog box base unit.
        /// </returns>
        /// <remarks>
        /// The horizontal base unit returned by <see cref="GetDialogBaseUnits"/> is equal to the average width, in pixels,
        /// of the characters in the system font; the vertical base unit is equal to the height, in pixels, of the font.
        /// The system font is used only if the dialog box template fails to specify a font.
        /// Most dialog box templates specify a font; as a result, this function is not useful for most dialog boxes.
        /// For a dialog box that does not use the system font, the base units are the average width and height, in pixels,
        /// of the characters in the dialog's font.
        /// You can use the <see cref="GetTextMetrics"/> and <see cref="GetTextExtentPoint32"/> functions to calculate these values for a selected font.
        /// However, by using the <see cref="MapDialogRect"/> function, you can avoid errors that might result
        /// if your calculations differ from those performed by the system.
        /// Each horizontal base unit is equal to 4 horizontal dialog template units; each vertical base unit is equal to 8 vertical dialog template units.
        /// Therefore, to convert dialog template units to pixels, use the following formulas:
        /// <code>
        /// pixelX = MulDiv(templateunitX, baseunitX, 4);
        /// pixelY = MulDiv(templateunitY, baseunitY, 8);
        /// </code>
        /// Similarly, to convert from pixels to dialog template units, use the following formulas:
        /// <code>
        /// templateunitX = MulDiv(pixelX, 4, baseunitX);
        /// templateunitY = MulDiv(pixelY, 8, baseunitY);
        /// </code>
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDialogBaseUnits", ExactSpelling = true, SetLastError = true)]
        public static extern long GetDialogBaseUnits();

        /// <summary>
        /// <para>
        /// Retrieves the identifier of the specified control.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdlgctrlid
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the control.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the identifier of the control.
        /// If the function fails, the return value is zero.
        /// An invalid value for the <paramref name="hWnd"/> parameter, for example, will cause the function to fail.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="GetDlgCtrlID"/> accepts child window handles as well as handles of controls in dialog boxes.
        /// An application sets the identifier for a child window when it creates the window
        /// by assigning the identifier value to the hmenu parameter when calling the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function.
        /// Although <see cref="GetDlgCtrlID"/> may return a value if <paramref name="hWnd"/> is a handle to a top-level window,
        /// top-level windows cannot have identifiers and such a return value is never valid.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDlgCtrlID", ExactSpelling = true, SetLastError = true)]
        public static extern int GetDlgCtrlID([In]HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves a handle to a control in the specified dialog box.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdlgitem
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box that contains the control.
        /// </param>
        /// <param name="nIDDlgItem">
        /// The identifier of the control to be retrieved.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the window handle of the specified control.
        /// If the function fails, the return value is <see cref="NULL"/>, indicating an invalid dialog box handle or a nonexistent control.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// You can use the <see cref="GetDlgItem"/> function with any parent-child window pair, not just with dialog boxes.
        /// As long as the <paramref name="hDlg"/> parameter specifies a parent window and the child window has a unique identifier
        /// (as specified by the hMenu parameter in the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function that created the child window),
        /// <see cref="GetDlgItem"/> returns a valid handle to the child window.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDlgItem", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetDlgItem([In]HWND hDlg, [In]int nIDDlgItem);

        /// <summary>
        /// <para>
        /// Translates the text of a specified control in a dialog box into an integer value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdlgitemint
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box that contains the control of interest.
        /// </param>
        /// <param name="nIDDlgItem">
        /// The identifier of the control whose text is to be translated.
        /// </param>
        /// <param name="lpTranslated">
        /// Indicates success or failure (<see langword="true"/> indicates success, <see langword="false"/>  indicates failure).
        /// If this parameter is <see langword="null"/>, the function returns no information about success or failure.
        /// </param>
        /// <param name="bSigned">
        /// Indicates whether the function should examine the text for a minus sign at the beginning and return a signed integer value
        /// if it finds one (<see langword="true"/> specifies this should be done, <see langword="false"/> that it should not).
        /// </param>
        /// <returns>
        /// If the function succeeds, the variable pointed to by <paramref name="lpTranslated"/> is set to <see langword="true"/>,
        /// and the return value is the translated value of the control text.
        /// If the function fails, the variable pointed to by <paramref name="lpTranslated"/> is set to <see langword="false"/>,
        /// and the return value is zero.
        /// Note that, because zero is a possible translated value, a return value of zero does not by itself indicate failure.
        /// If <paramref name="lpTranslated"/> is <see langword="null"/>, the function returns no information about success or failure.
        /// Note that, if the <paramref name="bSigned"/> parameter is <see langword="true"/> and there is a minus sign (–) at the beginning of the text,
        /// <see cref="GetDlgItemInt"/> translates the text into a signed integer value.
        /// Otherwise, the function creates an unsigned integer value.
        /// To obtain the proper value in this case, cast the return value to an int type.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetDlgItemInt"/> function retrieves the text of the specified control by sending the control a <see cref="WM_GETTEXT"/> message.
        /// The function translates the retrieved text by stripping any extra spaces at the beginning of the text and then converting the decimal digits.
        /// The function stops translating when it reaches the end of the text or encounters a nonnumeric character.
        /// The <see cref="GetDlgItemInt"/> function returns zero if the translated value is
        /// greater than <see cref="int.MaxValue"/> (for signed numbers) or <see cref="uint.MaxValue"/> (for unsigned numbers).
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDlgItemInt", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetDlgItemInt([In]HWND hDlg, [In]int nIDDlgItem, [Out]out BOOL lpTranslated, [In]BOOL bSigned);

        /// <summary>
        /// <para>
        /// Retrieves the title or text associated with a control in a dialog box.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdlgitemtextw
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box that contains the control.
        /// </param>
        /// <param name="nIDDlgItem">
        /// The identifier of the control whose title or text is to be retrieved.
        /// </param>
        /// <param name="lpString">
        /// The buffer to receive the title or text.
        /// </param>
        /// <param name="cchMax">
        /// The maximum length, in characters, of the string to be copied to the buffer pointed to by <paramref name="lpString"/>.
        /// If the length of the string, including the null character, exceeds the limit, the string is truncated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the number of characters copied to the buffer, not including the terminating null character.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the string is as long or longer than the buffer, the buffer will contain the truncated string with a terminating null character.
        /// The <see cref="GetDlgItemText"/> function sends a <see cref="WM_GETTEXT"/> message to the control.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDlgItemTextW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetDlgItemText([In]HWND hDlg, [In]int nIDDlgItem, [MarshalAs(UnmanagedType.LPWStr)][In]StringBuilder lpString,
            [In]int cchMax);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the first control in a group of controls that precedes (or follows) the specified control in a dialog box.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getnextdlggroupitem
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box to be searched.
        /// </param>
        /// <param name="hCtl">
        /// A handle to the control to be used as the starting point for the search.
        /// If this parameter is <see cref="NULL"/>, the function uses the last (or first) control in the dialog box as the starting point for the search.
        /// </param>
        /// <param name="bPrevious">
        /// Indicates how the function is to search the group of controls in the dialog box.
        /// If this parameter is <see cref="TRUE"/>, the function searches for the previous control in the group.
        /// If it is <see cref="FALSE"/>, the function searches for the next control in the group.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the previous (or next) control in the group of controls.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetNextDlgGroupItem"/> function searches controls in the order (or reverse order) they were created in the dialog box template.
        /// The first control in the group must have the <see cref="WS_GROUP"/> style; all other controls in the group
        /// must have been consecutively created and must not have the <see cref="WS_GROUP"/> style.
        /// When searching for the previous control, the function returns the first control it locates that is visible and not disabled.
        /// If the control specified by <paramref name="hCtl"/> has the <see cref="WS_GROUP"/> style,
        /// the function temporarily reverses the search to locate the first control having the <see cref="WS_GROUP"/> style,
        /// then resumes the search in the original direction, returning the first control it locates that is visible and not disabled,
        /// or returning <paramref name="hCtl"/> if no such control is found.
        /// When searching for the next control, the function returns the first control it locates that is visible, not disabled,
        /// and does not have the <see cref="WS_GROUP"/> style.
        /// If it encounters a control having the <see cref="WS_GROUP"/> style, the function reverses the search,
        /// locates the first control having the <see cref="WS_GROUP"/> style, and returns this control if it is visible and not disabled.
        /// Otherwise, the function resumes the search in the original direction and returns the first control it locates
        /// that is visible and not disabled, or returns <paramref name="hCtl"/> if no such control is found.
        /// If the search for the next control in the group encounters a window with the <see cref="WS_EX_CONTROLPARENT"/> style,
        /// the system recursively searches the window's children.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNextDlgGroupItem", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetNextDlgGroupItem([In]HWND hDlg, [In]HWND hCtl, [In]BOOL bPrevious);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the first control that has the <see cref="WS_TABSTOP"/> style that precedes (or follows) the specified control.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getnextdlgtabitem
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box to be searched.
        /// </param>
        /// <param name="hCtl">
        /// A handle to the control to be used as the starting point for the search.
        /// If this parameter is <see cref="NULL"/>, the function fails.
        /// </param>
        /// <param name="bPrevious">
        /// Indicates how the function is to search the dialog box.
        /// If this parameter is <see cref="TRUE"/>, the function searches for the previous control in the dialog box.
        /// If this parameter is <see cref="FALSE"/>, the function searches for the next control in the dialog box.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the window handle of the previous (or next) control that has the <see cref="WS_TABSTOP"/> style set.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetNextDlgTabItem"/> function searches controls in the order (or reverse order) they were created in the dialog box template.
        /// The function returns the first control it locates that is visible, not disabled, and has the <see cref="WS_TABSTOP"/> style.
        /// If no such control exists, the function returns <paramref name="hCtl"/>.
        /// If the search for the next control with the <see cref="WS_TABSTOP"/> style encounters a window with the <see cref="WS_EX_CONTROLPARENT"/> style,
        /// the system recursively searches the window's children.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNextDlgTabItem", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetNextDlgTabItem([In]HWND hDlg, [In]HWND hCtl, [In]BOOL bPrevious);

        /// <summary>
        /// <para>
        /// Determines whether a message is intended for the specified dialog box and, if it is, processes the message.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-isdialogmessagew
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box.
        /// </param>
        /// <param name="lpMsg">
        /// A pointer to an <see cref="MSG"/> structure that contains the message to be checked.
        /// </param>
        /// <returns>
        /// If the message has been processed, the return value is <see cref="TRUE"/>.
        /// If the message has not been processed, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Although the <see cref="IsDialogMessage"/> function is intended for modeless dialog boxes,
        /// you can use it with any window that contains controls, enabling the windows to provide the same keyboard selection as is used in a dialog box.
        /// When <see cref="IsDialogMessage"/> processes a message,
        /// it checks for keyboard messages and converts them into selections for the corresponding dialog box.
        /// For example, the TAB key, when pressed, selects the next control or group of controls, and the DOWN ARROW key,
        /// when pressed,selects the next control in a group.
        /// Because the <see cref="IsDialogMessage"/> function performs all necessary translating and dispatching of messages,
        /// a message processed by <see cref="IsDialogMessage"/> must not be
        /// passed to the <see cref="TranslateMessage"/> or <see cref="DispatchMessage"/> function.
        /// <see cref="IsDialogMessage"/> sends <see cref="WM_GETDLGCODE"/> messages to the dialog box procedure to determine which keys should be processed.
        /// <see cref="IsDialogMessage"/> can send <see cref="DM_GETDEFID"/> and <see cref="DM_SETDEFID"/> messages to the window.
        /// These messages are defined in the Winuser.h header file as <see cref="WM_USER"/> and <see cref="WM_USER"/> + 1,
        /// so conflicts are possible with application-defined messages having the same values.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsDialogMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsDialogMessage([In]HWND hDlg, [In]in MSG lpMsg);

        /// <summary>
        /// <para>
        /// Converts the specified dialog box units to screen units (pixels).
        /// The function replaces the coordinates in the specified <see cref="RECT"/> structure with the converted coordinates,
        /// which allows the structure to be used to create a dialog box or position a control within a dialog box.
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to a dialog box.
        /// This function accepts only handles returned by one of the dialog box creation functions; handles for other windows are not valid.
        /// </param>
        /// <param name="lpRect">
        /// A pointer to a <see cref="RECT"/> structure that contains the dialog box coordinates to be converted.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="MapDialogRect"/> function assumes that the initial coordinates in the <see cref="RECT"/> structure represent dialog box units.
        /// To convert these coordinates from dialog box units to pixels, the function retrieves the current horizontal
        /// and vertical base units for the dialog box, then applies the following formulas:
        /// <code>
        /// left   = MulDiv(left,   baseunitX, 4);
        /// right  = MulDiv(right,  baseunitX, 4);
        /// top    = MulDiv(top,    baseunitY, 8);
        /// bottom = MulDiv(bottom, baseunitY, 8);
        /// </code>
        /// If the dialog box template has the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style,
        /// the base units are the average width and height, in pixels, of the characters in the font specified by the template.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapDialogRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MapDialogRect([In]HWND hDlg, [In][Out]ref RECT lpRect);

        /// <summary>
        /// <para>
        /// Sends a message to the specified control in a dialog box.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-senddlgitemmessagew
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box that contains the control.
        /// </param>
        /// <param name="nIDDlgItem">
        /// The identifier of the control that receives the message.
        /// </param>
        /// <param name="Msg">
        /// The message to be sent.
        /// For lists of the system-provided messages, see System-Defined Messages.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// The return value specifies the result of the message processing and depends on the message sent.
        /// </returns>
        /// <remarks>
        /// The <see cref="SendDlgItemMessage"/> function does not return until the message has been processed.
        /// Using <see cref="SendDlgItemMessage"/> is identical to retrieving a handle to the specified control
        /// and calling the <see cref="SendMessage"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendDlgItemMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT SendDlgItemMessage([In]HWND hDlg, [In]int nIDDlgItem, [In]WindowsMessages Msg, [In]WPARAM wParam,
            [In]LPARAM lParam);

        /// <summary>
        /// <para>
        /// Sets the text of a control in a dialog box to the string representation of a specified integer value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setdlgitemint
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box that contains the control.
        /// </param>
        /// <param name="nIDDlgItem">
        /// The control to be changed.
        /// </param>
        /// <param name="uValue">
        /// The integer value used to generate the item text.
        /// </param>
        /// <param name="bSigned">
        /// Indicates whether the <paramref name="uValue"/> parameter is signed or unsigned.
        /// If this parameter is <see cref="TRUE"/>, <paramref name="uValue"/> is signed.
        /// If this parameter is <see cref="TRUE"/> and <paramref name="uValue"/> is less than zero,
        /// a minus sign is placed before the first digit in the string.
        /// If this parameter is <see cref="FALSE"/>, <paramref name="uValue"/> is unsigned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To set the new text, this function sends a <see cref="WM_SETTEXT"/> message to the specified control.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDlgItemInt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetDlgItemInt([In]HWND hDlg, [In]int nIDDlgItem, [In]UINT uValue, [In]BOOL bSigned);

        /// <summary>
        /// <para>
        /// Sets the title or text of a control in a dialog box.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setdlgitemtextw
        /// </para>
        /// </summary>
        /// <param name="hDlg">
        /// A handle to the dialog box that contains the control.
        /// </param>
        /// <param name="nIDDlgItem">
        /// The control with a title or text to be set.
        /// </param>
        /// <param name="lpString">
        /// The text to be copied to the control.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="SetDlgItemText"/> function sends a <see cref="WM_SETTEXT"/> message to the specified control.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDlgItemTextW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetDlgItemText([In]HWND hDlg, [In]int nIDDlgItem, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString);
    }
}
