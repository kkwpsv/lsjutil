using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a memory range.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_range"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="End"/> is one-past-the-end.
    /// When <see cref="Begin"/> equals <see cref="End"/>, the range is empty.
    /// The size of the range is (<see cref="End"/> - <see cref="Begin"/>).
    /// </para>
    /// <para>
    /// This structure is used by the <see cref="ID3D12Resource.Map"/> and <see cref="ID3D12Resource.Unmap"/> methods.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_RANGE
    {
        /// <summary>
        /// The offset, in bytes, denoting the beginning of a memory range.
        /// </summary>
        public SIZE_T Begin;

        /// <summary>
        /// The offset, in bytes, denoting the end of a memory range.
        /// <see cref="End"/> is one-past-the-end.
        /// </summary>
        public SIZE_T End;
    }
}
