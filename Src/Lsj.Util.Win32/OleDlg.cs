using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.OLEUIResults;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Constants;

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
        /// <para>
        /// Standard Success/Error Definitions
        /// </para>
        /// <para>
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
        /// <see cref="OLEUI_FALSE"/>
        /// </term>
        /// <term>
        /// Unknown failure (unused).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_OK"/>
        /// </term>
        /// <term>
        /// The user pressed the OK button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_SUCCESS"/>
        /// </term>
        /// <term>
        /// No error, same as OLEUI_OK.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_CANCEL"/>
        /// </term>
        /// <term>
        /// The user pressed the Cancel button.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Standard Field Validation Errors
        /// </para>
        /// <para>
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
        /// <see cref="OLEUI_ERR_STANDARDMIN"/>
        /// </term>
        /// <term>
        /// Errors common to all dialog boxes lie in the range <see cref="OLEUI_ERR_STANDARDMIN"/> to <see cref="OLEUI_ERR_STANDARDMAX"/>.
        /// This value allows the application to test for standard messages in order to display error messages to the user.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_STRUCTURENULL"/>
        /// </term>
        /// <term>
        /// The pointer to an OLEUIXXX structure passed into the function was <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_STRUCTUREINVALID"/>
        /// </term>
        /// <term>
        /// Insufficient permissions for read or write access to an OLEUIXXX structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_CBSTRUCTINCORRECT"/>
        /// </term>
        /// <term>
        /// The <see cref="OLEUIEDITLINKS.cbStruct"/> value is incorrect.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_HWNDOWNERINVALID"/>
        /// </term>
        /// <term>
        /// The <see cref="OLEUIEDITLINKS.hWndOwner"/> value is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_LPSZCAPTIONINVALID"/>
        /// </term>
        /// <term>
        /// The <see cref="OLEUIEDITLINKS.lpszCaption"/> value is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_LPFNHOOKINVALID"/>
        /// </term>
        /// <term>
        /// The <see cref="OLEUIEDITLINKS.lpfnHook"/> value is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_HINSTANCEINVALID"/>
        /// </term>
        /// <term>
        /// The <see cref="OLEUIEDITLINKS.hInstance"/> value is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_LPSZTEMPLATEINVALID"/>
        /// </term>
        /// <term>
        /// The <see cref="OLEUIEDITLINKS.lpszTemplate"/> value is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_HRESOURCEINVALID"/>
        /// </term>
        /// <term>
        /// The <see cref="OLEUIEDITLINKS.hResource"/> value is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Initialization Errors
        /// </para>
        /// <para>
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
        /// <see cref="OLEUI_ERR_FINDTEMPLATEFAILURE"/>
        /// </term>
        /// <term>
        /// Unable to find the dialog box template.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_LOADTEMPLATEFAILURE"/>
        /// </term>
        /// <term>
        /// Unable to load the dialog box template.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_DIALOGFAILURE"/>
        /// </term>
        /// <term>
        /// Dialog box initialization failed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_LOCALMEMALLOC"/>
        /// </term>
        /// <term>
        /// A call to <see cref="LocalAlloc"/> or the standard <see cref="IMalloc"/> allocator failed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_GLOBALMEMALLOC"/>
        /// </term>
        /// <term>
        /// A call to <see cref="GlobalAlloc"/> or the standard <see cref="IMalloc"/> allocator failed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_LOADSTRING"/>
        /// </term>
        /// <term>
        /// Unable to call LoadString for localized resources from the library.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OLEUI_ERR_OLEMEMALLOC"/>
        /// </term>
        /// <term>
        /// A call to the standard <see cref="IMalloc"/> allocator failed.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Function Specific Errors
        /// </para>
        /// <para>
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
        /// <see cref="OLEUI_ERR_STANDARDMAX"/>
        /// </term>
        /// <term>
        /// Errors common to all dialog boxes lie in the range <see cref="OLEUI_ERR_STANDARDMIN"/> to <see cref="OLEUI_ERR_STANDARDMAX"/>.
        /// This value allows the application to test for standard messages in order to display error messages to the user.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("OleDlg.dll", CharSet = CharSet.Unicode, EntryPoint = "OleUIEditLinksW", ExactSpelling = true)]
        public static extern OLEUIResults OleUIEditLinks([In] in OLEUIEDITLINKS unnamedParam1);
    }
}
