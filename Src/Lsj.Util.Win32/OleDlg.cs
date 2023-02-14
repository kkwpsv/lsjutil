using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.OLEUI;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// OleDlg.dll
    /// </summary>
    public static class OleDlg
    {
        /// <summary>
        /// <para>
        /// Invokes the standard Links dialog box, allowing the user to make modifications to a container's linked objects.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oledlg/nf-oledlg-oleuieditlinksw"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// Pointer to an <see cref="OLEUIEDITLINKS"/> structure that contains information used to initialize the dialog box.
        /// </param>
        /// <returns>
        /// Standard Success/Error Definitions
        /// <see cref="OLEUI_FALSE"/>: Unknown failure(unused).
        /// <see cref="OLEUI_OK"/>: The user pressed the OK button.
        /// <see cref="OLEUI_SUCCESS"/>: No error, same as <see cref="OLEUI_OK"/>.
        /// <see cref="OLEUI_CANCEL"/>: The user pressed the Cancel button.
        /// Standard Field Validation Errors
        /// <see cref="OLEUI_ERR_STANDARDMIN"/>:
        /// Errors common to all dialog boxes lie in the range <see cref="OLEUI_ERR_STANDARDMIN"/> to <see cref="OLEUI_ERR_STANDARDMAX"/>.
        /// This value allows the application to test for standard messages in order to display error messages to the user.
        /// <see cref="OLEUI_ERR_STRUCTURENULL"/>: The pointer to an OLEUIXXX structure passed into the function was NULL.
        /// <see cref="OLEUI_ERR_STRUCTUREINVALID"/>: Insufficient permissions for read or write access to an OLEUIXXX structure.
        /// <see cref="OLEUI_ERR_CBSTRUCTINCORRECT"/>: The <see cref="OLEUIEDITLINKS.cbStruct"/> value is incorrect.
        /// <see cref="OLEUI_ERR_HWNDOWNERINVALID"/>: The <see cref="OLEUIEDITLINKS.hWndOwner"/> value is invalid.
        /// <see cref="OLEUI_ERR_LPSZCAPTIONINVALID"/>: The <see cref="OLEUIEDITLINKS.lpszCaption"/> value is invalid.
        /// <see cref="OLEUI_ERR_LPFNHOOKINVALID"/>: The <see cref="OLEUIEDITLINKS.lpfnHook"/> value is invalid.
        /// <see cref="OLEUI_ERR_HINSTANCEINVALID"/>: The <see cref="OLEUIEDITLINKS.hInstance"/> value is invalid.
        /// <see cref="OLEUI_ERR_LPSZTEMPLATEINVALID"/>: The <see cref="OLEUIEDITLINKS.lpszTemplate"/> value is invalid.
        /// <see cref="OLEUI_ERR_HRESOURCEINVALID"/>: The <see cref="OLEUIEDITLINKS.hResource"/> value is invalid.
        /// Initialization Errors
        /// <see cref="OLEUI_ERR_FINDTEMPLATEFAILURE"/>: Unable to find the dialog box template.
        /// <see cref="OLEUI_ERR_LOADTEMPLATEFAILURE"/>: Unable to load the dialog box template.
        /// <see cref="OLEUI_ERR_DIALOGFAILURE"/>: Dialog box initialization failed.
        /// <see cref="OLEUI_ERR_LOCALMEMALLOC"/>: A call to <see cref="LocalAlloc"/> or the standard <see cref="IMalloc"/> allocator failed.
        /// <see cref="OLEUI_ERR_GLOBALMEMALLOC"/>: A call to <see cref="GlobalAlloc"/> or the standard <see cref="IMalloc"/> allocator failed.
        /// <see cref="OLEUI_ERR_LOADSTRING"/>: Unable to call <see cref="LoadString"/> for localized resources from the library.
        /// <see cref="OLEUI_ERR_OLEMEMALLOC"/>: A call to the standard <see cref="IMalloc"/> allocator failed.
        /// Function Specific Errors
        /// <see cref="OLEUI_ERR_STANDARDMAX"/>
        /// Errors common to all dialog boxes lie in the range <see cref="OLEUI_ERR_STANDARDMIN"/> to <see cref="OLEUI_ERR_STANDARDMAX"/>.
        /// This value allows the application to test for standard messages in order to display error messages to the user.
        /// </returns>
        [DllImport("OleDlg.dll", CharSet = CharSet.Unicode, EntryPoint = "OleUIEditLinksW", ExactSpelling = true, SetLastError = true)]
        public static extern OLEUI OleUIEditLinks([In] in OLEUIEDITLINKS unnamedParam1);
    }
}
