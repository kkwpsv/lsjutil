using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Driver stencil capability flags.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dstencilcaps"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Stencil-buffer entries are integer values ranging from 0 through 2ⁿ - 1, where n is the bit depth of the stencil buffer.
    /// These constants are used by the <see cref="D3DCAPS9.StencilCaps"/> member of <see cref="D3DCAPS9"/>.
    /// </remarks>
    [Flags]
    public enum D3DSTENCILCAPS : uint
    {
        /// <summary>
        /// Do not update the entry in the stencil buffer. This is the default value.
        /// </summary>
        D3DSTENCILCAPS_KEEP = 0x00000001,

        /// <summary>
        /// Set the stencil-buffer entry to 0.
        /// </summary>
        D3DSTENCILCAPS_ZERO = 0x00000002,

        /// <summary>
        /// Replace the stencil-buffer entry with reference value.
        /// </summary>
        D3DSTENCILCAPS_REPLACE = 0x00000004,

        /// <summary>
        /// Increment the stencil-buffer entry, clamping to the maximum value.
        /// </summary>
        D3DSTENCILCAPS_INCRSAT = 0x00000008,

        /// <summary>
        /// Decrement the stencil-buffer entry, clamping to zero.
        /// </summary>
        D3DSTENCILCAPS_DECRSAT = 0x00000010,

        /// <summary>
        /// Invert the bits in the stencil-buffer entry.
        /// </summary>
        D3DSTENCILCAPS_INVERT = 0x00000020,

        /// <summary>
        /// Increment the stencil-buffer entry, wrapping to zero if the new value exceeds the maximum value.
        /// </summary>
        D3DSTENCILCAPS_INCR = 0x00000040,

        /// <summary>
        /// Decrement the stencil-buffer entry, wrapping to the maximum value if the new value is less than zero.
        /// </summary>
        D3DSTENCILCAPS_DECR = 0x00000080,

        /// <summary>
        /// The device supports two-sided stencil.
        /// </summary>
        D3DSTENCILCAPS_TWOSIDED = 0x00000100,
    }
}
