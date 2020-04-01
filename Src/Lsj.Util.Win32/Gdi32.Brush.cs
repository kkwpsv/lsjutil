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
        /// The <see cref="CreateBrushIndirect"/> function creates a logical brush that has the specified style, color, and pattern.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createbrushindirect
        /// </para>
        /// </summary>
        /// <param name="plbrush">
        /// A pointer to a <see cref="LOGBRUSH"/> structure that contains information about the brush.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies a logical brush.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// A brush is a bitmap that the system uses to paint the interiors of filled shapes.
        /// After an application creates a brush by calling <see cref="CreateBrushIndirect"/>,
        /// it can select it into any device context by calling the <see cref="SelectObject"/> function.
        /// A brush created by using a monochrome bitmap (one color plane, one bit per pixel) is drawn using the current text and background colors.
        /// Pixels represented by a bit set to 0 are drawn with the current text color;
        /// pixels represented by a bit set to 1 are drawn with the current background color.
        /// When you no longer need the brush, call the <see cref="DeleteObject"/> function to delete it.
        /// ICM: No color is done at brush creation. However, color management is performed when the brush is selected into an ICM-enabled device context.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDIBPatternBrush", ExactSpelling = true, SetLastError = true)]
        public static extern HBRUSH CreateBrushIndirect([In]in LOGBRUSH plbrush);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDIBPatternBrush"/> function creates a logical brush
        /// that has the pattern specified by the specified device-independent bitmap (DIB).
        /// The brush can subsequently be selected into any device context that is associated with a device that supports raster operations.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createdibpatternbrush
        /// </para>
        /// </summary>
        /// <param name="h">
        /// A handle to a global memory object containing a packed DIB, which consists of a <see cref="BITMAPINFO"/> structure immediately
        /// followed by an array of bytes defining the pixels of the bitmap.
        /// </param>
        /// <param name="iUsage">
        /// Specifies whether the <see cref="bmiColors"/> member of the <see cref="BITMAPINFO"/> structure is initialized and,
        /// if so, whether this member contains explicit red, green, blue (RGB) values or indexes into a logical palette.
        /// The <paramref name="iUsage"/> parameter must be one of the following values.
        /// <see cref="DIB_PAL_COLORS"/>:
        /// A color table is provided and consists of an array of 16-bit indexes into the logical palette of
        /// the device context into which the brush is to be selected.
        /// <see cref="DIB_RGB_COLORS"/>:
        /// A color table is provided and contains literal RGB values.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies a logical brush.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When an application selects a two-color DIB pattern brush into a monochrome device context,
        /// the system does not acknowledge the colors specified in the DIB;
        /// instead, it displays the pattern brush using the current background and foreground colors of the device context.
        /// Pixels mapped to the first color of the DIB (offset 0 in the DIB color table) are displayed using the foreground color;
        /// pixels mapped to the second color (offset 1 in the color table) are displayed using the background color.
        /// When you no longer need the brush, call the <see cref="DeleteObject"/> function to delete it.
        /// ICM: No color is done at brush creation. However, color management is performed when the brush is selected into an ICM-enabled device context.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the CreateDIBPatternBrushPt function.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDIBPatternBrush", ExactSpelling = true, SetLastError = true)]
        public static extern HBRUSH CreateDIBPatternBrush([In]HGLOBAL h, [In]UINT iUsage);

        /// <summary>
        /// <para>
        /// The <see cref="CreateSolidBrush"/> function creates a logical brush that has the specified solid color.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createsolidbrush
        /// </para>
        /// </summary>
        /// <param name="color">
        /// The color of the brush.
        /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies a logical brush.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the HBRUSH object, call the <see cref="DeleteObject"/> function to delete it.
        /// A solid brush is a bitmap that the system uses to paint the interiors of filled shapes.
        /// After an application creates a brush by calling <see cref="CreateSolidBrush"/>,
        /// it can select that brush into any device context by calling the <see cref="SelectObject"/> function.
        /// To paint with a system color brush, an application should use <see cref="GetSysColorBrush"/> (nIndex)
        /// instead of <see cref="CreateSolidBrush"/>(<see cref="GetSysColor"/>(nIndex)),
        /// because <see cref="GetSysColorBrush"/> returns a cached brush instead of allocating a new one.
        /// ICM: No color management is done at brush creation.
        /// However, color management is performed when the brush is selected into an ICM-enabled device context.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateSolidBrush", ExactSpelling = true, SetLastError = true)]
        public static extern HBRUSH CreateSolidBrush([In]COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="CreateHatchBrush"/> function creates a logical brush that has the specified hatch pattern and color.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createhatchbrush
        /// </para>
        /// </summary>
        /// <param name="iHatch">
        /// The hatch style of the brush. This parameter can be one of the following values.
        /// <see cref="HS_BDIAGONAL"/>, <see cref="HS_CROSS"/>, <see cref="HS_DIAGCROSS"/>, <see cref="HS_FDIAGONAL"/>,
        /// <see cref="HS_HORIZONTAL"/>, <see cref="HS_VERTICAL"/>
        /// </param>
        /// <param name="color">
        /// The foreground color of the brush that is used for the hatches.
        /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies a logical brush.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// A brush is a bitmap that the system uses to paint the interiors of filled shapes.
        /// After an application creates a brush by calling <see cref="CreateHatchBrush"/>,
        /// it can select that brush into any device context by calling the <see cref="SelectObject"/> function.
        /// It can also call <see cref="SetBkMode"/> to affect the rendering of the brush.
        /// If an application uses a hatch brush to fill the backgrounds of both a parent and a child window with matching color,
        /// you must set the brush origin before painting the background of the child window.
        /// You can do this by calling the <see cref="SetBrushOrgEx"/> function.
        /// Your application can retrieve the current brush origin by calling the <see cref="GetBrushOrgEx"/> function.
        /// When you no longer need the brush, call the <see cref="DeleteObject"/> function to delete it.
        /// ICM: No color is defined at brush creation. However, color management is performed when the brush is selected into an ICM-enabled device context.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateHatchBrush", ExactSpelling = true, SetLastError = true)]
        public static extern HBRUSH CreateHatchBrush([In]HatchStyles iHatch, [In]COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="CreatePatternBrush"/> function creates a logical brush with the specified bitmap pattern.
        /// The bitmap can be a DIB section bitmap, which is created by the <see cref="CreateDIBSection"/> function, or it can be a device-dependent bitmap.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createpatternbrush
        /// </para>
        /// </summary>
        /// <param name="hbm">
        /// A handle to the bitmap to be used to create the logical brush.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies a logical brush.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// A pattern brush is a bitmap that the system uses to paint the interiors of filled shapes.
        /// After an application creates a brush by calling <see cref="CreatePatternBrush"/>,
        /// it can select that brush into any device context by calling the <see cref="SelectObject"/> function.
        /// You can delete a pattern brush without affecting the associated bitmap by using the <see cref="DeleteObject"/> function.
        /// Therefore, you can then use this bitmap to create any number of pattern brushes.
        /// A brush created by using a monochrome (1 bit per pixel) bitmap has the text and background colors of the device context to which it is drawn.
        /// Pixels represented by a 0 bit are drawn with the current text color; pixels represented by a 1 bit are drawn with the current background color.
        /// ICM: No color is done at brush creation. However, color management is performed when the brush is selected into an ICM-enabled device context.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePatternBrush", ExactSpelling = true, SetLastError = true)]
        public static extern HBRUSH CreatePatternBrush([In]HBITMAP hbm);

        /// <summary>
        /// <para>
        /// The <see cref="GetBrushOrgEx"/> function retrieves the current brush origin for the specified device context.
        /// This function replaces the GetBrushOrg function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getbrushorgex
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lppt">
        /// A pointer to a <see cref="POINT"/> structure that receives the brush origin, in device coordinates.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// A brush is a bitmap that the system uses to paint the interiors of filled shapes.
        /// The brush origin is a set of coordinates with values between 0 and 7, specifying the location of one pixel in the bitmap.
        /// The default brush origin coordinates are (0,0).
        /// For horizontal coordinates, the value 0 corresponds to the leftmost column of pixels; the value 7 corresponds to the rightmost column.
        /// For vertical coordinates, the value 0 corresponds to the uppermost row of pixels; the value 7 corresponds to the lowermost row.
        /// When the system positions the brush at the start of any painting operation,
        /// it maps the origin of the brush to the location in the window's client area specified by the brush origin.
        /// For example, if the origin is set to (2,3), the system maps the origin of the brush (0,0) to the location (2,3) on the window's client area.
        /// If an application uses a brush to fill the backgrounds of both a parent and a child window with matching colors,
        /// it may be necessary to set the brush origin after painting the parent window but before painting the child window.
        /// The system automatically tracks the origin of all window-managed device contexts
        /// and adjusts their brushes as necessary to maintain an alignment of patterns on the surface.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBrushOrgEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetBrushOrgEx([In]HDC hdc, [Out]out POINT lppt);
    }
}
