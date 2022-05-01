using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ExtFloodFillFlags;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.Enums.PenStyles;
using static Lsj.Util.Win32.Enums.PolyFillModes;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// AD_COUNTERCLOCKWISE
        /// </summary>
        public const int AD_COUNTERCLOCKWISE = 1;

        /// <summary>
        /// AD_CLOCKWISE
        /// </summary>
        public const int AD_CLOCKWISE = 2;

        /// <summary>
        /// <para>
        /// The LineDDAProc function is an application-defined callback function used with the <see cref="LineDDA"/> function.
        /// It is used to process coordinates.
        /// The <see cref="LINEDDAPROC"/> type defines a pointer to this callback function.
        /// LineDDAProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nc-wingdi-lineddaproc"/>
        /// </para>
        /// </summary>
        /// <param name="Arg1"></param>
        /// <param name="Arg2"></param>
        /// <param name="Arg3"></param>
        /// <remarks>
        /// An application registers a LineDDAProc function by passing its address to the <see cref="LineDDA"/> function.
        /// </remarks>
        public delegate void Lineddaproc([In] int Arg1, [In] int Arg2, [In] LPARAM Arg3);


        /// <summary>
        /// <para>
        /// The <see cref="AngleArc"/> function draws a line segment and an arc.
        /// The line segment is drawn from the current position to the beginning of the arc.
        /// The arc is drawn along the perimeter of a circle with the given radius and center.
        /// The length of the arc is defined by the given start and sweep angles.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-anglearc"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-anglearc
        /// </param>
        /// <param name="x">
        /// Specifies the x-coordinate, in logical units, of the center of the circle.
        /// </param>
        /// <param name="y">
        /// Specifies the y-coordinate, in logical units, of the center of the circle.
        /// </param>
        /// <param name="r">
        /// Specifies the radius, in logical units, of the circle. This value must be positive.
        /// </param>
        /// <param name="StartAngle">
        /// Specifies the start angle, in degrees, relative to the x-axis.
        /// </param>
        /// <param name="SweepAngle">
        /// Specifies the sweep angle, in degrees, relative to the starting angle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="AngleArc"/> function moves the current position to the ending point of the arc.
        /// The arc drawn by this function may appear to be elliptical, depending on the current transformation and mapping mode.
        /// Before drawing the arc, <see cref="AngleArc"/> draws the line segment from the current position to the beginning of the arc.
        /// The arc is drawn by constructing an imaginary circle around the specified center point with the specified radius.
        /// The starting point of the arc is determined by measuring counterclockwise
        /// from the x-axis of the circle by the number of degrees in the start angle.
        /// The ending point is similarly located by measuring counterclockwise
        /// from the starting point by the number of degrees in the sweep angle.
        /// If the sweep angle is greater than 360 degrees, the arc is swept multiple times.
        /// This function draws lines by using the current pen.
        /// The figure is not filled.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AngleArc", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AngleArc([In] HDC hdc, [In] int x, [In] int y, [In] DWORD r, [In] FLOAT StartAngle, [In] FLOAT SweepAngle);

        /// <summary>
        /// <para>
        /// The <see cref="Arc"/> function draws an elliptical arc.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-arc"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Arc", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Arc([In] HDC hdc, [In] int x1, [In] int y1, [In] int x2, [In] int y2, [In] int x3,
            [In] int y3, [In] int x4, [In] int y4);

        /// <summary>
        /// <para>
        /// The <see cref="ArcTo"/> function draws an elliptical arc.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-arcto"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context where drawing takes place.
        /// </param>
        /// <param name="left">
        /// The x-coordinate, in logical units, of the upper-left corner of the bounding rectangle.
        /// </param>
        /// <param name="top">
        /// The y-coordinate, in logical units, of the upper-left corner of the bounding rectangle.
        /// </param>
        /// <param name="right">
        /// The x-coordinate, in logical units, of the lower-right corner of the bounding rectangle.
        /// </param>
        /// <param name="bottom">
        /// The y-coordinate, in logical units, of the lower-right corner of the bounding rectangle.
        /// </param>
        /// <param name="xr1">
        /// The x-coordinate, in logical units, of the endpoint of the radial defining the starting point of the arc.
        /// </param>
        /// <param name="yr1">
        /// The y-coordinate, in logical units, of the endpoint of the radial defining the starting point of the arc.
        /// </param>
        /// <param name="xr2">
        /// The x-coordinate, in logical units, of the endpoint of the radial defining the ending point of the arc.
        /// </param>
        /// <param name="yr2">
        /// The y-coordinate, in logical units, of the endpoint of the radial defining the ending point of the arc.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="ArcTo"/> is similar to the <see cref="Arc"/> function, except that the current position is updated.
        /// The points (nLeftRect, nTopRect) and (nRightRect, nBottomRect) specify the bounding rectangle.
        /// An ellipse formed by the specified bounding rectangle defines the curve of the arc.
        /// The arc extends counterclockwise from the point where it intersects the radial line
        /// from the center of the bounding rectangle to the (nXRadial1, nYRadial1) point.
        /// The arc ends where it intersects the radial line from the center of the bounding rectangle to the (nXRadial2, nYRadial2) point.
        /// If the starting point and ending point are the same, a complete ellipse is drawn.
        /// A line is drawn from the current position to the starting point of the arc.
        /// If no error occurs, the current position is set to the ending point of the arc.
        /// The arc is drawn using the current pen; it is not filled.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ArcTo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ArcTo([In] HDC hdc, [In] int left, [In] int top, [In] int right, [In] int bottom,
            [In] int xr1, [In] int yr1, [In] int xr2, [In] int yr2);

        /// <summary>
        /// <para>
        /// The <see cref="BeginPath"/> function opens a path bracket in the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-beginpath"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// After a path bracket is open, an application can begin calling GDI drawing functions to define the points that lie in the path.
        /// An application can close an open path bracket by calling the <see cref="EndPath"/> function.
        /// When an application calls <see cref="BeginPath"/> for a device context, any previous paths are discarded from that device context.
        /// The following list shows which drawing functions can be used.
        /// <see cref="AngleArc"/>, <see cref="Arc"/>, <see cref="ArcTo"/>, <see cref="Chord"/>, <see cref="CloseFigure"/>,
        /// <see cref="Ellipse"/>, <see cref="ExtTextOut"/>, <see cref="LineTo"/>, <see cref="MoveToEx"/>, <see cref="Pie"/>,
        /// <see cref="PolyBezier"/>, <see cref="PolyBezierTo"/>, <see cref="PolyDraw"/>, <see cref="Polygon"/>,
        /// <see cref="Polyline"/>, <see cref="PolylineTo"/>, <see cref="PolyPolygon"/>, <see cref="PolyPolyline"/>,
        /// <see cref="Rectangle"/>, <see cref="RoundRect"/>, <see cref="TextOut"/>
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "BeginPath", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL BeginPath([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="Chord"/> function draws a chord (a region bounded by the intersection of an ellipse and a line segment, called a secant).
        /// The chord is outlined by using the current pen and filled by using the current brush.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-chord"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Chord", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Chord([In] HDC hdc, [In] int x1, [In] int y1, [In] int x2, [In] int y2,
            [In] int x3, [In] int y3, [In] int x4, [In] int y4);

        /// <summary>
        /// <para>
        /// The <see cref="CloseFigure"/> function closes an open figure in a path.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-closefigure"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context in which the figure will be closed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CloseFigure"/> function closes the figure by drawing a line
        /// from the current position to the first point of the figure
        /// (usually, the point specified by the most recent call to the <see cref="MoveToEx"/> function)
        /// and then connects the lines by using the line join style.
        /// If a figure is closed by using the <see cref="LineTo"/> function instead of <see cref="CloseFigure"/>,
        /// end caps are used to create the corner instead of a join.
        /// The <see cref="CloseFigure"/> function should only be called if there is an open path bracket in the specified device context.
        /// A figure in a path is open unless it is explicitly closed by using this function.
        /// (A figure can be open even if the current point and the starting point of the figure are the same.)
        /// After a call to <see cref="CloseFigure"/>, adding a line or curve to the path starts a new figure.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseFigure", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CloseFigure([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="Ellipse"/> function draws an ellipse.
        /// The center of the ellipse is the center of the specified bounding rectangle.
        /// The ellipse is outlined by using the current pen and is filled by using the current brush.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-ellipse"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Ellipse", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Ellipse([In] HDC hdc, [In] int left, [In] int top, [In] int right, [In] int bottom);

        /// <summary>
        /// <para>
        /// The <see cref="ExtFloodFill"/> function fills an area of the display surface with the current brush.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-extfloodfill"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtFloodFill", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ExtFloodFill([In] HDC hdc, [In] int x, [In] int y, [In] COLORREF color, [In] ExtFloodFillFlags type);

        /// <summary>
        /// <para>
        /// The <see cref="FillPath"/> function closes any open figures in the current 
        /// and fills the path's interior by using the current brush and polygon-filling mode.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-fillpath"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context that contains a valid path.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// After its interior is filled, the path is discarded from the DC identified by the <paramref name="hdc"/> parameter.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "FillPath", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FillPath([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="FillRgn"/> function fills a region by using the specified brush.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-fillrgn"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "FillRgn", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FillRgn([In] HDC hdc, [In] HRGN hrgn, [In] HBRUSH hbr);

        /// <summary>
        /// <para>
        /// The <see cref="FlattenPath"/> function transforms any curves in the path
        /// that is selected into the current device context (DC), turning each curve into a sequence of lines.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-flattenpath"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a DC that contains a valid path.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "FlattenPath", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FlattenPath([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="FloodFill"/> function fills an area of the display surface with the current brush.
        /// The area is assumed to be bounded as specified by the <paramref name="color"/> parameter.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-floodfill"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "FloodFill", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FloodFill([In] HDC hdc, [In] int x, [In] int y, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="FrameRgn"/> function draws a border around the specified region by using the specified brush.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-framergn"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "FrameRgn", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FrameRgn([In] HDC hdc, [In] HRGN hrgn, [In] HBRUSH hbr, [In] int w, [In] int h);

        /// <summary>
        /// <para>
        /// The <see cref="GdiGradientFill"/> function fills rectangle and triangle structures.
        /// </para>
        /// <para>
        /// From： <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gdigradientfill"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="pVertex">
        /// A pointer to an array of <see cref="TRIVERTEX"/> structures that each define a triangle vertex.
        /// </param>
        /// <param name="nVertex">
        /// The number of vertices in <paramref name="pVertex"/>.
        /// </param>
        /// <param name="pMesh">
        /// An array of <see cref="GRADIENT_TRIANGLE"/> structures in triangle mode,
        /// or an array of <see cref="GRADIENT_RECT"/> structures in rectangle mode.
        /// </param>
        /// <param name="nCount">
        /// The number of elements (triangles or rectangles) in <paramref name="pMesh"/>.
        /// </param>
        /// <param name="ulMode">
        /// The gradient fill mode. This parameter can be one of the following values.
        /// <see cref="GRADIENT_FILL_RECT_H"/>:
        /// In this mode, two endpoints describe a rectangle.
        /// The rectangle is defined to have a constant color (specified by the <see cref="TRIVERTEX"/> structure) for the left and right edges.
        /// GDI interpolates the color from the left to right edge and fills the interior.
        /// <see cref="GRADIENT_FILL_RECT_V"/>:
        /// In this mode, two endpoints describe a rectangle.
        /// The rectangle is defined to have a constant color (specified by the <see cref="TRIVERTEX"/> structure) for the top and bottom edges.
        /// GDI interpolates the color from the top to bottom edge and fills the interior.
        /// <see cref="GRADIENT_FILL_TRIANGLE"/>:
        /// In this mode, an array of <see cref="TRIVERTEX"/> structures is passed to GDI
        /// along with a list of array indexes that describe separate triangles.
        /// GDI performs linear interpolation between triangle vertices and fills the interior.
        /// Drawing is done directly in 24- and 32-bpp modes.
        /// Dithering is performed in 16-, 8-, 4-, and 1-bpp mode.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Note  This function is the same as <see cref="GradientFill"/>.
        /// To add smooth shading to a triangle, call the <see cref="GdiGradientFill"/> function with the three triangle endpoints.
        /// GDI will linearly interpolate and fill the triangle.
        /// Here is the drawing output of a shaded triangle.
        /// To add smooth shading to a rectangle, call <see cref="GdiGradientFill"/>
        /// with the upper-left and lower-right coordinates of the rectangle.
        /// There are two shading modes used when drawing a rectangle.
        /// In horizontal mode, the rectangle is shaded from left-to-right.
        /// In vertical mode, the rectangle is shaded from top-to-bottom.
        /// Here is the drawing output of two shaded rectangles - one in horizontal mode, the other in vertical mode.
        /// The <see cref="GdiGradientFill"/> function uses a mesh method to specify the endpoints of the object to draw.
        /// All vertices are passed to <see cref="GdiGradientFill"/> in the <paramref name="pVertex"/> array.
        /// The <paramref name="pMesh"/> parameter specifies how these vertices are connected to form an object.
        /// When filling a rectangle, <paramref name="pMesh"/> points to an array of <see cref="GRADIENT_RECT"/> structures.
        /// Each <see cref="GRADIENT_RECT"/> structure specifies the index of two vertices in the <paramref name="pVertex"/> array.
        /// These two vertices form the upper-left and lower-right boundary of one rectangle.
        /// In the case of filling a triangle, <paramref name="pMesh"/> points to an array of <see cref="GRADIENT_TRIANGLE"/> structures.
        /// Each <see cref="GRADIENT_TRIANGLE"/> structure specifies the index of three vertices in the <paramref name="pVertex"/> array.
        /// These three vertices form one triangle.
        /// To simplify hardware acceleration, this routine is not required to be pixel-perfect in the triangle interior.
        /// Note that <see cref="GdiGradientFill"/> does not use
        /// the <see cref="TRIVERTEX.Alpha"/> member of the <see cref="TRIVERTEX"/> structure.
        /// To use <see cref="GdiGradientFill"/> with transparency, call <see cref="GdiGradientFill"/>
        /// and then call <see cref="GdiAlphaBlend"/> with the desired values for the alpha channel of each vertex.
        /// For more information, see Smooth Shading, Drawing a Shaded Triangle, and Drawing a Shaded Rectangle.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GdiGradientFill", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GdiGradientFill([In] HDC hdc, [In] TRIVERTEX[] pVertex, [In] ULONG nVertex,
            [In] PVOID pMesh, [In] ULONG nCount, [In] ULONG ulMode);

        /// <summary>
        /// <para>
        /// The <see cref="GetArcDirection"/> function retrieves the current arc direction for the specified device context.
        /// Arc and rectangle functions use the arc direction.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getarcdirection"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context.
        /// </param>
        /// <returns>
        /// The return value specifies the current arc direction; it can be any one of the following values:
        /// <see cref="AD_COUNTERCLOCKWISE"/>: Arcs and rectangles are drawn counterclockwise.
        /// <see cref="AD_CLOCKWISE"/>: Arcs and rectangles are drawn clockwise.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetArcDirection", ExactSpelling = true, SetLastError = true)]
        public static extern int GetArcDirection([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetCurrentPositionEx"/> function retrieves the current position in logical coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getcurrentpositionex"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentPositionEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCurrentPositionEx([In] HDC hdc, [Out] out POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="GetPath"/> function retrieves the coordinates defining the endpoints of lines
        /// and the control points of curves found in the path that is selected into the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getpath"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context that contains a closed path.
        /// </param>
        /// <param name="apt">
        /// A pointer to an array of <see cref="POINT"/> structures
        /// that receives the line endpoints and curve control points, in logical coordinates.
        /// </param>
        /// <param name="aj">
        /// A pointer to an array of bytes that receives the vertex types.
        /// This parameter can be one of the following values.
        /// <see cref="PT_MOVETO"/>:
        /// Specifies that the corresponding point in the lpPoints parameter starts a disjoint figure.
        /// <see cref="PT_LINETO"/>:
        /// Specifies that the previous point and the corresponding point in lpPoints are the endpoints of a line.
        /// <see cref="PT_BEZIERTO"/>:
        /// Specifies that the corresponding point in lpPoints is a control point or ending point for a Bézier curve
        /// <see cref="PT_BEZIERTO"/> values always occur in sets of three. 
        /// The point in the path immediately preceding them defines the starting point for the Bézier curve.
        /// The first two <see cref="PT_BEZIERTO"/> points are the control points,
        /// and the third <see cref="PT_BEZIERTO"/> point is the ending (if hard-coded) point.
        /// A <see cref="PT_LINETO"/> or <see cref="PT_BEZIERTO"/> value may be combined with the following value
        /// (by using the bitwise operator OR) to indicate that the corresponding point
        /// is the last point in a figure and the figure should be closed.
        /// <see cref="PT_CLOSEFIGURE"/>:
        /// Specifies that the figure is automatically closed after the corresponding line or curve is drawn.
        /// The figure is closed by drawing a line from the line or curve endpoint to the point corresponding to the last <see cref="PT_MOVETO"/>.
        /// </param>
        /// <param name="cpt">
        /// The total number of <see cref="POINT"/> structures that can be stored in the array pointed to by lpPoints.
        /// This value must be the same as the number of bytes that can be placed in the array pointed to by lpTypes.
        /// </param>
        /// <returns>
        /// If the nSize parameter is nonzero, the return value is the number of points enumerated.
        /// If nSize is 0, the return value is the total number of points in the path (and GetPath writes nothing to the buffers).
        /// If nSize is nonzero and is less than the number of points in the path, the return value is 1.
        /// </returns>
        /// <remarks>
        /// The device context identified by the hdc parameter must contain a closed path.
        /// The points of the path are returned in logical coordinates.
        /// Points are stored in the path in device coordinates, so <see cref="GetPath"/> changes the points
        /// from device coordinates to logical coordinates by using the inverse of the current transformation.
        /// The <see cref="FlattenPath"/> function may be called before <see cref="GetPath"/> to convert all curves in the path into line segments.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPath", ExactSpelling = true, SetLastError = true)]
        public static extern int GetPath([In] HDC hdc, [Out] POINT[] apt, [Out] BYTE[] aj, [In] int cpt);

        /// <summary>
        /// <para>
        /// The <see cref="GetPolyFillMode"/> function retrieves the current polygon fill mode.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getpolyfillmode"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPolyFillMode", ExactSpelling = true, SetLastError = true)]
        public static extern int GetPolyFillMode([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="InvertRgn"/> function inverts the colors in the specified region.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-invertrgn"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "InvertRgn", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL InvertRgn([In] HDC hdc, [In] HRGN hrgn);

        /// <summary>
        /// <para>
        /// The <see cref="LineDDA"/> function determines which pixels should be highlighted for a line defined by the specified starting and ending points.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-linedda"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LineDDA", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LineDDA([In] int xStart, [In] int yStart, [In] int xEnd, [In] int yEnd, [In] LINEDDAPROC lpProc, [In] LPARAM data);

        /// <summary>
        /// <para>
        /// The <see cref="LineTo"/> function draws a line from the current position up to, but not including, the specified point.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-lineto"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LineTo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LineTo([In] HDC hdc, [In] int x, [In] int y);

        /// <summary>
        /// <para>
        /// The <see cref="MoveToEx"/> function updates the current position to the specified point and optionally returns the previous position.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-movetoex"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "MoveToEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL MoveToEx([In] HDC hdc, [In] int x, [In] int y, [In][Out] ref POINT lppt);

        /// <summary>
        /// <para>
        /// The <see cref="PaintRgn"/> function paints the specified region by using the brush currently selected into the device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-paintrgn"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PaintRgn", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PaintRgn([In] HDC hdc, [In] HRGN hrgn);

        /// <summary>
        /// <para>
        /// The <see cref="Pie"/> function draws a pie-shaped wedge bounded by the intersection of an ellipse and two radials.
        /// The pie is outlined by using the current pen and filled by using the current brush.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-pie"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Pie", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Pie([In] HDC hdc, [In] int left, [In] int top, [In] int right, [In] int bottom,
            [In] int xr1, [In] int yr1, [In] int xr2, [In] int yr2);

        /// <summary>
        /// <para>
        /// The <see cref="PolyBezier"/> function draws one or more Bézier curves.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-polybezier"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="apt">
        /// A pointer to an array of <see cref="POINT"/> structures that contain the endpoints and control points of the curve(s), in logical units.
        /// </param>
        /// <param name="cpt">
        /// The number of points in the <paramref name="apt"/> array.
        /// This value must be one more than three times the number of curves to be drawn,
        /// because each Bézier curve requires two control points and an endpoint, and the initial curve requires an additional starting point.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="PolyBezier"/> function draws cubic Bézier curves by using the endpoints and control points
        /// specified by the <paramref name="apt"/> parameter.
        /// The first curve is drawn from the first point to the fourth point by using the second and third points as control points.
        /// Each subsequent curve in the sequence needs exactly three more points:
        /// the ending point of the previous curve is used as the starting point, the next two points in the sequence are control points,
        /// and the third is the ending point.
        /// The current position is neither used nor updated by the <see cref="PolyBezier"/> function.
        /// The figure is not filled.
        /// This function draws lines by using the current pen.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PolyBezier", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PolyBezier([In] HDC hdc, [In] POINT[] apt, [In] DWORD cpt);

        /// <summary>
        /// <para>
        /// The <see cref="PolyBezierTo"/> function draws one or more Bézier curves.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-polybezierto"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="apt">
        /// A pointer to an array of <see cref="POINT"/> structures that contains the endpoints and control points, in logical units.
        /// </param>
        /// <param name="cpt">
        /// The number of points in the lppt array.
        /// This value must be three times the number of curves to be drawn
        /// because each Bézier curve requires two control points and an ending point.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// This function draws cubic Bézier curves by using the control points specified by the lppt parameter.
        /// The first curve is drawn from the current position to the third point by using the first two points as control points.
        /// For each subsequent curve, the function needs exactly three more points,
        /// and uses the ending point of the previous curve as the starting point for the next.
        /// <see cref="PolyBezierTo"/> moves the current position to the ending point of the last Bézier curve.
        /// The figure is not filled.
        /// This function draws lines by using the current pen.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PolyBezierTo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PolyBezierTo([In] HDC hdc, [In] POINT[] apt, [In] DWORD cpt);

        /// <summary>
        /// <para>
        /// The <see cref="PolyDraw"/> function draws a set of line segments and Bézier curves.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-polydraw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="apt">
        /// A pointer to an array of <see cref="POINT"/> structures that contains the endpoints for each line segment
        /// and the endpoints and control points for each Bézier curve, in logical units.
        /// </param>
        /// <param name="aj">
        /// A pointer to an array that specifies how each point in the lppt array is used.
        /// This parameter can be one of the following values.
        /// <see cref="PT_MOVETO"/>:
        /// Specifies that this point starts a disjoint figure. This point becomes the new current position.
        /// <see cref="PT_LINETO"/>:
        /// Specifies that a line is to be drawn from the current position to this point, which then becomes the new current position.
        /// <see cref="PT_BEZIERTO"/>:
        /// Specifies that this point is a control point or ending point for a Bézier curve.
        /// <see cref="PT_BEZIERTO"/> types always occur in sets of three.
        /// The current position defines the starting point for the Bézier curve.
        /// The first two <see cref="PT_BEZIERTO"/> points are the control points,
        /// and the third <see cref="PT_BEZIERTO"/> point is the ending point.
        /// The ending point becomes the new current position.
        /// If there are not three consecutive <see cref="PT_BEZIERTO"/> points, an error results.
        /// A <see cref="PT_LINETO"/> or <see cref="PT_BEZIERTO"/> type can be combined with the following value
        /// by using the bitwise operator OR to indicate that the corresponding point is the last point in a figure and the figure is closed.
        /// <see cref="PT_CLOSEFIGURE"/>:
        /// Specifies that the figure is automatically closed
        /// after the <see cref="PT_LINETO"/> or <see cref="PT_BEZIERTO"/> type for this point is done.
        /// A line is drawn from this point to the most recent <see cref="PT_MOVETO"/> or <see cref="MoveToEx"/> point.
        /// This value is combined with the <see cref="PT_LINETO"/> type for a line,
        /// or with the <see cref="PT_BEZIERTO"/> type of the ending point for a Bézier curve, by using the bitwise operator OR.
        /// The current position is set to the ending point of the closing line.
        /// </param>
        /// <param name="cpt">
        /// The total number of points in the lppt array, the same as the number of bytes in the lpbTypes array.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="PolyDraw"/> function can be used in place of consecutive calls
        /// to <see cref="MoveToEx"/>, <see cref="LineTo"/>, and <see cref="PolyBezierTo"/> functions to draw disjoint figures.
        /// The lines and curves are drawn using the current pen and figures are not filled.
        /// If there is an active path started by calling <see cref="BeginPath"/>, <see cref="PolyDraw"/> adds to the path.
        /// The points contained in the lppt array and in the lpbTypes array indicate
        /// whether each point is part of a <see cref="MoveTo"/>, <see cref="LineTo"/>, or <see cref="PolyBezierTo"/> operation.
        /// It is also possible to close figures.
        /// This function updates the current position.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PolyDraw", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PolyDraw([In] HDC hdc, [In] POINT[] apt, [In] BYTE[] aj, [In] int cpt);

        /// <summary>
        /// <para>
        /// The <see cref="Polygon"/> function draws a polygon consisting of two or more vertices connected by straight lines.
        /// The polygon is outlined by using the current pen and filled by using the current brush and polygon fill mode.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-polygon"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Polygon", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Polygon([In] HDC hdc, [In] POINT[] apt, [In] int cpt);

        /// <summary>
        /// <para>
        /// The <see cref="Polyline"/> function draws a series of line segments by connecting the points in the specified array.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-polyline"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Polyline", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Polyline([In] HDC hdc, [In] POINT[] apt, [In] int cpt);

        /// <summary>
        /// <para>
        /// The <see cref="PolylineTo"/> function draws one or more straight lines.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-polylineto"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="apt">
        /// A pointer to an array of <see cref="POINT"/> structures that contains the vertices of the line, in logical units.
        /// </param>
        /// <param name="cpt">
        /// The number of points in the array.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Unlike the <see cref="Polyline"/> function, the <see cref="PolylineTo"/> function uses and updates the current position.
        /// A line is drawn from the current position to the first point specified by the <paramref name="apt"/> parameter by using the current pen.
        /// For each additional line, the function draws from the ending point of the previous line
        /// to the next point specified by <paramref name="apt"/>.
        /// <see cref="PolylineTo"/> moves the current position to the ending point of the last line.
        /// If the line segments drawn by this function form a closed figure, the figure is not filled.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PolylineTo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PolylineTo([In] HDC hdc, [In] POINT[] apt, [In] DWORD cpt);

        /// <summary>
        /// <para>
        /// The <see cref="PolyPolygon"/> function draws a series of closed polygons.
        /// Each polygon is outlined by using the current pen and filled by using the current brush and polygon fill mode.
        /// The polygons drawn by this function can overlap.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-polypolygon"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PolyPolygon", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PolyPolygon([In] HDC hdc, [In] POINT[] apt, [In] INT[] asz, [In] int csz);

        /// <summary>
        /// <para>
        /// The <see cref="PolyPolyline"/> function draws multiple series of connected line segments.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-polypolyline"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="apt">
        /// A pointer to an array of <see cref="POINT"/> structures that contains the vertices of the polylines, in logical units.
        /// The polylines are specified consecutively.
        /// </param>
        /// <param name="asz">
        /// A pointer to an array of variables specifying the number of points in the lppt array for the corresponding polyline.
        /// Each entry must be greater than or equal to two.
        /// </param>
        /// <param name="csz">
        /// The total number of entries in the lpdwPolyPoints array.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The line segments are drawn by using the current pen.
        /// The figures formed by the segments are not filled.
        /// The current position is neither used nor updated by this function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PolyPolyline", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PolyPolyline([In] HDC hdc, [In] POINT[] apt, [In] DWORD[] asz, [In] DWORD csz);

        /// <summary>
        /// <para>
        /// The <see cref="Rectangle"/> function draws a rectangle.
        /// The rectangle is outlined by using the current pen and filled by using the current brush.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-rectangle"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "Rectangle", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL Rectangle([In] HDC hdc, [In] int left, [In] int top, [In] int right, [In] int bottom);

        /// <summary>
        /// <para>
        /// The <see cref="RoundRect"/> function draws a rectangle with rounded corners.
        /// The rectangle is outlined by using the current pen and filled by using the current brush.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-roundrect"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RoundRect", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RoundRect([In] HDC hdc, [In] int left, [In] int top, [In] int right, [In] int bottom, [In] int width, [In] int height);

        /// <summary>
        /// <para>
        /// The <see cref="SetArcDirection"/> sets the drawing direction to be used for arc and rectangle functions.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setarcdirection"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="dir">
        /// The new arc direction. This parameter can be one of the following values.
        /// <see cref="AD_COUNTERCLOCKWISE"/>:
        /// Figures drawn counterclockwise.
        /// <see cref="AD_CLOCKWISE"/>:
        /// Figures drawn clockwise.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the old arc direction.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The default direction is counterclockwise.
        /// The <see cref="SetArcDirection"/> function specifies the direction in which the following functions draw:
        /// <see cref="Arc"/>, <see cref="ArcTo"/>, <see cref="Chord"/>, <see cref="Ellipse"/>,
        /// <see cref="Pie"/>, <see cref="Rectangle"/>, <see cref="RoundRect"/>
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetArcDirection", ExactSpelling = true, SetLastError = true)]
        public static extern int SetArcDirection([In] HDC hdc, [In] int dir);

        /// <summary>
        /// <para>
        /// The <see cref="SetPolyFillMode"/> function sets the polygon fill mode for functions that fill polygons.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setpolyfillmode"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPolyFillMode", ExactSpelling = true, SetLastError = true)]
        public static extern int SetPolyFillMode([In] HDC hdc, [In] PolyFillModes mode);

        /// <summary>
        /// <para>
        /// The <see cref="StrokeAndFillPath"/> function closes any open figures in a path,
        /// strokes the outline of the path by using the current pen, and fills its interior by using the current brush.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-strokeandfillpath"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The device context identified by the hdc parameter must contain a closed path.
        /// The <see cref="StrokeAndFillPath"/> function has the same effect as closing all the open figures in the path,
        /// and stroking and filling the path separately, except that the filled region will not overlap the stroked region even if the pen is wide.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StrokeAndFillPath", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL StrokeAndFillPath([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="StrokePath"/> function renders the specified path by using the current pen.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-strokepath"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a device context that contains the completed path.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The path, if it is to be drawn by <see cref="StrokePath"/>, must have been completed through a call to <see cref="EndPath"/>.
        /// Calling this function on a path for which <see cref="EndPath"/> has not been called will cause this function to fail and return zero.
        /// Unlike other path drawing functions such as <see cref="StrokeAndFillPath"/>,
        /// <see cref="StrokePath"/> will not attempt to close the path by drawing a straight line
        /// from the first point on the path to the last point on the path.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StrokePath", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL StrokePath([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="WidenPath"/> function redefines the current path as the area that would be painted
        /// if the path were stroked using the pen currently selected into the given device context.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-widenpath"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context that contains a closed path.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="WidenPath"/> function is successful only if the current pen is a geometric pen
        /// created by the <see cref="ExtCreatePen"/> function, or if the pen is created with the <see cref="CreatePen"/> function
        /// and has a width, in device units, of more than one.
        /// The device context identified by the <paramref name="hdc"/> parameter must contain a closed path.
        /// Any Bézier curves in the path are converted to sequences of straight lines approximating the widened curves.
        /// As such, no Bézier curves remain in the path after <see cref="WidenPath"/> is called.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "WidenPath", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WidenPath([In] HDC hdc);
    }
}
