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
        /// The <see cref="CreateEllipticRgn"/> function creates an elliptical region.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createellipticrgn
        /// </para>
        /// </summary>
        /// <param name="x1">
        /// Specifies the x-coordinate in logical units, of the upper-left corner of the bounding rectangle of the ellipse.
        /// </param>
        /// <param name="y1">
        /// Specifies the y-coordinate in logical units, of the upper-left corner of the bounding rectangle of the ellipse.
        /// </param>
        /// <param name="x2">
        /// Specifies the x-coordinate in logical units, of the lower-right corner of the bounding rectangle of the ellipse.
        /// </param>
        /// <param name="y2">
        /// Specifies the y-coordinate in logical units, of the lower-right corner of the bounding rectangle of the ellipse.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the region.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the <see cref="HRGN"/> object, call the <see cref="DeleteObject"/> function to delete it.
        /// A bounding rectangle defines the size, shape, and orientation of the region:
        /// The long sides of the rectangle define the length of the ellipse's major axis; the short sides define the length of the ellipse's minor axis;
        /// and the center of the rectangle defines the intersection of the major and minor axes.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEllipticRgn", SetLastError = true)]
        public static extern HRGN CreateEllipticRgn([In]int x1, [In]int y1, [In]int x2, [In]int y2);

        /// <summary>
        /// <para>
        /// The <see cref="CreateEllipticRgnIndirect"/> function creates an elliptical region.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createellipticrgnindirect
        /// </para>
        /// </summary>
        /// <param name="lprect">
        /// Pointer to a <see cref="RECT"/> structure that contains the coordinates of the upper-left and lower-right corners of the bounding rectangle
        /// of the ellipse in logical units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the region.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the <see cref="HRGN"/> object, call the <see cref="DeleteObject"/> function to delete it.
        /// A bounding rectangle defines the size, shape, and orientation of the region: The long sides of the rectangle
        /// define the length of the ellipse's major axis; the short sides define the length of the ellipse's minor axis;
        /// and the center of the rectangle defines the intersection of the major and minor axes.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEllipticRgnIndirect", SetLastError = true)]
        public static extern HRGN CreateEllipticRgnIndirect([MarshalAs(UnmanagedType.LPStruct)][In]RECT lprect);

        /// <summary>
        /// <para>
        /// The <see cref="CreatePolygonRgn"/> function creates a polygonal region.
        /// </para>
        /// </summary>
        /// <param name="pptl">
        /// A pointer to an array of <see cref="POINT"/> structures that define the vertices of the polygon in logical units.
        /// The polygon is presumed closed.
        /// Each vertex can be specified only once.
        /// </param>
        /// <param name="cPoint">
        /// The number of points in the array.
        /// </param>
        /// <param name="iMode">
        /// The fill mode used to determine which pixels are in the region.
        /// This parameter can be one of the following values.
        /// <see cref="ALTERNATE"/>:
        /// Selects alternate mode (fills area between odd-numbered and even-numbered polygon sides on each scan line).
        /// <see cref="WINDING"/>:
        /// Selects winding mode (fills any region with a nonzero winding value).
        /// For more information about these modes, see the <see cref="SetPolyFillMode"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the region.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the <see cref="HRGN"/> object, call the <see cref="DeleteObject"/> function to delete it.
        /// Region coordinates are represented as 27-bit signed integers.
        /// Regions created by the Create&lt;shape&gt;Rgn methods (such as <see cref="CreateRectRgn"/> and <see cref="CreatePolygonRgn"/>)
        /// only include the interior of the shape; the shape's outline is excluded from the region.
        /// This means that any point on a line between two sequential vertices is not included in the region.
        /// If you were to call <see cref="PtInRegion"/> for such a point, it would return zero as the result.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePolygonRgn", SetLastError = true)]
        public static extern HRGN CreatePolygonRgn([MarshalAs(UnmanagedType.LPArray)][In]POINT[] pptl, [In]int cPoint, [In]int iMode);

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
        /// Regions created by the Create&lt;shape&gt;Rgn methods (such as <see cref="CreateRectRgn"/> and <see cref="CreatePolygonRgn"/>)
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
