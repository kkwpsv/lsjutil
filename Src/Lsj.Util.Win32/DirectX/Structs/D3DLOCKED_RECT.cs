using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a locked rectangular region.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dlocked-rect"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The pitch for DXTn formats is different from what was returned in DirectX 7.
    /// It now refers to the number of bytes in a row of blocks.
    /// For example, if you have a width of 16, then you will have a pitch of 4 blocks (4*8 for DXT1, 4*16 for DXT2-5.)
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DLOCKED_RECT
    {
        /// <summary>
        /// Number of bytes in one row of the surface.
        /// </summary>
        public INT Pitch;

        /// <summary>
        /// Pointer to the locked bits.
        /// If a <see cref="RECT"/> was provided to the <see cref="IDirect3DSurface9.LockRect"/> call,
        /// <see cref="pBits"/> will be appropriately offset from the start of the surface.
        /// </summary>
        public nint pBits;
    }
}
