using Lsj.Util.Win32.BaseTypes;
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
        /// The <see cref="CreatePalette"/> function creates a logical palette.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createpalette
        /// </para>
        /// </summary>
        /// <param name="plpal">
        /// A pointer to a <see cref="LOGPALETTE"/> structure that contains information about the colors in the logical palette.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a logical palette.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// An application can determine whether a device supports palette operations
        /// by calling the <see cref="GetDeviceCaps"/> function and specifying the <see cref="RASTERCAPS"/> constant.
        /// Once an application creates a logical palette, it can select that palette into a device context by calling the <see cref="SelectPalette"/> function.
        /// A palette selected into a device context can be realized by calling the <see cref="RealizePalette"/> function.
        /// When you no longer need the palette, call the DeleteObject function to delete it.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePalette", SetLastError = true)]
        public static extern HPALETTE CreatePalette([MarshalAs(UnmanagedType.LPStruct)][In]LOGPALETTE plpal);

        /// <summary>
        /// <para>
        /// The <see cref="RealizePalette"/> function maps palette entries from the current logical palette to the system palette.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-realizepalette
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context into which a logical palette has been selected.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of entries in the logical palette mapped to the system palette.
        /// If the function fails, the return value is <see cref="GDI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// An application can determine whether a device supports palette operations by calling the <see cref="GetDeviceCaps"/> function
        /// and specifying the <see cref="RASTERCAPS"/> constant.
        /// The <see cref="RealizePalette"/> function modifies the palette for the device associated with the specified device context.
        /// If the device context is a memory DC, the color table for the bitmap selected into the DC is modified.
        /// If the device context is a display DC, the physical palette for that device is modified.
        /// A logical palette is a buffer between color-intensive applications and the system,
        /// allowing these applications to use as many colors as needed without interfering with colors displayed by other windows.
        /// When an application's window has the focus and it calls the <see cref="RealizePalette"/> function,
        /// the system attempts to realize as many of the requested colors as possible.
        /// The same is also true for applications with inactive windows.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RealizePalette", SetLastError = true)]
        public static extern UINT RealizePalette([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="SelectPalette"/> function selects the specified logical palette into a device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-selectpalette
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="hPal">
        /// A handle to the logical palette to be selected.
        /// </param>
        /// <param name="bForceBkgd">
        /// Specifies whether the logical palette is forced to be a background palette.
        /// If this value is <see cref="TRUE"/>, the <see cref="RealizePalette"/> function causes the logical palette to be mapped to the colors
        /// already in the physical palette in the best possible way.
        /// This is always done, even if the window for which the palette is realized belongs to a thread without active focus.
        /// If this value is <see cref="FALSE"/>, <see cref="RealizePalette"/> causes the logical palette to be copied into the device palette
        /// when the application is in the foreground. (If the hdc parameter is a memory device context, this parameter is ignored.)
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the device context's previous logical palette.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// An application can determine whether a device supports palette operations by calling the <see cref="GetDeviceCaps"/> function
        /// and specifying the <see cref="RASTERCAPS"/> constant.
        /// An application can select a logical palette into more than one device context only if device contexts are compatible.
        /// Otherwise <see cref="SelectPalette"/> fails.
        /// To create a device context that is compatible with another device context,
        /// call <see cref="CreateCompatibleDC"/> with the first device context as the parameter.
        /// If a logical palette is selected into more than one device context, changes to the logical palette will affect all device contexts
        /// for which it is selected.
        /// An application might call the <see cref="SelectPalette"/> function with the <paramref name="bForceBkgd"/> parameter set to <see cref="TRUE"/>
        /// if the child windows of a top-level window each realize their own palettes.
        /// However, only the child window that needs to realize its palette must set <paramref name="bForceBkgd"/> to <see cref="TRUE"/>;
        /// other child windows must set this value to <see cref="FALSE"/>.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectPalette", SetLastError = true)]
        public static extern HPALETTE SelectPalette([In]HDC hdc, [In]HPALETTE hPal, [In]BOOL bForceBkgd);

        /// <summary>
        /// <para>
        /// The <see cref="UpdateColors"/> function updates the client area of the specified device context
        /// by remapping the current colors in the client area to the currently realized logical palette.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-updatecolors
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// An application can determine whether a device supports palette operations by calling the <see cref="GetDeviceCaps"/> function
        /// and specifying the <see cref="RASTERCAPS"/> constant.
        /// An inactive window with a realized logical palette may call <see cref="UpdateColors"/> as an alternative to
        /// redrawing its client area when the system palette changes.
        /// The <see cref="UpdateColors"/> function typically updates a client area faster than redrawing the area.
        /// However, because <see cref="UpdateColors"/> performs the color translation based on the color of each pixel before the system palette changed,
        /// each call to this function results in the loss of some color accuracy.
        /// This function must be called soon after a <see cref="WM_PALETTECHANGED"/> message is received.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateColors", SetLastError = true)]
        public static extern BOOL UpdateColors([In]HDC hdc);
    }
}
