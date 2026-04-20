using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines constants that specify logical operations to configure for a render target.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_logic_op"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_RENDER_TARGET_BLEND_DESC"/> structure.
    /// </remarks>
    public enum D3D12_LOGIC_OP
    {
        /// <summary>
        /// Clears the render target (0).
        /// </summary>
        D3D12_LOGIC_OP_CLEAR = 0,

        /// <summary>
        /// Sets the render target (1).
        /// </summary>
        D3D12_LOGIC_OP_SET = (D3D12_LOGIC_OP_CLEAR + 1),

        /// <summary>
        /// Copys the render target (<c>s</c> source from Pixel Shader output).
        /// </summary>
        D3D12_LOGIC_OP_COPY = (D3D12_LOGIC_OP_SET + 1),

        /// <summary>
        /// Performs an inverted-copy of the render target (<c>~s</c>).
        /// </summary>
        D3D12_LOGIC_OP_COPY_INVERTED = (D3D12_LOGIC_OP_COPY + 1),

        /// <summary>
        /// No operation is performed on the render target (<c>d</c> destination in the Render Target View).
        /// </summary>
        D3D12_LOGIC_OP_NOOP = (D3D12_LOGIC_OP_COPY_INVERTED + 1),

        /// <summary>
        /// Inverts the render target (<c>~d</c>).
        /// </summary>
        D3D12_LOGIC_OP_INVERT = (D3D12_LOGIC_OP_NOOP + 1),

        /// <summary>
        /// Performs a logical AND operation on the render target (<c>s &amp; d</c>).
        /// </summary>
        D3D12_LOGIC_OP_AND = (D3D12_LOGIC_OP_INVERT + 1),

        /// <summary>
        /// Performs a logical NAND operation on the render target (<c>~(s &amp; d)</c>).
        /// </summary>
        D3D12_LOGIC_OP_NAND = (D3D12_LOGIC_OP_AND + 1),

        /// <summary>
        /// Performs a logical OR operation on the render target (<c>s | d</c>).
        /// </summary>
        D3D12_LOGIC_OP_OR = (D3D12_LOGIC_OP_NAND + 1),

        /// <summary>
        /// Performs a logical NOR operation on the render target (<c>~(s | d)</c>).
        /// </summary>
        D3D12_LOGIC_OP_NOR = (D3D12_LOGIC_OP_OR + 1),

        /// <summary>
        /// Performs a logical XOR operation on the render target (<c>s ^ d</c>).
        /// </summary>
        D3D12_LOGIC_OP_XOR = (D3D12_LOGIC_OP_NOR + 1),

        /// <summary>
        /// Performs a logical equal operation on the render target (<c>~(s ^ d)</c>).
        /// </summary>
        D3D12_LOGIC_OP_EQUIV = (D3D12_LOGIC_OP_XOR + 1),

        /// <summary>
        /// Performs a logical AND and reverse operation on the render target (<c>s &amp; ~d</c>).
        /// </summary>
        D3D12_LOGIC_OP_AND_REVERSE = (D3D12_LOGIC_OP_EQUIV + 1),

        /// <summary>
        /// Performs a logical AND and invert operation on the render target (<c>~s &amp; d</c>).
        /// </summary>
        D3D12_LOGIC_OP_AND_INVERTED = (D3D12_LOGIC_OP_AND_REVERSE + 1),

        /// <summary>
        /// Performs a logical OR and reverse operation on the render target (<c>s | ~d</c>).
        /// </summary>
        D3D12_LOGIC_OP_OR_REVERSE = (D3D12_LOGIC_OP_AND_INVERTED + 1),

        /// <summary>
        /// Performs a logical OR and invert operation on the render target (<c>~s | d</c>).
        /// </summary>
        D3D12_LOGIC_OP_OR_INVERTED = (D3D12_LOGIC_OP_OR_REVERSE + 1)
    }
}
