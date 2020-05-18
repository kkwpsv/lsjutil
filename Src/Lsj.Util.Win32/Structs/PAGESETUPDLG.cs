using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.PAGESETUPDLGFlags;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information the <see cref="PageSetupDlg"/> function uses to initialize the Page Setup dialog box.
    /// After the user closes the dialog box, the system returns information about the user-defined page parameters in this structure.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/ns-commdlg-pagesetupdlgw
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the <see cref="PSD_INHUNDREDTHSOFMILLIMETERS"/> and <see cref="PSD_INTHOUSANDTHSOFINCHES"/> flags are not specified,
    /// the system queries the <see cref="LOCALE_IMEASURE"/> value of the default user locale to determine the unit of measure
    /// (either hundredths of millimeters or thousandths of inches) for the margin widths and paper size.
    /// If both <see cref="hDevNames"/> and <see cref="hDevMode"/> have valid handles
    /// and the printer name specified by the <see cref="DEVNAMES.wDeviceOffset"/> member of the <see cref="DEVNAMES"/> structure
    /// is not the same as the name specified by the <see cref="DEVMODE.dmDeviceName"/> member of the <see cref="DEVMODE"/> structure,
    /// the system uses the name specified by <see cref="DEVNAMES.wDeviceOffset"/> by default.
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
        /// A set of bit flags that you can use to initialize the Page Setup dialog box.
        /// When the dialog box returns, it sets these flags to indicate the user's input.
        /// This member can be one or more of the following values.
        /// <see cref="PSD_DEFAULTMINMARGINS"/>, <see cref="PSD_DISABLEMARGINS"/>, <see cref="PSD_DISABLEORIENTATION"/>,
        /// <see cref="PSD_DISABLEPAGEPAINTING"/>, <see cref="PSD_DISABLEPAPER"/>, <see cref="PSD_DISABLEPRINTER"/>,
        /// <see cref="PSD_ENABLEPAGEPAINTHOOK"/>, <see cref="PSD_ENABLEPAGESETUPHOOK"/>, <see cref="PSD_ENABLEPAGESETUPTEMPLATE"/>,
        /// <see cref="PSD_ENABLEPAGESETUPTEMPLATEHANDLE"/>, <see cref="PSD_INHUNDREDTHSOFMILLIMETERS"/>, <see cref="PSD_INTHOUSANDTHSOFINCHES"/>,
        /// <see cref="PSD_INWININIINTLMEASURE"/>, <see cref="PSD_MARGINS"/>, <see cref="PSD_MINMARGINS"/>, <see cref="PSD_NONETWORKBUTTON"/>,
        /// <see cref="PSD_NOWARNING"/>, <see cref="PSD_RETURNDEFAULT"/>, <see cref="PSD_SHOWHELP"/>
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
