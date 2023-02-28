using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines resource types.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dresourcetype"/>
    /// </para>
    /// </summary>
    public enum D3DRESOURCETYPE
    {
        /// <summary>
        /// Surface resource.
        /// </summary>
        D3DRTYPE_SURFACE = 1,

        /// <summary>
        /// Volume resource.
        /// </summary>
        D3DRTYPE_VOLUME = 2,

        /// <summary>
        /// Texture resource.
        /// </summary>
        D3DRTYPE_TEXTURE = 3,

        /// <summary>
        /// Volume texture resource.
        /// </summary>
        D3DRTYPE_VOLUMETEXTURE = 4,

        /// <summary>
        /// Cube texture resource.
        /// </summary>
        D3DRTYPE_CUBETEXTURE = 5,

        /// <summary>
        /// Vertex buffer resource.
        /// </summary>
        D3DRTYPE_VERTEXBUFFER = 6,

        /// <summary>
        /// Index buffer resource.
        /// </summary>
        D3DRTYPE_INDEXBUFFER = 7,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DRTYPE_FORCE_DWORD = 0x7fffffff
    }
}
