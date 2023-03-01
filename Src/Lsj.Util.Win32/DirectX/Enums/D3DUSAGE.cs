using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using static Lsj.Util.Win32.DirectX.Enums.D3DCREATE;
using static Lsj.Util.Win32.DirectX.Enums.D3DLOCK;
using static Lsj.Util.Win32.DirectX.Enums.D3DPOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Usage options that identify how resources are to be used.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dusage"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Usage and Resource Combinations
    /// Usages are either specified when a resource is created, or specified with <see cref="IDirect3D9.CheckDeviceType"/> to test the capability of an existing resource.
    /// The following table identifies which usages can be applied to which resource types.
    /// Usage                                       Vertex buffer create    Index buffer create     Texture create      Cube texture create     Volume texture create       Surface create      Check device format
    /// <see cref="D3DUSAGE_AUTOGENMIPMAP"/>                                                        x                   x                                                                       x
    /// <see cref="D3DUSAGE_DEPTHSTENCIL"/>                                                         x                   x                                                   x                   x
    /// <see cref="D3DUSAGE_DMAP"/>                                                                 x                                                                                           x
    /// <see cref="D3DUSAGE_DONOTCLIP"/>            x                       x
    /// <see cref="D3DUSAGE_DYNAMIC"/>              x                       x                       x                   x                       x                                               x
    /// <see cref="D3DUSAGE_NONSECURE"/>            x                       x                       x                   x                       x                           x                   x
    /// <see cref="D3DUSAGE_NPATCHES"/>             x                       x
    /// <see cref="D3DUSAGE_POINTS"/>               x                       x
    /// <see cref="D3DUSAGE_RTPATCHES"/>            x                       x
    /// <see cref="D3DUSAGE_RENDERTARGET"/>                                                         x                   x                                                   x                   x
    /// <see cref="D3DUSAGE_SOFTWAREPROCESSING"/>   x                       x                       x                   x                       x                                               x
    /// <see cref="D3DUSAGE_TEXTAPI"/>              x                                               x
    /// <see cref="D3DUSAGE_WRITEONLY"/>            x                       x
    /// Use <see cref="IDirect3D9.CheckDeviceFormat"/> to check hardware support for these usages.
    /// Each of the resource creation methods is listed here.
    /// <see cref="IDirect3DDevice9.CreateCubeTexture"/>
    /// <see cref="IDirect3DDevice9.CreateDepthStencilSurface"/>
    /// <see cref="IDirect3DDevice9.CreateIndexBuffer"/>
    /// <see cref="IDirect3DDevice9.CreateOffscreenPlainSurface"/>
    /// <see cref="IDirect3DDevice9.CreateRenderTarget"/>
    /// <see cref="IDirect3DDevice9.CreateTexture"/>
    /// <see cref="IDirect3DDevice9.CreateVertexBuffer"/>
    /// <see cref="IDirect3DDevice9.CreateVolumeTexture"/>
    /// The D3DXCreatexxx texturing functions also use some of these constant values for resource creation.
    /// For more information about pool types and their restrictions with certain usages, see <see cref="D3DPOOL"/>.
    /// </remarks>
    [Flags]
    public enum D3DUSAGE : uint
    {
        /// <summary>
        /// The resource will automatically generate mipmaps.
        /// See Automatic Generation of Mipmaps (Direct3D 9).
        /// Automatic generation of mipmaps is not supported for volume textures and depth stencil surfaces/textures.
        /// This usage is not valid for a resource in system memory (<see cref="D3DPOOL_SYSTEMMEM"/>).
        /// </summary>
        D3DUSAGE_AUTOGENMIPMAP = 0x00000400,

        /// <summary>
        /// The resource will be a depth stencil buffer.
        /// <see cref="D3DUSAGE_DEPTHSTENCIL"/> can only be used with <see cref="D3DPOOL_DEFAULT"/>.
        /// </summary>
        D3DUSAGE_DEPTHSTENCIL = 0x00000002,

        /// <summary>
        /// The resource will be a displacement map.
        /// </summary>
        D3DUSAGE_DMAP = 0x00004000,

        /// <summary>
        /// Set to indicate that the vertex buffer content will never require clipping.
        /// When rendering with buffers that have this flag set, the <see cref="D3DRS_CLIPPING"/> render state must be set to false.
        /// </summary>
        D3DUSAGE_DONOTCLIP = 0x00000020,

        /// <summary>
        /// Set to indicate that the vertex buffer requires dynamic memory use.
        /// This is useful for drivers because it enables them to decide where to place the buffer.
        /// In general, static vertex buffers are placed in video memory and dynamic vertex buffers are placed in AGP memory.
        /// Note that there is no separate static use.
        /// If you do not specify <see cref="D3DUSAGE_DYNAMIC"/>, the vertex buffer is made static.
        /// <see cref="D3DUSAGE_DYNAMIC"/> is strictly enforced through the <see cref="D3DLOCK_DISCARD"/> and <see cref="D3DLOCK_NOOVERWRITE"/> locking flags.
        /// As a result, <see cref="D3DLOCK_DISCARD"/> and <see cref="D3DLOCK_NOOVERWRITE"/> are valid only
        /// on vertex buffers created with <see cref="D3DUSAGE_DYNAMIC"/>.
        /// They are not valid flags on static vertex buffers.
        /// For more information, see Managing Resources (Direct3D 9).
        /// For more information about using dynamic vertex buffers, see Performance Optimizations(Direct3D 9).
        /// <see cref="D3DUSAGE_DYNAMIC"/> and <see cref="D3DPOOL_MANAGED"/> are incompatible and should not be used together.
        /// See <see cref="D3DPOOL"/>.
        /// Textures can specify <see cref="D3DUSAGE_DYNAMIC"/>.
        /// However, managed textures cannot use <see cref="D3DUSAGE_DYNAMIC"/>.
        /// For more information about dynamic textures, see Using Dynamic Textures.
        /// </summary>
        D3DUSAGE_DYNAMIC = 0x00000200,

        /// <summary>
        /// Allow a shared surface created by a secure application to be opened by a non-secure application that has the shared handle.
        /// Differences between Direct3D 9 and Direct3D 9Ex: This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DUSAGE_NONSECURE = 0x00800000,

        /// <summary>
        /// Set to indicate that the vertex buffer is to be used for drawing N-patches.
        /// </summary>
        D3DUSAGE_NPATCHES = 0x00000100,

        /// <summary>
        /// Set to indicate that the vertex or index buffer will be used for drawing point sprites.
        /// The buffer will be loaded in system memory if software vertex processing is needed to emulate point sprites.
        /// </summary>
        D3DUSAGE_POINTS = 0x00000040,

        /// <summary>
        /// The resource will be a render target.
        /// <see cref="D3DUSAGE_RENDERTARGET"/> can only be used with <see cref="D3DPOOL_DEFAULT"/>.
        /// </summary>
        D3DUSAGE_RENDERTARGET = 0x00000001,

        /// <summary>
        /// Set to indicate that the vertex buffer is to be used for drawing high-order primitives.
        /// </summary>
        D3DUSAGE_RTPATCHES = 0x00000080,

        /// <summary>
        /// If this flag is used, vertex processing is done in software.
        /// If this flag is not used, vertex processing is done in hardware.
        /// The <see cref="D3DUSAGE_SOFTWAREPROCESSING"/> flag can be set when mixed-mode or software vertex processing
        /// (<see cref="D3DCREATE_MIXED_VERTEXPROCESSING"/> / <see cref="D3DCREATE_SOFTWARE_VERTEXPROCESSING"/>) is enabled for that device.
        /// <see cref="D3DUSAGE_SOFTWAREPROCESSING"/> must be set for buffers to be used with software vertex processing in mixed mode,
        /// but it should not be set for the best possible performance
        /// when using hardware index processing in mixed mode (<see cref="D3DCREATE_HARDWARE_VERTEXPROCESSING"/>).
        /// However, setting <see cref="D3DUSAGE_SOFTWAREPROCESSING"/> is the only option
        /// when a single buffer is used with both hardware and software vertex processing.
        /// <see cref="D3DUSAGE_SOFTWAREPROCESSING"/> is allowed for mixed and software devices.
        /// <see cref="D3DUSAGE_SOFTWAREPROCESSING"/> is used with <see cref="IDirect3D9.CheckDeviceFormat"/> to find out
        /// if a particular texture format can be used as a vertex texture during software vertex processing.
        /// If it can, the texture must be created in <see cref="D3DPOOL_SCRATCH"/>.
        /// </summary>
        D3DUSAGE_SOFTWAREPROCESSING = 0x00000010,

        /// <summary>
        /// This usage flag must be specified for vertex buffers and source surfaces, used in calls to <see cref="IDirect3DDevice9Ex.ComposeRects"/>.
        /// T extures created with this usage flag cannot be used for texture filtering.
        /// Vertex buffers, created with this usage flag, cannot be used as input stream sources.
        /// Differences between Direct3D 9 and Direct3D 9Ex: This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DUSAGE_TEXTAPI = 0x10000000,

        /// <summary>
        /// Informs the system that the application writes only to the vertex buffer.
        /// Using this flag enables the driver to choose the best memory location for efficient write operations and rendering.
        /// Attempts to read from a vertex buffer that is created with this capability will fail.
        /// Buffers created with <see cref="D3DPOOL_DEFAULT"/> that do not specify <see cref="D3DUSAGE_WRITEONLY"/> may suffer a severe performance penalty.
        /// <see cref="D3DUSAGE_WRITEONLY"/> only affects the performance of <see cref="D3DPOOL_DEFAULT"/> buffers.
        /// </summary>
        D3DUSAGE_WRITEONLY = 0x00000008,

        /// <summary>
        /// Setting this flag indicates that the resource might contain protected content.
        /// Differences between Direct3D 9 and Direct3D 9Ex: This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DUSAGE_RESTRICTED_CONTENT = 0x00000800,

        /// <summary>
        /// Setting this flag indicates that access to the shared resource should be restricted.
        /// Differences between Direct3D 9 and Direct3D 9Ex: This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DUSAGE_RESTRICT_SHARED_RESOURCE = 0x00002000,

        /// <summary>
        /// Setting this flag indicates that the driver should restrict access to the shared resource.
        /// The caller must create an authenticated channel with the driver.
        /// The driver should then allow access to processes that attempt to open that shared resource.
        /// Differences between Direct3D 9 and Direct3D 9Ex: This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DUSAGE_RESTRICT_SHARED_RESOURCE_DRIVER = 0x00001000,
    }
}
