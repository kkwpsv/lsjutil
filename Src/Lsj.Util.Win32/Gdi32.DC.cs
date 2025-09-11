using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.COLORREF;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.BitmapCompressions;
using static Lsj.Util.Win32.Enums.BoundsRectAccumulationFlags;
using static Lsj.Util.Win32.Enums.CombineRgnModes;
using static Lsj.Util.Win32.Enums.DeviceCapIndexes;
using static Lsj.Util.Win32.Enums.DeviceTechnologies;
using static Lsj.Util.Win32.Enums.BackgroundModes;
using static Lsj.Util.Win32.Enums.DIBColorTableUsages;
using static Lsj.Util.Win32.Enums.EditControlStyles;
using static Lsj.Util.Win32.Enums.EscapeFunctions;
using static Lsj.Util.Win32.Enums.ExtendedWindowStyles;
using static Lsj.Util.Win32.Enums.GraphicsModes;
using static Lsj.Util.Win32.Enums.ICMModes;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.Enums.ObjTypes;
using static Lsj.Util.Win32.Enums.RasterCapabilities;
using static Lsj.Util.Win32.Enums.RasterCodes;
using static Lsj.Util.Win32.Enums.RasterOps;
using static Lsj.Util.Win32.Enums.RegionFlags;
using static Lsj.Util.Win32.Enums.StockObjectIndexes;
using static Lsj.Util.Win32.Enums.StretchBltModes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Msimg32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public static partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="BitBlt"/> function performs a bit-block transfer of the color data corresponding to
        /// a rectangle of pixels from the specified source device context into a destination device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-bitblt"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="cx">
        /// The width, in logical units, of the source and destination rectangles.
        /// </param>
        /// <param name="cy">
        /// The height, in logical units, of the source and the destination rectangles.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to the source device context.
        /// </param>
        /// <param name="x1">
        /// The x-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="y1">
        /// The y-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="rop">
        /// <para>
        /// A raster-operation code.
        /// These codes define how the color data for the source rectangle is to be combined
        /// with the color data for the destination rectangle to achieve the final color.
        /// </para>
        /// <para>
        /// The following list shows some common raster operation codes.
        /// </para>
        /// <para>
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
        /// <see cref="BLACKNESS"/>
        /// </term>
        /// <term>
        /// Fills the destination rectangle using the color associated with index 0 in the physical palette.
        /// (This color is black for the default physical palette.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CAPTUREBLT"/>
        /// </term>
        /// <term>
        /// Includes any windows that are layered on top of your window in the resulting image.
        /// By default, the image only contains your window.
        /// Note that this generally cannot be used for printing device contexts.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DSTINVERT"/>
        /// </term>
        /// <term>
        /// Inverts the destination rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MERGECOPY"/>
        /// </term>
        /// <term>
        /// Merges the colors of the source rectangle with the brush
        /// currently selected in <paramref name="hdc"/>, by using the Boolean AND operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MERGEPAINT"/>
        /// </term>
        /// <term>
        /// Merges the colors of the inverted source rectangle
        /// with the colors of the destination rectangle by using the Boolean OR operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NOMIRRORBITMAP"/>
        /// </term>
        /// <term>
        /// Prevents the bitmap from being mirrored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NOTSRCCOPY"/>
        /// </term>
        /// <term>
        /// Copies the inverted source rectangle to the destination.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NOTSRCERASE"/>
        /// </term>
        /// <term>
        /// Combines the colors of the source and destination rectangles
        /// by using the Boolean OR operator and then inverts the resultant color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PATCOPY"/>
        /// </term>
        /// <term>
        /// Copies the brush currently selected in <paramref name="hdc"/>, into the destination bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PATINVERT"/>
        /// </term>
        /// <term>
        /// Combines the colors of the brush currently selected in <paramref name="hdc"/>,
        /// with the colors of the destination rectangle by using the Boolean XOR operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PATPAINT"/>
        /// </term>
        /// <term>
        /// Combines the colors of the brush currently selected in <paramref name="hdc"/>,
        /// with the colors of the inverted source rectangle by using the Boolean OR operator.
        /// The result of this operation is combined with the colors
        /// of the destination rectangle by using the Boolean OR operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SRCAND"/>
        /// </term>
        /// <term>
        /// Combines the colors of the source and destination rectangles by using the Boolean AND operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SRCCOPY"/>
        /// </term>
        /// <term>
        /// Copies the source rectangle directly to the destination rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SRCERASE"/>
        /// </term>
        /// <term>
        /// Combines the inverted colors of the destination rectangle
        /// with the colors of the source rectangle by using the Boolean AND operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SRCINVERT"/>
        /// </term>
        /// <term>
        /// Combines the colors of the source and destination rectangles by using the Boolean XOR operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SRCPAINT"/>
        /// </term>
        /// <term>
        /// Combines the colors of the source and destination rectangles by using the Boolean OR operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHITENESS"/>
        /// </term>
        /// <term>
        /// Fills the destination rectangle using the color associated with index 1 in the physical palette.
        /// (This color is white for the default physical palette.)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="BitBlt"/> only does clipping on the destination DC.
        /// </para>
        /// <para>
        /// If a rotation or shear transformation is in effect in the source device context,
        /// <see cref="BitBlt"/> returns an error.
        /// If other transformations exist in the source device context
        /// (and a matching transformation is not in effect in the destination device context),
        /// the rectangle in the destination device context is stretched, compressed, or rotated, as necessary.
        /// </para>
        /// <para>
        /// If the color formats of the source and destination device contexts do not match,
        /// the <see cref="BitBlt"/> function converts the source color format to match the destination format.
        /// </para>
        /// <para>
        /// When an enhanced metafile is being recorded,
        /// an error occurs if the source device context identifies an enhanced-metafile device context.
        /// </para>
        /// <para>
        /// Not all devices support the <see cref="BitBlt"/> function.
        /// For more information, see the <see cref="RC_BITBLT"/> raster capability entry
        /// in the <see cref="GetDeviceCaps"/> function as well as the following functions:
        /// <see cref="MaskBlt"/>, <see cref="PlgBlt"/>, and <see cref="StretchBlt"/>.
        /// </para>
        /// <para>
        /// <see cref="BitBlt"/> returns an error if the source and destination device contexts represent different devices.
        /// To transfer data between DCs for different devices,
        /// convert the memory bitmap to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </para>
        /// <para>
        /// ICM: No color management is performed when blits occur.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "BitBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL BitBlt([In] HDC hdc, [In] int x, [In] int y, [In] int cx, [In] int cy, [In] HDC hdcSrc,
            [In] int x1, [In] int y1, [In] RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="CancelDC"/> function cancels any pending operation on the specified device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-canceldc"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CancelDC"/> function is used by multithreaded applications to cancel lengthy drawing operations.
        /// If thread A initiates a lengthy drawing operation, thread B may cancel that operation by calling this function.
        /// </para>
        /// <para>
        /// If an operation is canceled, the affected thread returns an error and the result of its drawing operation is undefined.
        /// The results are also undefined if no drawing operation was in progress when the function was called.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CancelDC", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CancelDC([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="CreateCompatibleDC"/> function creates a memory device context (DC) compatible with the specified device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createcompatibledc"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to an existing DC.
        /// If this handle is <see cref="NULL"/>, the function creates a memory DC compatible with the application's current screen.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to a memory DC.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A memory DC exists only in memory.
        /// When the memory DC is created, its display surface is exactly one monochrome pixel wide and one monochrome pixel high.
        /// Before an application can use a memory DC for drawing operations,
        /// it must select a bitmap of the correct width and height into the DC.
        /// To select a bitmap into a DC, use the <see cref="CreateCompatibleBitmap"/> function,
        /// specifying the height, width, and color organization required.
        /// </para>
        /// <para>
        /// When a memory DC is created, all attributes are set to normal default values.
        /// The memory DC can be used as a normal DC.
        /// You can set the attributes; obtain the current settings of its attributes; and select pens, brushes, and regions.
        /// </para>
        /// <para>
        /// The <see cref="CreateCompatibleDC"/> function can only be used with devices that support raster operations.
        /// An application can determine whether a device supports these operations by calling the <see cref="GetDeviceCaps"/> function.
        /// </para>
        /// <para>
        /// When you no longer need the memory DC, call the <see cref="DeleteDC"/> function.
        /// We recommend that you call <see cref="DeleteDC"/> to delete the DC.
        /// However, you can also call <see cref="DeleteObject"/> with the HDC to delete the DC.
        /// </para>
        /// <para>
        /// If <paramref name="hdc"/> is <see cref="NULL"/>,
        /// the thread that calls <see cref="CreateCompatibleDC"/> owns the <see cref="HDC"/> that is created.
        /// When this thread is destroyed, the <see cref="HDC"/> is no longer valid.
        /// Thus, if you create the <see cref="HDC"/> and pass it to another thread,
        /// then exit the first thread, the second thread will not be able to use the HDC.
        /// </para>
        /// <para>
        /// ICM: If the DC that is passed to this function is enabled for Image Color Management (ICM),
        /// the DC created by the function is ICM-enabled.
        /// The source and destination color spaces are specified in the DC.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleDC", ExactSpelling = true, SetLastError = true)]
        public static extern HDC CreateCompatibleDC([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDC"/> function creates a device context (DC) for a device using the specified name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createdcw"/>
        /// </para>
        /// </summary>
        /// <param name="pwszDriver">
        /// A pointer to a null-terminated character string that specifies either DISPLAY or the name of a specific display device.
        /// For printing, we recommend that you pass <see cref="NULL"/> to <paramref name="pwszDriver"/>
        /// because GDI ignores <paramref name="pwszDriver"/> for printer devices.
        /// </param>
        /// <param name="pwszDevice">
        /// <para>
        /// A pointer to a null-terminated character string that specifies the name of the specific output device being used,
        /// as shown by the Print Manager (for example, Epson FX-80). It is not the printer model name.
        /// The <paramref name="pwszDevice"/> parameter must be used.
        /// </para>
        /// <para>
        /// To obtain valid names for displays, call <see cref="EnumDisplayDevices"/>.
        /// </para>
        /// <para>
        /// If <paramref name="pwszDriver"/> is DISPLAY or the device name of a specific display device,
        /// then <paramref name="pwszDevice"/> must be <see cref="NULL"/> or that same device name.
        /// If <paramref name="pwszDevice"/> is <see cref="NULL"/>, then a DC is created for the primary display device.
        /// </para>
        /// <para>
        /// If there are multiple monitors on the system,
        /// calling <c>CreateDC(TEXT("DISPLAY"),NULL,NULL,NULL)</c> will create a DC covering all the monitors.
        /// </para>
        /// </param>
        /// <param name="pszPort">
        /// This parameter is ignored and should be set to <see cref="NULL"/>.
        /// It is provided only for compatibility with 16-bit Windows.
        /// </param>
        /// <param name="pdm">
        /// <para>
        /// A pointer to a <see cref="DEVMODE"/> structure containing device-specific initialization data for the device driver.
        /// The <see cref="DocumentProperties"/> function retrieves this structure filled in for a specified device.
        /// The <paramref name="pdm"/> parameter must be <see cref="NULL"/>
        /// if the device driver is to use the default initialization (if any) specified by the user.
        /// </para>
        /// <para>
        /// If <paramref name="pwszDriver"/> is DISPLAY, <paramref name="pdm"/> must be <see cref="NullRef{DEVMODE}"/>;
        /// GDI then uses the display device's current <see cref="DEVMODE"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to a DC for the specified device.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note that the handle to the DC can only be used by a single thread at any one time.
        /// </para>
        /// <para>
        /// For parameters <paramref name="pwszDriver"/> and <paramref name="pwszDevice"/>,
        /// call <see cref="EnumDisplayDevices"/> to obtain valid names for displays.
        /// </para>
        /// <para>
        /// When you no longer need the DC, call the <see cref="DeleteDC"/> function.
        /// </para>
        /// <para>
        /// If <paramref name="pwszDriver"/> or <paramref name="pwszDevice"/> is DISPLAY,
        /// the thread that calls <see cref="CreateDC"/> owns the <see cref="HDC"/> that is created.
        /// When this thread is destroyed, the <see cref="HDC"/> is no longer valid.
        /// Thus, if you create the <see cref="HDC"/> and pass it to another thread, then exit the first thread,
        /// the second thread will not be able to use the <see cref="HDC"/>.
        /// </para>
        /// <para>
        /// When you call <see cref="CreateDC"/> to create the <see cref="HDC"/> for a display device,
        /// you must pass to <paramref name="pdm"/> either <see cref="NULL"/>
        /// or a pointer to <see cref="DEVMODE"/> that matches the current <see cref="DEVMODE"/>
        /// of the display device that <paramref name="pwszDevice"/> specifies.
        /// We recommend to pass <see cref="NULL"/> and not to try to exactly match the <see cref="DEVMODE"/> for the current display device.
        /// </para>
        /// <para>
        /// When you call <see cref="CreateDC"/> to create the <see cref="HDC"/> for a printer device,
        /// the printer driver validates the <see cref="DEVMODE"/>.
        /// If the printer driver determines that the <see cref="DEVMODE"/> is invalid
        /// (that is, printer driver can’t convert or consume the <see cref="DEVMODE"/>),
        /// the printer driver provides a default <see cref="DEVMODE"/> to create the HDC for the printer device.
        /// </para>
        /// <para>
        /// ICM: To enable ICM, set the <see cref="DEVMODE.dmICMMethod"/> member of the <see cref="DEVMODE"/> structure
        /// (pointed to by the <paramref name="pdm"/> parameter) to the appropriate value.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDCW", ExactSpelling = true, SetLastError = true)]
        public static extern HDC CreateDC([In] LPCWSTR pwszDriver, [In] LPCWSTR pwszDevice, [In] LPCWSTR pszPort, [In] in DEVMODE pdm);

        /// <summary>
        /// <para>
        /// The <see cref="CreateIC"/> function creates an information context for the specified device.
        /// The information context provides a fast way to get information about the device without creating a device context (DC).
        /// However, GDI drawing functions cannot accept a handle to an information context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createicw"/>
        /// </para>
        /// </summary>
        /// <param name="pszDriver">
        /// A pointer to a null-terminated character string that specifies the name of the device driver (for example, Epson).
        /// </param>
        /// <param name="pszDevice">
        /// A pointer to a null-terminated character string that specifies the name of the specific output device being used,
        /// as shown by the Print Manager (for example, Epson FX-80).
        /// It is not the printer model name.
        /// The <paramref name="pszDevice"/> parameter must be used.
        /// </param>
        /// <param name="pszPort">
        /// This parameter is ignored and should be set to <see cref="NULL"/>.
        /// It is provided only for compatibility with 16-bit Windows.
        /// </param>
        /// <param name="pdm">
        /// A pointer to a <see cref="DEVMODE"/> structure containing device-specific initialization data for the device driver.
        /// The <see cref="DocumentProperties"/> function retrieves this structure filled in for a specified device.
        /// The <paramref name="pdm"/> parameter must be <see cref="NullRef{DEVMODE}"/> if the device driver is to use the default initialization
        /// (if any) specified by the user.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to an information context.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// When you no longer need the information DC, call the <see cref="DeleteDC"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateICW", ExactSpelling = true, SetLastError = true)]
        public static extern HDC CreateIC([In] LPWSTR pszDriver, [In] LPWSTR pszDevice, [In] LPWSTR pszPort, [In] in DEVMODE pdm);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteDC"/> function deletes the specified device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deletedc"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteDC", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteDC([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="ExcludeClipRect"/> function creates a new clipping region
        /// that consists of the existing clipping region minus the specified rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-excludecliprect"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="left">
        /// The x-coordinate, in logical units, of the upper-left corner of the rectangle.
        /// </param>
        /// <param name="top">
        /// The y-coordinate, in logical units, of the upper-left corner of the rectangle.
        /// </param>
        /// <param name="right">
        /// The x-coordinate, in logical units, of the lower-right corner of the rectangle.
        /// </param>
        /// <param name="bottom">
        /// The y-coordinate, in logical units, of the lower-right corner of the rectangle.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the new clipping region's complexity;
        /// it can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// No region was created.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The lower and right edges of the specified rectangle are not excluded from the clipping region.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExcludeClipRect", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags ExcludeClipRect([In] HDC hdc, [In] int left, [In] int top, [In] int right, [In] int bottom);

        /// <summary>
        /// <para>
        /// The <see cref="ExtSelectClipRgn"/> function combines the specified region
        /// with the current clipping region using the specified mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-extselectcliprgn"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// A handle to the region to be selected. 
        /// This handle must not be <see cref="NULL"/> unless the <see cref="RGN_COPY"/> mode is specified.
        /// </param>
        /// <param name="mode">
        /// <para>
        /// The operation to be performed.
        /// It must be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="RGN_AND"/>
        /// </term>
        /// <term>
        /// The new clipping region combines the overlapping areas of the current clipping region and the region identified by <paramref name="hrgn"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_COPY"/>
        /// </term>
        /// <term>
        /// The new clipping region is a copy of the region identified by <paramref name="hrgn"/>.
        /// This is identical to <see cref="SelectClipRgn"/>.
        /// If the region identified by <paramref name="hrgn"/> is <see cref="NULL"/>,
        /// the new clipping region is the default clipping region (the default clipping region is a null region).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_DIFF"/>
        /// </term>
        /// <term>
        /// The new clipping region combines the areas of the current clipping region
        /// with those areas excluded from the region identified by <paramref name="hrgn"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_OR"/>
        /// </term>
        /// <term>
        /// The new clipping region combines the current clipping region
        /// and the region identified by <paramref name="hrgn"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_XOR"/>
        /// </term>
        /// <term>
        /// The new clipping region combines the current clipping region
        /// and the region identified by <paramref name="hrgn"/> but excludes any overlapping areas.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the new clipping region's complexity;
        /// it can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If an error occurs when this function is called, the previous clipping region for the specified device context is not affected.
        /// </para>
        /// <para>
        /// The <see cref="ExtSelectClipRgn"/> function assumes that the coordinates for the specified region are specified in device units.
        /// </para>
        /// <para>
        /// Only a copy of the region identified by the <paramref name="hrgn"/> parameter is used.
        /// The region itself can be reused after this call or it can be deleted.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtSelectClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags ExtSelectClipRgn([In] HDC hdc, [In] HRGN hrgn, [In] CombineRgnModes mode);

        /// <summary>
        /// <para>
        /// The <see cref="GdiAlphaBlend"/> function displays bitmaps that have transparent or semitransparent pixels.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdialphablend"/>
        /// </para>
        /// </summary>
        /// <param name="hdcDest">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="xoriginDest">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="yoriginDest">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="wDest">
        /// The width, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="hDest">
        /// The height, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to the source device context.
        /// </param>
        /// <param name="xoriginSrc">
        /// The x-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="yoriginSrc">
        /// The y-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="wSrc">
        /// The width, in logical units, of the source rectangle.
        /// </param>
        /// <param name="hSrc">
        /// The height, in logical units, of the source rectangle.
        /// </param>
        /// <param name="ftn">
        /// The alpha-blending function for source and destination bitmaps, a global alpha value
        /// to be applied to the entire source bitmap, and format information for the source bitmap.
        /// The source and destination blend functions are currently limited to <see cref="AC_SRC_OVER"/>.
        /// See the <see cref="BLENDFUNCTION"/> and <see cref="EMRALPHABLEND"/> structures.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// This function can return the following value.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// One or more of the input parameters is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function is the same as <see cref="AlphaBlend"/>.
        /// </para>
        /// <para>
        /// If the source rectangle and destination rectangle are not the same size,
        /// the source bitmap is stretched to match the destination rectangle.
        /// If the <see cref="SetStretchBltMode"/> function is used,
        /// the iStretchMode value is automatically converted to <see cref="COLORONCOLOR"/> for this function
        /// (that is, <see cref="BLACKONWHITE"/>, <see cref="WHITEONBLACK"/>,
        /// and <see cref="HALFTONE"/> are changed to <see cref="COLORONCOLOR"/>).
        /// </para>
        /// <para>
        /// The destination coordinates are transformed
        /// by using the transformation currently specified for the destination device context.
        /// The source coordinates are transformed
        /// by using the transformation currently specified for the source device context.
        /// </para>
        /// <para>
        /// An error occurs (and the function returns <see cref="FALSE"/>) 
        /// if the source device context identifies an enhanced metafile device context.
        /// </para>
        /// <para>
        /// If destination and source bitmaps do not have the same color format,
        /// <see cref="GdiAlphaBlend"/> converts the source bitmap to match the destination bitmap.
        /// </para>
        /// <para>
        /// <see cref="GdiAlphaBlend"/> does not support mirroring.
        /// If either the width or height of the source or destination is negative, this call will fail.
        /// </para>
        /// <para>
        /// When rendering to a printer, first call <see cref="GetDeviceCaps"/> with <see cref="SHADEBLENDCAPS"/>
        /// to determine if the printer supports blending with <see cref="GdiAlphaBlend"/>.
        /// Note that, for a display DC, all blending operations are supported
        /// and these flags represent whether the operations are accelerated.
        /// </para>
        /// <para>
        /// If the source and destination are the same surface, that is,
        /// they are both the screen or the same memory bitmap and the source and destination rectangles overlap,
        /// an error occurs and the function returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// The source rectangle must lie completely within the source surface,
        /// otherwise an error occurs and the function returns <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// <see cref="GdiAlphaBlend"/> fails if the width or height of the source or destination is negative.
        /// </para>
        /// <para>
        /// The <see cref="BLENDFUNCTION.SourceConstantAlpha"/> member of <see cref="BLENDFUNCTION"/>
        /// specifies an alpha transparency value to be used on the entire source bitmap.
        /// The <see cref="BLENDFUNCTION.SourceConstantAlpha"/> value is combined with any per-pixel alpha values.
        /// If <see cref="BLENDFUNCTION.SourceConstantAlpha"/> is 0, it is assumed that the image is transparent.
        /// Set the <see cref="BLENDFUNCTION.SourceConstantAlpha"/> value to 255
        /// (which indicates that the image is opaque) when you only want to use per-pixel alpha values.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiAlphaBlend", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiAlphaBlend([In] HDC hdcDest, [In] int xoriginDest, [In] int yoriginDest, [In] int wDest,
            [In] int hDest, [In] HDC hdcSrc, [In] int xoriginSrc, [In] int yoriginSrc, [In] int wSrc, [In] int hSrc, [In] BLENDFUNCTION ftn);

        /// <summary>
        /// <para>
        /// The <see cref="GdiTransparentBlt"/> function performs a bit-block transfer of the color data
        /// corresponding to a rectangle of pixels from the specified source device context into a destination device context.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function is the same as <see cref="TransparentBlt"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gditransparentblt"/>
        /// </para>
        /// </summary>
        /// <param name="hdcDest">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="xoriginDest">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="yoriginDest">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="wDest">
        /// The width, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="hDest">
        /// The height, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to the source device context.
        /// </param>
        /// <param name="xoriginSrc">
        /// The x-coordinate, in logical units, of the source rectangle.
        /// </param>
        /// <param name="yoriginSrc">
        /// The y-coordinate, in logical units, of the source rectangle.
        /// </param>
        /// <param name="wSrc">
        /// The width, in logical units, of the source rectangle.
        /// </param>
        /// <param name="hSrc">
        /// The height, in logical units, of the source rectangle.
        /// </param>
        /// <param name="crTransparent">
        /// The RGB color in the source bitmap to treat as transparent.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GdiTransparentBlt"/> function works with compatible bitmaps (DDBs).
        /// </para>
        /// <para>
        /// The <see cref="GdiTransparentBlt"/> function supports all formats of source bitmaps.
        /// However, for 32 bpp bitmaps, it just copies the alpha value over.
        /// Use <see cref="AlphaBlend"/> to specify 32 bits-per-pixel bitmaps with transparency.
        /// </para>
        /// <para>
        /// If the source and destination rectangles are not the same size,
        /// the source bitmap is stretched to match the destination rectangle.
        /// When the <see cref="SetStretchBltMode"/> function is used,
        /// the iStretchMode modes of <see cref="BLACKONWHITE"/> and <see cref="WHITEONBLACK"/>
        /// are converted to <see cref="COLORONCOLOR"/> for the <see cref="GdiTransparentBlt"/> function.
        /// </para>
        /// <para>
        /// The destination device context specifies the transformation type for the destination coordinates.
        /// The source device context specifies the transformation type for the source coordinates.
        /// </para>
        /// <para>
        /// <see cref="GdiTransparentBlt"/> does not mirror a bitmap
        /// if either the width or height, of either the source or destination, is negative.
        /// </para>
        /// <para>
        /// When used in a multiple monitor system,
        /// both <paramref name="hdcSrc"/> and <paramref name="hdcDest"/> must refer to the same device or the function will fail.
        /// To transfer data between DCs for different devices,
        /// convert the memory bitmap to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiTransparentBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiTransparentBlt([In] HDC hdcDest, [In] int xoriginDest, [In] int yoriginDest, [In] int wDest,
            [In] int hDest, [In] HDC hdcSrc, [In] int xoriginSrc, [In] int yoriginSrc, [In] int wSrc, [In] int hSrc, [In] UINT crTransparent);

        /// <summary>
        /// <para>
        /// The <see cref="GetBkColor"/> function returns the current background color for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getbkcolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context whose background color is to be returned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a <see cref="COLORREF"/> value for the current background color.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBkColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF GetBkColor([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetBkMode"/> function returns the current background mix mode for a specified device context.
        /// The background mix mode of a device context affects text, hatched brushes, and pen styles that are not solid lines.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getbkmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context whose background mode is to be returned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the current background mix mode,
        /// either <see cref="OPAQUE"/> or <see cref="TRANSPARENT"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBkMode", ExactSpelling = true, SetLastError = true)]
        public static extern BackgroundModes GetBkMode([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetBoundsRect"/> function obtains the current accumulated bounding rectangle for a specified device context.
        /// </para>
        /// <para>
        /// The system maintains an accumulated bounding rectangle for each application.
        /// An application can retrieve and set this rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getboundsrect"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context whose bounding rectangle the function will return.
        /// </param>
        /// <param name="lprect">
        /// A pointer to the <see cref="RECT"/> structure that will receive the current bounding rectangle.
        /// The application's rectangle is returned in logical coordinates,
        /// and the bounding rectangle is returned in screen coordinates.
        /// </param>
        /// <param name="flags">
        /// <para>
        /// Specifies how the <see cref="GetBoundsRect"/> function will behave. This parameter can be the following value.
        /// </para>
        /// <para>
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
        /// <see cref="DCB_RESET"/>
        /// </term>
        /// <term>
        /// Clears the bounding rectangle after returning it.
        /// If this flag is not set, the bounding rectangle will not be cleared.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// he return value specifies the state of the accumulated bounding rectangle;
        /// it can be one of the following values.
        /// </para>
        /// <para>
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
        /// 0
        /// </term>
        /// <term>
        /// An error occurred.
        /// The specified device context handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCB_DISABLE"/>
        /// </term>
        /// <term>
        /// Boundary accumulation is off.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCB_ENABLE"/>
        /// </term>
        /// <term>
        /// Boundary accumulation is on.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCB_RESET"/>
        /// </term>
        /// <term>
        /// The bounding rectangle is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCB_SET"/>
        /// </term>
        /// <term>
        /// The bounding rectangle is not empty.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="DCB_SET"/> value is a combination of the bit values <see cref="DCB_ACCUMULATE"/> and <see cref="DCB_RESET"/>.
        /// Applications that check the <see cref="DCB_RESET"/> bit to determine whether the bounding rectangle is empty
        /// must also check the <see cref="DCB_ACCUMULATE"/> bit.
        /// The bounding rectangle is empty only if the <see cref="DCB_RESET"/> bit is 1 and the <see cref="DCB_ACCUMULATE"/> bit is 0.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBoundsRect", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetBoundsRect([In] HDC hdc, [Out] out RECT lprect, [In] BoundsRectAccumulationFlags flags);

        /// <summary>
        /// <para>
        /// The <see cref="GetClipBox"/> function retrieves the dimensions of the tightest bounding rectangle that can be drawn
        /// around the current visible area on the device.
        /// The visible area is defined by the current clipping region or clip path, as well as any overlapping windows.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getclipbox"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lprect">
        /// A pointer to a <see cref="RECT"/> structure that is to receive the rectangle dimensions, in logical units.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the clipping box's complexity and can be one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// <see cref="GetClipBox"/> returns logical coordinates based on the given device context.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipBox", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags GetClipBox([In] HDC hdc, [Out] out RECT lprect);

        /// <summary>
        /// <para>
        /// The <see cref="GetClipRgn"/> function retrieves a handle identifying
        /// the current application-defined clipping region for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcliprgn"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// A handle to an existing region before the function is called.
        /// After the function returns, this parameter is a handle to a copy of the current clipping region.
        /// </param>
        /// <returns>
        /// If the function succeeds and there is no clipping region for the given device context, the return value is zero.
        /// If the function succeeds and there is a clipping region for the given device context, the return value is 1.
        /// If an error occurs, the return value is -1.
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application-defined clipping region is a clipping region identified by the <see cref="SelectClipRgn"/> function.
        /// It is not a clipping region created when the application calls the <see cref="BeginPaint"/> function.
        /// </para>
        /// <para>
        /// If the function succeeds, the <paramref name="hrgn"/> parameter is a handle to a copy of the current clipping region.
        /// Subsequent changes to this copy will not affect the current clipping region.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern int GetClipRgn([In] HDC hdc, [In] HRGN hrgn);

        /// <summary>
        /// <para>
        /// The <see cref="GetColorAdjustment"/> function retrieves the color adjustment values for the specified device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcoloradjustment"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpca">
        /// A pointer to a <see cref="COLORADJUSTMENT"/> structure that receives the color adjustment values.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetColorAdjustment", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetColorAdjustment([In] HDC hdc, [Out] out COLORADJUSTMENT lpca);

        /// <summary>
        /// <para>
        /// The <see cref="GetCurrentObject"/> function retrieves a handle to an object of the specified type
        /// that has been selected into the specified device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcurrentobject"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <param name="type">
        /// <para>
        /// The object type to be queried.
        /// This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="OBJ_BITMAP"/>
        /// </term>
        /// <term>
        /// Returns the current selected bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBJ_BRUSH"/>
        /// </term>
        /// <term>
        /// Returns the current selected brush.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBJ_COLORSPACE"/>
        /// </term>
        /// <term>
        /// Returns the current color space.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBJ_FONT"/>
        /// </term>
        /// <term>
        /// Returns the current selected font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBJ_PAL"/>
        /// </term>
        /// <term>
        /// Returns the current selected palette.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OBJ_PEN"/>
        /// </term>
        /// <term>
        /// Returns the current selected pen.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the specified object.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// An application can use the <see cref="GetCurrentObject"/> and <see cref="GetObject"/> functions
        /// to retrieve descriptions of the graphic objects currently selected into the specified DC.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentObject", ExactSpelling = true, SetLastError = true)]
        public static extern HGDIOBJ GetCurrentObject([In] HDC hdc, [In] ObjTypes type);

        /// <summary>
        /// <para>
        /// The <see cref="GetDCBrushColor"/> function retrieves the current brush color for the specified device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdcbrushcolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC whose brush color is to be returned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the <see cref="COLORREF"/> value for the current DC brush color.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For information on setting the brush color, see <see cref="SetDCBrushColor"/>.
        /// </para>
        /// <para>
        /// ICM: Color management is performed if ICM is enabled.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDCBrushColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF GetDCBrushColor([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetDCOrgEx"/> function retrieves the final translation origin for a specified device context (DC).
        /// The final translation origin specifies an offset that the system uses
        /// to translate device coordinates into client coordinates (for coordinates in an application's window).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdcorgex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC whose final translation origin is to be retrieved.
        /// </param>
        /// <param name="lppt">
        /// A pointer to a <see cref="POINT"/> structure that receives the final translation origin, in device coordinates.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The final translation origin is relative to the physical origin of the screen.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDCOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetDCOrgEx([In] HDC hdc, [Out] out POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="GetDCPenColor"/> function retrieves the current pen color for the specified device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdcpencolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC whose brush color is to be returned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a <see cref="COLORREF"/> value for the current DC pen color.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For information on setting the pen color, see <see cref="SetDCPenColor"/>.
        /// </para>
        /// <para>
        /// ICM: Color management is performed if ICM is enabled.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDCPenColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF GetDCPenColor([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetDeviceCaps"/> function retrieves device-specific information for the specified device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdevicecaps"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <param name="nIndex">
        /// <para>
        /// The item to be returned. This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Index
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="DRIVERVERSION"/>
        /// </term>
        /// <term>
        /// The device driver version.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TECHNOLOGY"/>
        /// </term>
        /// <term>
        /// <para>
        /// Device technology. It can be any one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="DT_PLOTTER"/>
        /// </term>
        /// <term>
        /// Vector plotter
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="DT_RASDISPLAY"/>
        /// </term>
        /// <term>
        /// Raster display
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_RASPRINTER"/>
        /// </term>
        /// <term>
        /// Raster printer
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_RASCAMERA"/>
        /// </term>
        /// <term>
        /// Raster camera
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_CHARSTREAM"/>
        /// </term>
        /// <term>
        /// Character stream
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_METAFILE"/>
        /// </term>
        /// <term>
        /// Metafile
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DT_DISPFILE"/>
        /// </term>
        /// <term>
        /// Display file
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the <paramref name="hdc"/> parameter is a handle to the DC of an enhanced metafile,
        /// the device technology is that of the referenced device as specified to the <see cref="CreateEnhMetaFile"/> function.
        /// To determine whether it is an enhanced metafile DC, use the <see cref="GetObjectType"/> function.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HORZSIZE"/>
        /// </term>
        /// <term>
        /// Width, in millimeters, of the physical screen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VERTSIZE"/>
        /// </term>
        /// <term>
        /// Height, in millimeters, of the physical screen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HORZRES"/>
        /// </term>
        /// <term>
        /// Width, in pixels, of the screen; or for printers, the width, in pixels, of the printable area of the page.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VERTRES"/>
        /// </term>
        /// <term>
        /// Height, in raster lines, of the screen; or for printers, the height, in pixels, of the printable area of the page.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOGPIXELSX"/>
        /// </term>
        /// <term>
        /// Number of pixels per logical inch along the screen width.
        /// In a system with multiple display monitors, this value is the same for all monitors.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LOGPIXELSY"/>
        /// </term>
        /// <term>
        /// Number of pixels per logical inch along the screen height.
        /// In a system with multiple display monitors, this value is the same for all monitors.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BITSPIXEL"/>
        /// </term>
        /// <term>
        /// Number of adjacent color bits for each pixel.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PLANES"/>
        /// </term>
        /// <term>
        /// Number of color planes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NUMBRUSHES"/>
        /// </term>
        /// <term>
        /// Number of device-specific brushes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NUMPENS"/>
        /// </term>
        /// <term>
        /// Number of device-specific pens.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NUMFONTS"/>
        /// </term>
        /// <term>
        /// Number of device-specific fonts.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NUMCOLORS"/>
        /// </term>
        /// <term>
        /// Number of entries in the device's color table, if the device has a color depth of no more than 8 bits per pixel.
        /// For devices with greater color depths, -1 is returned.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ASPECTX"/>
        /// </term>
        /// <term>
        /// Relative width of a device pixel used for line drawing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ASPECTY"/>
        /// </term>
        /// <term>
        /// Relative height of a device pixel used for line drawing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ASPECTXY"/>
        /// </term>
        /// <term>
        /// Diagonal width of the device pixel used for line drawing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PDEVICESIZE"/>
        /// </term>
        /// <term>
        /// Reserved.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CLIPCAPS"/>
        /// </term>
        /// <term>
        /// Flag that indicates the clipping capabilities of the device.
        /// If the device can clip to a rectangle, it is 1. Otherwise, it is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIZEPALETTE"/>
        /// </term>
        /// <term>
        /// Number of entries in the system palette.
        /// This index is valid only if the device driver sets the <see cref="RC_PALETTE"/> bit in the <see cref="RASTERCAPS"/> index
        /// and is available only if the driver is compatible with 16-bit Windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NUMRESERVED"/>
        /// </term>
        /// <term>
        /// Number of reserved entries in the system palette.
        /// This index is valid only if the device driver sets the <see cref="RC_PALETTE"/> bit in the <see cref="RASTERCAPS"/> index
        /// and is available only if the driver is compatible with 16-bit Windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COLORRES"/>
        /// </term>
        /// <term>
        /// Actual color resolution of the device, in bits per pixel.
        /// This index is valid only if the device driver sets the <see cref="RC_PALETTE"/> bit in the <see cref="RASTERCAPS"/> index
        /// and is available only if the driver is compatible with 16-bit Windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PHYSICALWIDTH"/>
        /// </term>
        /// <term>
        /// For printing devices: the width of the physical page, in device units.
        /// For example, a printer set to print at 600 dpi on 8.5-x11-inch paper has a physical width value of 5100 device units.
        /// Note that the physical page is almost always greater than the printable area of the page, and never smaller.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PHYSICALHEIGHT"/>
        /// </term>
        /// <term>
        /// For printing devices: the height of the physical page, in device units.
        /// For example, a printer set to print at 600 dpi on 8.5-by-11-inch paper has a physical height value of 6600 device units.
        /// Note that the physical page is almost always greater than the printable area of the page, and never smaller.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PHYSICALOFFSETX"/>
        /// </term>
        /// <term>
        /// For printing devices: the distance from the left edge of the physical page to the left edge of the printable area, in device units.
        /// For example, a printer set to print at 600 dpi on 8.5-by-11-inch paper,
        /// that cannot print on the leftmost 0.25-inch of paper, has a horizontal physical offset of 150 device units.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PHYSICALOFFSETY"/>
        /// </term>
        /// <term>
        /// For printing devices: the distance from the top edge of the physical page to the top edge of the printable area, in device units.
        /// For example, a printer set to print at 600 dpi on 8.5-by-11-inch paper,
        /// that cannot print on the topmost 0.5-inch of paper, has a vertical physical offset of 300 device units.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VREFRESH"/>
        /// </term>
        /// <term>
        /// <para>
        /// For display devices: the current vertical refresh rate of the device, in cycles per second (Hz).
        /// </para>
        /// <para>
        /// A vertical refresh rate value of 0 or 1 represents the display hardware's default refresh rate.
        /// This default rate is typically set by switches on a display card or computer motherboard,
        /// or by a configuration program that does not use display functions such as <see cref="ChangeDisplaySettings"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SCALINGFACTORX"/>
        /// </term>
        /// <term>
        /// Scaling factor for the x-axis of the printer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SCALINGFACTORY"/>
        /// </term>
        /// <term>
        /// Scaling factor for the y-axis of the printer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BLTALIGNMENT"/>
        /// </term>
        /// <term>
        /// Preferred horizontal drawing alignment, expressed as a multiple of pixels.
        /// For best drawing performance, windows should be horizontally aligned to a multiple of this value.
        /// A value of zero indicates that the device is accelerated, and any alignment may be used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SHADEBLENDCAPS"/>
        /// </term>
        /// <term>
        /// <para>
        /// Value that indicates the shading and blending capabilities of the device.
        /// See Remarks for further comments.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="SB_CONST_ALPHA"/>
        /// </term>
        /// <term>
        /// Handles the <see cref="BLENDFUNCTION.SourceConstantAlpha"/> member of the <see cref="BLENDFUNCTION"/> structure,
        /// which is referenced by the blendFunction parameter of the <see cref="AlphaBlend"/> function.
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="SB_GRAD_RECT"/>
        /// </term>
        /// <term>
        /// Capable of doing <see cref="GradientFill"/> rectangles.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_GRAD_TRI"/>
        /// </term>
        /// <term>
        /// Capable of doing <see cref="GradientFill"/> triangles.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_NONE"/>
        /// </term>
        /// <term>
        /// Device does not support any of these capabilities.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_PIXEL_ALPHA"/>
        /// </term>
        /// <term>
        /// Capable of handling per-pixel alpha in <see cref="AlphaBlend"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SB_PREMULT_ALPHA"/>
        /// </term>
        /// <term>
        /// Capable of handling premultiplied alpha in <see cref="AlphaBlend"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RASTERCAPS"/>
        /// </term>
        /// <term>
        /// <para>
        /// Value that indicates the raster capabilities of the device, as shown in the following table.
        /// </para>
        /// <para>
        /// /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="RC_BANDING"/>
        /// </term>
        /// <term>
        /// Requires banding support.
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="RC_BITBLT"/>
        /// </term>
        /// <term>
        /// Capable of transferring bitmaps.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RC_BITMAP64"/>
        /// </term>
        /// <term>
        /// Capable of supporting bitmaps larger than 64 KB.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RC_DI_BITMAP"/>
        /// </term>
        /// <term>
        /// Capable of supporting the <see cref="SetDIBits"/> and <see cref="GetDIBits"/> functions.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RC_DIBTODEV"/>
        /// </term>
        /// <term>
        /// Capable of supporting the <see cref="SetDIBitsToDevice"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RC_FLOODFILL"/>
        /// </term>
        /// <term>
        /// Capable of performing flood fills.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RC_PALETTE"/>
        /// </term>
        /// <term>
        /// Specifies a palette-based device.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RC_SCALING"/>
        /// </term>
        /// <term>
        /// Capable of scaling.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RC_STRETCHBLT"/>
        /// </term>
        /// <term>
        /// Capable of performing the <see cref="StretchBlt"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RC_STRETCHDIB"/>
        /// </term>
        /// <term>
        /// Capable of performing the <see cref="StretchDIBits"/> function.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CURVECAPS"/>
        /// </term>
        /// <term>
        /// <para>
        /// Value that indicates the curve capabilities of the device, as shown in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="CC_NONE"/>
        /// </term>
        /// <term>
        /// Device does not support curves.
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="CC_CHORD"/>
        /// </term>
        /// <term>
        /// Device can draw chord arcs.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_CIRCLES"/>
        /// </term>
        /// <term>
        /// Device can draw circles.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_ELLIPSES"/>
        /// </term>
        /// <term>
        /// Device can draw ellipses.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_INTERIORS"/>
        /// </term>
        /// <term>
        /// Device can draw interiors.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_PIE"/>
        /// </term>
        /// <term>
        /// Device can draw pie wedges.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_ROUNDRECT"/>
        /// </term>
        /// <term>
        /// Device can draw rounded rectangles.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_STYLED"/>
        /// </term>
        /// <term>
        /// Device can draw styled borders.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_WIDE"/>
        /// </term>
        /// <term>
        /// Device can draw wide borders.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CC_WIDESTYLED"/>
        /// </term>
        /// <term>
        /// Device can draw borders that are wide and styled.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LINECAPS"/>
        /// </term>
        /// <term>
        /// <para>
        /// Value that indicates the line capabilities of the device, as shown in the following table:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="LC_NONE"/>
        /// </term>
        /// <term>
        /// Device does not support lines.
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="LC_INTERIORS"/>
        /// </term>
        /// <term>
        /// Device can draw interiors.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LC_MARKER"/>
        /// </term>
        /// <term>
        /// Device can draw a marker.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LC_POLYLINE"/>
        /// </term>
        /// <term>
        /// Device can draw a polyline.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LC_POLYMARKER"/>
        /// </term>
        /// <term>
        /// Device can draw multiple markers.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LC_STYLED"/>
        /// </term>
        /// <term>
        /// Device can draw styled lines.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LC_WIDE"/>
        /// </term>
        /// <term>
        /// Device can draw wide lines.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LC_WIDESTYLED"/>
        /// </term>
        /// <term>
        /// Device can draw lines that are wide and styled.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="POLYGONALCAPS"/>
        /// </term>
        /// <term>
        /// <para>
        /// Value that indicates the polygon capabilities of the device, as shown in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// PC_NONE
        /// </term>
        /// <term>
        /// Device does not support polygons.
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PC_INTERIORS"/>
        /// </term>
        /// <term>
        /// Device can draw interiors.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PC_POLYGON"/>
        /// </term>
        /// <term>
        /// Device can draw alternate-fill polygons.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PC_RECTANGLE"/>
        /// </term>
        /// <term>
        /// Device can draw rectangles.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PC_SCANLINE"/>
        /// </term>
        /// <term>
        /// Device can draw a single scanline.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PC_STYLED"/>
        /// </term>
        /// <term>
        /// Device can draw styled borders.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PC_WIDE"/>
        /// </term>
        /// <term>
        /// Device can draw wide borders.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PC_WIDESTYLED"/>
        /// </term>
        /// <term>
        /// Device can draw borders that are wide and styled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PC_WINDPOLYGON"/>
        /// </term>
        /// <term>
        /// Device can draw winding-fill polygons.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TEXTCAPS"/>
        /// </term>
        /// <term>
        /// <para>
        /// Value that indicates the text capabilities of the device, as shown in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="TC_OP_CHARACTER"/>
        /// </term>
        /// <term>
        /// Device is capable of character output precision.
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="TC_OP_STROKE"/>
        /// </term>
        /// <term>
        /// Device is capable of stroke output precision.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_CP_STROKE"/>
        /// </term>
        /// <term>
        /// Device is capable of stroke clip precision.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_CR_90"/>
        /// </term>
        /// <term>
        /// Device is capable of 90-degree character rotation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_CR_ANY"/>
        /// </term>
        /// <term>
        /// Device is capable of any character rotation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_SF_X_YINDEP"/>
        /// </term>
        /// <term>
        /// Device can scale independently in the x- and y-directions.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_SA_DOUBLE"/>
        /// </term>
        /// <term>
        /// Device is capable of doubled character for scaling.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_SA_INTEGER"/>
        /// </term>
        /// <term>
        /// Device uses integer multiples only for character scaling.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_SA_CONTIN"/>
        /// </term>
        /// <term>
        /// Device uses any multiples for exact character scaling.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_EA_DOUBLE"/>
        /// </term>
        /// <term>
        /// Device can draw double-weight characters.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_IA_ABLE"/>
        /// </term>
        /// <term>
        /// Device can italicize.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_UA_ABLE"/>
        /// </term>
        /// <term>
        /// Device can underline.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_SO_ABLE"/>
        /// </term>
        /// <term>
        /// Device can draw strikeouts.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_RA_ABLE"/>
        /// </term>
        /// <term>
        /// Device can draw raster fonts.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_VA_ABLE"/>
        /// </term>
        /// <term>
        /// Device can draw vector fonts.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_RESERVED"/>
        /// </term>
        /// <term>
        /// Reserved; must be zero.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TC_SCROLLBLT"/>
        /// </term>
        /// <term>
        /// Device cannot scroll using a bit-block transfer.
        /// Note that this meaning may be the opposite of what you expect.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COLORMGMTCAPS"/>
        /// </term>
        /// <term>
        /// <para>
        /// Value that indicates the color management capabilities of the device.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="CM_CMYK_COLOR"/>
        /// </term>
        /// <term>
        /// Device can accept CMYK color space ICC color profile.
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="CM_DEVICE_ICM"/>
        /// </term>
        /// <term>
        /// Device can perform ICM on either the device driver or the device itself.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CM_GAMMA_RAMP"/>
        /// </term>
        /// <term>
        /// Device supports <see cref="GetDeviceGammaRamp"/> and <see cref="SetDeviceGammaRamp"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CM_NONE"/>
        /// </term>
        /// <term>
        /// Device does not support ICM.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the value of the desired item.
        /// </para>
        /// <para>
        /// When <paramref name="nIndex"/> is <see cref="BITSPIXEL"/> and the device has 15bpp or 16bpp, the return value is 16.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When <paramref name="nIndex"/> is <see cref="SHADEBLENDCAPS"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// For a printer, <see cref="GetDeviceCaps"/> returns whatever the printer reports.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// For a display device, all blending operations are available; besides <see cref="SB_NONE"/>,
        /// the only return values are <see cref="SB_CONST_ALPHA"/> and <see cref="SB_PIXEL_ALPHA"/>,
        /// which indicate whether these operations are accelerated.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// On a multiple monitor system, if <paramref name="hdc"/> is the desktop,
        /// <see cref="GetDeviceCaps"/> returns the capabilities of the primary monitor.
        /// If you want info for other monitors, you must use the multi-monitor APIs
        /// or <see cref="CreateDC"/> to get a HDC for the device context (DC) of a specific monitor.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Display1 is typically the primary monitor, but not always.
        /// </para>
        /// <para>
        /// <see cref="GetDeviceCaps"/> provides the following six indexes in place of printer escapes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Index
        /// </term>
        /// <term>
        /// Printer escape replaced
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PHYSICALWIDTH"/>
        /// </term>
        /// <term>
        /// <see cref="GETPHYSPAGESIZE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PHYSICALHEIGHT"/>
        /// </term>
        /// <term>
        /// <see cref="GETPHYSPAGESIZE"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PHYSICALOFFSETX"/>
        /// </term>
        /// <term>
        /// <see cref="GETPRINTINGOFFSET"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PHYSICALOFFSETY"/>
        /// </term>
        /// <term>
        /// <see cref="GETPHYSICALOFFSET"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SCALINGFACTORX"/>
        /// </term>
        /// <term>
        /// <see cref="GETSCALINGFACTOR"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SCALINGFACTORY"/>
        /// </term>
        /// <term>
        /// <see cref="GETSCALINGFACTOR"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// <see cref="GetDeviceCaps"/> reports info that the display driver provides.
        /// If the display driver declines to report any info, <see cref="GetDeviceCaps"/> calculates the info based on fixed calculations.
        /// If the display driver reports invalid info, <see cref="GetDeviceCaps"/> returns the invalid info.
        /// Also, if the display driver declines to report info, <see cref="GetDeviceCaps"/> might calculate incorrect info
        /// because it assumes either fixed DPI (96 DPI) or a fixed size
        /// (depending on the info that the display driver did and didn’t provide).
        /// Unfortunately, a display driver that is implemented to the Windows Display Driver Model (WDDM)
        /// (introduced in Windows Vista) causes GDI to not get the info, so <see cref="GetDeviceCaps"/> must always calculate the info.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDeviceCaps", ExactSpelling = true, SetLastError = true)]
        public static extern int GetDeviceCaps([In] HDC hdc, [In] DeviceCapIndexes nIndex);

        /// <summary>
        /// <para>
        /// The <see cref="GetGraphicsMode"/> function retrieves the current graphics mode for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getgraphicsmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the current graphics mode. It can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="GM_COMPATIBLE"/>
        /// </term>
        /// <term>
        /// The current graphics mode is the compatible graphics mode, a mode that is compatible with 16-bit Windows.
        /// In this graphics mode, an application cannot set or modify the world transformation for the specified device context.
        /// The compatible graphics mode is the default graphics mode.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GM_ADVANCED"/>
        /// </term>
        /// <term>
        /// The current graphics mode is the advanced graphics mode, a mode that allows world transformations.
        /// In this graphics mode, an application can set or modify the world transformation for the specified device context.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Otherwise, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// An application can set the graphics mode for a device context by calling the <see cref="SetGraphicsMode"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetGraphicsMode", ExactSpelling = true, SetLastError = true)]
        public static extern GraphicsModes GetGraphicsMode([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetLayout"/> function returns the layout of a device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getlayout"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns the layout flags for the current device context.
        /// </para>
        /// <para>
        /// If the function fails, it returns <see cref="GDI_ERROR"/>.
        /// For extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The layout specifies the order in which text and graphics are revealed in a window or device context.
        /// The default is left to right.
        /// The <see cref="GetLayout"/> function tells you if the default has been changed through a call to <see cref="SetLayout"/>.
        /// For more information, see "Window Layout and Mirroring" in Window Features.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLayout", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetLayout([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetMapMode"/> function retrieves the current mapping mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getmapmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the mapping mode.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The following are the various mapping modes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Mode
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="MM_ANISOTROPIC"/>
        /// </term>
        /// <term>
        /// Logical units are mapped to arbitrary units with arbitrarily scaled axes.
        /// Use the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions
        /// to specify the units, orientation, and scaling required.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_HIENGLISH"/>
        /// </term>
        /// <term>
        /// Each logical unit is mapped to 0.001 inch. Positive x is to the right; positive y is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_HIMETRIC"/>
        /// </term>
        /// <term>
        /// Each logical unit is mapped to 0.01 millimeter. Positive x is to the right; positive y is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_ISOTROPIC"/>
        /// </term>
        /// <term>
        /// Logical units are mapped to arbitrary units with equally scaled axes;
        /// that is, one unit along the x-axis is equal to one unit along the y-axis.
        /// Use the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions
        /// to specify the units and the orientation of the axes.
        /// Graphics device interface makes adjustments as necessary to ensure the x and y units remain the same size.
        /// (When the windows extent is set, the viewport will be adjusted to keep the units isotropic).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_LOENGLISH"/>
        /// </term>
        /// <term>
        /// Each logical unit is mapped to 0.01 inch. Positive x is to the right; positive y is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_LOMETRIC"/>
        /// </term>
        /// <term>
        /// Each logical unit is mapped to 0.1 millimeter. Positive x is to the right; positive y is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_TEXT"/>
        /// </term>
        /// <term>
        /// Each logical unit is mapped to one device pixel. Positive x is to the right; positive y is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_TWIPS"/>
        /// </term>
        /// <term>
        /// Each logical unit is mapped to one twentieth of a printer's point (1/1440 inch, also called a "twip").
        /// Positive x is to the right; positive y is up.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMapMode", ExactSpelling = true, SetLastError = true)]
        public static extern MappingModes GetMapMode([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetMiterLimit"/> function retrieves the miter limit for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getmiterlimit"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <param name="plimit">
        /// Pointer to a floating-point value that receives the current miter limit.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The miter limit is used when drawing geometric lines that have miter joins.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMiterLimit", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetMiterLimit([In] HDC hdc, [Out] out FLOAT plimit);

        /// <summary>
        /// <para>
        /// The <see cref="GetPixel"/> function retrieves the red, green, blue (RGB) color value of the pixel at the specified coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getpixel"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the pixel to be examined.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the pixel to be examined.
        /// </param>
        /// <returns>
        /// The return value is the <see cref="COLORREF"/> value that specifies the RGB of the pixel.
        /// If the pixel is outside of the current clipping region,
        /// the return value is <see cref="CLR_INVALID"/> (0xFFFFFFFF defined in Wingdi.h).
        /// </returns>
        /// <remarks>
        /// <para>
        /// The pixel must be within the boundaries of the current clipping region.
        /// </para>
        /// <para>
        /// Not all devices support <see cref="GetPixel"/>.
        /// An application should call <see cref="GetDeviceCaps"/> to determine whether a specified device supports this function.
        /// </para>
        /// <para>
        /// A bitmap must be selected within the device context,
        /// otherwise, <see cref="CLR_INVALID"/> is returned on all pixels.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPixel", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF GetPixel([In] HDC hdc, [In] int x, [In] int y);

        /// <summary>
        /// <para>
        /// The <see cref="GetROP2"/> function retrieves the foreground mix mode of the specified device context.
        /// The mix mode specifies how the pen or interior color and the color already on the screen are combined to yield a new color.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getrop2"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the foreground mix mode.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Following are the foreground mix modes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Mix mode
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="R2_BLACK"/>
        /// </term>
        /// <term>
        /// Pixel is always 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_COPYPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the pen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MASKNOTPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors common to both the screen and the inverse of the pen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MASKPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors common to both the pen and the screen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MASKPENNOT"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors common to both the pen and the inverse of the screen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MERGENOTPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the screen color and the inverse of the pen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MERGEPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the pen color and the screen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MERGEPENNOT"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the pen color and the inverse of the screen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOP"/>
        /// </term>
        /// <term>
        /// Pixel remains unchanged.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOT"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the screen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTCOPYPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the pen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTMASKPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the <see cref="R2_MASKPEN"/> color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTMERGEPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the <see cref="R2_MERGEPEN"/> color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTXORPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the <see cref="R2_XORPEN"/> color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_WHITE"/>
        /// </term>
        /// <term>
        /// Pixel is always 1.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_XORPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors in the pen and in the screen, but not in both.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetROP2", ExactSpelling = true, SetLastError = true)]
        public static extern RasterOps GetROP2([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetStretchBltMode"/> function retrieves the current stretching mode.
        /// The stretching mode defines how color data is added to or removed from bitmaps that are stretched or compressed
        /// when the <see cref="StretchBlt"/> function is called.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getstretchbltmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the current stretching mode.
        /// This can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="BLACKONWHITE"/>
        /// </term>
        /// <term>
        /// Performs a Boolean AND operation using the color values for the eliminated and existing pixels.
        /// If the bitmap is a monochrome bitmap, this mode preserves black pixels at the expense of white pixels.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COLORONCOLOR"/>
        /// </term>
        /// <term>
        /// Deletes the pixels.
        /// This mode deletes all eliminated lines of pixels without trying to preserve their information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HALFTONE"/>
        /// </term>
        /// <term>
        /// Maps pixels from the source rectangle into blocks of pixels in the destination rectangle.
        /// The average color over the destination block of pixels approximates the color of the source pixels.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_ANDSCANS"/>
        /// </term>
        /// <term>
        /// Same as <see cref="BLACKONWHITE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_DELETESCANS"/>
        /// </term>
        /// <term>
        /// Same as <see cref="COLORONCOLOR"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_HALFTONE"/>
        /// </term>
        /// <term>
        /// Same as <see cref="HALFTONE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_ORSCANS"/>
        /// </term>
        /// <term>
        /// Same as <see cref="WHITEONBLACK"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHITEONBLACK"/>
        /// </term>
        /// <term>
        /// Performs a Boolean OR operation using the color values for the eliminated and existing pixels.
        /// If the bitmap is a monochrome bitmap, this mode preserves white pixels at the expense of black pixels.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetStretchBltMode", ExactSpelling = true, SetLastError = true)]
        public static extern StretchBltModes GetStretchBltMode([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetViewportExtEx"/> function retrieves the x-extent and y-extent of the current viewport for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getviewportextex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpsize">
        /// A pointer to a <see cref="SIZE"/> structure that receives the x- and y-extents, in device units.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetViewportExtEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetViewportExtEx([In] HDC hdc, [Out] out SIZE lpsize);

        /// <summary>
        /// <para>
        /// The <see cref="GetViewportOrgEx"/> function retrieves the x-coordinates and y-coordinates
        /// of the viewport origin for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getviewportorgex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lppoint">
        /// A pointer to a <see cref="POINT"/> structure that receives the coordinates of the origin, in device units.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetViewportOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetViewportOrgEx([In] HDC hdc, [Out] out POINT lppoint);

        /// <summary>
        /// <para>
        /// This function retrieves the x-extent and y-extent of the window for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getwindowextex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpsize">
        /// A pointer to a <see cref="SIZE"/> structure that receives the x- and y-extents in page-space units, that is, logical units.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowExtEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetWindowExtEx([In] HDC hdc, [Out] out SIZE lpsize);

        /// <summary>
        /// <para>
        /// The <see cref="GetWindowOrgEx"/> function retrieves the x-coordinates and y-coordinates of the window origin for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getwindoworgex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lppoint">
        /// A pointer to a <see cref="POINT"/> structure that receives the coordinates, in logical units, of the window origin.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetWindowOrgEx([In] HDC hdc, [Out] out POINT lppoint);

        /// <summary>
        /// <para>
        /// The <see cref="GetWorldTransform"/> function retrieves the current world-space to page-space transformation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getworldtransform"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpxf">
        /// A pointer to an <see cref="XFORM"/> structure that receives the current world-space to page-space transformation.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The precision of the transformation may be altered
        /// if an application calls the <see cref="ModifyWorldTransform"/> function prior to calling <see cref="GetWorldTransform"/>.
        /// (This is because the internal format for storing transformation values uses a higher precision than a <see cref="FLOAT"/> value.)
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWorldTransform", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetWorldTransform([In] HDC hdc, [Out] out XFORM lpxf);

        /// <summary>
        /// <para>
        /// The <see cref="IntersectClipRect"/> function creates a new clipping region from the intersection of the current clipping region
        /// and the specified rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-intersectcliprect"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="left">
        /// The x-coordinate, in logical units, of the upper-left corner of the rectangle.
        /// </param>
        /// <param name="top">
        /// The y-coordinate, in logical units, of the upper-left corner of the rectangle.
        /// </param>
        /// <param name="right">
        /// The x-coordinate, in logical units, of the lower-right corner of the rectangle.
        /// </param>
        /// <param name="bottom">
        /// The y-coordinate, in logical units, of the lower-right corner of the rectangle.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the new clipping region's type and can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred. (The current clipping region is unaffected.)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The lower and right-most edges of the given rectangle are excluded from the clipping region.
        /// </para>
        /// <para>
        /// If a clipping region does not already exist then the system may apply a default clipping region to the specified <see cref="HDC"/>.
        /// A clipping region is then created from the intersection of that default clipping region
        /// and the rectangle specified in the function parameters.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "IntersectClipRect", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags IntersectClipRect([In] HDC hdc, [In] int left, [In] int top, [In] int right, [In] int bottom);

        /// <summary>
        /// <para>
        /// The <see cref="MaskBlt"/> function combines the color data for the source and destination bitmaps
        /// using the specified mask and raster operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-maskblt"/>
        /// </para>
        /// </summary>
        /// <param name="hdcDest">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="xDest">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="yDest">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="width">
        /// The width, in logical units, of the destination rectangle and source bitmap.
        /// </param>
        /// <param name="height">
        /// The height, in logical units, of the destination rectangle and source bitmap.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to the device context from which the bitmap is to be copied.
        /// It must be zero if the <paramref name="rop"/> parameter specifies a raster operation that does not include a source.
        /// </param>
        /// <param name="xSrc">
        /// The x-coordinate, in logical units, of the upper-left corner of the source bitmap.
        /// </param>
        /// <param name="ySrc">
        /// The y-coordinate, in logical units, of the upper-left corner of the source bitmap.
        /// </param>
        /// <param name="hbmMask">
        /// A handle to the monochrome mask bitmap combined with the color bitmap in the source device context.
        /// </param>
        /// <param name="xMask">
        /// The horizontal pixel offset for the mask bitmap specified by the hbmMask parameter.
        /// </param>
        /// <param name="yMask">
        /// The vertical pixel offset for the mask bitmap specified by the hbmMask parameter.
        /// </param>
        /// <param name="rop">
        /// <para>
        /// The foreground and background ternary raster operation codes (ROPs) that the function uses
        /// to control the combination of source and destination data.
        /// The background raster operation code is stored in the high-order byte of the high-order word of this value;
        /// the foreground raster operation code is stored in the low-order byte of the high-order word of this value;
        /// the low-order word of this value is ignored, and should be zero.
        /// The macro <see cref="MAKEROP4"/> creates such combinations of foreground and background raster operation codes.
        /// </para>
        /// <para>
        /// For a discussion of foreground and background in the context of this function, see the following Remarks section.
        /// </para>
        /// <para>
        /// For a list of common raster operation codes (ROPs), see the <see cref="BitBlt"/> function.
        /// Note that the <see cref="CAPTUREBLT"/> ROP generally cannot be used for printing device contexts.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="MaskBlt"/> function uses device-dependent bitmaps.
        /// </para>
        /// <para>
        /// A value of 1 in the mask specified by <paramref name="hbmMask"/> indicates that
        /// the foreground raster operation code specified by <paramref name="rop"/> should be applied at that location.
        /// A value of 0 in the mask indicates that the background raster operation code
        /// specified by <paramref name="rop"/> should be applied at that location.
        /// </para>
        /// <para>
        /// If the raster operations require a source, the mask rectangle must cover the source rectangle.
        /// If it does not, the function will fail.
        /// If the raster operations do not require a source, the mask rectangle must cover the destination rectangle.
        /// If it does not, the function will fail.
        /// </para>
        /// <para>
        /// If a rotation or shear transformation is in effect for the source device context
        /// when this function is called, an error occurs.
        /// However, other types of transformation are allowed.
        /// </para>
        /// <para>
        /// If the color formats of the source, pattern, and destination bitmaps differ,
        /// this function converts the pattern or source format, or both, to match the destination format.
        /// </para>
        /// <para>
        /// If the mask bitmap is not a monochrome bitmap, an error occurs.
        /// </para>
        /// <para>
        /// When an enhanced metafile is being recorded, an error occurs (and the function returns <see cref="FALSE"/>)
        /// if the source device context identifies an enhanced-metafile device context.
        /// </para>
        /// <para>
        /// Not all devices support the <see cref="MaskBlt"/> function.
        /// An application should call the <see cref="GetDeviceCaps"/> function with the nIndex parameter
        /// as <see cref="RC_BITBLT"/> to determine whether a device supports this function.
        /// </para>
        /// <para>
        /// If no mask bitmap is supplied, this function behaves exactly like <see cref="BitBlt"/>, using the foreground raster operation code.
        /// </para>
        /// <para>
        /// ICM: No color management is performed when blits occur.
        /// </para>
        /// <para>
        /// When used in a multiple monitor system, both <paramref name="hdcSrc"/> and <paramref name="hdcDest"/>
        /// must refer to the same device or the function will fail.
        /// To transfer data between DCs for different devices,
        /// convert the memory bitmap (compatible bitmap, or DDB) to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "MaskBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MaskBlt([In] HDC hdcDest, [In] int xDest, [In] int yDest, [In] int width, [In] int height, [In] HDC hdcSrc,
            [In] int xSrc, [In] int ySrc, [In] HBITMAP hbmMask, [In] int xMask, [In] int yMask, [In] RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="ModifyWorldTransform"/> function changes the world transformation for a device context using the specified mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-modifyworldtransform"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpxf">
        /// A pointer to an <see cref="XFORM"/> structure used to modify the world transformation for the given device context.
        /// </param>
        /// <param name="mode">
        /// <para>
        /// Specifies how the transformation data modifies the current world transformation. This parameter must be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MWT_IDENTITY"/>
        /// </term>
        /// <term>
        /// Resets the current world transformation by using the identity matrix.
        /// If this mode is specified, the <see cref="XFORM"/> structure pointed to by <paramref name="lpxf"/> is ignored.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MWT_LEFTMULTIPLY"/>
        /// </term>
        /// <term>
        /// Multiplies the current transformation by the data in the <see cref="XFORM"/> structure.
        /// (The data in the <see cref="XFORM"/> structure becomes the left multiplicand,
        /// and the data for the current transformation becomes the right multiplicand.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MWT_RIGHTMULTIPLY"/>
        /// </term>
        /// <term>
        /// Multiplies the current transformation by the data in the <see cref="XFORM"/> structure.
        /// (The data in the <see cref="XFORM"/> structure becomes the right multiplicand,
        /// and the data for the current transformation becomes the left multiplicand.)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="ModifyWorldTransform"/> function will fail unless graphics mode for the specified device context
        /// has been set to <see cref="GM_ADVANCED"/> by previously calling the <see cref="SetGraphicsMode"/> function.
        /// Likewise, it will not be possible to reset the graphics mode for the device context
        /// to the default <see cref="GM_COMPATIBLE"/> mode, unless world transform has first been
        /// reset to the default identity transform by calling <see cref="SetWorldTransform"/> or <see cref="ModifyWorldTransform"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ModifyWorldTransform", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ModifyWorldTransform([In] HDC hdc, [In] in XFORM lpxf, [In] DWORD mode);

        /// <summary>
        /// <para>
        /// The <see cref="OffsetClipRgn"/> function moves the clipping region of a device context by the specified offsets.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-offsetcliprgn"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The number of logical units to move left or right.
        /// </param>
        /// <param name="y">
        /// The number of logical units to move up or down.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the new region's complexity and can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred. (The current clipping region is unaffected.)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OffsetClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags OffsetClipRgn([In] HDC hdc, [In] int x, [In] int y);

        /// <summary>
        /// <para>
        /// The <see cref="OffsetViewportOrgEx"/> function modifies the viewport origin
        /// for a device context using the specified horizontal and vertical offsets.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-offsetviewportorgex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The horizontal offset, in device units.
        /// </param>
        /// <param name="y">
        /// The vertical offset, in device units.
        /// </param>
        /// <param name="lppt">
        /// A pointer to a <see cref="POINT"/> structure.
        /// The previous viewport origin, in device units, is placed in this structure.
        /// If <paramref name="lppt"/> is <see cref="NullRef{POINT}"/>, the previous viewport origin is not returned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The new origin is the sum of the current origin and the horizontal and vertical offsets.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OffsetViewportOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OffsetViewportOrgEx([In] HDC hdc, [In] int x, [In] int y, [In] in POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="OffsetWindowOrgEx"/> function modifies the window origin
        /// for a device context using the specified horizontal and vertical offsets.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-offsetwindoworgex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The horizontal offset, in logical units.
        /// </param>
        /// <param name="y">
        /// The vertical offset, in logical units.
        /// </param>
        /// <param name="lppt">
        /// A pointer to a <see cref="POINT"/> structure.
        /// The logical coordinates of the previous window origin are placed in this structure.
        /// If <paramref name="lppt"/> is <see cref="NullRef{POINT}"/>, the previous origin is not returned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OffsetWindowOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OffsetWindowOrgEx([In] HDC hdc, [In] int x, [In] int y, [Out] out POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="PatBlt"/> function paints the specified rectangle
        /// using the brush that is currently selected into the specified device context.
        /// The brush color and the surface color or colors are combined by using the specified raster operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-patblt"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the upper-left corner of the rectangle to be filled.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the upper-left corner of the rectangle to be filled.
        /// </param>
        /// <param name="w">
        /// The width, in logical units, of the rectangle.
        /// </param>
        /// <param name="h">
        /// The height, in logical units, of the rectangle.
        /// </param>
        /// <param name="rop">
        /// <para>
        /// The raster operation code. This code can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="PATCOPY"/>
        /// </term>
        /// <term>
        /// Copies the specified pattern into the destination bitmap.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PATINVERT"/>
        /// </term>
        /// <term>
        /// Combines the colors of the specified pattern with the colors of the destination rectangle by using the Boolean XOR operator.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DSTINVERT"/>
        /// </term>
        /// <term>
        /// Inverts the destination rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BLACKNESS"/>
        /// </term>
        /// <term>
        /// Fills the destination rectangle using the color associated with index 0 in the physical palette.
        /// (This color is black for the default physical palette.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHITENESS"/>
        /// </term>
        /// <term>
        /// Fills the destination rectangle using the color associated with index 1 in the physical palette.
        /// (This color is white for the default physical palette.)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The values of the <paramref name="rop"/> parameter for this function
        /// are a limited subset of the full 256 ternary raster-operation codes;
        /// in particular, an operation code that refers to a source rectangle cannot be used.
        /// </para>
        /// <para>
        /// Not all devices support the <see cref="PatBlt"/> function.
        /// For more information, see the description of the <see cref="RC_BITBLT"/> capability in the <see cref="GetDeviceCaps"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PatBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PatBlt([In] HDC hdc, [In] int x, [In] int y, [In] int w, [In] int h, [In] RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="PlgBlt"/> function performs a bit-block transfer of the bits of color data
        /// from the specified rectangle in the source device context
        /// to the specified parallelogram in the destination device context.
        /// If the given bitmask handle identifies a valid monochrome bitmap,
        /// the function uses this bitmap to mask the bits of color data from the source rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-plgblt"/>
        /// </para>
        /// </summary>
        /// <param name="hdcDest">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="lpPoint">
        /// A pointer to an array of three points in logical space that identify three corners of the destination parallelogram.
        /// The upper-left corner of the source rectangle is mapped to the first point in this array,
        /// the upper-right corner to the second point in this array, and the lower-left corner to the third point.
        /// The lower-right corner of the source rectangle is mapped to the implicit fourth point in the parallelogram.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to the source device context.
        /// </param>
        /// <param name="xSrc">
        /// The x-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="ySrc">
        /// The y-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="width">
        /// The width, in logical units, of the source rectangle.
        /// </param>
        /// <param name="height">
        /// The height, in logical units, of the source rectangle.
        /// </param>
        /// <param name="hbmMask">
        /// A handle to an optional monochrome bitmap that is used to mask the colors of the source rectangle.
        /// </param>
        /// <param name="xMask">
        /// The x-coordinate, in logical units, of the upper-left corner of the monochrome bitmap.
        /// </param>
        /// <param name="yMask">
        /// The y-coordinate, in logical units, of the upper-left corner of the monochrome bitmap.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="PlgBlt"/> function works with device-dependent bitmaps.
        /// </para>
        /// <para>
        /// The fourth vertex of the parallelogram (D) is defined
        /// by treating the first three points (A, B, and C ) as vectors and computing D = B +CA.
        /// </para>
        /// <para>
        /// If the bitmask exists, a value of one in the mask indicates that the source pixel color should be copied to the destination.
        /// A value of zero in the mask indicates that the destination pixel color is not to be changed.
        /// If the mask rectangle is smaller than the source and destination rectangles, the function replicates the mask pattern.
        /// </para>
        /// <para>
        /// Scaling, translation, and reflection transformations are allowed in the source device context;
        /// however, rotation and shear transformations are not.
        /// If the mask bitmap is not a monochrome bitmap, an error occurs.
        /// The stretching mode for the destination device context is used to determine
        /// how to stretch or compress the pixels, if that is necessary.
        /// </para>
        /// <para>
        /// When an enhanced metafile is being recorded,
        /// an error occurs if the source device context identifies an enhanced-metafile device context.
        /// </para>
        /// <para>
        /// The destination coordinates are transformed according to the destination device context;
        /// the source coordinates are transformed according to the source device context.
        /// If the source transformation has a rotation or shear, an error is returned.
        /// </para>
        /// <para>
        /// If the destination and source rectangles do not have the same color format,
        /// <see cref="PlgBlt"/> converts the source rectangle to match the destination rectangle.
        /// </para>
        /// <para>
        /// Not all devices support the <see cref="PlgBlt"/> function.
        /// For more information, see the description of the <see cref="RC_BITBLT"/> raster capability
        /// in the <see cref="GetDeviceCaps"/> function.
        /// </para>
        /// <para>
        /// If the source and destination device contexts represent incompatible devices, <see cref="PlgBlt"/> returns an error.
        /// </para>
        /// <para>
        /// When used in a multiple monitor system,
        /// both <paramref name="hdcSrc"/> and <paramref name="hdcDest"/> must refer to the same device or the function will fail.
        /// To transfer data between DCs for different devices,
        /// convert the memory bitmap to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PlgBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PlgBlt([In] HDC hdcDest, [In] POINT[] lpPoint, [In] HDC hdcSrc, [In] int xSrc, [In] int ySrc,
            [In] int width, [In] int height, [In] HBITMAP hbmMask, [In] int xMask, [In] int yMask);

        /// <summary>
        /// <para>
        /// The <see cref="PtVisible"/> function determines whether the specified point is within the clipping region of a device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-ptvisible"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the point.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the point.
        /// </param>
        /// <returns>
        /// <para>
        /// If the specified point is within the clipping region of the device context, the return value is <see cref="TRUE"/>(1).
        /// </para>
        /// <para>
        /// If the specified point is not within the clipping region of the device context, the return value is <see cref="FALSE"/>(0).
        /// </para>
        /// <para>
        /// If the <see cref="HDC"/> is not valid, the return value is (BOOL)-1.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PtVisible", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PtVisible([In] HDC hdc, [In] int x, [In] int y);

        /// <summary>
        /// <para>
        /// The <see cref="RectVisible"/> function determines
        /// whether any part of the specified rectangle lies within the clipping region of a device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-rectvisible"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lprect">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the specified rectangle.
        /// </param>
        /// <returns>
        /// <para>
        /// If the current transform does not have a rotation and the rectangle lies within the clipping region,
        /// the return value is <see cref="TRUE"/> (1).
        /// </para>
        /// <para>
        /// If the current transform does not have a rotation and the rectangle does not lie within the clipping region,
        /// the return value is <see cref="FALSE"/> (0).
        /// </para>
        /// <para>
        /// If the current transform has a rotation and the rectangle lies within the clipping region, the return value is 2.
        /// </para>
        /// <para>
        /// If the current transform has a rotation and the rectangle does not lie within the clipping region, the return value is 1.
        /// </para>
        /// <para>
        /// All other return values are considered error codes. If the any parameter is not valid, the return value is undefined.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RectVisible", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RectVisible([In] HDC hdc, [In] in RECT lprect);


        /// <summary>
        /// <para>
        /// The <see cref="ResetDC"/> function updates the specified printer or plotter device context (DC) using the specified information.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-resetdcw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC to update.
        /// </param>
        /// <param name="lpdm">
        /// A pointer to a <see cref="DEVMODE"/> structure containing information about the new DC.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the original DC.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application will typically use the <see cref="ResetDC"/> function
        /// when a window receives a <see cref="WM_DEVMODECHANGE"/> message.
        /// <see cref="ResetDC"/> can also be used to change the paper orientation or paper bins while printing a document.
        /// </para>
        /// <para>
        /// The <see cref="ResetDC"/> function cannot be used to change the driver name, device name, or the output port.
        /// When the user changes the port connection or device name,
        /// the application must delete the original DC and create a new DC with the new information.
        /// </para>
        /// <para>
        /// An application can pass an information DC to the <see cref="ResetDC"/> function.
        /// In that situation, <see cref="ResetDC"/> will always return a printer DC.
        /// </para>
        /// <para>
        /// ICM: The color profile of the DC specified by the <paramref name="hdc"/> parameter will be reset
        /// based on the information contained in the <see cref="DEVMODE"/> structure.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ResetDCW", ExactSpelling = true, SetLastError = true)]
        public static extern HDC ResetDC([In] HDC hdc, [In] in DEVMODE lpdm);

        /// <summary>
        /// <para>
        /// The <see cref="RestoreDC"/> function restores a device context (DC) to the specified state.
        /// The DC is restored by popping state information off a stack created by earlier calls to the <see cref="SaveDC"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-restoredc"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <param name="nSavedDC">
        /// The saved state to be restored.
        /// If this parameter is positive, <paramref name="nSavedDC"/> represents a specific instance of the state to be restored.
        /// If this parameter is negative, <paramref name="nSavedDC"/> represents an instance relative to the current state.
        /// For example, -1 restores the most recently saved state.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Each DC maintains a stack of saved states.
        /// The <see cref="SaveDC"/> function pushes the current state of the DC onto its stack of saved states.
        /// That state can be restored only to the same DC from which it was created.
        /// After a state is restored, the saved state is destroyed and cannot be reused.
        /// Furthermore, any states saved after the restored state was created are also destroyed and cannot be used.
        /// In other words, the <see cref="RestoreDC"/> function
        /// pops the restored state (and any subsequent states) from the state information stack.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RestoreDC", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RestoreDC([In] HDC hdc, [In] int nSavedDC);

        /// <summary>
        /// <para>
        /// The <see cref="SaveDC"/> function saves the current state of the specified device context (DC) by copying data describing selected objects
        /// and graphic modes (such as the bitmap, brush, palette, font, pen, region, drawing mode, and mapping mode) to a context stack.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-savedc"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC whose state is to be saved.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value identifies the saved state.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="SaveDC"/> function can be used any number of times to save any number of instances of the DC state.
        /// </para>
        /// <para>
        /// A saved state can be restored by using the <see cref="RestoreDC"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SaveDC", ExactSpelling = true, SetLastError = true)]
        public static extern int SaveDC([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="ScaleViewportExtEx"/> function modifies the viewport for a device context
        /// using the ratios formed by the specified multiplicands and divisors.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-scaleviewportextex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="xn">
        /// The amount by which to multiply the current horizontal extent.
        /// </param>
        /// <param name="dx">
        /// The amount by which to divide the current horizontal extent.
        /// </param>
        /// <param name="yn">
        /// The amount by which to multiply the current vertical extent.
        /// </param>
        /// <param name="yd">
        /// The amount by which to divide the current vertical extent.
        /// </param>
        /// <param name="lpsz">
        /// A pointer to a <see cref="SIZE"/> structure that receives the previous viewport extents, in device units.
        /// If <paramref name="lpsz"/> is <see langword="null"/>, this parameter is not used.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The viewport extents are modified as follows:
        /// </para>
        /// <code>
        /// xNewVE = (xOldVE * Xnum) / Xdenom 
        /// yNewVE = (yOldVE * Ynum) / Ydenom
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ScaleViewportExtEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ScaleViewportExtEx([In] HDC hdc, [In] int xn, [In] int dx, [In] int yn, [In] int yd, [In] in SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="ScaleWindowExtEx"/> function modifies the window for a device context
        /// using the ratios formed by the specified multiplicands and divisors.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-scalewindowextex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="xn">
        /// The amount by which to multiply the current horizontal extent.
        /// </param>
        /// <param name="xd">
        /// The amount by which to divide the current horizontal extent.
        /// </param>
        /// <param name="yn">
        /// The amount by which to multiply the current vertical extent.
        /// </param>
        /// <param name="yd">
        /// The amount by which to divide the current vertical extent.
        /// </param>
        /// <param name="lpsz">
        /// A pointer to a <see cref="SIZE"/> structure that receives the previous window extents, in logical units.
        /// If <paramref name="lpsz"/> is <see cref="NullRef{SIZE}"/>, this parameter is not used.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The window extents are modified as follows:
        /// </para>
        /// <code>
        /// xNewWE = (xOldWE * Xnum) / Xdenom 
        /// yNewWE = (yOldWE* Ynum) / Ydenom
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ScaleWindowExtEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ScaleWindowExtEx([In] HDC hdc, [In] int xn, [In] int xd, [In] int yn, [In] int yd, [Out] out SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SelectClipPath"/> function selects the current path as a clipping region for a device context,
        /// combining the new region with any existing clipping region using the specified mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-selectclippath"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context of the path.
        /// </param>
        /// <param name="mode">
        /// <para>
        /// The way to use the path. This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="RGN_AND"/>
        /// </term>
        /// <term>
        /// The new clipping region includes the intersection (overlapping areas) of the current clipping region and the current path.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_COPY"/>
        /// </term>
        /// <term>
        /// The new clipping region is the current path.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_DIFF"/>
        /// </term>
        /// <term>
        /// The new clipping region includes the areas of the current clipping region with those of the current path excluded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_OR"/>
        /// </term>
        /// <term>
        /// The new clipping region includes the union (combined areas) of the current clipping region and the current path.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RGN_XOR"/>
        /// </term>
        /// <term>
        /// The new clipping region includes the union of the current clipping region and the current path but without the overlapping areas.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The device context identified by the <paramref name="hdc"/> parameter must contain a closed path.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectClipPath", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SelectClipPath([In] HDC hdc, [In] CombineRgnModes mode);

        /// <summary>
        /// <para>
        /// The <see cref="SelectClipRgn"/> function selects a region as the current clipping region for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-selectcliprgn"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// A handle to the region to be selected.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the region's complexity and can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region is a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region is more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR"/>
        /// </term>
        /// <term>
        /// An error occurred. (The previous clipping region is unaffected.)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Only a copy of the selected region is used.
        /// The region itself can be selected for any number of other device contexts or it can be deleted.
        /// </para>
        /// <para>
        /// The <see cref="SelectClipRgn"/> function assumes that the coordinates for a region are specified in device units.
        /// </para>
        /// <para>
        /// To remove a device-context's clipping region, specify a <see cref="NULL"/> region handle.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags SelectClipRgn([In] HDC hdc, [In] HRGN hrgn);

        /// <summary>
        /// <para>
        /// The <see cref="SelectObject"/> function selects an object into the specified device context (DC).
        /// The new object replaces the previous object of the same type.
        /// </para> 
        /// <para>
        ///  From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-selectobject"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <param name="hgdiobj">
        /// <para>
        /// A handle to the object to be selected. The specified object must have been created by using one of the following functions.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Object
        /// </term>
        /// <term>
        /// Functions
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Bitmap
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="CreateBitmap"/>, <see cref="CreateBitmapIndirect"/>, <see cref="CreateCompatibleBitmap"/>,
        /// <see cref="CreateDIBitmap"/>, <see cref="CreateDIBSection"/>
        /// </para>
        /// <para>
        /// Bitmaps can only be selected into memory DC's.
        /// A single bitmap cannot be selected into more than one DC at the same time.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Brush
        /// </term>
        /// <term>
        /// <see cref="CreateBrushIndirect"/>, <see cref="CreateDIBPatternBrush"/>, <see cref="CreateDIBPatternBrushPt"/>,
        /// <see cref="CreateHatchBrush"/>, <see cref="CreatePatternBrush"/>, <see cref="CreateSolidBrush"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Font
        /// </term>
        /// <term>
        /// <see cref="CreateFont"/>, <see cref="CreateFontIndirect"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Pen
        /// </term>
        /// <term>
        /// <see cref="CreatePen"/>, <see cref="CreatePenIndirect"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// Region
        /// </term>
        /// <term>
        /// <see cref="CombineRgn"/>, <see cref="CreateEllipticRgn"/>, <see cref="CreateEllipticRgnIndirect"/>,
        /// <see cref="CreatePolygonRgn"/>, <see cref="CreateRectRgn"/>, <see cref="CreateRectRgnIndirect"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the selected object is not a region and the function succeeds,
        /// the return value is a handle to the object being replaced.
        /// If the selected object is a region and the function succeeds,
        /// the return value is one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="SIMPLEREGION"/>
        /// </term>
        /// <term>
        /// Region consists of a single rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COMPLEXREGION"/>
        /// </term>
        /// <term>
        /// Region consists of more than one rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NULLREGION"/>
        /// </term>
        /// <term>
        /// Region is empty.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If an error occurs and the selected object is not a region, the return value is <see cref="NULL"/>.
        /// Otherwise, it is <see cref="HGDI_ERROR"/>.
        /// </para>
        /// </returns>
        /// <para>
        /// This function returns the previously selected object of the specified type.
        /// An application should always replace a new object with the original,
        /// default object after it has finished drawing with the new object.
        /// </para>
        /// <para>
        /// An application cannot select a single bitmap into more than one DC at a time.
        /// </para>
        /// <para>
        /// ICM: If the object being selected is a brush or a pen, color management is performed.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectObject", ExactSpelling = true, SetLastError = true)]
        public static extern HGDIOBJ SelectObject([In] HDC hdc, [In] HGDIOBJ hgdiobj);

        /// <summary>
        /// <para>
        /// The <see cref="SetBkColor"/> function sets the current background color to the specified color value,
        /// or to the nearest physical color if the device cannot represent the specified color value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setbkcolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="color">
        /// The new background color.
        /// To make a <see cref="COLORREF"/> value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the previous background color as a <see cref="COLORREF"/> value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is CLR_INVALID.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function fills the gaps between styled lines drawn using a pen created by the <see cref="CreatePen"/> function;
        /// it does not fill the gaps between styled lines drawn using a pen created by the <see cref="ExtCreatePen"/> function.
        /// The <see cref="SetBkColor"/> function also sets the background colors for <see cref="TextOut"/> and <see cref="ExtTextOut"/>.
        /// </para>
        /// <para>
        /// If the background mode is <see cref="OPAQUE"/>, the background color is used to fill gaps
        /// between styled lines, gaps between hatched lines in brushes, and character cells.
        /// The background color is also used when converting bitmaps from color to monochrome and vice versa.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBkColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF SetBkColor([In] HDC hdc, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="SetBkMode"/> function sets the background mix mode of the specified device context.
        /// The background mix mode is used with text, hatched brushes, and pen styles that are not solid lines.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setbkmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="mode">
        /// <para>
        /// The background mode.
        /// This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// </term>
        /// <term>
        /// Background is filled with the current background color before the text, hatched brush, or pen is drawn.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// </term>
        /// <term>
        /// Background is unaffected.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the previous background mode.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="SetBkMode"/> function affects the line styles for lines drawn using a pen created by the <see cref="CreatePen"/> function.
        /// <see cref="SetBkMode"/> does not affect lines drawn using a pen created by the <see cref="ExtCreatePen"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBkMode", ExactSpelling = true, SetLastError = true)]
        public static extern BackgroundModes SetBkMode([In] HDC hdc, [In] BackgroundModes mode);

        /// <summary>
        /// <para>
        /// The <see cref="SetBoundsRect"/> function controls the accumulation of bounding rectangle information for the specified device context.
        /// The system can maintain a bounding rectangle for all drawing operations.
        /// An application can examine and set this rectangle.
        /// The drawing boundaries are useful for invalidating bitmap caches.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setboundsrect"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context for which to accumulate bounding rectangles.
        /// </param>
        /// <param name="lprect">
        /// A pointer to a <see cref="RECT"/> structure used to set the bounding rectangle.
        /// Rectangle dimensions are in logical coordinates.
        /// This parameter can be <see cref="NullRef{RECT}"/>.
        /// </param>
        /// <param name="flags">
        /// <para>
        /// Specifies how the new rectangle will be combined with the accumulated rectangle.
        /// This parameter can be one of more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="DCB_ACCUMULATE"/>
        /// </term>
        /// <term>
        /// Adds the rectangle specified by the <paramref name="lprect"/> parameter to the bounding rectangle (using a rectangle union operation).
        /// Using both <see cref="DCB_RESET"/> and <see cref="DCB_ACCUMULATE"/> sets the bounding rectangle
        /// to the rectangle specified by the <paramref name="lprect"/> parameter.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCB_DISABLE"/>
        /// </term>
        /// <term>
        /// Turns off boundary accumulation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCB_ENABLE"/>
        /// </term>
        /// <term>
        /// Turns on boundary accumulation, which is disabled by default.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCB_RESET"/>
        /// </term>
        /// <term>
        /// Clears the bounding rectangle.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the previous state of the bounding rectangle.
        /// This state can be a combination of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="DCB_DISABLE"/>
        /// </term>
        /// <term>
        /// Boundary accumulation is off.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCB_ENABLE"/>
        /// </term>
        /// <term>
        /// Boundary accumulation is on.
        /// <see cref="DCB_ENABLE"/> and <see cref="DCB_DISABLE"/> are mutually exclusive.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCB_RESET"/>
        /// </term>
        /// <term>
        /// Bounding rectangle is empty.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DCB_SET"/>
        /// </term>
        /// <term>
        /// Bounding rectangle is not empty.
        /// <see cref="DCB_SET"/> and <see cref="DCB_RESET"/> are mutually exclusive.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="DCB_SET"/> value is a combination of the bit values <see cref="DCB_ACCUMULATE"/> and <see cref="DCB_RESET"/>.
        /// Applications that check the <see cref="DCB_RESET"/> bit to determine whether the bounding rectangle is empty
        /// must also check the <see cref="DCB_ACCUMULATE"/> bit.
        /// The bounding rectangle is empty only if the <see cref="DCB_RESET"/> bit is 1 and the <see cref="DCB_ACCUMULATE"/> bit is 0.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBoundsRect", ExactSpelling = true, SetLastError = true)]
        public static extern BoundsRectAccumulationFlags SetBoundsRect([In] HDC hdc, [In] in RECT lprect, [In] BoundsRectAccumulationFlags flags);

        /// <summary>
        /// <para>
        /// The <see cref="SetColorAdjustment"/> function sets the color adjustment values for a device context (DC) using the specified values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setcoloradjustment"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpca">
        /// A pointer to a <see cref="COLORADJUSTMENT"/> structure containing the color adjustment values.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The color adjustment values are used to adjust the input color of the source bitmap
        /// for calls to the <see cref="StretchBlt"/> and <see cref="StretchDIBits"/> functions when <see cref="HALFTONE"/> mode is set.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetColorAdjustment", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetColorAdjustment([In] HDC hdc, [In] in COLORADJUSTMENT lpca);

        /// <summary>
        /// <para>
        /// <see cref="SetDCBrushColor"/> function sets the current device context (DC) brush color to the specified color value.
        /// If the device cannot represent the specified color value, the color is set to the nearest physical color.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdcbrushcolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <param name="color">
        /// The new brush color.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the previous DC brush color as a <see cref="COLORREF"/> value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When the stock <see cref="DC_BRUSH"/> is selected in a DC,
        /// all the subsequent drawings will be done using the DC brush color until the stock brush is deselected.
        /// The default <see cref="DC_BRUSH"/> color is <see cref="WHITE"/>.
        /// </para>
        /// <para>
        /// The function returns the previous <see cref="DC_BRUSH"/> color,
        /// even if the stock brush <see cref="DC_BRUSH"/> is not selected in the DC:
        /// however, this will not be used in drawing operations until the stock <see cref="DC_BRUSH"/> is selected in the DC.
        /// </para>
        /// <para>
        /// The <see cref="GetStockObject"/> function with an argument of <see cref="DC_BRUSH"/> or <see cref="DC_PEN"/>
        /// can be used interchangeably with the <see cref="SetDCPenColor"/> and <see cref="SetDCBrushColor"/> functions.
        /// </para>
        /// <para>
        /// ICM: Color management is performed if ICM is enabled.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDCBrushColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF SetDCBrushColor([In] HDC hdc, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// <see cref="SetDCPenColor"/> function sets the current device context (DC) pen color to the specified color value.
        /// If the device cannot represent the specified color value, the color is set to the nearest physical color.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdcpencolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <param name="color">
        /// The new pen color.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the previous DC pen color as a <see cref="COLORREF"/> value.
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The function returns the previous <see cref="DC_PEN"/> color, even if the stock pen <see cref="DC_PEN"/> is not selected in the DC;
        /// however, this will not be used in drawing operations until the stock <see cref="DC_PEN"/> is selected in the DC.
        /// </para>
        /// <para>
        /// The <see cref="GetStockObject"/> function with an argument of <see cref="DC_BRUSH"/> or <see cref="DC_PEN"/>
        /// can be used interchangeably with the <see cref="SetDCPenColor"/> and <see cref="SetDCBrushColor"/> functions.
        /// </para>
        /// <para>
        /// ICM: Color management is performed if ICM is enabled.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDCPenColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF SetDCPenColor([In] HDC hdc, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="SetDIBitsToDevice"/> function sets the pixels in the specified rectangle on the device
        /// that is associated with the destination device context using color data from a DIB, JPEG, or PNG image.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdibitstodevice"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="xDest">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="yDest">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="w">
        /// The width, in logical units, of the image.
        /// </param>
        /// <param name="h">
        /// The height, in logical units, of the image.
        /// </param>
        /// <param name="xSrc">
        /// The x-coordinate, in logical units, of the lower-left corner of the image.
        /// </param>
        /// <param name="ySrc">
        /// The y-coordinate, in logical units, of the lower-left corner of the image.
        /// </param>
        /// <param name="StartScan">
        /// The starting scan line in the image.
        /// </param>
        /// <param name="cLines">
        /// The number of DIB scan lines contained in the array pointed to by the <paramref name="lpvBits"/> parameter.
        /// </param>
        /// <param name="lpvBits">
        /// A pointer to the color data stored as an array of bytes.
        /// For more information, see the following Remarks section.
        /// </param>
        /// <param name="lpbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure that contains information about the DIB.
        /// </param>
        /// <param name="ColorUse">
        /// <para>
        /// Indicates whether the <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure
        /// contains explicit red, green, blue (RGB) values or indexes into a palette.
        /// For more information, see the following Remarks section.
        /// </para>
        /// <para>
        /// The <paramref name="ColorUse"/> parameter must be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="DIB_PAL_COLORS"/>
        /// </term>
        /// <term>
        /// The color table consists of an array of 16-bit indexes into the currently selected logical palette.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DIB_RGB_COLORS"/>
        /// </term>
        /// <term>
        /// The color table contains literal RGB values.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of scan lines set.
        /// </para>
        /// <para>
        /// If zero scan lines are set (such as when <paramref name="h"/> is 0) or the function fails, the function returns zero.
        /// </para>
        /// <para>
        /// If the driver cannot support the JPEG or PNG file image passed to <see cref="SetDIBitsToDevice"/>,
        /// the function will fail and return <see cref="GDI_ERROR"/>.
        /// If failure does occur, the application must fall back on its own JPEG or PNG support 
        /// to decompress the image into a bitmap, and then pass the bitmap to <see cref="SetDIBitsToDevice"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Optimal bitmap drawing speed is obtained when the bitmap bits are indexes into the system palette.
        /// </para>
        /// <para>
        /// Applications can retrieve the system palette colors and indexes by calling the <see cref="GetSystemPaletteEntries"/> function.
        /// After the colors and indexes are retrieved, the application can create the DIB.
        /// For more information about the system palette, see Colors.
        /// </para>
        /// <para>
        /// The scan lines must be aligned on a <see cref="DWORD"/> except for RLE-compressed bitmaps.
        /// </para>
        /// <para>
        /// The origin of a bottom-up DIB is the lower-left corner of the bitmap; the origin of a top-down DIB is the upper-left corner.
        /// </para>
        /// <para>
        /// To reduce the amount of memory required to set bits from a large DIB on a device surface,
        /// an application can band the output by repeatedly calling <see cref="SetDIBitsToDevice"/>,
        /// placing a different portion of the bitmap into the <paramref name="lpvBits"/> array each time.
        /// The values of the <paramref name="StartScan"/> and <paramref name="cLines"/> parameters
        /// identify the portion of the bitmap contained in the <paramref name="lpvBits"/> array.
        /// </para>
        /// <para>
        /// The <see cref="SetDIBitsToDevice"/> function returns an error if it is called by a process
        /// that is running in the background while a full-screen MS-DOS session runs in the foreground.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the <see cref="BITMAPINFOHEADER.biCompression"/> member of <see cref="BITMAPINFOHEADER"/>
        /// is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>, <paramref name="lpvBits"/> points to a buffer containing a JPEG or PNG image.
        /// The <see cref="BITMAPINFOHEADER.biSizeImage"/> member of specifies the size of the buffer.
        /// The <paramref name="ColorUse"/> parameter must be set to <see cref="DIB_RGB_COLORS"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To ensure proper metafile spooling while printing,
        /// applications must call the <see cref="CHECKJPEGFORMAT"/> or <see cref="CHECKPNGFORMAT"/> escape
        /// to verify that the printer recognizes the JPEG or PNG image, respectively, before calling <see cref="SetDIBitsToDevice"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// ICM: Color management is performed if color management has been enabled
        /// with a call to <see cref="SetICMMode"/> with the iEnableICM parameter set to <see cref="ICM_ON"/>.
        /// If the bitmap specified by <paramref name="lpbmi"/> has a <see cref="BITMAPV4HEADER"/> that specifies the gamma and endpoints members,
        /// or a <see cref="BITMAPV5HEADER"/> that specifies either the gamma and endpoints members or the profileData and profileSize members,
        /// then the call treats the bitmap's pixels as being expressed in the color space described by those members,
        /// rather than in the device context's source color space.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDIBitsToDevice", ExactSpelling = true, SetLastError = true)]
        public static extern int SetDIBitsToDevice([In] HDC hdc, [In] int xDest, [In] int yDest, [In] DWORD w, [In] DWORD h, [In] int xSrc, [In] int ySrc,
            [In] UINT StartScan, [In] UINT cLines, [In] IntPtr lpvBits, [In] in BITMAPINFO lpbmi, [In] UINT ColorUse);

        /// <summary>
        /// <para>
        /// The <see cref="SetGraphicsMode"/> function sets the graphics mode for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setgraphicsmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="iMode">
        /// <para>
        /// The graphics mode. This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="GM_COMPATIBLE"/>
        /// </term>
        /// <term>
        /// Sets the graphics mode that is compatible with 16-bit Windows.
        /// This is the default mode.
        /// If this value is specified, the application can only modify the world-to-device transform
        /// by calling functions that set window and viewport extents and origins,
        /// but not by using <see cref="SetWorldTransform"/> or <see cref="ModifyWorldTransform"/>;
        /// calls to those functions will fail.
        /// Examples of functions that set window and viewport extents and origins
        /// are <see cref="SetViewportExtEx"/> and <see cref="SetWindowExtEx"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GM_ADVANCED"/>
        /// </term>
        /// <term>
        /// Sets the advanced graphics mode that allows world transformations.
        /// This value must be specified if the application will set or modify the world transformation for the specified device context.
        /// In this mode all graphics, including text output,
        /// fully conform to the world-to-device transformation specified in the device context.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the old graphics mode.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// There are three areas in which graphics output differs according to the graphics mode:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// <para>
        /// Text Output: In the <see cref="GM_COMPATIBLE"/> mode, TrueType (or vector font) text output
        /// behaves much the same way as raster font text output with respect to the world-to-device transformations in the DC.
        /// The TrueType text is always written from left to right and right side up,
        /// even if the rest of the graphics will be flipped on the x or y axis.
        /// Only the height of the TrueType (or vector font) text is scaled.
        /// The only way to write text that is not horizontal in the <see cref="GM_COMPATIBLE"/> mode
        /// is to specify nonzero escapement and orientation for the logical font selected in this device context.
        /// </para>
        /// <para>
        /// In the <see cref="GM_ADVANCED"/> mode, TrueType (or vector font) text output
        /// fully conforms to the world-to-device transformation in the device context.
        /// The raster fonts only have very limited transformation capabilities (stretching by some integer factors).
        /// Graphics device interface (GDI) tries to produce the best output it can with raster fonts for nontrivial transformations.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Rectangle Exclusion: If the default <see cref="GM_COMPATIBLE"/> graphics mode is set,
        /// the system excludes bottom and rightmost edges when it draws rectangles.
        /// </para>
        /// <para>
        /// The <see cref="GM_ADVANCED"/> graphics mode is required if applications want to draw rectangles that are lower-right inclusive.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Arc Drawing: If the default <see cref="GM_COMPATIBLE"/> graphics mode is set,
        /// GDI draws arcs using the current arc direction in the device space.
        /// With this convention, arcs do not respect page-to-device transforms that require a flip along the x or y axis.
        /// </para>
        /// <para>
        /// If the <see cref="GM_ADVANCED"/> graphics mode is set,
        /// GDI always draws arcs in the counterclockwise direction in logical space.
        /// This is equivalent to the statement that, in the <see cref="GM_ADVANCED"/> graphics mode,
        /// both arc control points and arcs themselves fully respect the device context's world-to-device transformation.
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetGraphicsMode", ExactSpelling = true, SetLastError = true)]
        public static extern GraphicsModes SetGraphicsMode([In] HDC hdc, [In] GraphicsModes iMode);

        /// <summary>
        /// <para>
        /// The <see cref="SetICMMode"/> function causes Image Color Management
        /// to be enabled, disabled, or queried on a given device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-seticmmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Identifies handle to the device context.
        /// </param>
        /// <param name="mode">
        /// <para>
        /// Turns on and off image color management. This parameter can take one of the following constant values. 
        /// </para>
        /// <para>
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
        /// <see cref="ICM_ON"/>
        /// </term>
        /// <term>
        /// Turns on color management.
        /// Turns off old-style color correction of halftones.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ICM_OFF"/>
        /// </term>
        /// <term>
        /// Turns off color management.
        /// Turns on old-style color correction of halftones.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ICM_QUERY"/>
        /// </term>
        /// <term>
        /// Queries the current state of color management.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ICM_DONE_OUTSIDEDC"/>
        /// </term>
        /// <term>
        /// Turns off color management inside DC.
        /// Under Windows 2000, also turns off old-style color correction of halftones.
        /// Not supported under Windows 95.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is a nonzero value.
        /// </para>
        /// <para>
        /// If this function fails, the return value is zero.
        /// </para>
        /// <para>
        /// If <see cref="ICM_QUERY"/> is specified and the function succeeds,
        /// the nonzero value returned is <see cref="ICM_ON"/> or <see cref="ICM_OFF"/> to indicate the current mode.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the system cannot find an ICC color profile to match the state of the device, <see cref="SetICMMode"/> fails and returns zero.
        /// </para>
        /// <para>
        /// Once WCS is enabled for a device context (DC), colors passed into the DC using most Win32 API functions are color matched.
        /// The primary exceptions are <see cref="BitBlt"/> and <see cref="StretchBlt"/>.
        /// The assumption is that when performing a bit block transfer (blit) from one DC to another,
        /// the two DCs are already compatible and need no color correction.
        /// If this is not the case, color correction may be performed.
        /// Specifically, if a device independent bitmap (DIB) is used as the source for a blit,
        /// and the blit is performed into a DC that has WCS enabled, color matching will be performed.
        /// If this is not what you want, turn WCS off for the destination DC by calling <see cref="SetICMMode"/>
        /// before calling <see cref="BitBlt"/> or <see cref="StretchBlt"/>.
        /// </para>
        /// <para>
        /// If the <see cref="CreateCompatibleDC"/> function is used to create a bitmap in a DC,
        /// it is possible for the bitmap to be color matched twice, once when it is created and once when a blit is performed.
        /// The reason is that a bitmap in a DC created by the <see cref="CreateCompatibleDC"/> function
        /// acquires the current brush, pens, and palette of the source DC.
        /// However, WCS will be disabled by default for the new DC.
        /// If WCS is later enabled for the new DC by using the <see cref="SetICMMode"/> function, a color correction will be done.
        /// To prevent double color corrections through the use of the <see cref="CreateCompatibleDC"/> function,
        /// use the <see cref="SetICMMode"/> function to turn WCS off for the source DC
        /// before the <see cref="CreateCompatibleDC"/> function is called.
        /// </para>
        /// <para>
        /// When a compatible DC is created from a printer's DC (see <see cref="CreateCompatibleDC"/> ),
        /// the default is for color matching to always be performed if it is enabled for the printer's DC.
        /// The default color profile for the printer is used when a blit is performed into the printer's DC
        /// using <see cref="SetDIBitsToDevice"/> or <see cref="StretchDIBits"/>.
        /// If this is not what you want, turn WCS off for the printer's DC by calling <see cref="SetICMMode"/>
        /// before calling <see cref="SetDIBitsToDevice"/> or <see cref="StretchDIBits"/>.
        /// </para>
        /// <para>
        /// Also, when printing to a printer's DC with WCS turned on, the <see cref="SetICMMode"/> function needs to be called
        /// after every call to the <see cref="StartPage"/> function to turn back on WCS.
        /// The <see cref="StartPage"/> function calls the <see cref="RestoreDC"/> and <see cref="SaveDC"/> functions,
        /// which result in WCS being turned off for the printer's DC.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetICMMode", ExactSpelling = true, SetLastError = true)]
        public static extern int SetICMMode([In] HDC hdc, [In] ICMModes mode);


        /// <summary>
        /// <para>
        /// The <see cref="SetLayout"/> function changes the layout of a device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setlayout"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <param name="l">
        /// <para>
        /// The DC layout. This parameter can be one or more of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="LAYOUT_BITMAPORIENTATIONPRESERVED"/>
        /// </term>
        /// <term>
        /// Disables any reflection during <see cref="BitBlt"/> and <see cref="StretchBlt"/> operations.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LAYOUT_RTL"/>
        /// </term>
        /// <term>
        /// Sets the default horizontal layout to be right to left.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, it returns the previous layout of the DC.
        /// </para>
        /// <para>
        /// If the function fails, it returns <see cref="GDI_ERROR"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The layout specifies the order in which text and graphics are revealed in a window or a device context.
        /// The default is left to right.
        /// The <see cref="SetLayout"/> function changes this to be right to left, which is the standard in Arabic and Hebrew cultures.
        /// </para>
        /// <para>
        /// Once the <see cref="LAYOUT_RTL"/> flag is selected, flags normally specifying right or left are reversed.
        /// To avoid confusion, consider defining alternate words for standard flags, such as those in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Standard flag
        /// </term>
        /// <term>
        /// Suggested alternate name
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WS_EX_RIGHT"/>
        /// </term>
        /// <term>
        /// WS_EX_TRAILING
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WS_EX_RTLREADING"/>
        /// </term>
        /// <term>
        /// WS_EX_REVERSEREADING
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WS_EX_LEFTSCROLLBAR"/>
        /// </term>
        /// <term>
        /// WS_EX_LEADSCROLLBAR
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ES_LEFT"/>
        /// </term>
        /// <term>
        /// ES_LEAD
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ES_RIGHT"/>
        /// </term>
        /// <term>
        /// ES_TRAIL
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EC_LEFTMARGIN"/>
        /// </term>
        /// <term>
        /// EC_LEADMARGIN
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="EC_RIGHTMARGIN"/>
        /// </term>
        /// <term>
        /// EC_TRAILMARGIN
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// <see cref="SetLayout"/> cannot modify drawing directly into the bits of a DIB.
        /// </para>
        /// <para>
        /// For more information, see "Window Layout and Mirroring" in Window Features.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetLayout", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD SetLayout([In] HDC hdc, [In] DWORD l);

        /// <summary>
        /// <para>
        /// The <see cref="SetMapMode"/> function sets the mapping mode of the specified device context.
        /// The mapping mode defines the unit of measure used to transform page-space units into device-space units,
        /// and also defines the orientation of the device's x and y axes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setmapmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="iMode">
        /// <para>
        /// The new mapping mode. This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="MM_ANISOTROPIC"/>
        /// </term>
        /// <term>
        /// Logical units are mapped to arbitrary units with arbitrarily scaled axes.
        /// Use the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions to specify the units, orientation, and scaling.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_HIENGLISH"/>
        /// </term>
        /// <term>
        /// Each logical unit is mapped to 0.001 inch. Positive x is to the right; positive y is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_HIMETRIC"/>
        /// </term>
        /// <term>
        /// Each logical unit is mapped to 0.01 millimeter. Positive x is to the right; positive y is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_ISOTROPIC"/>
        /// </term>
        /// <term>
        /// Logical units are mapped to arbitrary units with equally scaled axes;
        /// that is, one unit along the x-axis is equal to one unit along the y-axis.
        /// Use the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions
        /// to specify the units and the orientation of the axes.
        /// Graphics device interface (GDI) makes adjustments as necessary to ensure the x and y units remain the same size
        /// (When the window extent is set, the viewport will be adjusted to keep the units isotropic).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_LOENGLISH"/>
        /// </term>
        /// <term>
        /// Each logical unit is mapped to 0.01 inch.
        /// Positive x is to the right; positive y is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_LOMETRIC"/>
        /// </term>
        /// <term>
        /// Each logical unit is mapped to 0.1 millimeter.
        /// Positive x is to the right; positive y is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_TEXT"/>
        /// </term>
        /// <term>
        /// Each logical unit is mapped to one device pixel.
        /// Positive x is to the right; positive y is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MM_TWIPS"/>
        /// </term>
        /// <term>
        /// Each logical unit is mapped to one twentieth of a printer's point (1/1440 inch, also called a twip).
        /// Positive x is to the right; positive y is up.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value identifies the previous mapping mode.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="MM_TEXT"/> mode allows applications to work in device pixels, whose size varies from device to device.
        /// </para>
        /// <para>
        /// The <see cref="MM_HIENGLISH"/>, <see cref="MM_HIMETRIC"/>, <see cref="MM_LOENGLISH"/>, <see cref="MM_LOMETRIC"/>,
        /// and <see cref="MM_TWIPS"/> modes are useful for applications drawing in physically meaningful units (such as inches or millimeters).
        /// </para>
        /// <para>
        /// The <see cref="MM_ISOTROPIC"/> mode ensures a 1:1 aspect ratio.
        /// </para>
        /// <para>
        /// The <see cref="MM_ANISOTROPIC"/> mode allows the x-coordinates and y-coordinates to be adjusted independently.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMapMode", ExactSpelling = true, SetLastError = true)]
        public static extern int SetMapMode([In] HDC hdc, [In] MappingModes iMode);

        /// <summary>
        /// <para>
        /// The <see cref="SetMiterLimit"/> function sets the limit for the length of miter joins for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setmiterlimit"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <param name="limit">
        /// Specifies the new miter limit for the device context.
        /// </param>
        /// <param name="old">
        /// Pointer to a floating-point value that receives the previous miter limit.
        /// If this parameter is <see cref="NullRef{FLOAT}"/>, the previous miter limit is not returned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The miter length is defined as the distance from the intersection of the line walls on the inside of the join
        /// to the intersection of the line walls on the outside of the join.
        /// The miter limit is the maximum allowed ratio of the miter length to the line width.
        /// </para>
        /// <para>
        /// The default miter limit is 10.0.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Setting <paramref name="limit"/> to a float value less than 1.0f will cause the function to fail.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMiterLimit", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetMiterLimit([In] HDC hdc, [In] FLOAT limit, [Out] out FLOAT old);

        /// <summary>
        /// <para>
        /// The <see cref="SetPixel"/> function sets the pixel at the specified coordinates to the specified color.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setpixel"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the point to be set.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the point to be set.
        /// </param>
        /// <param name="color">
        /// The color to be used to paint the point.
        /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the RGB value that the function sets the pixel to.
        /// This value may differ from the color specified by <paramref name="color"/>;
        /// that occurs when an exact match for the specified color cannot be found.
        /// </para>
        /// <para>
        /// If the function fails, the return value is -1.
        /// </para>
        /// <para>
        /// This can be the following value.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// One or more of the input parameters is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The function fails if the pixel coordinates lie outside of the current clipping region.
        /// </para>
        /// <para>
        /// Not all devices support the <see cref="SetPixel"/> function.
        /// For more information, see <see cref="GetDeviceCaps"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPixel", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF SetPixel([In] HDC hdc, [In] int x, [In] int y, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="SetPixelV"/> function sets the pixel at the specified coordinates to the closest approximation of the specified color.
        /// The point must be in the clipping region and the visible part of the device surface.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setpixelv"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the point to be set.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the point to be set.
        /// </param>
        /// <param name="color">
        /// The color to be used to paint the point.
        /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Not all devices support the <see cref="SetPixelV"/> function.
        /// For more information, see the description of the <see cref="RC_BITBLT"/> capability in the <see cref="GetDeviceCaps"/> function.
        /// </para>
        /// <para>
        /// <see cref="SetPixelV"/> is faster than <see cref="SetPixel"/>
        /// because it does not need to return the color value of the point actually painted.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPixelV", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetPixelV([In] HDC hdc, [In] int x, [In] int y, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="SetROP2"/> function sets the current foreground mix mode.
        /// GDI uses the foreground mix mode to combine pens and interiors of filled objects with the colors already on the screen.
        /// The foreground mix mode defines how colors from the brush or pen and the colors in the existing image are to be combined.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setrop2"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="rop2">
        /// <para>
        /// The mix mode. This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Mix mode
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="R2_BLACK"/>
        /// </term>
        /// <term>
        /// Pixel is always 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_COPYPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the pen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MASKNOTPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors common to both the screen and the inverse of the pen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MASKPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors common to both the pen and the screen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MASKPENNOT"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors common to both the pen and the inverse of the screen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MERGENOTPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the screen color and the inverse of the pen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MERGEPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the pen color and the screen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_MERGEPENNOT"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the pen color and the inverse of the screen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOP"/>
        /// </term>
        /// <term>
        /// Pixel remains unchanged.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOT"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the screen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTCOPYPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the pen color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTMASKPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the <see cref="R2_MASKPEN"/> color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTMERGEPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the <see cref="R2_MERGEPEN"/> color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_NOTXORPEN"/>
        /// </term>
        /// <term>
        /// Pixel is the inverse of the <see cref="R2_XORPEN"/> color.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_WHITE"/>
        /// </term>
        /// <term>
        /// Pixel is always 1.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="R2_XORPEN"/>
        /// </term>
        /// <term>
        /// Pixel is a combination of the colors in the pen and in the screen, but not in both.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the previous mix mode.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Mix modes define how GDI combines source and destination colors when drawing with the current pen.
        /// The mix modes are binary raster operation codes, representing all possible Boolean functions of two variables,
        /// using the binary operations AND, OR, and XOR (exclusive OR), and the unary operation NOT.
        /// The mix mode is for raster devices only; it is not available for vector devices.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetROP2", ExactSpelling = true, SetLastError = true)]
        public static extern int SetROP2([In] HDC hdc, [In] RasterOps rop2);

        /// <summary>
        /// <para>
        /// The <see cref="SetStretchBltMode"/> function sets the bitmap stretching mode in the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setstretchbltmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="mode">
        /// <para>
        /// The stretching mode. This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="BLACKONWHITE"/>
        /// </term>
        /// <term>
        /// Performs a Boolean AND operation using the color values for the eliminated and existing pixels.
        /// If the bitmap is a monochrome bitmap, this mode preserves black pixels at the expense of white pixels.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="COLORONCOLOR"/>
        /// </term>
        /// <term>
        /// Deletes the pixels.
        /// This mode deletes all eliminated lines of pixels without trying to preserve their information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HALFTONE"/>
        /// </term>
        /// <term>
        /// <para>
        /// Maps pixels from the source rectangle into blocks of pixels in the destination rectangle.
        /// The average color over the destination block of pixels approximates the color of the source pixels.
        /// </para>
        /// <para>
        /// After setting the <see cref="HALFTONE"/> stretching mode,
        /// an application must call the <see cref="SetBrushOrgEx"/> function to set the brush origin.
        /// If it fails to do so, brush misalignment occurs.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_ANDSCANS"/>
        /// </term>
        /// <term>
        /// Same as <see cref="BLACKONWHITE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_DELETESCANS"/>
        /// </term>
        /// <term>
        /// Same as <see cref="COLORONCOLOR"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_HALFTONE"/>
        /// </term>
        /// <term>
        /// Same as <see cref="HALFTONE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STRETCH_ORSCANS"/>
        /// </term>
        /// <term>
        /// Same as <see cref="WHITEONBLACK"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHITEONBLACK"/>
        /// </term>
        /// <term>
        /// Performs a Boolean OR operation using the color values for the eliminated and existing pixels.
        /// If the bitmap is a monochrome bitmap, this mode preserves white pixels at the expense of black pixels.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the previous stretching mode.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// <para>
        /// This function can return the following value.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// One or more of the input parameters is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The stretching mode defines how the system combines rows or columns of a bitmap
        /// with existing pixels on a display device when an application calls the <see cref="StretchBlt"/> function.
        /// </para>
        /// <para>
        /// The <see cref="BLACKONWHITE"/> (<see cref="STRETCH_ANDSCANS"/>) and <see cref="WHITEONBLACK"/> (<see cref="STRETCH_ORSCANS"/>) modes
        /// are typically used to preserve foreground pixels in monochrome bitmaps.
        /// The <see cref="COLORONCOLOR"/> (<see cref="STRETCH_DELETESCANS"/>) mode is typically used to preserve color in color bitmaps.
        /// </para>
        /// <para>
        /// The <see cref="HALFTONE"/> mode is slower and requires more processing of the source image than the other three modes;
        /// but produces higher quality images.
        /// Also note that <see cref="SetBrushOrgEx"/> must be called after setting the <see cref="HALFTONE"/> mode to avoid brush misalignment.
        /// </para>
        /// <para>
        /// Additional stretching modes might also be available depending on the capabilities of the device driver.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetStretchBltMode", ExactSpelling = true, SetLastError = true)]
        public static extern int SetStretchBltMode([In] HDC hdc, [In] StretchBltModes mode);

        /// <summary>
        /// <para>
        /// The <see cref="SetViewportExtEx"/> function sets the horizontal and vertical extents of the viewport for a device context
        /// by using the specified values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setviewportextex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The horizontal extent, in device units, of the viewport.
        /// </param>
        /// <param name="y">
        /// The vertical extent, in device units, of the viewport.
        /// </param>
        /// <param name="lpsz">
        /// A pointer to a <see cref="SIZE"/> structure that receives the previous viewport extents, in device units.
        /// If <paramref name="lpsz"/> is <see cref="NullRef{SIZE}"/>, this parameter is not used.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The viewport refers to the device coordinate system of the device space.
        /// The extent is the maximum value of an axis.
        /// This function sets the maximum values for the horizontal and vertical axes of the viewport in device coordinates (or pixels).
        /// When mapping between page space and device space, <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/>
        /// determine the scaling factor between the window and the viewport.
        /// For more information, see Transformation of Coordinate Spaces.
        /// </para>
        /// <para>
        /// When the following mapping modes are set, calls to the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions are ignored.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MM_HIENGLISH"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MM_HIMETRIC"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MM_LOENGLISH"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MM_LOMETRIC"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MM_TEXT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MM_TWIPS"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When <see cref="MM_ISOTROPIC"/> mode is set, an application must call the <see cref="SetWindowExtEx"/> function
        /// before it calls <see cref="SetViewportExtEx"/>.
        /// Note that for the <see cref="MM_ISOTROPIC"/> mode certain portions of a nonsquare screen may not be available for display
        /// because the logical units on both axes represent equal physical distances.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetViewportExtEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetViewportExtEx([In] HDC hdc, [In] int x, [In] int y, [Out] out SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SetViewportOrgEx"/> function specifies which device point maps to the window origin (0,0).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setviewportorgex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in device units, of the new viewport origin.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in device units, of the new viewport origin.
        /// </param>
        /// <param name="lppt">
        /// A pointer to a <see cref="POINT"/> structure that receives the previous viewport origin, in device coordinates.
        /// If <paramref name="lppt"/> is <see langword="null"/>, this parameter is not used.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function (along with <see cref="SetViewportExtEx"/> and <see cref="SetWindowExtEx"/>) helps
        /// define the mapping from the logical coordinate space (also known as a window) to the device coordinate space (the viewport).
        /// <see cref="SetViewportOrgEx"/> specifies which device point maps to the logical point (0,0).
        /// It has the effect of shifting the axes so that the logical point (0,0) no longer refers to the upper-left corner.
        /// </para>
        /// <code>
        /// //map the logical point (0,0) to the device point (xViewOrg, yViewOrg)
        /// SetViewportOrgEx(hdc, xViewOrg, yViewOrg, NULL)
        /// </code>
        /// <para>
        /// This is related to the <see cref="SetWindowOrgEx"/> function.
        /// Generally, you will use one function or the other, but not both.
        /// Regardless of your use of <see cref="SetWindowOrgEx"/> and <see cref="SetViewportOrgEx"/>,
        /// the device point (0,0) is always the upper-left corner.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetViewportOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetViewportOrgEx([In] HDC hdc, [In] int x, [In] int y, [Out] out POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="SetWindowExtEx"/> function sets the horizontal and vertical extents of the window for a device context by using the specified values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setwindowextex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The window's horizontal extent in logical units.
        /// </param>
        /// <param name="y">
        /// The window's vertical extent in logical units.
        /// </param>
        /// <param name="lpsz">
        /// A pointer to a <see cref="SIZE"/> structure that receives the previous window extents, in logical units.
        /// If <paramref name="lpsz"/> is <see cref="NullRef{SIZE}"/>, this parameter is not used.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The window refers to the logical coordinate system of the page space.
        /// The extent is the maximum value of an axis.
        /// This function sets the maximum values for the horizontal and vertical axes of the window (in logical coordinates).
        /// When mapping between page space and device space, <see cref="SetViewportExtEx"/> and <see cref="SetWindowExtEx"/>
        /// determine the scaling factor between the window and the viewport.
        /// For more information, see Transformation of Coordinate Spaces.
        /// </para>
        /// <para>
        /// When the following mapping modes are set, calls to the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions are ignored:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MM_HIENGLISH"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MM_HIMETRIC"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MM_LOENGLISH"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MM_LOMETRIC"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MM_TEXT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MM_TWIPS"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When <see cref="MM_ISOTROPIC"/> mode is set, an application must call the <see cref="SetWindowExtEx"/> function
        /// before calling <see cref="SetViewportExtEx"/>.
        /// Note that for the MM_ISOTROPIC mode, certain portions of a nonsquare screen may not be available for display
        /// because the logical units on both axes represent equal physical distances.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowExtEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowExtEx([In] HDC hdc, [In] int x, [In] int y, [Out] out SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SetWindowOrgEx"/> function specifies which window point maps to the viewport origin (0,0).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setwindoworgex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the new window origin.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the new window origin.
        /// </param>
        /// <param name="lppt">
        /// A pointer to a <see cref="POINT"/> structure that receives the previous origin of the window, in logical units.
        /// If <paramref name="lppt"/> is <see cref="NullRef{POINT}"/>, this parameter is not used.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This helps define the mapping from the logical coordinate space (also known as a window) to the device coordinate space (the viewport).
        /// <see cref="SetWindowOrgEx"/> specifies which logical point maps to the device point (0,0).
        /// It has the effect of shifting the axes so that the logical point (0,0) no longer refers to the upper-left corner.
        /// </para>
        /// <code>
        /// //map the logical point (xWinOrg, yWinOrg) to the device point (0,0) 
        /// SetWindowOrgEx (hdc, xWinOrg, yWinOrg, NULL)
        /// </code>
        /// <para>
        /// This is related to the <see cref="SetViewportOrgEx"/> function.
        /// Generally, you will use one function or the other, but not both.
        /// Regardless of your use of <see cref="SetWindowOrgEx"/> and <see cref="SetViewportOrgEx"/>,
        /// the device point (0,0) is always the upper-left corner.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowOrgEx([In] HDC hdc, [In] int x, [In] int y, [Out] out POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="SetWorldTransform"/> function sets a two-dimensional linear transformation
        /// between world space and page space for the specified device context.
        /// This transformation can be used to scale, rotate, shear, or translate graphics output.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setworldtransform"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpxf">
        /// A pointer to an <see cref="XFORM"/> structure that contains the transformation data.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Below is the transformation matrix (note that the digits in the element notation are 1-based column number
        /// followed by 1-based row number, rather than the reverse).
        /// </para>
        /// <code>
        /// | eM11 eM21 eDx |
        /// | eM12 eM22 eDy |
        /// | 0    0    1   |
        /// </code>
        /// <para>
        /// So for any coordinates (x, y) in world space, the transformed coordinates in page space (x', y') can be determined in the way shown below.
        /// </para>
        /// <code>
        /// | x' |   | eM11 eM21 eDx |   | x |   
        /// | y' | = | eM12 eM22 eDy | . | y |
        /// | 1  |   | 0    0    1   |   | 1 |
        /// 
        /// x' = x * eM11 + y * eM21 + eDx
        /// y' = x * eM12 + y * eM22 + eDy
        /// </code>
        /// <para>
        /// This function uses logical units.
        /// </para>
        /// <para>
        /// The world transformation is usually used to scale or rotate logical images in a device-independent way.
        /// </para>
        /// <para>
        /// The default world transformation is the identity matrix with zero offset.
        /// </para>
        /// <para>
        /// The <see cref="SetWorldTransform"/> function will fail unless the graphics mode for the given device context
        /// has been set to <see cref="GM_ADVANCED"/> by previously calling the <see cref="SetGraphicsMode"/> function.
        /// Likewise, it will not be possible to reset the graphics mode for the device context to the default <see cref="GM_COMPATIBLE"/> mode,
        /// unless the world transformation has first been reset to the default identity transformation
        /// by calling <see cref="SetWorldTransform"/> or <see cref="ModifyWorldTransform"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWorldTransform", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWorldTransform([In] HDC hdc, [In] in XFORM lpxf);

        /// <summary>
        /// <para>
        /// The <see cref="StretchBlt"/> function copies a bitmap from a source rectangle into a destination rectangle,
        /// stretching or compressing the bitmap to fit the dimensions of the destination rectangle, if necessary.
        /// The system stretches or compresses the bitmap according to the stretching mode currently set in the destination device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-stretchblt"/>
        /// </para>
        /// </summary>
        /// <param name="hdcDest">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="xDest">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="yDest">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="wDest">
        /// The width, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="hDest">
        /// The height, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to the source device context.
        /// </param>
        /// <param name="xSrc">
        /// The x-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="ySrc">
        /// The y-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="wSrc">
        /// The width, in logical units, of the source rectangle.
        /// </param>
        /// <param name="hSrc">
        /// The height, in logical units, of the source rectangle.
        /// </param>
        /// <param name="rop">
        /// <para>
        /// The raster operation to be performed.
        /// Raster operation codes define how the system combines colors in output operations
        /// that involve a brush, a source bitmap, and a destination bitmap.
        /// </para>
        /// <para>
        /// See <see cref="BitBlt"/> for a list of common raster operation codes (ROPs).
        /// Note that the <see cref="CAPTUREBLT"/> ROP generally cannot be used for printing device contexts.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="StretchBlt"/> stretches or compresses the source bitmap in memory
        /// and then copies the result to the destination rectangle.
        /// This bitmap can be either a compatible bitmap (DDB) or the output from <see cref="CreateDIBSection"/>.
        /// The color data for pattern or destination pixels is merged after the stretching or compression occurs.
        /// </para>
        /// <para>
        /// When an enhanced metafile is being recorded, an error occurs (and the function returns <see cref="FALSE"/>)
        /// if the source device context identifies an enhanced-metafile device context.
        /// </para>
        /// <para>
        /// If the specified raster operation requires a brush,
        /// the system uses the brush currently selected into the destination device context.
        /// </para>
        /// <para>
        /// The destination coordinates are transformed by using the transformation currently specified for the destination device context;
        /// the source coordinates are transformed by using the transformation currently specified for the source device context.
        /// </para>
        /// <para>
        /// If the source transformation has a rotation or shear, an error occurs.
        /// </para>
        /// <para>
        /// If destination, source, and pattern bitmaps do not have the same color format,
        /// <see cref="StretchBlt"/> converts the source and pattern bitmaps to match the destination bitmap.
        /// </para>
        /// <para>
        /// If <see cref="StretchBlt"/> must convert a monochrome bitmap to a color bitmap,
        /// it sets white bits (1) to the background color and black bits (0) to the foreground color.
        /// To convert a color bitmap to a monochrome bitmap,
        /// it sets pixels that match the background color to white (1) and sets all other pixels to black (0).
        /// The foreground and background colors of the device context with color are used.
        /// </para>
        /// <para>
        /// <see cref="StretchBlt"/> creates a mirror image of a bitmap
        /// if the signs of the <paramref name="wSrc"/> and <paramref name="wDest"/> parameters
        /// or if the <paramref name="hSrc"/> and <paramref name="hDest"/> parameters differ.
        /// If <paramref name="wSrc"/> and <paramref name="wDest"/> have different signs,
        /// the function creates a mirror image of the bitmap along the x-axis.
        /// If <paramref name="hSrc"/> and <paramref name="hDest"/> have different signs,
        /// the function creates a mirror image of the bitmap along the y-axis.
        /// </para>
        /// <para>
        /// Not all devices support the <see cref="StretchBlt"/> function.
        /// For more information, see the <see cref="GetDeviceCaps"/>.
        /// </para>
        /// <para>
        /// ICM: No color management is performed when a blit operation occurs.
        /// </para>
        /// <para>
        /// When used in a multiple monitor system,
        /// both <paramref name="hdcSrc"/> and <paramref name="hdcDest"/> must refer to the same device or the function will fail.
        /// To transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling <see cref="GetDIBits"/>.
        /// To display the DIB to the second device, call <see cref="SetDIBits"/> or <see cref="StretchDIBits"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StretchBlt", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL StretchBlt([In] HDC hdcDest, [In] int xDest, [In] int yDest, [In] int wDest, [In] int hDest, [In] HDC hdcSrc,
            [In] int xSrc, [In] int ySrc, [In] int wSrc, [In] int hSrc, [In] RasterCodes rop);

        /// <summary>
        /// <para>
        /// The <see cref="StretchDIBits"/> function copies the color data
        /// for a rectangle of pixels in a DIB, JPEG, or PNG image to the specified destination rectangle.
        /// If the destination rectangle is larger than the source rectangle,
        /// this function stretches the rows and columns of color data to fit the destination rectangle.
        /// If the destination rectangle is smaller than the source rectangle,
        /// this function compresses the rows and columns by using the specified raster operation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-stretchdibits"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="xDest">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="yDest">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="DestWidth">
        /// The width, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="DestHeight">
        /// The height, in logical units, of the destination rectangle.
        /// </param>
        /// <param name="xSrc">
        /// The x-coordinate, in pixels, of the source rectangle in the image.
        /// </param>
        /// <param name="ySrc">
        /// The y-coordinate, in pixels, of the source rectangle in the image.
        /// </param>
        /// <param name="SrcWidth">
        /// The width, in pixels, of the source rectangle in the image.
        /// </param>
        /// <param name="SrcHeight">
        /// The height, in pixels, of the source rectangle in the image.
        /// </param>
        /// <param name="lpBits">
        /// A pointer to the image bits, which are stored as an array of bytes.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="lpbmi">
        /// A pointer to a <see cref="BITMAPINFO"/> structure that contains information about the DIB.
        /// </param>
        /// <param name="iUsage">
        /// <para>
        /// Specifies whether the <see cref="BITMAPINFO.bmiColors"/> member of the <see cref="BITMAPINFO"/> structure was provided and,
        /// if so, whether <see cref="BITMAPINFO.bmiColors"/> contains explicit red, green, blue (RGB) values or indexes.
        /// The <paramref name="iUsage"/> parameter must be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="DIB_PAL_COLORS"/>
        /// </term>
        /// <term>
        /// The array contains 16-bit indexes into the logical palette of the source device context.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DIB_RGB_COLORS"/>
        /// </term>
        /// <term>
        /// The color table contains literal RGB values.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// For more information, see the Remarks section.
        /// </para>
        /// </param>
        /// <param name="rop">
        /// A raster-operation code that specifies how the source pixels, the destination device context's current brush,
        /// and the destination pixels are to be combined to form the new image.
        /// For a list of some common raster operation codes, see <see cref="BitBlt"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the number of scan lines copied.
        /// Note that this value can be negative for mirrored content.
        /// </para>
        /// <para>
        /// If the function fails, or no scan lines are copied, the return value is 0.
        /// </para>
        /// <para>
        /// If the driver cannot support the JPEG or PNG file image passed to <see cref="StretchDIBits"/>,
        /// the function will fail and return <see cref="GDI_ERROR"/>.
        /// If failure does occur, the application must fall back on its own JPEG or PNG support to decompress the image into a bitmap,
        /// and then pass the bitmap to <see cref="StretchDIBits"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The origin of a bottom-up DIB is the lower-left corner; the origin of a top-down DIB is the upper-left corner.
        /// </para>
        /// <para>
        /// <see cref="StretchDIBits"/> creates a mirror image of a bitmap
        /// if the signs of the <paramref name="SrcWidth"/> and <paramref name="DestWidth"/> parameters,
        /// or if the <paramref name="SrcHeight"/> and <paramref name="DestHeight"/> parameters differ.
        /// If <paramref name="SrcWidth"/> and <paramref name="DestWidth"/> have different signs,
        /// the function creates a mirror image of the bitmap along the x-axis.
        /// If <paramref name="SrcHeight"/> and <paramref name="DestHeight"/> have different signs,
        /// the function creates a mirror image of the bitmap along the y-axis.
        /// </para>
        /// <para>
        /// <see cref="StretchDIBits"/> creates a top-down image if the sign of the <see cref="BITMAPINFOHEADER.biHeight"/> member
        /// of the <see cref="BITMAPINFOHEADER"/> structure for the DIB is negative.
        /// For a code example, see Sizing a JPEG or PNG Image.
        /// </para>
        /// <para>
        /// This function allows a JPEG or PNG image to be passed as the source image. How each parameter is used remains the same, except:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the <see cref="BITMAPINFOHEADER.biCompression"/> member
        /// of <see cref="BITMAPINFOHEADER"/> is <see cref="BI_JPEG"/> or <see cref="BI_PNG"/>,
        /// <paramref name="lpBits"/> points to a buffer containing a JPEG or PNG image, respectively.
        /// The <see cref="BITMAPINFOHEADER.biSizeImage"/> member of the <see cref="BITMAPINFOHEADER"/> structure specifies the size of the buffer.
        /// The <paramref name="iUsage"/> parameter must be set to <see cref="DIB_RGB_COLORS"/>.
        /// The <paramref name="rop"/> parameter must be set to <see cref="SRCCOPY"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// To ensure proper metafile spooling while printing,
        /// applications must call the <see cref="CHECKJPEGFORMAT"/> or <see cref="CHECKPNGFORMAT"/> escape
        /// to verify that the printer recognizes the JPEG or PNG image, respectively, before calling <see cref="StretchDIBits"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// ICM: Color management is performed if color management has been enabled
        /// with a call to <see cref="SetICMMode"/> with the iEnableICM parameter set to <see cref="ICM_ON"/>.
        /// If the bitmap specified by <paramref name="lpbmi"/> has a <see cref="BITMAPV4HEADER"/> that specifies the gamma and endpoints members,
        /// or a <see cref="BITMAPV5HEADER"/> that specifies either the gamma and endpoints members or the profileData and profileSize members,
        /// then the call treats the bitmap's pixels as being expressed in the color space described by those members,
        /// rather than in the device context's source color space.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StretchDIBits", ExactSpelling = true, SetLastError = true)]
        public static extern int StretchDIBits([In] HDC hdc, [In] int xDest, [In] int yDest, [In] int DestWidth, [In] int DestHeight, [In] int xSrc,
            [In] int ySrc, [In] int SrcWidth, [In] int SrcHeight, [In] IntPtr lpBits, [In] in BITMAPINFO lpbmi,
            [In] UINT iUsage, [In] RasterCodes rop);
    }
}
