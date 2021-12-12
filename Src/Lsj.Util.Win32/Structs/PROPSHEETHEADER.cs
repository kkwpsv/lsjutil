using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comctl32;
using static Lsj.Util.Win32.Enums.PROPSHEETHEADERFlags;
using static Lsj.Util.Win32.Enums.PROPSHEETPAGEFlags;

namespace Lsj.Util.Win32.Structs
{
#pragma warning disable IDE1006
    /// <summary>
    /// <para>
    /// Defines the frame and pages of a property sheet.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/pss-propsheetheader"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the user chooses a setting such as Large Fonts, which enlarges the dialog box,
    /// the watermark that is painted on the start and finish pages will be enlarged as well.
    /// The size and position of the original bitmap will remain the same.
    /// The additional area will be filled with the color of the pixel in the upper-left corner of the bitmap.
    /// The <see cref="PSH_WIZARD"/>, <see cref="PSH_WIZARD97"/>, and <see cref="PSH_WIZARD_LITE"/> styles are mutually incompatible.
    /// Only one of these style flags should be set.
    /// <see cref="PSH_AEROWIZARD"/> should be combined with <see cref="PSH_WIZARD"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROPSHEETHEADER
    {
        /// <summary>
        /// Size, in bytes, of this structure.
        /// The property sheet manager uses this member to determine which version of the <see cref="PROPSHEETHEADER"/> structure you are using.
        /// For more information, see the Remarks.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// Flags that indicate which options to use when creating the property sheet page.
        /// This member can be a combination of the following values.
        /// <see cref="PSH_DEFAULT"/>:
        /// Uses the default meaning for all structure members, and creates a normal property sheet.
        /// This flag has a value of zero and is not combined with other flags.
        /// <see cref="PSH_AEROWIZARD"/>:
        /// Version 6.00 and later.
        /// Creates a wizard property sheet that uses the Aero style.
        /// The <see cref="PSH_WIZARD"/> flag must also be set.
        /// The single-threaded apartment (STA) model must be used.
        /// <see cref="PSH_HASHELP"/>:
        /// Permits property sheet pages to display a Help button.
        /// You must also set the <see cref="PSP_HASHELP"/> flag in the page's <see cref="PROPSHEETPAGE"/> structure when the page is created.
        /// If any of the initial property sheet pages enable a Help button, <see cref="PSH_HASHELP"/> will be set automatically.
        /// If none of the initial pages enable a Help button, you must explicitly set <see cref="PSH_HASHELP"/>
        /// if you want to have Help buttons on any pages that might be added later.
        /// This flag is not supported in conjunction with <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_HEADER"/>:
        /// Version 5.80 and later.
        /// Indicates that a header bitmap will be used with a Wizard97 wizard.
        /// You must also set the <see cref="PSH_WIZARD97"/> flag.
        /// If the <see cref="PSH_USEHBMHEADER"/> flag is set, then the header bitmap is obtained from the <see cref="hbmHeader"/> member.
        /// Otherwise, the header bitmap is obtained from the <see cref="pszbmHeader"/> member.
        /// This flag is not supported in conjunction with <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_HEADERBITMAP"/>:
        /// Version 6.00 and later.
        /// The <see cref="pszbmHeader"/> member specifies a bitmap that is displayed in the header area.
        /// Must be used in combination with <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_MODELESS"/>:
        /// Causes the <see cref="PropertySheet"/> function to create the property sheet as a modeless dialog box instead of as a modal dialog box.
        /// When this flag is set, <see cref="PropertySheet"/> returns immediately after the dialog box is created,
        /// and the return value from <see cref="PropertySheet"/> is the window handle to the property sheet dialog box.
        /// This flag is not supported in conjunction with <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_NOAPPLYNOW"/>:
        /// Removes the Apply button. This flag is not supported in conjunction with <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_NOCONTEXTHELP"/>:
        /// Version 5.80 and later.
        /// Removes the context-sensitive Help button ("?"), which is usually present on the caption bar of property sheets.
        /// This flag is not valid for wizards.
        /// See About Property Sheets for a discussion of how to remove the caption bar Help button for earlier versions of the common controls.
        /// This flag is not supported in conjunction with <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_NOMARGIN"/>:
        /// Version 6.00 or later.
        /// Specifies that no margin is inserted between the page and the frame.
        /// Must be used in combination with <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_PROPSHEETPAGE"/>:
        /// Uses the <see cref="ppsp"/> member and ignores the <see cref="phpage"/> member when creating the pages for the property sheet.
        /// <see cref="PSH_PROPTITLE"/>:
        /// Indicates that the <see cref="pszCaption"/> is the name of the thing for which properties are being shown.
        /// Windows makes a version- and language-dependent adjustment to the caption.
        /// For example, in English, the phrase "Properties for" is prepended to a nonempty <see cref="pszCaption"/>
        /// (and if the <see cref="pszCaption"/> produces an empty caption, then the title is simply "Properties").
        /// If this flag is omitted, then the <see cref="pszCaption"/> is used unaltered.
        /// <see cref="PSH_RESIZABLE"/>:
        /// Allows the wizard to be resized by the user.
        /// Maximize and minimize buttons appear in the wizard's frame and the frame is sizable.
        /// To use this flag, you must also set <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_RTLREADING"/>:
        /// Sets the property sheet or wizard window to right-to-left (RTL) reading order, appropriate for languages like Hebrew and Arabic.
        /// If this flag is not specified, property sheet windows default to left-to-right (LTR) reading order,
        /// and wizard windows match the reading order of the current page.
        /// <see cref="PSH_STRETCHWATERMARK"/>:
        /// Stretches the watermark in Wizard97-style wizards.
        /// This flag is not supported in conjunction with <see cref="PSH_AEROWIZARD"/>.
        /// This style flag is only included to provide backward compatibility for certain applications.
        /// Its use is not recommended, and it is only supported by common controls versions 4.0 and 4.01.
        /// With common controls version 5.80 and later, this flag is ignored.
        /// <see cref="PSH_USECALLBACK"/>:
        /// Calls the function specified by the pfnCallback parameter when certain events occur.
        /// For more information, see the description of the <see cref="PFNPROPSHEETCALLBACK"/> callback function.
        /// <see cref="PSH_USEHBMHEADER"/>:
        /// Version 5.80.
        /// Obtains the header bitmap from the <see cref="hbmHeader"/> member instead of the <see cref="pszbmHeader"/> member.
        /// You must also set either the <see cref="PSH_AEROWIZARD"/> flag
        /// or the <see cref="PSH_WIZARD97"/> flag together with the <see cref="PSH_HEADER"/> flag.
        /// <see cref="PSH_USEHBMWATERMARK"/>:
        /// Version 5.80.
        /// Obtains the watermark bitmap from the <see cref="hbmWatermark"/> member instead of the <see cref="pszbmWatermark"/> member.
        /// You must also set <see cref="PSH_WIZARD97"/> and <see cref="PSH_WATERMARK"/>.
        /// This flag is not supported in conjunction with <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_USEHICON"/>:
        /// Uses <see cref="hIcon"/> as the small icon in the title bar of the property sheet dialog box.
        /// <see cref="PSH_USEHPLWATERMARK"/>:
        /// Version 5.80.
        /// Uses the <see cref="HPALETTE"/> structure pointed to by the <see cref="hplWatermark"/> membe
        /// instead of the default palette to draw the watermark bitmap and/or header bitmap for a Wizard97 wizard.
        /// You must also set <see cref="PSH_WIZARD97"/>, and <see cref="PSH_WATERMARK"/> or <see cref="PSH_HEADER"/>.
        /// This flag is not supported in conjunction with <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_USEICONID"/>:
        /// Uses <see cref="pszIcon"/> as the name of the icon resource to load and use as the small icon in the title bar of the property sheet dialog box.
        /// <see cref="PSH_USEPAGELANG"/>:
        /// Version 5.80.
        /// Specifies that the language for the property sheet will be taken from the first page's resource.
        /// That page must be specified by resource identifier.
        /// <see cref="PSH_USEPSTARTPAGE"/>:
        /// Uses the <see cref="pStartPage"/> member instead of the <see cref="nStartPage"/> member
        /// when displaying the initial page of the property sheet.
        /// <see cref="PSH_WATERMARK"/>:
        /// Version 5.80.
        /// Specifies that a watermark bitmap will be used with a Wizard97 wizard on pages that have the <see cref="PSP_HIDEHEADER"/> style.
        /// You must also set the <see cref="PSH_WIZARD97"/> flag.
        /// The watermark bitmap is obtained from the pszbmWatermark member, unless <see cref="PSH_USEHBMWATERMARK"/> is set.
        /// In that case, the header bitmap is obtained from the <see cref="hbmWatermark"/> member.
        /// This flag is not supported in conjunction with <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_WIZARD"/>:
        /// Creates a wizard property sheet.
        /// When using <see cref="PSH_AEROWIZARD"/>, you must also set this flag.
        /// <see cref="PSH_WIZARD97"/>:
        /// Version 5.80.
        /// Creates a Wizard97-style property sheet, which supports bitmaps in the header of interior pages and on the left side of exterior pages.
        /// This flag is not supported in conjunction with <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_WIZARDCONTEXTHELP"/>:
        /// Adds a context-sensitive Help button ("?"), which is usually absent from the caption bar of a wizard.
        /// This flag is not valid for regular property sheets.
        /// This flag is not supported in conjunction with <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_WIZARDHASFINISH"/>:
        /// Always displays the Finish button on the wizard.
        /// You must also set either <see cref="PSH_WIZARD"/>, <see cref="PSH_WIZARD97"/>, or <see cref="PSH_AEROWIZARD"/>.
        /// <see cref="PSH_WIZARD_LITE"/>:
        /// Version 5.80.
        /// Uses the Wizard-lite style.
        /// This style is similar in appearance to <see cref="PSH_WIZARD97"/>, but it is implemented much like <see cref="PSH_WIZARD"/>.
        /// There are few restrictions on how the pages are formatted.
        /// For instance, there are no enforced borders, and the <see cref="PSH_WIZARD_LITE"/> style does not paint the watermark
        /// and header bitmaps for you the way Wizard97 does.
        /// This flag is not supported in conjunction with <see cref="PSH_AEROWIZARD"/>.
        /// </summary>
        public PROPSHEETHEADERFlags dwFlags;

        /// <summary>
        /// Handle to the property sheet's owner window.
        /// </summary>
        public HWND hwndParent;

        /// <summary>
        /// Handle to the instance from which to load the icon, title string resource, starting page name, header bitmap, or watermark.
        /// If the <see cref="pszIcon"/>, <see cref="pszCaption"/>, <see cref="pStartPage"/>,
        /// <see cref="pszbmHeader"/>, or <see cref="pszbmWatermark"/> member identifies a resource to load, this member must be specified.
        /// </summary>
        public HINSTANCE hInstance;

        private UnionStruct1 _unionStruct1;

        /// <summary>
        /// Handle to the icon to use as the small icon in the title bar of the property sheet dialog box.
        /// This member is used if the <see cref="dwFlags"/> member includes <see cref="PSH_USEHICON"/>.
        /// This member is declared as a union with <see cref="pszIcon"/>.
        /// </summary>
        public IntPtr hIcon
        {
            get => _unionStruct1.hIcon;
            set => _unionStruct1.hIcon = value;
        }

        /// <summary>
        /// Icon resource to use as the small icon in the title bar of the property sheet dialog box.
        /// This member is used if the dwFlags member includes <see cref="PSH_USEICONID"/>.
        /// This member can specify either the identifier of the icon resource or the address of the string that specifies the name of the icon resource.
        /// In both cases, the icon is loaded from the instance provided by the <see cref="hInstance"/> member.
        /// This member is declared as a union with hIcon.
        /// </summary>
        public LPCSTR pszIcon
        {
            get => _unionStruct1.pszIcon;
            set => _unionStruct1.pszIcon = value;
        }

        /// <summary>
        /// Title of the property sheet dialog box.
        /// This member can specify either the identifier of a string resource (loaded from the instance specified by the <see cref="hInstance"/> member)
        /// or the address of a string that specifies the title.
        /// If the <see cref="dwFlags"/> member includes <see cref="PSH_PROPTITLE"/>, the string Properties for is inserted at the beginning of the title.
        /// This field is ignored for Wizard97 wizards.
        /// For Aero wizards, the string alone is used for the caption, regardless of whether the <see cref="PSH_PROPTITLE"/> flag is set.
        /// </summary>
        public LPCSTR pszCaption;

        /// <summary>
        /// Number of property sheet pages provided in either the <see cref="ppsp"/> or <see cref="phpage"/> array.
        /// </summary>
        public UINT nPages;

        private UnionStruct2 _unionStruct2;

        /// <summary>
        /// Zero-based index of the initial page that appears when the property sheet dialog box is created.
        /// This member is used if the dwFlags member does not include the <see cref="PSH_USEPSTARTPAGE"/> flag.
        /// This member is declared as a union with <see cref="pStartPage"/>.
        /// </summary>
        public UINT nStartPage
        {
            get => _unionStruct2.nStartPage;
            set => _unionStruct2.nStartPage = value;
        }

        /// <summary>
        /// Name of the initial page that appears when the property sheet dialog box is created.
        /// This member is used if the dwFlags member includes the <see cref="PSH_USESTARTPAGE"/> flag.
        /// This member can specify either the identifier of a string resource (loaded from the instance specified by the <see cref="hInstance"/> member)
        /// or the address of a string that specifies the name.
        /// The start page name is matched against the captions of the pages.
        /// This member is declared as a union with <see cref="nStartPage"/>.
        /// </summary>
        public LPCWSTR pStartPage
        {
            get => _unionStruct2.pStartPage;
            set => _unionStruct2.pStartPage = value;
        }

        private UnionStruct3 _unionStruct3;

        /// <summary>
        /// Pointer to an array of <see cref="PROPSHEETPAGE"/> structures that define the pages in the property sheet.
        /// If the <see cref="dwFlags"/> member does not include <see cref="PSH_PROPSHEETPAGE"/>, this member is ignored.
        /// Note that the <see cref="PROPSHEETPAGE"/> structure is variable in size.
        /// Applications that parse the array pointed to by <see cref="ppsp"/> must take the size of each page into account.
        /// This member is declared as a union with <see cref="phpage"/>.
        /// </summary>
        public IntPtr ppsp
        {
            get => _unionStruct3.ppsp;
            set => _unionStruct3.ppsp = value;
        }

        /// <summary>
        /// Pointer to an array of handles to the property sheet pages.
        /// This member is used if the <see cref="dwFlags"/> member does not include <see cref="PSH_PROPSHEETPAGE"/>.
        /// Each handle must have been created by a previous call to the <see cref="CreatePropertySheetPage"/> function.
        /// When the <see cref="PropertySheet"/> function returns, any <see cref="HPROPSHEETPAGE"/> handles in the phpage array will have been destroyed.
        /// This member is declared as a union with <see cref="ppsp"/>.
        /// </summary>
        public IntPtr phpage
        {
            get => _unionStruct3.phpage;
            set => _unionStruct3.phpage = value;
        }

        /// <summary>
        /// Pointer to an application-defined callback function that is called when certain events occur.
        /// For more information about the callback function, see the description of the <see cref="PFNPROPSHEETCALLBACK"/> callback function.
        /// If the <see cref="dwFlags"/> member does not include <see cref="PSH_USECALLBACK"/>, this member is ignored.
        /// </summary>
        public PFNPROPSHEETCALLBACK pfnCallback;

        private UnionStruct4 _unionStruct4;

        /// <summary>
        /// Version 5.80 or later.
        /// Handle to the watermark bitmap.
        /// If the <see cref="dwFlags"/> member does not include <see cref="PSH_USEHBMWATERMARK"/>, this member is ignored.
        /// </summary>
        public HBITMAP hbmWatermark
        {
            get => _unionStruct4.hbmWatermark;
            set => _unionStruct4.hbmWatermark = value;
        }

        /// <summary>
        /// Version 5.80 or later.
        /// Bitmap resource to use as the watermark.
        /// This member can specify either the identifier of the bitmap resource or the address of the string
        /// that specifies the name of the bitmap resource.
        /// If the <see cref="dwFlags"/> member includes <see cref="PSH_USEHBMWATERMARK"/>, this member is ignored.
        /// </summary>
        public LPCSTR pszbmWatermark
        {
            get => _unionStruct4.pszbmWatermark;
            set => _unionStruct4.pszbmWatermark = value;
        }

        /// <summary>
        /// Version 5.80 or later.
        /// <see cref="HPALETTE"/> structure used for drawing the watermark bitmap and/or header bitmap.
        /// If the <see cref="dwFlags"/> member does not include <see cref="PSH_USEHPLWATERMARK"/>, this member is ignored.
        /// </summary>
        public HPALETTE hplWatermark;

        private UnionStruct5 _unionStruct5;

        /// <summary>
        /// Version 5.80 or later.
        /// Handle to the header bitmap.
        /// If the <see cref="dwFlags"/> member does not include <see cref="PSH_USEHBMHEADER"/>, this member is ignored.
        /// </summary>
        public HBITMAP hbmHeader
        {
            get => _unionStruct5.hbmHeader;
            set => _unionStruct5.hbmHeader = value;
        }

        /// <summary>
        /// Version 5.80 or later.
        /// Bitmap resource to use as the header.
        /// This member can specify either the identifier of the bitmap resource or the address of the string
        /// that specifies the name of the bitmap resource.
        /// If the <see cref="dwFlags"/> member includes <see cref="PSH_USEHBMHEADER"/>, this member is ignored.
        /// </summary>
        public LPCSTR pszbmHeader
        {
            get => _unionStruct5.pszbmHeader;
            set => _unionStruct5.pszbmHeader = value;
        }

        struct UnionStruct1
        {
            public HICON hIcon;
            public LPCSTR pszIcon;
        }

        struct UnionStruct2
        {
            public UINT nStartPage;
            public LPCWSTR pStartPage;
        }

        struct UnionStruct3
        {
            public IntPtr ppsp;
            public IntPtr phpage;
        }

        struct UnionStruct4
        {
            public HBITMAP hbmWatermark;
            public LPCSTR pszbmWatermark;
        }

        struct UnionStruct5
        {
            public HBITMAP hbmHeader;
            public LPCSTR pszbmHeader;
        }
    }
#pragma warning restore IDE1006
}
