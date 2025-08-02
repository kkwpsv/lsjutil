using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.PAGESETUPDLGFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.BaseTypes.LCID;
using Lsj.Util.Win32.Callbacks;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information the <see cref="PageSetupDlg"/> function uses to initialize the Page Setup dialog box.
    /// After the user closes the dialog box, the system returns information about the user-defined page parameters in this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-pagesetupdlgw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the <see cref="PSD_INHUNDREDTHSOFMILLIMETERS"/> and <see cref="PSD_INTHOUSANDTHSOFINCHES"/> flags are not specified,
    /// the system queries the <see cref="LOCALE_IMEASURE"/> value of the default user locale to determine the unit of measure
    /// (either hundredths of millimeters or thousandths of inches) for the margin widths and paper size.
    /// </para>
    /// <para>
    /// If both <see cref="hDevNames"/> and <see cref="hDevMode"/> have valid handles and the printer name
    /// specified by the <see cref="DEVNAMES.wDeviceOffset"/> member of the <see cref="DEVNAMES"/> structure
    /// is not the same as the name specified by the <see cref="DEVMODE.dmDeviceName"/> member of the <see cref="DEVMODE"/> structure,
    /// the system uses the name specified by <see cref="DEVNAMES.wDeviceOffset"/> by default.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PAGESETUPDLG
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public DWORD lStructSize;

        /// <summary>
        /// A handle to the window that owns the dialog box.
        /// This member can be any valid window handle, or it can be <see cref="NULL"/> if the dialog box has no owner.
        /// </summary>
        public HWND hwndOwner;

        /// <summary>
        /// A handle to a global memory object that contains a <see cref="DEVMODE"/> structure.
        /// On input, if a handle is specified, the values in the corresponding <see cref="DEVMODE"/> structure
        /// are used to initialize the controls in the dialog box.
        /// On output, the dialog box sets <see cref="hDevMode"/> to a global memory handle to a <see cref="DEVMODE"/> structure
        /// that contains values specifying the user's selections.
        /// If the user's selections are not available, the dialog box sets <see cref="hDevMode"/> to <see cref="NULL"/>.
        /// </summary>
        public HGLOBAL hDevMode;

        /// <summary>
        /// A handle to a global memory object that contains a <see cref="DEVNAMES"/> structure.
        /// This structure contains three strings that specify the driver name, the printer name, and the output port name.
        /// On input, if a handle is specified, the strings in the corresponding <see cref="DEVNAMES"/> structure
        /// are used to initialize controls in the dialog box.
        /// On output, the dialog box sets <see cref="hDevNames"/> to a global memory handle to a <see cref="DEVNAMES"/> structure
        /// that contains strings specifying the user's selections.
        /// If the user's selections are not available, the dialog box sets <see cref="hDevNames"/> to <see cref="NULL"/>.
        /// </summary>
        public HGLOBAL hDevNames;

        /// <summary>
        /// <para>
        /// A set of bit flags that you can use to initialize the Page Setup dialog box.
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
        /// <see cref="PSD_DEFAULTMINMARGINS"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// Sets the minimum values that the user can specify for the page margins to be the minimum margins allowed by the printer.
        /// This is the default.
        /// This flag is ignored if the <see cref="PSD_MARGINS"/> and <see cref="PSD_MINMARGINS"/> flags are also specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_DISABLEMARGINS"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Disables the margin controls, preventing the user from setting the margins.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_DISABLEORIENTATION"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// Disables the orientation controls, preventing the user from setting the page orientation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_DISABLEPAGEPAINTING"/>
        /// </para>
        /// <para>
        /// 0x00080000
        /// </para>
        /// </term>
        /// <term>
        /// Prevents the dialog box from drawing the contents of the sample page.
        /// If you enable a PagePaintHook hook procedure, you can still draw the contents of the sample page.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_DISABLEPAPER"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// Disables the paper controls, preventing the user from setting page parameters such as the paper size and source.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_DISABLEPRINTER"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Obsolete.
        /// </para>
        /// <para>
        /// Windows XP/2000: Disables the Printer button, preventing the user from invoking a dialog box that contains additional printer setup information.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_ENABLEPAGEPAINTHOOK"/>
        /// </para>
        /// <para>
        /// 0x00040000
        /// </para>
        /// </term>
        /// <term>
        /// Enables the hook procedure specified in the <see cref="lpfnPagePaintHook"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_ENABLEPAGESETUPHOOK"/>
        /// </para>
        /// <para>
        /// 0x00002000
        /// </para>
        /// </term>
        /// <term>
        /// Enables the hook procedure specified in the <see cref="lpfnPageSetupHook"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_ENABLEPAGESETUPTEMPLATE"/>
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <see cref="hInstance"/> and <see cref="lpPageSetupTemplateName"/> members
        /// specify a dialog box template to use in place of the default template.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_ENABLEPAGESETUPTEMPLATEHANDLE"/>
        /// </para>
        /// <para>
        /// 0x00020000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <see cref="hPageSetupTemplate"/> member identifies a data block that contains a preloaded dialog box template.
        /// The system ignores the <see cref="lpPageSetupTemplateName"/> member if this flag is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_INHUNDREDTHSOFMILLIMETERS"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that hundredths of millimeters are the unit of measurement for margins and paper size.
        /// The values in the <see cref="rtMargin"/>, <see cref="rtMinMargin"/>,
        /// and <see cref="ptPaperSize"/> members are in hundredths of millimeters.
        /// You can set this flag on input to override the default unit of measurement for the user's locale.
        /// When the function returns, the dialog box sets this flag to indicate the units used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_INTHOUSANDTHSOFINCHES"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that thousandths of inches are the unit of measurement for margins and paper size.
        /// The values in the <see cref="rtMargin"/>, <see cref="rtMinMargin"/>,
        /// and <see cref="ptPaperSize"/> members are in thousandths of inches.
        /// You can set this flag on input to override the default unit of measurement for the user's locale.
        /// When the function returns, the dialog box sets this flag to indicate the units used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_INWININIINTLMEASURE"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// Reserved.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_MARGINS"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Causes the system to use the values specified in the <see cref="rtMargin"/> member
        /// as the initial widths for the left, top, right, and bottom margins.
        /// If <see cref="PSD_MARGINS"/> is not set, the system sets the initial widths to one inch for all margins.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_MINMARGINS"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Causes the system to use the values specified in the <see cref="rtMinMargin"/> member
        /// as the minimum allowable widths for the left, top, right, and bottom margins.
        /// The system prevents the user from entering a width that is less than the specified minimum.
        /// If <see cref="PSD_MINMARGINS"/> is not specified, the system sets the minimum allowable widths to those allowed by the printer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_NONETWORKBUTTON"/>
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
        /// <see cref="PSD_NOWARNING"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// Prevents the system from displaying a warning message when there is no default printer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_RETURNDEFAULT"/>
        /// </para>
        /// <para>
        /// 0x00000400
        /// </para>
        /// </term>
        /// <term>
        /// <see cref="PageSetupDlg"/> does not display the dialog box.
        /// Instead, it sets the <see cref="hDevNames"/> and <see cref="hDevMode"/> members
        /// to handles to <see cref="DEVMODE"/> and <see cref="DEVNAMES"/> structures that are initialized for the system default printer.
        /// <see cref="PageSetupDlg"/> returns an error if either <see cref="hDevNames"/> or <see cref="hDevMode"/> is not <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="PSD_SHOWHELP"/>
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
        /// </list>
        /// </summary>
        public PAGESETUPDLGFlags Flags;

        /// <summary>
        /// The dimensions of the paper selected by the user.
        /// The <see cref="PSD_INTHOUSANDTHSOFINCHES"/> or <see cref="PSD_INHUNDREDTHSOFMILLIMETERS"/> flag indicates the units of measurement.
        /// </summary>
        public POINT ptPaperSize;

        /// <summary>
        /// The minimum allowable widths for the left, top, right, and bottom margins.
        /// The system ignores this member if the <see cref="PSD_MINMARGINS"/> flag is not set.
        /// These values must be less than or equal to the values specified in the <see cref="rtMargin"/> member.
        /// The <see cref="PSD_INTHOUSANDTHSOFINCHES"/> or <see cref="PSD_INHUNDREDTHSOFMILLIMETERS"/> flag indicates the units of measurement.
        /// </summary>
        public RECT rtMinMargin;

        /// <summary>
        /// The widths of the left, top, right, and bottom margins.
        /// If you set the <see cref="PSD_MARGINS"/> flag, <see cref="rtMargin"/> specifies the initial margin values.
        /// When <see cref="PageSetupDlg"/> returns, <see cref="rtMargin"/> contains the margin widths selected by the user.
        /// The <see cref="PSD_INHUNDREDTHSOFMILLIMETERS"/> or <see cref="PSD_INTHOUSANDTHSOFINCHES"/> flag indicates the units of measurement.
        /// </summary>
        public RECT rtMargin;

        /// <summary>
        /// If the <see cref="PSD_ENABLEPAGESETUPTEMPLATE"/> flag is set in the <see cref="Flags"/> member,
        /// <see cref="hInstance"/> is a handle to the application or module instance that contains the dialog box template
        /// named by the <see cref="lpPageSetupTemplateName"/> member.
        /// </summary>
        public HINSTANCE hInstance;

        /// <summary>
        /// Application-defined data that the system passes to the hook procedure identified by the <see cref="lpfnPageSetupHook"/> member.
        /// When the system sends the <see cref="WM_INITDIALOG"/> message to the hook procedure, 
        /// the message's lParam parameter is a pointer to the <see cref="PAGESETUPDLG"/> structure specified when the dialog was created.
        /// The hook procedure can use this pointer to get the <see cref="lCustData"/> value.
        /// </summary>
        public LPARAM lCustData;

        /// <summary>
        /// A pointer to a PageSetupHook hook procedure that can process messages intended for the dialog box.
        /// This member is ignored unless the <see cref="PSD_ENABLEPAGESETUPHOOK"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public LPPAGESETUPHOOK lpfnPageSetupHook;

        /// <summary>
        /// A pointer to a PagePaintHook hook procedure that receives WM_PSD_* messages from the dialog box whenever the sample page is redrawn.
        /// By processing the messages, the hook procedure can customize the appearance of the sample page.
        /// This member is ignored unless the <see cref="PSD_ENABLEPAGEPAINTHOOK"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public LPPAGEPAINTHOOK lpfnPagePaintHook;

        /// <summary>
        /// The name of the dialog box template resource in the module identified by the hInstance member.
        /// This template is substituted for the standard dialog box template.
        /// For numbered dialog box resources, <see cref="lpPageSetupTemplateName"/> can be a value returned by the <see cref="MAKEINTRESOURCE"/> macro.
        /// This member is ignored unless the <see cref="PSD_ENABLEPAGESETUPTEMPLATE"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public IntPtr lpPageSetupTemplateName;

        /// <summary>
        /// If the <see cref="PSD_ENABLEPAGESETUPTEMPLATEHANDLE"/> flag is set in the <see cref="Flags"/> member,
        /// <see cref="hPageSetupTemplate"/> is a handle to a memory object containing a dialog box template.
        /// </summary>
        public HGLOBAL hPageSetupTemplate;
    }
}
