using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the CPU-page properties for the heap.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_cpu_page_property"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_HEAP_PROPERTIES"/> structure.
    /// </remarks>
    public enum D3D12_CPU_PAGE_PROPERTY
    {
        /// <summary>
        /// The CPU-page property is unknown.
        /// </summary>
        D3D12_CPU_PAGE_PROPERTY_UNKNOWN = 0,

        /// <summary>
        /// The CPU cannot access the heap, therefore no page properties are available.
        /// </summary>
        D3D12_CPU_PAGE_PROPERTY_NOT_AVAILABLE = 1,

        /// <summary>
        /// The CPU-page property is write-combined.
        /// </summary>
        D3D12_CPU_PAGE_PROPERTY_WRITE_COMBINE = 2,

        /// <summary>
        /// The CPU-page property is write-back.
        /// </summary>
        D3D12_CPU_PAGE_PROPERTY_WRITE_BACK = 3
    }
}
