using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.COLORREF;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.BackgroundModes;
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createpen"/>
        /// </para>
        /// </summary>
        /// <param name="iStyle">
        /// <para>
        /// The pen style. It can be any one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PS_SOLID"/>
        /// </term>
        /// <term>
        /// The pen is solid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_DASH"/>
        /// </term>
        /// <term>
        /// The pen is dashed.
        /// This style is valid only when the pen width is one or less in device units.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_DOT"/>
        /// </term>
        /// <term>
        /// The pen is dotted.
        /// This style is valid only when the pen width is one or less in device units.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_DASHDOT"/>
        /// </term>
        /// <term>
        /// The pen has alternating dashes and dots.
        /// This style is valid only when the pen width is one or less in device units.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_DASHDOTDOT"/>
        /// </term>
        /// <term>
        /// The pen has alternating dashes and double dots.
        /// This style is valid only when the pen width is one or less in device units.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_NULL"/>
        /// </term>
        /// <term>
        /// The pen is invisible.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_INSIDEFRAME"/>
        /// </term>
        /// <term>
        /// The pen is solid.
        /// When this pen is used in any GDI drawing function that takes a bounding rectangle,
        /// the dimensions of the figure are shrunk so that it fits entirely in the bounding rectangle,
        /// taking into account the width of the pen.
        /// This applies only to geometric pens.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="cWidth">
        /// <para>
        /// The width of the pen, in logical units.
        /// If <paramref name="cWidth"/> is zero, the pen is a single pixel wide, regardless of the current transformation.
        /// </para>
        /// <para>
        /// <see cref="CreatePen"/> returns a pen with the specified width but with the <see cref="PS_SOLID"/> style
        /// if you specify a width greater than one for the following styles:
        /// <see cref="PS_DASH"/>, <see cref="PS_DOT"/>, <see cref="PS_DASHDOT"/>, <see cref="PS_DASHDOTDOT"/>.
        /// </para>
        /// </param>
        /// <param name="color">
        /// A color reference for the pen color.
        /// To generate a <see cref="COLORREF"/> structure, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle that identifies a logical pen.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// After an application creates a logical pen,
        /// it can select that pen into a device context by calling the <see cref="SelectObject"/> function.
        /// After a pen is selected into a device context, it can be used to draw lines and curves.
        /// </para>
        /// <para>
        /// If the value specified by the <paramref name="cWidth"/> parameter is zero,
        /// a line drawn with the created pen always is a single pixel wide regardless of the current transformation.
        /// </para>
        /// <para>
        /// If the value specified by <paramref name="cWidth"/> is greater than 1
        /// the <paramref name="iStyle"/> parameter must be <see cref="PS_NULL"/>, <see cref="PS_SOLID"/>, or <see cref="PS_INSIDEFRAME"/>.
        /// </para>
        /// <para>
        /// If the value specified by <paramref name="cWidth"/> is greater than 1 and <paramref name="iStyle"/> is <see cref="PS_INSIDEFRAME"/>,
        /// the line associated with the pen is drawn inside the frame of all primitives except polygons and polylines.
        /// </para>
        /// <para>
        /// If the value specified by <paramref name="cWidth"/> is greater than 1, <paramref name="iStyle"/> is <see cref="PS_INSIDEFRAME"/>,
        /// and the color specified by the <paramref name="color"/> parameter does not match one of the entries in the logical palette,
        /// the system draws lines by using a dithered color. Dithered colors are not available with solid pens.
        /// </para>
        /// <para>
        /// When using an <paramref name="iStyle"/> parameter of <see cref="PS_DASH"/>, <see cref="PS_DOT"/>,
        /// <see cref="PS_DASHDOT"/> or <see cref="PS_DASHDOTDOT"/>, in order to make the gaps between the dashes or dots transparent,
        /// use <see cref="SetBkMode"/> to set the mode to <see cref="TRANSPARENT"/>.
        /// </para>
        /// <para>
        /// When you no longer need the pen, call the <see cref="DeleteObject"/> function to delete it.
        /// </para>
        /// <para>
        /// ICM: No color management is done at creation.
        /// However, color management is performed when the pen is selected into an ICM-enabled device context.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePen", ExactSpelling = true, SetLastError = true)]
        public static extern HPEN CreatePen([In] PenStyles iStyle, [In] int cWidth, [In] COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="CreatePenIndirect"/> function creates a logical cosmetic pen that has the style, width, and color specified in a structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createpenindirect"/>
        /// </para>
        /// </summary>
        /// <param name="plpen">
        /// Pointer to a <see cref="LOGPEN"/> structure that specifies the pen's style, width, and color.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle that identifies a logical cosmetic pen.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// After an application creates a logical pen,
        /// it can select that pen into a device context by calling the <see cref="SelectObject"/> function.
        /// After a pen is selected into a device context, it can be used to draw lines and curves.
        /// </para>
        /// <para>
        /// When you no longer need the pen, call the <see cref="DeleteObject"/> function to delete it.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePenIndirect", ExactSpelling = true, SetLastError = true)]
        public static extern HPEN CreatePenIndirect([In] in LOGPEN plpen);

        /// <summary>
        /// <para>
        /// The <see cref="ExtCreatePen"/> function creates a logical cosmetic or geometric pen
        /// that has the specified style, width, and brush attributes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-extcreatepen"/>
        /// </para>
        /// </summary>
        /// <param name="iPenStyle">
        /// <para>
        /// A combination of type, style, end cap, and join attributes.
        /// The values from each category are combined by using the bitwise OR operator ( | ).
        /// </para>
        /// <para>
        /// The pen type can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PS_GEOMETRIC"/>
        /// </term>
        /// <term>
        /// The pen is geometric.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_COSMETIC"/>
        /// </term>
        /// <term>
        /// The pen is cosmetic.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The pen style can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PS_ALTERNATE"/>
        /// </term>
        /// <term>
        /// The pen sets every other pixel.
        /// (This style is applicable only for cosmetic pens.)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_SOLID"/>
        /// </term>
        /// <term>
        /// The pen is solid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_DASH"/>
        /// </term>
        /// <term>
        /// The pen is dashed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_DOT"/>
        /// </term>
        /// <term>
        /// The pen is dotted.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_DASHDOT"/>
        /// </term>
        /// <term>
        /// The pen has alternating dashes and dots.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_DASHDOTDOT"/>
        /// </term>
        /// <term>
        /// The pen has alternating dashes and double dots.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_NULL"/>
        /// </term>
        /// <term>
        /// The pen is invisible.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_USERSTYLE"/>
        /// </term>
        /// <term>
        /// The pen uses a styling array supplied by the user.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_INSIDEFRAME"/>
        /// </term>
        /// <term>
        /// The pen is solid.
        /// When this pen is used in any GDI drawing function that takes a bounding rectangle,
        /// the dimensions of the figure are shrunk so that it fits entirely in the bounding rectangle,
        /// taking into account the width of the pen. This applies only to geometric pens.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The end cap is only specified for geometric pens. The end cap can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PS_ENDCAP_ROUND"/>
        /// </term>
        /// <term>
        /// End caps are round.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_ENDCAP_SQUARE"/>
        /// </term>
        /// <term>
        /// End caps are square.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_ENDCAP_FLAT"/>
        /// </term>
        /// <term>
        /// End caps are flat.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The join is only specified for geometric pens. The join can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="PS_JOIN_BEVEL"/>
        /// </term>
        /// <term>
        /// Joins are beveled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_JOIN_MITER"/>
        /// </term>
        /// <term>
        /// Joins are mitered when they are within the current limit set by the <see cref="SetMiterLimit"/> function.
        /// If it exceeds this limit, the join is beveled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PS_JOIN_ROUND"/>
        /// </term>
        /// <term>
        /// Joins are round.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
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
        /// <para>
        /// The length, in <see cref="DWORD"/> units, of the <paramref name="pstyle"/> array.
        /// This value must be zero if <paramref name="iPenStyle"/> is not <see cref="PS_USERSTYLE"/>.
        /// </para>
        /// <para>
        /// The style count is limited to 16.
        /// </para>
        /// </param>
        /// <param name="pstyle">
        /// <para>
        /// A pointer to an array.
        /// The first value specifies the length of the first dash in a user-defined style,
        /// the second value specifies the length of the first space, and so on.
        /// This pointer must be <see langword="null"/> if <paramref name="iPenStyle"/> is not <see cref="PS_USERSTYLE"/>.
        /// </para>
        /// <para>
        /// If the <paramref name="pstyle"/> array is exceeded during line drawing, the pointer is reset to the beginning of the array.
        /// When this happens and <paramref name="cStyle"/> is an even number, the pattern of dashes and spaces repeats.
        /// However, if <paramref name="cStyle"/> is odd, the pattern reverses when the pointer is reset
        /// -- the first element of <paramref name="pstyle"/> now refers to spaces, the second refers to dashes, and so forth.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle that identifies a logical pen.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A geometric pen can have any width and can have any of the attributes of a brush, such as dithers and patterns.
        /// A cosmetic pen can only be a single pixel wide and must be a solid color, but cosmetic pens are generally faster than geometric pens.
        /// </para>
        /// <para>
        /// The width of a geometric pen is always specified in world units.
        /// The width of a cosmetic pen is always 1.
        /// </para>
        /// <para>
        /// End caps and joins are only specified for geometric pens.
        /// </para>
        /// <para>
        /// After an application creates a logical pen, it can select that pen into a device context by calling the <see cref="SelectObject"/> function.
        /// After a pen is selected into a device context, it can be used to draw lines and curves.
        /// </para>
        /// <para>
        /// If <paramref name="iPenStyle"/> is <see cref="PS_COSMETIC"/> and <see cref="PS_USERSTYLE"/>,
        /// the entries in the <paramref name="pstyle"/> array specify lengths of dashes and spaces in style units.
        /// A style unit is defined by the device where the pen is used to draw a line.
        /// </para>
        /// <para>
        /// If <paramref name="iPenStyle"/> is <see cref="PS_GEOMETRIC"/> and <see cref="PS_USERSTYLE"/>,
        /// the entries in the <paramref name="pstyle"/> array specify lengths of dashes and spaces in logical units.
        /// </para>
        /// <para>
        /// If <paramref name="iPenStyle"/> is <see cref="PS_ALTERNATE"/>, the style unit is ignored and every other pixel is set.
        /// </para>
        /// <para>
        /// If the <see cref="LOGBRUSH.lbStyle"/> member of the <see cref="LOGBRUSH"/> structure
        /// pointed to by <paramref name="plbrush"/> is <see cref="BS_PATTERN"/>,
        /// the bitmap pointed to by the <see cref="LOGBRUSH.lbHatch"/> member of that structure cannot be a DIB section.
        /// A DIB section is a bitmap created by <see cref="CreateDIBSection"/>.
        /// If that bitmap is a DIB section, the <see cref="ExtCreatePen"/> function fails.
        /// </para>
        /// <para>
        /// When an application no longer requires a specified pen,
        /// it should call the <see cref="DeleteObject"/> function to delete the pen.
        /// </para>
        /// <para>
        /// ICM: No color management is done at pen creation.
        /// However, color management is performed when the pen is selected into an ICM-enabled device context.
        /// </para>
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtCreatePen", ExactSpelling = true, SetLastError = true)]
        public static extern HPEN ExtCreatePen([In] PenStyles iPenStyle, [In] DWORD cWidth, [In] in LOGBRUSH plbrush, [In] DWORD cStyle, [In] PenStyles[] pstyle);
    }
}
