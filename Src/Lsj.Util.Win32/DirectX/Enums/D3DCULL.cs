using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the supported culling modes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcull"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The values in this enumerated type are used by the <see cref="D3DRS_CULLMODE"/> render state.
    /// The culling modes define how back faces are culled when rendering a geometry.
    /// </remarks>
    public enum D3DCULL
    {
        /// <summary>
        /// Do not cull back faces.
        /// </summary>
        D3DCULL_NONE = 1,

        /// <summary>
        /// Cull back faces with clockwise vertices.
        /// </summary>
        D3DCULL_CW = 2,

        /// <summary>
        /// Cull back faces with counterclockwise vertices.
        /// </summary>
        D3DCULL_CCW = 3,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DCULL_FORCE_DWORD = 0x7fffffff,
    }
}
