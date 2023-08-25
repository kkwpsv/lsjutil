using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// D3D9ON12_ARGS
    /// </para>
    /// <para>
    /// From: <see href="https://microsoft.github.io/DirectX-Specs/d3d/TranslationLayerResourceInterop.html"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D9ON12_ARGS
    {
        /// <summary>
        /// <see cref="Enable9On12"/> Set <see cref="TRUE"/> to use 9On12 with the corresponding adapter.
        /// </summary>
        public BOOL Enable9On12;

        /// <summary>
        /// Optional pointer to the D3D12 Device to use.
        /// If this pointer is specified, this override applies to the display adapter with the same adapter LUID as the D3D12 Device.
        /// If <see cref="NULL"/> is specified and <see cref="Enable9On12"/> is <see cref="TRUE"/>,
        /// this override applies to any adapter that doesn’t match another override in the list.
        /// </summary>
        public IntPtr pD3D12Device;

        /// <summary>
        /// Optionally specify the Direct graphics command queue instance to use.
        /// If <see cref="NULL"/> and <see cref="Enable9on12"/> is <see cref="TRUE"/>, 9On12 will internally create the graphics queue.
        /// The second entry of this array is reserved.
        /// </summary>
        public ByValIntPtrArrayStructForSize2 ppD3D12Queues;

        /// <summary>
        /// Specifies the number of Queues in <see cref="ppD3D12Queues"/> array.
        /// Must be 0 or 1.
        /// See <see cref="ppD3D12Queues"/>.
        /// </summary>
        public UINT NumQueues;

        /// <summary>
        /// Specifies the nodes to use in linked display adapter.
        /// Zero specifies the default node 1.
        /// </summary>
        public UINT NodeMask;
    }
}
