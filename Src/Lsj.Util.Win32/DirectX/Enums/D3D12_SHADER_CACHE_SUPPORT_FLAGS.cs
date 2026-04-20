using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes the level of support for shader caching in the current graphics driver.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_cache_support_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_FEATURE_DATA_SHADER_CACHE"/> structure.
    /// </remarks>
    [Flags]
    public enum D3D12_SHADER_CACHE_SUPPORT_FLAGS
    {
        /// <summary>
        /// Indicates that the driver does not support shader caching.
        /// </summary>
        D3D12_SHADER_CACHE_SUPPORT_NONE = 0,

        /// <summary>
        /// Indicates that the driver supports the <c>CachedPSO</c> member
        /// of the <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> and <see cref="D3D12_COMPUTE_PIPELINE_STATE_DESC"/> structures.
        /// This is always supported.
        /// </summary>
        D3D12_SHADER_CACHE_SUPPORT_SINGLE_PSO = 0x1,

        /// <summary>
        /// Indicates that the driver supports the <see cref="ID3D12PipelineLibrary"/> interface,
        /// which provides application-controlled PSO grouping and caching.
        /// This is supported by drivers targetting the Windows 10 Anniversary Update.
        /// </summary>
        D3D12_SHADER_CACHE_SUPPORT_LIBRARY = 0x2,

        /// <summary>
        /// Indicates that the driver supports an OS-managed shader cache
        /// that stores compiled shaders in memory during the current run of the application.
        /// </summary>
        D3D12_SHADER_CACHE_SUPPORT_AUTOMATIC_INPROC_CACHE = 0x4,

        /// <summary>
        /// Indicates that the driver supports an OS-managed shader cache
        /// that stores compiled shaders on disk to accelerate future runs of the application.
        /// </summary>
        D3D12_SHADER_CACHE_SUPPORT_AUTOMATIC_DISK_CACHE = 0x8,

        /// <summary>
        /// 
        /// </summary>
        D3D12_SHADER_CACHE_SUPPORT_DRIVER_MANAGED_CACHE = 0x10,

        /// <summary>
        /// 
        /// </summary>
        D3D12_SHADER_CACHE_SUPPORT_SHADER_CONTROL_CLEAR = 0x20,

        /// <summary>
        /// 
        /// </summary>
        D3D12_SHADER_CACHE_SUPPORT_SHADER_SESSION_DELETE = 0x40
    }
}
