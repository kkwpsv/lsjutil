using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.COLORREF;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.BrushStyles;
using static Lsj.Util.Win32.Enums.PenStyles;
using static Lsj.Util.Win32.Enums.StockObjectIndexes;

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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePen", ExactSpelling = true, SetLastError = true)]
        public static extern HPEN CreatePen([In] PenStyles iStyle, [In] int cWidth, [In] COLORREF color);

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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePenIndirect", ExactSpelling = true, SetLastError = true)]
        public static extern HPEN CreatePenIndirect([In] in LOGPEN plpen);

        /// <summary>
        /// <para>
        /// The <see cref="ExtCreatePen"/> function creates a logical cosmetic or geometric pen
        /// that has the specified style, width, and brush attributes.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-extcreatepen
        /// </para>
        /// </summary>
        /// <param name="iPenStyle">
        /// A combination of type, style, end cap, and join attributes.
        /// The values from each category are combined by using the bitwise OR operator ( | ).
        /// The pen type can be one of the following values.
        /// <see cref="PS_GEOMETRIC"/>, <see cref="PS_COSMETIC"/>
        /// The pen style can be one of the following values.
        /// <see cref="PS_ALTERNATE"/>, <see cref="PS_SOLID"/>, <see cref="PS_DASH"/>, <see cref="PS_DOT"/>, <see cref="PS_DASHDOT"/>,
        /// <see cref="PS_DASHDOTDOT"/>, <see cref="PS_NULL"/>, <see cref="PS_USERSTYLE"/>
        /// The end cap is only specified for geometric pens. The end cap can be one of the following values.
        /// <see cref="PS_ENDCAP_ROUND"/>, <see cref="PS_ENDCAP_SQUARE"/>, <see cref="PS_ENDCAP_FLAT"/>
        /// The join is only specified for geometric pens. The join can be one of the following values.
        /// <see cref="PS_JOIN_BEVEL"/>, <see cref="PS_JOIN_MITER"/>, <see cref="PS_JOIN_ROUND"/>
        /// </param>
        /// <param name="cWidth">
        /// The width of the pen.
        /// If the <paramref name="iPenStyle"/> parameter is <see cref="PS_GEOMETRIC"/>, the width is given in logical units.
        /// If <paramref name="iPenStyle"/> is <see cref="PS_COSMETIC"/>, the width must be set to 1.
        /// </param>
        /// <param name="plbrush">
        /// A pointer to a <see cref="LOGBRUSH"/> structure.
        /// If <paramref name="iPenStyle"/> is <see cref="PS_COSMETIC"/>,
        /// the <see cref="LOGBRUSH.lbColor"/> member specifies the color of the pen
        /// and the <see cref="LOGBRUSH.lbStyle"/> member must be set to <see cref="LOGBRUSH"/>.
        /// If <paramref name="iPenStyle"/> is <see cref="PS_GEOMETRIC"/>, all members must be used to specify the brush attributes of the pen.
        /// </param>
        /// <param name="cStyle">
        /// The length, in <see cref="DWORD"/> units, of the <paramref name="pstyle"/> array.
        /// This value must be zero if <paramref name="iPenStyle"/> is not <see cref="PS_USERSTYLE"/>.
        /// The style count is limited to 16.
        /// </param>
        /// <param name="pstyle">
        /// A pointer to an array.
        /// The first value specifies the length of the first dash in a user-defined style,
        /// the second value specifies the length of the first space, and so on.
        /// This pointer must be <see langword="null"/> if <paramref name="iPenStyle"/> is not <see cref="PS_USERSTYLE"/>.
        /// If the <paramref name="pstyle"/> array is exceeded during line drawing, the pointer is reset to the beginning of the array.
        /// When this happens and <paramref name="cStyle"/> is an even number, the pattern of dashes and spaces repeats.
        /// However, if <paramref name="cStyle"/> is odd, the pattern reverses when the pointer is reset
        /// -- the first element of <paramref name="pstyle"/> now refers to spaces, the second refers to dashes, and so forth.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle that identifies a logical pen.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// A geometric pen can have any width and can have any of the attributes of a brush, such as dithers and patterns.
        /// A cosmetic pen can only be a single pixel wide and must be a solid color, but cosmetic pens are generally faster than geometric pens.
        /// The width of a geometric pen is always specified in world units. The width of a cosmetic pen is always 1.
        /// End caps and joins are only specified for geometric pens.
        /// After an application creates a logical pen, it can select that pen into a device context by calling the <see cref="SelectObject"/> function.
        /// After a pen is selected into a device context, it can be used to draw lines and curves.
        /// If <paramref name="iPenStyle"/> is <see cref="PS_COSMETIC"/> and <see cref="PS_USERSTYLE"/>,
        /// the entries in the <paramref name="pstyle"/> array specify lengths of dashes and spaces in style units.
        /// A style unit is defined by the device where the pen is used to draw a line.
        /// If <paramref name="iPenStyle"/> is <see cref="PS_GEOMETRIC"/> and <see cref="PS_USERSTYLE"/>,
        /// the entries in the <paramref name="pstyle"/> array specify lengths of dashes and spaces in logical units.
        /// If <paramref name="iPenStyle"/> is <see cref="PS_ALTERNATE"/>, the style unit is ignored and every other pixel is set.
        /// If the <see cref="LOGBRUSH.lbStyle"/> member of the <see cref="LOGBRUSH"/> structure pointed to by lplb is <see cref="BS_PATTERN"/>,
        /// the bitmap pointed to by the lbHatch member of that structure cannot be a DIB section.
        /// A DIB section is a bitmap created by <see cref="CreateDIBSection"/>.
        /// If that bitmap is a DIB section, the <see cref="ExtCreatePen"/> function fails.
        /// When an application no longer requires a specified pen, it should call the <see cref="DeleteObject"/> function to delete the pen.
        /// ICM: No color management is done at pen creation.
        /// However, color management is performed when the pen is selected into an ICM-enabled device context.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtCreatePen", ExactSpelling = true, SetLastError = true)]
        public static extern HPEN ExtCreatePen([In] PenStyles iPenStyle, [In] DWORD cWidth, [In] in LOGBRUSH plbrush,
            [In] DWORD cStyle, [In] PenStyles[] pstyle);

        /// <summary>
        /// <para>
        /// The <see cref="GetDCPenColor"/> function retrieves the current pen color for the specified device context (DC).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getdcpencolor
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC whose brush color is to be returned.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a <see cref="COLORREF"/> value for the current DC pen color.
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </returns>
        /// <remarks>
        /// For information on setting the pen color, see <see cref="SetDCPenColor"/>.
        /// ICM: Color management is performed if ICM is enabled.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDCPenColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF GetDCPenColor([In] HDC hdc);

        /// <summary>
        /// <para>
        /// <see cref="SetDCPenColor"/> function sets the current device context (DC) pen color to the specified color value.
        /// If the device cannot represent the specified color value, the color is set to the nearest physical color.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setdcpencolor
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <param name="color">
        /// The new pen color.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the previous DC pen color as a <see cref="COLORREF"/> value.
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </returns>
        /// <remarks>
        /// The function returns the previous <see cref="DC_PEN"/> color, even if the stock pen <see cref="DC_PEN"/> is not selected in the DC;
        /// however, this will not be used in drawing operations until the stock <see cref="DC_PEN"/> is selected in the DC.
        /// The <see cref="GetStockObject"/> function with an argument of <see cref="DC_BRUSH"/> or <see cref="DC_PEN"/>
        /// can be used interchangeably with the <see cref="SetDCPenColor"/> and <see cref="SetDCBrushColor"/> functions.
        /// ICM: Color management is performed if ICM is enabled.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDCPenColor", ExactSpelling = true, SetLastError = true)]
        public static extern COLORREF SetDCPenColor([In] HDC hdc, [In] COLORREF color);
    }
}
