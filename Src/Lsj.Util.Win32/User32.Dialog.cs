using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.INT;
using static Lsj.Util.Win32.BaseTypes.LANGID;
using static Lsj.Util.Win32.BaseTypes.UINT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DialogBoxCommandIDs;
using static Lsj.Util.Win32.Enums.DialogBoxMessages;
using static Lsj.Util.Win32.Enums.DialogBoxStyles;
using static Lsj.Util.Win32.Enums.ExtendedWindowStyles;
using static Lsj.Util.Win32.Enums.GetWindowLongIndexes;
using static Lsj.Util.Win32.Enums.MessageBoxFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// Application-defined callback function used with the <see cref="CreateDialog"/> and <see cref="DialogBox"/> families of functions.
        /// It processes messages sent to a modal or modeless dialog box.
        /// The <see cref="DLGPROC"/> type defines a pointer to this callback function.
        /// <c>DialogProc</c> is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-dlgproc"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// A handle to the dialog box
        /// This parameter is typically named <c>hWnd</c>.
        /// </param>
        /// <param name="unnamedParam2">
        /// The message.
        /// This parameter is typically named <c>uMsg</c>.
        /// </param>
        /// <param name="unnamedParam3">
        /// Additional message-specific information.
        /// This parameter is typically named <c>wParam</c>.
        /// </param>
        /// <param name="unnamedParam4">
        /// Additional message-specific information.
        /// This parameter is typically named <c>lParam</c>.
        /// </param>
        /// <returns>
        /// <para>
        /// Typically, the dialog box procedure should return <see cref="TRUE"/> if it processed the message, and <see cref="FALSE"/> if it did not.
        /// If the dialog box procedure returns <see cref="FALSE"/>, the dialog manager performs the default dialog operation in response to the message.
        /// </para>
        /// <para>
        /// If the dialog box procedure processes a message that requires a specific return value,
        /// the dialog box procedure should set the desired return value
        /// by calling <see cref="SetWindowLong"/>(<c>hwndDlg</c>, <see cref="DWL_MSGRESULT"/>, <c>lResult</c>) immediately before returning <see cref="TRUE"/>.
        /// Note that you must call <see cref="SetWindowLong"/> immediately before returning <see cref="TRUE"/>;
        /// doing so earlier may result in the <see cref="DWL_MSGRESULT"/> value being overwritten by a nested dialog box message.
        /// </para>
        /// <para>
        /// The following messages are exceptions to the general rules stated above.
        /// Consult the documentation for the specific message for details on the semantics of the return value.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="WM_CHARTOITEM"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_COMPAREITEM"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_CTLCOLORBTN"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_CTLCOLORDLG"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_CTLCOLOREDIT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_CTLCOLORLISTBOX"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_CTLCOLORSCROLLBAR"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_CTLCOLORSTATIC"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_INITDIALOG"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_QUERYDRAGICON"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WM_VKEYTOITEM"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The parameters are defined in the header with no names: <c>typedef INT_PTR (CALLBACK* DLGPROC)(HWND, UINT, WPARAM, LPARAM);</c>.
        /// Therefore, the syntax block lists them as <c>unnamedParam1</c> - <c>unnamedParam4</c>.
        /// You can name these parameters anything in your app.
        /// However, they are usually named as shown in the parameter descriptions.
        /// </para>
        /// <para>
        /// You should use the dialog box procedure only if you use the dialog box class for the dialog box.
        /// This is the default class and is used when no explicit class is specified in the dialog box template.
        /// Although the dialog box procedure is similar to a window procedure,
        /// it must not call the <see cref="DefWindowProc"/> function to process unwanted messages.
        /// Unwanted messages are processed internally by the dialog box window procedure.
        /// </para>
        /// </remarks>
        public delegate INT_PTR Dlgproc([In] HWND unnamedParam1, [In] WindowMessages unnamedParam2, [In] WPARAM unnamedParam3, [In] LPARAM unnamedParam4);


        /// <summary>
        /// <para>
        /// Creates a modeless dialog box from a dialog box template resource.
        /// The <see cref="CreateDialog"/> macro uses the <see cref="CreateDialogParam"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createdialogw"/>
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module which contains the dialog box template.
        /// If this parameter is <see cref="NULL"/>, then the current executable is used.
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
        /// A pointer to the dialog box procedure. For more information about the dialog box procedure, see <c>DialogProc</c>.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateDialog"/> function uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="CreateDialog"/> then sends a <see cref="WM_INITDIALOG"/> message
        /// (and a <see cref="WM_SETFONT"/> message if the template specifies the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style)
        /// to the dialog box procedure.
        /// The function displays the dialog box if the template specifies the <see cref="WS_VISIBLE"/> style.
        /// Finally, <see cref="CreateDialog"/> returns the window handle to the dialog box.
        /// </para>
        /// <para>
        /// After <see cref="CreateDialog"/> returns, the application displays the dialog box (if it is not already displayed)
        /// by using the <see cref="ShowWindow"/> function.
        /// The application destroys the dialog box by using the <see cref="DestroyWindow"/> function.
        /// To support keyboard navigation and other dialog box functionality,
        /// the message loop for the dialog box must call the <see cref="IsDialogMessage"/> function.
        /// </para>
        /// </remarks>
        public static HWND CreateDialog(HINSTANCE hInstance, LPCWSTR lpName, HWND hWndParent, DLGPROC lpDialogFunc) =>
            CreateDialogParam(hInstance, lpName, hWndParent, lpDialogFunc, 0);

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
        /// <para>
        /// A template that <see cref="CreateDialogIndirect"/> uses to create the dialog box.
        /// A dialog box template consists of a header that describes the dialog box,
        /// followed by one or more additional blocks of data that describe each of the controls in the dialog box.
        /// The template can use either the standard format or the extended format.
        /// </para>
        /// <para>
        /// In a standard template, the header is a <see cref="DLGTEMPLATE"/> structure followed by additional variable-length arrays.
        /// The data for each control consists of a <see cref="DLGITEMTEMPLATE"/> structure followed by additional variable-length arrays.
        /// </para>
        /// <para>
        /// In an extended dialog box template, the header uses the <see cref="DLGTEMPLATEEX"/> format
        /// and the control definitions use the <see cref="DLGITEMTEMPLATEEX"/> format.
        /// </para>
        /// <para>
        /// After <see cref="CreateDialogIndirect"/> returns, you can free the template, which is only used to get the dialog box started.
        /// </para>
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
        /// <para>
        /// The <see cref="CreateDialogIndirect"/> macro uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="CreateDialogIndirect"/> then sends a <see cref="WM_INITDIALOG"/> message to the dialog box procedure.
        /// If the template specifies the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style,
        /// the function also sends a <see cref="WM_SETFONT"/> message to the dialog box procedure.
        /// The function displays the dialog box if the template specifies the <see cref="WS_VISIBLE"/> style.
        /// Finally, <see cref="CreateDialogIndirect"/> returns the window handle to the dialog box.
        /// </para>
        /// <para>
        /// After <see cref="CreateDialogIndirect"/> returns,
        /// you can use the <see cref="ShowWindow"/> function to display the dialog box (if it is not already visible).
        /// To destroy the dialog box, use the <see cref="DestroyWindow"/> function.
        /// To support keyboard navigation and other dialog box functionality,
        /// the message loop for the dialog box must call the <see cref="IsDialogMessage"/> function.
        /// </para>
        /// <para>
        /// In a standard dialog box template, the <see cref="DLGTEMPLATE"/> structure
        /// and each of the <see cref="DLGITEMTEMPLATE"/> structures must be aligned on <see cref="DWORD"/> boundaries.
        /// The creation data array that follows a <see cref="DLGITEMTEMPLATE"/> structure must also be aligned on a <see cref="DWORD"/> boundary.
        /// All of the other variable-length arrays in the template must be aligned on <see cref="WORD"/> boundaries.
        /// </para>
        /// <para>
        /// In an extended dialog box template, the <see cref="DLGTEMPLATEEX"/> header
        /// and each of the <see cref="DLGITEMTEMPLATEEX"/> control definitions must be aligned on <see cref="DWORD"/> boundaries.
        /// The creation data array, if any, that follows a <see cref="DLGITEMTEMPLATEEX"/> structure must also be aligned on a <see cref="DWORD"/> boundary.
        /// All of the other variable-length arrays in the template must be aligned on <see cref="WORD"/> boundaries.
        /// </para>
        /// <para>
        /// All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.
        /// Use the <see cref="MultiByteToWideChar"/> function to generate Unicode strings from ANSI strings.
        /// </para>
        /// </remarks>
        public static HWND CreateDialogIndirect([In] HINSTANCE hInstance, [In] in DLGTEMPLATE lpTemplate, [In] HWND hWndParent,
            [In] DLGPROC lpDialogFunc) => CreateDialogIndirectParam(hInstance, lpTemplate, hWndParent, lpDialogFunc, NULL);

        /// <summary>
        /// <para>
        /// Creates a modeless dialog box from a dialog box template in memory.
        /// Before displaying the dialog box, the function passes an application-defined value to the dialog box procedure
        /// as the <c>lParam</c> parameter of the <see cref="WM_INITDIALOG"/> message.
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
        /// <para>
        /// The template <see cref="CreateDialogIndirectParam"/> uses to create the dialog box.
        /// A dialog box template consists of a header that describes the dialog box,
        /// followed by one or more additional blocks of data that describe each of the controls in the dialog box.
        /// The template can use either the standard format or the extended format.
        /// </para>
        /// <para>
        /// In a standard template, the header is a <see cref="DLGTEMPLATE"/> structure followed by additional variable-length arrays.
        /// The data for each control consists of a <see cref="DLGITEMTEMPLATE"/> structure followed by additional variable-length arrays.
        /// </para>
        /// <para>
        /// In an extended dialog box template, the header uses the <see cref="DLGTEMPLATEEX"/> format
        /// and the control definitions use the <see cref="DLGITEMTEMPLATEEX"/> format.
        /// </para>
        /// <para>
        /// After <see cref="CreateDialogIndirectParam"/> returns, you can free the template, which is only used to get the dialog box started.
        /// </para>
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the window that owns the dialog box.
        /// </param>
        /// <param name="lpDialogFunc">
        /// A pointer to the dialog box procedure.
        /// For more information about the dialog box procedure, see <c>DialogProc</c>.
        /// </param>
        /// <param name="dwInitParam">
        /// The value to pass to the dialog box in the <c>lParam</c> parameter of the <see cref="WM_INITDIALOG"/> message.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the window handle to the dialog box.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateDialogIndirectParam"/> function uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="CreateDialogIndirectParam"/> then sends a <see cref="WM_INITDIALOG"/> message to the dialog box procedure.
        /// If the template specifies the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style,
        /// the function also sends a <see cref="WM_SETFONT"/> message to the dialog box procedure.
        /// The function displays the dialog box if the template specifies the <see cref="WS_VISIBLE"/> style.
        /// Finally, <see cref="CreateDialogIndirectParam"/> returns the window handle to the dialog box.
        /// </para>
        /// <para>
        /// After <see cref="CreateDialogIndirectParam"/> returns,
        /// you can use the <see cref="ShowWindow"/> function to display the dialog box (if it is not already visible).
        /// To destroy the dialog box, use the <see cref="DestroyWindow"/> function.
        /// To support keyboard navigation and other dialog box functionality,
        /// the message loop for the dialog box must call the <see cref="IsDialogMessage"/> function.
        /// </para>
        /// <para>
        /// In a standard dialog box template, the <see cref="DLGTEMPLATE"/> structure
        /// and each of the <see cref="DLGITEMTEMPLATE"/> structures must be aligned on <see cref="DWORD"/> boundaries.
        /// The creation data array that follows a <see cref="DLGITEMTEMPLATE"/> structure must also be aligned on a <see cref="DWORD"/> boundary.
        /// All of the other variable-length arrays in the template must be aligned on <see cref="WORD"/> boundaries.
        /// </para>
        /// <para>
        /// In an extended dialog box template, the <see cref="DLGTEMPLATEEX"/> header
        /// and each of the <see cref="DLGITEMTEMPLATEEX"/> control definitions must be aligned on <see cref="DWORD"/> boundaries.
        /// The creation data array, if any, that follows a <see cref="DLGITEMTEMPLATEEX"/> structure must also be aligned on a <see cref="DWORD"/> boundary.
        /// All of the other variable-length arrays in the template must be aligned on <see cref="WORD"/> boundaries.
        /// </para>
        /// <para>
        /// All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDialogIndirectParamW", ExactSpelling = true, SetLastError = true)]
        public static extern HWND CreateDialogIndirectParam([In] HINSTANCE hInstance, [In] in DLGTEMPLATE lpTemplate, [In] HWND hWndParent,
            [In] DLGPROC lpDialogFunc, [In] LPARAM dwInitParam);

        /// <summary>
        /// <para>
        /// Creates a modeless dialog box from a dialog box template resource.
        /// Before displaying the dialog box, the function passes an application-defined value to the dialog box procedure
        /// as the <c>lParam</c> parameter of the <see cref="WM_INITDIALOG"/> message.
        /// An application can use this value to initialize dialog box controls.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createdialogparamw"/>
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module which contains the dialog box template.
        /// If this parameter is <see cref="NULL"/>, then the current executable is used.
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
        /// For more information about the dialog box procedure, see <c>DialogProc</c>.
        /// </param>
        /// <param name="dwInitParam">
        /// The value to be passed to the dialog box procedure in the <c>lParam</c> parameter in the <see cref="WM_INITDIALOG"/> message.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the window handle to the dialog box.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateDialogParam"/> function uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="CreateDialogParam"/> then sends a <see cref="WM_INITDIALOG"/> message
        /// (and a <see cref="WM_SETFONT"/> message if the template specifies the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style) to the dialog box procedure.
        /// The function displays the dialog box if the template specifies the <see cref="WS_VISIBLE"/> style.
        /// Finally, <see cref="CreateDialogParam"/> returns the window handle of the dialog box.
        /// </para>
        /// <para>
        /// After <see cref="CreateDialogParam"/> returns, the application displays the dialog box
        /// (if it is not already displayed) using the <see cref="ShowWindow"/> function.
        /// The application destroys the dialog box by using the <see cref="DestroyWindow"/> function.
        /// To support keyboard navigation and other dialog box functionality,
        /// the message loop for the dialog box must call the <see cref="IsDialogMessage"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDialogParamW", ExactSpelling = true, SetLastError = true)]
        public static extern HWND CreateDialogParam([In] HINSTANCE hInstance, [In] LPCWSTR lpTemplateName, [In] HWND hWndParent,
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
        /// <para>
        /// The <see cref="DefDlgProc"/> function is the window procedure for the predefined class of dialog box.
        /// This procedure provides internal processing for the dialog box by forwarding messages to the dialog box procedure
        /// and carrying out default processing for any messages that the dialog box procedure returns as <see cref="FALSE"/>.
        /// Applications that create custom window procedures for their custom dialog boxes often use <see cref="DefDlgProc"/>
        /// instead of the <see cref="DefWindowProc"/> function to carry out default message processing.
        /// </para>
        /// <para>
        /// Applications create custom dialog box classes by filling a <see cref="WNDCLASS"/> structure
        /// with appropriate information and registering the class with the <see cref="RegisterClass"/> function.
        /// Some applications fill the structure by using the <see cref="GetClassInfo"/> function, specifying the name of the predefined dialog box.
        /// In such cases, the applications modify at least the <see cref="WNDCLASS.lpszClassName"/> member before registering.
        /// In all cases, the <see cref="WNDCLASS.cbWndExtra"/> member of <see cref="WNDCLASS"/>
        /// for a custom dialog box class must be set to at least <see cref="DLGWINDOWEXTRA"/>.
        /// </para>
        /// <para>
        /// The <see cref="DefDlgProc"/> function must not be called by a dialog box procedure; doing so results in recursive execution.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DefDlgProcW", ExactSpelling = true, SetLastError = true)]
        public static extern LRESULT DefDlgProc([In] HWND hDlg, [In] WindowMessages Msg, [In] WPARAM wParam, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Creates a modal dialog box from a dialog box template resource.
        /// <see cref="DialogBox"/> does not return control until the specified callback function terminates the modal dialog box
        /// by calling the <see cref="EndDialog"/> function.
        /// </para>
        /// <para>
        /// <see cref="DialogBox"/> is implemented as a call to the <see cref="DialogBoxParam"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dialogboxw"/>
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module which contains the dialog box template.
        /// If this parameter is <see cref="NULL"/>, then the current executable is used.
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
        /// A pointer to the dialog box procedure. For more information about the dialog box procedure, see <c>DialogProc</c>.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// <para>
        /// The <see cref="DialogBox"/> macro uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="DialogBox"/> then sends a <see cref="WM_INITDIALOG"/> message
        /// (and a <see cref="WM_SETFONT"/> message if the template specifies the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style) to the dialog box procedure.
        /// The function displays the dialog box (regardless of whether the template specifies the <see cref="WS_VISIBLE"/> style),
        /// disables the owner window, and starts its own message loop to retrieve and dispatch messages for the dialog box.
        /// </para>
        /// <para>
        /// When the dialog box procedure calls the <see cref="EndDialog"/> function,
        /// <see cref="DialogBox"/> destroys the dialog box, ends the message loop, enables the owner window (if previously enabled),
        /// and returns the <c>nResult</c> parameter specified by the dialog box procedure when it called <see cref="EndDialog"/>.
        /// </para>
        /// </remarks>
        public static INT_PTR DialogBox(HINSTANCE hInstance, LPCWSTR lpTemplate, HWND hWndParent, DLGPROC lpDialogFunc) =>
            DialogBoxParam(hInstance, lpTemplate, hWndParent, lpDialogFunc, NULL);

        /// <summary>
        /// <para>
        /// Creates a modal dialog box from a dialog box template in memory.
        /// <see cref="DialogBoxIndirect"/> does not return control until the specified callback function
        /// terminates the modal dialog box by calling the <see cref="EndDialog"/> function.
        /// </para>
        /// <para>
        /// <see cref="DialogBoxIndirect"/> is implemented as a call to the <see cref="DialogBoxIndirectParam"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dialogboxindirectw"/>
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module which contains the dialog box template.
        /// If this parameter is <see cref="NULL"/>, then the current executable is used.
        /// </param>
        /// <param name="lpTemplate">
        /// <para>
        /// The template that <see cref="DialogBoxIndirect"/> uses to create the dialog box.
        /// A dialog box template consists of a header that describes the dialog box,
        /// followed by one or more additional blocks of data that describe each of the controls in the dialog box.
        /// The template can use either the standard format or the extended format.
        /// </para>
        /// <para>
        /// In a standard template for a dialog box, the header is a <see cref="DLGTEMPLATE"/> structure followed by additional variable-length arrays.
        /// The data for each control consists of a <see cref="DLGITEMTEMPLATE"/> structure followed by additional variable-length arrays.
        /// </para>
        /// <para>
        /// In an extended template for a dialog box,
        /// the header uses the <see cref="DLGTEMPLATEEX"/> format and the control definitions use the <see cref="DLGITEMTEMPLATEEX"/> format.
        /// </para>
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the window that owns the dialog box.
        /// </param>
        /// <param name="lpDialogFunc">
        /// A pointer to the dialog box procedure.
        /// For more information about the dialog box procedure, see <c>DialogProc</c>.
        /// </param>
        /// <remarks>
        /// <para>
        /// The <see cref="DialogBoxIndirect"/> macro uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="DialogBoxIndirect"/> then sends a <see cref="WM_INITDIALOG"/> message to the dialog box procedure.
        /// If the template specifies the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style,
        /// the function also sends a <see cref="WM_SETFONT"/> message to the dialog box procedure.
        /// The function displays the dialog box (regardless of whether the template specifies the <see cref="WS_VISIBLE"/> style),
        /// disables the owner window, and starts its own message loop to retrieve and dispatch messages for the dialog box.
        /// </para>
        /// <para>
        /// When the dialog box procedure calls the <see cref="EndDialog"/> function,
        /// <see cref="DialogBoxIndirect"/> destroys the dialog box, ends the message loop, enables the owner window (if previously enabled),
        /// and returns the <c>nResult</c> parameter specified by the dialog box procedure when it called <see cref="EndDialog"/>.
        /// </para>
        /// <para>
        /// In a standard dialog box template, the <see cref="DLGTEMPLATE"/> structure
        /// and each of the <see cref="DLGITEMTEMPLATE"/> structures must be aligned on <see cref="DWORD"/> boundaries.
        /// The creation data array that follows a <see cref="DLGITEMTEMPLATE"/> structure must also be aligned on a <see cref="DWORD"/> boundary.
        /// All of the other variable-length arrays in the template must be aligned on <see cref="WORD"/> boundaries.
        /// </para>
        /// <para>
        /// In an extended dialog box template, the <see cref="DLGTEMPLATEEX"/> header
        /// and each of the <see cref="DLGITEMTEMPLATEEX"/> control definitions must be aligned on <see cref="DWORD"/> boundaries.
        /// The creation data array, if any, that follows a <see cref="DLGITEMTEMPLATEEX"/> structure must also be aligned on a <see cref="DWORD"/> boundary.
        /// All of the other variable-length arrays in the template must be aligned on <see cref="WORD"/> boundaries.
        /// </para>
        /// <para>
        /// All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.
        /// Use the <see cref="MultiByteToWideChar"/> function to generate Unicode strings from ANSI strings.
        /// </para>
        /// </remarks>
        public static INT_PTR DialogBoxIndirect(HINSTANCE hInstance, in DLGTEMPLATE lpTemplate, HWND hWndParent, DLGPROC lpDialogFunc) =>
            DialogBoxIndirectParam(hInstance, lpTemplate, hWndParent, lpDialogFunc, NULL);

        /// <summary>
        /// <para>
        /// Creates a modal dialog box from a dialog box template in memory.
        /// Before displaying the dialog box, the function passes an application-defined value to the dialog box procedure
        /// as the <c>lParam</c> parameter of the <see cref="WM_INITDIALOG"/> message.
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
        /// <para>
        /// The template that <see cref="DialogBoxIndirectParam"/> uses to create the dialog box.
        /// A dialog box template consists of a header that describes the dialog box,
        /// followed by one or more additional blocks of data that describe each of the controls in the dialog box.
        /// The template can use either the standard format or the extended format.
        /// </para>
        /// <para>
        /// In a standard template for a dialog box, the header is a <see cref="DLGTEMPLATE"/> structure followed by additional variable-length arrays.
        /// The data for each control consists of a <see cref="DLGITEMTEMPLATE"/> structure followed by additional variable-length arrays.
        /// </para>
        /// <para>
        /// In an extended template for a dialog box,
        /// the header uses the <see cref="DLGTEMPLATEEX"/> format and the control definitions use the <see cref="DLGITEMTEMPLATEEX"/> format.
        /// </para>
        /// </param>
        /// <param name="hWndParent">
        /// A handle to the window that owns the dialog box.
        /// </param>
        /// <param name="lpDialogFunc">
        /// A pointer to the dialog box procedure.
        /// For more information about the dialog box procedure, see <c>DialogProc</c>.
        /// </param>
        /// <param name="dwInitParam">
        /// The value to pass to the dialog box in the <c>lParam</c> parameter of the <see cref="WM_INITDIALOG"/> message.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the <c>nResult</c> parameter specified in the call
        /// to the <see cref="EndDialog"/> function that was used to terminate the dialog box.
        /// </para>
        /// <para>
        /// If the function fails because the <paramref name="hWndParent"/> parameter is invalid, the return value is zero.
        /// The function returns zero in this case for compatibility with previous versions of Windows.
        /// If the function fails for any other reason, the return value is –1.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="DialogBoxIndirectParam"/> function uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="DialogBoxIndirectParam"/> then sends a <see cref="WM_INITDIALOG"/> message to the dialog box procedure.
        /// If the template specifies the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style,
        /// the function also sends a <see cref="WM_SETFONT"/> message to the dialog box procedure.
        /// The function displays the dialog box (regardless of whether the template specifies the <see cref="WS_VISIBLE"/> style),
        /// disables the owner window, and starts its own message loop to retrieve and dispatch messages for the dialog box.
        /// </para>
        /// <para>
        /// When the dialog box procedure calls the <see cref="EndDialog"/> function,
        /// <see cref="DialogBoxIndirectParam"/> destroys the dialog box, ends the message loop, enables the owner window (if previously enabled),
        /// and returns the <c>nResult</c> parameter specified by the dialog box procedure when it called <see cref="EndDialog"/>.
        /// </para>
        /// <para>
        /// In a standard dialog box template, the <see cref="DLGTEMPLATE"/> structure
        /// and each of the <see cref="DLGITEMTEMPLATE"/> structures must be aligned on <see cref="DWORD"/> boundaries.
        /// The creation data array that follows a <see cref="DLGITEMTEMPLATE"/> structure must also be aligned on a <see cref="DWORD"/> boundary.
        /// All of the other variable-length arrays in the template must be aligned on <see cref="WORD"/> boundaries.
        /// </para>
        /// <para>
        /// In an extended dialog box template, the <see cref="DLGTEMPLATEEX"/> header
        /// and each of the <see cref="DLGITEMTEMPLATEEX"/> control definitions must be aligned on <see cref="DWORD"/> boundaries.
        /// The creation data array, if any, that follows a <see cref="DLGITEMTEMPLATEEX"/> structure must also be aligned on a <see cref="DWORD"/> boundary.
        /// All of the other variable-length arrays in the template must be aligned on <see cref="WORD"/> boundaries.
        /// </para>
        /// <para>
        /// All character strings in the dialog box template, such as titles for the dialog box and buttons, must be Unicode strings.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DialogBoxIndirectParamW", ExactSpelling = true, SetLastError = true)]
        public static extern INT_PTR DialogBoxIndirectParam([In] HINSTANCE hInstance, [In] in DLGTEMPLATE lpTemplateName, [In] HWND hWndParent,
            [In] DLGPROC lpDialogFunc, [In] LPARAM dwInitParam);

        /// <summary>
        /// <para>
        /// Creates a modal dialog box from a dialog box template resource.
        /// Before displaying the dialog box, the function passes an application-defined value to the dialog box procedure
        /// as the <c>lParam</c> parameter of the <see cref="WM_INITDIALOG"/> message.
        /// An application can use this value to initialize dialog box controls.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-dialogboxparamw"/>
        /// </para>
        /// </summary>
        /// <param name="hInstance">
        /// A handle to the module which contains the dialog box template.
        /// If this parameter is <see cref="NULL"/>, then the current executable is used.
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
        /// A pointer to the dialog box procedure. For more information about the dialog box procedure, see <c>DialogProc</c>.
        /// </param>
        /// <param name="dwInitParam">
        /// The value to pass to the dialog box in the <c>lParam</c> parameter of the <see cref="WM_INITDIALOG"/> message.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the value of the <c>nResult</c> parameter specified
        /// in the call to the <see cref="EndDialog"/> function used to terminate the dialog box.
        /// </para>
        /// <para>
        /// If the function fails because the <paramref name="hWndParent"/> parameter is invalid, the return value is zero.
        /// The function returns zero in this case for compatibility with previous versions of Windows.
        /// If the function fails for any other reason, the return value is –1.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="DialogBoxParam"/> function uses the <see cref="CreateWindowEx"/> function to create the dialog box.
        /// <see cref="DialogBoxParam"/> then sends a <see cref="WM_INITDIALOG"/> message
        /// (and a <see cref="WM_SETFONT"/> message if the template specifies the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style) to the dialog box procedure.
        /// The function displays the dialog box (regardless of whether the template specifies the <see cref="WS_VISIBLE"/> style),
        /// disables the owner window, and starts its own message loop to retrieve and dispatch messages for the dialog box.
        /// </para>
        /// <para>
        /// When the dialog box procedure calls the <see cref="EndDialog"/> function,
        /// <see cref="DialogBoxParam"/> destroys the dialog box, ends the message loop, enables the owner window (if previously enabled),
        /// and returns the <c>nResult</c> parameter specified by the dialog box procedure when it called <see cref="EndDialog"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DialogBoxParamW", ExactSpelling = true, SetLastError = true)]
        public static extern INT_PTR DialogBoxParam([In] HINSTANCE hInstance, [In] LPCWSTR lpTemplateName, [In] HWND hWndParent,
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Dialog boxes created by the <see cref="DialogBox"/>, <see cref="DialogBoxParam"/>, <see cref="DialogBoxIndirect"/>,
        /// and <see cref="DialogBoxIndirectParam"/> functions must be destroyed using the <see cref="EndDialog"/> function.
        /// An application calls <see cref="EndDialog"/> from within the dialog box procedure; the function must not be used for any other purpose.
        /// </para>
        /// <para>
        /// A dialog box procedure can call <see cref="EndDialog"/> at any time, even during the processing of the <see cref="WM_INITDIALOG"/> message.
        /// If your application calls the function while <see cref="WM_INITDIALOG"/> is being processed,
        /// the dialog box is destroyed before it is shown and before the input focus is set.
        /// </para>
        /// <para>
        /// <see cref="EndDialog"/> does not destroy the dialog box immediately.
        /// Instead, it sets a flag and allows the dialog box procedure to return control to the system.
        /// The system checks the flag before attempting to retrieve the next message from the application queue.
        /// If the flag is set, the system ends the message loop, destroys the dialog box,
        /// and uses the value in <paramref name="nResult"/> as the return value from the function that created the dialog box.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndDialog", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EndDialog([In] HWND hDlg, [In] INT_PTR nResult);

        /// <summary>
        /// <para>
        /// Retrieves the system's dialog base units, which are the average width and height of characters in the system font.
        /// For dialog boxes that use the system font, you can use these values to convert between dialog template units,
        /// as specified in dialog box templates, and pixels.
        /// For dialog boxes that do not use the system font, the conversion from dialog template units to pixels depends on the font used by the dialog box.
        /// </para>
        /// <para>
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
        /// <para>
        /// The horizontal base unit returned by <see cref="GetDialogBaseUnits"/> is equal to the average width, in pixels, of the characters in the system font;
        /// the vertical base unit is equal to the height, in pixels, of the font.
        /// </para>
        /// <para>
        /// The system font is used only if the dialog box template fails to specify a font.
        /// Most dialog box templates specify a font; as a result, this function is not useful for most dialog boxes.
        /// </para>
        /// <para>
        /// For a dialog box that does not use the system font, the base units are the average width and height, in pixels, of the characters in the dialog's font.
        /// You can use the <see cref="GetTextMetrics"/> and <see cref="GetTextExtentPoint32"/> functions to calculate these values for a selected font.
        /// However, by using the <see cref="MapDialogRect"/> function,
        /// you can avoid errors that might result if your calculations differ from those performed by the system.
        /// </para>
        /// <para>
        /// Each horizontal base unit is equal to 4 horizontal dialog template units; each vertical base unit is equal to 8 vertical dialog template units.
        /// Therefore, to convert dialog template units to pixels, use the following formulas:
        /// </para>
        /// <code>
        /// pixelX = MulDiv(templateunitX, baseunitX, 4);
        /// pixelY = MulDiv(templateunitY, baseunitY, 8);
        /// </code>
        /// <para>
        /// Similarly, to convert from pixels to dialog template units, use the following formulas:
        /// </para>
        /// <code>
        /// templateunitX = MulDiv(pixelX, 4, baseunitX);
        /// templateunitY = MulDiv(pixelY, 8, baseunitY);
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// If the function succeeds, the return value is the identifier of the control.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// An invalid value for the <paramref name="hWnd"/> parameter, for example, will cause the function to fail.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetDlgCtrlID"/> accepts child window handles as well as handles of controls in dialog boxes.
        /// An application sets the identifier for a child window when it creates the window
        /// by assigning the identifier value to the <c>hmenu</c> parameter when calling the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function.
        /// </para>
        /// <para>
        /// Although <see cref="GetDlgCtrlID"/> may return a value if <paramref name="hWnd"/> is a handle to a top-level window,
        /// top-level windows cannot have identifiers and such a return value is never valid.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// If the function succeeds, the return value is the window handle of the specified control.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>, indicating an invalid dialog box handle or a nonexistent control.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// You can use the <see cref="GetDlgItem"/> function with any parent-child window pair, not just with dialog boxes.
        /// As long as the <paramref name="hDlg"/> parameter specifies a parent window and the child window has a unique identifier
        /// (as specified by the hMenu parameter in the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function that created the child window),
        /// <see cref="GetDlgItem"/> returns a valid handle to the child window.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// Indicates success or failure (<see cref="TRUE"/> indicates success, <see cref="FALSE"/> indicates failure).
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the function returns no information about success or failure.
        /// </para>
        /// </param>
        /// <param name="bSigned">
        /// Indicates whether the function should examine the text for a minus sign at the beginning and return a signed integer value if it finds one
        /// (<see cref="TRUE"/> specifies this should be done, <see cref="FALSE"/> that it should not).
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the variable pointed to by <paramref name="lpTranslated"/> is set to <see cref="TRUE"/>,
        /// and the return value is the translated value of the control text.
        /// </para>
        /// <para>
        /// If the function fails, the variable pointed to by <paramref name="lpTranslated"/> is set to <see cref="FALSE"/>, and the return value is zero.
        /// Note that, because zero is a possible translated value, a return value of zero does not by itself indicate failure.
        /// </para>
        /// <para>
        /// If <paramref name="lpTranslated"/> is <see cref="NULL"/>, the function returns no information about success or failure.
        /// </para>
        /// <para>
        /// Note that, if the <paramref name="bSigned"/> parameter is <see cref="TRUE"/> and there is a minus sign (–) at the beginning of the text,
        /// <see cref="GetDlgItemInt"/> translates the text into a signed integer value. Otherwise, the function creates an unsigned integer value.
        /// To obtain the proper value in this case, cast the return value to an <see langword="int"/> type.
        /// </para>
        /// <para>
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetDlgItemInt"/> function retrieves the text of the specified control by sending the control a <see cref="WM_GETTEXT"/> message.
        /// The function translates the retrieved text by stripping any extra spaces at the beginning of the text and then converting the decimal digits.
        /// The function stops translating when it reaches the end of the text or encounters a nonnumeric character.
        /// </para>
        /// <para>
        /// The <see cref="GetDlgItemInt"/> function returns zero if the translated value
        /// is greater than <see cref="INT_MAX"/> (for signed numbers) or <see cref="UINT_MAX"/> (for unsigned numbers).
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// If the function succeeds, the return value specifies the number of characters copied to the buffer, not including the terminating null character.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the string is as long or longer than the buffer, the buffer will contain the truncated string with a terminating null character.
        /// </para>
        /// <para>
        /// The <see cref="GetDlgItemText"/> function sends a <see cref="WM_GETTEXT"/> message to the control.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDlgItemTextW", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetDlgItemText([In] HWND hDlg, [In] int nIDDlgItem, [In] LPWSTR lpString, [In] int cchMax);

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
        /// <para>
        /// If the function succeeds, the return value is a handle to the previous (or next) control in the group of controls.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetNextDlgGroupItem"/> function searches controls in the order (or reverse order) they were created in the dialog box template.
        /// The first control in the group must have the <see cref="WS_GROUP"/> style;
        /// all other controls in the group must have been consecutively created and must not have the <see cref="WS_GROUP"/> style.
        /// </para>
        /// <para>
        /// When searching for the previous control, the function returns the first control it locates that is visible and not disabled.
        /// If the control specified by <paramref name="hCtl"/> has the <see cref="WS_GROUP"/> style,
        /// the function temporarily reverses the search to locate the first control having the <see cref="WS_GROUP"/> style,
        /// then resumes the search in the original direction, returning the first control it locates that is visible and not disabled,
        /// or returning <paramref name="hCtl"/> if no such control is found.
        /// </para>
        /// <para>
        /// When searching for the next control, the function returns the first control it locates
        /// that is visible, not disabled, and does not have the <see cref="WS_GROUP"/> style.
        /// If it encounters a control having the <see cref="WS_GROUP"/> style, the function reverses the search,
        /// locates the first control having the <see cref="WS_GROUP"/> style, and returns this control if it is visible and not disabled.
        /// Otherwise, the function resumes the search in the original direction and returns the first control it locates
        /// that is visible and not disabled, or returns <paramref name="hCtl"/> if no such control is found.
        /// </para>
        /// <para>
        /// If the search for the next control in the group encounters a window with the <see cref="WS_EX_CONTROLPARENT"/> style,
        /// the system recursively searches the window's children.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// If the function succeeds, the return value is the window handle of the previous (or next) control that has the <see cref="WS_TABSTOP"/> style set.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetNextDlgTabItem"/> function searches controls in the order (or reverse order) they were created in the dialog box template.
        /// The function returns the first control it locates that is visible, not disabled, and has the <see cref="WS_TABSTOP"/> style.
        /// If no such control exists, the function returns <paramref name="hCtl"/>.
        /// </para>
        /// <para>
        /// If the search for the next control with the <see cref="WS_TABSTOP"/> style encounters a window
        /// with the <see cref="WS_EX_CONTROLPARENT"/> style, the system recursively searches the window's children.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// If the message has been processed, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the message has not been processed, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Although the <see cref="IsDialogMessage"/> function is intended for modeless dialog boxes,
        /// you can use it with any window that contains controls, enabling the windows to provide the same keyboard selection as is used in a dialog box.
        /// </para>
        /// <para>
        /// When <see cref="IsDialogMessage"/> processes a message,
        /// it checks for keyboard messages and converts them into selections for the corresponding dialog box.
        /// For example, the TAB key, when pressed, selects the next control or group of controls,
        /// and the DOWN ARROW key, when pressed, selects the next control in a group.
        /// </para>
        /// <para>
        /// Because the <see cref="IsDialogMessage"/> function performs all necessary translating and dispatching of messages,
        /// a message processed by <see cref="IsDialogMessage"/> must not be passed to the <see cref="TranslateMessage"/> or <see cref="DispatchMessage"/> function.
        /// </para>
        /// <para>
        /// <see cref="IsDialogMessage"/> sends <see cref="WM_GETDLGCODE"/> messages to the dialog box procedure to determine which keys should be processed.
        /// </para>
        /// <para>
        /// <see cref="IsDialogMessage"/> can send <see cref="DM_GETDEFID"/> and <see cref="DM_SETDEFID"/> messages to the window.
        /// These messages are defined in the Winuser.h header file as <see cref="WM_USER"/> and <see cref="WM_USER"/> + 1,
        /// so conflicts are possible with application-defined messages having the same values.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsDialogMessageW", ExactSpelling = true)]
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="MapDialogRect"/> function assumes that the initial coordinates in the <see cref="RECT"/> structure represent dialog box units.
        /// To convert these coordinates from dialog box units to pixels, the function retrieves the current horizontal
        /// and vertical base units for the dialog box, then applies the following formulas:
        /// </para>
        /// <code>
        /// left   = MulDiv(left,   baseunitX, 4);
        /// right  = MulDiv(right,  baseunitX, 4);
        /// top    = MulDiv(top,    baseunitY, 8);
        /// bottom = MulDiv(bottom, baseunitY, 8);
        /// </code>
        /// <para>
        /// If the dialog box template has the <see cref="DS_SETFONT"/> or <see cref="DS_SHELLFONT"/> style,
        /// the base units are the average width and height, in pixels, of the characters in the font specified by the template.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapDialogRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MapDialogRect([In] HWND hDlg, [In][Out] ref RECT lpRect);

        /// <summary>
        /// <para>
        /// Returns strings for standard message box buttons.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dlgbox/mb-getstring"/>
        /// </para>
        /// </summary>
        /// <param name="wBtn">
        /// The id of the string to return.
        /// These are identified by the Dialog Box Command ID values listed in winuser.h.
        /// </param>
        /// <returns>
        /// The string, or <see cref="NULL"/> if not found.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MB_GetString", ExactSpelling = true)]
        public static extern nint MB_GetString([In] UINT wBtn);

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
        /// If this parameter is <see cref="NULL"/>, the default title is <c>Error</c>.
        /// </param>
        /// <param name="uType">
        /// <para>
        /// The contents and behavior of the dialog box.
        /// This parameter can be a combination of flags from the following groups of flags.
        /// </para>
        /// <para>
        /// To indicate the buttons displayed in the message box, specify one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_ABORTRETRYIGNORE"/>
        /// </para>
        /// <para>
        /// 0x00000002L
        /// </para>
        /// </term>
        /// <term>
        /// The message box contains three push buttons: <c>Abort</c>, <c>Retry</c>, and <c>Ignore</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_CANCELTRYCONTINUE"/>
        /// </para>
        /// <para>
        /// 0x00000006L
        /// </para>
        /// </term>
        /// <term>
        /// The message box contains three push buttons: <c>Cancel</c>, Try Again, <c>Continue</c>.
        /// Use this message box type instead of <see cref="MB_ABORTRETRYIGNORE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_HELP"/>
        /// </para>
        /// <para>
        /// 0x00004000L
        /// </para>
        /// </term>
        /// <term>
        /// Adds a <c>Help</c> button to the message box.
        /// When the user clicks the <c>Help</c> button or presses F1, the system sends a <see cref="WM_HELP"/> message to the owner.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_OK"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// The message box contains one push button: <c>OK</c>.
        /// This is the default.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_OKCANCEL"/>
        /// </para>
        /// <para>
        /// 0x00000001L
        /// </para>
        /// </term>
        /// <term>
        /// The message box contains two push buttons: <c>OK</c> and <c>Cancel</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_RETRYCANCEL"/>
        /// </para>
        /// <para>
        /// 0x00000005L
        /// </para>
        /// </term>
        /// <term>
        /// The message box contains two push buttons: <c>Retry</c> and <c>Cancel</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_YESNO"/>
        /// </para>
        /// <para>
        /// 0x00000004L
        /// </para>
        /// </term>
        /// <term>
        /// The message box contains two push buttons: <c>Yes</c> and <c>No</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_YESNOCANCEL"/>
        /// </para>
        /// <para>
        /// 0x00000003L
        /// </para>
        /// </term>
        /// <term>
        /// The message box contains three push buttons: <c>Yes</c>, <c>No</c>, and <c>Cancel</c>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To display an icon in the message box, specify one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_ICONEXCLAMATION"/>
        /// </para>
        /// <para>
        /// 0x00000030L
        /// </para>
        /// </term>
        /// <term>
        /// An exclamation-point icon appears in the message box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_ICONWARNING"/>
        /// </para>
        /// <para>
        /// 0x00000030L
        /// </para>
        /// </term>
        /// <term>
        /// An exclamation-point icon appears in the message box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_ICONINFORMATION"/>
        /// </para>
        /// <para>
        /// 0x00000040L
        /// </para>
        /// </term>
        /// <term>
        /// An icon consisting of a lowercase letter <c>i</c> in a circle appears in the message box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_ICONASTERISK"/>
        /// </para>
        /// <para>
        /// 0x00000040L
        /// </para>
        /// </term>
        /// <term>
        /// An icon consisting of a lowercase letter <c>i</c> in a circle appears in the message box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_ICONQUESTION"/>
        /// </para>
        /// <para>
        /// 0x00000020L
        /// </para>
        /// </term>
        /// <term>
        /// A question-mark icon appears in the message box.
        /// The question-mark message icon is no longer recommended because it does not clearly represent a specific type of message
        /// and because the phrasing of a message as a question could apply to any message type.
        /// In addition, users can confuse the message symbol question mark with Help information.
        /// Therefore, do not use this question mark message symbol in your message boxes.
        /// The system continues to support its inclusion only for backward compatibility.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_ICONSTOP"/>
        /// </para>
        /// <para>
        /// 0x00000010L
        /// </para>
        /// </term>
        /// <term>
        /// A stop-sign icon appears in the message box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_ICONERROR"/>
        /// </para>
        /// <para>
        /// 0x00000010L
        /// </para>
        /// </term>
        /// <term>
        /// A stop-sign icon appears in the message box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_ICONHAND"/>
        /// </para>
        /// <para>
        /// 0x00000010L
        /// </para>
        /// </term>
        /// <term>
        /// A stop-sign icon appears in the message box.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To indicate the default button, specify one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_DEFBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The first button is the default button.
        /// </para>
        /// <para>
        /// <see cref="MB_DEFBUTTON1"/> is the default unless <see cref="MB_DEFBUTTON2"/>,
        /// <see cref="MB_DEFBUTTON3"/>, or <see cref="MB_DEFBUTTON4"/> is specified.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_DEFBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x00000100L
        /// </para>
        /// </term>
        /// <term>
        /// The second button is the default button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_DEFBUTTON3"/>
        /// </para>
        /// <para>
        /// 0x00000200L
        /// </para>
        /// </term>
        /// <term>
        /// The third button is the default button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_DEFBUTTON4"/>
        /// </para>
        /// <para>
        /// 0x00000300L
        /// </para>
        /// </term>
        /// <term>
        /// The fourth button is the default button.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To indicate the modality of the dialog box, specify one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_APPLMODAL"/>
        /// </para>
        /// <para>
        /// 0x00000000L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The user must respond to the message box before continuing work in the window identified by the <paramref name="hWnd"/> parameter.
        /// However, the user can move to the windows of other threads and work in those windows.
        /// </para>
        /// <para>
        /// Depending on the hierarchy of windows in the application, the user may be able to move to other windows within the thread.
        /// All child windows of the parent of the message box are automatically disabled, but pop-up windows are not.
        /// </para>
        /// <para>
        /// <see cref="MB_APPLMODAL"/> is the default if neither <see cref="MB_SYSTEMMODAL"/> nor <see cref="MB_TASKMODAL"/> is specified.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_SYSTEMMODAL"/>
        /// </para>
        /// <para>
        /// 0x00001000L
        /// </para>
        /// </term>
        /// <term>
        /// Same as <see cref="MB_APPLMODAL"/> except that the message box has the <see cref="WS_EX_TOPMOST"/> style.
        /// Use system-modal message boxes to notify the user of serious,
        /// potentially damaging errors that require immediate attention (for example, running out of memory).
        /// This flag has no effect on the user's ability to interact with windows other than those associated with <paramref name="hWnd"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_TASKMODAL"/>
        /// </para>
        /// <para>
        /// 0x00002000L
        /// </para>
        /// </term>
        /// <term>
        /// Same as <see cref="MB_APPLMODAL"/> except that all the top-level windows belonging to the current thread are disabled
        /// if the <paramref name="hWnd"/> parameter is <see cref="NULL"/>.
        /// Use this flag when the calling application or library does not have a window handle available
        /// but still needs to prevent input to other windows in the calling thread without suspending other threads.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// To specify other options, use one or more of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_DEFAULT_DESKTOP_ONLY"/>
        /// </para>
        /// <para>
        /// 0x00020000L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Same as desktop of the interactive window station.
        /// For more information, see Window Stations.
        /// </para>
        /// <para>
        /// If the current input desktop is not the default desktop,
        /// <see cref="MessageBox"/> does not return until the user switches to the default desktop.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_RIGHT"/>
        /// </para>
        /// <para>
        /// 0x00080000L
        /// </para>
        /// </term>
        /// <term>
        /// The text is right-justified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_RTLREADING"/>
        /// </para>
        /// <para>
        /// 0x00100000L
        /// </para>
        /// </term>
        /// <term>
        /// Displays message and caption text using right-to-left reading order on Hebrew and Arabic systems.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_SETFOREGROUND"/>
        /// </para>
        /// <para>
        /// 0x00010000L
        /// </para>
        /// </term>
        /// <term>
        /// The message box becomes the foreground window.
        /// Internally, the system calls the <see cref="SetForegroundWindow"/> function for the message box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_TOPMOST"/>
        /// </para>
        /// <para>
        /// 0x00040000L
        /// </para>
        /// </term>
        /// <term>
        /// The message box is created with the <see cref="WS_EX_TOPMOST"/> window style.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MB_SERVICE_NOTIFICATION"/>
        /// </para>
        /// <para>
        /// 0x00200000L
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The caller is a service notifying the user of an event.
        /// The function displays a message box on the current active desktop, even if there is no user logged on to the computer.
        /// </para>
        /// <para>
        /// Terminal Services: If the calling thread has an impersonation token,
        /// the function directs the message box to the session specified in the impersonation token.
        /// </para>
        /// <para>
        /// If this flag is set, the <paramref name="hWnd"/> parameter must be <see cref="NULL"/>.
        /// This is so that the message box can appear on a desktop other than the desktop corresponding to the <paramref name="hWnd"/>.
        /// </para>
        /// <para>
        /// For information on security considerations in regard to using this flag, see Interactive Services.
        /// In particular, be aware that this flag can produce interactive content on a locked desktop
        /// and should therefore be used for only a very limited set of scenarios, such as resource exhaustion.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If a message box has a <c>Cancel</c> button, the function returns the <see cref="IDCANCEL"/> value
        /// if either the ESC key is pressed or the <c>Cancel</c> button is selected.
        /// If the message box has no <c>Cancel</c> button, pressing ESC will no effect - unless an <see cref="MB_OK"/> button is present.
        /// If an <see cref="MB_OK"/> button is displayed and the user presses ESC, the return value will be <see cref="IDOK"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If the function succeeds, the return value is one of the following menu-item values.
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
        /// <see cref="IDABORT"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Abort</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDCANCEL"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Cancel</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDCONTINUE"/>
        /// </para>
        /// <para>
        /// 11
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Continue</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDIGNORE"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Ignore</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDNO"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// The <c>No</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDOK"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The <c>OK</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDRETRY"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Retry</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDTRYAGAIN"/>
        /// </para>
        /// <para>
        /// 10
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Try Again</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDYES"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Yes</c> button was selected.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Adding two right-to-left marks (RLMs), represented by Unicode formatting character U+200F,
        /// in the beginning of a MessageBox display string is interpreted by the MessageBox rendering engine
        /// so as to cause the reading order of the MessageBox to be rendered as right-to-left (RTL).
        /// </para>
        /// <para>
        /// When you use a system-modal message box to indicate that the system is low on memory,
        /// the strings pointed to by the <paramref name="lpText"/> and <paramref name="lpCaption"/> parameters
        /// should not be taken from a resource file because an attempt to load the resource may fail.
        /// </para>
        /// <para>
        /// If you create a message box while a dialog box is present, use a handle to the dialog box as the <paramref name="hWnd"/> parameter.
        /// The <paramref name="hWnd"/> parameter should not identify a child window, such as a control in a dialog box.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBoxW", ExactSpelling = true, SetLastError = true)]
        public static extern int MessageBox([In] HWND hWnd, [In] LPCWSTR lpText, [In] LPCWSTR lpCaption, [In] MessageBoxFlags uType);

        /// <summary>
        /// <para>
        /// Creates, displays, and operates a message box.
        /// The message box contains an application-defined message and title, plus any combination of predefined icons and push buttons.
        /// The buttons are in the language of the system user interface.
        /// </para>
        /// <para>
        /// Currently <see cref="MessageBoxEx"/> and <see cref="MessageBox"/> work the same way.
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
        /// <para>
        /// The language for the text displayed in the message box button(s).
        /// Specifying a value of zero (0) indicates to display the button text in the default system language.
        /// If this parameter is <c>MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL)</c>, the current language associated with the calling thread is used.
        /// </para>
        /// <para>
        /// To specify a language other than the current language, use the <see cref="MAKELANGID"/> macro to create this parameter.
        /// For more information, see <see cref="MAKELANGID"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If a message box has a <c>Cancel</c> button, the function returns the <see cref="IDCANCEL"/> value
        /// if either the ESC key is pressed or the <c>Cancel</c> button is selected.
        /// If the message box has no <c>Cancel</c> button, pressing ESC will no effect - unless an <see cref="MB_OK"/> button is present.
        /// If an <see cref="MB_OK"/> button is displayed and the user presses ESC, the return value will be <see cref="IDOK"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// If the function succeeds, the return value is one of the following menu-item values.
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
        /// <see cref="IDABORT"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Abort</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDCANCEL"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Cancel</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDCONTINUE"/>
        /// </para>
        /// <para>
        /// 11
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Continue</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDIGNORE"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Ignore</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDNO"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// The <c>No</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDOK"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The <c>OK</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDRETRY"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Retry</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDTRYAGAIN"/>
        /// </para>
        /// <para>
        /// 10
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Try Again</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDYES"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Yes</c> button was selected.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you use a system-modal message box to indicate that the system is low on memory,
        /// the strings pointed to by the <paramref name="lpText"/> and <paramref name="lpCaption"/> parameters
        /// should not be taken from a resource file because an attempt to load the resource may fail.
        /// </para>
        /// <para>
        /// If you create a message box while a dialog box is present, use a handle to the dialog box as the <paramref name="hWnd"/> parameter.
        /// The <paramref name="hWnd"/> parameter should not identify a child window, such as a control in a dialog box.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// If the function succeeds, the return value is one of the following menu-item values.
        /// </para>
        /// <para>
        /// If a message box has a <c>Cancel</c> button, the function returns the <see cref="IDCANCEL"/> value
        /// if either the ESC key is pressed or the <c>Cancel</c> button is selected.
        /// If the message box has no <c>Cancel</c> button, pressing ESC has no effect.
        /// </para>
        /// <para>
        /// If there is not enough memory to create the message box, the return value is zero.
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
        /// <see cref="IDABORT"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Abort</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDCANCEL"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Cancel</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDCONTINUE"/>
        /// </para>
        /// <para>
        /// 11
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Continue</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDIGNORE"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Ignore</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDNO"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// The <c>No</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDOK"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The <c>OK</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDRETRY"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Retry</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDTRYAGAIN"/>
        /// </para>
        /// <para>
        /// 10
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Try Again</c> button was selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="IDYES"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// The <c>Yes</c> button was selected.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you use a system-modal message box to indicate that the system is low on memory,
        /// the strings pointed to by the <see cref="MSGBOXPARAMS.lpszText"/> and <see cref="MSGBOXPARAMS.lpszCaption"/> members
        /// of the <see cref="MSGBOXPARAMS"/> structure should not be taken from a resource file, because an attempt to load the resource may fail.
        /// </para>
        /// <para>
        /// If you create a message box while a dialog box is present, use a handle to the dialog box as the <see cref="MSGBOXPARAMS.hwndOwner"/> parameter.
        /// The <see cref="MSGBOXPARAMS.hwndOwner"/> parameter should not identify a child window, such as a control in a dialog box.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBoxIndirectW", ExactSpelling = true)]
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
        /// <para>
        /// The <see cref="SendDlgItemMessage"/> function does not return until the message has been processed.
        /// </para>
        /// <para>
        /// Using <see cref="SendDlgItemMessage"/> is identical to retrieving a handle to the specified control and calling the <see cref="SendMessage"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendDlgItemMessageW", ExactSpelling = true)]
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// To set the new text, this function sends a <see cref="WM_SETTEXT"/> message to the specified control.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="SetDlgItemText"/> function sends a <see cref="WM_SETTEXT"/> message to the specified control.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDlgItemTextW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetDlgItemText([In] HWND hDlg, [In] int nIDDlgItem, [In] LPCWSTR lpString);
    }
}
