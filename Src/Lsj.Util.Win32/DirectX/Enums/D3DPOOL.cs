using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the memory class that holds the buffers for a resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dpool"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// All pool types are valid with all resources including: vertex buffers, index buffers, textures, and surfaces.
    /// The following tables indicate restrictions on pool types for render targets, depth stencils, and dynamic and mipmap usages.
    /// An x indicates a compatible combination; lack of an x indicates incompatibility.
    /// Pool                            <see cref="D3DUSAGE_RENDERTARGET"/>     <see cref="D3DUSAGE_DEPTHSTENCIL"/>
    /// <see cref="D3DPOOL_DEFAULT"/>   x                                       x
    /// <see cref="D3DPOOL_MANAGED"/>
    /// <see cref="D3DPOOL_SCRATCH"/>
    /// <see cref="D3DPOOL_SYSTEMMEM"/>
    /// Pool                            <see cref="D3DUSAGE_DYNAMIC"/>          <see cref="D3DUSAGE_AUTOGENMIPMAP"/>
    /// <see cref="D3DPOOL_DEFAULT"/>   x                                       x
    /// <see cref="D3DPOOL_MANAGED"/>                                           x
    /// <see cref="D3DPOOL_SCRATCH"/>
    /// <see cref="D3DPOOL_SYSTEMMEM"/> x
    /// For more information about usage types, see <see cref="D3DUSAGE"/>.
    /// Pools cannot be mixed for different objects contained within one resource (mip levels in a mipmap) and, when a pool is chosen, it cannot be changed.
    /// Applications should use <see cref="D3DPOOL_MANAGED"/> for most static resources
    /// because this saves the application from having to deal with lost devices.
    /// (Managed resources are restored by the runtime.)
    /// This is especially beneficial for unified memory architecture (UMA) systems.
    /// Other dynamic resources are not a good match for <see cref="D3DPOOL_MANAGED"/>.
    /// In fact, index buffers and vertex buffers cannot be created using <see cref="D3DPOOL_MANAGED"/> together with <see cref="D3DUSAGE_DYNAMIC"/>.
    /// For dynamic textures, it is sometimes desirable to use a pair of video memory and system memory textures,
    /// allocating the video memory using <see cref="D3DPOOL_DEFAULT"/> and the system memory using <see cref="D3DPOOL_SYSTEMMEM"/>.
    /// You can lock and modify the bits of the system memory texture using a locking method.
    /// Then you can update the video memory texture using <see cref="IDirect3DDevice9.UpdateTexture"/>.
    /// </remarks>
    public enum D3DPOOL
    {
        /// <summary>
        /// Resources are placed in the memory pool most appropriate for the set of usages requested for the given resource.
        /// This is usually video memory, including both local video memory and AGP memory.
        /// The <see cref="D3DPOOL_DEFAULT"/> pool is separate from <see cref="D3DPOOL_MANAGED"/> and <see cref="D3DPOOL_SYSTEMMEM"/>,
        /// and it specifies that the resource is placed in the preferred memory for device access.
        /// Note that <see cref="D3DPOOL_DEFAULT"/> never indicates that
        /// either <see cref="D3DPOOL_MANAGED"/> or <see cref="D3DPOOL_SYSTEMMEM"/> should be chosen as the memory pool type for this resource.
        /// Textures placed in the <see cref="D3DPOOL_DEFAULT"/> pool cannot be locked unless
        /// they are dynamic textures or they are private, FOURCC, driver formats.
        /// To access unlockable textures, you must use functions such as <see cref="IDirect3DDevice9.UpdateSurface"/>,
        /// <see cref="IDirect3DDevice9.UpdateTexture"/>, <see cref="IDirect3DDevice9.GetFrontBufferData"/>, and <see cref="IDirect3DDevice9.GetRenderTargetData"/>.
        /// <see cref="D3DPOOL_MANAGED"/> is probably a better choice than <see cref="D3DPOOL_DEFAULT"/> for most applications.
        /// Note that some textures created in driver-proprietary pixel formats, unknown to the Direct3D runtime, can be locked.
        /// Also note that - unlike textures - swap chain back buffers, render targets, vertex buffers, and index buffers can be locked.
        /// When a device is lost, resources created using <see cref="D3DPOOL_DEFAULT"/> must be released before calling <see cref="IDirect3DDevice9.Reset"/>.
        /// For more information, see Lost Devices (Direct3D 9).
        /// When creating resources with <see cref="D3DPOOL_DEFAULT"/>, if video card memory is already committed,
        /// managed resources will be evicted to free enough memory to satisfy the request.
        /// </summary>
        D3DPOOL_DEFAULT = 0,

        /// <summary>
        /// Resources are copied automatically to device-accessible memory as needed.
        /// Managed resources are backed by system memory and do not need to be recreated when a device is lost.
        /// See Managing Resources (Direct3D 9) for more information. Managed resources can be locked.
        /// Only the system-memory copy is directly modified.
        /// Direct3D copies your changes to driver-accessible memory as needed.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// <see cref="D3DPOOL_MANAGED"/> is valid with <see cref="IDirect3DDevice9"/>; however, it is not valid with <see cref="IDirect3DDevice9Ex"/>.
        /// </summary>
        D3DPOOL_MANAGED = 1,

        /// <summary>
        /// Resources are placed in memory that is not typically accessible by the Direct3D device.
        /// This memory allocation consumes system RAM but does not reduce pageable RAM.
        /// These resources do not need to be recreated when a device is lost.
        /// Resources in this pool can be locked and can be used as the source for a <see cref="IDirect3DDevice9.UpdateSurface"/>
        /// or <see cref="IDirect3DDevice9.UpdateTexture"/> operation to a memory resource created with <see cref="D3DPOOL_DEFAULT"/>.
        /// </summary>
        D3DPOOL_SYSTEMMEM = 2,

        /// <summary>
        /// Resources are placed in system RAM and do not need to be recreated when a device is lost.
        /// These resources are not bound by device size or format restrictions.
        /// Because of this, these resources cannot be accessed by the Direct3D device nor set as textures or render targets.
        /// However, these resources can always be created, locked, and copied.
        /// </summary>
        D3DPOOL_SCRATCH = 3,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DPOOL_FORCE_DWORD = 0x7fffffff,
    }
}
