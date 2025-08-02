using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.PRINTDLGFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that the <see cref="PrintDlg"/> function uses to initialize the Print Dialog Box.
    /// After the user closes the dialog box, the system uses this structure to return information about the user's selections.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-printdlgw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If both <see cref="hDevMode"/> and <see cref="hDevNames"/> are <see cref="NULL"/>,
    /// <see cref="PrintDlg"/> initializes the dialog box using the current default printer.
    /// To initialize the dialog box for a different printer,
    /// use the <see cref="DEVNAMES.wDeviceOffset"/> member of the <see cref="DEVNAMES"/> structure to specify the name of the printer.
    /// </para>
    /// <para>
    /// Note that the <see cref="DEVMODE.dmDeviceName"/> member of the <see cref="DEVMODE"/> structure also specifies a printer name.
    /// However, <see cref="DEVMODE.dmDeviceName"/> is limited to 32 characters, and the <see cref="DEVNAMES.wDeviceOffset"/> name is not.
    /// If the <see cref="DEVNAMES.wDeviceOffset"/> and <see cref="DEVMODE.dmDeviceName"/> names are not the same,
    /// <see cref="PrintDlg"/> initializes the dialog box using the printer specified by <see cref="DEVNAMES.wDeviceOffset"/>.
    /// </para>
    /// <para>
    /// If the <see cref="PD_RETURNDEFAULT"/> flag is set and both <see cref="hDevMode"/> and <see cref="hDevNames"/> are <see cref="NULL"/>,
    /// <see cref="PrintDlg"/> uses the <see cref="hDevNames"/> and <see cref="hDevMode"/> members to return information
    /// about the current default printer without displaying the dialog box.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PRINTDLG
    {
        /// <summary>
        /// The structure size, in bytes.
        /// </summary>
        public DWORD lStructSize;

        /// <summary>
        /// A handle to the window that owns the dialog box.
        /// This member can be any valid window handle, or it can be <see cref="NULL"/> if the dialog box has no owner.
        /// </summary>
        public HWND hwndOwner;

        /// <summary>
        /// <para>
        /// A handle to a movable global memory object that contains a <see cref="DEVMODE"/> structure.
        /// If <see cref="hDevMode"/> is not <see cref="NULL"/> on input,
        /// you must allocate a movable block of memory for the <see cref="DEVMODE"/> structure and initialize its members.
        /// The <see cref="PrintDlg"/> function uses the input data to initialize the controls in the dialog box.
        /// When <see cref="PrintDlg"/> returns, the <see cref="DEVMODE"/> members indicate the user's input.
        /// </para>
        /// <para>
        /// If <see cref="hDevMode"/> is <see cref="NULL"/> on input,
        /// <see cref="PrintDlg"/> allocates memory for the <see cref="DEVMODE"/> structure,
        /// initializes its members to indicate the user's input, and returns a handle that identifies it.
        /// </para>
        /// <para>
        /// If the device driver for the specified printer does not support extended device modes,
        /// <see cref="hDevMode"/> is <see cref="NULL"/> when <see cref="PrintDlg"/> returns.
        /// </para>
        /// <para>
        /// If the device name (specified by the <see cref="DEVMODE.dmDeviceName"/> member of the <see cref="DEVMODE"/> structure)
        /// does not appear in the [devices] section of WIN.INI, <see cref="PrintDlg"/> returns an error.
        /// </para>
        /// <para>
        /// For more information about the <see cref="hDevMode"/> and <see cref="hDevNames"/> members,
        /// see the Remarks section at the end of this topic.
        /// </para>
        /// </summary>
        public HGLOBAL hDevMode;

        /// <summary>
        /// <para>
        /// A handle to a movable global memory object that contains a <see cref="DEVNAMES"/> structure.
        /// If <see cref="hDevNames"/> is not <see cref="NULL"/> on input,
        /// you must allocate a movable block of memory for the <see cref="DEVNAMES"/> structure and initialize its members.
        /// The <see cref="PrintDlg"/> function uses the input data to initialize the controls in the dialog box.
        /// When <see cref="PrintDlg"/> returns, the <see cref="DEVNAMES"/> members contain information for the printer chosen by the user.
        /// You can use this information to create a device context or an information context.
        /// </para>
        /// <para>
        /// The <see cref="hDevNames"/> member can be <see cref="NULL"/>, in which case,
        /// <see cref="PrintDlg"/> allocates memory for the <see cref="DEVNAMES"/> structure,
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
        /// Initializes the Print dialog box.
        /// When the dialog box returns, it sets these flags to indicate the user's input.
        /// This member can be one or more of the following values.
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
        /// This flag is used as a placeholder to indicate that the <see cref="PD_PAGENUMS"/> and <see cref="PD_SELECTION"/> flags are not specified.
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
        /// If this flag is set when the <see cref="PrintDlg"/> function returns,
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
        /// <see cref="PD_ENABLEPRINTHOOK"/>
        /// </para>
        /// <para>
        /// 0x00001000
        /// </para>
        /// </term>
        /// <term>
        /// Enables the hook procedure specified in the <see cref="lpfnPrintHook"/> member.
        /// This enables the hook procedure for the Print dialog box.
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
        /// Indicates that the <see cref="hInstance"/> and <see cref="lpPrintTemplateName"/> members specify a replacement
        /// for the default Print dialog box template.
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
        /// Indicates that the <see cref="hPrintTemplate"/> member identifies a data block that contains a preloaded dialog box template.
        /// This template replaces the default template for the Print dialog box.
        /// The system ignores the <see cref="lpPrintTemplateName"/> member if this flag is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_ENABLESETUPHOOK"/>
        /// </para>
        /// <para>
        /// 0x00002000
        /// </para>
        /// </term>
        /// <term>
        /// Enables the hook procedure specified in the <see cref="lpfnSetupHook"/> member.
        /// This enables the hook procedure for the Print Setup dialog box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_ENABLESETUPTEMPLATE"/>
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <see cref="hInstance"/> and <see cref="lpSetupTemplateName"/> members
        /// specify a replacement for the default Print Setup dialog box template.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_ENABLESETUPTEMPLATEHANDLE"/>
        /// </para>
        /// <para>
        /// 0x00020000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <see cref="hSetupTemplate"/> member identifies a data block that contains a preloaded dialog box template.
        /// This template replaces the default template for the Print Setup dialog box.
        /// The system ignores the lpSetupTemplateName member if this flag is specified.
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
        /// <see cref="PD_NONETWORKBUTTON"/>
        /// </para>
        /// <para>
        /// 0x00200000
        /// </para>
        /// </term>
        /// <term>
        /// Hides and disables the Network button.
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
        /// Prevents the warning message from being displayed when there is no default printer.
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
        /// If this flag is set when the <see cref="PrintDlg"/> function returns,
        /// the <see cref="nFromPage"/> and <see cref="nToPage"/> members indicate the starting and ending pages specified by the user.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_PRINTSETUP"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// Causes the system to display the Print Setup dialog box rather than the Print dialog box.
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
        /// If this flag is set when the <see cref="PrintDlg"/> function returns,
        /// the offset indicated by the <see cref="DEVNAMES.wOutputOffset"/> member of the <see cref="DEVNAMES"/> structure contains the string "FILE:".
        /// When you call the <see cref="StartDoc"/> function to start the printing operation,
        /// specify this "FILE:" string in the <see cref="lpszOutput"/> member of the <see cref="DOCINFO"/> structure.
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
        /// Causes <see cref="PrintDlg"/> to return a device context matching the selections the user made in the dialog box.
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
        /// If this flag is set, the <see cref="PrintDlg"/> function does not display the dialog box.
        /// Instead, it sets the <see cref="hDevNames"/> and <see cref="hDevMode"/> members to handles
        /// to <see cref="DEVMODE"/> and <see cref="DEVNAMES"/> structures that are initialized for the system default printer.
        /// Both <see cref="hDevNames"/> and <see cref="hDevMode"/> must be <see cref="NULL"/>, or <see cref="PrintDlg"/> returns an error.
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
        /// If neither <see cref="PD_PAGENUMS"/> nor <see cref="PD_SELECTION"/> is set, the All radio button is selected.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PD_SHOWHELP"/>
        /// </para>
        /// <para>
        /// 0x00000800
        /// </para>
        /// </term>
        /// <term>
        /// Causes the dialog box to display the Help button.
        /// The <see cref="hwndOwner"/> member must specify the window to receive the <see cref="HELPMSGSTRING"/> registered messages
        /// that the dialog box sends when the user clicks the Help button.
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
        /// In this case, the <see cref="nCopies"/> member of the <see cref="PRINTDLG"/> structure always returns 1,
        /// and <see cref="PD_COLLATE"/> is never set in the <see cref="Flags"/> member.
        /// </para>
        /// <para>
        /// If this flag is not set, the application is responsible for printing and collating multiple copies.
        /// In this case, the <see cref="nCopies"/> member of the <see cref="PRINTDLG"/> structure
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
        /// Known issue on Windows 2000/XP/2003: If this flag is not set before calling <see cref="PrintDlg"/>,
        /// <see cref="PrintDlg"/> might swap <see cref="nCopies"/> and <see cref="DEVMODE.dmCopies"/> values when it returns.
        /// The workaround for this issue is use <see cref="DEVMODE.dmCopies"/> if its value is larger than 1,
        /// else, use <see cref="nCopies"/>, for you to get the actual number of copies to be printed when <see cref="PrintDlg"/> returns.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// To ensure that <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/> returns the correct values
        /// in the <see cref="DEVMODE.dmCopies"/> and <see cref="DEVMODE.dmCollate"/> members of the <see cref="DEVMODE"/> structure,
        /// set <see cref="PD_RETURNDC"/> = <see cref="TRUE"/> and <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> = <see cref="TRUE"/>.
        /// In so doing, the <see cref="nCopies"/> member of the <see cref="PRINTDLG"/> structure is always 1
        /// and <see cref="PD_COLLATE"/> is always <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// To ensure that <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/> returns the correct values in <see cref="nCopies"/> and <see cref="PD_COLLATE"/>,
        /// set <see cref="PD_RETURNDC"/> = <see cref="TRUE"/> and <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> = <see cref="FALSE"/>.
        /// In so doing, <see cref="DEVMODE.dmCopies"/> is always 1 and <see cref="DEVMODE.dmCollate"/> is always <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// On Windows Vista and Windows 7, when you call <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/>
        /// with <see cref="PD_RETURNDC"/> set to <see cref="TRUE"/> and <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> set to <see cref="FALSE"/>,
        /// the <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/> function sets the number of copies
        /// in the <see cref="nCopies"/> member of the <see cref="PRINTDLG"/> structure,
        /// and it sets the number of copies in the structure represented by the hDC member of the <see cref="PRINTDLG"/> structure.
        /// </para>
        /// <para>
        /// When making calls to GDI, you must ignore the value of <see cref="nCopies"/>,
        /// consider the value as 1, and use the returned hDC to avoid printing duplicate copies.
        /// </para>
        /// </summary>
        public PRINTDLGFlags Flags;

        /// <summary>
        /// <para>
        /// The initial value for the starting page edit control.
        /// </para>
        /// <para>
        /// When <see cref="PrintDlg"/> returns, <see cref="nFromPage"/> is the starting page specified by the user.
        /// If the Pages radio button is selected when the user clicks the Okay button,
        /// <see cref="PrintDlg"/> sets the <see cref="PD_PAGENUMS"/> flag and does not return
        /// until the user enters a starting page value that is within the minimum to maximum page range.
        /// </para>
        /// <para>
        /// If the input value for either <see cref="nFromPage"/> or <see cref="nToPage"/> is outside the minimum/maximum range,
        /// <see cref="PrintDlg"/> returns an error only if the <see cref="PD_PAGENUMS"/> flag is specified;
        /// otherwise, it displays the dialog box but changes the out-of-range value to the minimum or maximum value.
        /// </para>
        /// </summary>
        public WORD nFromPage;

        /// <summary>
        /// The initial value for the ending page edit control.
        /// When <see cref="PrintDlg"/> returns, <see cref="nToPage"/> is the ending page specified by the user.
        /// If the Pages radio button is selected when the use clicks the Okay button,
        /// <see cref="PrintDlg"/> sets the <see cref="PD_PAGENUMS"/> flag and does not return
        /// until the user enters an ending page value that is within the minimum to maximum page range.
        /// </summary>
        public WORD nToPage;

        /// <summary>
        /// The minimum value for the page range specified in the From and To page edit controls.
        /// If <see cref="nMinPage"/> equals <see cref="nMaxPage"/>, the Pages radio button and the starting and ending page edit controls are disabled.
        /// </summary>
        public WORD nMinPage;

        /// <summary>
        /// The maximum value for the page range specified in the From and To page edit controls.
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
        /// If the <see cref="PD_ENABLEPRINTTEMPLATE"/> or <see cref="PD_ENABLESETUPTEMPLATE"/> flag is set in the <see cref="Flags"/> member,
        /// <see cref="hInstance"/> is a handle to the application or module instance that contains the dialog box template
        /// named by the <see cref="lpPrintTemplateName"/> or <see cref="lpSetupTemplateName"/> member.
        /// </summary>
        public HINSTANCE hInstance;

        /// <summary>
        /// Application-defined data that the system passes to the hook procedure identified
        /// by the <see cref="lpfnPrintHook"/> or <see cref="lpfnSetupHook"/> member.
        /// When the system sends the <see cref="WM_INITDIALOG"/> message to the hook procedure,
        /// the message's lParam parameter is a pointer to the <see cref="PRINTDLG"/> structure specified when the dialog was created.
        /// The hook procedure can use this pointer to get the <see cref="lCustData"/> value.
        /// </summary>
        public LPARAM lCustData;

        /// <summary>
        /// A pointer to a PrintHookProc hook procedure that can process messages intended for the Print dialog box.
        /// This member is ignored unless the <see cref="PD_ENABLEPRINTHOOK"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public LPPRINTHOOKPROC lpfnPrintHook;

        /// <summary>
        /// A pointer to a SetupHookProc hook procedure that can process messages intended for the Print Setup dialog box.
        /// This member is ignored unless the <see cref="PD_ENABLESETUPHOOK"/> flag is set in the Flags member.
        /// </summary>
        public LPSETUPHOOKPROC lpfnSetupHook;

        /// <summary>
        /// The name of the dialog box template resource in the module identified by the <see cref="hInstance"/> member.
        /// This template replaces the default Print dialog box template.
        /// This member is ignored unless the <see cref="PD_ENABLEPRINTTEMPLATE"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public IntPtr lpPrintTemplateName;

        /// <summary>
        /// The name of the dialog box template resource in the module identified by the <see cref="hInstance"/> member.
        /// This template replaces the default Print Setup dialog box template.
        /// This member is ignored unless the <see cref="PD_ENABLESETUPTEMPLATE"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public IntPtr lpSetupTemplateName;

        /// <summary>
        /// If the <see cref="PD_ENABLEPRINTTEMPLATEHANDLE"/> flag is set in the <see cref="Flags"/> member,
        /// <see cref="hPrintTemplate"/> is a handle to a memory object containing a dialog box template.
        /// This template replaces the default Print dialog box template.
        /// </summary>
        public HGLOBAL hPrintTemplate;

        /// <summary>
        /// If the <see cref="PD_ENABLESETUPTEMPLATEHANDLE"/> flag is set in the <see cref="Flags"/> member,
        /// <see cref="hSetupTemplate"/> is a handle to a memory object containing a dialog box template.
        /// This template replaces the default Print Setup dialog box template.
        /// </summary>
        public HGLOBAL hSetupTemplate;
    }
}
