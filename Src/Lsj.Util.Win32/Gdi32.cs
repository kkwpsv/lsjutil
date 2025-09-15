using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.COLORREF;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.BoundsRectAccumulationFlags;
using static Lsj.Util.Win32.Enums.EditControlStyles;
using static Lsj.Util.Win32.Enums.EscapeFunctions;
using static Lsj.Util.Win32.Enums.ExtendedWindowStyles;
using static Lsj.Util.Win32.Enums.GraphicsModes;
using static Lsj.Util.Win32.Enums.ICMModes;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.Enums.ObjTypes;
using static Lsj.Util.Win32.Enums.RasterCodes;
using static Lsj.Util.Win32.Enums.RegionFlags;
using static Lsj.Util.Win32.Enums.StockObjectIndexes;
using static Lsj.Util.Win32.Enums.StretchBltModes;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.WindowClassStyles;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Gdi32.dll
    /// </summary>
    public static partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The EnumObjectsProc function is an application-defined callback function used with the <see cref="EnumObjects"/> function.
        /// It is used to process the object data.
        /// The <see cref="GOBJENUMPROC"/> type defines a pointer to this callback function.
        /// EnumObjectsProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nc-wingdi-gobjenumproc"/>
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
        /// The <see cref="DeleteObject"/> function deletes a logical pen, brush, font, bitmap, region, or palette, 
        /// freeing all system resources associated with the object.
        /// After the object is deleted, the specified handle is no longer valid.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deleteobject"/>
        /// </para>
        /// </summary>
        /// <param name="hObject">A handle to a logical pen, brush, font, bitmap, region, or palette.</param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the specified handle is not valid or is currently selected into a DC, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Do not delete a drawing object (pen or brush) while it is still selected into a DC.
        /// </para>
        /// <para>
        /// When a pattern brush is deleted, the bitmap associated with the brush is not deleted.
        /// The bitmap must be deleted independently.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteObject", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteObject([In] HGDIOBJ hObject);

        /// <summary>
        /// <para>
        /// The <see cref="DPtoLP"/> function converts device coordinates into logical coordinates.
        /// The conversion depends on the mapping mode of the device context,
        /// the settings of the origins and extents for the window and viewport, and the world transformation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-dptolp"/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="DPtoLP"/> function fails if the device coordinates exceed 27 bits,
        /// or if the converted logical coordinates exceed 32 bits.
        /// In the case of such an overflow, the results for all the points are undefined.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DPtoLP", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DPtoLP([In] HDC hdc, [In][Out] POINT[] lppt, [In] int c);

        /// <summary>
        /// <para>
        /// The <see cref="DrawEscape"/> function provides drawing capabilities of the specified video display
        /// that are not directly available through the graphics device interface (GDI).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-drawescape"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC for the specified video display.
        /// </param>
        /// <param name="iEscape">
        /// The escape function to be performed.
        /// </param>
        /// <param name="cjIn">
        /// The number of bytes of data pointed to by the <paramref name="lpIn"/> parameter.
        /// </param>
        /// <param name="lpIn">
        /// A pointer to the input structure required for the specified escape.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function is successful, the return value is greater than zero
        /// except for the <see cref="QUERYESCSUPPORT"/> draw escape, which checks for implementation only.
        /// </para>
        /// <para>
        /// If the escape is not implemented, the return value is zero.
        /// </para>
        /// <para>
        /// If an error occurred, the return value is less than zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// When an application calls the <see cref="DrawEscape"/> function,
        /// the data identified by <paramref name="cjIn"/> and <paramref name="lpIn"/> is passed directly to the specified display driver.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawEscape", ExactSpelling = true, SetLastError = true)]
        public static extern int DrawEscape([In] HDC hdc, [In] int iEscape, [In] int cjIn, [In] LPCSTR lpIn);

        /// <summary>
        /// <para>
        /// The <see cref="EnumObjects"/> function enumerates the pens or brushes available for the specified device context (DC).
        /// This function calls the application-defined callback function once for each available object, supplying data describing that object.
        /// <see cref="EnumObjects"/> continues calling the callback function until the callback function returns zero
        /// or until all of the objects have been enumerated.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enumobjects"/>
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
        /// <para>
        /// If the function succeeds, the return value is the last value returned by the callback function.
        /// Its meaning is user-defined.
        /// </para>
        /// <para>
        /// If the objects cannot be enumerated (for example, there are too many objects),
        /// the function returns zero without calling the callback function.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumObjects", ExactSpelling = true, SetLastError = true)]
        public static extern int EnumObjects([In] HDC hdc, [In] ObjTypes nType, [In] GOBJENUMPROC lpFunc, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// The <see cref="Escape"/> function enables an application
        /// to access the system-defined device capabilities that are not available through GDI.
        /// Escape calls made by an application are translated and sent to the driver.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-escape"/>
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
        /// <para>
        /// If the function succeeds, the return value is greater than zero,
        /// except with the <see cref="QUERYESCSUPPORT"/> printer escape, which checks for implementation only.
        /// If the escape is not implemented, the return value is zero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is a system error code.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status,
        /// print server configuration, and printer driver implementation
        /// —factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface
        /// could make the application appear to be unresponsive.
        /// </para>
        /// <para>
        /// The effect of passing 0 for <paramref name="cjIn"/> will depend on the value of <paramref name="iEscape"/>
        /// and on the driver that is handling the escape.
        /// </para>
        /// <para>
        /// Of the original printer escapes, only the following can be used.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Escape
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="QUERYESCSUPPORT"/>
        /// </term>
        /// <term>
        /// Determines whether a particular escape is implemented by the device driver.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PASSTHROUGH"/>
        /// </term>
        /// <term>
        /// Allows the application to send data directly to a printer.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For information about printer escapes, see <see cref="ExtEscape"/>.
        /// </para>
        /// <para>
        /// Use the <see cref="StartPage"/> function to prepare the printer driver to receive data.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Escape", ExactSpelling = true, SetLastError = true)]
        public static extern int Escape([In] HDC hdc, [In] EscapeFunctions iEscape, [In] int cjIn, [In] IntPtr pvIn, [In] LPVOID pvOut);

        /// <summary>
        /// <para>
        /// The <see cref="ExtEscape"/> function enables an application to access device capabilities that are not available through GDI.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-extescape"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="iEscape">
        /// <para>
        /// The escape function to be performed.
        /// It can be one of the following or it can be an application-defined escape function.
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
        /// <see cref="CHECKJPEGFORMAT"/>
        /// </term>
        /// <term>
        /// Checks whether the printer supports a JPEG image.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CHECKPNGFORMAT"/>
        /// </term>
        /// <term>
        /// Checks whether the printer supports a PNG image.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DRAWPATTERNRECT"/>
        /// </term>
        /// <term>
        /// Draws a white, gray-scale, or black rectangle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GET_PS_FEATURESETTING"/>
        /// </term>
        /// <term>
        /// Gets information on a specified feature setting for a PostScript driver.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GETTECHNOLOGY"/>
        /// </term>
        /// <term>
        /// Reports on whether or not the driver is a Postscript driver.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PASSTHROUGH"/>
        /// </term>
        /// <term>
        /// Allows the application to send data directly to a printer.
        /// Supported in compatibility mode and GDI-centric mode.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="POSTSCRIPT_DATA"/>
        /// </term>
        /// <term>
        /// Allows the application to send data directly to a printer.
        /// Supported only in compatibility mode.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="POSTSCRIPT_IDENTIFY"/>
        /// </term>
        /// <term>
        /// Sets a PostScript driver to GDI-centric or PostScript-centric mode.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="POSTSCRIPT_INJECTION"/>
        /// </term>
        /// <term>
        /// Inserts a block of raw data in a PostScript job stream.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="POSTSCRIPT_PASSTHROUGH"/>
        /// </term>
        /// <term>
        /// Sends data directly to a PostScript printer driver.
        /// Supported in compatibility mode and PostScript-centric mode.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="QUERYESCSUPPORT"/>
        /// </term>
        /// <term>
        /// Determines whether a particular escape is implemented by the device driver.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SPCLPASSTHROUGH2"/>
        /// </term>
        /// <term>
        /// Enables applications to include private procedures and other resources at the document level-save context.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
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
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This is a blocking or synchronous function and might not return immediately.
        /// How quickly this function returns depends on run-time factors such as network status,
        /// print server configuration, and printer driver implementation
        /// —factors that are difficult to predict when writing an application.
        /// Calling this function from a thread that manages interaction with the user interface
        /// could make the application appear to be unresponsive.
        /// </para>
        /// <para>
        /// Use this function to pass a driver-defined escape value to a device.
        /// </para>
        /// <para>
        /// Use the <see cref="Escape"/> function to pass one of the system-defined escape values to a device,
        /// unless the escape is one of the defined escapes in <paramref name="iEscape"/>.
        /// <see cref="ExtEscape"/> might not work properly with the system-defined escapes.
        /// In particular, escapes in which <paramref name="lpInData"/> is a pointer to a structure
        /// that contains a member that is a pointer will fail.
        /// </para>
        /// <para>
        /// Note, that the behavior described in this article is the expected behavior,
        /// but it is up to the driver to comply with this model.
        /// </para>
        /// <para>
        /// The variables referenced by <paramref name="lpInData"/> and <paramref name="lpOutData"/> should not be the same or overlap.
        /// If the input and the output buffer size variables overlap, they may not contain the correct values after the call returns.
        /// For the best results, <paramref name="lpInData"/> and <paramref name="lpOutData"/> should refer to different variables.
        /// </para>
        /// <para>
        /// The <see cref="CHECKJPEGFORMAT"/> printer escape function determines whether a printer supports printing a JPEG image.
        /// </para>
        /// <para>
        /// Before using the <see cref="CHECKJPEGFORMAT"/> printer escape function,
        /// call the <see cref="QUERYESCSUPPORT"/> printer escape function
        /// to determine whether the driver supports <see cref="CHECKJPEGFORMAT"/>.
        /// For sample code that demonstrates the use of <see cref="CHECKJPEGFORMAT"/>,
        /// see Testing a Printer for JPEG or PNG Support.
        /// </para>
        /// <para>
        /// The <see cref="CHECKPNGFORMAT"/> printer escape function determines whether a printer supports printing a PNG image.
        /// </para>
        /// <para>
        /// Before using the <see cref="CHECKJPEGFORMAT"/> printer escape function,
        /// call the <see cref="QUERYESCSUPPORT"/> printer escape function
        /// to determine whether the driver supports <see cref="CHECKJPEGFORMAT"/>.
        /// For sample code, see Testing a Printer for JPEG or PNG Support.
        /// </para>
        /// <para>
        /// The <see cref="DRAWPATTERNRECT"/> printer escape creates a white, gray scale, or solid black rectangle
        /// by using the pattern and rule capabilities of Page Control Language (PCL)
        /// on Hewlett-Packard LaserJet or LaserJet-compatible printers.
        /// A gray scale is a gray pattern that contains a specific mixture of black and white pixels.
        /// </para>
        /// <para>
        /// An application should use the <see cref="QUERYESCSUPPORT"/> escape
        /// to determine whether the printer is capable of drawing patterns and rules
        /// before using the <see cref="DRAWPATTERNRECT"/> escape.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Rules drawn with <see cref="DRAWPATTERNRECT"/> are not subject to clipping regions in the device context.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Applications should not try to erase patterns and rules created with <see cref="DRAWPATTERNRECT"/> by placing opaque objects over them.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the printer supports white rules, these can be used to erase patterns created by <see cref="DRAWPATTERNRECT"/>.
        /// If the printer does not support white rules, there is no method for erasing these patterns.
        /// </para>
        /// <para>
        /// If an application cannot use the <see cref="DRAWPATTERNRECT"/> escape and the device is a printer,
        /// it should generally use the <see cref="PatBlt"/> function instead.
        /// Note that if <see cref="PatBlt"/> is used to print a black rectangle,
        /// the application should use the <see cref="BLACKNESS"/> raster operator.
        /// If the device is a plotter, however, the application should use the <see cref="Rectangle"/> function.
        /// </para>
        /// <para>
        /// The <see cref="GET_PS_FEATURESETTING"/> printer escape function retrieves information
        /// about a specified feature setting for a PostScript driver.
        /// </para>
        /// <para>
        /// This escape function is supported only if the PostScript driver is in PostScript-centric mode or in GDI-centric mode.
        /// To set the PostScript driver mode, call the <see cref="POSTSCRIPT_IDENTIFY"/> escape function.
        /// </para>
        /// <para>
        /// To perform this operation, call the <see cref="ExtEscape"/> function with the following parameters.
        /// </para>
        /// <para>
        /// The <see cref="GET_PS_FEATURESETTING"/> printer escape function is valid if called any time
        /// after calling the <see cref="CreateDC"/> function and before calling the <see cref="DeleteDC"/> function.
        /// </para>
        /// <para>
        /// The <see cref="GETTECHNOLOGY"/> printer escape function identifies the type of printer driver.
        /// </para>
        /// <para>
        /// For non-XPSDrv printers, this escape reports whether the driver is a Postscript driver.
        /// </para>
        /// <para>
        /// For XPSDrv printers, this escape reports whether the driver is the Microsoft XPS Document Converter (MXDC).
        /// If it is, the escape returns the zero-terminated string "http://schemas.microsoft.com/xps/2005/06"
        /// </para>
        /// <para>
        /// The <see cref="PASSTHROUGH"/> printer escape function sends data directly to a printer driver.
        /// To perform this operation, call the <see cref="ExtEscape"/> function with the following parameters.
        /// </para>
        /// <para>
        /// The <see cref="PASSTHROUGH"/> printer escape function is supported
        /// by PostScript drivers in GDI-centric mode or compatibility mode, but not in PostScript-centric mode.
        /// Drivers in PostScript-centric mode can use the <see cref="POSTSCRIPT_PASSTHROUGH"/> escape function.
        /// To set a PostScript driver mode, call the <see cref="POSTSCRIPT_IDENTIFY"/> escape function.
        /// </para>
        /// <para>
        /// For <see cref="PASSTHROUGH"/> data sent by <see cref="EPSPRINTING"/> or PostScript-centric applications,
        /// the PostScript driver will not make any modifications.
        /// For <see cref="PASSTHROUGH"/> data sent by other applications,
        /// if the PostScript driver is using BCP (Binary Communication Protocol)
        /// or TBCP (Tagged Binary Communication Protocol) output protocol,
        /// the driver does the appropriate BCP or TBCP quoting on special characters,
        /// as described in "Adobe Serial and Parallel Communications Protocols Specification."
        /// This means that the application should send either ASCII or pure binary <see cref="PASSTHROUGH"/> data.
        /// </para>
        /// <para>
        /// The <see cref="POSTSCRIPT_DATA"/> printer escape function sends data directly to a printer driver.
        /// To perform this operation, call the <see cref="ExtEscape"/> function with the following parameters.
        /// </para>
        /// <para>
        /// The <see cref="POSTSCRIPT_DATA"/> function is identical to the <see cref="PASSTHROUGH"/> escape function
        /// except that it is supported by PostScript drivers in compatibility mode only.
        /// It is not supported by PostScript drivers in PostScript-centric mode or in GDI-centric mode.
        /// </para>
        /// <para>
        /// Drivers in PostScript-centric mode can use the <see cref="POSTSCRIPT_PASSTHROUGH"/> escape function,
        /// and drivers in GDI-centric mode can use the <see cref="PASSTHROUGH"/> escape function.
        /// To set a PostScript driver's mode, call the <see cref="POSTSCRIPT_IDENTIFY"/> escape function.
        /// </para>
        /// <para>
        /// The <see cref="POSTSCRIPT_IDENTIFY"/> printer escape function sets a PostScript driver to GDI-centric mode or PostScript-centric mode.
        /// </para>
        /// <para>
        /// To put the driver in GDI-centric or PostScript-centric modes,
        /// first call the <see cref="QUERYESCSUPPORT"/> printer escape function to determine
        /// whether the driver supports the <see cref="POSTSCRIPT_IDENTIFY"/> printer escape function.
        /// If so, you can assume the driver is PSCRIPT 5.0.
        /// Then, before you call any other printer escape function,
        /// you must call <see cref="POSTSCRIPT_IDENTIFY"/> and specify either <see cref="PSIDENT_GDICENTRIC"/> or <see cref="PSIDENT_PSCENTRIC"/>.
        /// You must call the <see cref="QUERYESCSUPPORT"/> and <see cref="POSTSCRIPT_IDENTIFY"/> printer escape functions
        /// before calling any other printer escape function.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// After the PostScript driver is set to GDI-centric mode or PostScript-centric mode,
        /// you will not be allowed to call the <see cref="POSTSCRIPT_IDENTIFY"/> printer escape function anymore.
        /// If you do not use the <see cref="POSTSCRIPT_IDENTIFY"/> printer escape function,
        /// the PostScript driver is in compatibility mode and provides identical support for the <see cref="PASSTHROUGH"/>,
        /// <see cref="POSTSCRIPT_PASSTHROUGH"/>, and <see cref="POSTSCRIPT_DATA"/> printer escape functions.
        /// </para>
        /// <para>
        /// For PostScript drivers that support the <see cref="POSTSCRIPT_PASSTHROUGH"/>,
        /// <see cref="PASSTHROUGH"/>, and <see cref="POSTSCRIPT_PASSTHROUGH"/> printer escape functions are identical.
        /// </para>
        /// <para>
        /// In PostScript-centric mode, the application is responsible for all PostScript output
        /// that marks the paper using the <see cref="POSTSCRIPT_PASSTHROUGH"/> escape function.
        /// GDI functions are not allowed.
        /// The driver is responsible for the overall document structure and printer control settings.
        /// The application can use the <see cref="POSTSCRIPT_INJECTION"/> printer escape function
        /// to inject a block of raw data (including DSC comments) into the job stream at specific places.
        /// </para>
        /// <para>
        /// The <see cref="POSTSCRIPT_INJECTION"/> printer escape function
        /// inserts a block of raw data at a specified point in a PostScript job stream.
        /// </para>
        /// <para>
        /// A PostScript driver supports this escape function in GDI-centric mode or PostScript-centric mode support, but not in compatibility mode.
        /// </para>
        /// <para>
        /// To set the PostScript driver's mode, call the <see cref="POSTSCRIPT_IDENTIFY"/> escape function.
        /// </para>
        /// <para>
        /// To perform this operation, call the <see cref="ExtEscape"/> function with the following parameters.
        /// </para>
        /// <para>
        /// The driver internally caches the injection data and emits it at appropriate points in the output.
        /// The cached information is flushed when it is no longer needed.
        /// At the latest, it is flushed after the <see cref="EndDoc"/> call.
        /// </para>
        /// <para>
        /// In GDI-centric mode, the application can only inject valid DSC block data
        /// by using the <see cref="POSTSCRIPT_INJECTION"/> printer escape function.
        /// A valid DSC block must satisfy all of the following conditions:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// It consists of an integral sequence of "lines."
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Each "line" must begin with "%%".
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Each "line" except the last line must end with &lt;CR&gt;, &lt;LF&gt;, or &lt;CR&gt;&lt;LF&gt; except for the last line.
        /// If the last line does not end with &lt;CR&gt;, &lt;LF&gt;, or &lt;CR&gt;&lt;LF&gt;,
        /// the driver appends &lt;CR&gt;&lt;LF&gt; after the last byte of the injection data.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Each "line" must be 255 bytes or less including the "%%" but not counting the &lt;CR&gt;/&lt;LF&gt; line termination.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <see cref="POSTSCRIPT_PASSTHROUGH"/> printer escape function sends data directly to a PostScript printer driver.
        /// </para>
        /// <para>
        /// A PostScript driver supports this escape function when in PostScript-centric mode or in compatibility mode, but not in GDI-centric mode.
        /// </para>
        /// <para>
        /// To set the PostScript driver's mode, call the <see cref="POSTSCRIPT_IDENTIFY"/> escape function.
        /// </para>
        /// <para>
        /// The <see cref="QUERYESCSUPPORT"/> printer escape function checks the implementation of a printer escape function.
        /// </para>
        /// <para>
        /// The <see cref="SPCLPASSTHROUGH2"/> printer escape function allows applications
        /// that print to PostScript devices using <see cref="EPSPRINTING"/> to include private PostScript procedures
        /// and other resources at the document-level save context.
        /// </para>
        /// <para>
        /// This escape is supported only for backward compatibility with Adobe Acrobat.
        /// Other applications should not use this obsolete escape.
        /// </para>
        /// <para>
        /// The application must call this escape before calling <see cref="StartDoc"/>
        /// so that the driver will cache the data for insertion at the correct point in the PostScript stream.
        /// If this escape is supported, the driver will also allow escape <see cref="DOWNLOADFACE"/> calls prior to <see cref="StartDoc"/>.
        /// The driver internally caches the data to be inserted and the data required by any escape <see cref="DOWNLOADFACE"/> calls
        /// prior to <see cref="StartDoc"/> and emits them all immediately before %%EndProlog.
        /// The sequence of <see cref="SPCLPASSTHROUGH2"/> and <see cref="DOWNLOADFACE"/> calls
        /// will be preserved in the order their data is passed in, that is, a later call results in data output after an earlier call's data.
        /// The driver will consider fonts downloaded by pre-<see cref="StartDoc"/> escape <see cref="DOWNLOADFACE"/> calls as unavailable for removal during the scope of the job.
        /// </para>
        /// <para>
        /// This escape is not recorded in EMF files by the operating system,
        /// therefore applications must ensure that EMF recording is turned off for those jobs using the escape.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtEscape", ExactSpelling = true, SetLastError = true)]
        public static extern int ExtEscape([In] HDC hdc, [In] EscapeFunctions iEscape, [In] int cjInput, [In] LPCSTR lpInData,
            [In] int cjOutput, [In] LPSTR lpOutData);

        /// <summary>
        /// <para>
        /// The <see cref="GdiFlush"/> function flushes the calling thread's current batch.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdiflush"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If all functions in the current batch succeed, the return value is nonzero.
        /// </para>
        /// <para>
        /// If not all functions in the current batch succeed, the return value is zero,
        /// indicating that at least one function returned an error.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Batching enhances drawing performance by minimizing the amount of time
        /// needed to call GDI drawing functions that return Boolean values.
        /// The system accumulates the parameters for calls to these functions in the current batch
        /// and then calls the functions when the batch is flushed by any of the following means:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Calling the <see cref="GdiFlush"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Reaching or exceeding the batch limit set by the <see cref="GdiSetBatchLimit"/> function.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Filling the batching buffers.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Calling any GDI function that does not return a Boolean value.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The return value for <see cref="GdiFlush"/> applies only to the functions
        /// in the batch at the time <see cref="GdiFlush"/> is called.
        /// Errors that occur when the batch is flushed by any other means are never reported.
        /// </para>
        /// <para>
        /// The <see cref="GdiGetBatchLimit"/> function returns the batch limit.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The batch limit is maintained for each thread separately.
        /// In order to completely disable batching, call <see cref="GdiSetBatchLimit"/> (1)
        /// during the initialization of each thread.
        /// </para>
        /// <para>
        /// An application should call <see cref="GdiFlush"/> before a thread goes away
        /// if there is a possibility that there are pending function calls in the graphics batch queue.
        /// The system does not execute such batched functions when a thread goes away.
        /// </para>
        /// <para>
        /// A multithreaded application that serializes access to GDI objects with a mutex
        /// must ensure flushing the GDI batch queue by calling <see cref="GdiFlush"/>
        /// as each thread releases ownership of the GDI object.
        /// This prevents collisions of the GDI objects (device contexts, metafiles, and so on).
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiFlush", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiFlush();

        /// <summary>
        /// <para>
        /// The <see cref="GdiGetBatchLimit"/> function returns the maximum number of function
        /// calls that can be accumulated in the calling thread's current batch.
        /// The system flushes the current batch whenever this limit is exceeded.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdigetbatchlimit"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the batch limit.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The batch limit is set by using the <see cref="GdiSetBatchLimit"/> function.
        /// Setting the limit to 1 effectively disables batching.
        /// </para>
        /// <para>
        /// Only GDI drawing functions that return Boolean values can be batched;
        /// calls to any other GDI functions immediately flush the current batch.
        /// Exceeding the batch limit or calling the <see cref="GdiFlush"/> function also flushes the current batch.
        /// </para>
        /// <para>
        /// When the system batches a function call, the function returns <see cref="TRUE"/>.
        /// The actual return value for the function is reported only if <see cref="GdiFlush"/> is used to flush the batch.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The batch limit is maintained for each thread separately.
        /// In order to completely disable batching, call <see cref="GdiSetBatchLimit"/> (1) during the initialization of each thread.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiGetBatchLimit", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GdiGetBatchLimit();

        /// <summary>
        /// <para>
        /// The <see cref="GdiSetBatchLimit"/> function sets the maximum number of function calls
        /// that can be accumulated in the calling thread's current batch.
        /// The system flushes the current batch whenever this limit is exceeded.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdisetbatchlimit"/>
        /// </para>
        /// </summary>
        /// <param name="dw">
        /// Specifies the batch limit to be set.
        /// A value of 0 sets the default limit.
        /// A value of 1 disables batching.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the previous batch limit.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Only GDI drawing functions that return Boolean values can be accumulated in the current batch;
        /// calls to any other GDI functions immediately flush the current batch.
        /// Exceeding the batch limit or calling the <see cref="GdiFlush"/> function also flushes the current batch.
        /// </para>
        /// <para>
        /// When the system accumulates a function call,
        /// the function returns <see cref="TRUE"/> to indicate it is in the batch.
        /// When the system flushes the current batch and executes the function for the second time,
        /// the return value is either <see cref="TRUE"/> or <see cref="FALSE"/>, depending on whether the function succeeds.
        /// This second return value is reported only if <see cref="GdiFlush"/> is used to flush the batch.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The batch limit is maintained for each thread separately.
        /// In order to completely disable batching, call <see cref="GdiSetBatchLimit"/> (1) during the initialization of each thread.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiSetBatchLimit", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GdiSetBatchLimit([In] DWORD dw);

        /// <summary>
        /// <para>
        /// The <see cref="GetBValue"/> macro retrieves an intensity value for the blue component of a red, green, blue (RGB) value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getrvalue"/>
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
        /// The <see cref="GetGValue"/> macro retrieves an intensity value for the green component of a red, green, blue (RGB) value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getrvalue"/>
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
        /// The <see cref="GetNearestColor"/> function retrieves a color value identifying a color from the system palette
        /// that will be displayed when the specified color value is used.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getnearestcolor"/>
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
        /// <para>
        /// If the function succeeds, the return value identifies a color from the system palette
        /// that corresponds to the given color value.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNearestColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF GetNearestColor([In] HDC hdc, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="GetObject"/> function retrieves information for the specified graphics object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getobjectw"/>
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
        /// <para>
        /// A pointer to a buffer that receives the information about the specified graphics object.
        /// </para>
        /// <para>
        /// The following table shows the type of information the buffer receives for each type of graphics object
        /// you can specify with <paramref name="h"/>.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Object type
        /// </term>
        /// <term>
        /// Data written to buffer
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="HBITMAP"/>
        /// </term>
        /// <term>
        /// <see cref="BITMAP"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HBITMAP"/> returned from a call to <see cref="CreateDIBSection"/>
        /// </term>
        /// <term>
        /// <see cref="DIBSECTION"/>, if <paramref name="c"/> is set to <c>sizeof (DIBSECTION)</c>,
        /// or <see cref="BITMAP"/>, if <paramref name="c"/> is set to <c>sizeof (BITMAP)</c>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HPALETTE"/>
        /// </term>
        /// <term>
        /// A <see cref="WORD"/> count of the number of entries in the logical palette
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HPEN"/> returned from a call to <see cref="ExtCreatePen"/>
        /// </term>
        /// <term>
        /// <see cref="EXTLOGPEN"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HPEN"/>
        /// </term>
        /// <term>
        /// <see cref="LOGPEN"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HBRUSH"/>
        /// </term>
        /// <term>
        /// <see cref="LOGBRUSH"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HFONT"/>
        /// </term>
        /// <term>
        /// <see cref="LOGFONT"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the <paramref name="pv"/> parameter is <see cref="NULL"/>,
        /// the function return value is the number of bytes required to store the information
        /// it writes to the buffer for the specified graphics object.
        /// </para>
        /// <para>
        /// The address of <paramref name="pv"/> must be on a 4-byte boundary; otherwise, <see cref="GetObject"/> fails.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, and <paramref name="pv"/> is a valid pointer,
        /// the return value is the number of bytes stored into the buffer.
        /// </para>
        /// <para>
        /// If the function succeeds, and <paramref name="pv"/> is <see cref="NULL"/>,
        /// the return value is the number of bytes required to hold the information the function would store into the buffer.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The buffer pointed to by the <paramref name="pv"/> parameter must be sufficiently large
        /// to receive the information about the graphics object.
        /// Depending on the graphics object, the function uses a <see cref="BITMAP"/>, <see cref="DIBSECTION"/>,
        /// <see cref="EXTLOGPEN"/>, <see cref="LOGBRUSH"/>, <see cref="LOGFONT"/>,
        /// or <see cref="LOGPEN"/> structure, or a count of table entries (for a logical palette).
        /// </para>
        /// <para>
        /// If <paramref name="h"/> is a handle to a bitmap created by calling <see cref="CreateDIBSection"/>,
        /// and the specified buffer is large enough, the <see cref="GetObject"/> function returns a <see cref="DIBSECTION"/> structure.
        /// In addition, the <see cref="BITMAP.bmBits"/> member of the <see cref="BITMAP"/> structure
        /// contained within the <see cref="DIBSECTION"/> will contain a pointer to the bitmap's bit values.
        /// </para>
        /// <para>
        /// If <paramref name="h"/> is a handle to a bitmap created by any other means,
        /// <see cref="GetObject"/> returns only the width, height, and color format information of the bitmap.
        /// You can obtain the bitmap's bit values by calling the <see cref="GetDIBits"/> or <see cref="GetBitmapBits"/> function.
        /// </para>
        /// <para>
        /// If <paramref name="h"/> is a handle to a logical palette, <see cref="GetObject"/> retrieves a 2-byte integer
        /// that specifies the number of entries in the palette.
        /// The function does not retrieve the <see cref="LOGPALETTE"/> structure defining the palette.
        /// To retrieve information about palette entries, an application can call the <see cref="GetPaletteEntries"/> function.
        /// </para>
        /// <para>
        /// If <paramref name="h"/> is a handle to a font, the <see cref="LOGFONT"/> that is returned
        /// is the <see cref="LOGFONT"/> used to create the font.
        /// If Windows had to make some interpolation of the font because the precise <see cref="LOGFONT"/> could not be represented,
        /// the interpolation will not be reflected in the <see cref="LOGFONT"/>.
        /// For example, if you ask for a vertical version of a font that doesn't support vertical painting,
        /// the <see cref="LOGFONT"/> indicates the font is vertical, but Windows will paint it horizontally.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetObjectW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetObject([In] HANDLE h, [In] int c, [In] LPVOID pv);

        /// <summary>
        /// <para>
        /// The <see cref="GetRValue"/> macro retrieves an intensity value for the red component of a red, green, blue (RGB) value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getrvalue"/>
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
        /// The <see cref="GetStockObject"/> function retrieves a handle to one of the stock pens, brushes, fonts, or palettes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getstockobject"/>
        /// </para>
        /// </summary>
        /// <param name="i">
        /// <para>
        /// The type of stock object. This parameter can be one of the following values.
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
        /// <see cref="BLACK_BRUSH"/>
        /// </term>
        /// <term>
        /// Black brush.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DKGRAY_BRUSH"/>
        /// </term>
        /// <term>
        /// Dark gray brush.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DC_BRUSH"/>
        /// </term>
        /// <term>
        /// Solid color brush. The default color is white.
        /// The color can be changed by using the <see cref="SetDCBrushColor"/> function.
        /// For more information, see the Remarks section.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GRAY_BRUSH"/>
        /// </term>
        /// <term>
        /// Gray brush.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="HOLLOW_BRUSH"/>
        /// </term>
        /// <term>
        /// Hollow brush (equivalent to <see cref="NULL_BRUSH"/>).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LTGRAY_BRUSH"/>
        /// </term>
        /// <term>
        /// Light gray brush.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NULL_BRUSH"/>
        /// </term>
        /// <term>
        /// Null brush (equivalent to <see cref="HOLLOW_BRUSH"/>).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHITE_BRUSH"/>
        /// </term>
        /// <term>
        /// White brush.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="BLACK_PEN"/>
        /// </term>
        /// <term>
        /// Black pen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DC_PEN"/>
        /// </term>
        /// <term>
        /// Solid pen color. The default color is black.
        /// The color can be changed by using the <see cref="SetDCPenColor"/> function.
        /// For more information, see the Remarks section.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="NULL_PEN"/>
        /// </term>
        /// <term>
        /// Null pen.
        /// The null pen draws nothing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHITE_PEN"/>
        /// </term>
        /// <term>
        /// White pen.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ANSI_FIXED_FONT"/>
        /// </term>
        /// <term>
        /// Windows fixed-pitch (monospace) system font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ANSI_VAR_FONT"/>
        /// </term>
        /// <term>
        /// Windows variable-pitch (proportional space) system font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DEVICE_DEFAULT_FONT"/>
        /// </term>
        /// <term>
        /// Device-dependent font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DEFAULT_GUI_FONT"/>
        /// </term>
        /// <term>
        /// <para>
        /// Default font for user interface objects such as menus and dialog boxes.
        /// It is not recommended that you use <see cref="DEFAULT_GUI_FONT"/> or <see cref="SYSTEM_FONT"/>
        /// to obtain the font used by dialogs and windows; for more information, see the remarks section.
        /// </para>
        /// <para>
        /// The default font is Tahoma.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OEM_FIXED_FONT"/>
        /// </term>
        /// <term>
        /// Original equipment manufacturer (OEM) dependent fixed-pitch (monospace) font.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SYSTEM_FONT"/>
        /// </term>
        /// <term>
        /// <para>
        /// System font.
        /// By default, the system uses the system font to draw menus, dialog box controls, and text.
        /// It is not recommended that you use <see cref="DEFAULT_GUI_FONT"/> or <see cref="SYSTEM_FONT"/>
        /// to obtain the font used by dialogs and windows; for more information, see the remarks section.
        /// </para>
        /// <para>
        /// The default system font is Tahoma.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SYSTEM_FIXED_FONT"/>
        /// </term>
        /// <term>
        /// Fixed-pitch (monospace) system font.
        /// This stock object is provided only for compatibility with 16-bit Windows versions earlier than 3.0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DEFAULT_PALETTE"/>
        /// </term>
        /// <term>
        /// Default palette.
        /// This palette consists of the static colors in the system palette.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the requested logical object.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// It is not recommended that you employ this method to obtain the current font used by dialogs and windows.
        /// Instead, use the <see cref="SystemParametersInfo"/> function
        /// with the <see cref="SPI_GETNONCLIENTMETRICS"/> parameter to retrieve the current font.
        /// <see cref="SystemParametersInfo"/> will take into account the current theme
        /// and provides font information for captions, menus, and message dialogs.
        /// </para>
        /// <para>
        /// Use the <see cref="DKGRAY_BRUSH"/>, <see cref="GRAY_BRUSH"/>, and <see cref="LTGRAY_BRUSH"/> stock objects
        /// only in windows with the <see cref="CS_HREDRAW"/> and <see cref="CS_VREDRAW"/> styles.
        /// Using a gray stock brush in any other style of window can lead to misalignment of brush patterns after a window is moved or sized.
        /// The origins of stock brushes cannot be adjusted.
        /// </para>
        /// <para>
        /// The <see cref="HOLLOW_BRUSH"/> and <see cref="NULL_BRUSH"/> stock objects are equivalent.
        /// </para>
        /// <para>
        /// It is not necessary (but it is not harmful) to delete stock objects by calling <see cref="DeleteObject"/>.
        /// </para>
        /// <para>
        /// Both <see cref="DC_BRUSH"/> and <see cref="DC_PEN"/> can be used interchangeably
        /// with other stock objects like <see cref="BLACK_BRUSH"/> and <see cref="BLACK_PEN"/>.
        /// For information on retrieving the current pen or brush color, see <see cref="GetDCBrushColor"/> and <see cref="GetDCPenColor"/>.
        /// See Setting the Pen or Brush Color for an example of setting colors.
        /// The <see cref="GetStockObject"/> function with an argument of <see cref="DC_BRUSH"/> or <see cref="DC_PEN"/>
        /// can be used interchangeably with the <see cref="SetDCPenColor"/> and <see cref="SetDCBrushColor"/> functions.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetStockObject", ExactSpelling = true, SetLastError = true)]
        public static extern HGDIOBJ GetStockObject([In] StockObjectIndexes i);

        /// <summary>
        /// <para>
        /// The <see cref="LPtoDP"/> function converts logical coordinates into device coordinates.
        /// The conversion depends on the mapping mode of the device context,
        /// the settings of the origins and extents for the window and viewport, and the world transformation.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-lptodp"/>
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
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="LPtoDP"/> function fails if the logical coordinates exceed 32 bits,
        /// or if the converted device coordinates exceed 27 bits.
        /// In the case of such an overflow, the results for all the points are undefined.
        /// </para>
        /// <para>
        /// <see cref="LPtoDP"/> calculates complex floating-point arithmetic, and it has a caching system for efficiency.
        /// Therefore, the conversion result of an initial call to <see cref="LPtoDP"/> might not exactly
        /// match the conversion result of a later call to <see cref="LPtoDP"/>.
        /// We recommend not to write code that relies on the exact match of the conversion results
        /// from multiple calls to <see cref="LPtoDP"/> even if the parameters that are passed to each call are identical.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LPtoDP", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LPtoDP([In] HDC hdc, [In][Out] POINT[] lppt, [In] int c);

        /// <summary>
        /// <para>
        /// The <see cref="PALETTEINDEX"/> macro accepts an index to a logical-color palette entry and returns a palette-entry specifier
        /// consisting of a <see cref="COLORREF"/> value that specifies the color associated with the given index.
        /// An application using a logical palette can pass this specifier, instead of an explicit red, green, blue (RGB) value,
        /// to GDI functions that expect a color.
        /// This allows the function to use the color in the specified palette entry.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-paletteindex"/>
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-palettergb"/>
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
        /// The <see cref="RGB"/> macro selects a red, green, blue (RGB) color based on the arguments supplied and the color capabilities of the output device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-rgb"/>
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
        /// <para>
        /// The intensity for each argument is in the range 0 through 255.
        /// If all three intensities are zero, the result is black.
        /// If all three intensities are 255, the result is white.
        /// </para>
        /// <para>
        /// To extract the individual values for the red, green, and blue components of a <see cref="COLORREF"/> color value,
        /// use the <see cref="GetRValue"/>, <see cref="GetGValue"/>, and <see cref="GetBValue"/> macros, respectively.
        /// </para>
        /// <para>
        /// When creating or examining a logical palette, use the <see cref="RGBQUAD"/> structure
        /// to define color values and examine individual component values.
        /// For more information about using color values in a color palette,
        /// see the descriptions of the <see cref="PALETTEINDEX"/> and <see cref="PALETTERGB"/> macros.
        /// </para>
        /// </remarks>
        public static COLORREF RGB([In] byte r, [In] byte g, [In] byte b) => (COLORREF)(r | g << 8 | b << 16);

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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-unrealizeobject"/>
        /// </para>
        /// </summary>
        /// <param name="h">
        /// A handle to the logical palette to be reset.
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
        /// The <see cref="UnrealizeObject"/> function should not be used with stock objects.
        /// For example, the default palette, obtained by calling <c>GetStockObject(DEFAULT_PALETTE)</c>, is a stock object.
        /// </para>
        /// <para>
        /// A palette identified by <paramref name="h"/> can be the currently selected palette of a device context.
        /// </para>
        /// <para>
        /// If <paramref name="h"/> is a brush, <see cref="UnrealizeObject"/> does nothing, and the function returns <see cref="TRUE"/>.
        /// Use <see cref="SetBrushOrgEx"/> to set the origin of a brush.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnrealizeObject", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnrealizeObject([In] HGDIOBJ h);
    }
}
