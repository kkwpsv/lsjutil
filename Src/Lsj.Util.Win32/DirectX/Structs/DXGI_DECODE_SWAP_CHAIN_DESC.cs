using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Used with <see cref="IDXGIFactoryMedia.CreateDecodeSwapChainForCompositionSurfaceHandle"/> to describe a decode swap chain.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/ns-dxgi1_3-dxgi_decode_swap_chain_desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_DECODE_SWAP_CHAIN_DESC
    {
        /// <summary>
        /// Can be 0, or a combination of <see cref="DXGI_SWAP_CHAIN_FLAG_FULLSCREEN_VIDEO"/> and/or <see cref="DXGI_SWAP_CHAIN_FLAG_YUV_VIDEO"/>.
        /// Those named values are members of the <see cref="DXGI_SWAP_CHAIN_FLAG"/> enumerated type,
        /// and you can combine them by using a bitwise OR operation.
        /// The resulting value specifies options for decode swap-chain behavior.
        /// </summary>
        public DXGI_SWAP_CHAIN_FLAG Flags;
    }
}
