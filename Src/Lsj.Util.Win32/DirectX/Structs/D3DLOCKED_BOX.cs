using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a locked box (volume).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dlocked-box"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Volumes can be visualized as being organized into slices of width x height 2D surfaces stacked up to make a width x height x depth volume.
    /// For more information, see Volume Texture Resources (Direct3D 9).
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DLOCKED_BOX
    {
        /// <summary>
        /// Byte offset from the left edge of one row to the left edge of the next row.
        /// </summary>
        public int RowPitch;

        /// <summary>
        /// Byte offset from the top-left of one slice to the top-left of the next deepest slice.
        /// </summary>
        public int SlicePitch;

        /// <summary>
        /// Pointer to the beginning of the volume box.
        /// If a <see cref="D3DBOX"/> was provided to the <see cref="IDirect3DVolume9.LockBox"/> call,
        /// <see cref="pBits"/> will be appropriately offset from the start of the volume.
        /// </summary>
        public nint pBits;
    }
}
