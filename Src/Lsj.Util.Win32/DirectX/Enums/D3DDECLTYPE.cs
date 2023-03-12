using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.D3DDECLMETHOD;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines a vertex declaration data type.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddecltype"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Vertex data is declared with an array of <see cref="D3DVERTEXELEMENT9"/> structures.
    /// Each element in the array contains a vertex declaration data type.
    /// Use the DirectX Caps Viewer Tool (DXCapsViewer.exe) to see which types are supported on your device.
    /// You can get this tool and learn about it from the DirectX SDK.
    /// For info about the DirectX SDK, see Where is the DirectX SDK?.
    /// </remarks>
    public enum D3DDECLTYPE : byte
    {
        /// <summary>
        /// One-component float expanded to (float, 0, 0, 1).
        /// </summary>
        D3DDECLTYPE_FLOAT1 = 0,

        /// <summary>
        /// Two-component float expanded to (float, float, 0, 1).
        /// </summary>
        D3DDECLTYPE_FLOAT2 = 1,

        /// <summary>
        /// Three-component float expanded to (float, float, float, 1).
        /// </summary>
        D3DDECLTYPE_FLOAT3 = 2,

        /// <summary>
        /// Four-component float expanded to (float, float, float, float).
        /// </summary>
        D3DDECLTYPE_FLOAT4 = 3,

        /// <summary>
        /// Four-component, packed, unsigned bytes mapped to 0 to 1 range.
        /// Input is a <see cref="D3DCOLOR"/> and is expanded to RGBA order.
        /// </summary>
        D3DDECLTYPE_D3DCOLOR = 4,

        /// <summary>
        /// Four-component, unsigned byte.
        /// </summary>
        D3DDECLTYPE_UBYTE4 = 5,

        /// <summary>
        /// Two-component, signed short expanded to (value, value, 0, 1).
        /// </summary>
        D3DDECLTYPE_SHORT2 = 6,

        /// <summary>
        /// Four-component, signed short expanded to (value, value, value, value).
        /// </summary>
        D3DDECLTYPE_SHORT4 = 7,

        /// <summary>
        /// Four-component byte with each byte normalized by dividing with 255.0f.
        /// </summary>
        D3DDECLTYPE_UBYTE4N = 8,

        /// <summary>
        /// Normalized, two-component, signed short, expanded to (first short/32767.0, second short/32767.0, 0, 1).
        /// </summary>
        D3DDECLTYPE_SHORT2N = 9,

        /// <summary>
        /// Normalized, four-component, signed short, expanded to (first short/32767.0, second short/32767.0, third short/32767.0, fourth short/32767.0).
        /// </summary>
        D3DDECLTYPE_SHORT4N = 10,

        /// <summary>
        /// Normalized, two-component, unsigned short, expanded to (first short/65535.0, short short/65535.0, 0, 1).
        /// </summary>
        D3DDECLTYPE_USHORT2N = 11,

        /// <summary>
        /// Normalized, four-component, unsigned short, expanded to (first short/65535.0, second short/65535.0, third short/65535.0, fourth short/65535.0).
        /// </summary>
        D3DDECLTYPE_USHORT4N = 12,

        /// <summary>
        /// Three-component, unsigned, 10 10 10 format expanded to (value, value, value, 1).
        /// </summary>
        D3DDECLTYPE_UDEC3 = 13,

        /// <summary>
        /// Three-component, signed, 10 10 10 format normalized and expanded to (v[0]/511.0, v[1]/511.0, v[2]/511.0, 1).
        /// </summary>
        D3DDECLTYPE_DEC3N = 14,

        /// <summary>
        /// Two-component, 16-bit, floating point expanded to (value, value, 0, 1).
        /// </summary>
        D3DDECLTYPE_FLOAT16_2 = 15,

        /// <summary>
        /// Four-component, 16-bit, floating point expanded to (value, value, value, value).
        /// </summary>
        D3DDECLTYPE_FLOAT16_4 = 16,

        /// <summary>
        /// Type field in the declaration is unused.
        /// This is designed for use with <see cref="D3DDECLMETHOD_UV"/> and <see cref="D3DDECLMETHOD_LOOKUPPRESAMPLED"/>.
        /// </summary>
        D3DDECLTYPE_UNUSED = 17
    }
}
