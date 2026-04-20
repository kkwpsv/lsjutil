using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes details for the discard-resource operation.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_discard_region"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used by the <see cref="ID3D12GraphicsCommandList.DiscardResource"/> method.
    /// </para>
    /// <para>
    /// If rectangles are supplied in this structure,
    /// the resource must have 2D subresources with all specified subresources the same dimension.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_DISCARD_REGION
    {
        /// <summary>
        /// The number of rectangles in the array that the <see cref="pRects"/> member specifies.
        /// </summary>
        public UINT NumRects;

        /// <summary>
        /// An array of <see cref="D3D12_RECT"/> structures for the rectangles in the resource to discard.
        /// If <see cref="NULL"/>, <see cref="ID3D12GraphicsCommandList.DiscardResource"/> discards the entire resource.
        /// </summary>
        public P<D3D12_RECT> pRects;

        /// <summary>
        /// Index of the first subresource in the resource to discard.
        /// </summary>
        public UINT FirstSubresource;

        /// <summary>
        /// The number of subresources in the resource to discard.
        /// </summary>
        public UINT NumSubresources;
    }
}
