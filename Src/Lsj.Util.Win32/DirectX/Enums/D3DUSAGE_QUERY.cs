using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using static Lsj.Util.Win32.DirectX.Enums.D3DTEXTUREFILTERTYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// These options identify query resource types.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dusage-query"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use <see cref="IDirect3D9.CheckDeviceFormat"/> to query hardware support for these usages, and some other usages listed in <see cref="D3DUSAGE"/>.
    /// </remarks>
    [Flags]
    public enum D3DUSAGE_QUERY : uint
    {
        /// <summary>
        /// Query the resource format to see if it supports texture filter types other than <see cref="D3DTEXF_POINT"/> (which is always supported).
        /// </summary>
        D3DUSAGE_QUERY_FILTER = 0x00020000,

        /// <summary>
        /// Query the resource about a legacy bump map.
        /// </summary>
        D3DUSAGE_QUERY_LEGACYBUMPMAP = 0x00008000,

        /// <summary>
        /// Query the resource to verify support for post pixel shader blending support.
        /// If <see cref="IDirect3D9.CheckDeviceFormat"/> fails with <see cref="D3DUSAGE_QUERY_POSTPIXELSHADER_BLENDING"/>,
        /// post pixel blending operations are not supported.
        /// These include alpha test, pixel fog, render-target blending, color write enable, and dithering.
        /// </summary>
        D3DUSAGE_QUERY_POSTPIXELSHADER_BLENDING = 0x00080000,

        /// <summary>
        /// Query the resource to verify if a texture supports gamma correction during a read operation.
        /// </summary>
        D3DUSAGE_QUERY_SRGBREAD = 0x00010000,

        /// <summary>
        /// Query the resource to verify if a texture supports gamma correction during a write operation.
        /// </summary>
        D3DUSAGE_QUERY_SRGBWRITE = 0x00040000,

        /// <summary>
        /// Query the resource to verify support for vertex shader texture sampling.
        /// </summary>
        D3DUSAGE_QUERY_VERTEXTEXTURE = 0x00100000,

        /// <summary>
        /// Query the resource to verify support for texture wrapping and mip-mapping.
        /// </summary>
        D3DUSAGE_QUERY_WRAPANDMIP = 0x00200000,
    }
}
