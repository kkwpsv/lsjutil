using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3DUSAGE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes an index buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dindexbuffer-desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DINDEXBUFFER_DESC
    {
        /// <summary>
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, describing the surface format of the index buffer data.
        /// </summary>
        public D3DFORMAT Format;

        /// <summary>
        /// Member of the <see cref="D3DRESOURCETYPE"/> enumerated type, identifying this resource as an index buffer.
        /// </summary>
        public D3DRESOURCETYPE Type;

        /// <summary>
        /// Combination of one or more of the following flags, specifying the usage for this resource.
        /// <see cref="D3DUSAGE_DONOTCLIP"/>:
        /// Set to indicate that the index buffer content will never require clipping.
        /// <see cref="D3DUSAGE_DYNAMIC"/>:
        /// Set to indicate that the index buffer requires dynamic memory use.
        /// This is useful for drivers because it enables them to decide where to place the buffer.
        /// In general, static index buffers are placed in video memory and dynamic index buffers are placed in AGP memory.
        /// Note that there is no separate static usage; if you do not specify <see cref="D3DUSAGE_DYNAMIC"/> the index buffer is made static.
        /// <see cref="D3DUSAGE_DYNAMIC"/> is strictly enforced through the <see cref="D3DLOCK_DISCARD"/> and <see cref="D3DLOCK_NOOVERWRITE"/> locking flags.
        /// As a result, <see cref="D3DLOCK_DISCARD"/> and <see cref="D3DLOCK_NOOVERWRITE"/> are only valid on index buffers created with <see cref="D3DUSAGE_DYNAMIC"/>;
        /// they are not valid flags on static vertex buffers.
        /// For more information about using dynamic index buffers, see Using Dynamic Vertex and Index Buffers.
        /// Note that <see cref="D3DUSAGE_DYNAMIC"/> cannot be specified on managed index buffers.
        /// For more information, see Managing Resources (Direct3D 9).
        /// <see cref="D3DUSAGE_RTPATCHES"/>:
        /// Set to indicate when the index buffer is to be used for drawing high-order primitives.
        /// <see cref="D3DUSAGE_NPATCHES"/>:
        /// Set to indicate when the index buffer is to be used for drawing N patches.
        /// <see cref="D3DUSAGE_POINTS"/>:
        /// Set to indicate when the index buffer is to be used for drawing point sprites or indexed point lists.
        /// <see cref="D3DUSAGE_SOFTWAREPROCESSING"/>:
        /// Set to indicate that the buffer is to be used with software processing.
        /// <see cref="D3DUSAGE_WRITEONLY"/>:
        /// Informs the system that the application writes only to the index buffer.
        /// Using this flag enables the driver to choose the best memory location for efficient write operations and rendering.
        /// Attempts to read from an index buffer that is created with this capability can result in degraded performance.
        /// </summary>
        public D3DUSAGE Usage;

        /// <summary>
        /// Member of the <see cref="D3DPOOL"/> enumerated type, specifying the class of memory allocated for this index buffer.
        /// </summary>
        public D3DPOOL Pool;

        /// <summary>
        /// Size of the index buffer, in bytes.
        /// </summary>
        public UINT Size;
    }
}
