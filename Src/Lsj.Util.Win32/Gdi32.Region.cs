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
        /// The <see cref="CreateRectRgn"/> function creates a rectangular region.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createrectrgn
        /// </para>
        /// </summary>
        /// <param name="x1">
        /// Specifies the x-coordinate of the upper-left corner of the region in logical units.
        /// </param>
        /// <param name="y1">
        /// Specifies the y-coordinate of the upper-left corner of the region in logical units.
        /// </param>
        /// <param name="x2">
        /// Specifies the x-coordinate of the lower-right corner of the region in logical units.
        /// </param>
        /// <param name="y2">
        /// Specifies the y-coordinate of the lower-right corner of the region in logical units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the region.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the <see cref="HRGN"/> object, call the <see cref="DeleteObject"/> function to delete it.
        /// Region coordinates are represented as 27-bit signed integers.
        /// Regions created by the Create<shape>Rgn methods (such as <see cref="CreateRectRgn"/> and <see cref="CreatePolygonRgn"/>)
        /// only include the interior of the shape; the shape's outline is excluded from the region.
        /// This means that any point on a line between two sequential vertices is not included in the region.
        /// If you were to call <see cref="PtInRegion"/> for such a point, it would return zero as the result.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateRectRgn", SetLastError = true)]
        public static extern HRGN CreateRectRgn([In]int x1, [In]int y1, [In]int x2, [In]int y2);

        /// <summary>
        /// <para>
        /// The <see cref="CreateRectRgnIndirect"/> function creates a rectangular region.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createrectrgnindirect
        /// </para>
        /// </summary>
        /// <param name="lprect">
        /// Pointer to a <see cref="RECT"/> structure that contains the coordinates of the upper-left and lower-right corners of the rectangle
        /// that defines the region in logical units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the region.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the <see cref="HRGN"/> object, call the <see cref="DeleteObject"/> function to delete it.
        /// Region coordinates are represented as 27-bit signed integers.
        /// The region will be exclusive of the bottom and right edges.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateRectRgn", SetLastError = true)]
        public static extern HRGN CreateRectRgnIndirect([MarshalAs(UnmanagedType.LPStruct)][In]RECT lprect);
    }
}
