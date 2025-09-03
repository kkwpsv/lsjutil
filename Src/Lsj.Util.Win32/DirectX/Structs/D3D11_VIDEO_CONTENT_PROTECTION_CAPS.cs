using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the content-protection capabilities of a graphics driver.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_content_protection_caps"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_CONTENT_PROTECTION_CAPS
    {
        /// <summary>
        /// A bitwise OR of zero or more flags from the <see cref="D3D11_CONTENT_PROTECTION_CAPS"/> enumeration.
        /// </summary>
        public D3D11_CONTENT_PROTECTION_CAPS Caps;

        /// <summary>
        /// The number of cryptographic key-exchange types that are supported by the driver.
        /// To get the list of key-exchange types,
        /// call the <see cref="ID3D11VideoDevice.CheckCryptoKeyExchange"/> method.
        /// </summary>
        public UINT KeyExchangeTypeCount;

        /// <summary>
        /// The encryption block size, in bytes.
        /// The size of data to be encrypted must be a multiple of this value.
        /// </summary>
        public UINT BlockAlignmentSize;

        /// <summary>
        /// The total amount of memory, in bytes, that can be used to hold protected surfaces.
        /// </summary>
        public ULONGLONG ProtectedMemorySize;
    }
}
