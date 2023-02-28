using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Pixel shader driver caps.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9caps/ns-d3d9caps-d3dpshadercaps2_0"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DPSHADERCAPS2_0
    {
        /// <summary>
        /// Instruction predication is supported if this value is nonzero.
        /// See setp_comp - vs.
        /// </summary>
        public DWORD Caps;

        /// <summary>
        /// Either 0 or 24, which represents the depth of the dynamic flow control instruction nesting.
        /// See <see cref="D3DPSHADERCAPS2_0"/>.
        /// </summary>
        public INT DynamicFlowControlDepth;

        /// <summary>
        /// The number of temporary registers supported.
        /// See <see cref="D3DPSHADERCAPS2_0"/>.
        /// </summary>
        public INT NumTemps;

        /// <summary>
        /// The depth of nesting of the loop - vs/rep - vs and call - vs/callnz bool - vs instructions.
        /// See <see cref="D3DPSHADERCAPS2_0"/>.
        /// </summary>
        public INT StaticFlowControlDepth;

        /// <summary>
        /// The number of instruction slots supported.
        /// See <see cref="D3DPSHADERCAPS2_0"/>.
        /// </summary>
        public INT NumInstructionSlots;
    }
}
