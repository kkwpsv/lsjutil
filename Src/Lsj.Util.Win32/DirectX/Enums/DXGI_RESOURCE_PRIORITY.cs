namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// DXGI_RESOURCE_PRIORITY
    /// </summary>
    public enum DXGI_RESOURCE_PRIORITY : uint
    {
        /// <summary>
        /// DXGI_RESOURCE_PRIORITY_MINIMUM
        /// </summary>
        DXGI_RESOURCE_PRIORITY_MINIMUM = 0x28000000,

        /// <summary>
        /// DXGI_RESOURCE_PRIORITY_LOW
        /// </summary>
        DXGI_RESOURCE_PRIORITY_LOW = 0x50000000,

        /// <summary>
        /// DXGI_RESOURCE_PRIORITY_NORMAL
        /// </summary>
        DXGI_RESOURCE_PRIORITY_NORMAL = 0x78000000,

        /// <summary>
        /// DXGI_RESOURCE_PRIORITY_HIGH
        /// </summary>
        DXGI_RESOURCE_PRIORITY_HIGH = 0xa0000000,

        /// <summary>
        /// DXGI_RESOURCE_PRIORITY_MAXIMUM
        /// </summary>
        DXGI_RESOURCE_PRIORITY_MAXIMUM = 0xc8000000,
    }
}
