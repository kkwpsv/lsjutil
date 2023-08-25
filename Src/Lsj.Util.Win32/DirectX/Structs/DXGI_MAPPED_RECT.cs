using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a mapped rectangle that is used to access a surface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/ns-dxgi-dxgi_mapped_rect"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="DXGI_MAPPED_RECT"/> structure is initialized by the <see cref="IDXGISurface.Map"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_MAPPED_RECT
    {
        /// <summary>
        /// A value that describes the width, in bytes, of the surface.
        /// </summary>
        public INT Pitch;

        /// <summary>
        /// A pointer to the image buffer of the surface.
        /// </summary>
        public IntPtr pBits;
    }
}
