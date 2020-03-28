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
    }
}
