namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This enumeration is supported by the Direct3D 11.1 runtime, which is available on Windows 8 and later operating systems.
    /// </para>
    /// <para>
    /// Specifies logical operations to configure for a render target.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/ne-d3d11_1-d3d11_logic_op"/>
    /// </para>
    /// </summary>
    public enum D3D11_LOGIC_OP
    {
        /// <summary>
        /// Clears the render target.
        /// </summary>
        D3D11_LOGIC_OP_CLEAR = 0,

        /// <summary>
        /// Sets the render target.
        /// </summary>
        D3D11_LOGIC_OP_SET,

        /// <summary>
        /// Copys the render target.
        /// </summary>
        D3D11_LOGIC_OP_COPY,

        /// <summary>
        /// Performs an inverted-copy of the render target.
        /// </summary>
        D3D11_LOGIC_OP_COPY_INVERTED,

        /// <summary>
        /// No operation is performed on the render target.
        /// </summary>
        D3D11_LOGIC_OP_NOOP,

        /// <summary>
        /// Inverts the render target.
        /// </summary>
        D3D11_LOGIC_OP_INVERT,

        /// <summary>
        /// Performs a logical AND operation on the render target.
        /// </summary>
        D3D11_LOGIC_OP_AND,

        /// <summary>
        /// Performs a logical NAND operation on the render target.
        /// </summary>
        D3D11_LOGIC_OP_NAND,

        /// <summary>
        /// Performs a logical OR operation on the render target.
        /// </summary>
        D3D11_LOGIC_OP_OR,

        /// <summary>
        /// Performs a logical NOR operation on the render target.
        /// </summary>
        D3D11_LOGIC_OP_NOR,

        /// <summary>
        /// Performs a logical XOR operation on the render target.
        /// </summary>
        D3D11_LOGIC_OP_XOR,

        /// <summary>
        /// Performs a logical equal operation on the render target.
        /// </summary>
        D3D11_LOGIC_OP_EQUIV,

        /// <summary>
        /// Performs a logical AND and reverse operation on the render target.
        /// </summary>
        D3D11_LOGIC_OP_AND_REVERSE,

        /// <summary>
        /// Performs a logical AND and invert operation on the render target.
        /// </summary>
        D3D11_LOGIC_OP_AND_INVERTED,

        /// <summary>
        /// Performs a logical OR and reverse operation on the render target.
        /// </summary>
        D3D11_LOGIC_OP_OR_REVERSE,

        /// <summary>
        /// Performs a logical OR and invert operation on the render target.
        /// </summary>
        D3D11_LOGIC_OP_OR_INVERTED,
    }
}
