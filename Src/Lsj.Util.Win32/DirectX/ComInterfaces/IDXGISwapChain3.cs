using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Extends <see cref="IDXGISwapChain2"/> with methods to support getting the index of the swap chain's current back buffer and support for color space.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nn-dxgi1_4-idxgiswapchain3"/>
    /// </para>
    /// </summary>
    public unsafe struct IDXGISwapChain3
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the index of the swap chain's current back buffer.
        /// </summary>
        /// <returns>
        /// Returns the index of the current back buffer.
        /// </returns>
        public UINT GetCurrentBackBufferIndex()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT>)_vTable[36])(thisPtr);
            }
        }

        /// <summary>
        /// Checks the swap chain's support for color space.
        /// </summary>
        /// <param name="ColorSpace">
        /// A <see cref="DXGI_COLOR_SPACE_TYPE"/>-typed value that specifies color space type to check support for.
        /// </param>
        /// <param name="pColorSpaceSupport">
        /// A pointer to a variable that receives a combination of <see cref="DXGI_SWAP_CHAIN_COLOR_SPACE_SUPPORT_FLAG"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies options for color space support.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success, or it returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT CheckColorSpaceSupport([In] DXGI_COLOR_SPACE_TYPE ColorSpace, [Out] out UINT pColorSpaceSupport)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_COLOR_SPACE_TYPE, out UINT, HRESULT>)_vTable[37])(thisPtr, ColorSpace, out pColorSpaceSupport);
            }
        }

        /// <summary>
        /// Sets the color space used by the swap chain.
        /// </summary>
        /// <param name="ColorSpace">
        /// A <see cref="DXGI_COLOR_SPACE_TYPE"/>-typed value that specifies the color space to set.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success, or it returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT SetColorSpace1([In] DXGI_COLOR_SPACE_TYPE ColorSpace)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_COLOR_SPACE_TYPE, HRESULT>)_vTable[38])(thisPtr, ColorSpace);
            }
        }

        /// <summary>
        /// Changes the swap chain's back buffer size, format, and number of buffers, where the swap chain was created using a D3D12 command queue as an input device.
        /// This should be called when the application window is resized.
        /// </summary>
        /// <param name="BufferCount">
        /// The number of buffers in the swap chain (including all back and front buffers).
        /// This number can be different from the number of buffers with which you created the swap chain.
        /// This number can't be greater than <see cref="DXGI_MAX_SWAP_CHAIN_BUFFERS"/>.
        /// Set this number to zero to preserve the existing number of buffers in the swap chain.
        /// You can't specify less than two buffers for the flip presentation model.
        /// </param>
        /// <param name="Width">
        /// The new width of the back buffer.
        /// If you specify zero, DXGI will use the width of the client area of the target window.
        /// You can't specify the width as zero if you called the <see cref="IDXGIFactory2.CreateSwapChainForComposition"/> method to create the swap chain for a composition surface.
        /// </param>
        /// <param name="Height">
        /// The new height of the back buffer.
        /// If you specify zero, DXGI will use the height of the client area of the target window.
        /// You can't specify the height as zero if you called the <see cref="IDXGIFactory2.CreateSwapChainForComposition"/> method to create the swap chain for a composition surface.
        /// </param>
        /// <param name="NewFormat">
        /// A <see cref="DXGI_FORMAT"/>-typed value for the new format of the back buffer.
        /// Set this value to <see cref="DXGI_FORMAT_UNKNOWN"/> to preserve the existing format of the back buffer.
        /// The flip presentation model supports a more restricted set of formats than the bit-block transfer (bitblt) model.
        /// </param>
        /// <param name="SwapChainFlags">
        /// A combination of <see cref="DXGI_SWAP_CHAIN_FLAG"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies options for swap-chain behavior.
        /// </param>
        /// <param name="pCreationNodeMask">
        /// An array of UINTs, of total size <paramref name="BufferCount"/>, where the value indicates which node the back buffer should be created on.
        /// Buffers created using <see cref="ResizeBuffers1"/> with a non-null <paramref name="pCreationNodeMask"/> array are visible to all nodes.
        /// </param>
        /// <param name="ppPresentQueue">
        /// An array of command queues (<see cref="ID3D12CommandQueue"/> instances), of total size <paramref name="BufferCount"/>.
        /// Each queue provided must match the corresponding creation node mask specified in the <paramref name="pCreationNodeMask"/> array.
        /// When Present() is called, in addition to rotating to the next buffer for the next frame, the swapchain will also rotate through these command queues.
        /// This allows the app to control which queue requires synchronization for a given present operation.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise. For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// This method is only valid to call when the swapchain was created using a D3D12 command queue (<see cref="ID3D12CommandQueue"/>) as an input device.
        /// When a swapchain is created on a multi-GPU adapter, the backbuffers are all created on node 1 and only a single command queue is supported.
        /// <see cref="ResizeBuffers1"/> enables applications to create backbuffers on different nodes, allowing a different command queue to be used with each node.
        /// These capabilities enable Alternate Frame Rendering (AFR) techniques to be used with the swapchain. See Multi-adapter systems.
        /// Also see the Remarks section in <see cref="IDXGISwapChain.ResizeBuffers"/>, all of which is relevant to <see cref="ResizeBuffers1"/>.
        /// </remarks>
        public HRESULT ResizeBuffers1([In] UINT BufferCount, [In] UINT Width, [In] UINT Height, [In] DXGI_FORMAT NewFormat, [In] DXGI_SWAP_CHAIN_FLAG SwapChainFlags,
            [In] UINT[] pCreationNodeMask, [In] P<IUnknown>[] ppPresentQueue)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (UINT* pCreationNodeMaskPtr = pCreationNodeMask)
                {
                    fixed (P<IUnknown>* ppPresentQueuePtr = ppPresentQueue)
                    {
                        return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, UINT, DXGI_FORMAT, DXGI_SWAP_CHAIN_FLAG, UINT*, P<IUnknown>*, HRESULT>)_vTable[38])
                        (thisPtr, BufferCount, Width, Height, NewFormat, SwapChainFlags, pCreationNodeMaskPtr, ppPresentQueuePtr);
                    }
                }
            }
        }
    }
}
