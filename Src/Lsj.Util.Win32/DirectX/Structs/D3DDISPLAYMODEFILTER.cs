using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies types of display modes to filter out.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddisplaymodefilter"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DDISPLAYMODEFILTER
    {
        /// <summary>
        /// The size of this structure.
        /// This should always be set to <c>sizeof(D3DDISPLAYMODEFILTER)</c>.
        /// </summary>
        public UINT Size;

        /// <summary>
        /// The display mode format to filter out.
        /// See <see cref="D3DFORMAT"/>.
        /// </summary>
        public D3DFORMAT Format;

        /// <summary>
        /// Whether the scanline ordering is interlaced or progressive.
        /// See <see cref="D3DSCANLINEORDERING"/>.
        /// </summary>
        public D3DSCANLINEORDERING ScanLineOrdering;
    }
}
