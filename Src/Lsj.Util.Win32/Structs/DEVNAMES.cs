using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Enums.DEVNAMESFlags;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains strings that identify the driver, device, and output port names for a printer.
    /// These strings must be ANSI strings when the ANSI version of <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/> is used,
    /// and must be Unicode strings when the Unicode version of <see cref="PrintDlg"/> or <see cref="PrintDlgEx"/> is used.
    /// The <see cref="PrintDlgEx"/> and <see cref="PrintDlg"/> functions use these strings to initialize
    /// the system-defined Print Property Sheet or Print Dialog Box.
    /// When the user closes the property sheet or dialog box, information about the selected printer is returned in this structure.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/ns-commdlg-devnames
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DEVNAMES
    {
        /// <summary>
        /// The offset, in characters, from the beginning of this structure to a null-terminated string
        /// that contains the file name (without the extension) of the device driver.
        /// On input, this string is used to determine the printer to display initially in the dialog box.
        /// </summary>
        public WORD wDriverOffset;

        /// <summary>
        /// The offset, in characters, from the beginning of this structure to the null-terminated string that contains the name of the device.
        /// </summary>
        public WORD wDeviceOffset;

        /// <summary>
        /// The offset, in characters, from the beginning of this structure to the null-terminated string
        /// that contains the device name for the physical output medium (output port).
        /// </summary>
        public WORD wOutputOffset;

        /// <summary>
        /// Indicates whether the strings contained in the <see cref="DEVNAMES"/> structure identify the default printer.
        /// This string is used to verify that the default printer has not changed since the last print operation.
        /// If any of the strings do not match, a warning message is displayed informing the user that the document may need to be reformatted.
        /// On output, the wDefault member is changed only if the Print Setup dialog box was displayed and the user chose the OK button.
        /// The <see cref="DN_DEFAULTPRN"/> flag is used if the default printer was selected.
        /// If a specific printer is selected, the flag is not used. All other flags in this member are reserved for internal
        /// use by the dialog box procedure for the Print property sheet or Print dialog box.
        /// </summary>
        public DEVNAMESFlags wDefault;
    }
}
