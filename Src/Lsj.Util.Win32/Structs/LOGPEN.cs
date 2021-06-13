using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.PenStyles;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="LOGPEN"/> structure defines the style, width, and color of a pen.
    /// The <see cref="CreatePenIndirect"/> function uses the <see cref="LOGPEN"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-logpen"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the width of the pen is greater than 1 and the pen style is <see cref="PS_INSIDEFRAME"/>,
    /// the line is drawn inside the frame of all GDI objects except polygons and polylines.
    /// If the pen color does not match an available RGB value, the pen is drawn with a logical (dithered) color.
    /// If the pen width is less than or equal to 1, the <see cref="PS_INSIDEFRAME"/> style is identical to the <see cref="PS_SOLID"/> style.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOGPEN
    {
        /// <summary>
        /// The pen style, which can be one of the following values.
        /// </summary>
        public PenStyles lopnStyle;

        /// <summary>
        /// The <see cref="POINT"/> structure that contains the pen width, in logical units.
        /// If the pointer member is NULL, the pen is one pixel wide on raster devices.
        /// The <see cref="POINT.y"/> member in the <see cref="POINT"/> structure for <see cref="lopnWidth"/> is not used.
        /// </summary>
        public POINT lopnWidth;

        /// <summary>
        /// The pen color.
        /// To generate a <see cref="COLORREF"/> structure, use the <see cref="RGB"/> macro.
        /// </summary>
        public COLORREF lopnColor;
    }
}
