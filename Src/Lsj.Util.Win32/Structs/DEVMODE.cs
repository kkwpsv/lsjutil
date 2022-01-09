using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DEVMODEBinConstants;
using static Lsj.Util.Win32.Enums.DEVMODECollations;
using static Lsj.Util.Win32.Enums.DEVMODEColors;
using static Lsj.Util.Win32.Enums.DEVMODEDisplayOrientations;
using static Lsj.Util.Win32.Enums.DEVMODEDuplexes;
using static Lsj.Util.Win32.Enums.DEVMODEFields;
using static Lsj.Util.Win32.Enums.DEVMODEFixedOutputs;
using static Lsj.Util.Win32.Enums.DEVMODENups;
using static Lsj.Util.Win32.Enums.DEVMODEOrientations;
using static Lsj.Util.Win32.Enums.DEVMODEPrintQualities;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DEVMODE"/> structure is used for specifying characteristics of display and print devices in the Unicode (wide) character set.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-devmodew"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="DEVMODE"/> structure is the Unicode version of the DEVMODE structure (described in the Microsoft Windows SDK documentation).
    /// While applications can use either the ANSI or Unicode version of the structure, drivers are required to use the Unicode version.
    /// For printer drivers, the DEVMODEW structure is used for specifying printer characteristics required by a print document.
    /// It is also used for specifying a printer's default characteristics.
    /// Immediately following a <see cref="DEVMODE"/> structure's defined members (often referred to as its public members),
    /// there can be a set of driver-defined members (often referred to as private DEVMODEW members).
    /// The driver supplies the size, in bytes, of this private area in <see cref="dmDriverExtra"/>.
    /// Driver-defined private members are for exclusive use by the driver.
    /// The starting address for the private members can be referenced using the dmSize member as follows:
    /// <code>PVOID pvDriverData = (PVOID) (((BYTE *) pdm) + (pdm->dmSize));</code>
    /// A driver can rely on the spooler to pass a <see cref="DEVMODE"/> buffer that is no smaller than (<see cref="dmSize"/> + <see cref="dmDriverExtra"/>) bytes.
    /// As a result, the driver can safely read that number of bytes starting from the beginning of the buffer without causing an access violation,
    /// and without needing to probe memory.
    /// Prior to playing EMF, GDI calls the spooler to validate the contents of the public portion of the <see cref="DEVMODE"/> buffer.
    /// If the <see cref="DEVMODE"/> buffer does not pass the validation tests performed in the spooler, GDI does not pass the buffer on to the printer driver.
    /// Windows only confirms that the public portion of <see cref="DEVMODE"/> is valid.
    /// However, corrupted data in the private portion of the structure can cause driver code to crash in the application or in the spooler process.
    /// Consequently, before each use of <see cref="DEVMODE"/> data the driver should verify that the private portion of <see cref="DEVMODE"/> is well-formed.
    /// In Windows 2000, a new union member was added to the <see cref="DEVMODE"/> structure.
    /// This union member contains an existing <see cref="DEVMODE"/> structure member, <see cref="dmDisplayFlags"/>,
    /// together with a new member, <see cref="dmNup"/>.
    /// This member is described in the preceding Members section.
    /// In Windows XP, a new struct member was added.
    /// This struct member contains an existing <see cref="DEVMODE"/> structure member, <see cref="dmPosition"/>, together with two new members, 
    /// <see cref="dmDisplayOrientation"/> and <see cref="dmDisplayFixedOutput"/>.
    /// These members are described in the preceding Members section.
    /// Also for Windows XP, several members of the <see cref="DEVMODE"/> structure were moved to different locations in this structure.
    /// The <see cref="dmScale"/>, <see cref="dmCopies"/>, <see cref="dmDefaultSource"/>, and <see cref="dmPrintQuality"/> members were appended to
    /// the struct member containing the <see cref="dmOrientation"/>, <see cref="dmPaperSize"/>, <see cref="dmPaperLength"/>, and <see cref="dmPaperWidth"/> members.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct DEVMODE
    {
        /// <summary>
        /// For a display, specifies the name of the display driver's DLL; for example, "perm3dd" for the 3Dlabs Permedia3 display driver.
        /// For a printer, specifies the "friendly name"; for example, "PCL/HP LaserJet" in the case of PCL/HP LaserJet.
        /// If the name is greater than <see cref="CCHDEVICENAME"/> characters in length, the spooler truncates it to fit in the array.
        /// </summary>
        [FieldOffset(0)]
        public ByValStringStructForSize32 dmDeviceName;

        /// <summary>
        /// Specifies the version number of this <see cref="DEVMODE"/> structure.
        /// The current version number is identified by the <see cref="DM_SPECVERSION"/> constant in wingdi.h.
        /// </summary>
        [FieldOffset(64)]
        public WORD dmSpecVersion;

        /// <summary>
        /// For a printer, specifies the printer driver version number assigned by the printer driver developer.
        /// Display drivers can set this member to <see cref="DM_SPECVERSION"/>.
        /// </summary>
        [FieldOffset(66)]
        public WORD dmDriverVersion;

        /// <summary>
        /// Specifies the size in bytes of the public <see cref="DEVMODE"/> structure, not including any private,
        /// driver-specified members identified by the <see cref="dmDriverExtra"/> member.
        /// </summary>
        [FieldOffset(68)]
        public WORD dmSize;

        /// <summary>
        /// Specifies the number of bytes of private driver data that follow the public structure members.
        /// If a device driver does not provide private <see cref="DEVMODE"/> members, this member should be set to zero.
        /// </summary>
        [FieldOffset(70)]
        public WORD dmDriverExtra;

        /// <summary>
        /// Specifies bit flags identifying which of the following <see cref="DEVMODE"/> members are in use.
        /// For example, the <see cref="DM_ORIENTATION"/> flag is set when the <see cref="dmOrientation"/> member contains valid data.
        /// The DM_XXX flags are defined in wingdi.h.
        /// </summary>
        [FieldOffset(72)]
        public DEVMODEFields dmFields;

        /// <summary>
        /// For printers, specifies the paper orientation.
        /// This member can be either <see cref="DMORIENT_PORTRAIT"/> or <see cref="DMORIENT_LANDSCAPE"/>.
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(76)]
        public DEVMODEOrientations dmOrientation;

        /// <summary>
        /// For printers, specifies the size of the paper to be printed on.
        /// This member must be zero if the length and width of the paper are specified
        /// by the <see cref="dmPaperLength"/> and <see cref="dmPaperWidth"/> members.
        /// Otherwise, the <see cref="dmPaperSize"/> member must be one of the DMPAPER-prefixed constants defined in wingdi.h.
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(78)]
        public short dmPaperSize;

        /// <summary>
        /// For printers, specifies the length of the paper, in units of 1/10 of a millimeter.
        /// This value overrides the length of the paper specified by the <see cref="dmPaperSize"/> member,
        /// and is used if the paper is of a custom size, or if the device is a dot matrix printer, which can print a page of arbitrary length.
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(80)]
        public short dmPaperLength;

        /// <summary>
        /// For printers, specifies the width of the paper, in units of 1/10 of a millimeter.
        /// This value overrides the width of the paper specified by the <see cref="dmPaperSize"/> member.
        /// This member must be used if <see cref="dmPaperLength"/> is used.
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(82)]
        public short dmPaperWidth;

        /// <summary>
        /// For printers, specifies the percentage by which the image is to be scaled for printing.
        /// The image's page size is scaled to the physical page by a factor of dmScale/100.
        /// For example, a 17-inch by 22-inch image with a scale value of 100 requires 17x22-inch paper,
        /// while the same image with a scale value of 50 should print as half-sized and fit on letter-sized paper.
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(84)]
        public short dmScale;

        /// <summary>
        /// For printers, specifies the number of copies to be printed, if the device supports multiple copies.
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(86)]
        public short dmCopies;

        /// <summary>
        /// For printers, specifies the printer's default input bin.
        /// This must be one of the DMBIN-prefixed constants defined in wingdi.h.
        /// If the specified constant is <see cref="DMBIN_FORMSOURCE"/>, the input bin should be selected automatically.
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(88)]
        public short dmDefaultSource;

        /// <summary>
        /// For printers, specifies the printer resolution. The following negative constant values are defined in wingdi.h:
        /// <see cref="DMRES_HIGH"/>, <see cref="DMRES_MEDIUM"/>, <see cref="DMRES_LOW"/>, <see cref="DMRES_DRAFT"/>
        /// If a positive value is specified, it represents the number of dots per inch (DPI) for the x resolution,
        /// and the y resolution is specified by <see cref="dmYResolution"/>.
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(90)]
        public DEVMODEPrintQualities dmPrintQuality;

        /// <summary>
        /// For displays, specifies a <see cref="POINTL"/> structure containing the x- and y-coordinates of upper-left corner of the display,
        /// in desktop coordinates.
        /// This member is used to determine the relative position of monitors in a multiple monitor environment.
        /// This member is not used for printers.
        /// </summary>
        [FieldOffset(76)]
        public POINTL dmPosition;

        /// <summary>
        /// This member is defined only for Windows XP and later.
        /// For displays, specifies the orientation at which images should be presented.
        /// When the <see cref="DM_DISPLAYORIENTATION"/> bit is not set in the dmFields member, this member must be set to zero.
        /// When the <see cref="DM_DISPLAYORIENTATION"/> bit is set in the dmFields member, this member must be set to one of the following values:
        /// <see cref="DMDO_DEFAULT"/>, <see cref="DMDO_90"/>, <see cref="DMDO_180"/>, <see cref="DMDO_270"/>
        /// This member is not used for printers.
        /// For more information, see Returning Display Modes: DrvGetModes.
        /// </summary>
        [FieldOffset(84)]
        public DEVMODEDisplayOrientations dmDisplayOrientation;

        /// <summary>
        /// This member is defined only for Windows XP and later.
        /// For fixed-resolution displays, specifies how the device can present a lower-resolution mode on a higher-resolution display.
        /// For example, if a display device's resolution is fixed at 1024 X 768, and its mode is set to 640 x 480,
        /// the device can either display a 640 X 480 image within the 1024 X 768 screen space,
        /// or stretch the 640 X 480 image to fill the larger screen space.
        /// When the <see cref="DM_DISPLAYFIXEDOUTPUT"/> bit is not set in the <see cref="dmFields"/> member,
        /// this member must be set to zero.
        /// When the <see cref="DM_DISPLAYFIXEDOUTPUT"/> bit is set in the <see cref="dmFields"/> member,
        /// this member must be set to one of the following values:
        /// <see cref="DMDFO_CENTER"/>, <see cref="DMDFO_STRETCH"/>
        /// This member is not used for printers.
        /// For more information, see Returning Display Modes: DrvGetModes.
        /// </summary>
        [FieldOffset(88)]
        public DEVMODEFixedOutputs dmDisplayFixedOutput;

        /// <summary>
        /// For printers, specifies whether a color printer should print color or monochrome.
        /// This member can be one of <see cref="DMCOLOR_COLOR"/> or <see cref="DMCOLOR_MONOCHROME"/>.
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(92)]
        public DEVMODEColors dmColor;

        /// <summary>
        /// For printers, specifies duplex (double-sided) printing for duplex-capable printers.
        /// This member can be one of the following values:
        /// <see cref="DMDUP_HORIZONTAL"/>, <see cref="DMDUP_SIMPLEX"/>, <see cref="DMDUP_VERTICAL"/>
        /// </summary>
        [FieldOffset(94)]
        public DEVMODEDuplexes dmDuplex;

        /// <summary>
        /// For printers, specifies the y resolution of the printer, in DPI.
        /// If this member is used, the <see cref="dmPrintQuality"/> member specifies the x resolution.
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(96)]
        public short dmYResolution;

        /// <summary>
        /// For printers, specifies how TrueType fonts should be printed. 
        /// This member must be one of the DMTT-prefixed constants defined in wingdi.h.
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(98)]
        public short dmTTOption;

        /// <summary>
        /// For printers, specifies whether multiple copies should be collated.
        /// This member can be one of the following values:
        /// <see cref="DMCOLLATE_TRUE"/>, <see cref="DMCOLLATE_FALSE"/>
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(100)]
        public DEVMODECollations dmCollate;

        /// <summary>
        /// For printers, specifies the name of the form to use; such as "Letter" or "Legal".
        /// This must be a name that can be obtain by calling the Win32 EnumForms function (described in the Microsoft Window SDK documentation).
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(102)]
        public ByValStringStructForSize32 dmFormName;

        /// <summary>
        /// For displays, specifies the number of logical pixels per inch of a display device and should be equal to
        /// the <see cref="GDIINFO.ulLogPixelsX"/> and <see cref="GDIINFO.ulLogPixelsY"/> member of the <see cref="GDIINFO"/> structure.
        /// This member is not used for printers.
        /// </summary>
        [FieldOffset(166)]
        public WORD dmLogPixels;

        /// <summary>
        /// For displays, specifies the color resolution, in bits per pixel, of a display device.
        /// This member is not used for printers.
        /// </summary>
        [FieldOffset(168)]
        public DWORD dmBitsPerPel;

        /// <summary>
        /// For displays, specifies the width, in pixels, of the visible device surface.
        /// This member is not used for printers.
        /// </summary>
        [FieldOffset(172)]
        public DWORD dmPelsWidth;

        /// <summary>
        /// For displays, specifies the height, in pixels, of the visible device surface.
        /// This member is not used for printers.
        /// </summary>
        [FieldOffset(176)]
        public DWORD dmPelsHeight;

        /// <summary>
        /// For displays, specifies a display device's display mode. This member can be one of the following values:
        /// This member is not used for printers.
        /// </summary>
        [FieldOffset(180)]
        public DWORD dmDisplayFlags;

        /// <summary>
        /// For printers, specifies whether the print system handles "N-up" printing (playing multiple EMF logical pages onto a single physical page).
        /// The value of this member can be one of the following:
        /// <see cref="DMNUP_SYSTEM"/>, <see cref="DMNUP_ONEUP"/>
        /// This member is not used for displays.
        /// </summary>
        [FieldOffset(180)]
        public DEVMODENups dmNup;

        /// <summary>
        /// For displays, specifies the frequency, in hertz, of a display device in its current mode.
        /// This member is not used for printers.
        /// </summary>
        [FieldOffset(184)]
        public DWORD dmDisplayFrequency;

        /// <summary>
        /// Specifies one of the DMICMMETHOD-prefixed constants defined in wingdi.h.
        /// </summary>
        [FieldOffset(188)]
        public DWORD dmICMMethod;

        /// <summary>
        /// Specifies one of the DMICM-prefixed constants defined in wingdi.h.
        /// </summary>
        [FieldOffset(192)]
        public DWORD dmICMIntent;

        /// <summary>
        /// Specifies one of the DMMEDIA-prefixed constants defined in wingdi.h.
        /// </summary>
        [FieldOffset(196)]
        public DWORD dmMediaType;

        /// <summary>
        /// Specifies one of the DMDITHER-prefixed constants defined in wingdi.h.
        /// </summary>
        [FieldOffset(200)]
        public DWORD dmDitherType;

        /// <summary>
        /// Is reserved for system use and should be ignored by the driver.
        /// </summary>
        [FieldOffset(204)]
        public DWORD dmReserved1;

        /// <summary>
        /// Is reserved for system use and should be ignored by the driver.
        /// </summary>
        [FieldOffset(208)]
        public DWORD dmReserved2;

        /// <summary>
        /// Is reserved for system use and should be ignored by the driver.
        /// </summary>
        [FieldOffset(212)]
        public DWORD dmPanningWidth;

        /// <summary>
        /// Is reserved for system use and should be ignored by the driver.
        /// </summary>
        [FieldOffset(216)]
        public DWORD dmPanningHeight;
    }
}
