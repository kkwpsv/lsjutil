using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
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
        /// The <see cref="CreatePen"/> function creates a logical pen that has the specified style, width, and color.
        /// The pen can subsequently be selected into a device context and used to draw lines and curves.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createpen
        /// </para>
        /// </summary>
        /// <param name="iStyle">
        /// The pen style. It can be any one of the following values.
        /// <see cref="PS_SOLID"/>, <see cref="PS_DASH"/>, <see cref="PS_DOT"/>, <see cref="PS_DASHDOT"/>, <see cref="PS_DASHDOTDOT"/>,
        /// <see cref="PS_NULL"/>, <see cref="PS_INSIDEFRAME"/>
        /// </param>
        /// <param name="cWidth">
        /// The width of the pen, in logical units.
        /// If <paramref name="cWidth"/> is zero, the pen is a single pixel wide, regardless of the current transformation.
        /// <see cref="CreatePen"/> returns a pen with the specified width bit with the <see cref="PS_SOLID"/> style
        /// if you specify a width greater than one for the following styles:
        /// <see cref="PS_DASH"/>, <see cref="PS_DOT"/>, <see cref="PS_DASHDOT"/>, <see cref="PS_DASHDOTDOT"/>.
        /// </param>
        /// <param name="color">
        /// A color reference for the pen color.
        /// To generate a <see cref="COLORREF"/> structure, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle that identifies a logical pen.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// After an application creates a logical pen, it can select that pen into a device context by calling the <see cref="SelectObject"/> function.
        /// After a pen is selected into a device context, it can be used to draw lines and curves.
        /// If the value specified by the <paramref name="cWidth"/> parameter is zero, a line drawn with the created pen always is a single pixel wide
        /// regardless of the current transformation.
        /// If the value specified by <paramref name="cWidth"/> is greater than 1, the <paramref name="iStyle"/> parameter
        /// must be <see cref="PS_NULL"/>, <see cref="PS_SOLID"/>, or <see cref="PS_INSIDEFRAME"/>.
        /// If the value specified by <paramref name="cWidth"/> is greater than 1 and <paramref name="iStyle"/> is <see cref="PS_INSIDEFRAME"/>,
        /// the line associated with the pen is drawn inside the frame of all primitives except polygons and polylines.
        /// If the value specified by <paramref name="cWidth"/> is greater than 1, <paramref name="iStyle"/> is <see cref="PS_INSIDEFRAME"/>,
        /// and the color specified by the <paramref name="color"/> parameter does not match one of the entries in the logical palette,
        /// the system draws lines by using a dithered color.
        /// Dithered colors are not available with solid pens.
        /// When you no longer need the pen, call the <see cref="DeleteObject"/> function to delete it.
        /// ICM: No color management is done at creation. However, color management is performed when the pen is selected into an ICM-enabled device context.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePen", SetLastError = true)]
        public static extern HPEN CreatePen([In]PenStyles iStyle, [In]int cWidth, [In]COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="CreatePenIndirect"/> function creates a logical cosmetic pen that has the style, width, and color specified in a structure.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createpenindirect
        /// </para>
        /// </summary>
        /// <param name="plpen">
        /// Pointer to a <see cref="LOGPEN"/> structure that specifies the pen's style, width, and color.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle that identifies a logical cosmetic pen.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// After an application creates a logical pen, it can select that pen into a device context by calling the <see cref="SelectObject"/> function.
        /// After a pen is selected into a device context, it can be used to draw lines and curves.
        /// When you no longer need the pen, call the <see cref="DeleteObject"/> function to delete it.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePenIndirect", SetLastError = true)]
        public static extern HPEN CreatePenIndirect([MarshalAs(UnmanagedType.LPStruct)][In]LOGPEN plpen);
    }
}
