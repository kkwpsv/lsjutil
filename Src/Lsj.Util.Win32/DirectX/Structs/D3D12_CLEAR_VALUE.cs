using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a value used to optimize clear operations for a particular resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_clear_value"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is optionally passed into the following methods:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreateCommittedResource"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreatePlacedResource"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreateReservedResource"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D3D12_CLEAR_VALUE
    {
        /// <summary>
        /// <para>
        /// Specifies one member of the <see cref="DXGI_FORMAT"/> enum.
        /// </para>
        /// <para>
        /// The format of the commonly cleared color follows the same validation rules as a view/ descriptor creation.
        /// In general, the format of the clear color can be any format in the same typeless group that the resource format belongs to.
        /// </para>
        /// <para>
        /// This <see cref="Format"/> must match the format of the view used during the clear operation.
        /// It indicates whether the <see cref="Color"/> or the <see cref="DepthStencil"/> member is valid
        /// and how to convert the values for usage with the resource.
        /// </para>
        /// </summary>
        [FieldOffset(0)]
        public DXGI_FORMAT Format;

        /// <summary>
        /// Specifies a 4-entry array of float values, determining the RGBA value.
        /// The order of RGBA matches the order used with <see cref="ID3D12GraphicsCommandList.ClearRenderTargetView"/>.
        /// </summary>
        [FieldOffset(4)]
        public ByValFLOATArrayStructForSize4 Color;

        /// <summary>
        /// Specifies one member of <see cref="D3D12_DEPTH_STENCIL_VALUE"/>.
        /// These values match the semantics of <c>Depth</c> and <c>Stencil</c>
        /// in <see cref="ID3D12GraphicsCommandList.ClearDepthStencilView"/>.
        /// </summary>
        [FieldOffset(4)]
        public D3D12_DEPTH_STENCIL_VALUE DepthStencil;
    }
}
