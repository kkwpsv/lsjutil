using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// <see cref="D3D11_RECT"/> is declared as follows:
    /// </para>
    /// <code>
    /// typedef RECT D3D11_RECT;
    /// </code>
    /// <para>
    /// For more information about this GDI rectangle structure, see <see cref="RECT"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d11/d3d11-rect"/>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/windef/ns-windef-rect"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used for scissor rectangles by <see cref="ID3D11DeviceContext.RSGetScissorRects"/> and <see cref="ID3D11DeviceContext.RSSetScissorRects"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_RECT
    {
        /// <summary>
        /// Specifies the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public LONG left;

        /// <summary>
        /// Specifies the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public LONG top;

        /// <summary>
        /// Specifies the x-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public LONG right;

        /// <summary>
        /// Specifies the y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public LONG bottom;
    }
}
