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
    }
}
