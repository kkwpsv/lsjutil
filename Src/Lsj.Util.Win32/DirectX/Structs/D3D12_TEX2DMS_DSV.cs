using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the subresource from a multi sampled 2D texture that is accessible to a depth-stencil view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2dms_dsv"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is a member of the <see cref="D3D12_DEPTH_STENCIL_VIEW_DESC"/> structure.
    /// </para>
    /// <para>
    /// Because a multi sampled 2D texture contains a single subresource,
    /// there is nothing to specify in <see cref="D3D12_TEX2DMS_DSV"/>.
    /// Consequently, <see cref="UnusedField_NothingToDefine"/> is included so that this structure will compile in C.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_TEX2DMS_DSV
    {
        /// <summary>
        /// Integer of any value.
        /// See remarks.
        /// </summary>
        public UINT UnusedField_NothingToDefine;
    }
}
