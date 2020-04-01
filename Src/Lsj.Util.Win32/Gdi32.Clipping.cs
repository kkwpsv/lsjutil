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
        /// The <see cref="ExcludeClipRect"/> function creates a new clipping region that consists of the existing clipping region minus the specified rectangle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-excludecliprect
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
        /// The return value specifies the new clipping region's complexity; it can be one of the following values.
        /// <see cref="NULLREGION"/>: Region is empty.
        /// <see cref="SIMPLEREGION"/>: Region is a single rectangle.
        /// <see cref="COMPLEXREGION"/>: Region is more than one rectangle.
        /// <see cref="ERROR"/>: No region was created.
        /// </returns>
        /// <remarks>
        /// The lower and right edges of the specified rectangle are not excluded from the clipping region.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExcludeClipRect", ExactSpelling = true, SetLastError = true)]
        public static extern int ExcludeClipRect([In]HDC hdc, [In]int left, [In]int top, [In]int right, [In]int bottom);

        /// <summary>
        /// <para>
        /// The <see cref="GetClipBox"/> function retrieves the dimensions of the tightest bounding rectangle that can be drawn
        /// around the current visible area on the device.
        /// The visible area is defined by the current clipping region or clip path, as well as any overlapping windows.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getclipbox
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lprect">
        /// A pointer to a <see cref="RECT"/> structure that is to receive the rectangle dimensions, in logical units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the clipping box's complexity and can be one of the following values.
        /// <see cref="NULLREGION"/>: Region is empty.
        /// <see cref="SIMPLEREGION"/>: Region is a single rectangle.
        /// <see cref="COMPLEXREGION"/>: Region is more than one rectangle.
        /// <see cref="ERROR"/>: An error occurred.
        /// <see cref="GetClipBox"/> returns logical coordinates based on the given device context.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipBox", ExactSpelling = true, SetLastError = true)]
        public static extern int GetClipBox([In]HDC hdc, [Out]out RECT lprect);

        /// <summary>
        /// <para>
        /// The <see cref="IntersectClipRect"/> function creates a new clipping region from the intersection of the current clipping region
        /// and the specified rectangle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-intersectcliprect
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
        /// The return value specifies the new clipping region's type and can be one of the following values.
        /// <see cref="NULLREGION"/>: Region is empty.
        /// <see cref="SIMPLEREGION"/>: Region is a single rectangle.
        /// <see cref="COMPLEXREGION"/>: Region is more than one rectangle.
        /// <see cref="ERROR"/>: An error occurred. (The current clipping region is unaffected.)
        /// </returns>
        /// <remarks>
        /// The lower and right-most edges of the given rectangle are excluded from the clipping region.
        /// If a clipping region does not already exist then the system may apply a default clipping region to the specified <see cref="HDC"/>.
        /// A clipping region is then created from the intersection of that default clipping region and the rectangle specified in the function parameters.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "IntersectClipRect", ExactSpelling = true, SetLastError = true)]
        public static extern int IntersectClipRect([In]HDC hdc, [In]int left, [In]int top, [In]int right, [In]int bottom);

        /// <summary>
        /// <para>
        /// The <see cref="OffsetClipRgn"/> function moves the clipping region of a device context by the specified offsets.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-offsetcliprgn
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
        /// The return value specifies the new region's complexity and can be one of the following values.
        /// <see cref="NULLREGION"/>: Region is empty.
        /// <see cref="SIMPLEREGION"/>: Region is a single rectangle.
        /// <see cref="COMPLEXREGION"/>: Region is more than one rectangle.
        /// <see cref="ERROR"/>: An error occurred. (The current clipping region is unaffected.)
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OffsetClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern int OffsetClipRgn([In]HDC hdc, [In]int x, [In]int y);

        /// <summary>
        /// <para>
        /// The <see cref="PtVisible"/> function determines whether the specified point is within the clipping region of a device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-ptvisible
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
        /// If the specified point is within the clipping region of the device context, the return value is <see cref="TRUE"/>(1).
        /// If the specified point is not within the clipping region of the device context, the return value is <see cref="FALSE"/>(0).
        /// If the HDC is not valid, the return value is (<see cref="BOOL"/>)-1.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PtVisible", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PtVisible([In]HDC hdc, [In]int x, [In]int y);

        /// <summary>
        /// <para>
        /// The <see cref="RectVisible"/> function determines whether any part of the specified rectangle lies within the clipping region of a device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-rectvisible
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lprect">
        /// A pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the specified rectangle.
        /// </param>
        /// <returns>
        /// If the current transform does not have a rotation and the rectangle lies within the clipping region,
        /// the return value is <see cref="TRUE"/> (1).
        /// If the current transform does not have a rotation and the rectangle does not lie within the clipping region,
        /// the return value is <see cref="FALSE"/> (0).
        /// If the current transform has a rotation and the rectangle lies within the clipping region, the return value is 2.
        /// If the current transform has a rotation and the rectangle does not lie within the clipping region, the return value is 1.
        /// All other return values are considered error codes.
        /// If the any parameter is not valid, the return value is undefined.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RectVisible", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RectVisible([In]HDC hdc, [In]in RECT lprect);

        /// <summary>
        /// <para>
        /// The <see cref="SelectClipRgn"/> function selects a region as the current clipping region for the specified device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-selectcliprgn
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// A handle to the region to be selected.
        /// </param>
        /// <returns>
        /// The return value specifies the region's complexity and can be one of the following values.
        /// <see cref="NULLREGION"/>: Region is empty.
        /// <see cref="SIMPLEREGION"/>: Region is a single rectangle.
        /// <see cref="COMPLEXREGION"/>: Region is more than one rectangle.
        /// <see cref="ERROR"/>: An error occurred. (The previous clipping region is unaffected.)
        /// </returns>
        /// <remarks>
        /// Only a copy of the selected region is used. The region itself can be selected for any number of other device contexts or it can be deleted.
        /// The <see cref="SelectClipRgn"/> function assumes that the coordinates for a region are specified in device units.
        /// To remove a device-context's clipping region, specify a <see cref="NULL"/> region handle.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern int SelectClipRgn([In]HDC hdc, [In]HRGN hrgn);
    }
}
