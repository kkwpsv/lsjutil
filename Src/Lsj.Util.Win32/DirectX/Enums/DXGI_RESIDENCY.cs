using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Flags indicating the memory location of a resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/ne-dxgi-dxgi_residency"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by <see cref="IDXGIDevice.QueryResourceResidency"/>.
    /// </remarks>
    public enum DXGI_RESIDENCY
    {
        /// <summary>
        /// The resource is located in video memory.
        /// </summary>
        DXGI_RESIDENCY_FULLY_RESIDENT = 1,

        /// <summary>
        /// At least some of the resource is located in CPU memory.
        /// </summary>
        DXGI_RESIDENCY_RESIDENT_IN_SHARED_MEMORY = 2,

        /// <summary>
        /// At least some of the resource has been paged out to the hard drive.
        /// </summary>
        DXGI_RESIDENCY_EVICTED_TO_DISK = 3
    }
}
