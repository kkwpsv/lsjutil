using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies broad residency priority buckets useful for quickly establishing an application priority scheme.
    /// </para>
    /// <para>
    /// Applications can assign priority values other than the five values present in this enumeration.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_residency_priority"/>
    /// </para>
    /// </summary>
    public enum D3D12_RESIDENCY_PRIORITY : uint
    {
        /// <summary>
        /// Indicates a minimum priority.
        /// </summary>
        D3D12_RESIDENCY_PRIORITY_MINIMUM = 0x28000000,

        /// <summary>
        /// Indicates a low priority.
        /// </summary>
        D3D12_RESIDENCY_PRIORITY_LOW = 0x50000000,

        /// <summary>
        /// Indicates a normal, medium, priority.
        /// </summary>
        D3D12_RESIDENCY_PRIORITY_NORMAL = 0x78000000,

        /// <summary>
        /// Indicates a high priority.
        /// Applications are discouraged from using priories greater than this.
        /// For more information see <see cref="ID3D12Device1.SetResidencyPriority"/>.
        /// </summary>
        D3D12_RESIDENCY_PRIORITY_HIGH = 0xa0010000,

        /// <summary>
        /// Indicates a maximum priority.
        /// Applications are discouraged from using priorities greater than this;
        /// <see cref="D3D12_RESIDENCY_PRIORITY_MAXIMUM"/> is not guaranteed to be available.
        /// For more information see <see cref="ID3D12Device1.SetResidencyPriority"/>
        /// </summary>
        D3D12_RESIDENCY_PRIORITY_MAXIMUM = 0xc8000000
    }
}
