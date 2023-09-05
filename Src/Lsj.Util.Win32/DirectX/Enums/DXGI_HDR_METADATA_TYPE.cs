using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the header metadata type.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_5/ne-dxgi1_5-dxgi_hdr_metadata_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="IDXGISwapChain4.SetHDRMetaData"/> method.
    /// </remarks>
    public enum DXGI_HDR_METADATA_TYPE
    {
        /// <summary>
        /// Indicates there is no header metadata.
        /// </summary>
        DXGI_HDR_METADATA_TYPE_NONE = 0,

        /// <summary>
        /// Indicates the header metadata is held by a <see cref="DXGI_HDR_METADATA_HDR10"/> structure.
        /// </summary>
        DXGI_HDR_METADATA_TYPE_HDR10 = 1,

        /// <summary>
        /// 
        /// </summary>
        DXGI_HDR_METADATA_TYPE_HDR10PLUS = 2
    }
}
