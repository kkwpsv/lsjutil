using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a vertex buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dvertexbuffer-desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DVERTEXBUFFER_DESC
    {
        /// <summary>
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, describing the surface format of the vertex buffer data.
        /// </summary>
        public D3DFORMAT Format;

        /// <summary>
        /// ember of the <see cref="D3DRESOURCETYPE"/> enumerated type, identifying this resource as a vertex buffer.
        /// </summary>
        public D3DRESOURCETYPE Type;

        /// <summary>
        /// Combination of one or more <see cref="D3DUSAGE"/> flags.
        /// </summary>
        public D3DUSAGE Usage;

        /// <summary>
        /// Member of the <see cref="D3DPOOL"/> enumerated type, specifying the class of memory allocated for this vertex buffer.
        /// </summary>
        public D3DPOOL Pool;

        /// <summary>
        /// Size of the vertex buffer, in bytes.
        /// </summary>
        public UINT Size;

        /// <summary>
        /// Combination of <see cref="D3DFVF"/> that describes the vertex format of the vertices in this buffer.
        /// </summary>
        public D3DFVF FVF;
    }
}
