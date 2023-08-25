using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// DXGI_MAP
    /// </summary>
    [Flags]
    public enum DXGI_MAP : uint
    {
        /// <summary>
        /// DXGI_MAP_READ
        /// </summary>
        DXGI_MAP_READ = 1,

        /// <summary>
        /// DXGI_MAP_WRITE
        /// </summary>
        DXGI_MAP_WRITE = 2,

        /// <summary>
        /// DXGI_MAP_DISCARD
        /// </summary>
        DXGI_MAP_DISCARD = 4,
    }
}
