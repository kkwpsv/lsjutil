using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="CIEXYZ"/> structure contains the x,y, and z coordinates of a specific color in a specified color space.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-ciexyz
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CIEXYZ
    {
        /// <summary>
        /// The x coordinate in fix point (2.30).
        /// </summary>
        public FXPT2DOT30 ciexyzX;

        /// <summary>
        /// The y coordinate in fix point (2.30).
        /// </summary>
        public FXPT2DOT30 ciexyzY;

        /// <summary>
        /// The z coordinate in fix point (2.30).
        /// </summary>
        public FXPT2DOT30 ciexyzZ;
    }
}
