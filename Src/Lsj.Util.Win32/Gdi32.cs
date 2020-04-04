using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.GraphicsModes;
using static Lsj.Util.Win32.Enums.StockObjectIndexes;
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
        /// <para>
        /// The EnumObjectsProc function is an application-defined callback function used with the <see cref="EnumObjects"/> function.
        /// It is used to process the object data.
        /// The <see cref="GOBJENUMPROC"/> type defines a pointer to this callback function. 
        /// EnumObjectsProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/dd162686(v=vs.85)
        /// </para>
        /// </summary>
        /// <param name="lpLogObject">
        /// A pointer to a <see cref="LOGPEN"/> or <see cref="LOGBRUSH"/> structure describing the attributes of the object.
        /// </param>
        /// <param name="lpData">
        /// A pointer to the application-defined data passed by the <see cref="EnumObjects"/> function.
        /// </param>
        /// <returns>
        /// To continue enumeration, the callback function must return a nonzero value. This value is user-defined.
        /// To stop enumeration, the callback function must return zero.
        /// </returns>
        /// <remarks>
        /// An application must register this function by passing its address to the <see cref="EnumObjects"/> function.
        /// </remarks>
        public delegate int GOBJENUMPROC([In]LPVOID lpLogObject, [In]LPARAM lpData);

        /// <summary>
        /// <para>
        /// The <see cref="CreateCompatibleDC"/> function creates a memory device context (DC) compatible with the specified device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createcompatibledc
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
        public static extern HDC CreateCompatibleDC([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDC"/> function creates a device context (DC) for a device using the specified name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createdcw
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
        /// either <see langword="null"/> or a pointer to <see cref="DEVMODE"/> that
        /// matches the current <see cref="DEVMODE"/> of the display device that <paramref name="pwszDevice"/> specifies.
        /// We recommend to pass <see langword="null"/> and not to try to exactly match the <see cref="DEVMODE"/> for the current display device.
        /// When you call <see cref="CreateDC"/> to create the <see cref="HDC"/> for a printer device, the printer driver validates the <see cref="DEVMODE"/>.
        /// If the printer driver determines that the <see cref="DEVMODE"/> is invalid (that is, printer driver can’t convert or consume the <see cref="DEVMODE"/>),
        /// the printer driver provides a default <see cref="DEVMODE"/> to create the <see cref="HDC"/> for the printer device.
        /// ICM: To enable ICM, set the <see cref="dmICMMethod"/> member of the <see cref="DEVMODE"/> structure
        /// (pointed to by the <see cref="pInitData"/> parameter) to the appropriate value.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDCW", ExactSpelling = true, SetLastError = true)]
        public static extern HDC CreateDC([MarshalAs(UnmanagedType.LPWStr)][In]string pwszDriver,
            [MarshalAs(UnmanagedType.LPWStr)][In]string pwszDevice, [MarshalAs(UnmanagedType.LPWStr)][In]string pszPort,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<DEVMODE>))][In]StructPointerOrNullObject<DEVMODE> pdm);

        /// <summary>
        /// <para>
        /// The <see cref="CreateIC"/> function creates an information context for the specified device.
        /// The information context provides a fast way to get information about the device without creating a device context (DC).
        /// However, GDI drawing functions cannot accept a handle to an information context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createicw
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
        /// The <see cref="lpdvmInit"/> parameter must be <see langword="null"/> if the device driver is to use the default initialization
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
        public static extern HDC CreateIC([MarshalAs(UnmanagedType.LPWStr)][In]string pszDriver,
            [MarshalAs(UnmanagedType.LPWStr)][In]string pszDevice, [MarshalAs(UnmanagedType.LPWStr)][In]string pszPort,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<DEVMODE>))][In]StructPointerOrNullObject<DEVMODE> pdm);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteDC"/> function deletes the specified device context (DC).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-deletedc
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteDC", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteDC([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteObject"/> function deletes a logical pen, brush, font, bitmap, region, or palette, 
        /// freeing all system resources associated with the object.
        /// After the object is deleted, the specified handle is no longer valid.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-deleteobject
        /// </para>
        /// </summary>
        /// <param name="hObject">A handle to a logical pen, brush, font, bitmap, region, or palette.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the specified handle is not valid or is currently selected into a DC, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteObject", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteObject([In]HGDIOBJ hObject);

        /// <summary>
        /// <para>
        /// The <see cref="DPtoLP"/> function converts device coordinates into logical coordinates.
        /// The conversion depends on the mapping mode of the device context, the settings of the origins and extents for the window and viewport,
        /// and the world transformation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-dptolp
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
        public static extern BOOL DPtoLP([In]HDC hdc, [MarshalAs(UnmanagedType.LPArray)][In][Out]POINT[] lppt, [In]int c);

        /// <summary>
        /// <para>
        /// The <see cref="EnumObjects"/> function enumerates the pens or brushes available for the specified device context (DC).
        /// This function calls the application-defined callback function once for each available object, supplying data describing that object.
        /// <see cref="EnumObjects"/> continues calling the callback function until the callback function returns zero
        /// or until all of the objects have been enumerated.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-enumobjects
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
        public static extern int EnumObjects([In]HDC hdc, [In]int nType, [In]GOBJENUMPROC lpFunc, [In]LPARAM lParam);

        /// <summary>
        /// <para>
        /// The <see cref="Escape"/> function enables an application to access the system-defined device capabilities that are not available through GDI.
        /// Escape calls made by an application are translated and sent to the driver.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-escape
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
        public static extern int Escape([In]HDC hdc, [In]int iEscape, [In]int cjIn, [In]IntPtr pvIn, [In]LPVOID pvOut);

        /// <summary>
        /// <para>
        /// The <see cref="GetBoundsRect"/> function obtains the current accumulated bounding rectangle for a specified device context.
        /// The system maintains an accumulated bounding rectangle for each application. An application can retrieve and set this rectangle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getboundsrect
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
        public static extern UINT GetBoundsRect([In]HDC hdc, [Out]out RECT lprect, [In]BoundsAccumulationFlags flags);

        /// <summary>
        /// <para>
        /// The <see cref="GetMapMode"/> function retrieves the current mapping mode.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getmapmode
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
        public static extern MappingModes GetMapMode([In]HDC hdc);

        /// <summary>
        /// <para>
        /// This function retrieves the x-extent and y-extent of the window for the specified device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getwindowextex
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
        public static extern BOOL GetWindowExtEx([In]HDC hdc, [Out]out SIZE lpsize);

        /// <summary>
        /// <para>
        /// The <see cref="GetBValue"/> macro retrieves an intensity value for the blue component of a red, green, blue (RGB) value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getrvalue
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getdevicecaps
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="nIndex">The item to be returned.</param>
        /// <returns>
        /// The return value specifies the value of the desired item.
        /// When <paramref name="nIndex"/> is <see cref="DeviceCapIndexes.BITSPIXEL"/> and the device has 15bpp or 16bpp, the return value is 16.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDeviceCaps", ExactSpelling = true, SetLastError = true)]
        public static extern int GetDeviceCaps([In]IntPtr hdc, [In]DeviceCapIndexes nIndex);

        /// <summary>
        /// <para>
        /// The <see cref="GetGValue"/> macro retrieves an intensity value for the green component of a red, green, blue (RGB) value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getrvalue
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getrvalue
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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getobjectw
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
        /// <see cref="DIBSECTION"/>, if <see cref="cbBuffer"/> is set to <code>sizeof (DIBSECTION)</code>,
        /// or <see cref="BITMAP"/>, if cbBuffer is set to <code>sizeof (BITMAP)</code>.
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
        /// In addition, the <see cref="bmBits"/> member of the <see cref="BITMAP"/> structure contained
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
        public static extern int GetObject([In]HANDLE h, [In]int c, [In]LPVOID pv);

        /// <summary>
        /// <para>
        /// The <see cref="GetNearestColor"/> function retrieves a color value identifying a color from the system palette
        /// that will be displayed when the specified color value is used.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getnearestcolor
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
        public static extern COLORREF GetNearestColor([In]HDC hdc, [In]COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="GetStockObject"/> function retrieves a handle to one of the stock pens, brushes, fonts, or palettes.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getstockobject
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
        public static extern HGDIOBJ GetStockObject([In]StockObjectIndexes i);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextExtentPoint32"/> function computes the width and height of the specified string of text.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gettextextentpoint32w
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
        public static extern bool GetTextExtentPoint32([In]IntPtr hdc, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString,
            [In] int c, [Out]out SIZE psizl);

        /// <summary>
        /// <para>
        /// The <see cref="GetWindowOrgEx"/> function retrieves the x-coordinates and y-coordinates of the window origin for the specified device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getwindoworgex
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
        public static extern BOOL GetWindowOrgEx([In]HDC hdc, [Out]out POINT lppoint);

        /// <summary>
        /// <para>
        /// The <see cref="GetViewportExtEx"/> function retrieves the x-extent and y-extent of the current viewport for the specified device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getviewportextex
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
        public static extern BOOL GetViewportExtEx([In]HDC hdc, [Out]out SIZE lpsize);

        /// <summary>
        /// <para>
        /// The <see cref="GetViewportOrgEx"/> function retrieves the x-coordinates and y-coordinates of the viewport origin for the specified device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getviewportorgex
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
        public static extern BOOL GetViewportOrgEx([In]HDC hdc, [Out]out POINT lppoint);

        /// <summary>
        /// <para>
        /// The <see cref="LPtoDP"/> function converts logical coordinates into device coordinates.
        /// The conversion depends on the mapping mode of the device context, the settings of the origins and extents for the window and viewport,
        /// and the world transformation.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-lptodp
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
        public static extern BOOL LPtoDP([In]HDC hdc, [MarshalAs(UnmanagedType.LPArray)][In][Out]POINT[] lppt, [In]int c);

        /// <summary>
        /// <para>
        /// The <see cref="OffsetWindowOrgEx"/> function modifies the window origin for a device context using the specified horizontal and vertical offsets.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-offsetwindoworgex
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
        public static extern BOOL OffsetWindowOrgEx([In]HDC hdc, [In]int x, [In]int y, [Out]out POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="OffsetViewportOrgEx"/> function modifies the viewport origin for a device context using the specified horizontal and vertical offsets.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-offsetviewportorgex
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
        public static extern BOOL OffsetViewportOrgEx([In]HDC hdc, [In]int x, [In]int y,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<POINT>))][In]StructPointerOrNullObject<POINT> lppt);

        /// <summary>
        /// <para>
        /// The <see cref="RestoreDC"/> function restores a device context (DC) to the specified state.
        /// The DC is restored by popping state information off a stack created by earlier calls to the <see cref="SaveDC"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-restoredc
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
        public static extern BOOL RestoreDC([In]HDC hdc, [In]int nSavedDC);

        /// <summary>
        /// <para>
        /// The <see cref="RGB"/> macro selects a red, green, blue (RGB) color based on the arguments supplied and the color capabilities of the output device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-rgb
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
        /// When creating or examining a logical palette, use the <see cref="RGBQUAD"/> structure to define color values and examine individual component values.
        /// For more information about using color values in a color palette, see the descriptions of the <see cref="PALETTEINDEX"/> and <see cref="PALETTERGB"/> macros.
        /// </remarks>
        public static COLORREF RGB([In]byte r, [In]byte g, [In]byte b) => (COLORREF)(r | g << 8 | b << 16);

        /// <summary>
        /// <para>
        /// The <see cref="SaveDC"/> function saves the current state of the specified device context (DC) by copying data describing selected objects
        /// and graphic modes (such as the bitmap, brush, palette, font, pen, region, drawing mode, and mapping mode) to a context stack.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-savedc
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
        public static extern int SaveDC([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="ScaleWindowExtEx"/> function modifies the window for a device context
        /// using the ratios formed by the specified multiplicands and divisors.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-scalewindowextex
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
        public static extern BOOL ScaleWindowExtEx([In]HDC hdc, [In]int xn, [In]int xd, [In]int yn, [In]int yd,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SIZE>))][In]StructPointerOrNullObject<SIZE> lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="ScaleViewportExtEx"/> function modifies the viewport for a device context
        /// using the ratios formed by the specified multiplicands and divisors.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-scaleviewportextex
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
        public static extern BOOL ScaleViewportExtEx([In]HDC hdc, [In]int xn, [In]int dx, [In]int yn, [In]int yd,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SIZE>))][In]StructPointerOrNullObject<SIZE> lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SelectObject"/> function selects an object into the specified device context (DC).
        /// The new object replaces the previous object of the same type.
        /// </para> 
        /// <para>
        ///  From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-selectobject
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
        public static extern HGDIOBJ SelectObject([In]HDC hdc, [In]HGDIOBJ hgdiobj);

        /// <summary>
        /// <para>
        /// The <see cref="SetBoundsRect"/> function controls the accumulation of bounding rectangle information for the specified device context.
        /// The system can maintain a bounding rectangle for all drawing operations.
        /// An application can examine and set this rectangle.
        /// The drawing boundaries are useful for invalidating bitmap caches.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setboundsrect
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
        public static extern BoundsAccumulationFlags SetBoundsRect([In]HDC hdc,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<RECT>))][In]StructPointerOrNullObject<RECT> lprect,
            [In]BoundsAccumulationFlags flags);

        /// <summary>
        /// <para>
        /// The SetMapMode function sets the mapping mode of the specified device context.
        /// The mapping mode defines the unit of measure used to transform page-space units into device-space units,
        /// and also defines the orientation of the device's x and y axes.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setmapmode
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
        public static extern int SetMapMode([In]HDC hdc, [In]int iMode);

        /// <summary>
        /// <para>
        /// The <see cref="SetWindowExtEx"/> function sets the horizontal and vertical extents of the window for a device context by using the specified values.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setwindowextex
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
        public static extern BOOL SetWindowExtEx([In]HDC hdc, [In]int x, [In]int y,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SIZE>))][In]StructPointerOrNullObject<SIZE> lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SetWindowOrgEx"/> function specifies which window point maps to the viewport origin (0,0).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setwindoworgex
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
        public static extern BOOL SetWindowOrgEx([In]HDC hdc, [In]int x, [In]int y,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<POINT>))][In]StructPointerOrNullObject<POINT> lppt);

        /// <summary>
        /// <para>
        /// The <see cref="SetViewportExtEx"/> function sets the horizontal and vertical extents of the viewport for a device context
        /// by using the specified values.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setviewportextex
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetViewportExtEx([In]HDC hdc, [In]int x, [In]int y,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SIZE>))][In]StructPointerOrNullObject<SIZE> lpsz);

        /// <summary>
        /// <para>
        /// The <see cref="SetViewportOrgEx"/> function specifies which device point maps to the window origin (0,0).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setviewportorgex
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
        public static extern BOOL SetViewportOrgEx([In]HDC hdc, [In]int x, [In]int y,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<POINT>))][In]StructPointerOrNullObject<POINT> lppt);

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
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-unrealizeobject
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
        public static extern BOOL UnrealizeObject([In]HGDIOBJ h);
    }
}
