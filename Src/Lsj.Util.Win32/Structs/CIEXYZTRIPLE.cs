using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="CIEXYZTRIPLE"/> structure contains the x,y, and z coordinates of the three colors that correspond
    /// to the red, green, and blue endpoints for a specified logical color space.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-ciexyztriple
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CIEXYZTRIPLE
    {
        /// <summary>
        /// The xyz coordinates of red endpoint.
        /// </summary>
        public CIEXYZ ciexyzRed;

        /// <summary>
        /// The xyz coordinates of green endpoint.
        /// </summary>
        public CIEXYZ ciexyzGreen;

        /// <summary>
        /// The xyz coordinates of green endpoint.
        /// </summary>
        public CIEXYZ ciexyzBlue;
    }
}
