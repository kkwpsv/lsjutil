using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

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
    }
}
