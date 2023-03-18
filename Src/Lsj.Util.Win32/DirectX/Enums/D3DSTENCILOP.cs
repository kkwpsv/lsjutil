namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines stencil-buffer operations.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dstencilop"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Stencil-buffer entries are integer values ranging from 0 through 2ⁿ - 1, where n is the bit depth of the stencil buffer.
    /// </remarks>
    public enum D3DSTENCILOP
    {
        /// <summary>
        /// Do not update the entry in the stencil buffer.
        /// This is the default value.
        /// </summary>
        D3DSTENCILOP_KEEP = 1,

        /// <summary>
        /// Set the stencil-buffer entry to 0.
        /// </summary>
        D3DSTENCILOP_ZERO = 2,

        /// <summary>
        /// Replace the stencil-buffer entry with a reference value.
        /// </summary>
        D3DSTENCILOP_REPLACE = 3,

        /// <summary>
        /// Increment the stencil-buffer entry, clamping to the maximum value.
        /// </summary>
        D3DSTENCILOP_INCRSAT = 4,

        /// <summary>
        /// Decrement the stencil-buffer entry, clamping to zero.
        /// </summary>
        D3DSTENCILOP_DECRSAT = 5,

        /// <summary>
        /// Invert the bits in the stencil-buffer entry.
        /// </summary>
        D3DSTENCILOP_INVERT = 6,

        /// <summary>
        /// Increment the stencil-buffer entry, wrapping to zero if the new value exceeds the maximum value.
        /// </summary>
        D3DSTENCILOP_INCR = 7,

        /// <summary>
        /// Decrement the stencil-buffer entry, wrapping to the maximum value if the new value is less than zero.
        /// </summary>
        D3DSTENCILOP_DECR = 8,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DSTENCILOP_FORCE_DWORD = 0x7fffffff,
    }
}
