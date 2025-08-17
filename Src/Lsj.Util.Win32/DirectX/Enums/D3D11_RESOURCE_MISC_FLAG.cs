using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BIND_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_USAGE;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies options for resources.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_resource_misc_flag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enumeration is used in <see cref="D3D11_BUFFER_DESC"/>, <see cref="D3D11_TEXTURE1D_DESC"/>,
    /// <see cref="D3D11_TEXTURE2D_DESC"/>, <see cref="D3D11_TEXTURE3D_DESC"/>.
    /// </para>
    /// <para>
    /// These flags can be combined by bitwise OR.
    /// </para>
    /// <para>
    /// The <see cref="D3D11_RESOURCE_MISC_FLAG"/> cannot be used
    /// when creating resources with <see cref="D3D11_CPU_ACCESS_FLAG"/> flags.
    /// </para>
    /// </remarks>
    [Flags]
    public enum D3D11_RESOURCE_MISC_FLAG : uint
    {
        /// <summary>
        /// Enables MIP map generation by using <see cref="ID3D11DeviceContext.GenerateMips"/> on a texture resource.
        /// The resource must be created with the bind flags that specify that the resource is a render target and a shader resource.
        /// </summary>
        D3D11_RESOURCE_MISC_GENERATE_MIPS = 0x1,

        /// <summary>
        /// <para>
        /// Enables resource data sharing between two or more Direct3D devices.
        /// The only resources that can be shared are 2D non-mipmapped textures.
        /// </para>
        /// <para>
        /// <see cref="D3D11_RESOURCE_MISC_SHARED"/> and <see cref="D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> are mutually exclusive.
        /// </para>
        /// <para>
        /// WARP and REF devices do not support shared resources.
        /// </para>
        /// <para>
        /// If you try to create a resource with this flag on either a WARP or REFs device,
        /// the create method will return an <see cref="E_OUTOFMEMORY"/> error code.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Starting with Windows 8, WARP devices fully support shared resources.
        /// </para>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// Starting with Windows 8, we recommend that you enable resource data sharing between two or more Direct3D devices
        /// by using a combination of the <see cref="D3D11_RESOURCE_MISC_SHARED_NTHANDLE"/> and <see cref="D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> flags instead.
        /// </para>
        /// </summary>
        D3D11_RESOURCE_MISC_SHARED = 0x2,

        /// <summary>
        /// Sets a resource to be a cube texture created from a Texture2DArray that contains 6 textures.
        /// </summary>
        D3D11_RESOURCE_MISC_TEXTURECUBE = 0x4,

        /// <summary>
        /// Enables instancing of GPU-generated content.
        /// </summary>
        D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS = 0x10,

        /// <summary>
        /// Enables a resource as a byte address buffer.
        /// </summary>
        D3D11_RESOURCE_MISC_BUFFER_ALLOW_RAW_VIEWS = 0x20,

        /// <summary>
        /// Enables a resource as a structured buffer.
        /// </summary>
        D3D11_RESOURCE_MISC_BUFFER_STRUCTURED = 0x40,

        /// <summary>
        /// Enables a resource with MIP map clamping for use with <see cref="ID3D11DeviceContext.SetResourceMinLOD"/>.
        /// </summary>
        D3D11_RESOURCE_MISC_RESOURCE_CLAMP = 0x80,

        /// <summary>
        /// <para>
        /// Enables the resource to be synchronized by using the <see cref="IDXGIKeyedMutex.AcquireSync"/> and <see cref="IDXGIKeyedMutex.ReleaseSync"/> APIs.
        /// </para>
        /// <para>
        /// The following Direct3D 11 resource creation APIs, that take <see cref="D3D11_RESOURCE_MISC_FLAG"/> parameters, have been extended to support the new flag.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="ID3D11Device.CreateTexture1D"/>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="ID3D11Device.CreateTexture2D"/>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="ID3D11Device.CreateTexture3D"/>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ID3D11Device.CreateBuffer"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// If you call any of these methods with the <see cref="D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> flag set,
        /// the interface returned will support the <see cref="IDXGIKeyedMutex"/> interface.
        /// You can retrieve a pointer to the <see cref="IDXGIKeyedMutex"/> interface from the resource by using <see cref="IUnknown.QueryInterface"/>.
        /// The <see cref="IDXGIKeyedMutex"/> interface implements the <see cref="IDXGIKeyedMutex.AcquireSync"/>
        /// and <see cref="IDXGIKeyedMutex.ReleaseSync"/> APIs to synchronize access to the surface.
        /// The device that creates the surface, and any other device that opens the surface
        /// by using <see cref="ID3D11Device.OpenSharedResource"/>, must call <see cref="IDXGIKeyedMutex.AcquireSync"/>
        /// before they issue any rendering commands to the surface.
        /// When those devices finish rendering, they must call <see cref="IDXGIKeyedMutex.ReleaseSync"/>.
        /// </para>
        /// <para>
        /// <see cref="D3D11_RESOURCE_MISC_SHARED"/> and <see cref="D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> are mutually exclusive.
        /// </para>
        /// <para>
        /// WARP and REF devices do not support shared resources.
        /// </para>
        /// <para>
        /// If you try to create a resource with this flag on either a WARP or REF device,
        /// the create method will return an <see cref="E_OUTOFMEMORY"/> error code.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Note  Starting with Windows 8, WARP devices fully support shared resources.
        /// </para>
        /// </summary>
        D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX = 0x100,

        /// <summary>
        /// <para>
        /// Enables a resource compatible with GDI.
        /// You must set the <see cref="D3D11_RESOURCE_MISC_GDI_COMPATIBLE"/> flag on surfaces that you use with GDI.
        /// Setting the <see cref="D3D11_RESOURCE_MISC_GDI_COMPATIBLE"/> flag
        /// allows GDI rendering on the surface via <see cref="IDXGISurface1.GetDC"/>.
        /// </para>
        /// <para>
        /// Consider the following programming tips for using <see cref="D3D11_RESOURCE_MISC_GDI_COMPATIBLE"/>
        /// when you create a texture or use that texture in a swap chain:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> and <see cref="D3D11_RESOURCE_MISC_GDI_COMPATIBLE"/> are mutually exclusive.
        /// Therefore, do not use them together.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D11_RESOURCE_MISC_RESOURCE_CLAMP"/> and <see cref="D3D11_RESOURCE_MISC_GDI_COMPATIBLE"/> are mutually exclusive.
        /// Therefore, do not use them together.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// You must bind the texture as a render target for the output-merger stage.
        /// For example, set the <see cref="D3D11_BIND_RENDER_TARGET"/> flag
        /// in the <see cref="D3D11_TEXTURE2D_DESC.BindFlags"/> member of the <see cref="D3D11_TEXTURE2D_DESC"/> structure.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// You must set the maximum number of MIP map levels to 1.
        /// For example, set the <see cref="D3D11_TEXTURE2D_DESC.MipLevels"/> member of the <see cref="D3D11_TEXTURE2D_DESC"/> structure to 1.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// You must specify that the texture requires read and write access by the GPU.
        /// For example, set the <see cref="D3D11_TEXTURE2D_DESC.Usage"/> member
        /// of the <see cref="D3D11_TEXTURE2D_DESC"/> structure to <see cref="D3D11_USAGE_DEFAULT"/>.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// You must set the texture format to one of the following types.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_FORMAT_B8G8R8A8_TYPELESS"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_FORMAT_B8G8R8A8_UNORM_SRGB"/>
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// For example, set the <see cref="D3D11_TEXTURE2D_DESC.Format"/> member
        /// of the <see cref="D3D11_TEXTURE2D_DESC"/> structure to one of these types.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// You cannot use <see cref="D3D11_RESOURCE_MISC_GDI_COMPATIBLE"/> with multisampling.
        /// Therefore, set the <see cref="DXGI_SAMPLE_DESC.Count"/> member of the <see cref="DXGI_SAMPLE_DESC"/> structure to 1.
        /// Then, set the <see cref="D3D11_TEXTURE2D_DESC.SampleDesc"/> member
        /// of the <see cref="D3D11_TEXTURE2D_DESC"/> structure to this <see cref="DXGI_SAMPLE_DESC"/> structure.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        D3D11_RESOURCE_MISC_GDI_COMPATIBLE = 0x200,

        /// <summary>
        /// <para>
        /// Set this flag to enable the use of NT HANDLE values when you create a shared resource.
        /// By enabling this flag, you deprecate the use of existing HANDLE values.
        /// </para>
        /// <para>
        /// The value specifies a new shared resource type that directs the runtime to use NT HANDLE values for the shared resource.
        /// The runtime then must confirm that the shared resource works on all hardware at the specified feature level.
        /// </para>
        /// <para>
        /// Without this flag set, the runtime does not strictly validate shared resource parameters (that is, formats, flags, usage, and so on).
        /// When the runtime does not validate shared resource parameters,
        /// behavior of much of the Direct3D API might be undefined and might vary from driver to driver.
        /// </para>
        /// <para>
        /// Direct3D 11 and earlier: This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_RESOURCE_MISC_SHARED_NTHANDLE = 0x800,

        /// <summary>
        /// <para>
        /// Set this flag to indicate that the resource might contain protected content;
        /// therefore, the operating system should use the resource only when the driver and hardware support content protection.
        /// If the driver and hardware do not support content protection and you try to create a resource with this flag, the resource creation fails.
        /// </para>
        /// <para>
        /// Direct3D 11:  This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_RESOURCE_MISC_RESTRICTED_CONTENT = 0x1000,

        /// <summary>
        /// <para>
        /// Set this flag to indicate that the operating system restricts access to the shared surface.
        /// You can use this flag together with the <see cref="D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE_DRIVER"/> flag
        /// and only when you create a shared surface.
        /// The process that creates the shared resource can always open the shared resource.
        /// </para>
        /// <para>
        /// Direct3D 11:  This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE = 0x2000,

        /// <summary>
        /// <para>
        /// Set this flag to indicate that the driver restricts access to the shared surface.
        /// You can use this flag in conjunction with the <see cref="D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE"/> flag
        /// and only when you create a shared surface.
        /// The process that creates the shared resource can always open the shared resource.
        /// </para>
        /// <para>
        /// Direct3D 11:  This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_RESOURCE_MISC_RESTRICT_SHARED_RESOURCE_DRIVER = 0x4000,

        /// <summary>
        /// <para>
        /// Set this flag to indicate that the resource is guarded.
        /// Such a resource is returned by the <see cref="IDCompositionSurface.BeginDraw"/> (DirectComposition)
        /// and <see cref="ISurfaceImageSourceNative.BeginDraw"/> (Windows Runtime) APIs. 
        /// For these APIs, you provide a region of interest (ROI) on a surface to update.
        /// This surface isn't compatible with multiple render targets (MRT).
        /// </para>
        /// <para>
        /// A guarded resource automatically restricts all writes to the region that is related to one of the preceding APIs.
        /// Additionally, the resource enforces access to the ROI with these restrictions:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <para>
        /// Copy operations from the resource by using <see cref="ID3D11DeviceContext.CopyResource"/>
        /// or <see cref="ID3D11DeviceContext.CopySubresourceRegion"/> are restricted to only copy from the ROI.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// When a guarded resource is set as a render target, it must be the only target.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Direct3D 11:  This value is not supported until Direct3D 11.1.
        /// </para>
        /// </summary>
        D3D11_RESOURCE_MISC_GUARDED = 0x8000,

        /// <summary>
        /// <para>
        /// Set this flag to indicate that the resource is a tile pool.
        /// </para>
        /// <para>
        /// Direct3D 11:  This value is not supported until Direct3D 11.2.
        /// </para>
        /// </summary>
        D3D11_RESOURCE_MISC_TILE_POOL = 0x20000,

        /// <summary>
        /// <para>
        /// Set this flag to indicate that the resource is a tiled resource.
        /// </para>
        /// <para>
        /// Direct3D 11:  This value is not supported until Direct3D 11.2.
        /// </para>
        /// </summary>
        D3D11_RESOURCE_MISC_TILED = 0x40000,

        /// <summary>
        /// <para>
        /// Set this flag to indicate that the resource should be created such that it will be protected by the hardware.
        /// Resource creation will fail if hardware content protection is not supported.
        /// </para>
        /// <para>
        /// This flag has the following restrictions:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <para>
        /// This flag cannot be used with the following <see cref="D3D11_USAGE"/> values:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3D11_USAGE_DYNAMIC"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D11_USAGE_STAGING"/>
        /// </description>
        /// </item>
        /// </list>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// This flag cannot be used with the following <see cref="D3D11_BIND_FLAG"/> values.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3D11_BIND_VERTEX_BUFFER"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D11_BIND_INDEX_BUFFER"/>
        /// </description>
        /// </item>
        /// </list>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// No CPU access flags can be specified.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Note  
        /// </para>
        /// <para>
        /// Creating a texture using this flag does not automatically guarantee
        /// that hardware protection will be enabled for the underlying allocation.
        /// Some implementations require that the DRM components are first initialized prior to any guarantees of protection.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This enumeration value is supported starting with Windows 10.
        /// </para>
        /// </summary>
        D3D11_RESOURCE_MISC_HW_PROTECTED = 0x80000,

        /// <summary>
        /// Enables the resource to work with the displayable surfaces feature.
        /// You must use <see cref="D3D11_RESOURCE_MISC_SHARED_DISPLAYABLE"/> in combination
        /// with both <see cref="D3D11_RESOURCE_MISC_SHARED"/> and <see cref="D3D11_RESOURCE_MISC_SHARED_NTHANDLE"/>.
        /// </summary>
        D3D11_RESOURCE_MISC_SHARED_DISPLAYABLE = 0x100000,

        /// <summary>
        /// TBD
        /// </summary>
        D3D11_RESOURCE_MISC_SHARED_EXCLUSIVE_WRITER = 0x200000,
    }
}
