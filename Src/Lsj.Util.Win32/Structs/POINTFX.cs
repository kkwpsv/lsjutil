using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="POINTFX"/> structure contains the coordinates of points that describe the outline of a character in a TrueType font.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-pointfx
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="POINTFX"/> structure is a member of the <see cref="TTPOLYCURVE"/> and <see cref="TTPOLYGONHEADER"/> structures.
    /// Values in the <see cref="POINTFX"/> structure are specified in device units.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct POINTFX
    {
        /// <summary>
        /// The x-component of a point on the outline of a TrueType character.
        /// </summary>
        public FIXED x;

        /// <summary>
        /// The y-component of a point on the outline of a TrueType character.
        /// </summary>
        public FIXED y;
    }
}
