using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DDECLUSAGE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Defines the vertex data layout.
    /// Each vertex can contain one or more data types, and each data type is described by a vertex element.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dvertexelement9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Vertex data is defined using an array of <see cref="D3DVERTEXELEMENT9"/> structures.
    /// Use <see cref="D3DDECL_END"/> to declare the last element in the declaration.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DVERTEXELEMENT9
    {
        /// <summary>
        /// Stream number.
        /// </summary>
        public WORD Stream;

        /// <summary>
        /// Offset from the beginning of the vertex data to the data associated with the particular data type.
        /// </summary>
        public WORD Offset;

        /// <summary>
        /// The data type, specified as a <see cref="D3DDECLTYPE"/>.
        /// One of several predefined types that define the data size. Some methods have an implied type.
        /// </summary>
        public D3DDECLTYPE Type;

        /// <summary>
        /// The method specifies the tessellator processing, which determines how the tessellator interprets (or operates on) the vertex data.
        /// For more information, see <see cref="D3DDECLMETHOD"/>.
        /// </summary>
        public D3DDECLMETHOD Method;

        /// <summary>
        /// Defines what the data will be used for; that is, the interoperability between vertex data layouts and vertex shaders.
        /// Each usage acts to bind a vertex declaration to a vertex shader.
        /// In some cases, they have a special interpretation.
        /// For example, an element that specifies <see cref="D3DDECLUSAGE_NORMAL"/> or <see cref="D3DDECLUSAGE_POSITION"/>
        /// is used by the N-patch tessellator to set up tessellation.
        /// See <see cref="D3DDECLUSAGE"/> for a list of the available semantics.
        /// <see cref="D3DDECLUSAGE_TEXCOORD"/> can be used for user-defined fields (which don't have an existing usage defined).
        /// </summary>
        public D3DDECLUSAGE Usage;

        /// <summary>
        /// Modifies the usage data to allow the user to specify multiple usage types.
        /// </summary>
        public BYTE UsageIndex;
    }
}
