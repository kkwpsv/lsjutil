using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.Marshals.ByValStructs;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ADAPTER_FLAG;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes an adapter (or video card) using DXGI 1.1.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_adapter_desc1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="DXGI_ADAPTER_DESC1"/> structure provides a DXGI 1.1 description of an adapter.
    /// This structure is initialized by using the <see cref="IDXGIAdapter1.GetDesc1"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_ADAPTER_DESC1
    {
        /// <summary>
        /// A string that contains the adapter description.
        /// On feature level 9 graphics hardware, <see cref="IDXGIAdapter1.GetDesc1"/> returns “Software Adapter” for the description string.
        /// </summary>
        public ByValStringStructForSize128 Description;

        /// <summary>
        /// The PCI ID of the hardware vendor.
        /// On feature level 9 graphics hardware, <see cref="IDXGIAdapter.GetDesc"/> returns zeros for the PCI ID of the hardware vendor.
        /// </summary>
        public UINT VendorId;

        /// <summary>
        /// The PCI ID of the hardware device.
        /// On feature level 9 graphics hardware, <see cref="IDXGIAdapter.GetDesc"/> returns zeros for the PCI ID of the hardware device.
        /// </summary>
        public UINT DeviceId;

        /// <summary>
        /// The PCI ID of the sub system.
        /// On feature level 9 graphics hardware, <see cref="IDXGIAdapter.GetDesc"/> returns zeros for the PCI ID of the sub system.
        /// </summary>
        public UINT SubSysId;

        /// <summary>
        /// The PCI ID of the revision number of the adapter.
        /// On feature level 9 graphics hardware, <see cref="IDXGIAdapter.GetDesc"/> returns zeros for the PCI ID of the revision number of the adapter.
        /// </summary>
        public UINT Revision;

        /// <summary>
        /// The number of bytes of dedicated video memory that are not shared with the CPU.
        /// </summary>
        public SIZE_T DedicatedVideoMemory;

        /// <summary>
        /// The number of bytes of dedicated system memory that are not shared with the CPU.
        /// This memory is allocated from available system memory at boot time.
        /// </summary>
        public SIZE_T DedicatedSystemMemory;

        /// <summary>
        /// The number of bytes of shared system memory.
        /// This is the maximum value of system memory that may be consumed by the adapter during operation.
        /// Any incidental memory consumed by the driver as it manages and uses video memory is additional.
        /// </summary>
        public SIZE_T SharedSystemMemory;

        /// <summary>
        /// A unique value that identifies the adapter.
        /// See <see cref="LUID"/> for a definition of the structure.
        /// <see cref="LUID"/> is defined in dxgi.h.
        /// </summary>
        public LUID AdapterLuid;

        /// <summary>
        /// A value of the <see cref="DXGI_ADAPTER_FLAG"/> enumerated type that describes the adapter type.
        /// The <see cref="DXGI_ADAPTER_FLAG_REMOTE"/> flag is reserved.
        /// </summary>
        public DXGI_ADAPTER_FLAG Flags;
    }
}
