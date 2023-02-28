namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines constants that describe transformation state values.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dtransformstatetype"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The transform states in the range 256 through 511 are reserved to store up to 256 world matrices
    /// that can be indexed using the <see cref="D3DTS_WORLDMATRIX"/> and <see cref="D3DTS_WORLD"/> macros.
    /// <see cref="D3DTS_WORLD"/>:
    /// Equivalent to <code>D3DTS_WORLDMATRIX(0)</code>.
    /// <see cref="D3DTS_WORLDMATRIX"/>(index):
    /// Identifies the transform matrix to set for the world matrix at index.
    /// Multiple world matrices are used only for vertex blending.
    /// Otherwise only <see cref="D3DTS_WORLD"/> is used.
    /// </remarks>
    public enum D3DTRANSFORMSTATETYPE
    {
        /// <summary>
        /// Identifies the transformation matrix being set as the view transformation matrix.
        /// The default value is NULL (the identity matrix).
        /// </summary>
        D3DTS_VIEW = 2,

        /// <summary>
        /// Identifies the transformation matrix being set as the projection transformation matrix.
        /// The default value is NULL (the identity matrix).
        /// </summary>
        D3DTS_PROJECTION = 3,

        /// <summary>
        /// Identifies the transformation matrix being set for the specified texture stage.
        /// </summary>
        D3DTS_TEXTURE0 = 16,

        /// <summary>
        /// Identifies the transformation matrix being set for the specified texture stage.
        /// </summary>
        D3DTS_TEXTURE1 = 17,

        /// <summary>
        /// Identifies the transformation matrix being set for the specified texture stage.
        /// </summary>
        D3DTS_TEXTURE2 = 18,

        /// <summary>
        /// Identifies the transformation matrix being set for the specified texture stage.
        /// </summary>
        D3DTS_TEXTURE3 = 19,

        /// <summary>
        /// Identifies the transformation matrix being set for the specified texture stage.
        /// </summary>
        D3DTS_TEXTURE4 = 20,

        /// <summary>
        /// Identifies the transformation matrix being set for the specified texture stage.
        /// </summary>
        D3DTS_TEXTURE5 = 21,

        /// <summary>
        /// Identifies the transformation matrix being set for the specified texture stage.
        /// </summary>
        D3DTS_TEXTURE6 = 22,

        /// <summary>
        /// Identifies the transformation matrix being set for the specified texture stage.
        /// </summary>
        D3DTS_TEXTURE7 = 23,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DTS_FORCE_DWORD = 0x7fffffff
    }
}
