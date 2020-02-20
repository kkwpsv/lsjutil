using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DialogBoxStyles;
using static Lsj.Util.Win32.Enums.GetWindowLongIndexes;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
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
        public static IntPtr CreateDialog(IntPtr hInstance, StringOrIntPtrObject lpName, IntPtr hWndParent, DLGPROC lpDialogFunc) =>
            CreateDialogParam(hInstance, lpName, hWndParent, lpDialogFunc, IntPtr.Zero);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDialogParamW", SetLastError = true)]
        public static extern IntPtr CreateDialogParam([In]IntPtr hInstance,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringOrIntPtrObjectMarshaler))][In]StringOrIntPtrObject lpTemplateName,
            [In]IntPtr hWndParent, [In]DLGPROC lpDialogFunc, [In]IntPtr dwInitParam);

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
        public static IntPtr DialogBox(IntPtr hInstance, StringOrIntPtrObject lpTemplate, IntPtr hWndParent, DLGPROC lpDialogFunc) =>
            DialogBoxParam(hInstance, lpTemplate, hWndParent, lpDialogFunc, IntPtr.Zero);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DialogBoxParamW", SetLastError = true)]
        public static extern IntPtr DialogBoxParam([In]IntPtr hInstance,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringOrIntPtrObjectMarshaler))][In]StringOrIntPtrObject lpTemplateName,
            [In]IntPtr hWndParent, [In] DLGPROC lpDialogFunc, [In]IntPtr dwInitParam);

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
        public static IntPtr DialogBoxIndirect([In]IntPtr hInstance, [In]IntPtr lpTemplateName, [In]IntPtr hWndParent, [In]DLGPROC lpDialogFunc) =>
            DialogBoxIndirectParam(hInstance, lpTemplateName, hWndParent, lpDialogFunc, IntPtr.Zero);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DialogBoxIndirectParamW", SetLastError = true)]
        public static extern IntPtr DialogBoxIndirectParam([In]IntPtr hInstance, [In]IntPtr lpTemplateName, [In]IntPtr hWndParent,
            [In]DLGPROC lpDialogFunc, [In]IntPtr dwInitParam);

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
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EndDialog", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EndDialog([In]IntPtr hDlg, [In]IntPtr nResult);
    }
}
