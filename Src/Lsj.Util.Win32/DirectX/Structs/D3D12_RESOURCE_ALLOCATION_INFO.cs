using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes parameters needed to allocate resources.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_allocation_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by the <see cref="ID3D12Device.GetResourceAllocationInfo"/>
    /// and <see cref="ID3D12Device4.GetResourceAllocationInfo1"/> methods.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_RESOURCE_ALLOCATION_INFO
    {
        /// <summary>
        /// The size, in bytes, of the resource.
        /// </summary>
        public UINT64 SizeInBytes;

        /// <summary>
        /// The alignment value for the resource; one of 4KB (4096), 64KB (65536), or 4MB (4194304) alignment.
        /// </summary>
        public UINT64 Alignment;
    }
}
