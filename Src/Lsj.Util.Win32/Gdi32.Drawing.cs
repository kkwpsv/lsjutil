using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The LineDDAProc function is an application-defined callback function used with the <see cref="LineDDA"/> function.
        /// It is used to process coordinates.
        /// The <see cref="LINEDDAPROC"/> type defines a pointer to this callback function.
        /// LineDDAProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nc-wingdi-lineddaproc
        /// </para>
        /// </summary>
        /// <param name="Arg1"></param>
        /// <param name="Arg2"></param>
        /// <param name="Arg3"></param>
        /// <remarks>
        /// An application registers a LineDDAProc function by passing its address to the <see cref="LineDDA"/> function.
        /// </remarks>
        public delegate void LINEDDAPROC([In]int Arg1, [In]int Arg2, [In]LPARAM Arg3);


        /// <summary>
        /// <para>
        /// The <see cref="Arc"/> function draws an elliptical arc.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-arc
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context where drawing takes place.
        /// </param>
        /// <param name="x1">
        /// The x-coordinate, in logical units, of the upper-left corner of the bounding rectangle.
        /// </param>
        /// <param name="y1">
        /// The y-coordinate, in logical units, of the upper-left corner of the bounding rectangle.
        /// </param>
        /// <param name="x2">
        /// The x-coordinate, in logical units, of the lower-right corner of the bounding rectangle.
        /// </param>
        /// <param name="y2">
        /// The y-coordinate, in logical units, of the lower-right corner of the bounding rectangle.
        /// </param>
        /// <param name="x3">
        /// The x-coordinate, in logical units, of the ending point of the radial line defining the starting point of the arc.
        /// </param>
        /// <param name="y3">
        /// The y-coordinate, in logical units, of the ending point of the radial line defining the starting point of the arc.
        /// </param>
        /// <param name="x4">
        /// The x-coordinate, in logical units, of the ending point of the radial line defining the ending point of the arc.
        /// </param>
        /// <param name="y4">
        /// The y-coordinate, in logical units, of the ending point of the radial line defining the ending point of the arc.
        /// </param>
        /// <returns>
        /// If the arc is drawn, the return value is <see cref="TRUE"/>.
        /// If the arc is not drawn, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The points (nLeftRect, nTopRect) and (nRightRect, nBottomRect) specify the bounding rectangle.
        /// An ellipse formed by the specified bounding rectangle defines the curve of the arc.
        /// The arc extends in the current drawing direction from the point where it intersects the radial
        /// from the center of the bounding rectangle to the (nXStartArc, nYStartArc) point.
        /// The arc ends where it intersects the radial from the center of the bounding rectangle to the (nXEndArc, nYEndArc) point.
        /// If the starting point and ending point are the same, a complete ellipse is drawn.
        /// The arc is drawn using the current pen; it is not filled.
        /// The current position is neither used nor updated by Arc.
        /// Use the <see cref="GetArcDirection"/> and <see cref="SetArcDirection"/> functions to get and set the current drawing direction for a device context.
        /// The default drawing direction is counterclockwise.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Arc", SetLastError = true)]
        public static extern BOOL Arc([In]HDC hdc, [In]int x1, [In]int y1, [In]int x2, [In]int y2, [In]int x3, [In]int y3, [In]int x4, [In]int y4);

        /// <summary>
        /// <para>
        /// The <see cref="Chord"/> function draws a chord (a region bounded by the intersection of an ellipse and a line segment, called a secant).
        /// The chord is outlined by using the current pen and filled by using the current brush.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-chord
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context in which the chord appears.
        /// </param>
        /// <param name="x1">
        /// The x-coordinate, in logical coordinates, of the upper-left corner of the bounding rectangle.
        /// </param>
        /// <param name="y1">
        /// The y-coordinate, in logical coordinates, of the upper-left corner of the bounding rectangle.
        /// </param>
        /// <param name="x2">
        /// The x-coordinate, in logical coordinates, of the lower-right corner of the bounding rectangle.
        /// </param>
        /// <param name="y2">
        /// The y-coordinate, in logical coordinates, of the lower-right corner of the bounding rectangle.
        /// </param>
        /// <param name="x3">
        /// The x-coordinate, in logical coordinates, of the endpoint of the radial defining the beginning of the chord.
        /// </param>
        /// <param name="y3">
        /// The y-coordinate, in logical coordinates, of the endpoint of the radial defining the beginning of the chord.
        /// </param>
        /// <param name="x4">
        /// The x-coordinate, in logical coordinates, of the endpoint of the radial defining the end of the chord.
        /// </param>
        /// <param name="y4">
        /// The y-coordinate, in logical coordinates, of the endpoint of the radial defining the end of the chord.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The curve of the chord is defined by an ellipse that fits the specified bounding rectangle.
        /// The curve begins at the point where the ellipse intersects the first radial and extends counterclockwise to the point
        /// where the ellipse intersects the second radial.
        /// The chord is closed by drawing a line from the intersection of the first radial and the curve to the intersection of the second radial and the curve.
        /// If the starting point and ending point of the curve are the same, a complete ellipse is drawn.
        /// The current position is neither used nor updated by <see cref="Chord"/>.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Chord", SetLastError = true)]
        public static extern BOOL Chord([In]HDC hdc, [In]int x1, [In]int y1, [In]int x2, [In]int y2, [In]int x3, [In]int y3, [In]int x4, [In]int y4);

        /// <summary>
        /// <para>
        /// The <see cref="Ellipse"/> function draws an ellipse.
        /// The center of the ellipse is the center of the specified bounding rectangle.
        /// The ellipse is outlined by using the current pen and is filled by using the current brush.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-ellipse
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="left">
        /// The x-coordinate, in logical coordinates, of the upper-left corner of the bounding rectangle.
        /// </param>
        /// <param name="top">
        /// The y-coordinate, in logical coordinates, of the upper-left corner of the bounding rectangle.
        /// </param>
        /// <param name="right">
        /// The x-coordinate, in logical coordinates, of the lower-right corner of the bounding rectangle.
        /// </param>
        /// <param name="bottom">
        /// The y-coordinate, in logical coordinates, of the lower-right corner of the bounding rectangle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The current position is neither used nor updated by <see cref="Ellipse"/>.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Ellipse", SetLastError = true)]
        public static extern BOOL Ellipse([In]HDC hdc, [In]int left, [In]int top, [In]int right, [In]int bottom);

        /// <summary>
        /// <para>
        /// The <see cref="ExtFloodFill"/> function fills an area of the display surface with the current brush.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-extfloodfill
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the point where filling is to start.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the point where filling is to start.
        /// </param>
        /// <param name="color">
        /// The color of the boundary or of the area to be filled.
        /// The interpretation of <paramref name="color"/> depends on the value of the <paramref name="type"/> parameter.
        /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <param name="type">
        /// The type of fill operation to be performed. This parameter must be one of the following values.
        /// <see cref="FLOODFILLBORDER"/>:
        /// The fill area is bounded by the color specified by the <paramref name="color"/> parameter.
        /// This style is identical to the filling performed by the <see cref="FloodFill"/> function.
        /// <see cref="FLOODFILLSURFACE"/>:
        /// The fill area is defined by the color that is specified by <paramref name="color"/>.
        /// Filling continues outward in all directions as long as the color is encountered.
        /// This style is useful for filling areas with multicolored boundaries.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The following are some of the reasons this function might fail:
        /// The filling could not be completed.
        /// The specified point has the boundary color specified by the <paramref name="color"/> parameter (if <see cref="FLOODFILLBORDER"/> was requested).
        /// The specified point does not have the color specified by <paramref name="color"/> (if <see cref="FLOODFILLSURFACE"/> was requested).
        /// The point is outside the clipping regionthat is, it is not visible on the device.
        /// If the <paramref name="type"/> parameter is <see cref="FLOODFILLBORDER"/>, the system assumes
        /// that the area to be filled is completely bounded by the color specified by the <paramref name="color"/> parameter.
        /// The function begins filling at the point specified by the <paramref name="x"/> and <paramref name="y"/> parameters
        /// and continues in all directions until it reaches the boundary.
        /// If <paramref name="type"/> is <see cref="FLOODFILLSURFACE"/>, the system assumes that the area to be filled is a single color.
        /// The function begins to fill the area at the point specified by <paramref name="x"/> and <paramref name="y"/> and continues in all directions,
        /// filling all adjacent regions containing the color specified by <paramref name="color"/>.
        /// Only memory device contexts and devices that support raster-display operations support the <see cref="ExtFloodFill"/> function.
        /// To determine whether a device supports this technology, use the <see cref="GetDeviceCaps"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtFloodFill", SetLastError = true)]
        public static extern BOOL ExtFloodFill([In]HDC hdc, [In]int x, [In]int y, [In]COLORREF color, [In]UINT type);

        /// <summary>
        /// <para>
        /// The <see cref="FillRect"/> function fills a rectangle by using the specified brush.
        /// This function includes the left and top borders, but excludes the right and bottom borders of the rectangle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-fillrect
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// A handle to the device context.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the rectangle to be filled.
        /// </param>
        /// <param name="hbr">
        /// A handle to the brush used to fill the rectangle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The brush identified by the hbr parameter may be either a handle to a logical brush or a color value.
        /// If specifying a handle to a logical brush, call one of the following functions to obtain the handle:
        /// <see cref="CreateHatchBrush"/>, <see cref="CreatePatternBrush"/>, or <see cref="CreateSolidBrush"/>.
        /// Additionally, you may retrieve a handle to one of the stock brushes by using the <see cref="GetStockObject"/> function.
        /// If specifying a color value for the <paramref name="hbr"/> parameter, it must be one of the standard system colors
        /// (the value 1 must be added to the chosen color).
        /// For example:
        /// <code>FillRect(hdc, &amp;rect, (HBRUSH) (COLOR_WINDOW+1));</code>
        /// For a list of all the standard system colors, see GetSysColor.
        /// When filling the specified rectangle, <see cref="FillRect"/> does not include the rectangle's right and bottom sides.
        /// GDI fills a rectangle up to, but not including, the right column and bottom row, regardless of the current mapping mode.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "FillRect", SetLastError = true)]
        public static extern int FillRect([In]HDC hDC, [In][Out]ref RECT lprc, [In]HBRUSH hbr);

        /// <summary>
        /// <para>
        /// The <see cref="FillRgn"/> function fills a region by using the specified brush.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-fillrgn
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// Handle to the region to be filled.
        /// The region's coordinates are presumed to be in logical units.
        /// </param>
        /// <param name="hbr">
        /// Handle to the brush to be used to fill the region.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "FillRgn", SetLastError = true)]
        public static extern BOOL FillRgn([In]HDC hdc, [In]HRGN hrgn, [In]HBRUSH hbr);

        /// <summary>
        /// <para>
        /// The <see cref="FloodFill"/> function fills an area of the display surface with the current brush.
        /// The area is assumed to be bounded as specified by the <paramref name="color"/> parameter.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-floodfill
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the point where filling is to start.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the point where filling is to start.
        /// </param>
        /// <param name="color">
        /// The color of the boundary or the area to be filled.
        /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The following are reasons this function might fail:
        /// The fill could not be completed.
        /// The given point has the boundary color specified by the <paramref name="color"/> parameter.
        /// The given point lies outside the current clipping regionthat is, it is not visible on the device.
        /// </remarks>
        [Obsolete("The FloodFill function is included only for compatibility with 16-bit versions of Windows." +
            "Applications should use the ExtFloodFill function with FLOODFILLBORDER specified.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "FloodFill", SetLastError = true)]
        public static extern BOOL FloodFill([In]HDC hdc, [In]int x, [In]int y, [In]COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="FrameRect"/> function draws a border around the specified rectangle by using the specified brush.
        /// The width and height of the border are always one logical unit.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-framerect
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// A handle to the device context in which the border is drawn.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the upper-left and lower-right corners of the rectangle.
        /// </param>
        /// <param name="hbr">
        /// A handle to the brush used to draw the border.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The brush identified by the hbr parameter must have been created by using the <see cref="CreateHatchBrush"/>, <see cref="CreatePatternBrush"/>,
        /// or <see cref="CreateSolidBrush"/> function, or retrieved by using the <see cref="GetStockObject"/> function.
        /// If the <see cref="bottom"/> member of the <see cref="RECT"/> structure is less than the top member,
        /// or if the right member is less than the left member, the function does not draw the rectangle.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "FrameRect", SetLastError = true)]
        public static extern int FrameRect([In]HDC hDC, [In][Out]ref RECT lprc, [In]HBRUSH hbr);

        /// <summary>
        /// <para>
        /// The <see cref="FrameRgn"/> function draws a border around the specified region by using the specified brush.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-framergn
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// Handle to the region to be enclosed in a border.
        /// The region's coordinates are presumed to be in logical units.
        /// </param>
        /// <param name="hbr">
        /// Handle to the brush to be used to draw the border.
        /// </param>
        /// <param name="w">
        /// Specifies the width, in logical units, of vertical brush strokes.
        /// </param>
        /// <param name="h">
        /// Specifies the height, in logical units, of horizontal brush strokes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "FrameRgn", SetLastError = true)]
        public static extern BOOL FrameRgn([In]HDC hdc, [In]HRGN hrgn, [In]HBRUSH hbr, [In]int w, [In]int h);

        /// <summary>
        /// <para>
        /// The <see cref="GetCurrentPositionEx"/> function retrieves the current position in logical coordinates.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getcurrentpositionex
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lppt">
        /// A pointer to a <see cref="POINT"/> structure that receives the logical coordinates of the current position.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "MoveToEx", SetLastError = true)]
        public static extern BOOL GetCurrentPositionEx([In]HDC hdc, [Out]out POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="GetPolyFillMode"/> function retrieves the current polygon fill mode.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getpolyfillmode
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the polygon fill mode, which can be one of the following values.
        /// <see cref="ALTERNATE"/>: Selects alternate mode (fills area between odd-numbered and even-numbered polygon sides on each scan line).
        /// <see cref="WINDING"/>: Selects winding mode (fills any region with a nonzero winding value).
        /// If an error occurs, the return value is zero.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPolyFillMode", SetLastError = true)]
        public static extern int GetPolyFillMode([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="InvertRect"/> function inverts a rectangle in a window by performing a logical NOT operation on the color values
        /// for each pixel in the rectangle's interior.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-invertrect
        /// </para>
        /// </summary>
        /// <param name="hDC">
        /// A handle to the device context.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the rectangle to be inverted.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// On monochrome screens, <see cref="InvertRect"/> makes white pixels black and black pixels white.
        /// On color screens, the inversion depends on how colors are generated for the screen.
        /// Calling <see cref="InvertRect"/> twice for the same rectangle restores the display to its previous colors.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "InvertRect", SetLastError = true)]
        public static extern BOOL InvertRect([In]HDC hDC, [MarshalAs(UnmanagedType.LPStruct)][In]RECT lprc);

        /// <summary>
        /// <para>
        /// The <see cref="InvertRgn"/> function inverts the colors in the specified region.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-invertrgn
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// Handle to the region for which colors are inverted.
        /// The region's coordinates are presumed to be logical coordinates.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// On monochrome screens, the <see cref="InvertRgn"/> function makes white pixels black and black pixels white.
        /// On color screens, this inversion is dependent on the type of technology used to generate the colors for the screen.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "InvertRgn", SetLastError = true)]
        public static extern BOOL InvertRgn([In]HDC hdc, [In]HRGN hrgn);

        /// <summary>
        /// <para>
        /// The <see cref="LineDDA"/> function determines which pixels should be highlighted for a line defined by the specified starting and ending points.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-linedda
        /// </para>
        /// </summary>
        /// <param name="xStart">
        /// Specifies the x-coordinate, in logical units, of the line's starting point.
        /// </param>
        /// <param name="yStart">
        /// Specifies the y-coordinate, in logical units, of the line's starting point.
        /// </param>
        /// <param name="xEnd">
        /// Specifies the x-coordinate, in logical units, of the line's ending point.
        /// </param>
        /// <param name="yEnd">
        /// Specifies the y-coordinate, in logical units, of the line's ending point.
        /// </param>
        /// <param name="lpProc">
        /// Pointer to an application-defined callback function.
        /// For more information, see the <see cref="LINEDDAPROC"/> callback function.
        /// </param>
        /// <param name="data">
        /// Pointer to the application-defined data.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="LineDDA"/> function passes the coordinates for each point along the line, except for the line's ending point,
        /// to the application-defined callback function.
        /// In addition to passing the coordinates of a point, this function passes any existing application-defined data.
        /// The coordinates passed to the callback function match pixels on a video display only if the default transformations and mapping modes are used.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LineDDA", SetLastError = true)]
        public static extern BOOL LineDDA([In]int xStart, [In]int yStart, [In]int xEnd, [In]int yEnd, [In]LINEDDAPROC lpProc, [In]LPARAM data);

        /// <summary>
        /// <para>
        /// The <see cref="LineTo"/> function draws a line from the current position up to, but not including, the specified point.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-lineto
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a device context.
        /// </param>
        /// <param name="x">
        /// Specifies the x-coordinate, in logical units, of the line's ending point.
        /// </param>
        /// <param name="y">
        /// Specifies the y-coordinate, in logical units, of the line's ending point.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The line is drawn by using the current pen and, if the pen is a geometric pen, the current brush.
        /// If <see cref="LineTo"/> succeeds, the current position is set to the specified ending point.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LineTo", SetLastError = true)]
        public static extern BOOL LineTo([In]HDC hdc, [In]int x, [In]int y);

        /// <summary>
        /// <para>
        /// The <see cref="MoveToEx"/> function updates the current position to the specified point and optionally returns the previous position.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-movetoex
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a device context.
        /// </param>
        /// <param name="x">
        /// Specifies the x-coordinate, in logical units, of the new position, in logical units.
        /// </param>
        /// <param name="y">
        /// Specifies the y-coordinate, in logical units, of the new position, in logical units.
        /// </param>
        /// <param name="lppt">
        /// Pointer to a <see cref="POINT"/> structure that receives the previous current position.
        /// If this parameter is a <see cref="NULL"/> pointer, the previous position is not returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="MoveToEx"/> function affects all drawing functions.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "MoveToEx", SetLastError = true)]
        public static extern BOOL MoveToEx([In]HDC hdc, [In]int x, [In]int y, [In][Out]ref POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="PaintRgn"/> function paints the specified region by using the brush currently selected into the device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-paintrgn
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// Handle to the region to be filled.
        /// The region's coordinates are presumed to be logical coordinates.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PaintRgn", SetLastError = true)]
        public static extern BOOL PaintRgn([In]HDC hdc, [In]HRGN hrgn);

        /// <summary>
        /// <para>
        /// The <see cref="Pie"/> function draws a pie-shaped wedge bounded by the intersection of an ellipse and two radials.
        /// The pie is outlined by using the current pen and filled by using the current brush.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-pie
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="left">
        /// The x-coordinate, in logical coordinates, of the upper-left corner of the bounding rectangle.
        /// </param>
        /// <param name="top">
        /// The y-coordinate, in logical coordinates, of the upper-left corner of the bounding rectangle.
        /// </param>
        /// <param name="right">
        /// The x-coordinate, in logical coordinates, of the lower-right corner of the bounding rectangle.
        /// </param>
        /// <param name="bottom">
        /// The y-coordinate, in logical coordinates, of the lower-right corner of the bounding rectangle.
        /// </param>
        /// <param name="xr1">
        /// The x-coordinate, in logical coordinates, of the endpoint of the first radial.
        /// </param>
        /// <param name="yr1">
        /// The y-coordinate, in logical coordinates, of the endpoint of the first radial.
        /// </param>
        /// <param name="xr2">
        /// The x-coordinate, in logical coordinates, of the endpoint of the second radial.
        /// </param>
        /// <param name="yr2">
        /// The y-coordinate, in logical coordinates, of the endpoint of the second radial.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The curve of the pie is defined by an ellipse that fits the specified bounding rectangle.
        /// The curve begins at the point where the ellipse intersects the first radial and extends counterclockwise to the point
        /// where the ellipse intersects the second radial.
        /// The current position is neither used nor updated by the <see cref="Pie"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Pie", SetLastError = true)]
        public static extern BOOL Pie([In]HDC hdc, [In]int left, [In]int top, [In]int right, [In]int bottom, [In]int xr1, [In]int yr1, [In]int xr2, [In]int yr2);

        /// <summary>
        /// <para>
        /// The <see cref="Polygon"/> function draws a polygon consisting of two or more vertices connected by straight lines.
        /// The polygon is outlined by using the current pen and filled by using the current brush and polygon fill mode.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-polygon
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="apt">
        /// A pointer to an array of <see cref="POINT"/> structures that specify the vertices of the polygon, in logical coordinates.
        /// </param>
        /// <param name="cpt">
        /// The number of vertices in the array.
        /// This value must be greater than or equal to 2.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The polygon is closed automatically by drawing a line from the last vertex to the first.
        /// The current position is neither used nor updated by the <see cref="Polygon"/> function.
        /// Any extra points are ignored. To draw a line with more points, divide your data into groups,
        /// each of which have less than the maximum number of points, and call the function for each group of points.
        /// Remember to connect the line segments.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Polygon", SetLastError = true)]
        public static extern BOOL Polygon([In]HDC hdc, [MarshalAs(UnmanagedType.LPArray)][In]POINT[] apt, [In]int cpt);

        /// <summary>
        /// <para>
        /// The <see cref="Polyline"/> function draws a series of line segments by connecting the points in the specified array.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-polyline
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="apt">
        /// A pointer to an array of <see cref="POINT"/> structures, in logical units.
        /// </param>
        /// <param name="cpt">
        /// The number of points in the array.
        /// This number must be greater than or equal to two.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The lines are drawn from the first point through subsequent points by using the current pen.
        /// Unlike the <see cref="LineTo"/> or <see cref="PolylineTo"/> functions,
        /// the <see cref="Polyline"/> function neither uses nor updates the current position.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Polyline", SetLastError = true)]
        public static extern BOOL Polyline([In]HDC hdc, [MarshalAs(UnmanagedType.LPArray)][In]POINT[] apt, [In]int cpt);

        /// <summary>
        /// <para>
        /// The <see cref="PolyPolygon"/> function draws a series of closed polygons.
        /// Each polygon is outlined by using the current pen and filled by using the current brush and polygon fill mode.
        /// The polygons drawn by this function can overlap.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-polypolygon
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="apt">
        /// A pointer to an array of <see cref="POINT"/> structures that define the vertices of the polygons, in logical coordinates.
        /// The polygons are specified consecutively.
        /// Each polygon is closed automatically by drawing a line from the last vertex to the first.
        /// Each vertex should be specified once.
        /// </param>
        /// <param name="asz">
        /// A pointer to an array of integers, each of which specifies the number of points in the corresponding polygon.
        /// Each integer must be greater than or equal to 2.
        /// </param>
        /// <param name="csz">
        /// The total number of polygons.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The current position is neither used nor updated by this function.
        /// Any extra points are ignored.
        /// To draw the polygons with more points, divide your data into groups, each of which have less than the maximum number of points,
        /// and call the function for each group of points.
        /// Note, it is best to have a polygon in only one of the groups.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PolyPolygon", SetLastError = true)]
        public static extern BOOL PolyPolygon([In]HDC hdc, [MarshalAs(UnmanagedType.LPArray)][In]POINT[] apt,
            [MarshalAs(UnmanagedType.LPArray)][In]INT[] asz, [In]int csz);

        /// <summary>
        /// <para>
        /// The <see cref="Rectangle"/> function draws a rectangle.
        /// The rectangle is outlined by using the current pen and filled by using the current brush.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-rectangle
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="left">
        /// The x-coordinate, in logical coordinates, of the upper-left corner of the rectangle.
        /// </param>
        /// <param name="top">
        /// The y-coordinate, in logical coordinates, of the upper-left corner of the rectangle.
        /// </param>
        /// <param name="right">
        /// The x-coordinate, in logical coordinates, of the lower-right corner of the rectangle.
        /// </param>
        /// <param name="bottom">
        /// The y-coordinate, in logical coordinates, of the lower-right corner of the rectangle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The current position is neither used nor updated by <see cref="Rectangle"/>.
        /// The rectangle that is drawn excludes the bottom and right edges.
        /// If a <see cref="PS_NULL"/> pen is used, the dimensions of the rectangle are 1 pixel less in height and 1 pixel less in width.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Rectangle", SetLastError = true)]
        public static extern BOOL Rectangle([In]HDC hdc, [In]int left, [In]int top, [In]int right, [In]int bottom);

        /// <summary>
        /// <para>
        /// The <see cref="RoundRect"/> function draws a rectangle with rounded corners.
        /// The rectangle is outlined by using the current pen and filled by using the current brush.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-roundrect
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="left">
        /// The x-coordinate, in logical coordinates, of the upper-left corner of the rectangle.
        /// </param>
        /// <param name="top">
        /// The y-coordinate, in logical coordinates, of the upper-left corner of the rectangle.
        /// </param>
        /// <param name="right">
        /// The x-coordinate, in logical coordinates, of the lower-right corner of the rectangle.
        /// </param>
        /// <param name="bottom">
        /// The y-coordinate, in logical coordinates, of the lower-right corner of the rectangle.
        /// </param>
        /// <param name="width">
        /// The width, in logical coordinates, of the ellipse used to draw the rounded corners.
        /// </param>
        /// <param name="height">
        /// The height, in logical coordinates, of the ellipse used to draw the rounded corners.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The current position is neither used nor updated by this function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RoundRect", SetLastError = true)]
        public static extern BOOL RoundRect([In]HDC hdc, [In]int left, [In]int top, [In]int right, [In]int bottom, [In]int width, [In]int height);

        /// <summary>
        /// <para>
        /// The <see cref="SetPolyFillMode"/> function sets the polygon fill mode for functions that fill polygons.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setpolyfillmode
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="mode">
        /// The new fill mode.
        /// This parameter can be one of the following values.
        /// <see cref="ALTERNATE"/>: Selects alternate mode (fills the area between odd-numbered and even-numbered polygon sides on each scan line).
        /// <see cref="WINDING"/>: Selects winding mode (fills any region with a nonzero winding value).
        /// </param>
        /// <returns>
        /// The return value specifies the previous filling mode.
        /// If an error occurs, the return value is zero.
        /// </returns>
        /// <remarks>
        /// In general, the modes differ only in cases where a complex, overlapping polygon must be filled
        /// (for example, a five-sided polygon that forms a five-pointed star with a pentagon in the center).
        /// In such cases, <see cref="ALTERNATE"/> mode fills every other enclosed region within the polygon (that is, the points of the star),
        /// but <see cref="WINDING"/> mode fills all regions (that is, the points and the pentagon).
        /// When the fill mode is <see cref="ALTERNATE"/>, GDI fills the area between odd-numbered and even-numbered polygon sides on each scan line.
        /// That is, GDI fills the area between the first and second side, between the third and fourth side, and so on.
        /// When the fill mode is <see cref="WINDING"/>, GDI fills any region that has a nonzero winding value.
        /// This value is defined as the number of times a pen used to draw the polygon would go around the region.
        /// The direction of each edge of the polygon is important.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPolyFillMode", SetLastError = true)]
        public static extern int SetPolyFillMode([In]HDC hdc, [In]int mode);
    }
}
