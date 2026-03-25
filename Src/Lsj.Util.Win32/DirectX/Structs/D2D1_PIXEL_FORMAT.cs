using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains the data format and alpha mode for a bitmap or render target.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d1_pixel_format"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For more information about the pixel formats and alpha modes supported by each render target, see Supported Pixel Formats and Alpha Modes.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_PIXEL_FORMAT
    {
        /// <summary>
        /// A value that specifies the size and arrangement of channels in each pixel.
        /// </summary>
        public DXGI_FORMAT format;

        /// <summary>
        /// A value that specifies whether the alpha channel is using pre-multiplied alpha, straight alpha,
        /// whether it should be ignored and considered opaque, or whether it is unknown.
        /// </summary>
        public D2D1_ALPHA_MODE alphaMode;
    }
}
