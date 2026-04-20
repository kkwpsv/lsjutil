using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// <see cref="D3D12_RECT"/> is declared as a RECT. For more information about this GDI rectangle structure, see <see cref="RECT"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d12/d3d12-rect"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used by the following methods:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="ID3D12GraphicsCommandList.RSSetScissorRects"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12GraphicsCommandList.ClearDepthStencilView"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12GraphicsCommandList.ClearRenderTargetView"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12GraphicsCommandList.ClearUnorderedAccessViewUint"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12GraphicsCommandList.ClearUnorderedAccessViewFloat"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// This structure is a member of the <see cref="D3D12_DISCARD_REGION"/> structure.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_RECT
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
