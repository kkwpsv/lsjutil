using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.COLORREF;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.BoundsAccumulationFlags;
using static Lsj.Util.Win32.Enums.ClassStyles;
using static Lsj.Util.Win32.Enums.GDIEscapes;
using static Lsj.Util.Win32.Enums.GraphicsModes;
using static Lsj.Util.Win32.Enums.ICMModes;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.Enums.ObjTypes;
using static Lsj.Util.Win32.Enums.RasterCodes;
using static Lsj.Util.Win32.Enums.RegionFlags;
using static Lsj.Util.Win32.Enums.StockObjectIndexes;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Gdi32.dll
    /// </summary>
    public static partial class Gdi32
    {
        /// <summary>
        /// HGDI_ERROR
        /// </summary>
        public static readonly IntPtr HGDI_ERROR = new IntPtr(-1);

        /// <summary>
        /// CCHDEVICENAME
        /// </summary>
        public const int CCHDEVICENAME = 32;

        /// <summary>
        /// CCHFORMNAME
        /// </summary>
        public const int CCHFORMNAME = 32;

        /// <summary>
        /// LF_FACESIZE
        /// </summary>
        public const int LF_FACESIZE = 32;

        /// <summary>
        /// LF_FULLFACESIZE
        /// </summary>
        public const int LF_FULLFACESIZE = 64;

        /// <summary>
        /// MM_MAX_NUMAXES
        /// </summary>
        public const int MM_MAX_NUMAXES = 16;

        /// <summary>
        /// MM_MAX_AXES_NAMELEN
        /// </summary>
        public const int MM_MAX_AXES_NAMELEN = 16;

        /// <summary>
        /// GDI_ERROR
        /// </summary>
        public const uint GDI_ERROR = 0xFFFFFFFF;


        /// <summary>
        /// <para>
        /// The EnumObjectsProc function is an application-defined callback function used with the <see cref="EnumObjects"/> function.
        /// It is used to process the object data. The <see cref="GOBJENUMPROC"/> type defines a pointer to this callback function.
        /// EnumObjectsProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nc-wingdi-gobjenumproc"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// </param>
        /// <param name="unnamedParam2">
        /// </param>
        /// <returns>
        /// To continue enumeration, the callback function must return a nonzero value. This value is user-defined.
        /// To stop enumeration, the callback function must return zero.
        /// </returns>
        /// <remarks>
        /// An application must register this function by passing its address to the <see cref="EnumObjects"/> function.
        /// </remarks>
        public delegate int Gobjenumproc([In] LPVOID unnamedParam1, [In] LPARAM unnamedParam2);


        /// <summary>
        /// <para>
        /// The <see cref="CancelDC"/> function cancels any pending operation on the specified device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-canceldc"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CancelDC"/> function is used by multithreaded applications to cancel lengthy drawing operations.
        /// If thread A initiates a lengthy drawing operation, thread B may cancel that operation by calling this function.
        /// If an operation is canceled, the affected thread returns an error and the result of its drawing operation is undefined.
        /// The results are also undefined if no drawing operation was in progress when the function was called.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CancelDC", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CancelDC([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="CreateCompatibleDC"/> function creates a memory device context (DC) compatible with the specified device.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createcompatibledc"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to an existing DC. If this handle is NULL, the function creates a memory DC compatible with the application's current screen.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a memory DC.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleDC", ExactSpelling = true, SetLastError = true)]
        public static extern HDC CreateCompatibleDC([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDC"/> function creates a device context (DC) for a device using the specified name.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createdcw"/>
        /// </para>
        /// </summary>
        /// <param name="pwszDriver">
        /// A pointer to a null-terminated character string that specifies either DISPLAY or the name of a specific display device.
        /// For printing, we recommend that you pass <see langword="null"/> to <paramref name="pwszDriver"/>
        /// because GDI ignores <paramref name="pwszDriver"/> for printer devices.
        /// </param>
        /// <param name="pwszDevice">
        /// A pointer to a null-terminated character string that specifies the name of the specific output device being used,
        /// as shown by the Print Manager (for example, Epson FX-80).
        /// It is not the printer model name. The <paramref name="pwszDevice"/> parameter must be used.
        /// To obtain valid names for displays, call <see cref="EnumDisplayDevices"/>.
        /// If <paramref name="pwszDriver"/> is DISPLAY or the device name of a specific display device,
        /// then <paramref name="pwszDevice"/> must be <see langword="null"/> or that same device name.
        /// If <paramref name="pwszDevice"/> is NULL, then a DC is created for the primary display device.
        /// If there are multiple monitors on the system, calling <code>CreateDC(TEXT("DISPLAY"),NULL,NULL,NULL)</code>
        /// will create a DC covering all the monitors.
        /// </param>
        /// <param name="pszPort">
        /// This parameter is ignored and should be set to <see langword="null"/>.
        /// It is provided only for compatibility with 16-bit Windows.
        /// </param>
        /// <param name="pdm">
        /// A pointer to a <see cref="DEVMODE"/> structure containing device-specific initialization data for the device driver.
        /// The <see cref="DocumentProperties"/> function retrieves this structure filled in for a specified device.
        /// The <paramref name="pdm"/> parameter must be <see langword="null"/> if the device driver is to use the default initialization
        /// (if any) specified by the user.
        /// If <paramref name="pwszDriver"/> is DISPLAY, <paramref name="pdm"/> must be <see langword="null"/>;
        /// GDI then uses the display device's current <see cref="DEVMODE"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a DC for the specified device.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// Note that the handle to the DC can only be used by a single thread at any one time.
        /// For parameters <paramref name="pwszDriver"/> and <paramref name="pwszDevice"/>,
        /// call <see cref="EnumDisplayDevices"/> to obtain valid names for displays.
        /// When you no longer need the DC, call the <see cref="DeleteDC"/> function.
        /// If <paramref name="pwszDriver"/> or <paramref name="pwszDevice"/> is DISPLAY,
        /// the thread that calls <see cref="CreateDC"/> owns the HDC that is created.
        /// When this thread is destroyed, the <see cref="HDC"/> is no longer valid.
        /// Thus, if you create the HDC and pass it to another thread, then exit the first thread, the second thread will not be able to use the HDC.
        /// When you call <see cref="CreateDC"/> to create the <see cref="HDC"/> for a display device, you must pass to <paramref name="pdm"/>
        /// either <see cref="NULL"/> or a pointer to <see cref="DEVMODE"/> that
        /// matches the current <see cref="DEVMODE"/> of the display device that <paramref name="pwszDevice"/> specifies.
        /// We recommend to pass <see langword="null"/> and not to try to exactly match the <see cref="DEVMODE"/> for the current display device.
        /// When you call <see cref="CreateDC"/> to create the <see cref="HDC"/> for a printer device, the printer driver validates the <see cref="DEVMODE"/>.
        /// If the printer driver determines that the <see cref="DEVMODE"/> is invalid
        /// (that is, printer driver can’t convert or consume the <see cref="DEVMODE"/>),
        /// the printer driver provides a default <see cref="DEVMODE"/> to create the <see cref="HDC"/> for the printer device.
        /// ICM: To enable ICM, set the <see cref="DEVMODE.dmICMMethod"/> member of the <see cref="DEVMODE"/> structure
        /// (pointed to by the <paramref name="pdm"/> parameter) to the appropriate value.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDCW", ExactSpelling = true, SetLastError = true)]
        public static extern HDC CreateDC([MarshalAs(UnmanagedType.LPWStr)][In] string pwszDriver, [MarshalAs(UnmanagedType.LPWStr)][In] string pwszDevice,
            [MarshalAs(UnmanagedType.LPWStr)][In] string pszPort, [In] in DEVMODE pdm);

        /// <summary>
        /// <para>
        /// The <see cref="CreateIC"/> function creates an information context for the specified device.
        /// The information context provides a fast way to get information about the device without creating a device context (DC).
        /// However, GDI drawing functions cannot accept a handle to an information context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createicw"/>
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
        /// This parameter is ignored and should be set to <see langword="null"/>.
        /// It is provided only for compatibility with 16-bit Windows.
        /// </param>
        /// <param name="pdm">
        /// A pointer to a <see cref="DEVMODE"/> structure containing device-specific initialization data for the device driver.
        /// The <see cref="DocumentProperties"/> function retrieves this structure filled in for a specified device.
        /// The <paramref name="pdm"/> parameter must be <see langword="null"/> if the device driver is to use the default initialization
        /// (if any) specified by the user.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to an information context.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the information DC, call the <see cref="DeleteDC"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateICW", ExactSpelling = true, SetLastError = true)]
        public static extern HDC CreateIC([MarshalAs(UnmanagedType.LPWStr)][In] string pszDriver, [MarshalAs(UnmanagedType.LPWStr)][In] string pszDevice,
            [MarshalAs(UnmanagedType.LPWStr)][In] string pszPort, [In] in DEVMODE pdm);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteDC"/> function deletes the specified device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-deletedc"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteDC", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteDC([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteObject"/> function deletes a logical pen, brush, font, bitmap, region, or palette, 
        /// freeing all system resources associated with the object.
        /// After the object is deleted, the specified handle is no longer valid.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-deleteobject"/>
        /// </para>
        /// </summary>
        /// <param name="hObject">A handle to a logical pen, brush, font, bitmap, region, or palette.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the specified handle is not valid or is currently selected into a DC, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteObject", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteObject([In] HGDIOBJ hObject);

        /// <summary>
        /// <para>
        /// The <see cref="DPtoLP"/> function converts device coordinates into logical coordinates.
        /// The conversion depends on the mapping mode of the device context, the settings of the origins and extents for the window and viewport,
        /// and the world transformation.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-dptolp"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lppt">
        /// A pointer to an array of <see cref="POINT"/> structures.
        /// The x- and y-coordinates contained in each <see cref="POINT"/> structure will be transformed.
        /// </param>
        /// <param name="c">
        /// The number of points in the array.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="DPtoLP"/> function fails if the device coordinates exceed 27 bits, or if the converted logical coordinates exceed 32 bits.
        /// In the case of such an overflow, the results for all the points are undefined.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DPtoLP", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DPtoLP([In] HDC hdc, [MarshalAs(UnmanagedType.LPArray)][In][Out] POINT[] lppt, [In] int c);

        /// <summary>
        /// <para>
        /// The <see cref="EnumObjects"/> function enumerates the pens or brushes available for the specified device context (DC).
        /// This function calls the application-defined callback function once for each available object, supplying data describing that object.
        /// <see cref="EnumObjects"/> continues calling the callback function until the callback function returns zero
        /// or until all of the objects have been enumerated.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-enumobjects"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <param name="nType">
        /// The object type.
        /// This parameter can be <see cref="OBJ_BRUSH"/> or <see cref="OBJ_PEN"/>.
        /// </param>
        /// <param name="lpFunc">
        /// A pointer to the application-defined callback function.
        /// For more information about the callback function, see the <see cref="GOBJENUMPROC"/> function.
        /// </param>
        /// <param name="lParam">
        /// A pointer to the application-defined data.
        /// The data is passed to the callback function along with the object information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the last value returned by the callback function.
        /// Its meaning is user-defined.
        /// If the objects cannot be enumerated (for example, there are too many objects), the function returns zero without calling the callback function.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumObjects", ExactSpelling = true, SetLastError = true)]
        public static extern int EnumObjects([In] HDC hdc, [In] ObjTypes nType, [In] GOBJENUMPROC lpFunc, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// The <see cref="Escape"/> function enables an application to access the system-defined device capabilities that are not available through GDI.
        /// Escape calls made by an application are translated and sent to the driver.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-escape"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="iEscape">
        /// The escape function to be performed.
        /// This parameter must be one of the predefined escape values listed in Remarks.
        /// Use the <see cref="ExtEscape"/> function if your application defines a private escape value.
        /// </param>
        /// <param name="cjIn">
        /// The number of bytes of data pointed to by the <paramref name="pvIn"/> parameter.
        /// This can be 0.
        /// </param>
        /// <param name="pvIn">
        /// A pointer to the input structure required for the specified escape.
        /// </param>
        /// <param name="pvOut">
        /// A pointer to the structure that receives output from this escape.
        /// This parameter should be <see cref="NULL"/> if no data is returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is greater than zero, except with the <see cref="QUERYESCSUPPORT"/> printer escape,
        /// which checks for implementation only.
        /// If the escape is not implemented, the return value is zero.
        /// If the function fails, the return value is a system error code.
        /// </returns>
        /// <remarks>
        /// Note
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// The effect of passing 0 for cbInput will depend on the value of nEscape and on the driver that is handling the escape.
        /// Of the original printer escapes, only the following can be used.
        /// <see cref="QUERYESCSUPPORT"/>: Determines whether a particular escape is implemented by the device driver.
        /// <see cref="PASSTHROUGH"/>: Allows the application to send data directly to a printer.
        /// For information about printer escapes, see <see cref="ExtEscape"/>.
        /// Use the <see cref="StartPage"/> function to prepare the printer driver to receive data.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Escape", ExactSpelling = true, SetLastError = true)]
        public static extern int Escape([In] HDC hdc, [In] GDIEscapes iEscape, [In] int cjIn, [In] IntPtr pvIn, [In] LPVOID pvOut);

        /// <summary>
        /// <para>
        /// The <see cref="ExtEscape"/> function enables an application to access device capabilities that are not available through GDI.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-extescape"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="iEscape">
        /// The escape function to be performed.
        /// It can be one of the following or it can be an application-defined escape function.
        /// <see cref="CHECKJPEGFORMAT"/>: Checks whether the printer supports a JPEG image. 
        /// <see cref="CHECKPNGFORMAT"/>: Checks whether the printer supports a PNG image. 
        /// <see cref="DRAWPATTERNRECT"/>: Draws a white, gray-scale, or black rectangle. 
        /// <see cref="GET_PS_FEATURESETTING"/>: Gets information on a specified feature setting for a PostScript driver. 
        /// <see cref="GETTECHNOLOGY"/>: Reports on whether or not the driver is a Postscript driver.
        /// <see cref="PASSTHROUGH"/>: Allows the application to send data directly to a printer. Supported in compatibility mode and GDI-centric mode.
        /// <see cref="POSTSCRIPT_DATA"/>: Allows the application to send data directly to a printer. Supported only in compatibility mode.
        /// <see cref="POSTSCRIPT_IDENTIFY"/>: Sets a PostScript driver to GDI-centric or PostScript-centric mode. 
        /// <see cref="POSTSCRIPT_INJECTION"/>: Inserts a block of raw data in a PostScript job stream.
        /// <see cref="POSTSCRIPT_PASSTHROUGH"/>: Sends data directly to a PostScript printer driver. Supported in compatibility mode and PostScript-centric mode.
        /// <see cref="QUERYESCSUPPORT"/>: Determines whether a particular escape is implemented by the device driver.
        /// <see cref="SPCLPASSTHROUGH2"/>: Enables applications to include private procedures and other resources at the document level-save context.
        /// </param>
        /// <param name="cjInput">
        /// The number of bytes of data pointed to by the <paramref name="lpInData"/> parameter.
        /// </param>
        /// <param name="lpInData">
        /// A pointer to the input structure required for the specified escape. See also Remarks.
        /// </param>
        /// <param name="cjOutput">
        /// The number of bytes of data pointed to by the <paramref name="lpOutData"/> parameter.
        /// </param>
        /// <param name="lpOutData">
        /// A pointer to the structure that receives output from this escape.
        /// This parameter must not be <see cref="NULL"/> if <see cref="ExtEscape"/> is called as a query function.
        /// If no data is to be returned in this structure, set <paramref name="cjOutput"/> to 0. See also Remarks.
        /// </param>
        /// <returns>
        /// The return value specifies the outcome of the function.
        /// It is greater than zero if the function is successful, except for the <see cref="QUERYESCSUPPORT"/> printer escape,
        /// which checks for implementation only.
        /// The return value is zero if the escape is not implemented.
        /// A return value less than zero indicates an error.
        /// </returns>
        /// <remarks>
        /// Note
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status, print server configuration,
        /// and printer driver implementation—factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface could make the application appear to be unresponsive.
        /// Use this function to pass a driver-defined escape value to a device.
        /// Use the <see cref="Escape"/> function to pass one of the system-defined escape values to a device,
        /// unless the escape is one of the defined escapes in <paramref name="iEscape"/>.
        /// <see cref="ExtEscape"/> might not work properly with the system-defined escapes.
        /// In particular, escapes in which lpszInData is a pointer to a structure that contains a member that is a pointer will fail.
        /// Note, that the behavior described in this article is the expected behavior, but it is up to the driver to comply with this model.
        /// The variables referenced by <paramref name="lpInData"/> and <paramref name="lpOutData"/> should not be the same or overlap.
        /// If the input and the output buffer size variables overlap, they may not contain the correct values after the call returns.
        /// For the best results, <paramref name="lpInData"/> and <paramref name="lpOutData"/> should refer to different variables.
        /// The <see cref="CHECKJPEGFORMAT"/> printer escape function determines whether a printer supports printing a JPEG image.
        /// Before using the <see cref="CHECKJPEGFORMAT"/> printer escape function,
        /// call the <see cref="QUERYESCSUPPORT"/> printer escape function to determine whether the driver supports <see cref="CHECKJPEGFORMAT"/>.
        /// For sample code that demonstrates the use of <see cref="CHECKJPEGFORMAT"/>, see Testing a Printer for JPEG or PNG Support.
        /// The <see cref="CHECKPNGFORMAT"/> printer escape function determines whether a printer supports printing a PNG image.
        /// Before using the <see cref="CHECKJPEGFORMAT"/> printer escape function,
        /// call the <see cref="QUERYESCSUPPORT"/> printer escape function to determine whether the driver supports <see cref="CHECKJPEGFORMAT"/>.
        /// For sample code, see Testing a Printer for JPEG or PNG Support.
        /// The <see cref="DRAWPATTERNRECT"/> printer escape creates a white, gray scale, or solid black rectangle
        /// by using the pattern and rule capabilities of Page Control Language (PCL) on Hewlett-Packard LaserJet or LaserJet-compatible printers.
        /// A gray scale is a gray pattern that contains a specific mixture of black and white pixels.
        /// An application should use the <see cref="QUERYESCSUPPORT"/> escape to determine
        /// whether the printer is capable of drawing patterns and rules before using the <see cref="DRAWPATTERNRECT"/> escape.
        /// Rules drawn with <see cref="DRAWPATTERNRECT"/> are not subject to clipping regions in the device context.
        /// Applications should not try to erase patterns and rules created with <see cref="DRAWPATTERNRECT"/> by placing opaque objects over them.
        /// If the printer supports white rules, these can be used to erase patterns created by <see cref="DRAWPATTERNRECT"/>.
        /// If the printer does not support white rules, there is no method for erasing these patterns.
        /// If an application cannot use the <see cref="DRAWPATTERNRECT"/> escape and the device is a printer,
        /// it should generally use the <see cref="PatBlt"/> function instead.
        /// Note that if <see cref="PatBlt"/> is used to print a black rectangle, the application should use the <see cref="BLACKNESS"/> raster operator.
        /// If the device is a plotter, however, the application should use the Rectangle function.
        /// The <see cref="GET_PS_FEATURESETTING"/> printer escape function retrieves information about a specified feature setting for a PostScript driver.
        /// This escape function is supported only if the PostScript driver is in PostScript-centric mode or in GDI-centric mode.
        /// To set the PostScript driver mode, call the <see cref="POSTSCRIPT_IDENTIFY"/> escape function.
        /// To perform this operation, call the <see cref="ExtEscape"/> function with the following parameters.
        /// The <see cref="GET_PS_FEATURESETTING"/> printer escape function is valid if called any time
        /// after calling the <see cref="CreateDC"/> function and before calling the <see cref="DeleteDC"/> function.
        /// The <see cref="GETTECHNOLOGY"/> printer escape function identifies the type of printer driver.
        /// For non-XPSDrv printers, this escape reports whether the driver is a Postscript driver.
        /// For XPSDrv printers, this escape reports whether the driver is the Microsoft XPS Document Converter (MXDC).
        /// If it is, the escape returns the zero-terminated string "http://schemas.microsoft.com/xps/2005/06"
        /// The <see cref="PASSTHROUGH"/> printer escape function sends data directly to a printer driver.
        /// To perform this operation, call the <see cref="ExtEscape"/> function with the following parameters.
        /// The <see cref="PASSTHROUGH"/> printer escape function is supported by PostScript drivers in GDI-centric mode or compatibility mode,
        /// but not in PostScript-centric mode.
        /// Drivers in PostScript-centric mode can use the <see cref="POSTSCRIPT_PASSTHROUGH"/> escape function.
        /// To set a PostScript driver mode, call the <see cref="POSTSCRIPT_IDENTIFY"/> escape function.
        /// For <see cref="PASSTHROUGH"/> data sent by EPSPRINTING or PostScript-centric applications,
        /// the PostScript driver will not make any modifications.
        /// For <see cref="PASSTHROUGH"/> data sent by other applications, if the PostScript driver is using BCP (Binary Communication Protocol)
        /// or TBCP (Tagged Binary Communication Protocol) output protocol, the driver does the appropriate BCP or TBCP quoting on special characters,
        /// as described in "Adobe Serial and Parallel Communications Protocols Specification."
        /// This means that the application should send either ASCII or pure binary PASSTHROUGH data.
        /// The <see cref="POSTSCRIPT_DATA"/> printer escape function sends data directly to a printer driver.
        /// To perform this operation, call the <see cref="ExtEscape"/> function with the following parameters.
        /// The <see cref="POSTSCRIPT_DATA"/> function is identical to the <see cref="PASSTHROUGH"/> escape function
        /// except that it is supported by PostScript drivers in compatibility mode only.
        /// It is not supported by PostScript drivers in PostScript-centric mode or in GDI-centric mode.
        /// Drivers in PostScript-centric mode can use the <see cref="POSTSCRIPT_PASSTHROUGH"/> escape function,
        /// and drivers in GDI-centric mode can use the <see cref="PASSTHROUGH"/> escape function.
        /// To set a PostScript driver's mode, call the <see cref="POSTSCRIPT_IDENTIFY"/> escape function.
        /// The <see cref="POSTSCRIPT_IDENTIFY"/> printer escape function sets a PostScript driver to GDI-centric mode or PostScript-centric mode.
        /// To put the driver in GDI-centric or PostScript-centric modes, first call the <see cref="QUERYESCSUPPORT"/> printer escape function
        /// to determine whether the driver supports the <see cref="POSTSCRIPT_IDENTIFY"/> printer escape function.
        /// If so, you can assume the driver is PSCRIPT 5.0.
        /// Then, before you call any other printer escape function, you must call <see cref="POSTSCRIPT_IDENTIFY"/>
        /// and specify either <see cref="PSIDENT_GDICENTRIC"/> or <see cref="PSIDENT_PSCENTRIC"/>.
        /// You must call the <see cref="QUERYESCSUPPORT"/> and <see cref="POSTSCRIPT_IDENTIFY"/> printer escape functions
        /// before calling any other printer escape function.
        /// Note
        /// After the PostScript driver is set to GDI-centric mode or PostScript-centric mode,
        /// you will not be allowed to call the <see cref="POSTSCRIPT_IDENTIFY"/> printer escape function anymore.
        /// If you do not use the <see cref="POSTSCRIPT_IDENTIFY"/> printer escape function,
        /// the PostScript driver is in compatibility mode and provides identical support
        /// for the <see cref="PASSTHROUGH"/>, <see cref="POSTSCRIPT_PASSTHROUGH"/>, and <see cref="POSTSCRIPT_DATA"/> printer escape functions.
        /// For PostScript drivers that support the <see cref="POSTSCRIPT_PASSTHROUGH"/>,
        /// <see cref="PASSTHROUGH"/>, and <see cref="POSTSCRIPT_PASSTHROUGH"/> printer escape functions are identical.
        /// In PostScript-centric mode, the application is responsible for all PostScript output that marks the paper
        /// using the <see cref="POSTSCRIPT_PASSTHROUGH"/> escape function.
        /// GDI functions are not allowed. The driver is responsible for the overall document structure and printer control settings.
        /// The application can use the <see cref="POSTSCRIPT_INJECTION"/> printer escape function
        /// to inject a block of raw data (including DSC comments) into the job stream at specific places.
        /// The <see cref="POSTSCRIPT_INJECTION"/> printer escape function inserts a block of raw data at a specified point in a PostScript job stream.
        /// A PostScript driver supports this escape function in GDI-centric mode or PostScript-centric mode support, but not in compatibility mode.
        /// To set the PostScript driver's mode, call the <see cref="POSTSCRIPT_IDENTIFY"/> escape function.
        /// To perform this operation, call the <see cref="ExtEscape"/> function with the following parameters.
        /// The driver internally caches the injection data and emits it at appropriate points in the output.
        /// The cached information is flushed when it is no longer needed. At the latest, it is flushed after the <see cref="EndDoc"/> call.
        /// In GDI-centric mode, the application can only inject valid DSC block data
        /// by using the <see cref="POSTSCRIPT_INJECTION"/> printer escape function.
        /// A valid DSC block must satisfy all of the following conditions:
        /// It consists of an integral sequence of "lines."
        /// Each "line" must begin with "%%".
        /// Each "line" except the last line must end with &lt;CR&gt;, &lt;LF&gt;, or &lt;CR&gt;&lt;LF&gt; except for the last line.
        /// If the last line does not end with &lt;CR&gt;, &lt;LF&gt;, or &lt;CR&gt;&lt;LF&gt;,
        /// the driver appends &lt;CR&gt;&lt;LF&gt; after the last byte of the injection data.
        /// Each "line" must be 255 bytes or less including the "%%" but not counting the &lt;CR&gt;/&lt;LF&gt; line termination.
        /// The <see cref="POSTSCRIPT_PASSTHROUGH"/> printer escape function sends data directly to a PostScript printer driver.
        /// A PostScript driver supports this escape function when in PostScript-centric mode or in compatibility mode, but not in GDI-centric mode.
        /// To set the PostScript driver's mode, call the <see cref="POSTSCRIPT_IDENTIFY"/> escape function.
        /// The <see cref="QUERYESCSUPPORT"/> printer escape function checks the implementation of a printer escape function.
        /// The <see cref="SPCLPASSTHROUGH2"/> printer escape function allows applications that print to PostScript devices
        /// using <see cref="EPSPRINTING"/> to include private PostScript procedures and other resources at the document-level save context.
        /// This escape is supported only for backward compatibility with Adobe Acrobat. Other applications should not use this obsolete escape.
        /// The application must call this escape before calling <see cref="StartDoc"/>
        /// so that the driver will cache the data for insertion at the correct point in the PostScript stream.
        /// If this escape is supported, the driver will also allow escape <see cref="DOWNLOADFACE"/> calls prior to <see cref="StartDoc"/>.
        /// The driver internally caches the data to be inserted and the data required
        /// by any escape <see cref="DOWNLOADFACE"/> calls prior to <see cref="StartDoc"/> and emits them all immediately before %%EndProlog.
        /// The sequence of <see cref="SPCLPASSTHROUGH2"/> and <see cref="DOWNLOADFACE"/> calls will be preserved in the order their data is passed in,
        /// that is, a later call results in data output after an earlier call's data.
        /// The driver will consider fonts downloaded by pre-StartDoc escape <see cref="DOWNLOADFACE"/> calls
        /// as unavailable for removal during the scope of the job.
        /// This escape is not recorded in EMF files by the operating system,
        /// therefore applications must ensure that EMF recording is turned off for those jobs using the escape.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtEscape", ExactSpelling = true, SetLastError = true)]
        public static extern int ExtEscape([In] HDC hdc, [In] GDIEscapes iEscape, [In] int cjInput, [In] IntPtr lpInData, [In] int cjOutput, [In] IntPtr lpOutData);

        /// <summary>
        /// <para>
        /// The <see cref="GdiFlush"/> function flushes the calling thread's current batch.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gdiflush"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If all functions in the current batch succeed, the return value is <see cref="TRUE"/>.
        /// If not all functions in the current batch succeed, the return value is <see cref="FALSE"/>,
        /// indicating that at least one function returned an error.
        /// </returns>
        /// <remarks>
        /// Batching enhances drawing performance by minimizing the amount of time needed to call GDI drawing functions that return Boolean values.
        /// The system accumulates the parameters for calls to these functions in the current batch
        /// and then calls the functions when the batch is flushed by any of the following means:
        /// Calling the <see cref="GdiFlush"/> function.
        /// Reaching or exceeding the batch limit set by the <see cref="GdiSetBatchLimit"/> function.
        /// Filling the batching buffers.
        /// Calling any GDI function that does not return a Boolean value.
        /// The return value for GdiFlush applies only to the functions in the batch at the time <see cref="GdiFlush"/> is called.
        /// Errors that occur when the batch is flushed by any other means are never reported.
        /// The <see cref="GdiGetBatchLimit"/> function returns the batch limit.
        /// Note
        /// The batch limit is maintained for each thread separately.
        /// In order to completely disable batching, call <code>GdiSetBatchLimit(1)</code> during the initialization of each thread.
        /// An application should call <see cref="GdiFlush"/> before a thread goes away
        /// if there is a possibility that there are pending function calls in the graphics batch queue.
        /// The system does not execute such batched functions when a thread goes away.
        /// A multithreaded application that serializes access to GDI objects with a mutex must
        /// ensure flushing the GDI batch queue by calling <see cref="GdiFlush"/> as each thread releases ownership of the GDI object.
        /// This prevents collisions of the GDI objects (device contexts, metafiles, and so on).
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiFlush", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiFlush();

        /// <summary>
        /// <para>
        /// The <see cref="GdiGetBatchLimit"/> function returns the maximum number of function
        /// calls that can be accumulated in the calling thread's current batch.
        /// The system flushes the current batch whenever this limit is exceeded.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gdigetbatchlimit"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is the batch limit.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The batch limit is set by using the <see cref="GdiSetBatchLimit"/> function.
        /// Setting the limit to 1 effectively disables batching.
        /// Only GDI drawing functions that return Boolean values can be batched;
        /// calls to any other GDI functions immediately flush the current batch.
        /// Exceeding the batch limit or calling the <see cref="GdiFlush"/> function also flushes the current batch.
        /// When the system batches a function call, the function returns <see cref="TRUE"/>.
        /// The actual return value for the function is reported only if <see cref="GdiFlush"/> is used to flush the batch.
        /// Note
        /// The batch limit is maintained for each thread separately.
        /// In order to completely disable batching, call <code>GdiSetBatchLimit(1)</code> during the initialization of each thread.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiGetBatchLimit", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GdiGetBatchLimit();

        /// <summary>
        /// <para>
        /// The <see cref="GdiSetBatchLimit"/> function sets the maximum number of function calls
        /// that can be accumulated in the calling thread's current batch.
        /// The system flushes the current batch whenever this limit is exceeded.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gdisetbatchlimit"/>
        /// </para>
        /// </summary>
        /// <param name="dw">
        /// Specifies the batch limit to be set.
        /// A value of 0 sets the default limit.
        /// A value of 1 disables batching.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the previous batch limit.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// Only GDI drawing functions that return Boolean values can be accumulated in the current batch;
        /// calls to any other GDI functions immediately flush the current batch.
        /// Exceeding the batch limit or calling the GdiFlush function also flushes the current batch.
        /// When the system accumulates a function call, the function returns <see cref="TRUE"/> to indicate it is in the batch.
        /// When the system flushes the current batch and executes the function for the second time,
        /// the return value is either <see cref="TRUE"/> or <see cref="FALSE"/>, depending on whether the function succeeds.
        /// This second return value is reported only if <see cref="GdiFlush"/> is used to flush the batch
        /// Note
        /// The batch limit is maintained for each thread separately.
        /// In order to completely disable batching, call <code>GdiSetBatchLimit(1)</code> during the initialization of each thread.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiSetBatchLimit", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GdiSetBatchLimit([In] DWORD dw);

        /// <summary>
        /// <para>
        /// The <see cref="GetBoundsRect"/> function obtains the current accumulated bounding rectangle for a specified device context.
        /// The system maintains an accumulated bounding rectangle for each application. An application can retrieve and set this rectangle.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getboundsrect"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context whose bounding rectangle the function will return.
        /// </param>
        /// <param name="lprect">
        /// A pointer to the <see cref="RECT"/> structure that will receive the current bounding rectangle.
        /// The application's rectangle is returned in logical coordinates, and the bounding rectangle is returned in screen coordinates.
        /// </param>
        /// <param name="flags">
        /// Specifies how the <see cref="GetBoundsRect"/> function will behave. This parameter can be the following value.
        /// <see cref="DCB_RESET"/>: 
        /// Clears the bounding rectangle after returning it.If this flag is not set, the bounding rectangle will not be cleared.
        /// </param>
        /// <returns>
        /// The return value specifies the state of the accumulated bounding rectangle; it can be one of the following values.
        /// 0: An error occurred. The specified device context handle is invalid.
        /// <see cref="DCB_DISABLE"/>: Boundary accumulation is off.
        /// <see cref="DCB_ENABLE"/>: Boundary accumulation is on.
        /// <see cref="DCB_RESET"/>: The bounding rectangle is empty.
        /// <see cref="DCB_SET"/>: The bounding rectangle is not empty.
        /// </returns>
        /// <remarks>
        /// The <see cref="DCB_SET"/> value is a combination of the bit values <see cref="DCB_ACCUMULATE"/> and <see cref="DCB_RESET"/>.
        /// Applications that check the <see cref="DCB_RESET"/> bit to determine whether the bounding rectangle is empty
        /// must also check the <see cref="DCB_ACCUMULATE"/> bit.
        /// The bounding rectangle is empty only if the <see cref="DCB_RESET"/> bit is 1 and the <see cref="DCB_ACCUMULATE"/> bit is 0.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBoundsRect", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetBoundsRect([In] HDC hdc, [Out] out RECT lprect, [In] BoundsAccumulationFlags flags);

        /// <summary>
        /// <para>
        /// The <see cref="GetMapMode"/> function retrieves the current mapping mode.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getmapmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the mapping mode.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The following are the various mapping modes.
        /// <see cref="MM_ANISOTROPIC"/>:
        /// Logical units are mapped to arbitrary units with arbitrarily scaled axes.
        /// Use the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions to specify the units, orientation, and scaling required.
        /// <see cref="MM_HIENGLISH"/>: Each logical unit is mapped to 0.001 inch. Positive x is to the right; positive y is up.
        /// <see cref="MM_HIMETRIC"/>: Each logical unit is mapped to 0.01 millimeter. Positive x is to the right; positive y is up.
        /// <see cref="MM_ISOTROPIC"/>:
        /// Logical units are mapped to arbitrary units with equally scaled axes; that is, one unit along the x-axis is equal to one unit along the y-axis.
        /// Use the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions to specify the units and the orientation of the axes.
        /// Graphics device interface makes adjustments as necessary to ensure the x and y units remain the same size.
        /// (When the windows extent is set, the viewport will be adjusted to keep the units isotropic).
        /// <see cref="MM_LOENGLISH"/>: Each logical unit is mapped to 0.01 inch. Positive x is to the right; positive y is up.
        /// <see cref="MM_LOMETRIC"/>: Each logical unit is mapped to 0.1 millimeter. Positive x is to the right; positive y is up.
        /// <see cref="MM_TEXT"/>: Each logical unit is mapped to one device pixel. Positive x is to the right; positive y is down.
        /// <see cref="MM_TWIPS"/>: 
        /// Each logical unit is mapped to one twentieth of a printer's point (1/1440 inch, also called a "twip").
        /// Positive x is to the right; positive y is up.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMapMode", ExactSpelling = true, SetLastError = true)]
        public static extern MappingModes GetMapMode([In] HDC hdc);

        /// <summary>
        /// <para>
        /// This function retrieves the x-extent and y-extent of the window for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getwindowextex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpsize">
        /// A pointer to a <see cref="SIZE"/> structure that receives the x- and y-extents in page-space units, that is, logical units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowExtEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetWindowExtEx([In] HDC hdc, [Out] out SIZE lpsize);

        /// <summary>
        /// <para>
        /// The <see cref="GetBValue"/> macro retrieves an intensity value for the blue component of a red, green, blue (RGB) value.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getrvalue"/>
        /// </para>
        /// </summary>
        /// <param name="rgb">
        /// Specifies an RGB color value.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The intensity value is in the range 0 through 255.
        /// </remarks>
        public static BYTE GetBValue(COLORREF rgb) => (byte)((rgb >> 16) & 0xff);

        /// <summary>
        /// <para>
        /// The <see cref="GetDeviceCaps"/> function retrieves device-specific information for the specified device.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getdevicecaps"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="nIndex">The item to be returned.</param>
        /// <returns>
        /// The return value specifies the value of the desired item.
        /// When <paramref name="nIndex"/> is <see cref="DeviceCapIndexes.BITSPIXEL"/> and the device has 15bpp or 16bpp, the return value is 16.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDeviceCaps", ExactSpelling = true, SetLastError = true)]
        public static extern int GetDeviceCaps([In] IntPtr hdc, [In] DeviceCapIndexes nIndex);

        /// <summary>
        /// <para>
        /// The <see cref="GetGValue"/> macro retrieves an intensity value for the green component of a red, green, blue (RGB) value.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getrvalue"/>
        /// </para>
        /// </summary>
        /// <param name="rgb">
        /// Specifies an RGB color value.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The intensity value is in the range 0 through 255.
        /// </remarks>
        public static BYTE GetGValue(COLORREF rgb) => (byte)((rgb >> 8) & 0xff);

        /// <summary>
        /// <para>
        /// The <see cref="GetRValue"/> macro retrieves an intensity value for the red component of a red, green, blue (RGB) value.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getrvalue"/>
        /// </para>
        /// </summary>
        /// <param name="rgb">
        /// Specifies an RGB color value.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The intensity value is in the range 0 through 255.
        /// </remarks>
        public static BYTE GetRValue(COLORREF rgb) => (byte)(rgb & 0xff);

        /// <summary>
        /// <para>
        /// The <see cref="GetObject"/> function retrieves information for the specified graphics object.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getobjectw"/>
        /// </para>
        /// </summary>
        /// <param name="h">
        /// A handle to the graphics object of interest.
        /// This can be a handle to one of the following: a logical bitmap, a brush, a font, a palette, a pen,
        /// or a device independent bitmap created by calling the <see cref="CreateDIBSection"/> function.
        /// </param>
        /// <param name="c">
        /// The number of bytes of information to be written to the buffer.
        /// </param>
        /// <param name="pv">
        /// A pointer to a buffer that receives the information about the specified graphics object.
        /// The following table shows the type of information the buffer receives for each type of graphics object you can specify with hgdiobj.
        /// <see cref="HBITMAP"/>: <see cref="BITMAP"/>
        /// <see cref="HBITMAP"/> returned from a call to <see cref="CreateDIBSection"/>:
        /// <see cref="DIBSECTION"/>, if <paramref name="c"/> is set to <code>sizeof (DIBSECTION)</code>,
        /// or <see cref="BITMAP"/>, if <paramref name="c"/> is set to <code>sizeof (BITMAP)</code>.
        /// <see cref="HPALETTE"/>:
        /// A <see cref="WORD"/> count of the number of entries in the logical palette
        /// <see cref="HPEN"/> returned from a call to <see cref="ExtCreatePen"/>: <see cref="EXTLOGPEN"/>
        /// <see cref="HPEN"/>: <see cref="LOGPEN"/>
        /// <see cref="HBRUSH"/>: <see cref="LOGBRUSH"/>
        /// <see cref="HFONT"/>: <see cref="LOGFONT"/>
        /// If the lpvObject parameter is <see cref="NULL"/>, the function return value is the number of bytes required to store the information
        /// it writes to the buffer for the specified graphics object.
        /// The address of <paramref name="pv"/> must be on a 4-byte boundary; otherwise, <see cref="GetObject"/> fails.
        /// </param>
        /// <returns>
        /// If the function succeeds, and <paramref name="pv"/> is a valid pointer, the return value is the number of bytes stored into the buffer.
        /// If the function succeeds, and <paramref name="pv"/> is <see cref="NULL"/>,
        /// the return value is the number of bytes required to hold the information the function would store into the buffer.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The buffer pointed to by the <paramref name="pv"/> parameter must be sufficiently large to receive the information about the graphics object.
        /// Depending on the graphics object, the function uses a <see cref="BITMAP"/>, <see cref="DIBSECTION"/>, <see cref="EXTLOGPEN"/>,
        /// <see cref="LOGBRUSH"/>, <see cref="LOGFONT"/>, or <see cref="LOGPEN"/> structure, or a count of table entries (for a logical palette).
        /// If <paramref name="h"/> is a handle to a bitmap created by calling <see cref="CreateDIBSection"/>, and the specified buffer is large enough,
        /// the <see cref="GetObject"/> function returns a <see cref="DIBSECTION"/> structure.
        /// In addition, the <see cref="BITMAP.bmBits"/> member of the <see cref="BITMAP"/> structure contained
        /// within the <see cref="DIBSECTION"/> will contain a pointer to the bitmap's bit values.
        /// If <paramref name="h"/> is a handle to a bitmap created by any other means,
        /// <see cref="GetObject"/> returns only the width, height, and color format information of the bitmap.
        /// You can obtain the bitmap's bit values by calling the <see cref="GetDIBits"/> or <see cref="GetBitmapBits"/> function.
        /// If <paramref name="h"/> is a handle to a logical palette, <see cref="GetObject"/> retrieves a 2-byte integer
        /// that specifies the number of entries in the palette.
        /// The function does not retrieve the <see cref="LOGPALETTE"/> structure defining the palette.
        /// To retrieve information about palette entries, an application can call the <see cref="GetPaletteEntries"/> function.
        /// If <paramref name="h"/> is a handle to a font, the <see cref="LOGFONT"/> that is returned is the LOGFONT used to create the font.
        /// If Windows had to make some interpolation of the font because the precise <see cref="LOGFONT"/> could not be represented,
        /// the interpolation will not be reflected in the <see cref="LOGFONT"/>.
        /// For example, if you ask for a vertical version of a font that doesn't support vertical painting,
        /// the <see cref="LOGFONT"/> indicates the font is vertical, but Windows will paint it horizontally.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetObjectW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetObject([In] HANDLE h, [In] int c, [In] LPVOID pv);

        /// <summary>
        /// <para>
        /// The <see cref="GetNearestColor"/> function retrieves a color value identifying a color from the system palette
        /// that will be displayed when the specified color value is used.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getnearestcolor"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="color">
        /// A color value that identifies a requested color.
        /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies a color from the system palette that corresponds to the given color value.
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNearestColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF GetNearestColor([In] HDC hdc, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="GetStockObject"/> function retrieves a handle to one of the stock pens, brushes, fonts, or palettes.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getstockobject"/>
        /// </para>
        /// </summary>
        /// <param name="i">
        /// The type of stock object.
        /// This parameter can be one of the following values.
        /// <see cref="BLACK_BRUSH"/>, <see cref="DKGRAY_BRUSH"/>, <see cref="DC_BRUSH"/>, <see cref="GRAY_BRUSH"/>, <see cref="HOLLOW_BRUSH"/>,
        /// <see cref="LTGRAY_BRUSH"/>, <see cref="NULL_BRUSH"/>, <see cref="WHITE_BRUSH"/>, <see cref="BLACK_PEN"/>, <see cref="DC_PEN"/>,
        /// <see cref="NULL_PEN"/>, <see cref="WHITE_PEN"/>, <see cref="ANSI_FIXED_FONT"/>, <see cref="ANSI_VAR_FONT"/>, <see cref="DEVICE_DEFAULT_FONT"/>,
        /// <see cref="DEFAULT_GUI_FONT"/>, <see cref="OEM_FIXED_FONT"/>, <see cref="SYSTEM_FONT"/>, <see cref="SYSTEM_FIXED_FONT"/>, <see cref="DEFAULT_PALETTE"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the requested logical object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        /// <remarks>
        /// It is not recommended that you employ this method to obtain the current font used by dialogs and windows.
        /// Instead, use the <see cref="SystemParametersInfo"/> function with the <see cref="SPI_GETNONCLIENTMETRICS"/> parameter to retrieve the current font.
        /// <see cref="SystemParametersInfo"/> will take into account the current theme and provides font information for captions, menus, and message dialogs.
        /// Use the <see cref="DKGRAY_BRUSH"/>, <see cref="GRAY_BRUSH"/>, and <see cref="LTGRAY_BRUSH"/> stock objects only in windows
        /// with the <see cref="CS_HREDRAW"/> and <see cref="CS_VREDRAW"/> styles.
        /// Using a gray stock brush in any other style of window can lead to misalignment of brush patterns after a window is moved or sized.
        /// The origins of stock brushes cannot be adjusted.
        /// The <see cref="HOLLOW_BRUSH"/> and <see cref="NULL_BRUSH"/> stock objects are equivalent.
        /// It is not necessary (but it is not harmful) to delete stock objects by calling <see cref="DeleteObject"/>.
        /// Both <see cref="DC_BRUSH"/> and <see cref="DC_PEN"/> can be used interchangeably
        /// with other stock objects like <see cref="BLACK_BRUSH"/> and <see cref="BLACK_PEN"/>.
        /// For information on retrieving the current pen or brush color, see <see cref="GetDCBrushColor"/> and <see cref="GetDCPenColor"/>.
        /// See Setting the Pen or Brush Color for an example of setting colors.
        /// The <see cref="GetStockObject"/> function with an argument of <see cref="DC_BRUSH"/> or <see cref="DC_PEN"/>
        /// can be used interchangeably with the <see cref="SetDCPenColor"/> and <see cref="SetDCBrushColor"/> functions.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetStockObject", ExactSpelling = true, SetLastError = true)]
        public static extern HGDIOBJ GetStockObject([In] StockObjectIndexes i);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextExtentPoint32"/> function computes the width and height of the specified string of text.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gettextextentpoint32w"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpString">
        /// A pointer to a buffer that specifies the text string.
        /// The string does not need to be null-terminated, because the c parameter specifies the length of the string.
        /// </param>
        /// <param name="c">
        /// The length of the string pointed to by lpString.
        /// </param>
        /// <param name="psizl">
        /// A pointer to a <see cref="SIZE"/> structure that receives the dimensions of the string, in logical units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetTextExtentPoint32"/> function uses the currently selected font to compute the dimensions of the string.
        /// The width and height, in logical units, are computed without considering any clipping.
        /// Because some devices kern characters, the sum of the extents of the characters in a string may not be equal to the extent of the string.
        /// The calculated string width takes into account the intercharacter spacing set by the <see cref="SetTextCharacterExtra"/> function
        /// and the justification set by <see cref="SetTextJustification"/>.
        /// This is true for both displaying on a screen and for printing.
        /// However, if lpDx is set in <see cref="ExtTextOut"/>, <see cref="GetTextExtentPoint32"/> does not take into account
        /// either intercharacter spacing or justification.
        /// In addition, for EMF, the print result always takes both intercharacter spacing and justification into account.
        /// When dealing with text displayed on a screen, the calculated string width takes into account the intercharacter spacing set
        /// by the <see cref="SetTextCharacterExtra"/> function and the justification set by <see cref="SetTextJustification"/>.
        /// However, if lpDx is set in <see cref="ExtTextOut"/>, <see cref="GetTextExtentPoint32"/> does not take into account
        /// either intercharacter spacing or justification. However, when printing with EMF:
        /// The print result ignores intercharacter spacing, although <see cref="GetTextExtentPoint32"/> takes it into account.
        /// The print result takes justification into account, although <see cref="GetTextExtentPoint32"/> ignores it.
        /// When this function returns the text extent, it assumes that the text is horizontal, that is, that the escapement is always 0.
        /// This is true for both the horizontal and vertical measurements of the text.
        /// Even if you use a font that specifies a nonzero escapement, this function doesn't use the angle while it computes the text extent.
        /// The app must convert it explicitly.
        /// However, when the graphics mode is set to <see cref="GM_ADVANCED"/> and the character orientation is 90 degrees from the print orientation,
        /// the values that this function return do not follow this rule.
        /// When the character orientation and the print orientation match for a given string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 116, cy : 18 }.
        /// When the character orientation and the print orientation are 90 degrees apart for the same string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 18, cy : 116 }.
        /// <see cref="GetTextExtentPoint32"/> doesn't consider "\n" (new line) or "\r\n" (carriage return and new line) characters
        /// when it computes the height of a text string.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextExtentPoint32W", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetTextExtentPoint32([In] IntPtr hdc, [MarshalAs(UnmanagedType.LPWStr)][In] string lpString,
            [In] int c, [Out] out SIZE psizl);

        /// <summary>
        /// <para>
        /// The <see cref="GetWindowOrgEx"/> function retrieves the x-coordinates and y-coordinates of the window origin for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getwindoworgex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lppoint">
        /// A pointer to a <see cref="POINT"/> structure that receives the coordinates, in logical units, of the window origin.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetWindowOrgEx([In] HDC hdc, [Out] out POINT lppoint);

        /// <summary>
        /// <para>
        /// The <see cref="GetViewportExtEx"/> function retrieves the x-extent and y-extent of the current viewport for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getviewportextex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpsize">
        /// A pointer to a <see cref="SIZE"/> structure that receives the x- and y-extents, in device units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetViewportExtEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetViewportExtEx([In] HDC hdc, [Out] out SIZE lpsize);

        /// <summary>
        /// <para>
        /// The <see cref="GetViewportOrgEx"/> function retrieves the x-coordinates and y-coordinates of the viewport origin for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getviewportorgex"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lppoint">
        /// A pointer to a <see cref="POINT"/> structure that receives the coordinates of the origin, in device units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetViewportOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetViewportOrgEx([In] HDC hdc, [Out] out POINT lppoint);

        /// <summary>
        /// <para>
        /// The <see cref="LPtoDP"/> function converts logical coordinates into device coordinates.
        /// The conversion depends on the mapping mode of the device context, the settings of the origins and extents for the window and viewport,
        /// and the world transformation.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-lptodp"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lppt">
        /// A pointer to an array of <see cref="POINT"/> structures.
        /// The x-coordinates and y-coordinates contained in each of the <see cref="POINT"/> structures will be transformed.
        /// </param>
        /// <param name="c">
        /// The number of points in the array.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="LPtoDP"/> function fails if the logical coordinates exceed 32 bits, or if the converted device coordinates exceed 27 bits.
        /// In the case of such an overflow, the results for all the points are undefined.
        /// <see cref="LPtoDP"/> calculates complex floating-point arithmetic, and it has a caching system for efficiency.
        /// Therefore, the conversion result of an initial call to <see cref="LPtoDP"/> might not exactly match
        /// the conversion result of a later call to <see cref="LPtoDP"/>.
        /// We recommend not to write code that relies on the exact match of the conversion results
        /// from multiple calls to <see cref="LPtoDP"/> even if the parameters that are passed to each call are identical.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LPtoDP", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LPtoDP([In] HDC hdc, [MarshalAs(UnmanagedType.LPArray)][In][Out] POINT[] lppt, [In] int c);

        /// <summary>
        /// <para>
        /// The <see cref="OffsetWindowOrgEx"/> function modifies the window origin for a device context using the specified horizontal and vertical offsets.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-offsetwindoworgex"/>
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
        /// If <paramref name="lppt"/> is <see langword="null"/>, the previous origin is not returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OffsetWindowOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OffsetWindowOrgEx([In] HDC hdc, [In] int x, [In] int y, [Out] out POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="PALETTEINDEX"/> macro accepts an index to a logical-color palette entry and returns a palette-entry specifier
        /// consisting of a <see cref="COLORREF"/> value that specifies the color associated with the given index.
        /// An application using a logical palette can pass this specifier, instead of an explicit red, green, blue (RGB) value,
        /// to GDI functions that expect a color.
        /// This allows the function to use the color in the specified palette entry.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-paletteindex"/>
        /// </para>
        /// </summary>
        /// <param name="i">
        /// An index to the palette entry containing the color to be used for a graphics operation.
        /// </param>
        /// <returns></returns>
        public static COLORREF PALETTEINDEX(WORD i) => 0x01000000 | i;

        /// <summary>
        /// <para>
        /// The <see cref="PALETTERGB"/> macro accepts three values that represent the relative intensities of red, green, and blueand returns
        /// a palette-relative red, green, blue (RGB) specifier consisting of 2 in the high-order byte and an RGB value in the three low-order bytes.
        /// An application using a color palette can pass this specifier, instead of an explicit RGB value, to functions that expect a color.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-palettergb"/>
        /// </para>
        /// </summary>
        /// <param name="r">
        /// The intensity of the red color field.
        /// </param>
        /// <param name="g">
        /// The intensity of the green color field.
        /// </param>
        /// <param name="b">
        /// The intensity of the blue color field.
        /// </param>
        /// <returns></returns>
        public static COLORREF PALETTERGB(byte r, byte g, byte b) => 0x02000000 | RGB(r, g, b);

        /// <summary>
        /// <para>
        /// The <see cref="OffsetViewportOrgEx"/> function modifies the viewport origin for a device context using the specified horizontal and vertical offsets.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-offsetviewportorgex"/>
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
        /// If <paramref name="lppt"/> is <see langword="null"/>, the previous viewport origin is not returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The new origin is the sum of the current origin and the horizontal and vertical offsets.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OffsetViewportOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL OffsetViewportOrgEx([In] HDC hdc, [In] int x, [In] int y, [In] in POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="ResetDC"/> function updates the specified printer or plotter device context (DC) using the specified information.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-resetdcw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC to update.
        /// </param>
        /// <param name="lpdm">
        /// A pointer to a <see cref="DEVMODE"/> structure containing information about the new DC.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the original DC.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// An application will typically use the <see cref="ResetDC"/> function when a window receives a <see cref="WM_DEVMODECHANGE"/> message.
        /// <see cref="ResetDC"/> can also be used to change the paper orientation or paper bins while printing a document.
        /// The <see cref="ResetDC"/> function cannot be used to change the driver name, device name, or the output port.
        /// When the user changes the port connection or device name, the application must delete the original DC
        /// and create a new DC with the new information.
        /// An application can pass an information DC to the <see cref="ResetDC"/> function.
        /// In that situation, <see cref="ResetDC"/> will always return a printer DC.
        /// ICM: The color profile of the DC specified by the <paramref name="hdc"/> parameter will be reset
        /// based on the information contained in the lpInitData member of the <see cref="DEVMODE"/> structure.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ResetDCW", ExactSpelling = true, SetLastError = true)]
        public static extern HDC ResetDC([In] HDC hdc, [In] in DEVMODE lpdm);

        /// <summary>
        /// <para>
        /// The <see cref="RestoreDC"/> function restores a device context (DC) to the specified state.
        /// The DC is restored by popping state information off a stack created by earlier calls to the <see cref="SaveDC"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-restoredc"/>
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
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Each DC maintains a stack of saved states.
        /// The <see cref="SaveDC"/> function pushes the current state of the DC onto its stack of saved states.
        /// That state can be restored only to the same DC from which it was created.
        /// After a state is restored, the saved state is destroyed and cannot be reused.
        /// Furthermore, any states saved after the restored state was created are also destroyed and cannot be used.
        /// In other words, the <see cref="RestoreDC"/> function pops the restored state (and any subsequent states) from the state information stack.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RestoreDC", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RestoreDC([In] HDC hdc, [In] int nSavedDC);

        /// <summary>
        /// <para>
        /// The <see cref="RGB"/> macro selects a red, green, blue (RGB) color based on the arguments supplied and the color capabilities of the output device.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-rgb"/>
        /// </para>
        /// </summary>
        /// <param name="r">
        /// The intensity of the red color.
        /// </param>
        /// <param name="g">
        /// The intensity of the green color.
        /// </param>
        /// <param name="b">
        /// The intensity of the blue color.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The intensity for each argument is in the range 0 through 255.
        /// If all three intensities are zero, the result is black.
        /// If all three intensities are 255, the result is white.
        /// To extract the individual values for the red, green, and blue components of a <see cref="COLORREF"/> color value,
        /// use the <see cref="GetRValue"/>, <see cref="GetGValue"/>, and <see cref="GetBValue"/> macros, respectively.
        /// When creating or examining a logical palette, use the <see cref="RGBQUAD"/> structure to define color values
        /// and examine individual component values.
        /// For more information about using color values in a color palette, see the descriptions
        /// of the <see cref="PALETTEINDEX"/> and <see cref="PALETTERGB"/> macros.
        /// </remarks>
        public static COLORREF RGB([In] byte r, [In] byte g, [In] byte b) => (COLORREF)(r | g << 8 | b << 16);

        /// <summary>
        /// <para>
        /// The <see cref="SaveDC"/> function saves the current state of the specified device context (DC) by copying data describing selected objects
        /// and graphic modes (such as the bitmap, brush, palette, font, pen, region, drawing mode, and mapping mode) to a context stack.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-savedc"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC whose state is to be saved.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies the saved state.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="SaveDC"/> function can be used any number of times to save any number of instances of the DC state.
        /// A saved state can be restored by using the <see cref="RestoreDC"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SaveDC", ExactSpelling = true, SetLastError = true)]
        public static extern int SaveDC([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="ScaleWindowExtEx"/> function modifies the window for a device context
        /// using the ratios formed by the specified multiplicands and divisors.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-scalewindowextex"/>
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
        /// If <paramref name="lpsz"/> is <see langword="null"/>, this parameter is not used.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The window extents are modified as follows:
        /// <code>
        /// xNewWE = (xOldWE * Xnum) / Xdenom 
        /// yNewWE = (yOldWE* Ynum) / Ydenom
        /// </code>
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ScaleWindowExtEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ScaleWindowExtEx([In] HDC hdc, [In] int xn, [In] int xd, [In] int yn, [In] int yd, [In] in SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="ScaleViewportExtEx"/> function modifies the viewport for a device context
        /// using the ratios formed by the specified multiplicands and divisors.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-scaleviewportextex"/>
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The viewport extents are modified as follows:
        ///  xNewVE = (xOldVE * Xnum) / Xdenom 
        ///  yNewVE = (yOldVE* Ynum) / Ydenom
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ScaleViewportExtEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ScaleViewportExtEx([In] HDC hdc, [In] int xn, [In] int dx, [In] int yn, [In] int yd, [In] in SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SelectObject"/> function selects an object into the specified device context (DC).
        /// The new object replaces the previous object of the same type.
        /// </para> 
        /// <para>
        ///  From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-selectobject"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <param name="hgdiobj">
        /// A handle to the object to be selected.
        /// The specified object must have been created by using one of the following functions.
        /// Bitmap:
        /// <see cref="CreateBitmap"/>, <see cref="CreateBitmapIndirect"/>, <see cref="CreateCompatibleBitmap"/>,
        /// <see cref="CreateDIBitmap"/>, <see cref="CreateDIBSection"/>
        /// Bitmaps can only be selected into memory DC's.
        /// A single bitmap cannot be selected into more than one DC at the same time.
        /// Brush:
        /// <see cref="CreateBrushIndirect"/>, <see cref="CreateDIBPatternBrush"/>, <see cref="CreateDIBPatternBrushPt"/>,
        /// <see cref="CreateHatchBrush"/>, <see cref="CreatePatternBrush"/>, <see cref="CreateSolidBrush"/>
        /// Font:
        /// <see cref="CreateFont"/>, <see cref="CreateFontIndirect"/>
        /// Pen:
        /// <see cref="CreatePen"/>, <see cref="CreatePenIndirect"/>
        /// Region:
        /// <see cref="CombineRgn"/>, <see cref="CreateEllipticRgn"/>, <see cref="CreateEllipticRgnIndirect"/>,
        /// <see cref="CreatePolygonRgn"/>, <see cref="CreatePolygonRgn"/>, <see cref="CreateRectRgnIndirect"/>
        /// </param>
        /// <returns>
        /// If the selected object is not a region and the function succeeds, the return value is a handle to the object being replaced.
        /// If the selected object is a region and the function succeeds, 
        /// the return value is one of the following values: <see cref="SIMPLEREGION"/>, <see cref="COMPLEXREGION"/>, <see cref="NULLREGION" />
        /// If an error occurs and the selected object is not a region, the return value is <see cref="NULL"/>.
        /// Otherwise, it is <see cref="HGDI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// This function returns the previously selected object of the specified type.
        /// An application should always replace a new object with the original, default object after it has finished drawing with the new object.
        /// An application cannot select a single bitmap into more than one DC at a time.
        /// ICM: If the object being selected is a brush or a pen, color management is performed.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectObject", ExactSpelling = true, SetLastError = true)]
        public static extern HGDIOBJ SelectObject([In] HDC hdc, [In] HGDIOBJ hgdiobj);

        /// <summary>
        /// <para>
        /// The <see cref="SetBoundsRect"/> function controls the accumulation of bounding rectangle information for the specified device context.
        /// The system can maintain a bounding rectangle for all drawing operations.
        /// An application can examine and set this rectangle.
        /// The drawing boundaries are useful for invalidating bitmap caches.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setboundsrect"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context for which to accumulate bounding rectangles.
        /// </param>
        /// <param name="lprect">
        /// A pointer to a <see cref="RECT"/> structure used to set the bounding rectangle.
        /// Rectangle dimensions are in logical coordinates.
        /// This parameter can be <see langword="null"/>.
        /// </param>
        /// <param name="flags">
        /// Specifies how the new rectangle will be combined with the accumulated rectangle.
        /// This parameter can be one of more of the following values.
        /// <see cref="DCB_ACCUMULATE"/>:
        /// Adds the rectangle specified by the <paramref name="lprect"/> parameter to the bounding rectangle (using a rectangle union operation).
        /// Using both <see cref="DCB_RESET"/> and <see cref="DCB_ACCUMULATE"/> sets the bounding rectangle
        /// to the rectangle specified by the <paramref name="lprect"/> parameter.
        /// <see cref="DCB_DISABLE"/>: Turns off boundary accumulation.
        /// <see cref="DCB_ENABLE"/>: Turns on boundary accumulation, which is disabled by default.
        /// <see cref="DCB_RESET"/>: Clears the bounding rectangle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the previous state of the bounding rectangle.
        /// This state can be a combination of the following values.
        /// <see cref="DCB_DISABLE"/>: Boundary accumulation is off.
        /// <see cref="DCB_ENABLE"/>: Boundary accumulation is on. <see cref="DCB_ENABLE"/> and <see cref="DCB_DISABLE"/> are mutually exclusive.
        /// <see cref="DCB_RESET"/>: Bounding rectangle is empty.
        /// <see cref="DCB_SET"/>: Bounding rectangle is not empty. <see cref="DCB_SET"/> and <see cref="DCB_RESET"/> are mutually exclusive.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="DCB_SET"/> value is a combination of the bit values <see cref="DCB_ACCUMULATE"/> and <see cref="DCB_RESET"/>.
        /// Applications that check the <see cref="DCB_RESET"/> bit to determine whether the bounding rectangle is empty
        /// must also check the <see cref="DCB_ACCUMULATE"/> bit.
        /// The bounding rectangle is empty only if the <see cref="DCB_RESET"/> bit is 1 and the <see cref="DCB_ACCUMULATE"/> bit is 0.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBoundsRect", ExactSpelling = true, SetLastError = true)]
        public static extern BoundsAccumulationFlags SetBoundsRect([In] HDC hdc, [In] in RECT lprect, [In] BoundsAccumulationFlags flags);

        /// <summary>
        /// <para>
        /// The <see cref="SetGraphicsMode"/> function sets the graphics mode for the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setgraphicsmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="iMode">
        /// The graphics mode. This parameter can be one of the following values.
        /// <see cref="GM_COMPATIBLE"/>, <see cref="GM_ADVANCED"/>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the old graphics mode.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// There are three areas in which graphics output differs according to the graphics mode:
        /// Text Output:
        /// In the <see cref="GM_COMPATIBLE"/> mode, TrueType (or vector font) text output behaves much the same way as
        /// raster font text output with respect to the world-to-device transformations in the DC.
        /// The TrueType text is always written from left to right and right side up, even if the rest of the graphics will be flipped on the x or y axis.
        /// Only the height of the TrueType (or vector font) text is scaled.
        /// The only way to write text that is not horizontal in the <see cref="GM_COMPATIBLE"/> mode is to specify nonzero escapement
        /// and orientation for the logical font selected in this device context.
        /// In the <see cref="GM_ADVANCED"/> mode, TrueType (or vector font) text output fully conforms to
        /// the world-to-device transformation in the device context.
        /// The raster fonts only have very limited transformation capabilities (stretching by some integer factors).
        /// Graphics device interface (GDI) tries to produce the best output it can with raster fonts for nontrivial transformations.
        /// Rectangle Exclusion:
        /// If the default <see cref="GM_COMPATIBLE"/> graphics mode is set, the system excludes bottom and rightmost edges when it draws rectangles.
        /// The <see cref="GM_ADVANCED"/> graphics mode is required if applications want to draw rectangles that are lower-right inclusive.
        /// Arc Drawing:
        /// If the default <see cref="GM_COMPATIBLE"/> graphics mode is set, GDI draws arcs using the current arc direction in the device space.
        /// With this convention, arcs do not respect page-to-device transforms that require a flip along the x or y axis.
        /// If the <see cref="GM_ADVANCED"/> graphics mode is set, GDI always draws arcs in the counterclockwise direction in logical space.
        /// This is equivalent to the statement that, in the <see cref="GM_ADVANCED"/> graphics mode,
        /// both arc control points and arcs themselves fully respect the device context's world-to-device transformation.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetGraphicsMode", ExactSpelling = true, SetLastError = true)]
        public static extern GraphicsModes SetGraphicsMode([In] HDC hdc, [In] GraphicsModes iMode);

        /// <summary>
        /// <para>
        /// The <see cref="SetICMMode"/> function causes Image Color Management to be enabled, disabled, or queried on a given device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-seticmmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Identifies handle to the device context.
        /// </param>
        /// <param name="mode">
        /// Turns on and off image color management. This parameter can take one of the following constant values.
        /// <see cref="ICM_ON"/>: Turns on color management. Turns off old-style color correction of halftones.
        /// <see cref="ICM_OFF"/>: Turns off color management. Turns on old-style color correction of halftones.
        /// <see cref="ICM_QUERY"/>: Queries the current state of color management.
        /// <see cref="ICM_DONE_OUTSIDEDC"/>:
        /// Turns off color management inside DC. Under Windows 2000, also turns off old-style color correction of halftones.
        /// Not supported under Windows 95.
        /// </param>
        /// <returns>
        /// If this function succeeds, the return value is a nonzero value.
        /// If this function fails, the return value is zero.
        /// If <see cref="ICM_QUERY"/> is specified and the function succeeds,
        /// the nonzero value returned is <see cref="ICM_ON"/> or <see cref="ICM_OFF"/> to indicate the current mode.
        /// </returns>
        /// <remarks>
        /// If the system cannot find an ICC color profile to match the state of the device, <see cref="SetICMMode"/> fails and returns zero.
        /// Once WCS is enabled for a device context (DC), colors passed into the DC using most Win32 API functions are color matched.
        /// The primary exceptions are <see cref="BitBlt"/> and <see cref="StretchBlt"/>.
        /// The assumption is that when performing a bit block transfer (blit) from one DC to another,
        /// the two DCs are already compatible and need no color correction.
        /// If this is not the case, color correction may be performed.
        /// Specifically, if a device independent bitmap (DIB) is used as the source for a blit,
        /// and the blit is performed into a DC that has WCS enabled, color matching will be performed.
        /// If this is not what you want, turn WCS off for the destination DC
        /// by calling <see cref="SetICMMode"/> before calling <see cref="BitBlt"/> or <see cref="StretchBlt"/>.
        /// If the <see cref="CreateCompatibleDC"/> function is used to create a bitmap in a DC,
        /// it is possible for the bitmap to be color matched twice, once when it is created and once when a blit is performed.
        /// The reason is that a bitmap in a DC created by the <see cref="CreateCompatibleDC"/> function acquires the current brush,
        /// pens, and palette of the source DC.
        /// However, WCS will be disabled by default for the new DC.
        /// If WCS is later enabled for the new DC by using the <see cref="SetICMMode"/> function, a color correction will be done.
        /// To prevent double color corrections through the use of the <see cref="CreateCompatibleDC"/> function,
        /// use the <see cref="SetICMMode"/> function to turn WCS off for the source DC before the <see cref="CreateCompatibleDC"/> function is called.
        /// When a compatible DC is created from a printer's DC (see <see cref="CreateCompatibleDC"/>),
        /// the default is for color matching to always be performed if it is enabled for the printer's DC.
        /// The default color profile for the printer is used when a blit is performed into the printer's DC
        /// using <see cref="SetDIBitsToDevice"/> or <see cref="StretchDIBits"/>.
        /// If this is not what you want, turn WCS off for the printer's DC by calling <see cref="SetICMMode"/>
        /// before calling <see cref="SetDIBitsToDevice"/> or <see cref="StretchDIBits"/>.
        /// Also, when printing to a printer's DC with WCS turned on, the <see cref="SetICMMode"/> function needs to be called
        /// after every call to the <see cref="StartPage"/> function to turn back on WCS.
        /// The StartPage function calls the <see cref="RestoreDC"/> and <see cref="SaveDC"/> functions,
        /// which result in WCS being turned off for the printer's DC.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetICMMode", ExactSpelling = true, SetLastError = true)]
        public static extern int SetICMMode([In] HDC hdc, [In] ICMModes mode);

        /// <summary>
        /// <para>
        /// The SetMapMode function sets the mapping mode of the specified device context.
        /// The mapping mode defines the unit of measure used to transform page-space units into device-space units,
        /// and also defines the orientation of the device's x and y axes.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setmapmode"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="iMode">
        /// The new mapping mode. This parameter can be one of the following values.
        /// <see cref="MM_ANISOTROPIC"/>:
        /// Logical units are mapped to arbitrary units with arbitrarily scaled axes.
        /// Use the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions to specify the units, orientation, and scaling.
        /// <see cref="MM_HIENGLISH"/>:
        /// Each logical unit is mapped to 0.001 inch. Positive x is to the right; positive y is up.
        /// <see cref="MM_HIMETRIC"/>:
        /// Each logical unit is mapped to 0.01 millimeter. Positive x is to the right; positive y is up.
        /// <see cref="MM_ISOTROPIC"/>:
        /// Logical units are mapped to arbitrary units with equally scaled axes; that is, one unit along the x-axis is equal to one unit along the y-axis.
        /// Use the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions to specify the units and the orientation of the axes.
        /// Graphics device interface (GDI) makes adjustments as necessary to ensure the x and y units remain the same size
        /// (When the window extent is set, the viewport will be adjusted to keep the units isotropic).
        /// <see cref="MM_LOENGLISH"/>:
        /// Each logical unit is mapped to 0.01 inch. Positive x is to the right; positive y is up.
        /// <see cref="MM_LOMETRIC"/>:
        /// Each logical unit is mapped to 0.1 millimeter. Positive x is to the right; positive y is up.
        /// <see cref="MM_TEXT"/>:
        /// Each logical unit is mapped to one device pixel. Positive x is to the right; positive y is down.
        /// <see cref="MM_TWIPS"/>:
        /// Each logical unit is mapped to one twentieth of a printer's point (1/1440 inch, also called a twip). Positive x is to the right; positive y is up.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies the previous mapping mode.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="MM_TEXT"/> mode allows applications to work in device pixels, whose size varies from device to device.
        /// The <see cref="MM_HIENGLISH"/>, <see cref="MM_HIMETRIC"/>, <see cref="MM_LOENGLISH"/>, <see cref="MM_LOMETRIC"/>,
        /// and <see cref="MM_TWIPS"/> modes are useful for applications drawing in physically meaningful units (such as inches or millimeters).
        /// The <see cref="MM_ISOTROPIC"/> mode ensures a 1:1 aspect ratio.
        /// The <see cref="MM_ANISOTROPIC"/> mode allows the x-coordinates and y-coordinates to be adjusted independently.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMapMode", ExactSpelling = true, SetLastError = true)]
        public static extern int SetMapMode([In] HDC hdc, [In] MappingModes iMode);

        /// <summary>
        /// <para>
        /// The <see cref="SetWindowExtEx"/> function sets the horizontal and vertical extents of the window for a device context by using the specified values.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setwindowextex"/>
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
        /// If <paramref name="lpsz"/> is <see langword="null"/>, this parameter is not used.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// The window refers to the logical coordinate system of the page space.
        /// The extent is the maximum value of an axis.
        /// This function sets the maximum values for the horizontal and vertical axes of the window (in logical coordinates).
        /// When mapping between page space and device space, <see cref="SetViewportExtEx"/> and <see cref="SetWindowExtEx"/> determine
        /// the scaling factor between the window and the viewport.
        /// For more information, see Transformation of Coordinate Spaces.
        /// When the following mapping modes are set, calls to the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions are ignored:
        /// <see cref="MM_HIENGLISH"/>, <see cref="MM_HIMETRIC"/>, <see cref="MM_LOENGLISH"/>, <see cref="MM_LOMETRIC"/>,
        /// <see cref="MM_TEXT"/>, <see cref="MM_TWIPS"/>
        /// When <see cref="MM_ISOTROPIC"/> mode is set, an application must call
        /// the <see cref="SetWindowExtEx"/> function before calling <see cref="SetViewportExtEx"/>.
        /// Note that for the <see cref="MM_ISOTROPIC"/> mode, certain portions of a nonsquare screen may not be available
        /// for display because the logical units on both axes represent equal physical distances.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowExtEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowExtEx([In] HDC hdc, [In] int x, [In] int y, [In] in SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SetWindowOrgEx"/> function specifies which window point maps to the viewport origin (0,0).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setwindoworgex"/>
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
        /// If <paramref name="lppt"/> is <see langword="null"/>, this parameter is not used.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// </returns>
        /// <remarks>
        /// This helps define the mapping from the logical coordinate space (also known as a window) to the device coordinate space (the viewport).
        /// <see cref="SetWindowOrgEx"/> specifies which logical point maps to the device point (0,0).
        /// It has the effect of shifting the axes so that the logical point (0,0) no longer refers to the upper-left corner.
        /// <code>
        /// //map the logical point (xWinOrg, yWinOrg) to the device point (0,0) 
        /// SetWindowOrgEx (hdc, xWinOrg, yWinOrg, NULL)
        /// </code>
        /// This is related to the <see cref="SetViewportOrgEx"/> function.
        /// Generally, you will use one function or the other, but not both.
        /// Regardless of your use of <see cref="SetWindowOrgEx"/> and <see cref="SetViewportOrgEx"/>,
        /// the device point (0,0) is always the upper-left corner.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetWindowOrgEx([In] HDC hdc, [In] int x, [In] int y, [In] in POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="SetViewportExtEx"/> function sets the horizontal and vertical extents of the viewport for a device context
        /// by using the specified values.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setviewportextex"/>
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
        /// If <paramref name="lpsz"/> is <see langword="null"/>, this parameter is not used.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The viewport refers to the device coordinate system of the device space.
        /// The extent is the maximum value of an axis.
        /// This function sets the maximum values for the horizontal and vertical axes of the viewport in device coordinates (or pixels).
        /// When mapping between page space and device space, <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/>
        /// determine the scaling factor between the window and the viewport.
        /// For more information, see Transformation of Coordinate Spaces.
        /// When the following mapping modes are set, calls to the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions are ignored.
        /// <see cref="MM_HIENGLISH"/>, <see cref="MM_HIMETRIC"/>, <see cref="MM_LOENGLISH"/>, <see cref="MM_LOMETRIC"/>,
        /// <see cref="MM_TEXT"/>, <see cref="MM_TWIPS"/>
        /// When <see cref="MM_ISOTROPIC"/> mode is set, an application must call the <see cref="SetWindowExtEx"/> function
        /// before it calls <see cref="SetViewportExtEx"/>.
        /// Note that for the <see cref="MM_ISOTROPIC"/> mode certain portions of a nonsquare screen may not be available for display
        /// because the logical units on both axes represent equal physical distances.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetViewportExtEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetViewportExtEx([In] HDC hdc, [In] int x, [In] int y, [In] in SIZE lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SetViewportOrgEx"/> function specifies which device point maps to the window origin (0,0).
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setviewportorgex"/>
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// This function (along with <see cref="SetViewportExtEx"/> and <see cref="SetWindowExtEx"/>) helps define the mapping
        /// from the logical coordinate space (also known as a window) to the device coordinate space (the viewport).
        /// <see cref="SetViewportOrgEx"/> specifies which device point maps to the logical point (0,0).
        /// It has the effect of shifting the axes so that the logical point (0,0) no longer refers to the upper-left corner.
        /// <code>
        /// //map the logical point (0,0) to the device point (xViewOrg, yViewOrg)
        /// SetViewportOrgEx(hdc, xViewOrg, yViewOrg, NULL)
        /// </code>
        /// This is related to the <see cref="SetWindowOrgEx"/> function.
        /// Generally, you will use one function or the other, but not both.
        /// Regardless of your use of <see cref="SetWindowOrgEx"/> and <see cref="SetViewportOrgEx"/>, the device point (0,0) is always the upper-left corner.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetViewportOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetViewportOrgEx([In] HDC hdc, [In] int x, [In] int y, [In] in POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="UnrealizeObject"/> function resets the origin of a brush or resets a logical palette.
        /// If the <paramref name="h"/> parameter is a handle to a brush, <see cref="UnrealizeObject"/> directs the system to reset
        /// the origin of the brush the next time it is selected.
        /// If the <paramref name="h"/> parameter is a handle to a logical palette, <see cref="UnrealizeObject"/> directs the system
        /// to realize the palette as though it had not previously been realized.
        /// The next time the application calls the <see cref="RealizePalette"/> function for the specified palette,
        /// the system completely remaps the logical palette to the system palette.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-unrealizeobject"/>
        /// </para>
        /// </summary>
        /// <param name="h">
        /// A handle to the logical palette to be reset.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="UnrealizeObject"/> function should not be used with stock objects.
        /// For example, the default palette, obtained by calling <code>GetStockObject (DEFAULT_PALETTE)</code>, is a stock object.
        /// A palette identified by hgdiobj can be the currently selected palette of a device context.
        /// If <paramref name="h"/> is a brush, <see cref="UnrealizeObject"/> does nothing, and the function returns <see cref="TRUE"/>.
        /// Use <see cref="SetBrushOrgEx"/> to set the origin of a brush.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnrealizeObject", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnrealizeObject([In] HGDIOBJ h);
    }
}
