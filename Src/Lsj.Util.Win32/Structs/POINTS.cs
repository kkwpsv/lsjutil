using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="POINTS"/> structure defines the x- and y-coordinates of a point.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/windef/ns-windef-points
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="POINTS"/> structure is similar to the <see cref="POINT"/> and <see cref="POINTL"/> structures.
    /// The difference is that the members of the <see cref="POINTS"/> structure are of type <see cref="SHORT"/>,
    /// while those of the other two structures are of type <see cref="LONG"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct POINTS
    {
        /// <summary>
        /// Specifies the x-coordinate of the point.
        /// </summary>
        public SHORT x;

        /// <summary>
        /// Specifies the y-coordinate of the point.
        /// </summary>
        public SHORT y;
    }
}
