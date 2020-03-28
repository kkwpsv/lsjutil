using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateSolidBrush", SetLastError = true)]
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateHatchBrush", SetLastError = true)]
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePatternBrush", SetLastError = true)]
        public static extern HBRUSH CreatePatternBrush([In]HBITMAP hbm);
    }
}
