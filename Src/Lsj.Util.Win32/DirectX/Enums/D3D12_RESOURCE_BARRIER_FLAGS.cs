using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Flags for setting split resource barriers.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_barrier_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Split barriers allow a single transition to be split into begin and end halves (refer to Multi-engine synchronization).
    /// </para>
    /// <para>
    /// This enum is used by the <see cref="D3D12_RESOURCE_BARRIER.Flags"/> member of the <see cref="D3D12_RESOURCE_BARRIER"/> structure.
    /// </para>
    /// </remarks>
    [Flags]
    public enum D3D12_RESOURCE_BARRIER_FLAGS
    {
        /// <summary>
        /// No flags.
        /// </summary>
        D3D12_RESOURCE_BARRIER_FLAG_NONE = 0,

        /// <summary>
        /// This starts a barrier transition in a new state, putting a resource in a temporary no-access condition.
        /// </summary>
        D3D12_RESOURCE_BARRIER_FLAG_BEGIN_ONLY = 0x1,

        /// <summary>
        /// This barrier completes a transition, setting a new state and restoring active access to a resource.
        /// </summary>
        D3D12_RESOURCE_BARRIER_FLAG_END_ONLY = 0x2
    }
}
