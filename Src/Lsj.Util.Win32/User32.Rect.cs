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
    }
}
