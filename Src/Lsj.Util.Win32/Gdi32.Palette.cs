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
    }
}
