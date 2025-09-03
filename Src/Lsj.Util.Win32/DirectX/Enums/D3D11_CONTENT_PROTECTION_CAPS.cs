using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Contains flags that describe content-protection capabilities.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_content_protection_caps"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D3D11_CONTENT_PROTECTION_CAPS
    {
        /// <summary>
        /// The content protection is implemented in software by the driver.
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_SOFTWARE = 0x1,

        /// <summary>
        /// The content protection is implemented in hardware by the GPU.
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_HARDWARE = 0x2,

        /// <summary>
        /// Content protection is always applied to a protected surface,
        /// regardless of whether the application explicitly enables protection.
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_PROTECTION_ALWAYS_ON = 0x4,

        /// <summary>
        /// The driver can use partially encrypted buffers.
        /// If this capability is not present, the entire buffer must be either encrypted or clear.
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_PARTIAL_DECRYPTION = 0x8,

        /// <summary>
        /// The driver can encrypt data using a separate content key that is encrypted using the session key.
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_CONTENT_KEY = 0x10,

        /// <summary>
        /// The driver can refresh the session key without renegotiating the key.
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_FRESHEN_SESSION_KEY = 0x20,

        /// <summary>
        /// The driver can read back encrypted data from a protected surface.
        /// For more information, see <see cref="ID3D11VideoContext.EncryptionBlt"/>.
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_ENCRYPTED_READ_BACK = 0x40,

        /// <summary>
        /// The driver requires a separate key to read encrypted data from a protected surface.
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_ENCRYPTED_READ_BACK_KEY = 0x80,

        /// <summary>
        /// If the encryption type is <see cref="D3DCRYPTOTYPE_AES128_CTR"/>,
        /// the application must use a sequential count in the <see cref="D3D11_AES_CTR_IV"/> structure.
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_SEQUENTIAL_CTR_IV = 0x100,

        /// <summary>
        /// <para>
        /// The driver supports encrypted slice data,
        /// but does not support any other encrypted data in the compressed buffer.
        /// The caller should not encrypt any data within the buffer other than the slice data.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The driver should only report this flag for the specific profiles that have this limitation.
        /// </para>
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_ENCRYPT_SLICEDATA_ONLY = 0x200,

        /// <summary>
        /// The driver can copy encrypted data from one resource to another,
        /// decrypting the data as part of the process.
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_DECRYPTION_BLT = 0x400,

        /// <summary>
        /// <para>
        /// The hardware supports the protection of specific resources.
        /// This means that:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The contents of a protected allocation can never be read by the CPU.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The hardware can ensure a protected resource cannot be copied to an unprotected resource.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Note  This enumeration value is supported starting with Windows 10.
        /// </para>
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_HARDWARE_PROTECT_UNCOMPRESSED = 0x800,

        /// <summary>
        /// <para>
        /// Physical pages of a protected resource can be evicted and potentially paged to disk
        /// in low memory conditions without losing the contents of the resource when paged back in.
        /// </para>
        /// <para>
        /// Note  This enumeration value is supported starting with Windows 10.
        /// </para>
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_HARDWARE_PROTECTED_MEMORY_PAGEABLE = 0x1000,

        /// <summary>
        /// <para>
        /// The hardware supports an automatic teardown mechanism
        /// that could trigger hardware keys or protected content to become lost in some conditions.
        /// The application can register to be notified when these events occur.
        /// </para>
        /// <para>
        /// Note  This enumeration value is supported starting with Windows 10.
        /// </para>
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_HARDWARE_TEARDOWN = 0x2000,

        /// <summary>
        /// <para>
        /// The secure environment is tightly coupled with the GPU
        /// and an <see cref="ID3D11CryptoSession"/> should be used for communication
        /// between the user mode DRM component and the secure execution environment.
        /// </para>
        /// <para>
        /// Note  This enumeration value is supported starting with Windows 10.
        /// </para>
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_HARDWARE_DRM_COMMUNICATION = 0x4000,

        /// <summary>
        /// 
        /// </summary>
        D3D11_CONTENT_PROTECTION_CAPS_HARDWARE_DRM_COMMUNICATION_MULTI_THREADED = 0x8000,
    }
}
