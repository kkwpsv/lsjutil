using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.RASTERIZER_STATUSFlags;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="RASTERIZER_STATUS"/> structure contains information about whether TrueType is installed.
    /// This structure is filled when an application calls the <see cref="GetRasterizerCaps"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-rasterizer_status"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RASTERIZER_STATUS
    {
        /// <summary>
        /// The size, in bytes, of the <see cref="RASTERIZER_STATUS"/> structure.
        /// </summary>
        public short nSize;

        /// <summary>
        /// Specifies whether at least one TrueType font is installed and whether TrueType is enabled.
        /// This value is <see cref="TT_AVAILABLE"/>, <see cref="TT_ENABLED"/>, or both if TrueType is on the system.
        /// </summary>
        public RASTERIZER_STATUSFlags wFlags;

        /// <summary>
        /// The language in the system's Setup.inf file.
        /// </summary>
        public short nLanguageID;
    }
}
