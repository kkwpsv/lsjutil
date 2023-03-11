namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the faces of a cubemap.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcubemap-faces"/>
    /// </para>
    /// </summary>
    public enum D3DCUBEMAP_FACES
    {
        /// <summary>
        /// Positive x-face of the cubemap.
        /// </summary>
        D3DCUBEMAP_FACE_POSITIVE_X = 0,

        /// <summary>
        /// Negative x-face of the cubemap.
        /// </summary>
        D3DCUBEMAP_FACE_NEGATIVE_X = 1,

        /// <summary>
        /// Positive y-face of the cubemap.
        /// </summary>
        D3DCUBEMAP_FACE_POSITIVE_Y = 2,

        /// <summary>
        /// Negative y-face of the cubemap.
        /// </summary>
        D3DCUBEMAP_FACE_NEGATIVE_Y = 3,

        /// <summary>
        /// Positive z-face of the cubemap.
        /// </summary>
        D3DCUBEMAP_FACE_POSITIVE_Z = 4,

        /// <summary>
        /// Negative z-face of the cubemap.
        /// </summary>
        D3DCUBEMAP_FACE_NEGATIVE_Z = 5,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DCUBEMAP_FACE_FORCE_DWORD = unchecked((int)0xffffffff),
    }
}
