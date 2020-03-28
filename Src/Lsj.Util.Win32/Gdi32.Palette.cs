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
        /// The <see cref="AnimatePalette"/> function replaces entries in the specified logical palette.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-animatepalette
        /// </para>
        /// </summary>
        /// <param name="hPal">
        /// A handle to the logical palette.
        /// </param>
        /// <param name="iStartIndex">
        /// The first logical palette entry to be replaced.
        /// </param>
        /// <param name="cEntries">
        /// The number of entries to be replaced.
        /// </param>
        /// <param name="ppe">
        /// A pointer to the first member in an array of <see cref="PALETTEENTRY"/> structures used to replace the current entries.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// An application can determine whether a device supports palette operations by calling the <see cref="GetDeviceCaps"/> function
        /// and specifying the <see cref="RASTERCAPS"/> constant.
        /// The <see cref="AnimatePalette"/> function only changes entries with the <see cref="PC_RESERVED"/> flag set
        /// in the corresponding <see cref="palPalEntry"/> member of the <see cref="LOGPALETTE"/> structure.
        /// If the given palette is associated with the active window, the colors in the palette are replaced immediately.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AnimatePalette", SetLastError = true)]
        public static extern BOOL AnimatePalette([In]HPALETTE hPal, [In]UINT iStartIndex, [In]UINT cEntries,
            [MarshalAs(UnmanagedType.LPArray)][In]PALETTEENTRY[] ppe);

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
        /// The <see cref="GetNearestPaletteIndex"/> function retrieves the index for the entry
        /// in the specified logical palette most closely matching a specified color value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getnearestpaletteindex
        /// </para>
        /// </summary>
        /// <param name="h">
        /// A handle to a logical palette.
        /// </param>
        /// <param name="color">
        /// A color to be matched.
        /// To create a <see cref="COLORREF"/> color value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the index of an entry in a logical palette.
        /// If the function fails, the return value is <see cref="CLR_INVALID"/>.
        /// </returns>
        /// <remarks>
        /// An application can determine whether a device supports palette operations by calling the <see cref="GetDeviceCaps"/> function
        /// and specifying the <see cref="RASTERCAPS"/> constant.
        /// If the given logical palette contains entries with the <see cref="PC_EXPLICIT"/> flag set, the return value is undefined.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNearestPaletteIndex", SetLastError = true)]
        public static extern UINT GetNearestPaletteIndex([In]HPALETTE h, [In]COLORREF color);

        /// <summary>
        /// <para>
        /// The <see cref="GetPaletteEntries"/> function retrieves a specified range of palette entries from the given logical palette.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getpaletteentries
        /// </para>
        /// </summary>
        /// <param name="hpal">
        /// A handle to the logical palette.
        /// </param>
        /// <param name="iStart">
        /// The first entry in the logical palette to be retrieved.
        /// </param>
        /// <param name="cEntries">
        /// The number of entries in the logical palette to be retrieved.
        /// </param>
        /// <param name="pPalEntries">
        /// A pointer to an array of <see cref="PALETTEENTRY"/> structures to receive the palette entries.
        /// The array must contain at least as many structures as specified by the <paramref name="cEntries"/> parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds and the handle to the logical palette is a valid pointer (not <see cref="NULL"/>),
        /// the return value is the number of entries retrieved from the logical palette.
        /// If the function succeeds and handle to the logical palette is <see cref="NULL"/>, the return value is the number of entries in the given palette.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// An application can determine whether a device supports palette operations by calling the <see cref="GetDeviceCaps"/> function
        /// and specifying the <see cref="RASTERCAPS"/> constant.
        /// If the <paramref name="cEntries"/> parameter specifies more entries than exist in the palette,
        /// the remaining members of the <see cref="PALETTEENTRY"/> structure are not altered.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPaletteEntries", SetLastError = true)]
        public static extern UINT GetPaletteEntries([In]HPALETTE hpal, [In]UINT iStart, [In]UINT cEntries,
            [MarshalAs(UnmanagedType.LPArray)][Out]PALETTEENTRY[] pPalEntries);

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
        /// The <see cref="SetPaletteEntries"/> function sets RGB (red, green, blue) color values and flags in a range of entries in a logical palette.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setpaletteentries
        /// </para>
        /// </summary>
        /// <param name="hpal">
        /// A handle to the logical palette.
        /// </param>
        /// <param name="iStart">
        /// The first logical-palette entry to be set.
        /// </param>
        /// <param name="cEntries">
        /// The number of logical-palette entries to be set.
        /// </param>
        /// <param name="pPalEntries">
        /// A pointer to the first member of an array of <see cref="PALETTEENTRY"/> structures containing the RGB values and flags.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of entries that were set in the logical palette.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// An application can determine whether a device supports palette operations by calling the <see cref="GetDeviceCaps"/> function
        /// and specifying the <see cref="RASTERCAPS"/> constant.
        /// Even if a logical palette has been selected and realized, changes to the palette do not affect the physical palette in the surface.
        /// <see cref="RealizePalette"/> must be called again to set the new logical palette into the surface.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPaletteEntries", SetLastError = true)]
        public static extern UINT SetPaletteEntries([In]HPALETTE hpal, [In]UINT iStart, [In]UINT cEntries,
            [MarshalAs(UnmanagedType.LPArray)][In]PALETTEENTRY[] pPalEntries);

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
