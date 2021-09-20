using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.EditLinksFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that the OLE User Interface Library uses to initialize the Edit Links dialog box,
    /// and contains space for the library to return information when the dialog box is dismissed.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/oledlg/ns-oledlg-oleuieditlinksw"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OLEUIEDITLINKS
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// This member must be filled on input.
        /// </summary>
        public DWORD cbStruct;

        /// <summary>
        /// On input, dwFlags specifies the initialization and creation flags.
        /// It may be a combination of the following flags.
        /// <see cref="ELF_SHOWHELP"/>: Specifies that the dialog box will display a Help button.
        /// <see cref="ELF_DISABLEUPDATENOW"/>: Specifies that the Update Now button will be disabled on initialization.
        /// <see cref="ELF_DISABLEOPENSOURCE"/>: Specifies that the Open Source button will be disabled on initialization.
        /// <see cref="ELF_DISABLECHANGESOURCE"/>: Specifies that the Change Source button will be disabled on initialization.
        /// <see cref="ELF_DISABLECANCELLINK"/>: Specifies that the Cancel Link button will be disabled on initialization.
        /// </summary>
        public EditLinksFlags dwFlags;

        /// <summary>
        /// The window that owns the dialog box. This member should not be NULL.
        /// </summary>
        public HWND hWndOwner;

        /// <summary>
        /// Pointer to a string to be used as the title of the dialog box.
        /// If <see cref="NULL"/>, then the library uses Links.
        /// </summary>
        public LPCWSTR lpszCaption;

        /// <summary>
        /// Pointer to a hook function that processes messages intended for the dialog box.
        /// The hook function must return zero to pass a message that it didn't process back to the dialog box procedure in the library.
        /// The hook function must return a nonzero value to prevent the library's dialog box procedure from processing a message it has already processed.
        /// </summary>
        public LPFNOLEUIHOOK lpfnHook;

        /// <summary>
        /// Application-defined data that the library passes to the hook function pointed to by the <see cref="lpfnHook"/> member.
        /// The library passes a pointer to the <see cref="OLEUIEDITLINKS"/> structure in the lParam parameter of the <see cref="WM_INITDIALOG"/> message;
        /// this pointer can be used to retrieve the <see cref="lCustData"/> member.
        /// </summary>
        public LPARAM lCustData;

        /// <summary>
        /// Instance that contains a dialog box template specified by the <see cref="lpszTemplate"/> member.
        /// </summary>
        public HINSTANCE hInstance;

        /// <summary>
        /// Pointer to a null-terminated string that specifies the name of the resource file for the dialog box template
        /// that is to be substituted for the library's Edit Links dialog box template.
        /// </summary>
        public LPCWSTR lpszTemplate;

        /// <summary>
        /// Customized template handle.
        /// </summary>
        public HRSRC hResource;

        /// <summary>
        /// Pointer to the container's implementation of the <see cref="IOleUILinkContainer"/> Interface.
        /// The Edit Links dialog box uses this to allow the container to manipulate its links.
        /// </summary>
        public LP<IOleUILinkContainer> lpOleUILinkContainer;
    }
}
