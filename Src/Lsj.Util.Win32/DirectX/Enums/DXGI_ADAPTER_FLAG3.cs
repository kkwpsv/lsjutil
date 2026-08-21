using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FENCE_FLAGS;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the type of DXGI adapter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/ne-dxgi1_6-dxgi_adapter_flag3"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="DXGI_ADAPTER_FLAG3"/> enumerated type is used by the <see cref="DXGI_ADAPTER_DESC3.Flags"/> member
    /// of the <see cref="DXGI_ADAPTER_DESC3"/>  structure to identify the type of DXGI adapter.
    /// </remarks>
    [Flags]
    public enum DXGI_ADAPTER_FLAG3
    {
        /// <summary>
        /// Specifies no flags.
        /// </summary>
        DXGI_ADAPTER_FLAG_NONE = 0,

        /// <summary>
        /// Value always set to 0.
        /// This flag is reserved.
        /// </summary>
        DXGI_ADAPTER_FLAG_REMOTE = 1,

        /// <summary>
        /// <para>
        /// Specifies a software adapter.
        /// For more info about this flag, see new info in Windows 8 about enumerating adapters.
        /// </para>
        /// <para>
        /// Direct3D 11:
        /// This enumeration value is supported starting with Windows 8.
        /// </para>
        /// </summary>
        DXGI_ADAPTER_FLAG_SOFTWARE = 2,

        /// <summary>
        /// Specifies that the adapter's driver has been confirmed to work in an OS process
        /// where Arbitrary Code Guard (ACG) is enabled (i.e. dynamic code generation is disallowed).
        /// </summary>
        DXGI_ADAPTER_FLAG3_ACG_COMPATIBLE = 4,

        /// <summary>
        /// Specifies that the adapter supports monitored fences.
        /// These adapters support the <see cref="ID3D12Device.CreateFence"/> and <see cref="ID3D11Device5.CreateFence"/> functions.
        /// </summary>
        DXGI_ADAPTER_FLAG3_SUPPORT_MONITORED_FENCES = 8,

        /// <summary>
        /// <para>
        /// Specifies that the adapter supports non-monitored fences.
        /// These adapters support the <see cref="ID3D12Device.CreateFence"/> function together with the <see cref="D3D12_FENCE_FLAG_NON_MONITORED"/> flag.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For adapters that support both monitored and non-monitored fences, non-monitored fences are only supported
        /// when created with the <see cref="D3D12_FENCE_FLAG_SHARED"/> and <see cref="D3D12_FENCE_FLAG_SHARED_CROSS_ADAPTER"/> flags.
        /// Monitored fences should always be used by supporting adapters unless communicating with an adapter that only supports non-monitored fences.
        /// </para>
        /// </summary>
        DXGI_ADAPTER_FLAG3_SUPPORT_NON_MONITORED_FENCES = 0x10,

        /// <summary>
        /// Specifies that the adapter claims keyed mutex conformance.
        /// This signals a stronger guarantee that the IDXGIKeyedMutex interface behaves correctly.
        /// </summary>
        DXGI_ADAPTER_FLAG3_KEYED_MUTEX_CONFORMANCE = 0x20,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        DXGI_ADAPTER_FLAG_FORCE_DWORD = unchecked((int)0xffffffff),
    }
}
