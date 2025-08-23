using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DeviceModeBinFlags;
using static Lsj.Util.Win32.Enums.DeviceModeCollateFlags;
using static Lsj.Util.Win32.Enums.DeviceModeColorFlags;
using static Lsj.Util.Win32.Enums.DeviceModeDisplayOrientationFlags;
using static Lsj.Util.Win32.Enums.DeviceModeDuplexFlags;
using static Lsj.Util.Win32.Enums.DeviceModeFieldFlags;
using static Lsj.Util.Win32.Enums.DeviceModeDisplayFixedOutputFlags;
using static Lsj.Util.Win32.Enums.DeviceModesNUps;
using static Lsj.Util.Win32.Enums.DeviceModesOrientations;
using static Lsj.Util.Win32.Enums.DeviceModesPrintQualities;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DEVMODE"/> structure is used for specifying characteristics of display and print devices in the Unicode (wide) character set.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-devmodew"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="DEVMODE"/> structure is the Unicode version of the structure (described in the Microsoft Windows SDK documentation).
    /// While applications can use either the ANSI or Unicode version of the structure, drivers are required to use the Unicode version.
    /// </para>
    /// <para>
    /// For printer drivers, the <see cref="DEVMODE"/> structure is used for specifying printer characteristics required by a print document.
    /// It is also used for specifying a printer's default characteristics.
    /// </para>
    /// <para>
    /// Immediately following a <see cref="DEVMODE"/> structure's defined members (often referred to as its public members),
    /// there can be a set of driver-defined members (often referred to as private <see cref="DEVMODE"/> members).
    /// The driver supplies the size, in bytes, of this private area in <see cref="dmDriverExtra"/>.
    /// Driver-defined private members are for exclusive use by the driver.
    /// The starting address for the private members can be referenced using the <see cref="dmSize"/> member as follows:
    /// </para>
    /// <code>PVOID pvDriverData = (PVOID) (((BYTE *) pdm) + (pdm->dmSize));</code>
    /// <para>
    /// A driver can rely on the spooler to pass a <see cref="DEVMODE"/> buffer
    /// that is no smaller than (<see cref="dmSize"/> + <see cref="dmDriverExtra"/>) bytes.
    /// As a result, the driver can safely read that number of bytes starting from the beginning of the buffer
    /// without causing an access violation, and without needing to probe memory.
    /// </para>
    /// <para>
    /// Prior to playing EMF, GDI calls the spooler to validate the contents of the public portion of the <see cref="DEVMODE"/> buffer.
    /// If the <see cref="DEVMODE"/> buffer does not pass the validation tests performed in the spooler,
    /// GDI does not pass the buffer on to the printer driver.
    /// </para>
    /// <para>
    /// Warning  Windows only confirms that the public portion of <see cref="DEVMODE"/> is valid.
    /// However, corrupted data in the private portion of the structure can cause driver code to crash in the application or in the spooler process.
    /// Consequently, before each use of <see cref="DEVMODE"/> data the driver should verify that the private portion of <see cref="DEVMODE"/> is well-formed.
    /// </para>
    /// <para>
    /// In Windows 2000, a new union member was added to the <see cref="DEVMODE"/> structure.
    /// This union member contains an existing <see cref="DEVMODE"/> structure member,
    /// <see cref="dmDisplayFlags"/>, together with a new member, <see cref="dmNup"/>.
    /// This member is described in the preceding Members section.
    /// </para>
    /// <para>
    /// In Windows XP, a new struct member was added.
    /// This struct member contains an existing <see cref="DEVMODE"/> structure member, <see cref="dmPosition"/>,
    /// together with two new members, <see cref="dmDisplayOrientation"/> and <see cref="dmDisplayFixedOutput"/>.
    /// These members are described in the preceding Members section.
    /// </para>
    /// <para>
    /// Also for Windows XP, several members of the <see cref="DEVMODE"/> structure were moved to different locations in this structure.
    /// The <see cref="dmScale"/>, <see cref="dmCopies"/>, <see cref="dmDefaultSource"/>,
    /// and <see cref="dmPrintQuality"/> members were appended to the struct member
    /// containing the <see cref="dmOrientation"/>, <see cref="dmPaperSize"/>, <see cref="dmPaperLength"/>, and <see cref="dmPaperWidth"/> members.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct DEVMODE
    {
        /// <summary>
        /// <para>
        /// For a display, specifies the name of the display driver's DLL; for example, "perm3dd" for the 3Dlabs Permedia3 display driver.
        /// </para>
        /// <para>
        /// For a printer, specifies the "friendly name"; for example, "PCL/HP LaserJet" in the case of PCL/HP LaserJet.
        /// If the name is greater than <see cref="CCHDEVICENAME"/> characters in length, the spooler truncates it to fit in the array.
        /// </para>
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
        /// <para>
        /// For a printer, specifies the printer driver version number assigned by the printer driver developer.
        /// </para>
        /// <para>
        /// Display drivers can set this member to <see cref="DM_SPECVERSION"/>.
        /// </para>
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
        public DeviceModeFieldFlags dmFields;

        /// <summary>
        /// <para>
        /// For printers, specifies the paper orientation.
        /// This member can be either <see cref="DMORIENT_PORTRAIT"/> or <see cref="DMORIENT_LANDSCAPE"/>.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(76)]
        public DeviceModesOrientations dmOrientation;

        /// <summary>
        /// <para>
        /// For printers, specifies the size of the paper to be printed on.
        /// This member must be zero if the length and width of the paper
        /// are specified by the <see cref="dmPaperLength"/> and <see cref="dmPaperWidth"/> members.
        /// Otherwise, the <see cref="dmPaperSize"/> member must be one of the DMPAPER-prefixed constants defined in wingdi.h.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(78)]
        public short dmPaperSize;

        /// <summary>
        /// <para>
        /// For printers, specifies the length of the paper, in units of 1/10 of a millimeter.
        /// This value overrides the length of the paper specified by the <see cref="dmPaperSize"/> member,
        /// and is used if the paper is of a custom size, or if the device is a dot matrix printer,
        /// which can print a page of arbitrary length.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(80)]
        public short dmPaperLength;

        /// <summary>
        /// <para>
        /// For printers, specifies the width of the paper, in units of 1/10 of a millimeter.
        /// This value overrides the width of the paper specified by the <see cref="dmPaperSize"/> member.
        /// This member must be used if <see cref="dmPaperLength"/> is used.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(82)]
        public short dmPaperWidth;

        /// <summary>
        /// <para>
        /// For printers, specifies the percentage by which the image is to be scaled for printing.
        /// The image's page size is scaled to the physical page by a factor of <see cref="dmScale"/>/100.
        /// For example, a 17-inch by 22-inch image with a scale value of 100 requires 17x22-inch paper,
        /// while the same image with a scale value of 50 should print as half-sized and fit on letter-sized paper.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(84)]
        public short dmScale;

        /// <summary>
        /// <para>
        /// For printers, specifies the number of copies to be printed, if the device supports multiple copies.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(86)]
        public short dmCopies;

        /// <summary>
        /// <para>
        /// For printers, specifies the printer's default input bin.
        /// This must be one of the DMBIN-prefixed constants defined in wingdi.h.
        /// If the specified constant is <see cref="DMBIN_FORMSOURCE"/>, the input bin should be selected automatically.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(88)]
        public DeviceModeBinFlags dmDefaultSource;

        /// <summary>
        /// <para>
        /// For printers, specifies the printer resolution.
        /// The following negative constant values are defined in wingdi.h:
        /// </para>
        /// <para>
        /// <see cref="DMRES_HIGH"/>
        /// </para>
        /// <para>
        /// <see cref="DMRES_MEDIUM"/>
        /// </para>
        /// <para>
        /// <see cref="DMRES_LOW"/>
        /// </para>
        /// <para>
        /// <see cref="DMRES_DRAFT"/>
        /// </para>
        /// <para>
        /// If a positive value is specified, it represents the number of dots per inch (DPI) for the x resolution,
        /// and the y resolution is specified by <see cref="dmYResolution"/>.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(90)]
        public DeviceModesPrintQualities dmPrintQuality;

        /// <summary>
        /// <para>
        /// For displays, specifies a <see cref="POINTL"/> structure containing the x- and y-coordinates
        /// of upper-left corner of the display, in desktop coordinates.
        /// This member is used to determine the relative position of monitors in a multiple monitor environment.
        /// </para>
        /// <para>
        /// This member is not used for printers.
        /// </para>
        /// </summary>
        [FieldOffset(76)]
        public POINTL dmPosition;

        /// <summary>
        /// <para>
        /// This member is defined only for Windows XP and later.
        /// </para>
        /// <para>
        /// For displays, specifies the orientation at which images should be presented.
        /// When the <see cref="DM_DISPLAYORIENTATION"/> bit is not set in the <see cref="dmFields"/> member,
        /// this member must be set to zero.
        /// When the <see cref="DM_DISPLAYORIENTATION"/> bit is set in the <see cref="dmFields"/> member,
        /// this member must be set to one of the following values:
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
        /// <see cref="DMDO_DEFAULT"/>
        /// </term>
        /// <term>
        /// The current mode's display device orientation is the natural orientation of the device, and should be used as the default.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DMDO_90"/>
        /// </term>
        /// <term>
        /// The display device orientation is 90 degrees (measured counter-clockwise) from that of DMDO_DEFAULT.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DMDO_180"/>
        /// </term>
        /// <term>
        /// The display device orientation is 180 degrees (measured counter-clockwise) from that of DMDO_DEFAULT.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DMDO_270"/>
        /// </term>
        /// <term>
        /// The display device orientation is 270 degrees (measured counter-clockwise) from that of DMDO_DEFAULT.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This member is not used for printers.
        /// </para>
        /// <para>
        /// For more information, see Returning Display Modes: DrvGetModes.
        /// </para>
        /// </summary>
        [FieldOffset(84)]
        public DeviceModeDisplayOrientationFlags dmDisplayOrientation;

        /// <summary>
        /// <para>
        /// This member is defined only for Windows XP and later.
        /// </para>
        /// <para>
        /// For fixed-resolution displays, specifies how the device can present a lower-resolution mode on a higher-resolution display.
        /// For example, if a display device's resolution is fixed at 1024 X 768, and its mode is set to 640 x 480,
        /// the device can either display a 640 X 480 image within the 1024 X 768 screen space,
        /// or stretch the 640 X 480 image to fill the larger screen space.
        /// </para>
        /// <para>
        /// When the <see cref="DM_DISPLAYFIXEDOUTPUT"/> bit is not set in the <see cref="dmFields"/> member,
        /// this member must be set to zero.
        /// When the <see cref="DM_DISPLAYFIXEDOUTPUT"/> bit is set in the <see cref="dmFields"/> member,
        /// this member must be set to one of the following values:
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
        /// <see cref="DMDFO_CENTER"/>
        /// </term>
        /// <term>
        /// The display device presents a lower resolution mode image by centering it in the larger screen space.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DMDFO_STRETCH"/>
        /// </term>
        /// <term>
        /// The display device presents a lower-resolution mode image by stretching it to fill the larger screen space.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        [FieldOffset(88)]
        public DeviceModeDisplayFixedOutputFlags dmDisplayFixedOutput;

        /// <summary>
        /// <para>
        /// For printers, specifies whether a color printer should print color or monochrome.
        /// This member can be one of <see cref="DMCOLOR_COLOR"/> or <see cref="DMCOLOR_MONOCHROME"/>.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(92)]
        public DeviceModeColorFlags dmColor;

        /// <summary>
        /// <para>
        /// For printers, specifies duplex (double-sided) printing for duplex-capable printers.
        /// This member can be one of the following values:
        /// </para>
        /// <para>
        /// <see cref="DMDUP_HORIZONTAL"/>
        /// </para>
        /// <para>
        /// Print double-sided, using short edge binding.
        /// </para>
        /// <para>
        /// <see cref="DMDUP_SIMPLEX"/>
        /// </para>
        /// <para>
        /// Print single-sided.
        /// </para>
        /// <para>
        /// <see cref="DMDUP_VERTICAL"/>
        /// </para>
        /// <para>
        /// Print double-sided, using long edge binding.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(94)]
        public DeviceModeDuplexFlags dmDuplex;

        /// <summary>
        /// <para>
        /// For printers, specifies the y resolution of the printer, in DPI.
        /// If this member is used, the <see cref="dmPrintQuality"/> member specifies the x resolution.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(96)]
        public short dmYResolution;

        /// <summary>
        /// <para>
        /// For printers, specifies how TrueType fonts should be printed.
        /// This member must be one of the DMTT-prefixed constants defined in wingdi.h.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(98)]
        public short dmTTOption;

        /// <summary>
        /// <para>
        /// For printers, specifies whether multiple copies should be collated. This member can be one of the following values:
        /// </para>
        /// <para>
        /// <see cref="DMCOLLATE_TRUE"/>
        /// </para>
        /// <para>
        /// Collate when printing multiple copies.
        /// </para>
        /// <para>
        /// <see cref="DMCOLLATE_FALSE"/>
        /// </para>
        /// <para>
        /// Do not collate when printing multiple copies.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(100)]
        public DeviceModeCollateFlags dmCollate;

        /// <summary>
        /// <para>
        /// For printers, specifies the name of the form to use; such as "Letter" or "Legal".
        /// This must be a name that can be obtain by calling the Win32 <see cref="EnumForms"/> function.
        /// </para>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(102)]
        public ByValStringStructForSize32 dmFormName;

        /// <summary>
        /// <para>
        /// For displays, specifies the number of logical pixels per inch of a display device
        /// and should be equal to the ulLogPixels member of the <see cref="GDIINFO"/> structure.
        /// </para>
        /// <para>
        /// This member is not used for printers.
        /// </para>
        /// </summary>
        [FieldOffset(166)]
        public WORD dmLogPixels;

        /// <summary>
        /// <para>
        /// For displays, specifies the color resolution, in bits per pixel, of a display device.
        /// </para>
        /// <para>
        /// This member is not used for printers.
        /// </para>
        /// </summary>
        [FieldOffset(168)]
        public DWORD dmBitsPerPel;

        /// <summary>
        /// <para>
        /// For displays, specifies the width, in pixels, of the visible device surface.
        /// </para>
        /// <para>
        /// This member is not used for printers.
        /// </para>
        /// </summary>
        [FieldOffset(172)]
        public DWORD dmPelsWidth;

        /// <summary>
        /// <para>
        /// For displays, specifies the height, in pixels, of the visible device surface.
        /// </para>
        /// <para>
        /// This member is not used for printers.
        /// </para>
        /// </summary>
        [FieldOffset(176)]
        public DWORD dmPelsHeight;

        /// <summary>
        /// <para>
        /// Specifies the device's display mode. This member can be a combination of the following values.
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
        /// <see cref="DM_GRAYSCALE"/>
        /// </term>
        /// <term>
        /// Specifies that the display is a noncolor device. If this flag is not set, color is assumed. This flag is no longer valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DM_INTERLACED"/>
        /// </term>
        /// <term>
        /// Specifies that the display mode is interlaced. If the flag is not set, noninterlaced is assumed.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Display drivers use this member; for example, in the <see cref="ChangeDisplaySettings"/> function.
        /// Printer drivers don't use this member.
        /// </para>
        /// </summary>
        [FieldOffset(180)]
        public DWORD dmDisplayFlags;

        /// <summary>
        /// <para>
        /// For printers, specifies whether the print system handles "N-up" printing
        /// (playing multiple EMF logical pages onto a single physical page).
        /// The value of this member can be one of the following:
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
        /// <see cref="DMNUP_SYSTEM"/>
        /// </term>
        /// <term>
        /// The print system handles "N-up" printing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DMNUP_ONEUP"/>
        /// </term>
        /// <term>
        /// The print system does not handle "N-up" printing.
        /// An application can set <see cref="dmNup"/> to <see cref="DMNUP_ONEUP"/> if it intends to carry out "N-up" printing on its own.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// This member is not used for displays.
        /// </para>
        /// </summary>
        [FieldOffset(180)]
        public DeviceModesNUps dmNup;

        /// <summary>
        /// <para>
        /// For displays, specifies the frequency, in hertz, of a display device in its current mode.
        /// </para>
        /// <para>
        /// This member is not used for printers.
        /// </para>
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
