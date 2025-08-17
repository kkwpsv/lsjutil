using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Flags for surface and resource creation options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-usage"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Each flag is defined as an unsigned integer.
    /// </para>
    /// <code>
    /// #define DXGI_CPU_ACCESS_NONE    ( 0 )
    /// #define DXGI_CPU_ACCESS_DYNAMIC    ( 1 )
    /// #define DXGI_CPU_ACCESS_READ_WRITE    ( 2 )
    /// #define DXGI_CPU_ACCESS_SCRATCH    ( 3 )
    /// #define DXGI_CPU_ACCESS_FIELD        15
    /// #define DXGI_USAGE_SHADER_INPUT             ( 1L &lt;&lt; (0 + 4) )
    /// #define DXGI_USAGE_RENDER_TARGET_OUTPUT     ( 1L &lt;&lt; (1 + 4) )
    /// #define DXGI_USAGE_BACK_BUFFER              ( 1L &lt;&lt; (2 + 4) )
    /// #define DXGI_USAGE_SHARED                   ( 1L &lt;&lt; (3 + 4) )
    /// #define DXGI_USAGE_READ_ONLY                ( 1L &lt;&lt; (4 + 4) )
    /// #define DXGI_USAGE_DISCARD_ON_PRESENT       ( 1L &lt;&lt; (5 + 4) )
    /// #define DXGI_USAGE_UNORDERED_ACCESS         ( 1L &lt;&lt; (6 + 4) )
    /// typedef UINT DXGI_USAGE;
    /// </code>
    /// <para>
    /// These flag options are used in a call to the <see cref="IDXGIFactory.CreateSwapChain"/>::, <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/>,
    /// <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/>, or <see cref="IDXGIFactory2.CreateSwapChainForComposition"/> method
    /// to describe the surface usage and CPU access options for the back buffer of a swap chain.
    /// You can't use the <see cref="DXGI_USAGE_SHARED"/>, <see cref="DXGI_USAGE_DISCARD_ON_PRESENT"/>,
    /// and <see cref="DXGI_USAGE_READ_ONLY"/> values as input to create a swap chain.
    /// However, DXGI can set <see cref="DXGI_USAGE_DISCARD_ON_PRESENT"/> and <see cref="DXGI_USAGE_READ_ONLY"/>
    /// for some of the swap chain's back buffers on the application's behalf.
    /// You can call the <see cref="IDXGIResource.GetUsage"/> method to retrieve the usage of these back buffers.
    /// Swap chain's only support the <see cref="DXGI_CPU_ACCESS_NONE"/> value in the <see cref="DXGI_CPU_ACCESS_FIELD"/> part of <see cref="DXGI_USAGE"/>.
    /// </para>
    /// <para>
    /// These flag options are also used by the <see cref="IDXGIDevice.CreateSurface"/> method.
    /// </para>
    /// </remarks>
    [Flags]
    public enum DXGI_USAGE : uint
    {
        /// <summary>
        /// The surface or resource is used as a back buffer.
        /// You don’t need to pass <see cref="DXGI_USAGE_BACK_BUFFER"/> when you create a swap chain.
        /// But you can determine whether a resource belongs to a swap chain when you call <see cref="IDXGIResource.GetUsage"/> and get <see cref="DXGI_USAGE_BACK_BUFFER"/>.
        /// </summary>
        DXGI_USAGE_BACK_BUFFER = 1 << (2 + 4),

        /// <summary>
        /// This flag is for internal use only.
        /// </summary>
        DXGI_USAGE_DISCARD_ON_PRESENT = 1 << (5 + 4),

        /// <summary>
        /// Use the surface or resource for reading only.
        /// </summary>
        DXGI_USAGE_READ_ONLY = 1 << (4 + 4),

        /// <summary>
        /// Use the surface or resource as an output render target.
        /// </summary>
        DXGI_USAGE_RENDER_TARGET_OUTPUT = 1 << (1 + 4),

        /// <summary>
        /// Use the surface or resource as an input to a shader.
        /// </summary>
        DXGI_USAGE_SHADER_INPUT = 1 << (0 + 4),

        /// <summary>
        /// Share the surface or resource.
        /// </summary>
        DXGI_USAGE_SHARED = 1 << (3 + 4),

        /// <summary>
        /// Use the surface or resource for unordered access.
        /// </summary>
        DXGI_USAGE_UNORDERED_ACCESS = 1 << (6 + 4),
    }
}
