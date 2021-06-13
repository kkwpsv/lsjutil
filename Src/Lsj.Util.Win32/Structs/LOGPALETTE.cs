using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="LOGPALETTE"/> structure defines a logical palette.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-logpalette"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The colors in the palette-entry table should appear in order of importance 
    /// because entries earlier in the logical palette are most likely to be placed in the system palette.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOGPALETTE
    {
        /// <summary>
        /// The version number of the system.
        /// </summary>
        public WORD palVersion;

        /// <summary>
        /// The number of entries in the logical palette.
        /// </summary>
        public WORD palNumEntries;

        /// <summary>
        /// Specifies an array of <see cref="PALETTEENTRY"/> structures that define the color and usage of each entry in the logical palette.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public PALETTEENTRY[] palPalEntry;
    }
}
