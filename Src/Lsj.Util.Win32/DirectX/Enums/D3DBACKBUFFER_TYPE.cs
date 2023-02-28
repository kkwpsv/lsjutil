namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines constants that describe the type of back buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dbackbuffer-type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Direct3D 9 does not support stereo view, so Direct3D does not use the <see cref="D3DBACKBUFFER_TYPE_LEFT"/>
    /// and <see cref="D3DBACKBUFFER_TYPE_RIGHT"/> values of this enumerated type.
    /// </remarks>
    public enum D3DBACKBUFFER_TYPE
    {
        /// <summary>
        /// Specifies a nonstereo swap chain.
        /// </summary>
        D3DBACKBUFFER_TYPE_MONO = 0,

        /// <summary>
        /// Specifies the left side of a stereo pair in a swap chain.
        /// </summary>
        D3DBACKBUFFER_TYPE_LEFT = 1,

        /// <summary>
        /// Specifies the right side of a stereo pair in a swap chain.
        /// </summary>
        D3DBACKBUFFER_TYPE_RIGHT = 2,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DBACKBUFFER_TYPE_FORCE_DWORD = 0x7fffffff,
    }
}
