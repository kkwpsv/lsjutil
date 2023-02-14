using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CombineRgnModes;
using static Lsj.Util.Win32.Enums.PolyFillModes;
using static Lsj.Util.Win32.Enums.RegionFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="CombineRgn"/> function combines two regions and stores the result in a third region.
        /// The two regions are combined according to the specified mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-combinergn"/>
        /// </para>
        /// </summary>
        /// <param name="hrgnDst">
        /// A handle to a new region with dimensions defined by combining two other regions.
        /// (This region must exist before <see cref="CombineRgn"/> is called.)
        /// </param>
        /// <param name="hrgnSrc1">
        /// A handle to the first of two regions to be combined.
        /// </param>
        /// <param name="hrgnSrc2">
        /// A handle to the second of two regions to be combined.
        /// </param>
        /// <param name="iMode">
        /// A mode indicating how the two regions will be combined.
        /// This parameter can be one of the following values.
        /// <see cref="RGN_AND"/>, <see cref="RGN_COPY"/>, <see cref="RGN_DIFF"/>, <see cref="RGN_OR"/>, <see cref="RGN_XOR"/>
        /// </param>
        /// <returns>
        /// The return value specifies the type of the resulting region. It can be one of the following values.
        /// <see cref="NULLREGION"/>: The region is empty.
        /// <see cref="SIMPLEREGION"/>: The region is a single rectangle.
        /// <see cref="COMPLEXREGION"/>: The region is more than a single rectangle.
        /// <see cref="ERROR"/>: No region is created.
        /// </returns>
        /// <remarks>
        /// The three regions need not be distinct.
        /// For example, the <paramref name="hrgnSrc1"/> parameter can equal the <paramref name="hrgnDst"/> parameter.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CombineRgn", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags CombineRgn([In] HRGN hrgnDst, [In] HRGN hrgnSrc1, [In] HRGN hrgnSrc2, [In] CombineRgnModes iMode);

        /// <summary>
        /// <para>
        /// The <see cref="CreateEllipticRgn"/> function creates an elliptical region.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createellipticrgn"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEllipticRgn", ExactSpelling = true, SetLastError = true)]
        public static extern HRGN CreateEllipticRgn([In] int x1, [In] int y1, [In] int x2, [In] int y2);

        /// <summary>
        /// <para>
        /// The <see cref="CreateEllipticRgnIndirect"/> function creates an elliptical region.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createellipticrgnindirect"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEllipticRgnIndirect", ExactSpelling = true, SetLastError = true)]
        public static extern HRGN CreateEllipticRgnIndirect([In] in RECT lprect);

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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePolygonRgn", ExactSpelling = true, SetLastError = true)]
        public static extern HRGN CreatePolygonRgn([MarshalAs(UnmanagedType.LPArray)][In] POINT[] pptl, [In] int cPoint, [In] PolyFillModes iMode);

        /// <summary>
        /// <para>
        /// The <see cref="CreatePolyPolygonRgn"/> function creates a region consisting of a series of polygons.
        /// The polygons can overlap.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createpolypolygonrgn"/>
        /// </para>
        /// </summary>
        /// <param name="pptl">
        /// A pointer to an array of <see cref="POINT"/> structures that define the vertices of the polygons in logical units.
        /// The polygons are specified consecutively.
        /// Each polygon is presumed closed and each vertex is specified only once.
        /// </param>
        /// <param name="pc">
        /// A pointer to an array of integers, each of which specifies the number of points in one of the polygons in the array pointed to by lppt.
        /// </param>
        /// <param name="cPoly">
        /// The total number of integers in the array pointed to by lpPolyCounts.
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
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePolyPolygonRgn", ExactSpelling = true, SetLastError = true)]
        public static extern HRGN CreatePolyPolygonRgn([MarshalAs(UnmanagedType.LPArray)][In] POINT[] pptl,
            [MarshalAs(UnmanagedType.LPArray)][In] INT[] pc, [In] int cPoly, [In] int iMode);

        /// <summary>
        /// <para>
        /// The <see cref="CreateRectRgn"/> function creates a rectangular region.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createrectrgn"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateRectRgn", ExactSpelling = true, SetLastError = true)]
        public static extern HRGN CreateRectRgn([In] int x1, [In] int y1, [In] int x2, [In] int y2);

        /// <summary>
        /// <para>
        /// The <see cref="CreateRectRgnIndirect"/> function creates a rectangular region.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createrectrgnindirect"/>
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateRectRgnIndirect", ExactSpelling = true, SetLastError = true)]
        public static extern HRGN CreateRectRgnIndirect([In] in RECT lprect);

        /// <summary>
        /// <para>
        /// The <see cref="CreateRoundRectRgn"/> function creates a rectangular region with rounded corners.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createroundrectrgn"/>
        /// </para>
        /// </summary>
        /// <param name="x1">
        /// Specifies the x-coordinate of the upper-left corner of the region in device units.
        /// </param>
        /// <param name="y1">
        /// Specifies the y-coordinate of the upper-left corner of the region in device units.
        /// </param>
        /// <param name="x2">
        /// Specifies the x-coordinate of the lower-right corner of the region in device units.
        /// </param>
        /// <param name="y2">
        /// Specifies the y-coordinate of the lower-right corner of the region in device units.
        /// </param>
        /// <param name="w">
        /// Specifies the width of the ellipse used to create the rounded corners in device units.
        /// </param>
        /// <param name="h">
        /// Specifies the height of the ellipse used to create the rounded corners in device units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the region.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the <see cref="HRGN"/> object call the <see cref="DeleteObject"/> function to delete it.
        /// Region coordinates are represented as 27-bit signed integers.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateRoundRectRgn", ExactSpelling = true, SetLastError = true)]
        public static extern HRGN CreateRoundRectRgn([In] int x1, [In] int y1, [In] int x2, [In] int y2, [In] int w, [In] int h);

        /// <summary>
        /// <para>
        /// The <see cref="EqualRgn"/> function checks the two specified regions to determine whether they are identical.
        /// The function considers two regions identical if they are equal in size and shape.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-equalrgn"/>
        /// </para>
        /// </summary>
        /// <param name="hrgn1">
        /// Handle to a region.
        /// </param>
        /// <param name="hrgn2">
        /// Handle to a region.
        /// </param>
        /// <returns>
        /// If the two regions are equal, the return value is <see cref="TRUE"/>.
        /// If the two regions are not equal, the return value is <see cref="FALSE"/>.
        /// A return value of <see cref="ERROR"/> means at least one of the region handles is invalid.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EqualRgn", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EqualRgn([In] HRGN hrgn1, [In] HRGN hrgn2);

        /// <summary>
        /// <para>
        /// The <see cref="ExtCreateRegion"/> function creates a region from the specified region and transformation data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-extcreateregion"/>
        /// </para>
        /// </summary>
        /// <param name="lpx">
        /// A pointer to an <see cref="XFORM"/> structure that defines the transformation to be performed on the region.
        /// If this pointer is <see cref="NullRef{XFORM}"/>, the identity transformation is used.
        /// </param>
        /// <param name="nCount">
        /// The number of bytes pointed to by <paramref name="lpData"/>.
        /// </param>
        /// <param name="lpData">
        /// A pointer to a <see cref="RGNDATA"/> structure that contains the region data in logical units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the value of the region.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// Region coordinates are represented as 27-bit signed integers.
        /// An application can retrieve data for a region by calling the <see cref="GetRegionData"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtCreateRegion", ExactSpelling = true, SetLastError = true)]
        public static extern HRGN ExtCreateRegion([In] in XFORM lpx, [In] DWORD nCount, [In] in RGNDATA lpData);

        /// <summary>
        /// <para>
        /// The <see cref="GetRandomRgn"/> function copies the system clipping region of a specified device context to a specific region.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getrandomrgn"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hrgn">
        /// A handle to a region.
        /// Before the function is called, this identifies an existing region.
        /// After the function returns, this identifies a copy of the current system region.
        /// The old region identified by hrgn is overwritten.
        /// </param>
        /// <param name="i">
        /// This parameter must be <see cref="SYSRGN"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is 1.
        /// If the function fails, the return value is -1.
        /// If the region to be retrieved is <see cref="NULL"/>, the return value is 0.
        /// If the function fails or the region to be retrieved is <see cref="NULL"/>, <paramref name="hrgn"/> is not initialized.
        /// </returns>
        /// <remarks>
        /// When using the <see cref="SYSRGN"/> flag, note that the system clipping region might not be current because of window movements.
        /// Nonetheless, it is safe to retrieve and use the system clipping region
        /// within the BeginPaint-EndPaint block during <see cref="WM_PAINT"/> processing.
        /// In this case, the system region is the intersection of the update region and the current visible area of the window.
        /// Any window movement following the return of <see cref="GetRandomRgn"/> and
        /// before <see cref="EndPaint"/> will result in a new <see cref="WM_PAINT"/> message.
        /// Any other use of the <see cref="SYSRGN"/> flag may result in painting errors in your application.
        /// The region returned is in screen coordinates.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetRandomRgn", ExactSpelling = true, SetLastError = true)]
        public static extern int GetRandomRgn([In] HDC hdc, [In] HRGN hrgn, [In] INT i);

        /// <summary>
        /// <para>
        /// The <see cref="GetRegionData"/> function fills the specified buffer with data describing a region.
        /// This data includes the dimensions of the rectangles that make up the region.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getregiondata"/>
        /// </para>
        /// </summary>
        /// <param name="hrgn">
        /// A handle to the region.
        /// </param>
        /// <param name="nCount">
        /// The size, in bytes, of the <paramref name="lpRgnData"/> buffer.
        /// </param>
        /// <param name="lpRgnData">
        /// A pointer to a <see cref="RGNDATA"/> structure that receives the information.
        /// The dimensions of the region are in logical units.
        /// If this parameter is <see cref="NullRef{RGNDATA}"/>, the return value contains the number of bytes needed for the region data.
        /// </param>
        /// <returns>
        /// If the function succeeds and <paramref name="nCount"/> specifies an adequate number of bytes,
        /// the return value is always <paramref name="nCount"/>.
        /// If <paramref name="nCount"/> is too small or the function fails, the return value is 0.
        /// If <paramref name="lpRgnData"/> is <see cref="NullRef{RGNDATA}"/>, the return value is the required number of bytes.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetRegionData"/> function is used in conjunction with the <see cref="ExtCreateRegion"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetRegionData", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetRegionData([In] HRGN hrgn, [In] DWORD nCount, [Out] out RGNDATA lpRgnData);

        /// <summary>
        /// <para>
        /// The <see cref="GetRgnBox"/> function retrieves the bounding rectangle of the specified region.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getrgnbox"/>
        /// </para>
        /// </summary>
        /// <param name="hrgn">
        /// A handle to the region.
        /// </param>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that receives the bounding rectangle in logical units.
        /// </param>
        /// <returns>
        /// The return value specifies the region's complexity. It can be one of the following values:
        /// <see cref="NULLREGION"/>: The region is empty.
        /// <see cref="SIMPLEREGION"/>: The region is a single rectangle.
        /// <see cref="COMPLEXREGION"/>: The region is more than a single rectangle.
        /// If the <paramref name="hrgn"/> parameter does not identify a valid region, the return value is zero.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetRgnBox", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags GetRgnBox([In] HRGN hrgn, [Out] out RECT lprc);

        /// <summary>
        /// <para>
        /// The <see cref="OffsetRgn"/> function moves a region by the specified offsets.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-offsetrgn"/>
        /// </para>
        /// </summary>
        /// <param name="hrgn">
        /// Handle to the region to be moved.
        /// </param>
        /// <param name="x">
        /// Specifies the number of logical units to move left or right.
        /// </param>
        /// <param name="y">
        /// Specifies the number of logical units to move up or down.
        /// </param>
        /// <returns>
        /// The return value specifies the type of the resulting region. It can be one of the following values.
        /// <see cref="NULLREGION"/>: The region is empty.
        /// <see cref="SIMPLEREGION"/>: The region is a single rectangle.
        /// <see cref="COMPLEXREGION"/>: The region is more than a single rectangle.
        /// <see cref="ERROR"/>: No region is created.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OffsetRgn", ExactSpelling = true, SetLastError = true)]
        public static extern RegionFlags OffsetRgn([In] HRGN hrgn, [In] int x, [In] int y);

        /// <summary>
        /// <para>
        /// The <see cref="PathToRegion"/> function creates a region from the path that is selected into the specified device context.
        /// The resulting region uses device coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-pathtoregion"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to a device context that contains a closed path.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies a valid region.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// When you no longer need the <see cref="HRGN"/> object call the <see cref="DeleteObject"/> function to delete it.
        /// The device context identified by the hdc parameter must contain a closed path.
        /// After <see cref="PathToRegion"/> converts a path into a region, the system discards the closed path from the specified device context.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PathToRegion", ExactSpelling = true, SetLastError = true)]
        public static extern HRGN PathToRegion([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="PtInRegion"/> function determines whether the specified point is inside the specified region.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-ptinregion"/>
        /// </para>
        /// </summary>
        /// <param name="hrgn">
        /// Handle to the region to be examined.
        /// </param>
        /// <param name="x">
        /// Specifies the x-coordinate of the point in logical units.
        /// </param>
        /// <param name="y">
        /// Specifies the y-coordinate of the point in logical units.
        /// </param>
        /// <returns>
        /// If the specified point is in the region, the return value is <see cref="TRUE"/>.
        /// If the specified point is not in the region, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "PtInRegion", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL PtInRegion([In] HRGN hrgn, [In] int x, [In] int y);

        /// <summary>
        /// <para>
        /// The <see cref="RectInRegion"/> function determines whether any part of the specified rectangle is within the boundaries of a region.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-rectinregion"/>
        /// </para>
        /// </summary>
        /// <param name="hrgn">
        /// Handle to the region.
        /// </param>
        /// <param name="lprect">
        /// Pointer to a <see cref="RECT"/> structure containing the coordinates of the rectangle in logical units.
        /// The lower and right edges of the rectangle are not included.
        /// </param>
        /// <returns>
        /// If any part of the specified rectangle lies within the boundaries of the region, the return value is <see cref="TRUE"/>.
        /// If no part of the specified rectangle lies within the boundaries of the region, the return value is <see cref="FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RectInRegion", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RectInRegion([In] HRGN hrgn, [In] in RECT lprect);

        /// <summary>
        /// <para>
        /// The <see cref="SetRectRgn"/> function converts a region into a rectangular region with the specified coordinates.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setrectrgn"/>
        /// </para>
        /// </summary>
        /// <param name="hrgn">
        /// Handle to the region.
        /// </param>
        /// <param name="left">
        /// Specifies the x-coordinate of the upper-left corner of the rectangular region in logical units.
        /// </param>
        /// <param name="top">
        /// Specifies the y-coordinate of the upper-left corner of the rectangular region in logical units.
        /// </param>
        /// <param name="right">
        /// Specifies the x-coordinate of the lower-right corner of the rectangular region in logical units.
        /// </param>
        /// <param name="bottom">
        /// Specifies the y-coordinate of the lower-right corner of the rectangular region in logical units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The region does not include the lower and right boundaries of the rectangle.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetRectRgn", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetRectRgn([In] HRGN hrgn, [In] int left, [In] int top, [In] int right, [In] int bottom);
    }
}
