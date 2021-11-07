using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Comdlg32;
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
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/ns-commdlg-printdlgw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If both <see cref="hDevMode"/> and <see cref="hDevNames"/> are <see cref="NULL"/>,
    /// PrintDlg initializes the dialog box using the current default printer.
    /// To initialize the dialog box for a different printer, use the <see cref="DEVNAMES.wDeviceOffset"/> member
    /// of the <see cref="DEVNAMES"/> structure to specify the name of the printer.
    /// Note that the <see cref="DEVMODE.dmDeviceName"/> member of the <see cref="DEVMODE"/> structure also specifies a printer name.
    /// However, <see cref="DEVMODE.dmDeviceName"/> is limited to 32 characters, and the <see cref="DEVNAMES.wDeviceOffset"/> name is not.
    /// If the <see cref="DEVNAMES.wDeviceOffset"/> and <see cref="DEVMODE.dmDeviceName"/> names are not the same,
    /// <see cref="PrintDlg"/> initializes the dialog box using the printer specified by <see cref="DEVNAMES.wDeviceOffset"/>.
    /// If the <see cref="PD_RETURNDEFAULT"/> flag is set and both <see cref="hDevMode"/> and <see cref="hDevNames"/> are <see cref="NULL"/>,
    /// <see cref="PrintDlg"/> uses the <see cref="hDevNames"/> and <see cref="hDevMode"/> members
    /// to return information about the current default printer without displaying the dialog box.
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
        /// A handle to a movable global memory object that contains a <see cref="DEVMODE"/> structure.
        /// If <see cref="hDevMode"/> is not <see cref="NULL"/> on input, you must allocate a movable block of memory
        /// for the <see cref="DEVMODE"/> structure and initialize its members.
        /// The <see cref="PrintDlg"/> function uses the input data to initialize the controls in the dialog box.
        /// When <see cref="PrintDlg"/> returns, the <see cref="DEVMODE"/> members indicate the user's input.
        /// If <see cref="hDevMode"/> is <see cref="NULL"/> on input, <see cref="PrintDlg"/> allocates memory
        /// for the <see cref="DEVMODE"/> structure, initializes its members to indicate the user's input, and returns a handle that identifies it.
        /// If the device driver for the specified printer does not support extended device modes,
        /// <see cref="hDevMode"/> is <see cref="NULL"/> when <see cref="PrintDlg"/> returns.
        /// If the device name (specified by the <see cref="DEVMODE.dmDeviceName"/> member of the <see cref="DEVMODE"/> structure) does not appear
        /// in the [devices] section of WIN.INI, <see cref="PrintDlg"/> returns an error.
        /// For more information about the <see cref="hDevMode"/> and <see cref="hDevNames"/> members, see the Remarks section at the end of this topic.
        /// </summary>
        public HGLOBAL hDevMode;

        /// <summary>
        /// A handle to a movable global memory object that contains a <see cref="DEVNAMES"/> structure.
        /// If <see cref="hDevNames"/> is not <see cref="NULL"/> on input, you must allocate a movable block of memory
        /// for the <see cref="DEVNAMES"/> structure and initialize its members.
        /// The <see cref="PrintDlg"/> function uses the input data to initialize the controls in the dialog box.
        /// When <see cref="PrintDlg"/> returns, the <see cref="DEVNAMES"/> members contain information for the printer chosen by the user.
        /// You can use this information to create a device context or an information context.
        /// The <see cref="hDevNames"/> member can be <see cref="NULL"/>, in which case, <see cref="PrintDlg"/> allocates memory
        /// for the <see cref="DEVNAMES"/> structure, initializes its members to indicate the user's input, and returns a handle that identifies it.
        /// For more information about the <see cref="hDevMode"/> and <see cref="hDevNames"/> members, see the Remarks section at the end of this topic.
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
        /// Initializes the Print dialog box.
        /// When the dialog box returns, it sets these flags to indicate the user's input.
        /// This member can be one or more of the following values.
        /// <see cref="PD_ALLPAGES"/>, <see cref="PD_COLLATE"/>, <see cref="PD_DISABLEPRINTTOFILE"/>, <see cref="PD_ENABLEPRINTHOOK"/>,
        /// <see cref="PD_ENABLEPRINTTEMPLATE"/>, <see cref="PD_ENABLEPRINTTEMPLATEHANDLE"/>, <see cref="PD_ENABLESETUPHOOK"/>,
        /// <see cref="PD_ENABLESETUPTEMPLATE"/>, <see cref="PD_ENABLESETUPTEMPLATEHANDLE"/>, <see cref="PD_HIDEPRINTTOFILE"/>,
        /// <see cref="PD_NONETWORKBUTTON"/>, <see cref="PD_NOPAGENUMS"/>, <see cref="PD_NOSELECTION"/>, <see cref="PD_NOWARNING"/>,
        /// <see cref="PD_PAGENUMS"/>, <see cref="PD_PRINTSETUP"/>, <see cref="PD_PRINTTOFILE"/>, <see cref="PD_RETURNDC"/>,
        /// <see cref="PD_RETURNDEFAULT"/>, <see cref="PD_RETURNIC"/>, <see cref="PD_SELECTION"/>, <see cref="PD_SHOWHELP"/>,
        /// <see cref="PD_USEDEVMODECOPIES"/>, <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/>.
        /// To ensure that <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/> returns the correct values
        /// in the <see cref="DEVMODE.dmCopies"/> and <see cref="DEVMODE.dmCollate"/> members of the <see cref="DEVMODE"/> structure,
        /// set <see cref="PD_RETURNDC"/> = <see cref="TRUE"/> and <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> = <see cref="TRUE"/>.
        /// In so doing, the <see cref="PRINTDLG.nCopies"/> member of the <see cref="PRINTDLG"/> structure
        /// is always 1 and <see cref="PD_COLLATE"/> is always <see cref="FALSE"/>.
        /// To ensure that <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/> returns the correct values in <see cref="nCopies"/> and <see cref="PD_COLLATE"/>,
        /// set <see cref="PD_RETURNDC"/> = <see cref="TRUE"/> and <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> = <see cref="FALSE"/>.
        /// In so doing, <see cref="DEVMODE.dmCopies"/> is always 1 and <see cref="DEVMODE.dmCollate"/> is always <see cref="FALSE"/>.
        /// On Windows Vista and Windows 7, when you call <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/>
        /// with <see cref="PD_RETURNDC"/> set to <see cref="TRUE"/> and <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> set to <see cref="FALSE"/>,
        /// the <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/> function sets the number of copies in the <see cref="nCopies"/> member
        /// of the <see cref="PRINTDLG"/> structure, and it sets the number of copies in the structure represented
        /// by the <see cref="hDC"/> member of the <see cref="PRINTDLG"/> structure.
        /// When making calls to GDI, you must ignore the value of <see cref="nCopies"/>, consider the value as 1,
        /// and use the returned <see cref="hDC"/> to avoid printing duplicate copies.
        /// </summary>
        public PRINTDLGFlags Flags;

        /// <summary>
        /// The initial value for the starting page edit control.
        /// When <see cref="PrintDlg"/> returns, <see cref="nFromPage"/> is the starting page specified by the user.
        /// If the Pages radio button is selected when the user clicks the Okay button,
        /// <see cref="PrintDlg"/> sets the <see cref="PD_PAGENUMS"/> flag and does not return until the user enters a starting page value
        /// that is within the minimum to maximum page range.
        /// If the input value for either <see cref="nFromPage"/> or <see cref="nToPage"/> is outside the minimum/maximum range,
        /// PrintDlg returns an error only if the <see cref="PD_PAGENUMS"/> flag is specified;
        /// otherwise, it displays the dialog box but changes the out-of-range value to the minimum or maximum value.
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
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpPrintTemplateName;

        /// <summary>
        /// The name of the dialog box template resource in the module identified by the <see cref="hInstance"/> member.
        /// This template replaces the default Print Setup dialog box template.
        /// This member is ignored unless the <see cref="PD_ENABLESETUPTEMPLATE"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpSetupTemplateName;

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
