using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// DXGI_MWA
    /// </summary>
    [Flags]
    public enum DXGI_MWA : uint
    {
        /// <summary>
        /// DXGI_MWA_NO_WINDOW_CHANGES
        /// </summary>
        DXGI_MWA_NO_WINDOW_CHANGES = (1 << 0),

        /// <summary>
        /// DXGI_MWA_NO_ALT_ENTER
        /// </summary>
        DXGI_MWA_NO_ALT_ENTER = (1 << 1),

        /// <summary>
        /// DXGI_MWA_NO_PRINT_SCREEN
        /// </summary>
        DXGI_MWA_NO_PRINT_SCREEN = (1 << 2),

        /// <summary>
        /// DXGI_MWA_VALID
        /// </summary>
        DXGI_MWA_VALID = (0x7)
    }
}
