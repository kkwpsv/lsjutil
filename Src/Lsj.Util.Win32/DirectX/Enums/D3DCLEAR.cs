using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// These flags identify a surface to reset when calling <see cref="IDirect3DDevice9.Clear"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dclear"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D3DCLEAR
    {
        /// <summary>
        /// Clear a render target, or all targets in a multiple render target.
        /// See Multiple Render Targets (Direct3D 9).
        /// </summary>
        D3DCLEAR_TARGET = 0x00000001,

        /// <summary>
        /// Clear the depth buffer.
        /// </summary>
        D3DCLEAR_ZBUFFER = 0x00000002,

        /// <summary>
        /// Clear the stencil buffer.
        /// </summary>
        D3DCLEAR_STENCIL = 0x00000004,
    }
}
