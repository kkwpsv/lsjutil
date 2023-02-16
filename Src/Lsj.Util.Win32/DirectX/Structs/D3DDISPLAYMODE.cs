using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the display mode.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddisplaymode"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DDISPLAYMODE
    {
        /// <summary>
        /// Screen width, in pixels.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// Screen height, in pixels.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// Refresh rate.
        /// The value of 0 indicates an adapter default.
        /// </summary>
        public UINT RefreshRate;

        /// <summary>
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, describing the surface format of the display mode.
        /// </summary>
        public D3DFORMAT Format;
    }
}
