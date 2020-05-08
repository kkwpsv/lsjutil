using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="PRINTDLG"/> Flags
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/ns-commdlg-printdlgw
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/ns-commdlg-printdlgexw
    /// </para>
    /// </summary>
    [Flags]
    public enum PRINTDLGFlags : uint
    {
        /// <summary>
        /// The default flag that indicates that the All radio button is initially selected.
        /// This flag is used as a placeholder to indicate that the <see cref="PD_PAGENUMS"/> and <see cref="PD_SELECTION"/> flags are not specified.
        /// </summary>
        PD_ALLPAGES = 0x00000000,

        /// <summary>
        /// If this flag is set, the Collate check box is selected.
        /// If this flag is set when the <see cref="PrintDlg"/> function returns, the application must simulate collation of multiple copies.
        /// For more information, see the description of the <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/> flag.
        /// See <see cref="PD_NOPAGENUMS"/>.
        /// </summary>
        PD_COLLATE = 0x00000010,

        /// <summary>
        /// If this flag is set, the Current Page radio button is selected.
        /// If none of the <see cref="PD_PAGENUMS"/>, <see cref="PD_SELECTION"/>, or <see cref="PD_CURRENTPAGE"/> flags is set,
        /// the All radio button is selected.
        /// </summary>
        PD_CURRENTPAGE = 0x00400000,

        /// <summary>
        /// Disables the Print to File check box.
        /// </summary>
        PD_DISABLEPRINTTOFILE = 0x00080000,

        /// <summary>
        /// Enables the hook procedure specified in the <see cref="PRINTDLG.lpfnPrintHook"/> member.
        /// This enables the hook procedure for the Print dialog box.
        /// </summary>
        PD_ENABLEPRINTHOOK = 0x00001000,

        /// <summary>
        /// Indicates that the <see cref="PRINTDLG.hInstance"/> and <see cref="PRINTDLG.lpPrintTemplateName"/> members
        /// specify a replacement for the default Print dialog box template.
        /// </summary>
        PD_ENABLEPRINTTEMPLATE = 0x00004000,

        /// <summary>
        /// Indicates that the <see cref="PRINTDLG.hPrintTemplate"/> member identifies a data block that contains a preloaded dialog box template.
        /// This template replaces the default template for the Print dialog box.
        /// The system ignores the <see cref="PRINTDLG.lpPrintTemplateName"/> member if this flag is specified.
        /// </summary>
        PD_ENABLEPRINTTEMPLATEHANDLE = 0x00010000,

        /// <summary>
        /// Enables the hook procedure specified in the <see cref="PRINTDLG.lpfnSetupHook"/> member.
        /// This enables the hook procedure for the Print Setup dialog box.
        /// </summary>
        PD_ENABLESETUPHOOK = 0x00002000,

        /// <summary>
        /// Indicates that the <see cref="PRINTDLG.hInstance"/> and <see cref="PRINTDLG.lpSetupTemplateName"/> members specify a replacement
        /// for the default Print Setup dialog box template.
        /// </summary>
        PD_ENABLESETUPTEMPLATE = 0x00008000,

        /// <summary>
        /// Indicates that the <see cref="PRINTDLG.hSetupTemplate"/> member identifies a data block that contains a preloaded dialog box template.
        /// This template replaces the default template for the Print Setup dialog box.
        /// The system ignores the <see cref="PRINTDLG.lpSetupTemplateName"/> member if this flag is specified.
        /// </summary>
        PD_ENABLESETUPTEMPLATEHANDLE = 0x00020000,

        /// <summary>
        /// Indicates that the <see cref="PRINTDLGEX.ExclusionFlags"/> member identifies items to be excluded from the printer driver property pages.
        /// If this flag is not set, items will be excluded by default from the printer driver property pages.
        /// The exclusions prevent the duplication of items among the General page, any application-specified pages, and the printer driver pages.
        /// </summary>
        PD_EXCLUSIONFLAGS = 0x01000000,

        /// <summary>
        /// Hides the Print to File check box.
        /// </summary>
        PD_HIDEPRINTTOFILE = 0x00100000,

        /// <summary>
        /// Disables the Current Page radio button.
        /// </summary>
        PD_NOCURRENTPAGE = 0x00800000,

        /// <summary>
        /// Hides and disables the Network button.
        /// </summary>
        PD_NONETWORKBUTTON = 0x00200000,

        /// <summary>
        /// Disables the Pages radio button and the associated edit controls. Also, it causes the Collate check box to appear in the dialog.
        /// </summary>
        PD_NOPAGENUMS = 0x00000008,

        /// <summary>
        /// Disables the Selection radio button.
        /// </summary>
        PD_NOSELECTION = 0x00000004,

        /// <summary>
        /// Prevents the warning message from being displayed when there is no default printer.
        /// </summary>
        PD_NOWARNING = 0x00000080,

        /// <summary>
        /// If this flag is set, the Pages radio button is selected.
        /// If this flag is set when the <see cref="PrintDlg"/> function returns,
        /// the <see cref="PRINTDLG.nFromPage"/> and <see cref="PRINTDLG.nToPage"/> members indicate the starting and ending pages specified by the user.
        /// </summary>
        PD_PAGENUMS = 0x00000002,

        /// <summary>
        /// Causes the system to display the Print Setup dialog box rather than the Print dialog box.
        /// </summary>
        PD_PRINTSETUP = 0x00000040,

        /// <summary>
        /// If this flag is set, the Print to File check box is selected.
        /// If this flag is set when the <see cref="PrintDlg"/> function returns,
        /// the offset indicated by the <see cref="DEVNAMES.wOutputOffset"/> member of the <see cref="DEVNAMES"/> structure contains the string "FILE:".
        /// When you call the <see cref="StartDoc"/> function to start the printing operation, specify this "FILE:" string
        /// in the <see cref="DOCINFO.lpszOutput"/> member of the <see cref="DOCINFO"/> structure.
        /// Specifying this string causes the print subsystem to query the user for the name of the output file.
        /// </summary>
        PD_PRINTTOFILE = 0x00000020,

        /// <summary>
        /// Causes <see cref="PrintDlg"/> to return a device context matching the selections the user made in the dialog box.
        /// The device context is returned in <see cref="PRINTDLG.hDC"/>.
        /// </summary>
        PD_RETURNDC = 0x00000100,

        /// <summary>
        /// If this flag is set, the <see cref="PrintDlg"/> function does not display the dialog box.
        /// Instead, it sets the <see cref="PRINTDLG.hDevNames"/> and <see cref="PRINTDLG.hDevMode"/> members
        /// to handles to <see cref="DEVMODE"/> and <see cref="DEVNAMES"/> structures that are initialized for the system default printer.
        /// Both <see cref="PRINTDLG.hDevNames"/> and <see cref="PRINTDLG.hDevMode"/> must be <see cref="NULL"/>,
        /// or <see cref="PrintDlg"/> returns an error.
        /// </summary>
        PD_RETURNDEFAULT = 0x00000400,

        /// <summary>
        /// Similar to the <see cref="PD_RETURNDC"/> flag, except this flag returns an information context rather than a device context.
        /// If neither <see cref="PD_RETURNDC"/> nor <see cref="PD_RETURNIC"/> is specified, <see cref="PRINTDLG.hDC"/> is undefined on output.
        /// </summary>
        PD_RETURNIC = 0x00000200,

        /// <summary>
        /// If this flag is set, the Selection radio button is selected.
        /// If neither <see cref="PD_PAGENUMS"/> nor <see cref="PD_SELECTION"/> is set, the All radio button is selected.
        /// </summary>
        PD_SELECTION = 0x00000001,

        /// <summary>
        /// Causes the dialog box to display the Help button.
        /// The <see cref="PRINTDLG.hwndOwner"/> member must specify the window to receive the <see cref="HELPMSGSTRING"/> registered messages
        /// that the dialog box sends when the user clicks the Help button.
        /// </summary>
        PD_SHOWHELP = 0x00000800,

        /// <summary>
        /// Same as <see cref="PD_USEDEVMODECOPIESANDCOLLATE"/>.
        /// </summary>
        PD_USEDEVMODECOPIES = 0x00040000,

        /// <summary>
        /// This flag indicates whether your application supports multiple copies and collation.
        /// Set this flag on input to indicate that your application does not support multiple copies and collation.
        /// In this case, the <see cref="PRINTDLG.nCopies"/> member of the <see cref="PRINTDLG"/> structure always returns 1,
        /// and <see cref="PD_COLLATE"/> is never set in the <see cref="PRINTDLG.Flags"/> member.
        /// If this flag is not set, the application is responsible for printing and collating multiple copies.
        /// In this case, the <see cref="PRINTDLG.nCopies"/> member of the <see cref="PRINTDLG"/> structure
        /// indicates the number of copies the user wants to print, and the <see cref="PD_COLLATE"/> flag
        /// in the <see cref="PRINTDLG.Flags"/> member indicates whether the user wants collation.
        /// Regardless of whether this flag is set, an application can determine from <see cref="PRINTDLG.nCopies"/> and <see cref="PD_COLLATE"/>
        /// how many copies to render and whether to print them collated.
        /// If this flag is set and the printer driver does not support multiple copies, the Copies edit control is disabled.
        /// Similarly, if this flag is set and the printer driver does not support collation, the Collate check box is disabled.
        /// The <see cref="DEVMODE.dmCopies"/> and <see cref="DEVMODE.dmCollate"/> members of the DEVMODE structure
        /// contain the copies and collate information used by the printer driver.
        /// If this flag is set and the printer driver supports multiple copies,
        /// the <see cref="DEVMODE.dmCopies"/> member indicates the number of copies requested by the user.
        /// If this flag is set and the printer driver supports collation,
        /// the <see cref="DEVMODE.dmCollate"/> member of the <see cref="DEVMODE"/> structure indicates whether the user wants collation.
        /// If this flag is not set, the <see cref="DEVMODE.dmCopies"/> member always returns 1,
        /// and the <see cref="DEVMODE.dmCollate"/> member is always zero.
        /// Known issue on Windows 2000/XP/2003:
        /// If this flag is not set before calling <see cref="PrintDlg"/>, <see cref="PrintDlg"/> might
        /// swap <see cref="PRINTDLG.nCopies"/> and <see cref="DEVMODE.dmCopies"/> values when it returns.
        /// The workaround for this issue is use <see cref="DEVMODE.dmCopies"/> if its value is larger than 1, else,
        /// use <see cref="PRINTDLG.nCopies"/>, for you to to get the actual number of copies to be printed when <see cref="PrintDlg"/> returns.
        /// </summary>
        PD_USEDEVMODECOPIESANDCOLLATE = 0x00040000,

        /// <summary>
        /// Forces the property sheet to use a large template for the General page.
        /// The larger template provides more space for applications that specify a custom template for the lower portion of the General page.
        /// </summary>
        PD_USELARGETEMPLATE = 0x10000000,
    }
}
