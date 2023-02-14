using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="PAGESETUPDLG"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-pagesetupdlgw"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum PAGESETUPDLGFlags : uint
    {
        /// <summary>
        /// Sets the minimum values that the user can specify for the page margins to be the minimum margins allowed by the printer.
        /// This is the default.
        /// This flag is ignored if the <see cref="PSD_MARGINS"/> and <see cref="PSD_MINMARGINS"/> flags are also specified.
        /// </summary>
        PSD_DEFAULTMINMARGINS = 0x00000000,

        /// <summary>
        /// Disables the margin controls, preventing the user from setting the margins.
        /// </summary>
        PSD_DISABLEMARGINS = 0x00000010,

        /// <summary>
        /// Disables the orientation controls, preventing the user from setting the page orientation.
        /// </summary>
        PSD_DISABLEORIENTATION = 0x00000100,

        /// <summary>
        /// Prevents the dialog box from drawing the contents of the sample page.
        /// If you enable a PagePaintHook hook procedure, you can still draw the contents of the sample page.
        /// </summary>
        PSD_DISABLEPAGEPAINTING = 0x00080000,

        /// <summary>
        /// Disables the paper controls, preventing the user from setting page parameters such as the paper size and source.
        /// </summary>
        PSD_DISABLEPAPER = 0x00000200,

        /// <summary>
        /// Windows XP/2000:
        /// Disables the Printer button, preventing the user from invoking a dialog box that contains additional printer setup information.
        /// </summary>
        [Obsolete]
        PSD_DISABLEPRINTER = 0x00000020,

        /// <summary>
        /// Enables the hook procedure specified in the <see cref="PAGESETUPDLG.lpfnPagePaintHook"/> member.
        /// </summary>
        PSD_ENABLEPAGEPAINTHOOK = 0x00040000,

        /// <summary>
        /// Enables the hook procedure specified in the <see cref="PAGESETUPDLG.lpfnPageSetupHook"/> member.
        /// </summary>
        PSD_ENABLEPAGESETUPHOOK = 0x00002000,

        /// <summary>
        /// Indicates that the <see cref="PAGESETUPDLG.hInstance"/> and <see cref="PAGESETUPDLG.lpPageSetupTemplateName"/> members
        /// specify a dialog box template to use in place of the default template.
        /// </summary>
        PSD_ENABLEPAGESETUPTEMPLATE = 0x00008000,

        /// <summary>
        /// Indicates that the <see cref="PAGESETUPDLG.hPageSetupTemplate"/> member identifies a data block that contains a preloaded dialog box template.
        /// The system ignores the <see cref="PAGESETUPDLG.lpPageSetupTemplateName"/> member if this flag is specified.
        /// </summary>
        PSD_ENABLEPAGESETUPTEMPLATEHANDLE = 0x00020000,

        /// <summary>
        /// Indicates that hundredths of millimeters are the unit of measurement for margins and paper size.
        /// The values in the <see cref="PAGESETUPDLG.rtMargin"/>, <see cref="PAGESETUPDLG.rtMinMargin"/>,
        /// and <see cref="PAGESETUPDLG.ptPaperSize"/> members are in hundredths of millimeters.
        /// You can set this flag on input to override the default unit of measurement for the user's locale.
        /// When the function returns, the dialog box sets this flag to indicate the units used.
        /// </summary>
        PSD_INHUNDREDTHSOFMILLIMETERS = 0x00000008,

        /// <summary>
        /// Indicates that thousandths of inches are the unit of measurement for margins and paper size.
        /// The values in the <see cref="PAGESETUPDLG.rtMargin"/>, <see cref="PAGESETUPDLG.rtMinMargin"/>,
        /// and <see cref="PAGESETUPDLG.ptPaperSize"/> members are in thousandths of inches.
        /// You can set this flag on input to override the default unit of measurement for the user's locale.
        /// When the function returns, the dialog box sets this flag to indicate the units used.
        /// </summary>
        PSD_INTHOUSANDTHSOFINCHES = 0x00000004,

        /// <summary>
        /// Reserved.
        /// </summary>
        PSD_INWININIINTLMEASURE = 0x00000000,

        /// <summary>
        /// Causes the system to use the values specified in the <see cref="PAGESETUPDLG.rtMargin"/> member as the initial widths
        /// for the left, top, right, and bottom margins.
        /// If <see cref="PSD_MARGINS"/> is not set, the system sets the initial widths to one inch for all margins.
        /// </summary>
        PSD_MARGINS = 0x00000002,

        /// <summary>
        /// Causes the system to use the values specified in the <see cref="PAGESETUPDLG.rtMinMargin"/> member as the minimum allowable widths
        /// for the left, top, right, and bottom margins.
        /// The system prevents the user from entering a width that is less than the specified minimum.
        /// If <see cref="PSD_MINMARGINS"/> is not specified, the system sets the minimum allowable widths to those allowed by the printer.
        /// </summary>
        PSD_MINMARGINS = 0x00000001,

        /// <summary>
        /// Hides and disables the Network button.
        /// </summary>
        PSD_NONETWORKBUTTON = 0x00200000,

        /// <summary>
        /// Prevents the system from displaying a warning message when there is no default printer.
        /// </summary>
        PSD_NOWARNING = 0x00000080,

        /// <summary>
        /// <see cref="PageSetupDlg"/> does not display the dialog box.
        /// Instead, it sets the <see cref="PAGESETUPDLG.hDevNames"/> and <see cref="PAGESETUPDLG.hDevMode"/> members
        /// to handles to <see cref="DEVMODE"/> and <see cref="DEVNAMES"/> structures that are initialized for the system default printer.
        /// <see cref="PageSetupDlg"/> returns an error if either <see cref="PAGESETUPDLG.hDevNames"/>
        /// or <see cref="PAGESETUPDLG.hDevMode"/> is not <see cref="NULL"/>.
        /// </summary>
        PSD_RETURNDEFAULT = 0x00000400,

        /// <summary>
        /// Causes the dialog box to display the Help button.
        /// The <see cref="PAGESETUPDLG.hwndOwner"/> member must specify the window to receive the <see cref="HELPMSGSTRING"/> registered messages
        /// that the dialog box sends when the user clicks the Help button.
        /// </summary>
        PSD_SHOWHELP = 0x00000800,
    }
}
