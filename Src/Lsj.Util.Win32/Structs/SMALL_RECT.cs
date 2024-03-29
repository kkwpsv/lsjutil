﻿using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines the coordinates of the upper left and lower right corners of a rectangle.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/console/small-rect-str"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by console functions to specify rectangular areas of console screen buffers,
    /// where the coordinates specify the rows and columns of screen-buffer character cells.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SMALL_RECT
    {
        /// <summary>
        /// The x-coordinate of the upper left corner of the rectangle.
        /// </summary>
        public SHORT Left;

        /// <summary>
        /// The y-coordinate of the upper left corner of the rectangle.
        /// </summary>
        public SHORT Top;

        /// <summary>
        /// The x-coordinate of the lower right corner of the rectangle.
        /// </summary>
        public SHORT Right;

        /// <summary>
        /// The y-coordinate of the lower right corner of the rectangle.
        /// </summary>
        public SHORT Bottom;
    }
}
