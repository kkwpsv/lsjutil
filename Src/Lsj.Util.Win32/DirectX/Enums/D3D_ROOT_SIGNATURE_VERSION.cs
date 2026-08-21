using static Lsj.Util.Win32.DirectX.D3D12;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the version of root signature layout.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d_root_signature_version"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by the following structures and methods.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="D3D12_VERSIONED_ROOT_SIGNATURE_DESC"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_FEATURE_DATA_ROOT_SIGNATURE"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12VersionedRootSignatureDeserializer.GetRootSignatureDescAtVersion"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12SerializeRootSignature"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    public enum D3D_ROOT_SIGNATURE_VERSION
    {
        /// <summary>
        /// Version one of root signature layout.
        /// </summary>
        D3D_ROOT_SIGNATURE_VERSION_1 = 0x1,

        /// <summary>
        /// Version one of root signature layout.
        /// </summary>
        D3D_ROOT_SIGNATURE_VERSION_1_0 = 0x1,

        /// <summary>
        /// Version 1.1 of root signature layout.
        /// Refer to Root Signature Version 1.1.
        /// </summary>
        D3D_ROOT_SIGNATURE_VERSION_1_1 = 0x2,

        /// <summary>
        /// 
        /// </summary>
        D3D_ROOT_SIGNATURE_VERSION_1_2 = 0x3
    }
}
