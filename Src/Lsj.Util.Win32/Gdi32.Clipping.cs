using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CombineRgnModes;
using static Lsj.Util.Win32.Enums.RegionFlags;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
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
        /// The operation to be performed. It must be one of the following values.
        /// <see cref="RGN_AND"/>:
        /// The new clipping region combines the overlapping areas of the current clipping region
        /// and the region identified by <paramref name="hrgn"/>.
        /// <see cref="RGN_COPY"/>:
        /// The new clipping region is a copy of the region identified by <paramref name="hrgn"/>.
        /// This is identical to <see cref="SelectClipRgn"/>.
        /// If the region identified by <paramref name="hrgn"/> is <see cref="NULL"/>,
        /// the new clipping region is the default clipping region (the default clipping region is a null region).
        /// <see cref="RGN_DIFF"/>:
        /// The new clipping region combines the areas of the current clipping region
        /// with those areas excluded from the region identified by <paramref name="hrgn"/>.
        /// <see cref="RGN_OR"/>:
        /// The new clipping region combines the current clipping region and
        /// the region identified by <paramref name="hrgn"/>.
        /// <see cref="RGN_XOR"/>:
        /// The new clipping region combines the current clipping region and
        /// the region identified by <paramref name="hrgn"/> but excludes any overlapping areas.
        /// </param>
        /// <returns>
        /// The return value specifies the new clipping region's complexity; it can be one of the following values.
        /// <see cref="NULLREGION"/>: Region is empty.
        /// <see cref="SIMPLEREGION"/>: Region is a single rectangle.
        /// <see cref="COMPLEXREGION"/>: Region is more than one rectangle.
        /// <see cref="ERROR"/>: An error occurred.
        /// </returns>
        /// <remarks>
        /// If an error occurs when this function is called,
        /// the previous clipping region for the specified device context is not affected.
        /// The <see cref="ExtSelectClipRgn"/> function assumes that the coordinates
        /// for the specified region are specified in device units.
        /// Only a copy of the region identified by the <paramref name="hrgn"/> parameter is used.
        /// The region itself can be reused after this call or it can be deleted.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtSelectClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags ExtSelectClipRgn([In] HDC hdc, [In] HRGN hrgn, [In] CombineRgnModes mode);

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
        /// If the function succeeds, the return value specifies the clipping box's complexity and can be one of the following values.
        /// <see cref="NULLREGION"/>: Region is empty.
        /// <see cref="SIMPLEREGION"/>: Region is a single rectangle.
        /// <see cref="COMPLEXREGION"/>: Region is more than one rectangle.
        /// <see cref="ERROR"/>: An error occurred.
        /// <see cref="GetClipBox"/> returns logical coordinates based on the given device context.
        /// </returns>
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
        /// An application-defined clipping region is a clipping region identified by the <see cref="SelectClipRgn"/> function.
        /// It is not a clipping region created when the application calls the <see cref="BeginPaint"/> function.
        /// If the function succeeds, the hrgn parameter is a handle to a copy of the current clipping region.
        /// Subsequent changes to this copy will not affect the current clipping region.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern int GetClipRgn([In] HDC hdc, [In] HRGN hrgn);

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
        public static extern RegionFlags IntersectClipRect([In] HDC hdc, [In] int left, [In] int top, [In] int right, [In] int bottom);

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
        /// The return value specifies the new region's complexity and can be one of the following values.
        /// <see cref="NULLREGION"/>: Region is empty.
        /// <see cref="SIMPLEREGION"/>: Region is a single rectangle.
        /// <see cref="COMPLEXREGION"/>: Region is more than one rectangle.
        /// <see cref="ERROR"/>: An error occurred. (The current clipping region is unaffected.)
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OffsetClipRgn", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags OffsetClipRgn([In] HDC hdc, [In] int x, [In] int y);

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
        /// If the specified point is within the clipping region of the device context, the return value is <see cref="TRUE"/>(1).
        /// If the specified point is not within the clipping region of the device context, the return value is <see cref="FALSE"/>(0).
        /// If the HDC is not valid, the return value is (<see cref="BOOL"/>)-1.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PtVisible", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PtVisible([In] HDC hdc, [In] int x, [In] int y);

        /// <summary>
        /// <para>
        /// The <see cref="RectVisible"/> function determines whether any part of the specified rectangle lies within the clipping region of a device context.
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
        public static extern BOOL RectVisible([In] HDC hdc, [In] in RECT lprect);

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
        /// The way to use the path. This parameter can be one of the following values.
        /// <see cref="RGN_AND"/>:
        /// The new clipping region includes the intersection (overlapping areas) of the current clipping region and the current path.
        /// <see cref="RGN_COPY"/>:
        /// The new clipping region is the current path.
        /// <see cref="RGN_DIFF"/>:
        /// The new clipping region includes the areas of the current clipping region with those of the current path excluded.
        /// <see cref="RGN_OR"/>:
        /// The new clipping region includes the union (combined areas) of the current clipping region and the current path.
        /// <see cref="RGN_XOR"/>:
        /// The new clipping region includes the union of the current clipping region and the current path but without the overlapping areas.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The device context identified by the <paramref name="hdc"/> parameter must contain a closed path.
        /// </remarks>
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
        public static extern RegionFlags SelectClipRgn([In] HDC hdc, [In] HRGN hrgn);
    }
}
