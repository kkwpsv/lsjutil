using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comctl32;
using static Lsj.Util.Win32.Enums.PROPSHEETPAGEFlags;

namespace Lsj.Util.Win32.Structs
{
#pragma warning disable IDE1006
    /// <summary>
    /// <para>
    /// Defines a page in a property sheet.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/pss-propsheetpage"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Comctl32.dll version 6 and later are not redistributable.
    /// To use Comctl32.dll version 6 or later, specify the .dll file in a manifest.
    /// For more information on manifests, see Enabling Visual Styles.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROPSHEETPAGE
    {
        /// <summary>
        /// Size, in bytes, of this structure.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// Flags that indicate which options to use when creating the property sheet page.
        /// This member can be a combination of the following values.
        /// <see cref="PSP_DEFAULT"/>, <see cref="PSP_DLGINDIRECT"/>, <see cref="PSP_HASHELP"/>, <see cref="PSP_HIDEHEADER"/>,
        /// <see cref="PSP_PREMATURE"/>, <see cref="PSP_RTLREADING"/>, <see cref="PSP_USECALLBACK"/>, <see cref="PSP_USEFUSIONCONTEXT"/>,
        /// <see cref="PSP_USEHEADERSUBTITLE"/>, <see cref="PSP_USEHEADERTITLE"/>, <see cref="PSP_USEHICON"/>, <see cref="PSP_USEICONID"/>,
        /// <see cref="PSP_USEREFPARENT"/>, <see cref="PSP_USETITLE"/>
        /// </summary>
        public PROPSHEETPAGEFlags dwFlags;

        /// <summary>
        /// Handle to the instance from which to load an icon or string resource.
        /// If the <see cref="pszIcon"/>, <see cref="pszTitle"/>, <see cref="pszHeaderTitle"/>, or <see cref="pszHeaderSubTitle"/> member
        /// identifies a resource to load, hInstance must be specified.
        /// </summary>
        public HINSTANCE hInstance;

        private UnionStruct1 _unionStruct1;

        /// <summary>
        /// Dialog box template to use to create the page.
        /// This member can specify either the resource identifier of the template or the address of a string that specifies the name of the template.
        /// If the <see cref="PSP_DLGINDIRECT"/> flag in the <see cref="dwFlags"/> member is set, <see cref="pszTemplate"/> is ignored.
        /// This member is declared as a union with <see cref="pResource"/>.
        /// </summary>
        public IntPtr pszTemplate
        {
            get => _unionStruct1.pszTemplate;
            set => _unionStruct1.pszTemplate = value;
        }

        /// <summary>
        /// Pointer to a dialog box template in memory. 
        /// The <see cref="PropertySheet"/> function assumes that the template is not write-protected.
        /// A read-only template will cause an exception in some versions of Windows.
        /// To use this member, you must set the <see cref="PSP_DLGINDIRECT"/> flag in the <see cref="dwFlags"/> member.
        /// This member is declared as a union with <see cref="pszTemplate"/>.
        /// </summary>
        public IntPtr pResource
        {
            get => _unionStruct1.pResource;
            set => _unionStruct1.pResource = value;
        }

        private UnionStruct2 _unionStruct2;

        /// <summary>
        /// Handle to the icon to use as the icon in the tab of the page.
        /// If the <see cref="dwFlags"/> member does not include <see cref="PSP_USEHICON"/>, this member is ignored.
        /// This member is declared as a union with <see cref="pszIcon"/>.
        /// </summary>
        public HICON hIcon
        {
            get => _unionStruct2.hIcon;
            set => _unionStruct2.hIcon = value;
        }

        /// <summary>
        /// Icon resource to use as the icon in the tab of the page.
        /// This member can specify either the identifier of the icon resource or the address of the string that specifies the name of the icon resource.
        /// To use this member, you must set the <see cref="PSP_USEICONID"/> flag in the <see cref="dwFlags"/> member.
        /// This member is declared as a union with <see cref="hIcon"/>.
        /// </summary>
        public IntPtr pszIcon
        {
            get => _unionStruct2.pszIcon;
            set => _unionStruct2.pszIcon = value;
        }

        /// <summary>
        /// Title of the property sheet dialog box.
        /// This title overrides the title specified in the dialog box template.
        /// This member can specify either the identifier of a string resource or the address of a string that specifies the title.
        /// To use this member, you must set the <see cref="PSP_USETITLE"/> flag in the <see cref="dwFlags"/> member.
        /// </summary>
        public IntPtr pszTitle;

        /// <summary>
        /// Pointer to the dialog box procedure for the page.
        /// Because the pages are created as modeless dialog boxes, the dialog box procedure must not call the <see cref="EndDialog"/> function.
        /// </summary>
        public IntPtr pfnDlgProc;

        /// <summary>
        /// When the page is created, a copy of the page's <see cref="PROPSHEETPAGE"/> structure is passed to the dialog box procedure with a <see cref="WM_INITDIALOG"/> message.
        /// The <see cref="lParam"/> member is provided to allow you to pass application-specific information to the dialog box procedure.
        /// It has no effect on the page itself.
        /// </summary>
        public LPARAM lParam;

        /// <summary>
        /// Pointer to an application-defined callback function that is called when the page is created and when it is about to be destroyed.
        /// For more information about the callback function, see LPFNPSPCALLBACK callback function.
        /// To use this member, you must set the <see cref="PSP_USECALLBACK"/> flag in the <see cref="dwFlags"/> member.
        /// </summary>
        public IntPtr pfnCallback;

        /// <summary>
        /// Pointer to the reference count value.
        /// To use this member, you must set the <see cref="PSP_USEREFPARENT"/> flag in the <see cref="dwFlags"/> member.
        /// When a property sheet page is created, the value pointed to by <see cref="pcRefParent"/> is incremented.
        /// You create a property sheet page implicitly by setting the <see cref="PSH_PROPSHEETPAGE"/> flag
        /// in the <see cref="dwFlags"/> member of <see cref="PROPSHEETHEADER"/> and calling the <see cref="PropertySheet"/> function.
        /// You can do it explicitly by using the <see cref="CreatePropertySheetPage"/> function.
        /// When a property sheet page is destroyed, the value pointed to by the <see cref="pcRefParent"/> member is decremented.
        /// This takes place automatically when the property sheet is destroyed.
        /// You can explicitly destroy a property sheet page by using the <see cref="DestroyPropertySheetPage"/> function.
        /// </summary>
        public IntPtr pcRefParent;

        /// <summary>
        /// Version 5.80 or later.
        /// Title of the header area. 
        /// To use this member under the Wizard97-style wizard, you must also do the following:
        /// Set the <see cref="PSP_USEHEADERTITLE"/> flag in the <see cref="dwFlags"/> member.
        /// Set the <see cref="PSH_WIZARD97"/> flag in the dwFlags member of the page's <see cref="PROPSHEETHEADER"/> structure.
        /// Make sure that the <see cref="PSP_HIDEHEADER"/> flag in the <see cref="dwFlags"/> member is not set.
        /// </summary>
        public IntPtr pszHeaderTitle;

        /// <summary>
        /// Version 5.80 or later.
        /// Subtitle of the header area.
        /// To use this member, you must do the following:
        /// Set the <see cref="PSP_USEHEADERSUBTITLE"/> flag in the <see cref="dwFlags"/> member.
        /// Set the <see cref="PSH_WIZARD97"/> flag in the <see cref="dwFlags"/> member of the page's <see cref="PROPSHEETHEADER"/> structure.
        /// Make sure that the <see cref="PSP_HIDEHEADER"/> flag in the <see cref="dwFlags"/> member is not set.
        /// Note
        /// This member is ignored when using the Aero-style wizard (<see cref="PSH_AEROWIZARD"/>)
        /// </summary>
        public IntPtr pszHeaderSubTitle;

        /// <summary>
        /// Version 6.0 or later.
        /// An activation context handle.
        /// Set this member to the handle that is returned when you create the activation context with <see cref="CreateActCtx"/>.
        /// The system will activate this context before creating the dialog box.
        /// You do not need to use this member if you use a global manifest.
        /// </summary>
        public HANDLE hActCtx;

        private UnionStruct3 _unionStruct3;

        /// <summary>
        /// This member is declared as a union with <see cref="pszbmHeader"/>.
        /// </summary>
        public HBITMAP hbmHeader
        {
            get => _unionStruct3.hbmHeader;
            set => _unionStruct3.hbmHeader = value;
        }

        /// <summary>
        /// This member is declared as a union with <see cref="hbmHeader"/>.
        /// </summary>
        public IntPtr pszbmHeader
        {
            get => _unionStruct3.pszbmHeader;
            set => _unionStruct3.pszbmHeader = value;
        }

        struct UnionStruct1
        {
            public IntPtr pszTemplate;
            public IntPtr pResource;
        }

        struct UnionStruct2
        {
            public HICON hIcon;
            public IntPtr pszIcon;
        }

        struct UnionStruct3
        {
            public HBITMAP hbmHeader;
            public IntPtr pszbmHeader;
        }
    }
#pragma warning restore IDE1006
}
