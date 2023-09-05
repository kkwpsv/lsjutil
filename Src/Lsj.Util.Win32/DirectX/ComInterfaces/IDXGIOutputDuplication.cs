using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDXGIOutputDuplication"/> interface accesses and manipulates the duplicated desktop image.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgioutputduplication"/>
    /// </para>
    /// </summary>
    public unsafe struct IDXGIOutputDuplication
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves a description of a duplicated output.
        /// This description specifies the dimensions of the surface that contains the desktop image.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_OUTDUPL_DESC"/> structure that describes the duplicated output.
        /// This parameter must not be <see cref="NullRef{DXGI_OUTDUPL_DESC}"/>.
        /// </param>
        /// <returns>
        /// After an application creates an <see cref="IDXGIOutputDuplication"/> interface,
        /// it calls <see cref="GetDesc"/> to retrieve the dimensions of the surface that contains the desktop image.
        /// The format of the desktop image is always <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/>.
        /// </returns>
        public HRESULT GetDesc([Out] out DXGI_OUTDUPL_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_OUTDUPL_DESC, HRESULT>)_vTable[7])(thisPtr, out pDesc);
            }
        }

        /// <summary>
        /// Indicates that the application is ready to process the next desktop image.
        /// </summary>
        /// <param name="TimeoutInMilliseconds">
        /// The time-out interval, in milliseconds.
        /// This interval specifies the amount of time that this method waits for a new frame before it returns to the caller.
        /// This method returns if the interval elapses, and a new desktop image is not available.
        /// For more information about the time-out interval, see Remarks.
        /// </param>
        /// <param name="pFrameInfo">
        /// A pointer to a memory location that receives the <see cref="DXGI_OUTDUPL_FRAME_INFO"/> structure
        /// that describes timing and presentation statistics for a frame.
        /// </param>
        /// <param name="ppDesktopResource">
        /// A pointer to a variable that receives the <see cref="IDXGIResource"/> interface of the surface that contains the desktop bitmap.
        /// </param>
        /// <returns>
        /// <see cref="AcquireNextFrame"/> returns:
        /// <see cref="S_OK"/> if it successfully received the next desktop image.
        /// <see cref="DXGI_ERROR_ACCESS_LOST"/> if the desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid when a different type of image is displayed on the desktop.
        /// Examples of this situation are:
        /// Desktop switch
        /// Mode change
        /// Switch from DWM on, DWM off, or other full-screen application
        /// In this situation, the application must release the <see cref="IDXGIOutputDuplication"/> interface
        /// and create a new <see cref="IDXGIOutputDuplication"/> for the new content.
        /// <see cref="DXGI_ERROR_WAIT_TIMEOUT"/> if the time-out interval elapsed before the next desktop frame was available.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application called <see cref="AcquireNextFrame"/> without releasing the previous frame.
        /// <see cref="E_INVALIDARG"/> if one of the parameters to <see cref="AcquireNextFrame"/> is incorrect;
        /// for example, if <paramref name="pFrameInfo"/> is <see cref="NullRef{DXGI_OUTDUPL_FRAME_INFO}"/>.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        /// <remarks>
        /// When <see cref="AcquireNextFrame"/> returns successfully, the calling application can access the desktop image
        /// that <see cref="AcquireNextFrame"/> returns in the variable at <paramref name="ppDesktopResource"/>.
        /// If the caller specifies a zero time-out interval in the <paramref name="TimeoutInMilliseconds"/> parameter,
        /// <see cref="AcquireNextFrame"/> verifies whether there is a new desktop image available, returns immediately, and indicates its outcome with the return value.
        /// If the caller specifies an <see cref="INFINITE"/> time-out interval in the <paramref name="TimeoutInMilliseconds"/> parameter, the time-out interval never elapses.
        /// Note
        /// You cannot cancel the wait that you specified in the <paramref name="TimeoutInMilliseconds"/> parameter.
        /// Therefore, if you must periodically check for other conditions (for example, a terminate signal), you should specify a non-INFINITE time-out interval.
        /// After the time-out interval elapses, you can check for these other conditions and then call <see cref="AcquireNextFrame"/> again to wait for the next frame.
        /// <see cref="AcquireNextFrame"/> acquires a new desktop frame
        /// when the operating system either updates the desktop bitmap image or changes the shape or position of a hardware pointer.
        /// The new frame that <see cref="AcquireNextFrame"/> acquires might have only the desktop image updated, only the pointer shape or position updated, or both.
        /// </remarks>
        public HRESULT AcquireNextFrame([In] UINT TimeoutInMilliseconds, [Out] out DXGI_OUTDUPL_FRAME_INFO pFrameInfo, [Out] out P<IDXGIResource> ppDesktopResource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out DXGI_OUTDUPL_FRAME_INFO, out P<IDXGIResource>, HRESULT>)_vTable[8])
                    (thisPtr, TimeoutInMilliseconds, out pFrameInfo, out ppDesktopResource);
            }
        }

        /// <summary>
        /// Gets information about dirty rectangles for the current desktop frame.
        /// </summary>
        /// <param name="DirtyRectsBufferSize">
        /// The size in bytes of the buffer that the caller passed to the <paramref name="pDirtyRectsBuffer"/> parameter.
        /// </param>
        /// <param name="pDirtyRectsBuffer">
        /// A pointer to an array of <see cref="RECT"/> structures that identifies the dirty rectangle regions for the desktop frame.
        /// </param>
        /// <param name="pDirtyRectsBufferSizeRequired">
        /// Pointer to a variable that receives the number of bytes that <see cref="GetFrameDirtyRects"/> needs
        /// to store information about dirty regions in the buffer at <paramref name="pDirtyRectsBuffer"/>.
        /// For more information about returning the required buffer size, see Remarks.
        /// </param>
        /// <returns>
        /// <see cref="GetFrameDirtyRects"/> returns:
        /// <see cref="S_OK"/> if it successfully retrieved information about dirty rectangles.
        /// <see cref="DXGI_ERROR_ACCESS_LOST"/> if the desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid when a different type of image is displayed on the desktop.
        /// Examples of this situation are:
        /// Desktop switch
        /// Mode change
        /// Switch from DWM on, DWM off, or other full-screen application
        /// In this situation, the application must release the <see cref="IDXGIOutputDuplication"/> interface
        /// and create a new <see cref="IDXGIOutputDuplication"/> for the new content.
        /// <see cref="DXGI_ERROR_MORE_DATA"/> if the buffer that the calling application provided was not big enough.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application called <see cref="GetFrameDirtyRects"/> without owning the desktop image.
        /// <see cref="E_INVALIDARG"/> if one of the parameters to <see cref="GetFrameDirtyRects"/> is incorrect;
        /// for example, if <paramref name="pDirtyRectsBuffer"/> is <see langword="null"/>.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        /// <remarks>
        /// <see cref="GetFrameDirtyRects"/> stores a size value in the variable at <paramref name="pDirtyRectsBufferSizeRequired"/>.
        /// This value specifies the number of bytes that <see cref="GetFrameDirtyRects"/> needs to store information about dirty regions.
        /// You can use this value in the following situations to determine the amount of memory to allocate
        /// for future buffers that you pass to <paramref name="pDirtyRectsBuffer"/>:
        /// <see cref="GetFrameDirtyRects"/> fails with <see cref="DXGI_ERROR_MORE_DATA"/> because the buffer is not big enough.
        /// <see cref="GetFrameDirtyRects"/> supplies a buffer that is bigger than necessary.
        /// The size value returned at <paramref name="pDirtyRectsBufferSizeRequired"/> informs the caller
        /// how much buffer space was actually used compared to how much buffer space the caller allocated
        /// and specified in the <paramref name="DirtyRectsBufferSize"/> parameter.
        /// The caller can also use the value returned at <paramref name="pDirtyRectsBufferSizeRequired"/>
        /// to determine the number of RECTs returned in the <paramref name="pDirtyRectsBuffer"/> array.
        /// The buffer contains the list of dirty RECTs for the current frame.
        /// Note
        /// To produce a visually accurate copy of the desktop, an application must first process all move RECTs before it processes dirty RECTs.
        /// </remarks>
        public HRESULT GetFrameDirtyRects([In] UINT DirtyRectsBufferSize, [Out] RECT[] pDirtyRectsBuffer, [Out] out UINT pDirtyRectsBufferSizeRequired)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (RECT* pDirtyRectsBufferPtr = pDirtyRectsBuffer)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, UINT, RECT*, out UINT, HRESULT>)_vTable[9])
                        (thisPtr, DirtyRectsBufferSize, pDirtyRectsBufferPtr, out pDirtyRectsBufferSizeRequired);
                }
            }
        }

        /// <summary>
        /// Gets information about the moved rectangles for the current desktop frame.
        /// </summary>
        /// <param name="MoveRectsBufferSize">
        /// The size in bytes of the buffer that the caller passed to the <paramref name="pMoveRectBuffer"/> parameter.
        /// </param>
        /// <param name="pMoveRectBuffer">
        /// A pointer to an array of <see cref="DXGI_OUTDUPL_MOVE_RECT"/> structures that identifies the moved rectangle regions for the desktop frame.
        /// </param>
        /// <param name="pMoveRectsBufferSizeRequired">
        /// Pointer to a variable that receives the number of bytes that <see cref="GetFrameMoveRects"/> needs
        /// to store information about moved regions in the buffer at <paramref name="pMoveRectBuffer"/>.
        /// For more information about returning the required buffer size, see Remarks.
        /// </param>
        /// <returns>
        /// <see cref="GetFrameMoveRects "/> returns:
        /// <see cref="S_OK"/> if it successfully retrieved information about moved rectangles.
        /// <see cref="DXGI_ERROR_ACCESS_LOST"/> if the desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid when a different type of image is displayed on the desktop.
        /// Examples of this situation are:
        /// Desktop switch
        /// Mode change
        /// Switch from DWM on, DWM off, or other full-screen application
        /// In this situation, the application must release the <see cref="IDXGIOutputDuplication"/> interface
        /// and create a new <see cref="IDXGIOutputDuplication"/> for the new content.
        /// <see cref="DXGI_ERROR_MORE_DATA"/> if the buffer that the calling application provided was not big enough.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application called <see cref="GetFrameMoveRects"/> without owning the desktop image.
        /// <see cref="E_INVALIDARG"/> if one of the parameters to <see cref="GetFrameMoveRects"/> is incorrect;
        /// for example, if <paramref name="pMoveRectBuffer"/> is <see langword="null"/>.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        /// <remarks>
        /// <see cref="GetFrameMoveRects"/> stores a size value in the variable at <paramref name="pMoveRectsBufferSizeRequired"/>.
        /// This value specifies the number of bytes that <see cref="GetFrameMoveRects"/> needs to store information about moved regions.
        /// You can use this value in the following situations to determine the amount of memory to allocate
        /// for future buffers that you pass to <paramref name="pMoveRectBuffer"/>:
        /// <see cref="GetFrameMoveRects"/> fails with <see cref="DXGI_ERROR_MORE_DATA"/> because the buffer is not big enough.
        /// <see cref="GetFrameMoveRects"/> supplies a buffer that is bigger than necessary.
        /// The size value returned at <paramref name="pMoveRectsBufferSizeRequired"/> informs the caller
        /// how much buffer space was actually used compared to how much buffer space the caller allocated
        /// and specified in the <paramref name="MoveRectsBufferSize"/> parameter.
        /// The caller can also use the value returned at <paramref name="pMoveRectsBufferSizeRequired"/>
        /// to determine the number of <see cref="DXGI_OUTDUPL_MOVE_RECT"/> structures returned.
        /// The buffer contains the list of dirty RECTs for the current frame.
        /// Note
        /// To produce a visually accurate copy of the desktop, an application must first process all move RECTs before it processes dirty RECTs.
        /// </remarks>
        public HRESULT GetFrameMoveRects([In] UINT MoveRectsBufferSize, [Out] DXGI_OUTDUPL_MOVE_RECT[] pMoveRectBuffer, [Out] out UINT pMoveRectsBufferSizeRequired)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (DXGI_OUTDUPL_MOVE_RECT* pMoveRectBufferPtr = pMoveRectBuffer)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, UINT, DXGI_OUTDUPL_MOVE_RECT*, out UINT, HRESULT>)_vTable[10])
                        (thisPtr, MoveRectsBufferSize, pMoveRectBufferPtr, out pMoveRectsBufferSizeRequired);
                }
            }
        }

        /// <summary>
        /// Gets information about the new pointer shape for the current desktop frame.
        /// </summary>
        /// <param name="PointerShapeBufferSize">
        /// The size in bytes of the buffer that the caller passed to the <paramref name="pPointerShapeBuffer"/> parameter.
        /// </param>
        /// <param name="pPointerShapeBuffer">
        /// A pointer to a buffer to which <see cref="GetFramePointerShape"/> copies and returns pixel data for the new pointer shape.
        /// </param>
        /// <param name="pPointerShapeBufferSizeRequired">
        /// Pointer to a variable that receives the number of bytes that <see cref="GetFramePointerShape"/> needs to store
        /// the new pointer shape pixel data in the buffer at <paramref name="pPointerShapeBuffer"/>.
        /// For more information about returning the required buffer size, see Remarks.
        /// </param>
        /// <param name="pPointerShapeInfo">
        /// Pointer to a <see cref="DXGI_OUTDUPL_POINTER_SHAPE_INFO"/> structure that receives the pointer shape information.
        /// </param>
        /// <returns>
        /// <see cref="GetFramePointerShape"/> returns:
        /// <see cref="S_OK"/> if it successfully retrieved information about the new pointer shape.
        /// <see cref="DXGI_ERROR_ACCESS_LOST"/> if the desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid when a different type of image is displayed on the desktop.
        /// Examples of this situation are:
        /// Desktop switch
        /// Mode change
        /// Switch from DWM on, DWM off, or other full-screen application
        /// In this situation, the application must release the <see cref="IDXGIOutputDuplication"/> interface
        /// and create a new <see cref="IDXGIOutputDuplication"/> for the new content.
        /// <see cref="DXGI_ERROR_MORE_DATA"/> if the buffer that the calling application provided was not big enough.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application called <see cref="GetFramePointerShape"/> without owning the desktop image.
        /// <see cref="E_INVALIDARG"/> if one of the parameters to <see cref="GetFramePointerShape"/> is incorrect;
        /// for example, if <paramref name="pPointerShapeInfo"/> is <see cref="NullRef{DXGI_OUTDUPL_POINTER_SHAPE_INFO}"/>.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        /// <remarks>
        /// <see cref="GetFramePointerShape"/> stores a size value in the variable at <paramref name="pPointerShapeBufferSizeRequired"/>.
        /// This value specifies the number of bytes that <paramref name="pPointerShapeBufferSizeRequired"/> needs to store the new pointer shape pixel data.
        /// You can use this value in the following situations to determine the amount of memory to allocate
        /// for future buffers that you pass to <paramref name="pPointerShapeBuffer"/>:
        /// <see cref="GetFramePointerShape"/> fails with <see cref="DXGI_ERROR_MORE_DATA"/> because the buffer is not big enough.
        /// <see cref="GetFramePointerShape"/> supplies a buffer that is bigger than necessary.
        /// The size value returned at <paramref name="pPointerShapeBufferSizeRequired"/> informs the caller
        /// how much buffer space was actually used compared to how much buffer space the caller allocated
        /// and specified in the <paramref name="PointerShapeBufferSize"/> parameter.
        /// The <paramref name="pPointerShapeInfo"/> parameter describes the new pointer shape.
        /// </remarks>
        public HRESULT GetFramePointerShape([In] UINT PointerShapeBufferSize, [In] IntPtr pPointerShapeBuffer,
            [Out] out UINT pPointerShapeBufferSizeRequired, [Out] out DXGI_OUTDUPL_POINTER_SHAPE_INFO pPointerShapeInfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, IntPtr, out UINT, out DXGI_OUTDUPL_POINTER_SHAPE_INFO, HRESULT>)_vTable[11])
                    (thisPtr, PointerShapeBufferSize, pPointerShapeBuffer, out pPointerShapeBufferSizeRequired, out pPointerShapeInfo);
            }
        }

        /// <summary>
        /// Provides the CPU with efficient access to a desktop image if that desktop image is already in system memory.
        /// </summary>
        /// <param name="pLockedRect">
        /// A pointer to a <see cref="DXGI_MAPPED_RECT"/> structure that receives the surface data
        /// that the CPU needs to directly access the surface data.
        /// </param>
        /// <returns>
        /// <see cref="MapDesktopSurface"/> returns:
        /// <see cref="S_OK"/> if it successfully retrieved the surface data.
        /// <see cref="DXGI_ERROR_ACCESS_LOST"/> if the desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid when a different type of image is displayed on the desktop.
        /// Examples of this situation are:
        /// Desktop switch
        /// Mode change
        /// Switch from DWM on, DWM off, or other full-screen application
        /// In this situation, the application must release the <see cref="IDXGIOutputDuplication"/> interface
        /// and create a new <see cref="IDXGIOutputDuplication"/> for the new content.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application already has an outstanding map on the desktop image.
        /// The application must call <see cref="UnMapDesktopSurface"/> before it calls <see cref="MapDesktopSurface"/> again.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> is also returned if the application did not own the desktop image when it called <see cref="MapDesktopSurface"/>.
        /// <see cref="DXGI_ERROR_UNSUPPORTED"/> if the desktop image is not in system memory.
        /// In this situation, the application must first transfer the image to a staging surface
        /// and then lock the image by calling the <see cref="IDXGISurface.Map"/> method.
        /// <see cref="E_INVALIDARG"/> if the <paramref name="pLockedRect"/> parameter is incorrect;
        /// for example, if <paramref name="pLockedRect"/> is <see cref="NullRef{DXGI_MAPPED_RECT}"/>.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        /// <remarks>
        /// You can successfully call <see cref="MapDesktopSurface"/> if the <see cref="DXGI_OUTDUPL_DESC.DesktopImageInSystemMemory"/> member
        /// of the <see cref="DXGI_OUTDUPL_DESC"/> structure is set to <see cref="TRUE"/>.
        /// If <see cref="DXGI_OUTDUPL_DESC.DesktopImageInSystemMemory"/> is <see cref="FALSE"/>,
        /// <see cref="MapDesktopSurface"/> returns <see cref="DXGI_ERROR_UNSUPPORTED"/>.
        /// Call <see cref="GetDesc"/> to retrieve the <see cref="DXGI_OUTDUPL_DESC"/> structure.
        /// </remarks>
        public HRESULT MapDesktopSurface([Out] out DXGI_MAPPED_RECT pLockedRect)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_MAPPED_RECT, HRESULT>)_vTable[12])(thisPtr, out pLockedRect);
            }
        }

        /// <summary>
        /// Invalidates the pointer to the desktop image that was retrieved by using <see cref="MapDesktopSurface"/>.
        /// </summary>
        /// <returns>
        /// <see cref="UnMapDesktopSurface"/> returns:
        /// <see cref="S_OK"/> if it successfully completed.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application did not map the desktop surface by calling <see cref="MapDesktopSurface"/>.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        public HRESULT UnMapDesktopSurface()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[13])(thisPtr);
            }
        }

        /// <summary>
        /// Indicates that the application finished processing the frame.
        /// </summary>
        /// <returns>
        /// <see cref="ReleaseFrame"/> returns:
        /// <see cref="S_OK"/> if it successfully completed.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application already released the frame.
        /// <see cref="DXGI_ERROR_ACCESS_LOST"/> if the desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid when a different type of image is displayed on the desktop.
        /// Examples of this situation are:
        /// Desktop switch
        /// Mode change
        /// Switch from DWM on, DWM off, or other full-screen application
        /// In this situation, the application must release the <see cref="IDXGIOutputDuplication"/> interface
        /// and create a new <see cref="IDXGIOutputDuplication"/> for the new content.
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        /// <remarks>
        /// The application must release the frame before it acquires the next frame.
        /// After the frame is released, the surface that contains the desktop bitmap becomes invalid;
        /// you will not be able to use the surface in a DirectX graphics operation.
        /// For performance reasons, we recommend that you release the frame
        /// just before you call the <see cref="AcquireNextFrame"/> method to acquire the next frame.
        /// When the client does not own the frame, the operating system copies all desktop updates to the surface.
        /// This can result in wasted GPU cycles if the operating system updates the same region for each frame that occurs.
        /// When the client acquires the frame, the client is aware of only the final update to this region;
        /// therefore, any overlapping updates during previous frames are wasted.
        /// When the client acquires a frame, the client owns the surface;
        /// therefore, the operating system can track only the updated regions and cannot copy desktop updates to the surface.
        /// Because of this behavior, we recommend that you minimize the time
        /// between the call to release the current frame and the call to acquire the next frame.
        /// </remarks>
        public HRESULT ReleaseFrame()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[14])(thisPtr);
            }
        }
    }
}
