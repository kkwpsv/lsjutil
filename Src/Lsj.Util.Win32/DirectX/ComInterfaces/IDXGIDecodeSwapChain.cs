using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_PRESENT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_EFFECT;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a swap chain that is used by desktop media apps to decode video data and show it on a DirectComposition surface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nn-dxgi1_3-idxgidecodeswapchain"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Decode swap chains are intended for use primarily with YUV surface formats.
    /// When using decode buffers created with an RGB surface format, the TargetRect and DestSize must be set equal to the buffer dimensions.
    /// SourceRect cannot exceed the buffer dimensions.
    /// In clone mode, the decode swap chain is only guaranteed to be shown on the primary output.
    /// Decode swap chains cannot be used with dirty rects.
    /// </remarks>
    public unsafe struct IDXGIDecodeSwapChain
    {
        IntPtr* _vTable;

        /// <summary>
        /// Presents a frame on the output adapter.
        /// The frame is a subresource of the <see cref="IDXGIResource"/> object that was used to create the decode swap chain.
        /// </summary>
        /// <param name="BufferToPresent">
        /// An index indicating which member of the subresource array to present.
        /// </param>
        /// <param name="SyncInterval">
        /// An integer that specifies how to synchronize presentation of a frame with the vertical blank.
        /// For the bit-block transfer (bitblt) model (<see cref="DXGI_SWAP_EFFECT_DISCARD"/> or <see cref="DXGI_SWAP_EFFECT_SEQUENTIAL"/>), values are:
        /// 0 - The presentation occurs immediately, there is no synchronization.
        /// 1,2,3,4 - Synchronize presentation after the nth vertical blank.
        /// For the flip model (<see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/>), values are:
        /// 0 - Cancel the remaining time on the previously presented frame and discard this frame if a newer frame is queued.
        /// n > 0 - Synchronize presentation for at least n vertical blanks.
        /// </param>
        /// <param name="Flags">
        /// An integer value that contains swap-chain presentation options.
        /// These options are defined by the <see cref="DXGI_PRESENT"/> constants.
        /// The <see cref="DXGI_PRESENT_USE_DURATION"/> flag must be set if a custom present duration (custom refresh rate) is being used.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success, or it returns one of the following error codes:
        /// <see cref="DXGI_ERROR_DEVICE_REMOVED"/>, <see cref="DXGI_STATUS_OCCLUDED"/>, <see cref="DXGI_ERROR_INVALID_CALL"/>, <see cref="E_OUTOFMEMORY"/>
        /// </returns>
        public HRESULT PresentBuffer([In] UINT BufferToPresent, [In] UINT SyncInterval, [In] DXGI_PRESENT Flags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, DXGI_PRESENT, HRESULT>)_vTable[3])(thisPtr, BufferToPresent, SyncInterval, Flags);
            }
        }

        /// <summary>
        /// Sets the rectangle that defines the source region for the video processing blit operation.
        /// The source rectangle is the portion of the input surface that is blitted to the destination surface.
        /// The source rectangle is given in pixel coordinates, relative to the input surface.
        /// </summary>
        /// <param name="pRect">
        /// A pointer to a <see cref="RECT"/> structure that contains the source region to set for the swap chain.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success,
        /// or it returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT SetSourceRect([In] in RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in RECT, HRESULT>)_vTable[4])(thisPtr, pRect);
            }
        }

        /// <summary>
        /// Sets the rectangle that defines the target region for the video processing blit operation.
        /// The target rectangle is the area within the destination surface where the output will be drawn.
        /// The target rectangle is given in pixel coordinates, relative to the destination surface.
        /// </summary>
        /// <param name="pRect">
        /// A pointer to a <see cref="RECT"/> structure that contains the target region to set for the swap chain.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success,
        /// or it returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT SetTargetRect([In] in RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in RECT, HRESULT>)_vTable[5])(thisPtr, pRect);
            }
        }

        /// <summary>
        /// Sets the size of the destination surface to use for the video processing blit operation.
        /// The destination rectangle is the portion of the output surface that receives the blit for this stream.
        /// The destination rectangle is given in pixel coordinates, relative to the output surface.
        /// </summary>
        /// <param name="Width">
        /// The width of the destination size, in pixels.
        /// </param>
        /// <param name="Height">
        /// The height of the destination size, in pixels.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success,
        /// or it returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT SetDestSize([In] UINT Width, [In] UINT Height)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, UINT, HRESULT>)_vTable[6])(thisPtr, Width, Height);
            }
        }

        /// <summary>
        /// Gets the source region that is used for the swap chain.
        /// </summary>
        /// <param name="pRect">
        /// A pointer to a <see cref="RECT"/> structure that receives the source region for the swap chain.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success,
        /// or it returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT GetSourceRect([Out] out RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out RECT, HRESULT>)_vTable[7])(thisPtr, out pRect);
            }
        }

        /// <summary>
        /// Gets the rectangle that defines the target region for the video processing blit operation.
        /// </summary>
        /// <param name="pRect">
        /// A pointer to a <see cref="RECT"/> structure that receives the target region for the swap chain.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success,
        /// or it returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT GetTargetRect([Out] out RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out RECT, HRESULT>)_vTable[8])(thisPtr, out pRect);
            }
        }

        /// <summary>
        /// Gets the size of the destination surface to use for the video processing blit operation.
        /// </summary>
        /// <param name="pWidth">
        /// A pointer to a variable that receives the width in pixels.
        /// </param>
        /// <param name="pHeight">
        /// A pointer to a variable that receives the height in pixels.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success,
        /// or it returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT GetDestSize([Out] out UINT pWidth, [Out] out UINT pHeight)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, out UINT, HRESULT>)_vTable[9])(thisPtr, out pWidth, out pHeight);
            }
        }

        /// <summary>
        /// Sets the color space used by the swap chain.
        /// </summary>
        /// <param name="ColorSpace">
        /// A pointer to a combination of <see cref="DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies the color space to set for the swap chain.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success,
        /// or it returns one of the error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT SetColorSpace([In] DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS ColorSpace)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS, HRESULT>)_vTable[10])(thisPtr, ColorSpace);
            }
        }

        /// <summary>
        /// Gets the color space used by the swap chain.
        /// </summary>
        /// <returns>
        /// A combination of <see cref="DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies the color space for the swap chain.
        /// </returns>
        public DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS GetColorSpace()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS>)_vTable[11])(thisPtr);
            }
        }
    }
}
