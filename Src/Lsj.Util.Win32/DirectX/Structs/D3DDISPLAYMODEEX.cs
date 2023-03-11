using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Information about the properties of a display mode.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddisplaymodeex"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used in various methods to create and manage Direct3D 9Ex devices (<see cref="IDirect3DDevice9Ex"/>) and swapchains (<see cref="IDirect3DSwapChain9Ex"/>).
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DDISPLAYMODEEX
    {
        /// <summary>
        /// The size of this structure.
        /// This should always be set to sizeof(D3DDISPLAYMODEEX).
        /// </summary>
        public UINT Size;

        /// <summary>
        /// Width of the display mode.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// Height of the display mode.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// Refresh rate of the display mode.
        /// </summary>
        public UINT RefreshRate;

        /// <summary>
        /// Format of the display mode.
        /// See <see cref="D3DFORMAT"/>.
        /// </summary>
        public D3DFORMAT Format;

        /// <summary>
        /// Indicates whether the scanline order is progressive or interlaced.
        /// See <see cref="D3DSCANLINEORDERING"/>.
        /// </summary>
        public D3DSCANLINEORDERING ScanLineOrdering;
    }
}
