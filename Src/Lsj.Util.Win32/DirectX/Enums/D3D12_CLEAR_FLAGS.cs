using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies what to clear from the depth stencil view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_clear_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by <see cref="ID3D12GraphicsCommandList.ClearDepthStencilView"/>.
    /// The flags can be combined to clear all.
    /// </remarks>
    [Flags]
    public enum D3D12_CLEAR_FLAGS
    {
        /// <summary>
        /// Indicates the depth buffer should be cleared.
        /// </summary>
        D3D12_CLEAR_FLAG_DEPTH = 0x1,

        /// <summary>
        /// Indicates the stencil buffer should be cleared.
        /// </summary>
        D3D12_CLEAR_FLAG_STENCIL = 0x2
    }
}
