using System;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DTSS_TCI;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// A combination of one or more flags that control the device create behavior.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dvtxpcaps"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D3DVTXPCAPS : uint
    {
        /// <summary>
        /// Device can do directional lights.
        /// </summary>
        D3DVTXPCAPS_DIRECTIONALLIGHTS = 0x00000008,

        /// <summary>
        /// Device can do local viewer.
        /// </summary>
        D3DVTXPCAPS_LOCALVIEWER = 0x00000020,

        /// <summary>
        /// When this cap is set, the device supports the color material states:
        /// <see cref="D3DRS_AMBIENTMATERIALSOURCE"/>, <see cref="D3DRS_DIFFUSEMATERIALSOURCE"/>,
        /// <see cref="D3DRS_EMISSIVEMATERIALSOURCE"/>, and <see cref="D3DRS_SPECULARMATERIALSOURCE"/>.
        /// </summary>
        D3DVTXPCAPS_MATERIALSOURCE7 = 0x00000002,

        /// <summary>
        /// Device does not support texture generation in non-local viewer mode.
        /// </summary>
        D3DVTXPCAPS_NO_TEXGEN_NONLOCALVIEWER = 0x00000200,

        /// <summary>
        /// Device can do positional lights (includes point and spot).
        /// </summary>
        D3DVTXPCAPS_POSITIONALLIGHTS = 0x00000010,

        /// <summary>
        /// Device can do texgen.
        /// </summary>
        D3DVTXPCAPS_TEXGEN = 0x00000001,

        /// <summary>
        /// Device supports <see cref="D3DTSS_TCI_SPHEREMAP"/>.
        /// </summary>
        D3DVTXPCAPS_TEXGEN_SPHEREMAP = 0x00000100,

        /// <summary>
        /// Device can do vertex tweening.
        /// </summary>
        D3DVTXPCAPS_TWEENING = 0x00000040,
    }
}
