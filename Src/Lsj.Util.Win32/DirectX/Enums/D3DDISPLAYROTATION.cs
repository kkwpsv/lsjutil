using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENTFLAG;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how the monitor being used to display a full-screen application is rotated.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddisplayrotation"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enumeration is used in <see cref="IDirect3D9Ex.GetAdapterDisplayModeEx"/>,
    /// <see cref="IDirect3DDevice9Ex.GetDisplayModeEx"/>, and <see cref="IDirect3DSwapChain9Ex.GetDisplayModeEx"/>.
    /// </para>
    /// <para>
    /// Applications may choose to handle monitor rotation themselves by using the <see cref="D3DPRESENTFLAG_NOAUTOROTATE"/>,
    /// in which case, the application will need to know how the monitor is rotated so that it may adjust its rendering accordingly.
    /// </para>
    /// </remarks>
    public enum D3DDISPLAYROTATION
    {
        /// <summary>
        /// Display is not rotated.
        /// </summary>
        D3DDISPLAYROTATION_IDENTITY = 1,

        /// <summary>
        /// Display is rotated 90 degrees.
        /// </summary>
        D3DDISPLAYROTATION_90 = 2,

        /// <summary>
        /// Display is rotated 180 degrees.
        /// </summary>
        D3DDISPLAYROTATION_180 = 3,

        /// <summary>
        /// Display is rotated 270 degrees.
        /// </summary>
        D3DDISPLAYROTATION_270 = 4,
    }
}
