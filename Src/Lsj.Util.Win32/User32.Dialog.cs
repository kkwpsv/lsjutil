using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DialogBoxCommandIDs;
using static Lsj.Util.Win32.Enums.DialogBoxMessages;
using static Lsj.Util.Win32.Enums.DialogBoxStyles;
using static Lsj.Util.Win32.Enums.GetWindowLongIndexes;
using static Lsj.Util.Win32.Enums.MessageBoxFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.WindowStylesEx;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.BaseTypes.LANGID;

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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowlongptrw"/>
        /// </para>
        /// </summary>
        public static readonly GetWindowLongIndexes DWLP_MSGRESULT = 0;

        /// <summary>
        /// <para>
        /// Retrieves the pointer to the dialog box procedure, or a handle representing the pointer to the dialog box procedure.
        /// You must use the <see cref="CallWindowProc"/> function to call the dialog box procedure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowlongptrw"/>
        /// </para>
        /// </summary>
        public static readonly GetWindowLongIndexes DWLP_DLGPROC = DWLP_MSGRESULT + IntPtr.Size;

        /// <summary>
        /// <para>
        /// Retrieves extra information private to the application, such as handles or pointers.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowlongptrw"/>
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-dlgproc"/>
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
        public delegate IntPtr Dlgproc([In] IntPtr Arg1, [In] WindowMessages Arg2, [In] UIntPtr Arg3, [In] IntPtr Arg4);


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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createdialogindirectw"/>
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
        public static HWND CreateDialogIndirect([In] HINSTANCE hInstance, [In] in DLGTEMPLATE lpTemplate, [In] HWND hWndParent,
            [In] DLGPROC lpDialogFunc) => CreateDialogIndirectParam(hInstance, lpTemplate, hWndParent, lpDialogFunc, NULL);

        /// <summary>
        /// <para>
        /// Creates a modeless dialog box from a dialog box template in memory.
        /// Before displaying the dialog box, the function passes an application-defined value to the dialog box procedure
        /// as the <see cref="MSG.lParam"/> parameter of the <see cref="WM_INITDIALOG"/> message.
        /// An application can use this value to initialize dialog box controls.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createdialogindirectparamw"/>
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
        public static extern HWND CreateDialogIndirectParam([In] HINSTANCE hInstance, [In] in DLGTEMPLATE lpTemplate, [In] HWND hWndParent,
            [In] DLGPROC lpDialogFunc, [In] LPARAM dwInitParam);

        /// <summary>
        /// <para>
        /// Creates a modeless dialog box from a dialog box template resource.
        /// Before displaying the dialog box, the function passes an application-defined value to the dialog box procedure
        /// as the lParam parameter of the <see cref="WM_INITDIALOG"/> message.
        /// An application can use this value to initialize dialog box controls.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createdialogparamw"/>
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
        public static extern HWND CreateDialogParam([In] HINSTANCE hInstance, [In] StringHandle lpTemplateName, [In] HWND hWndParent,
            [In] DLGPROC lpDialogFunc, [In] LPARAM dwInitParam);

        /// <summary>
        /// <para>
        /// Calls the default dialog box window procedure to provide default processing for any window messages
        /// that a dialog box with a private window class does not process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-defdlgprocw"/>
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
        public static extern LRESULT DefDlgProc([In] HWND hDlg, [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Creates a modal dialog box from a dialog box template resource.
        /// <see cref="DialogBox"/> does not return control until the specified callback function terminates the modal dialog box
        /// by calling the <see cref="EndDialog"/> function.
        /// <see cref="DialogBox"/> is implemented as a call to the <see cref="DialogBoxParam"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dialogboxw"/>
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dialogboxindirectw"/>
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dialogboxindirectparamw"/>
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
        public static extern INT_PTR DialogBoxIndirectParam([In] HINSTANCE hInstance, [In] in DLGTEMPLATE lpTemplateName, [In] HWND hWndParent,
            [In] DLGPROC lpDialogFunc, [In] LPARAM dwInitParam);

        /// <summary>
        /// <para>
        /// Creates a modal dialog box from a dialog box template resource.
        /// Before displaying the dialog box, the function passes an application-defined value to the dialog box procedure
        /// as the lParam parameter of the <see cref="WM_INITDIALOG"/> message.
        /// An application can use this value to initialize dialog box controls.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dialogboxparamw"/>
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
        public static extern INT_PTR DialogBoxParam([In] HINSTANCE hInstance, [In] StringHandle lpTemplateName, [In] HWND hWndParent,
            [In] DLGPROC lpDialogFunc, [In] LPARAM dwInitParam);

        /// <summary>
        /// <para>
        /// Destroys a modal dialog box, causing the system to end any processing for the dialog box.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enddialog"/>
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
        public static extern BOOL EndDialog([In] HWND hDlg, [In] INT_PTR nResult);

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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdialogbaseunits"/>
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdlgctrlid"/>
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
        public static extern int GetDlgCtrlID([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Retrieves a handle to a control in the specified dialog box.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdlgitem"/>
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
        public static extern HWND GetDlgItem([In] HWND hDlg, [In] int nIDDlgItem);

        /// <summary>
        /// <para>
        /// Translates the text of a specified control in a dialog box into an integer value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdlgitemint"/>
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
        public static extern UINT GetDlgItemInt([In] HWND hDlg, [In] int nIDDlgItem, [Out] out BOOL lpTranslated, [In] BOOL bSigned);

        /// <summary>
        /// <para>
        /// Retrieves the title or text associated with a control in a dialog box.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdlgitemtextw"/>
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
        public static extern UINT GetDlgItemText([In] HWND hDlg, [In] int nIDDlgItem, [In] IntPtr lpString, [In] int cchMax);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the first control in a group of controls that precedes (or follows) the specified control in a dialog box.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getnextdlggroupitem"/>
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
        public static extern HWND GetNextDlgGroupItem([In] HWND hDlg, [In] HWND hCtl, [In] BOOL bPrevious);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the first control that has the <see cref="WS_TABSTOP"/> style that precedes (or follows) the specified control.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getnextdlgtabitem"/>
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
        public static extern HWND GetNextDlgTabItem([In] HWND hDlg, [In] HWND hCtl, [In] BOOL bPrevious);

        /// <summary>
        /// <para>
        /// Determines whether a message is intended for the specified dialog box and, if it is, processes the message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-isdialogmessagew"/>
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
        public static extern BOOL IsDialogMessage([In] HWND hDlg, [In] in MSG lpMsg);

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
        public static extern BOOL MapDialogRect([In] HWND hDlg, [In][Out] ref RECT lpRect);

        /// <summary>
        /// <para>
        /// Displays a modal dialog box that contains a system icon, a set of buttons, and a brief application-specific message,
        /// such as status or error information.
        /// The message box returns an integer value that indicates which button the user clicked.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-messageboxw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the owner window of the message box to be created.
        /// If this parameter is <see cref="NULL"/>, the message box has no owner window.
        /// </param>
        /// <param name="lpText">
        /// The message to be displayed.
        /// If the string consists of more than one line, you can separate the lines using a carriage return and/or linefeed character between each line.
        /// </param>
        /// <param name="lpCaption">
        /// The dialog box title.
        /// If this parameter is <see langword="null"/>, the default title is Error.
        /// </param>
        /// <param name="uType">
        /// The contents and behavior of the dialog box.
        /// This parameter can be a combination of flags from the following groups of flags.
        /// To indicate the buttons displayed in the message box, specify one of the following values.
        /// <see cref="MB_ABORTRETRYIGNORE"/>, <see cref="MB_CANCELTRYCONTINUE"/>, <see cref="MB_HELP"/>, <see cref="MB_OK"/>,
        /// <see cref="MB_OKCANCEL"/>, <see cref="MB_RETRYCANCEL"/>, <see cref="MB_YESNO"/>, <see cref="MB_YESNOCANCEL"/>
        /// To display an icon in the message box, specify one of the following values.
        /// <see cref="MB_ICONEXCLAMATION"/>, <see cref="MB_ICONWARNING"/>, <see cref="MB_ICONINFORMATION"/>, <see cref="MB_ICONASTERISK"/>,
        /// <see cref="MB_ICONQUESTION"/>, <see cref="MB_ICONSTOP"/>, <see cref="MB_ICONERROR"/>, <see cref="MB_ICONHAND"/>
        /// To indicate the default button, specify one of the following values.
        /// <see cref="MB_DEFBUTTON1"/>, <see cref="MB_DEFBUTTON2"/>, <see cref="MB_DEFBUTTON3"/>, <see cref="MB_DEFBUTTON4"/>
        /// To indicate the modality of the dialog box, specify one of the following values.
        /// <see cref="MB_APPLMODAL"/>, <see cref="MB_SYSTEMMODAL"/>, <see cref="MB_TASKMODAL"/>
        /// To specify other options, use one or more of the following values.
        /// <see cref="MB_DEFAULT_DESKTOP_ONLY"/>, <see cref="MB_RIGHT"/>, <see cref="MB_RTLREADING"/>, <see cref="MB_SETFOREGROUND"/>,
        /// <see cref="MB_TOPMOST"/>, <see cref="MB_SERVICE_NOTIFICATION"/>
        /// </param>
        /// <returns>
        /// If a message box has a Cancel button, the function returns the <see cref="IDCANCEL"/> value
        /// if either the ESC key is pressed or the Cancel button is selected.
        /// If the message box has no Cancel button, pressing ESC has no effect.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the function succeeds, the return value is one of the following menu-item values.
        /// <see cref="IDABORT"/>: The Abort button was selected.
        /// <see cref="IDCANCEL"/>: The Cancel button was selected.
        /// <see cref="IDCONTINUE"/>: The Continue button was selected.
        /// <see cref="IDIGNORE"/>: The Ignore button was selected.
        /// <see cref="IDNO"/>: The No button was selected.
        /// <see cref="IDOK"/>: The OK button was selected.
        /// <see cref="IDRETRY"/>: The Retry button was selected.
        /// <see cref="IDTRYAGAIN"/>: The Try Again button was selected.
        /// <see cref="IDYES"/>: The Yes button was selected.
        /// </returns>
        /// <remarks>
        /// Adding two right-to-left marks (RLMs), represented by Unicode formatting character U+200F,
        /// in the beginning of a MessageBox display string is interpreted by the MessageBox rendering engine
        /// so as to cause the reading order of the MessageBox to be rendered as right-to-left (RTL).
        /// When you use a system-modal message box to indicate that the system is low on memory,
        /// the strings pointed to by the <paramref name="lpText"/> and <paramref name="lpCaption"/> parameters
        /// should not be taken from a resource file because an attempt to load the resource may fail.
        /// If you create a message box while a dialog box is present, use a handle to the dialog box as the <paramref name="hWnd"/> parameter.
        /// The <paramref name="hWnd"/> parameter should not identify a child window, such as a control in a dialog box.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBoxW", ExactSpelling = true, SetLastError = true)]
        public static extern int MessageBox([In] HWND hWnd, [In] LPCWSTR lpText, [In] LPCWSTR lpCaption, [In] MessageBoxFlags uType);

        /// <summary>
        /// <para>
        /// Creates, displays, and operates a message box.
        /// The message box contains an application-defined message and title, plus any combination of predefined icons and push buttons.
        /// The buttons are in the language of the system user interface.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-messageboxexw"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the owner window of the message box to be created.
        /// If this parameter is <see cref="NULL"/>, the message box has no owner window.
        /// </param>
        /// <param name="lpText">
        /// The message to be displayed.
        /// </param>
        /// <param name="lpCaption">
        /// The dialog box title.
        /// If this parameter is <see cref="NULL"/>, the default title Error is used.
        /// </param>
        /// <param name="uType">
        /// The contents and behavior of the dialog box.
        /// For information on the supported flags, see <see cref="MessageBox"/>.
        /// </param>
        /// <param name="wLanguageId">
        /// The language for the text displayed in the message box button(s).
        /// Specifying a value of zero (0) indicates to display the button text in the default system language.
        /// If this parameter is <code>MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL)</code>,
        /// the current language associated with the calling thread is used.
        /// To specify a language other than the current language, use the <see cref="MAKELANGID"/> macro to create this parameter.
        /// For more information, see <see cref="MAKELANGID"/>.
        /// </param>
        /// <returns>
        /// If a message box has a Cancel button, the function returns the <see cref="IDCANCEL"/> value
        /// if either the ESC key is pressed or the Cancel button is selected.
        /// If the message box has no Cancel button, pressing ESC has no effect.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the function succeeds, the return value is one of the following menu-item values.
        /// <see cref="IDABORT"/>: The Abort button was selected.
        /// <see cref="IDCANCEL"/>: The Cancel button was selected.
        /// <see cref="IDCONTINUE"/>: The Continue button was selected.
        /// <see cref="IDIGNORE"/>: The Ignore button was selected.
        /// <see cref="IDNO"/>: The No button was selected.
        /// <see cref="IDOK"/>: The OK button was selected.
        /// <see cref="IDRETRY"/>: The Retry button was selected.
        /// <see cref="IDTRYAGAIN"/>: The Try Again button was selected.
        /// <see cref="IDYES"/>: The Yes button was selected.
        /// </returns>
        /// <remarks>
        /// When you use a system-modal message box to indicate that the system is low on memory,
        /// the strings pointed to by the <paramref name="lpText"/> and <paramref name="lpCaption"/> parameters should not be taken from a resource file
        /// because an attempt to load the resource may fail.
        /// If you create a message box while a dialog box is present, use a handle to the dialog box as the <paramref name="hWnd"/> parameter.
        /// The <paramref name="hWnd"/> parameter should not identify a child window, such as a control in a dialog box.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBoxExW", ExactSpelling = true, SetLastError = true)]
        public static extern int MessageBoxEx([In] HWND hWnd, [In] LPCWSTR lpText, [In] LPCWSTR lpCaption, [In] MessageBoxFlags uType, [In] LANGID wLanguageId);

        /// <summary>
        /// <para>
        /// Creates, displays, and operates a message box.
        /// The message box contains application-defined message text and title, any icon, and any combination of predefined push buttons.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-messageboxindirectw"/>
        /// </para>
        /// </summary>
        /// <param name="lpmbp">
        /// A pointer to a <see cref="MSGBOXPARAMS"/> structure that contains information used to display the message box.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is one of the following menu-item values.
        /// If a message box has a Cancel button, the function returns the <see cref="IDCANCEL"/> value
        /// if either the ESC key is pressed or the Cancel button is selected.
        /// If the message box has no Cancel button, pressing ESC has no effect.
        /// If there is not enough memory to create the message box, the return value is zero.
        /// <see cref="IDABORT"/>: The Abort button was selected.
        /// <see cref="IDCANCEL"/>: The Cancel button was selected.
        /// <see cref="IDCONTINUE"/>: The Continue button was selected.
        /// <see cref="IDIGNORE"/>: The Ignore button was selected.
        /// <see cref="IDNO"/>: The No button was selected.
        /// <see cref="IDOK"/>: The OK button was selected.
        /// <see cref="IDRETRY"/>: The Retry button was selected.
        /// <see cref="IDTRYAGAIN"/>: The Try Again button was selected.
        /// <see cref="IDYES"/>: The Yes button was selected.
        /// </returns>
        /// <remarks>
        /// When you use a system-modal message box to indicate that the system is low on memory,
        /// the strings pointed to by the <see cref="MSGBOXPARAMS.lpszText"/> and <see cref="MSGBOXPARAMS.lpszCaption"/> members
        /// of the <see cref="MSGBOXPARAMS"/> structure should not be taken from a resource file,
        /// because an attempt to load the resource may fail.
        /// If you create a message box while a dialog box is present, use a handle to the dialog box as the <see cref="MSGBOXPARAMS.hwndOwner"/> parameter.
        /// The <see cref="MSGBOXPARAMS.hwndOwner"/> parameter should not identify a child window, such as a control in a dialog box.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBoxIndirectW", ExactSpelling = true, SetLastError = true)]
        public static extern int MessageBoxIndirect([In] in MSGBOXPARAMS lpmbp);

        /// <summary>
        /// <para>
        /// Sends a message to the specified control in a dialog box.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-senddlgitemmessagew"/>
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
        public static extern LRESULT SendDlgItemMessage([In] HWND hDlg, [In] int nIDDlgItem, [In] WindowMessages Msg, [In] WPARAM wParam,
            [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Sets the text of a control in a dialog box to the string representation of a specified integer value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setdlgitemint"/>
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
        public static extern BOOL SetDlgItemInt([In] HWND hDlg, [In] int nIDDlgItem, [In] UINT uValue, [In] BOOL bSigned);

        /// <summary>
        /// <para>
        /// Sets the title or text of a control in a dialog box.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setdlgitemtextw"/>
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
        public static extern BOOL SetDlgItemText([In] HWND hDlg, [In] int nIDDlgItem, [MarshalAs(UnmanagedType.LPWStr)][In] string lpString);
    }
}
