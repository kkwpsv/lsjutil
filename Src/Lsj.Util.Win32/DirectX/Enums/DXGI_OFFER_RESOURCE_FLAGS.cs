using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies flags for the <see cref="IDXGIDevice4.OfferResources1"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_5/ne-dxgi1_5-dxgi_offer_resource_flags"/>
    /// </para>
    /// </summary>
    public enum DXGI_OFFER_RESOURCE_FLAGS
    {
        /// <summary>
        /// Indicates the ability to allow memory de-commit by the DirectX Graphics Kernel.
        /// </summary>
        DXGI_OFFER_RESOURCE_FLAG_ALLOW_DECOMMIT = 0x1,
    }
}
