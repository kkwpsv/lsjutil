using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using static Lsj.Util.Win32.DirectX.Enums.D3DDECLUSAGE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="D3DDEVCAPS2"/> driver capability flags.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddevcaps2"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D3DDEVCAPS2 : uint
    {
        /// <summary>
        /// Device supports adaptive tessellation of RT-patches
        /// </summary>
        D3DDEVCAPS2_ADAPTIVETESSRTPATCH = 0x00000004,

        /// <summary>
        /// Device supports adaptive tessellation of N-patches.
        /// </summary>
        D3DDEVCAPS2_ADAPTIVETESSNPATCH = 0x00000008,

        /// <summary>
        /// Device supports <see cref="IDirect3DDevice9.StretchRect"/> using a texture as the source.
        /// </summary>
        D3DDEVCAPS2_CAN_STRETCHRECT_FROM_TEXTURES = 0x00000010,

        /// <summary>
        /// Device supports displacement maps for N-patches.
        /// </summary>
        D3DDEVCAPS2_DMAPNPATCH = 0x00000002,

        /// <summary>
        /// Device supports presampled displacement maps for N-patches.
        /// For more information about displacement mapping, see Displacement Mapping (Direct3D 9).
        /// </summary>
        D3DDEVCAPS2_PRESAMPLEDDMAPNPATCH = 0x00000020,

        /// <summary>
        /// Device supports stream offsets.
        /// </summary>
        D3DDEVCAPS2_STREAMOFFSET = 0x00000001,

        /// <summary>
        /// Multiple vertex elements can share the same offset in a stream if <see cref="D3DDEVCAPS2_VERTEXELEMENTSCANSHARESTREAMOFFSET"/> is set by the device
        /// and the vertex declaration does not have an element with <see cref="D3DDECLUSAGE_POSITIONT"/> 0.
        /// </summary>
        D3DDEVCAPS2_VERTEXELEMENTSCANSHARESTREAMOFFSET = 0x00000040,
    }
}
