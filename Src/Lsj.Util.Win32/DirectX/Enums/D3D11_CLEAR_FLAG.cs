using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the parts of the depth stencil to clear.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_clear_flag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These flags are used when calling <see cref="ID3D11DeviceContext.ClearDepthStencilView"/>; the flags can be combined with a bitwise OR.
    /// </remarks>
    [Flags]
    public enum D3D11_CLEAR_FLAG
    {
        /// <summary>
        /// Clear the depth buffer, using fast clear if possible, then place the resource in a compressed state.
        /// </summary>
        D3D11_CLEAR_DEPTH = 0x1,

        /// <summary>
        /// Clear the stencil buffer, using fast clear if possible, then place the resource in a compressed state.
        /// </summary>
        D3D11_CLEAR_STENCIL = 0x2,
    }
}
