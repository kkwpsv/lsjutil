using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public partial class User32
    {
        /// <summary>
        /// <para>
        /// The <see cref="CopyRect"/> function copies the coordinates of one rectangle to another.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-copyrect
        /// </para>
        /// </summary>
        /// <param name="lprcDst">
        /// Pointer to the <see cref="RECT"/> structure that receives the logical coordinates of the source rectangle.
        /// </param>
        /// <param name="lprcSrc">
        /// Pointer to the <see cref="RECT"/> structure whose coordinates are to be copied in logical units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CopyRect", SetLastError = true)]
        public static extern BOOL CopyRect([In][Out]ref RECT lprcDst, [In]in RECT lprcSrc);

        /// <summary>
        /// <para>
        /// The <see cref="EqualRect"/> function determines whether the two specified rectangles are equal
        /// by comparing the coordinates of their upper-left and lower-right corners.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-equalrect
        /// </para>
        /// </summary>
        /// <param name="lprc1">
        /// Pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the first rectangle.
        /// </param>
        /// <param name="lprc2">
        /// Pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the second rectangle.
        /// </param>
        /// <returns>
        /// If the two rectangles are identical, the return value is <see cref="TRUE"/>.
        /// If the two rectangles are not identical, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="EqualRect"/> function does not treat empty rectangles as equal if their coordinates are different.
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EqualRect", SetLastError = true)]
        public static extern BOOL EqualRect([In]in RECT lprc1, [MarshalAs(UnmanagedType.LPStruct)][In]RECT lprc2);

        /// <summary>
        /// <para>
        /// The <see cref="IntersectRect"/> function calculates the intersection of two source rectangles and
        /// places the coordinates of the intersection rectangle into the destination rectangle.
        /// If the source rectangles do not intersect, an empty rectangle (in which all coordinates are set to zero) is placed into the destination rectangle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-intersectrect
        /// </para>
        /// </summary>
        /// <param name="lprcDst">
        /// A pointer to the <see cref="RECT"/> structure that is to receive the intersection of the rectangles pointed to
        /// by the <paramref name="lprcSrc1"/> and <paramref name="lprcSrc2"/> parameters.
        /// This parameter cannot be <see langword="null"/>.
        /// </param>
        /// <param name="lprcSrc1">
        /// A pointer to the <see cref="RECT"/> structure that contains the first source rectangle.
        /// </param>
        /// <param name="lprcSrc2">
        /// A pointer to the <see cref="RECT"/> structure that contains the second source rectangle.
        /// </param>
        /// <returns>
        /// If the rectangles intersect, the return value is <see cref="TRUE"/>.
        /// If the rectangles do not intersect, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IntersectRect", SetLastError = true)]
        public static extern BOOL IntersectRect([In][Out]ref RECT lprcDst, [In]in RECT lprcSrc1, [In]in RECT lprcSrc2);

        /// <summary>
        /// <para>
        /// The <see cref="InflateRect"/> function increases or decreases the width and height of the specified rectangle.
        /// The <see cref="InflateRect"/> function adds -<paramref name="dx"/> units to the left end and <paramref name="dx"/> to the right
        /// end of the rectangle and -<paramref name="dy"/> units to the top and <paramref name="dy"/> to the bottom.
        /// The <paramref name="dx"/> and <paramref name="dy"/> parameters are signed values; positive values increase the width and height,
        /// and negative values decrease them.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-inflaterect
        /// </para>
        /// </summary>
        /// <param name="lprc">
        /// A pointer to the <see cref="RECT"/> structure that increases or decreases in size.
        /// </param>
        /// <param name="dx">
        /// The amount to increase or decrease the rectangle width.
        /// This parameter must be negative to decrease the width.
        /// </param>
        /// <param name="dy">
        /// The amount to increase or decrease the rectangle height.
        /// This parameter must be negative to decrease the height.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "InflateRect", SetLastError = true)]
        public static extern BOOL InflateRect([In][Out]RECT lprc, [In]int dx, [In]int dy);

        /// <summary>
        /// <para>
        /// The <see cref="IsRectEmpty"/> function determines whether the specified rectangle is empty.
        /// An empty rectangle is one that has no area; that is, the coordinate of the right side is less than or equal to the coordinate of the left side,
        /// or the coordinate of the bottom side is less than or equal to the coordinate of the top side.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-isrectempty
        /// </para>
        /// </summary>
        /// <param name="lprc">
        /// Pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the rectangle.
        /// </param>
        /// <returns>
        /// If the rectangle is empty, the return value is <see cref="TRUE"/>.
        /// If the rectangle is not empty, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsRectEmpty", SetLastError = true)]
        public static extern BOOL IsRectEmpty([In]in RECT lprc);

        /// <summary>
        /// <para>
        /// The <see cref="OffsetRect"/> function moves the specified rectangle by the specified offsets.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-offsetrect
        /// </para>
        /// </summary>
        /// <param name="lprc">
        /// Pointer to a <see cref="RECT"/> structure that contains the logical coordinates of the rectangle to be moved.
        /// </param>
        /// <param name="dx">
        /// Specifies the amount to move the rectangle left or right.
        /// This parameter must be a negative value to move the rectangle to the left.
        /// </param>
        /// <param name="dy">
        /// Specifies the amount to move the rectangle up or down.
        /// This parameter must be a negative value to move the rectangle up.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OffsetRect", SetLastError = true)]
        public static extern BOOL OffsetRect([In][Out]ref RECT lprc, [In]int dx, [In]int dy);

        /// <summary>
        /// <para>
        /// The <see cref="PtInRect"/> function determines whether the specified point lies within the specified rectangle.
        /// A point is within a rectangle if it lies on the left or top side or is within all four sides.
        /// A point on the right or bottom side is considered outside the rectangle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-ptinrect
        /// </para>
        /// </summary>
        /// <param name="lprc">
        /// A pointer to a <see cref="RECT"/> structure that contains the specified rectangle.
        /// </param>
        /// <param name="pt">
        /// A <see cref="POINT"/> structure that contains the specified point.
        /// </param>
        /// <returns>
        /// If the specified point lies within the rectangle, the return value is <see cref="TRUE"/>.
        /// If the specified point does not lie within the rectangle, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The rectangle must be normalized before <see cref="PtInRect"/> is called.
        /// That is, lprc.right must be greater than lprc.left and lprc.bottom must be greater than lprc.top.
        /// If the rectangle is not normalized, a point is never considered inside of the rectangle.
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "PtInRect", SetLastError = true)]
        public static extern BOOL PtInRect([In]in RECT lprc, [In]POINT pt);

        /// <summary>
        /// <para>
        /// The <see cref="SetRect"/> function sets the coordinates of the specified rectangle.
        /// This is equivalent to assigning the left, top, right, and bottom arguments to the appropriate members of the <see cref="RECT"/> structure.
        /// </para>
        /// </summary>
        /// <param name="lprc">
        /// Pointer to the <see cref="RECT"/> structure that contains the rectangle to be set.
        /// </param>
        /// <param name="xLeft">
        /// Specifies the x-coordinate of the rectangle's upper-left corner.
        /// </param>
        /// <param name="yTop">
        /// Specifies the y-coordinate of the rectangle's upper-left corner.
        /// </param>
        /// <param name="xRight">
        /// Specifies the x-coordinate of the rectangle's lower-right corner.
        /// </param>
        /// <param name="yBottom">
        /// Specifies the y-coordinate of the rectangle's lower-right corner.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetRect", SetLastError = true)]
        public static extern BOOL SetRect([In][Out]ref RECT lprc, [In]int xLeft, [In]int yTop, [In]int xRight, [In]int yBottom);

        /// <summary>
        /// <para>
        /// The <see cref="SetRectEmpty"/> function creates an empty rectangle in which all coordinates are set to zero.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setrectempty
        /// </para>
        /// </summary>
        /// <param name="lprc">
        /// Pointer to the <see cref="RECT"/> structure that contains the coordinates of the rectangle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetRectEmpty", SetLastError = true)]
        public static extern BOOL SetRectEmpty([In][Out]ref RECT lprc);

        /// <summary>
        /// <para>
        /// The <see cref="SubtractRect"/> function determines the coordinates of a rectangle formed by subtracting one rectangle from another.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-subtractrect
        /// </para>
        /// </summary>
        /// <param name="lprcDst">
        /// A pointer to a <see cref="RECT"/> structure that receives the coordinates of the rectangle determined
        /// by subtracting the rectangle pointed to by <paramref name="lprcSrc2"/> from the rectangle pointed to by <paramref name="lprcSrc1"/>.
        /// </param>
        /// <param name="lprcSrc1">
        /// A pointer to a <see cref="RECT"/> structure from which the function subtracts the rectangle pointed to by <paramref name="lprcSrc2"/>.
        /// </param>
        /// <param name="lprcSrc2">
        /// A pointer to a <see cref="RECT"/> structure that the function subtracts from the rectangle pointed to by <paramref name="lprcSrc1"/>.
        /// </param>
        /// <returns>
        /// If the resulting rectangle is empty, the return value is <see cref="FALSE"/>.
        /// If the resulting rectangle is not empty, the return value is <see cref="TRUE"/>.
        /// </returns>
        /// <remarks>
        /// The function only subtracts the rectangle specified by <paramref name="lprcSrc2"/> from the rectangle specified by <paramref name="lprcSrc1"/>
        /// when the rectangles intersect completely in either the x- or y-direction.
        /// For example, if *<paramref name="lprcSrc1"/> has the coordinates (10,10,100,100)
        /// and *<paramref name="lprcSrc2"/> has the coordinates (50,50,150,150),
        /// the function sets the coordinates of the rectangle pointed to by <paramref name="lprcDst"/> to (10,10,100,100).
        /// If *<paramref name="lprcSrc1"/> has the coordinates (10,10,100,100) and *<paramref name="lprcSrc2"/> has the coordinates (50,10,150,150),
        /// however, the function sets the coordinates of the rectangle pointed to by <paramref name="lprcDst"/> to (10,10,50,100).
        /// In other words, the resulting rectangle is the bounding box of the geometric difference.
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SubtractRect", SetLastError = true)]
        public static extern BOOL SubtractRect([In][Out]ref RECT lprcDst, [In]in RECT lprcSrc1, [In]in RECT lprcSrc2);

        /// <summary>
        /// <para>
        /// The <see cref="UnionRect"/> function creates the union of two rectangles.
        /// The union is the smallest rectangle that contains both source rectangles.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-unionrect
        /// </para>
        /// </summary>
        /// <param name="lprcDst">
        /// A pointer to the <see cref="RECT"/> structure that will receive a rectangle containing the rectangles
        /// pointed to by the <paramref name="lprcSrc1"/> and <paramref name="lprcSrc2"/> parameters.
        /// </param>
        /// <param name="lprcSrc1">
        /// A pointer to the <see cref="RECT"/> structure that contains the first source rectangle.
        /// </param>
        /// <param name="lprcSrc2">
        /// A pointer to the <see cref="RECT"/> structure that contains the second source rectangle.
        /// </param>
        /// <returns>
        /// If the specified structure contains a nonempty rectangle, the return value is <see cref="TRUE"/>.
        /// If the specified structure does not contain a nonempty rectangle, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The system ignores the dimensions of an empty rectangle that is, a rectangle in which all coordinates are set to zero,
        /// so that it has no height or no width.
        /// Because applications can use rectangles for different purposes, the rectangle functions do not use an explicit unit of measure.
        /// Instead, all rectangle coordinates and dimensions are given in signed, logical values.
        /// The mapping mode and the function in which the rectangle is used determine the units of measure.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnionRect", SetLastError = true)]
        public static extern BOOL UnionRect([In][Out]ref RECT lprcDst, [In]in RECT lprcSrc1, [In]in RECT lprcSrc2);
    }
}
