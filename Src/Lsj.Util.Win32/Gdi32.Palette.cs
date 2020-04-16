using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.COLORREF;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DeviceCapIndexes;
using static Lsj.Util.Win32.Enums.SystemPaletteStates;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

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
        /// in the corresponding <see cref="LOGPALETTE.palPalEntry"/> member of the <see cref="LOGPALETTE"/> structure.
        /// If the given palette is associated with the active window, the colors in the palette are replaced immediately.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "AnimatePalette", ExactSpelling = true, SetLastError = true)]
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePalette", ExactSpelling = true, SetLastError = true)]
        public static extern HPALETTE CreatePalette([In]in LOGPALETTE plpal);

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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNearestPaletteIndex", ExactSpelling = true, SetLastError = true)]
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPaletteEntries", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetPaletteEntries([In]HPALETTE hpal, [In]UINT iStart, [In]UINT cEntries,
            [MarshalAs(UnmanagedType.LPArray)][Out]PALETTEENTRY[] pPalEntries);

        /// <summary>
        /// <para>
        /// The <see cref="GetSystemPaletteEntries"/> function retrieves a range of palette entries from the system palette
        /// that is associated with the specified device context (DC).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getsystempaletteentries
        /// </para>
        /// </summary>
        /// <param name="hpal">
        /// A handle to the device context.
        /// </param>
        /// <param name="iStart">
        /// The first entry to be retrieved from the system palette.
        /// </param>
        /// <param name="cEntries">
        /// The number of entries to be retrieved from the system palette.
        /// </param>
        /// <param name="pPalEntries">
        /// A pointer to an array of <see cref="PALETTEENTRY"/> structures to receive the palette entries.
        /// The array must contain at least as many structures as specified by the nEntries parameter.
        /// If this parameter is <see cref="NULL"/>, the function returns the total number of entries in the palette.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of entries retrieved from the palette.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// An application can determine whether a device supports palette operations by calling the <see cref="GetDeviceCaps"/> function
        /// and specifying the <see cref="RASTERCAPS"/> constant.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemPaletteEntries", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetSystemPaletteEntries([In]HPALETTE hpal, [In]UINT iStart, [In]UINT cEntries,
            [MarshalAs(UnmanagedType.LPArray)][Out]PALETTEENTRY[] pPalEntries);

        /// <summary>
        /// <para>
        /// The <see cref="GetSystemPaletteUse"/> function retrieves the current state of the system (physical) palette for the specified device context (DC).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getsystempaletteuse
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the current state of the system palette.
        /// This parameter can be one of the following values.
        /// <see cref="SYSPAL_NOSTATIC"/>: The system palette contains no static colors except black and white.
        /// <see cref="SYSPAL_STATIC"/>: The system palette contains static colors that will not change when an application realizes its logical palette.
        /// <see cref="SYSPAL_ERROR"/>: The given device context is invalid or does not support a color palette.
        /// </returns>
        /// <remarks>
        /// By default, the system palette contains 20 static colors that are not changed when an application realizes its logical palette.
        /// An application can gain access to most of these colors by calling the <see cref="SetSystemPaletteUse"/> function.
        /// The device context identified by the hdc parameter must represent a device that supports color palettes.
        /// An application can determine whether a device supports color palettes by calling the <see cref="GetDeviceCaps"/> function
        /// and specifying the <see cref="RASTERCAPS"/> constant.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetSystemPaletteUse", ExactSpelling = true, SetLastError = true)]
        public static extern SystemPaletteStates GetSystemPaletteUse([In]HDC hdc);

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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RealizePalette", ExactSpelling = true, SetLastError = true)]
        public static extern UINT RealizePalette([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="ResizePalette"/> function increases or decreases the size of a logical palette based on the specified value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-resizepalette
        /// </para>
        /// </summary>
        /// <param name="hpal">
        /// A handle to the palette to be changed.
        /// </param>
        /// <param name="n">
        /// The number of entries in the palette after it has been resized.
        /// The number of entries is limited to 1024.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// An application can determine whether a device supports palette operations by calling the <see cref="GetDeviceCaps"/> function
        /// and specifying the <see cref="RASTERCAPS"/> constant.
        /// If an application calls <see cref="ResizePalette"/> to reduce the size of the palette, the entries remaining in the resized palette are unchanged.
        /// If the application calls <see cref="ResizePalette"/> to enlarge the palette, the additional palette entries are set to black
        /// (the red, green, and blue values are all 0) and their flags are set to zero.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ResizePalette", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ResizePalette([In]HPALETTE hpal, [In]UINT n);

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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectPalette", ExactSpelling = true, SetLastError = true)]
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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPaletteEntries", ExactSpelling = true, SetLastError = true)]
        public static extern UINT SetPaletteEntries([In]HPALETTE hpal, [In]UINT iStart, [In]UINT cEntries,
            [MarshalAs(UnmanagedType.LPArray)][In]PALETTEENTRY[] pPalEntries);

        /// <summary>
        /// <para>
        /// The <see cref="SetSystemPaletteUse"/> function allows an application to specify whether the system palette contains 2 or 20 static colors.
        /// The default system palette contains 20 static colors.
        /// (Static colors cannot be changed when an application realizes a logical palette.)
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setsystempaletteuse
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// This device context must refer to a device that supports color palettes.
        /// </param>
        /// <param name="use">
        /// The new use of the system palette.
        /// This parameter can be one of the following values.
        /// <see cref="SYSPAL_NOSTATIC"/>: The system palette contains two static colors (black and white).
        /// <see cref="SYSPAL_NOSTATIC256"/>: The system palette contains no static colors.
        /// <see cref="SYSPAL_STATIC"/>: The system palette contains static colors that will not change when an application realizes its logical palette.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the previous system palette.
        /// It can be either <see cref="SYSPAL_NOSTATIC"/>, <see cref="SYSPAL_NOSTATIC256"/>, or <see cref="SYSPAL_STATIC"/>.
        /// If the function fails, the return value is <see cref="SYSPAL_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// An application can determine whether a device supports palette operations by calling the <see cref="GetDeviceCaps"/> function
        /// and specifying the <see cref="RASTERCAPS"/> constant.
        /// When an application window moves to the foreground and the <see cref="SYSPAL_NOSTATIC"/> value is set,
        /// the application must call the <see cref="GetSysColor"/> function to save the current system colors setting.
        /// It must also call <see cref="SetSysColors"/> to set reasonable values using only black and white.
        /// When the application returns to the background or terminates, the previous system colors must be restored.
        /// If the function returns <see cref="SYSPAL_ERROR"/>, the specified device context is invalid or does not support color palettes.
        /// An application must call this function only when its window is maximized and has the input focus.
        /// If an application calls <see cref="SetSystemPaletteUse"/> with <paramref name="use"/> set to <see cref="SYSPAL_NOSTATIC"/>,
        /// the system continues to set aside two entries in the system palette for pure white and pure black, respectively.
        /// After calling this function with <paramref name="use"/> set to <see cref="SYSPAL_NOSTATIC"/>, an application must take the following steps:
        /// Realize the logical palette.
        /// Call the <see cref="GetSysColor"/> function to save the current system-color settings.
        /// Call the <see cref="SetSysColors"/> function to set the system colors to reasonable values using black and white.
        /// For example, adjacent or overlapping items (such as window frames and borders) should be set to black and white, respectively.
        /// Send the <see cref="WM_SYSCOLORCHANGE"/> message to other top-level windows to allow them to be redrawn with the new system colors.
        /// When the application's window loses focus or closes, the application must perform the following steps:
        /// Call <see cref="SetSystemPaletteUse"/> with the <paramref name="use"/> parameter set to <see cref="SYSPAL_STATIC"/>.
        /// Realize the logical palette.
        /// Restore the system colors to their previous values.
        /// Send the <see cref="WM_SYSCOLORCHANGE"/> message.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetSystemPaletteUse", ExactSpelling = true, SetLastError = true)]
        public static extern SystemPaletteStates SetSystemPaletteUse([In]HDC hdc, [In]SystemPaletteStates use);

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
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateColors", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UpdateColors([In]HDC hdc);
    }
}
