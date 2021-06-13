using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="POINTL"/> structure defines the x- and y-coordinates of a point.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/windef/ns-windef-pointl"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="POINTL"/> structure is identical to the <see cref="POINT"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct POINTL
    {
        /// <summary>
        /// Specifies the x-coordinate of the point.
        /// </summary>
        public LONG x;

        /// <summary>
        /// Specifies the y-coordinate of the point.
        /// </summary>
        public LONG y;
    }
}
