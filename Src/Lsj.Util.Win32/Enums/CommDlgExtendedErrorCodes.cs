using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.PRINTDLGFlags;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Common dialog box error codes.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/nf-commdlg-commdlgextendederror
    /// </para>
    /// </summary>
    public enum CommDlgExtendedErrorCodes : uint
    {
        /// <summary>
        /// The dialog box could not be created.
        /// The common dialog box function's call to the <see cref="DialogBox"/> function failed.
        /// For example, this error occurs if the common dialog box call specifies an invalid window handle.
        /// </summary>
        CDERR_DIALOGFAILURE = 0xFFFF,

        /// <summary>
        /// The common dialog box function failed to find a specified resource.
        /// </summary>
        CDERR_FINDRESFAILURE = 0x0006,

        /// <summary>
        /// The common dialog box function failed during initialization.
        /// This error often occurs when sufficient memory is not available.
        /// </summary>
        CDERR_INITIALIZATION = 0x0002,

        /// <summary>
        /// The common dialog box function failed to load a specified resource.
        /// </summary>
        CDERR_LOADRESFAILURE = 0x0007,

        /// <summary>
        /// The common dialog box function failed to load a specified string.
        /// </summary>
        CDERR_LOADSTRFAILURE = 0x0005,

        /// <summary>
        /// The common dialog box function failed to lock a specified resource.
        /// </summary>
        CDERR_LOCKRESFAILURE = 0x0008,

        /// <summary>
        /// The common dialog box function was unable to allocate memory for internal structures.
        /// </summary>
        CDERR_MEMALLOCFAILURE = 0x0009,

        /// <summary>
        /// The common dialog box function was unable to lock the memory associated with a handle.
        /// </summary>
        CDERR_MEMLOCKFAILURE = 0x000A,

        /// <summary>
        /// The ENABLETEMPLATE flag was set in the Flags member of the initialization structure
        /// for the corresponding common dialog box, but you failed to provide a corresponding instance handle.
        /// </summary>
        CDERR_NOHINSTANCE = 0x0004,

        /// <summary>
        /// The ENABLEHOOK flag was set in the Flags member of the initialization structure for the corresponding common dialog box,
        /// but you failed to provide a pointer to a corresponding hook procedure.
        /// </summary>
        CDERR_NOHOOK = 0x000B,

        /// <summary>
        /// The ENABLETEMPLATE flag was set in the Flags member of the initialization structure for the corresponding common dialog box,
        /// but you failed to provide a corresponding template.
        /// </summary>
        CDERR_NOTEMPLATE = 0x0003,

        /// <summary>
        /// The <see cref="RegisterWindowMessage"/> function returned an error code when it was called by the common dialog box function.
        /// </summary>
        CDERR_REGISTERMSGFAIL = 0x000C,

        /// <summary>
        /// The lStructSize member of the initialization structure for the corresponding common dialog box is invalid.
        /// </summary>
        CDERR_STRUCTSIZE = 0x0001,

        /// <summary>
        /// The <see cref="PrintDlg"/> function failed when it attempted to create an information context.
        /// </summary>
        PDERR_CREATEICFAILURE = 0x100A,

        /// <summary>
        /// You called the <see cref="PrintDlg"/> function with the <see cref="DN_DEFAULTPRN"/> flag specified
        /// in the <see cref="DEVNAMES.wDefault"/> member of the <see cref="DEVNAMES"/> structure,
        /// but the printer described by the other structure members did not match the current default printer.
        /// This error occurs when you store the <see cref="DEVNAMES"/> structure, and the user changes the default printer by using the Control Panel.
        /// To use the printer described by the <see cref="DEVNAMES"/> structure, clear the <see cref="DN_DEFAULTPRN"/> flag
        /// and call <see cref="PrintDlg"/> again.
        /// To use the default printer, replace the <see cref="DEVNAMES"/> structure (and the structure, if one exists) with <see cref="NULL"/>;
        /// and call <see cref="PrintDlg"/> again.
        /// </summary>
        PDERR_DEFAULTDIFFERENT = 0x100C,

        /// <summary>
        /// The data in the <see cref="DEVMODE"/> and <see cref="DEVNAMES"/> structures describes two different printers.
        /// </summary>
        PDERR_DNDMMISMATCH = 0x1009,

        /// <summary>
        /// The printer driver failed to initialize a <see cref="DEVMODE"/> structure.
        /// </summary>
        PDERR_GETDEVMODEFAIL = 0x1005,

        /// <summary>
        /// The <see cref="PrintDlg"/> function failed during initialization, and there is no more specific extended error code to describe the failure.
        /// This is the generic default error code for the function.
        /// </summary>
        PDERR_INITFAILURE = 0x1006,

        /// <summary>
        /// The <see cref="PrintDlg"/> function failed to load the device driver for the specified printer.
        /// </summary>
        PDERR_LOADDRVFAILURE = 0x1004,

        /// <summary>
        /// A default printer does not exist.
        /// </summary>
        PDERR_NODEFAULTPRN = 0x1008,

        /// <summary>
        /// No printer drivers were found.
        /// </summary>
        PDERR_NODEVICES = 0x1007,

        /// <summary>
        /// The <see cref="PrintDlg"/> function failed to parse the strings in the [devices] section of the WIN.INI file.
        /// </summary>
        PDERR_PARSEFAILURE = 0x1002,

        /// <summary>
        /// The [devices] section of the WIN.INI file did not contain an entry for the requested printer.
        /// </summary>
        PDERR_PRINTERNOTFOUND = 0x100B,

        /// <summary>
        /// The <see cref="PD_RETURNDEFAULT"/> flag was specified in the <see cref="PRINTDLG.Flags"/> member of the <see cref="PRINTDLG"/> structure,
        /// but the <see cref="PRINTDLG.hDevMode"/> or <see cref="PRINTDLG.hDevNames"/> member was not <see cref="NULL"/>.
        /// </summary>
        PDERR_RETDEFFAILURE = 0x1003,

        /// <summary>
        /// The <see cref="PrintDlg"/> function failed to load the required resources.
        /// </summary>
        PDERR_SETUPFAILURE = 0x1001,

        /// <summary>
        /// The size specified in the <see cref="CHOOSEFONT.nSizeMax"/> member of the <see cref="CHOOSEFONT"/> structure
        /// is less than the size specified in the <see cref="CHOOSEFONT.nSizeMin"/> member.
        /// </summary>
        CFERR_MAXLESSTHANMIN = 0x2002,

        /// <summary>
        /// No fonts exist.
        /// </summary>
        CFERR_NOFONTS = 0x2001,

        /// <summary>
        /// The buffer pointed to by the <see cref="OPENFILENAME.lpstrFile"/> member of the <see cref="OPENFILENAME"/> structure
        /// is too small for the file name specified by the user.
        /// The first two bytes of the <see cref="OPENFILENAME.lpstrFile"/> buffer contain an integer value specifying the size required
        /// to receive the full name, in characters.
        /// </summary>
        FNERR_BUFFERTOOSMALL = 0x3003,

        /// <summary>
        /// A file name is invalid.
        /// </summary>
        FNERR_INVALIDFILENAME = 0x3002,

        /// <summary>
        /// An attempt to subclass a list box failed because sufficient memory was not available.
        /// </summary>
        FNERR_SUBCLASSFAILURE = 0x3001,

        /// <summary>
        /// A member of the <see cref="FINDREPLACE"/> structure points to an invalid buffer.
        /// </summary>
        FRERR_BUFFERLENGTHZERO = 0x4001,
    }
}
