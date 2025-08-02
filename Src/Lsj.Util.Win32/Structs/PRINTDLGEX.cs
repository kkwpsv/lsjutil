using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Comctl32;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DEVMODEFields;
using static Lsj.Util.Win32.Enums.PrintDlgExResults;
using static Lsj.Util.Win32.Enums.PRINTDLGFlags;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that the <see cref="PrintDlgEx"/> function uses to initialize the Print property sheet.
    /// After the user closes the property sheet, the system uses this structure to return information about the user's selections.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-printdlgexw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If both <see cref="hDevMode"/> and <see cref="hDevNames"/> are <see cref="NULL"/>,
    /// <see cref="PrintDlgEx"/> initializes the property sheet using the current default printer.
    /// To initialize the property sheet for a different printer,
    /// use the <see cref="DEVNAMES.wDeviceOffset"/> member of the <see cref="DEVNAMES"/> structure to specify the name of the printer.
    /// </para>
    /// <para>
    /// Note that the <see cref="DEVMODE.dmDeviceName"/> member of the <see cref="DEVMODE"/> structure also specifies a printer name.
    /// However, <see cref="DEVMODE.dmDeviceName"/> is limited to 32 characters, and the <see cref="DEVNAMES.wDeviceOffset"/> name is not.
    /// If the <see cref="DEVNAMES.wDeviceOffset"/> and <see cref="DEVMODE.dmDeviceName"/> names are not the same,
    /// <see cref="PrintDlgEx"/> initializes the property sheet using the printer specified by <see cref="DEVNAMES.wDeviceOffset"/>.
    /// </para>
    /// <para>
    /// If the <see cref="PD_RETURNDEFAULT"/> flag is set and both <see cref="hDevMode"/> and <see cref="hDevNames"/> are <see cref="NULL"/>,
    /// <see cref="PrintDlgEx"/> uses the <see cref="hDevNames"/> and <see cref="hDevMode"/> members to return information
    /// about the current default printer without displaying the dialog box.
    /// </para>
    /// <para>
    /// During the execution of <see cref="PrintDlgEx"/>, the <see cref="DEVMODE"/> and <see cref="DEVNAMES"/> structures
    /// that you specified in the <see cref="PRINTDLGEX"/> structure may not always contain current data.
    /// For this reason, application-specific property pages as well as <see cref="IPrintDialogCallback"/> routines
    /// for the initial page should use the <see cref="IPrintDialogServices"/> interface to retrieve information about the state of the current printer.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PRINTDLGEX
    {
        /// <summary>
        /// PD_EXCL_COPIESANDCOLLATE
        /// </summary>
        public static readonly DWORD PD_EXCL_COPIESANDCOLLATE = (uint)(DM_COPIES | DM_COLLATE);

        /// <summary>
        /// START_PAGE_GENERAL
        /// </summary>
        public static readonly DWORD START_PAGE_GENERAL = 0xffffffff;

        /// <summary>
        /// The structure size, in bytes.
        /// </summary>
        public DWORD lStructSize;

        /// <summary>
        /// A handle to the window that owns the property sheet.
        /// This member must be a valid window handle; it cannot be <see cref="NULL"/>.
        /// </summary>
        public HWND hwndOwner;

        /// <summary>
        /// <para>
        /// A handle to a movable global memory object that contains a <see cref="DEVMODE"/> structure.
        /// If <see cref="hDevMode"/> is not <see cref="NULL"/> on input,
        /// you must allocate a movable block of memory for the <see cref="DEVMODE"/> structure and initialize its members.
        /// The <see cref="PrintDlgEx"/> function uses the input data to initialize the controls in the property sheet.
        /// When <see cref="PrintDlgEx"/> returns, the <see cref="DEVMODE"/> members indicate the user's input.
        /// </para>
        /// <para>
        /// If <see cref="hDevMode"/> is <see cref="NULL"/> on input,
        /// <see cref="PrintDlgEx"/> allocates memory for the <see cref="DEVMODE"/> structure,
        /// initializes its members to indicate the user's input, and returns a handle that identifies it.
        /// </para>
        /// <para>
        /// For more information about the <see cref="hDevMode"/> and <see cref="hDevNames"/> members, see the Remarks section at the end of this topic.
        /// </para>
        /// </summary>
        public HGLOBAL hDevMode;

        /// <summary>
        /// <para>
        /// A handle to a movable global memory object that contains a <see cref="DEVNAMES"/> structure.
        /// If <see cref="hDevNames"/> is not <see cref="NULL"/> on input,
        /// you must allocate a movable block of memory for the <see cref="DEVNAMES"/> structure and initialize its members.
        /// The <see cref="PrintDlgEx"/> function uses the input data to initialize the controls in the property sheet.
        /// When <see cref="PrintDlgEx"/> returns, the <see cref="DEVNAMES"/> members contain information for the printer chosen by the user.
        /// You can use this information to create a device context or an information context.
        /// </para>
        /// <para>
        /// The <see cref="hDevNames"/> member can be <see cref="NULL"/>, in which case,
        /// <see cref="PrintDlgEx"/> allocates memory for the <see cref="DEVNAMES"/> structure,
        /// initializes its members to indicate the user's input, and returns a handle that identifies it.
        /// </para>
        /// <para>
        /// For more information about the <see cref="hDevMode"/> and <see cref="hDevNames"/> members,
        /// see the Remarks section at the end of this topic.
        /// </para>
        /// </summary>
        public HGLOBAL hDevNames;

        /// <summary>
        /// A handle to a device context or an information context, depending on whether the <see cref="Flags"/> member
        /// specifies the <see cref="PD_RETURNDC"/> or <see cref="PD_RETURNIC"/> flag.
        /// If neither flag is specified, the value of this member is undefined.
        /// If both flags are specified, <see cref="PD_RETURNDC"/> has priority.
        /// </summary>
        public HDC hDC;

        /// <summary>
        /// <para>
        /// A set of bit flags that you can use to initialize the Print property sheet.
        /// When the <see cref="PrintDlgEx"/> function returns, it sets these flags to indicate the user's input.
        /// This member can be one or more of the following values.
        /// </para>
        /// <para>
        /// To ensure that <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/> returns the correct values
        /// in the <see cref="DEVMODE.dmCopies"/> and <see cref="DEVMODE.dmCollate"/> members of the <see cref="DEVMODE"/> structure,
        /// set <see cref="PD_RETURNDC"/> = <see cref="TRUE"/> and <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> = <see cref="TRUE"/>.
        /// In so doing, the <see cref="nCopies"/> member of the <see cref="PRINTDLG"/> structure is always 1
        /// and <see cref="PD_COLLATE"/> is always <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// To ensure that <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/> returns the correct values
        /// in <see cref="nCopies"/> and <see cref="PD_COLLATE"/>,
        /// set <see cref="PD_RETURNDC"/> = <see cref="TRUE"/> and <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> = <see cref="FALSE"/>.
        /// In so doing, <see cref="DEVMODE.dmCopies"/> is always 1 and <see cref="DEVMODE.dmCollate"/> is always <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// Starting with Windows Vista, when you call <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/>
        /// with <see cref="PD_RETURNDC"/> set to <see cref="TRUE"/> and <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> set to <see cref="FALSE"/>,
        /// the <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/> function sets the number of copies
        /// in the <see cref="nCopies"/> member of the <see cref="PRINTDLG"/> structure,
        /// and it sets the number of copies in the structure represented by the <see cref="hDC"/> member of the <see cref="PRINTDLG"/> structure.
        /// </para>
        /// <para>
        /// When making calls to GDI, you must ignore the value of <see cref="nCopies"/>, consider the value as 1,
        /// and use the returned <see cref="hDC"/> to avoid printing duplicate copies.
        /// </para>
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
        /// <see cref="PD_ALLPAGES"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// The default flag that indicates that the All radio button is initially selected.
        /// This flag is used as a placeholder to indicate that the <see cref="PD_PAGENUMS"/>,
        /// <see cref="PD_SELECTION"/>, and <see cref="PD_CURRENTPAGE"/> flags are not specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_COLLATE"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// If this flag is set, the Collate check box is selected.
        /// </para>
        /// <para>
        /// If this flag is set when the <see cref="PrintDlgEx"/> function returns,
        /// the application must simulate collation of multiple copies.
        /// For more information, see the description of the <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> flag.
        /// </para>
        /// <para>
        /// See <see cref="PD_NOPAGENUMS"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_CURRENTPAGE"/>
        /// </para>
        /// <para>
        /// 0x00400000
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, the Current Page radio button is selected.
        /// If none of the <see cref="PD_PAGENUMS"/>, <see cref="PD_SELECTION"/>,
        /// or <see cref="PD_CURRENTPAGE"/> flags is set, the All radio button is selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_DISABLEPRINTTOFILE"/>
        /// </para>
        /// <para>
        /// 0x00080000
        /// </para>
        /// </term>
        /// <term>
        /// Disables the Print to File check box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_ENABLEPRINTTEMPLATE"/>
        /// </para>
        /// <para>
        /// 0x00004000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <see cref="hInstance"/> and <see cref="lpPrintTemplateName"/> members
        /// specify a replacement for the default dialog box template in the lower portion of the General page.
        /// The default template contains controls similar to those of the Print dialog box.
        /// The system uses the specified template to create a window that is a child of the General page.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_ENABLEPRINTTEMPLATEHANDLE"/>
        /// </para>
        /// <para>
        /// 0x00010000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <see cref="hInstance"/> member identifies a data block that contains a preloaded dialog box template.
        /// This template replaces the default dialog box template in the lower portion of the General page.
        /// The system uses the specified template to create a window that is a child of the General page.
        /// The system ignores the <see cref="lpPrintTemplateName"/> member if this flag is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_EXCLUSIONFLAGS"/>
        /// </para>
        /// <para>
        /// 0x01000000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <see cref="ExclusionFlags"/> member identifies items to be excluded from the printer driver property pages.
        /// If this flag is not set, items will be excluded by default from the printer driver property pages.
        /// The exclusions prevent the duplication of items among the General page,
        /// any application-specified pages, and the printer driver pages.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_HIDEPRINTTOFILE"/>
        /// </para>
        /// <para>
        /// 0x00100000
        /// </para>
        /// </term>
        /// <term>
        /// Hides the Print to File check box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_NOCURRENTPAGE"/>
        /// </para>
        /// <para>
        /// 0x00800000
        /// </para>
        /// </term>
        /// <term>
        /// Disables the Current Page radio button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_NOPAGENUMS"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Disables the Pages radio button and the associated edit controls.
        /// Also, it causes the Collate check box to appear in the dialog.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_NOSELECTION"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Disables the Selection radio button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_NOWARNING"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// Prevents the warning message from being displayed when an error occurs.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_PAGENUMS"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, the Pages radio button is selected.
        /// If none of the <see cref="PD_PAGENUMS"/>, <see cref="PD_SELECTION"/>,
        /// or <see cref="PD_CURRENTPAGE"/> flags is set, the All radio button is selected.
        /// If this flag is set when the <see cref="PrintDlgEx"/> function returns,
        /// the <see cref="lpPageRanges"/> member indicates the page ranges specified by the user.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_PRINTTOFILE"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, the Print to File check box is selected.
        /// If this flag is set when <see cref="PrintDlgEx"/> returns, the offset indicated
        /// by the <see cref="DEVNAMES.wOutputOffset"/> member of the <see cref="DEVNAMES"/> structure contains the string "FILE:".
        /// When you call the <see cref="StartDoc"/> function to start the printing operation,
        /// specify this "FILE:" string in the <see cref="DOCINFO.lpszOutput"/> member of the <see cref="DOCINFO"/> structure.
        /// Specifying this string causes the print subsystem to query the user for the name of the output file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_RETURNDC"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// Causes <see cref="PrintDlgEx"/> to return a device context matching the selections the user made in the property sheet.
        /// The device context is returned in <see cref="hDC"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_RETURNDEFAULT"/>
        /// </para>
        /// <para>
        /// 0x00000400
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, the <see cref="PrintDlgEx"/> function does not display the property sheet.
        /// Instead, it sets the <see cref="hDevNames"/> and <see cref="hDevMode"/> members to handles
        /// to <see cref="DEVNAMES"/> and <see cref="DEVMODE"/> structures that are initialized for the system default printer.
        /// Both <see cref="hDevNames"/> and <see cref="hDevMode"/> must be <see cref="NULL"/>,
        /// or <see cref="PrintDlgEx"/> returns an error.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_RETURNIC"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// Similar to the <see cref="PD_RETURNDC"/> flag, except this flag returns an information context rather than a device context.
        /// If neither <see cref="PD_RETURNDC"/> nor <see cref="PD_RETURNIC"/> is specified, <see cref="hDC"/> is undefined on output.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_SELECTION"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, the Selection radio button is selected.
        /// If none of the <see cref="PD_PAGENUMS"/>, <see cref="PD_SELECTION"/>,
        /// or <see cref="PD_CURRENTPAGE"/> flags is set, the All radio button is selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_USEDEVMODECOPIES"/>
        /// </para>
        /// <para>
        /// 0x00040000
        /// </para>
        /// </term>
        /// <term>
        /// Same as <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/>
        /// </para>
        /// <para>
        /// 0x00040000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// This flag indicates whether your application supports multiple copies and collation.
        /// Set this flag on input to indicate that your application does not support multiple copies and collation.
        /// In this case, the <see cref="nCopies"/> member of the <see cref="PRINTDLGEX"/> structure always returns 1,
        /// and <see cref="PD_COLLATE"/> is never set in the <see cref="Flags"/> member.
        /// </para>
        /// <para>
        /// If this flag is not set, the application is responsible for printing and collating multiple copies.
        /// In this case, the <see cref="nCopies"/> member of the <see cref="PRINTDLGEX"/> structure
        /// indicates the number of copies the user wants to print,
        /// and the <see cref="PD_COLLATE"/> flag in the <see cref="Flags"/> member indicates whether the user wants collation.
        /// </para>
        /// <para>
        /// Regardless of whether this flag is set, an application can determine from <see cref="nCopies"/> and <see cref="PD_COLLATE"/>
        /// how many copies to render and whether to print them collated.
        /// </para>
        /// <para>
        /// If this flag is set and the printer driver does not support multiple copies, the Copies edit control is disabled.
        /// Similarly, if this flag is set and the printer driver does not support collation, the Collate check box is disabled.
        /// </para>
        /// <para>
        /// The <see cref="DEVMODE.dmCopies"/> and <see cref="DEVMODE.dmCollate"/> members of the <see cref="DEVMODE"/> structure
        /// contain the copies and collate information used by the printer driver.
        /// If this flag is set and the printer driver supports multiple copies,
        /// the <see cref="DEVMODE.dmCopies"/> member indicates the number of copies requested by the user.
        /// If this flag is set and the printer driver supports collation,
        /// the <see cref="DEVMODE.dmCollate"/> member of the <see cref="DEVMODE"/> structure indicates whether the user wants collation.
        /// If this flag is not set, the <see cref="DEVMODE.dmCopies"/> member always returns 1,
        /// and the <see cref="DEVMODE.dmCollate"/> member is always zero.
        /// </para>
        /// <para>
        /// In Windows versions prior to Windows Vista, if this flag is not set by the calling application
        /// and the <see cref="DEVMODE.dmCopies"/> member of the <see cref="DEVMODE"/> structure is greater than 1,
        /// use that value for the number of copies;
        /// otherwise, use the value of the <see cref="nCopies"/> member of the <see cref="PRINTDLGEX"/> structure.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_USELARGETEMPLATE"/>
        /// </para>
        /// <para>
        /// 0x10000000
        /// </para>
        /// </term>
        /// <term>
        /// Forces the property sheet to use a large template for the General page.
        /// The larger template provides more space for applications that specify a custom template for the lower portion of the General page.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public PRINTDLGFlags Flags;

        /// <summary>
        /// 
        /// </summary>
        public DWORD Flags2;

        /// <summary>
        /// <para>
        /// A set of bit flags that can exclude items from the printer driver property pages in the Print property sheet.
        /// This value is used only if the <see cref="PD_EXCLUSIONFLAGS"/> flag is set in the <see cref="Flags"/> member.
        /// Exclusion flags should be used only if the item to be excluded will be included on either the General page
        /// or on an application-defined page in the Print property sheet.
        /// This member can specify the following flag.
        /// </para>
        /// <para>
        /// <see cref="PD_EXCL_COPIESANDCOLLATE"/>
        /// </para>
        /// <para>
        /// Excludes the Copies> and Collate controls from the printer driver property pages in a Print property sheet.
        /// This flag should always be set when the application uses the default Copies and Collate controls
        /// provided by the lower portion of the General page of the Print property sheet.
        /// </para>
        /// </summary>
        public DWORD ExclusionFlags;

        /// <summary>
        /// On input, set this member to the initial number of page ranges specified in the <see cref="lpPageRanges"/> array.
        /// When the <see cref="PrintDlgEx"/> function returns, <see cref="nPageRanges"/> indicates the number of user-specified page ranges
        /// stored in the <see cref="lpPageRanges"/> array.
        /// If the <see cref="PD_NOPAGENUMS"/> flag is specified, this value is not valid.
        /// </summary>
        public DWORD nPageRanges;

        /// <summary>
        /// The size, in array elements, of the <see cref="lpPageRanges"/> buffer.
        /// This value indicates the maximum number of page ranges that can be stored in the array.
        /// If the <see cref="PD_NOPAGENUMS"/> flag is specified, this value is not valid.
        /// If the <see cref="PD_NOPAGENUMS"/> flag is not specified, this value must be greater than zero.
        /// </summary>
        public DWORD nMaxPageRanges;

        /// <summary>
        /// Pointer to a buffer containing an array of <see cref="PRINTPAGERANGE"/> structures.
        /// \On input, the array contains the initial page ranges to display in the Pages edit control.
        /// When the <see cref="PrintDlgEx"/> function returns, the array contains the page ranges specified by the user.
        /// If the <see cref="PD_NOPAGENUMS"/> flag is specified, this value is not valid.
        /// If the <see cref="PD_NOPAGENUMS"/> flag is not specified, <see cref="lpPageRanges"/> must be non-NULL.
        /// </summary>
        public IntPtr lpPageRanges;

        /// <summary>
        /// The minimum value for the page ranges specified in the Pages edit control.
        /// If the <see cref="PD_NOPAGENUMS"/> flag is specified, this value is not valid.
        /// </summary>
        public WORD nMinPage;

        /// <summary>
        /// The maximum value for the page ranges specified in the Pages edit control.
        /// If the <see cref="PD_NOPAGENUMS"/> flag is specified, this value is not valid.
        /// </summary>
        public WORD nMaxPage;

        /// <summary>
        /// The initial number of copies for the Copies edit control if <see cref="hDevMode"/> is <see cref="NULL"/>;
        /// otherwise, the <see cref="DEVMODE.dmCopies"/> member of the <see cref="DEVMODE"/> structure contains the initial value.
        /// When <see cref="PrintDlg"/> returns, <see cref="nCopies"/> contains the actual number of copies to print.
        /// This value depends on whether the application or the printer driver is responsible for printing multiple copies.
        /// If the <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> flag is set in the <see cref="Flags"/> member, <see cref="nCopies"/> is always 1 on return,
        /// and the printer driver is responsible for printing multiple copies.
        /// If the flag is not set, the application is responsible for printing the number of copies specified by <see cref="nCopies"/>.
        /// For more information, see the description of the <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> flag.
        /// </summary>
        public WORD nCopies;

        /// <summary>
        /// If the <see cref="PD_ENABLEPRINTTEMPLATE"/> flag is set in the <see cref="Flags"/> member,
        /// <see cref="hInstance"/> is a handle to the application or module instance that contains the dialog box template
        /// named by the <see cref="lpPrintTemplateName"/> member.
        /// If the <see cref="PD_ENABLEPRINTTEMPLATEHANDLE"/> flag is set in the <see cref="Flags"/> member,
        /// hInstance is a handle to a memory object containing a dialog box template.
        /// If neither of the template flags is set in the <see cref="Flags"/> member, <see cref="hInstance"/> should be <see cref="NULL"/>.
        /// </summary>
        public HINSTANCE hInstance;

        /// <summary>
        /// The name of the dialog box template resource in the module identified by the <see cref="hInstance"/> member.
        /// This template replaces the default dialog box template in the lower portion of the General page.
        /// The default template contains controls similar to those of the Print dialog box.
        /// This member is ignored unless the <see cref="PD_ENABLEPRINTTEMPLATE"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public IntPtr lpPrintTemplateName;

        /// <summary>
        /// <para>
        /// A pointer to an application-defined callback object.
        /// </para>
        /// <para>
        /// The object should contain the <see cref="IPrintDialogCallback"/> class
        /// to receive messages for the child dialog box in the lower portion of the General page.
        /// </para>
        /// <para>
        /// The callback object should also contain the <see cref="IObjectWithSite"/> class
        /// to receive a pointer to the <see cref="IPrintDialogServices"/> interface.
        /// The <see cref="PrintDlgEx"/> function calls <see cref="IUnknown.QueryInterface"/> on the callback object
        /// for both <see cref="IID_IPrintDialogCallback"/> and <see cref="IID_IObjectWithSite"/> to determine which interfaces are supported.
        /// </para>
        /// <para>
        /// If you do not want to retrieve any of the callback information, set <see cref="lpCallback"/> to <see cref="NULL"/>.
        /// </para>
        /// </summary>
        public P<IUnknown> lpCallback;

        /// <summary>
        /// The number of property page handles in the <see cref="lphPropertyPages"/> array.
        /// </summary>
        public DWORD nPropertyPages;

        /// <summary>
        /// Contains an array of property page handles to add to the Print property sheet.
        /// The additional property pages follow the General page.
        /// Use the <see cref="CreatePropertySheetPage"/> function to create these additional pages.
        /// When the <see cref="PrintDlgEx"/> function returns, all the <see cref="HPROPSHEETPAGE"/> handles
        /// in the <see cref="lphPropertyPages"/> array have been destroyed.
        /// If <see cref="nPropertyPages"/> is zero, <see cref="lphPropertyPages"/> should be <see cref="NULL"/>.
        /// </summary>
        public IntPtr lphPropertyPages;

        /// <summary>
        /// The property page that is initially displayed.
        /// To display the General page, specify <see cref="START_PAGE_GENERAL"/>.
        /// Otherwise, specify the zero-based index of a property page in the array specified in the <see cref="lphPropertyPages"/> member.
        /// For consistency, it is recommended that the property sheet always be started on the General page.
        /// </summary>
        public DWORD nStartPage;

        /// <summary>
        /// <para>
        /// On input, set this member to zero.
        /// If the <see cref="PrintDlgEx"/> function returns <see cref="S_OK"/>, <see cref="dwResultAction"/> contains the outcome of the dialog.
        /// If <see cref="PrintDlgEx"/> returns an error, this member should be ignored.
        /// The <see cref="dwResultAction"/> member can be one of the following values.
        /// </para>
        /// <para>
        /// <see cref="PD_RESULT_APPLY"/>
        /// </para>
        /// <para>
        /// The user clicked the Apply button and later clicked the Cancel button.
        /// This indicates that the user wants to apply the changes made in the property sheet, but does not want to print yet.
        /// The <see cref="PRINTDLGEX"/> structure contains the information specified by the user at the time the Apply button was clicked.
        /// </para>
        /// <para>
        /// <see cref="PD_RESULT_CANCEL"/>
        /// </para>
        /// <para>
        /// The user clicked the Cancel button.
        /// The information in the <see cref="PRINTDLGEX"/> structure is unchanged.
        /// </para>
        /// <para>
        /// <see cref="PD_RESULT_PRINT"/>
        /// </para>
        /// <para>
        /// The user clicked the Print button.
        /// The <see cref="PRINTDLGEX"/> structure contains the information specified by the user.
        /// </para>
        /// </summary>
        public DWORD dwResultAction;
    }
}
