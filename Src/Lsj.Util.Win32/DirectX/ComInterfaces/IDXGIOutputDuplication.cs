using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.Constants;

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
    /// <remarks>
    /// <para>
    /// A collaboration application can use <see cref="IDXGIOutputDuplication"/> to access the desktop image.
    /// <see cref="IDXGIOutputDuplication"/> is supported in Desktop Window Manager (DWM)
    /// on non-8bpp DirectX full-screen modes and non-8bpp OpenGL full-screen modes.
    /// 16-bit or 32-bit GDI non-DWM desktop modes are not supported.
    /// </para>
    /// <para>
    /// An application can use <see cref="IDXGIOutputDuplication"/> on a separate thread
    /// to receive the desktop images and to feed them into their specific image-processing pipeline.
    /// The application uses <see cref="IDXGIOutputDuplication"/> to perform the following operations:
    /// </para>
    /// <para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// Acquire the next desktop image.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Retrieve the information that describes the image.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Perform an operation on the image.
    /// This operation can be as simple as copying the image to a staging buffer
    /// so that the application can read the pixel data on the image.
    /// The application reads the pixel data after the application calls <see cref="IDXGISurface.Map"/>.
    /// Alternatively, this operation can be more complex.
    /// For example, the application can run some pixel shaders on the updated regions of the image
    /// to encode those regions for transmission to a client.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// After the application finishes processing each desktop image,
    /// it releases the image, loops to step 1, and repeats the steps.
    /// The application repeats these steps until it is finished processing desktop images.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// The following components of the operating system can generate the desktop image:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// The DWM by composing the desktop image
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// A full-screen DirectX or OpenGL application
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// An application by switching to a separate desktop,
    /// for example, the secure desktop that is used to display the login screen
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// All current <see cref="IDXGIOutputDuplication"/> interfaces become invalid
    /// when the operating system switches to a different component that produces the desktop image
    /// or when a mode change occurs.
    /// In these situations, the application must destroy its current <see cref="IDXGIOutputDuplication"/> interface
    /// and create a new <see cref="IDXGIOutputDuplication"/> interface.
    /// </para>
    /// <para>
    /// Examples of situations in which <see cref="IDXGIOutputDuplication"/> becomes invalid are:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Desktop switch
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Mode change
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Switch from DWM on, DWM off, or other full-screen application
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// In these situations, the application must release the <see cref="IDXGIOutputDuplication"/> interface
    /// and must create a new <see cref="IDXGIOutputDuplication"/> interface for the new content.
    /// If the application does not have the appropriate privilege to the new desktop image,
    /// its call to the <see cref="IDXGIOutput1.DuplicateOutput"/> method fails.
    /// </para>
    /// <para>
    /// While the application processes each desktop image,
    /// the operating system accumulates all the desktop image updates into a single update.
    /// For more information about desktop updates, see Updating the desktop image data.
    /// </para>
    /// <para>
    /// The desktop image is always in the <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/> format.
    /// </para>
    /// <para>
    /// The <see cref="IDXGIOutputDuplication"/> interface does not exist for Windows Store apps.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "191cfac3-a341-470d-b26e-a864f428319c", BeginVTableSlotIndex = 7, EndVTableSlotIndex = 14,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject)])]
    public unsafe struct IDXGIOutputDuplication
    {
        nint* _vTable;

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
        /// <para>
        /// The time-out interval, in milliseconds.
        /// This interval specifies the amount of time that this method waits for a new frame before it returns to the caller.
        /// This method returns if the interval elapses, and a new desktop image is not available.
        /// </para>
        /// <para>
        /// For more information about the time-out interval, see Remarks.
        /// </para>
        /// </param>
        /// <param name="pFrameInfo">
        /// A pointer to a memory location that receives the <see cref="DXGI_OUTDUPL_FRAME_INFO"/> structure
        /// that describes timing and presentation statistics for a frame.
        /// </param>
        /// <param name="ppDesktopResource">
        /// A pointer to a variable that receives the <see cref="IDXGIResource"/> interface of the surface that contains the desktop bitmap.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="AcquireNextFrame"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully received the next desktop image.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="DXGI_ERROR_ACCESS_LOST"/> if the desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid
        /// when a different type of image is displayed on the desktop.
        /// Examples of this situation are:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Desktop switch
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mode change
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Switch from DWM on, DWM off, or other full-screen application
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// In this situation, the application must release the <see cref="IDXGIOutputDuplication"/> interface
        /// and create a new <see cref="IDXGIOutputDuplication"/> for the new content.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_WAIT_TIMEOUT"/> if the time-out interval elapsed before the next desktop frame was available.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application called <see cref="AcquireNextFrame"/> without releasing the previous frame.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_INVALIDARG"/> if one of the parameters to <see cref="AcquireNextFrame"/> is incorrect;
        /// for example, if <paramref name="pFrameInfo"/> is <see cref="NullRef{DXGI_OUTDUPL_FRAME_INFO}"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When <see cref="AcquireNextFrame"/> returns successfully,
        /// the calling application can access the desktop image
        /// that <see cref="AcquireNextFrame"/> returns in the variable at <paramref name="ppDesktopResource"/>.
        /// If the caller specifies a zero time-out interval in the <paramref name="TimeoutInMilliseconds"/> parameter,
        /// <see cref="AcquireNextFrame"/> verifies whether there is a new desktop image available,
        /// returns immediately, and indicates its outcome with the return value.
        /// If the caller specifies an <see cref="INFINITE"/> time-out interval
        /// in the <paramref name="TimeoutInMilliseconds"/> parameter, the time-out interval never elapses.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// You cannot cancel the wait that you specified in the <see cref="TimeoutInMilliseconds"/> parameter.
        /// Therefore, if you must periodically check for other conditions (for example, a terminate signal),
        /// you should specify a non-<see cref="INFINITE"/> time-out interval.
        /// After the time-out interval elapses, you can check for these other conditions
        /// and then call <see cref="AcquireNextFrame"/> again to wait for the next frame.
        /// </para>
        /// <para>
        /// <see cref="AcquireNextFrame"/> acquires a new desktop frame
        /// when the operating system either updates the desktop bitmap image
        /// or changes the shape or position of a hardware pointer.
        /// The new frame that <see cref="AcquireNextFrame"/> acquires might have only the desktop image updated,
        /// only the pointer shape or position updated, or both.
        /// </para>
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
        /// A pointer to an array of <see cref="RECT"/> structures
        /// that identifies the dirty rectangle regions for the desktop frame.
        /// </param>
        /// <param name="pDirtyRectsBufferSizeRequired">
        /// <para>
        /// Pointer to a variable that receives the number of bytes
        /// that <see cref="GetFrameDirtyRects"/> needs to store information
        /// about dirty regions in the buffer at <paramref name="pDirtyRectsBuffer"/>.
        /// </para>
        /// <para>
        /// For more information about returning the required buffer size, see Remarks.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="GetFrameDirtyRects"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully retrieved information about dirty rectangles.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="DXGI_ERROR_ACCESS_LOST"/> if the desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid
        /// when a different type of image is displayed on the desktop.
        /// Examples of this situation are:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Desktop switch
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mode change
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Switch from DWM on, DWM off, or other full-screen application
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// In this situation, the application must release the <see cref="IDXGIOutputDuplication"/> interface
        /// and create a new <see cref="IDXGIOutputDuplication"/> for the new content.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_MORE_DATA"/> if the buffer that the calling application provided was not big enough.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application called <see cref="GetFrameDirtyRects"/> without owning the desktop image.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_INVALIDARG"/> if one of the parameters to <see cref="GetFrameDirtyRects"/> is incorrect;
        /// for example, if <paramref name="pDirtyRectsBuffer"/> is <see langword="null"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetFrameDirtyRects"/> stores a size value in the variable at <paramref name="pDirtyRectsBufferSizeRequired"/>.
        /// This value specifies the number of bytes that <see cref="GetFrameDirtyRects"/> needs to store information about dirty regions.
        /// You can use this value in the following situations to determine the amount of memory
        /// to allocate for future buffers that you pass to <paramref name="pDirtyRectsBuffer"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GetFrameDirtyRects"/> fails with <see cref="DXGI_ERROR_MORE_DATA"/> because the buffer is not big enough.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GetFrameDirtyRects"/> supplies a buffer that is bigger than necessary.
        /// The size value returned at <paramref name="pDirtyRectsBufferSizeRequired"/> informs the caller
        /// how much buffer space was actually used compared to how much buffer space the caller allocated
        /// and specified in the <paramref name="DirtyRectsBufferSize"/> parameter.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The caller can also use the value returned at <paramref name="pDirtyRectsBufferSizeRequired"/>
        /// to determine the number of <see cref="RECT"/>s returned in the <paramref name="pDirtyRectsBuffer"/> array.
        /// </para>
        /// <para>
        /// The buffer contains the list of dirty <see cref="RECT"/>s for the current frame.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// To produce a visually accurate copy of the desktop,
        /// an application must first process all move <see cref="RECT"/>s before it processes dirty <see cref="RECT"/>s.
        /// </para>
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
        /// A pointer to an array of <see cref="DXGI_OUTDUPL_MOVE_RECT"/> structures
        /// that identifies the moved rectangle regions for the desktop frame.
        /// </param>
        /// <param name="pMoveRectsBufferSizeRequired">
        /// <para>
        /// Pointer to a variable that receives the number of bytes
        /// that <see cref="GetFrameMoveRects"/> needs to store information
        /// about moved regions in the buffer at <paramref name="pMoveRectBuffer"/>.
        /// </para>
        /// <para>
        /// For more information about returning the required buffer size, see Remarks.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="GetFrameMoveRects"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully retrieved information about moved rectangles.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="DXGI_ERROR_ACCESS_LOST"/> if the desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid
        /// when a different type of image is displayed on the desktop.
        /// Examples of this situation are:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Desktop switch
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mode change
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Switch from DWM on, DWM off, or other full-screen application
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// In this situation, the application must release the <see cref="IDXGIOutputDuplication"/> interface
        /// and create a new <see cref="IDXGIOutputDuplication"/> for the new content.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_MORE_DATA"/> if the buffer that the calling application provided is not big enough.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application called <see cref="GetFrameMoveRects"/> without owning the desktop image.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_INVALIDARG"/> if one of the parameters to <see cref="GetFrameMoveRects"/> is incorrect;
        /// for example, if <paramref name="pMoveRectBuffer"/> is <see langword="null"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetFrameMoveRects"/> stores a size value in the variable at <paramref name="pMoveRectsBufferSizeRequired"/>.
        /// This value specifies the number of bytes that <see cref="GetFrameMoveRects"/> needs to store information about moved regions.
        /// You can use this value in the following situations to determine the amount of memory to allocate
        /// for future buffers that you pass to <paramref name="pMoveRectBuffer"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GetFrameMoveRects"/> fails with <see cref="DXGI_ERROR_MORE_DATA"/> because the buffer is not big enough.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GetFrameMoveRects"/> supplies a buffer that is bigger than necessary.
        /// The size value returned at <paramref name="pMoveRectsBufferSizeRequired"/> informs the caller
        /// how much buffer space was actually used compared to how much buffer space 
        /// the caller allocated and specified in the <paramref name="MoveRectsBufferSize"/> parameter.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The caller can also use the value returned at <paramref name="pMoveRectsBufferSizeRequired"/>
        /// to determine the number of <see cref="DXGI_OUTDUPL_MOVE_RECT"/> structures returned.
        /// </para>
        /// <para>
        /// The buffer contains the list of move <see cref="RECT"/>s for the current frame.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// To produce a visually accurate copy of the desktop,
        /// an application must first process all move <see cref="RECT"/>s before it processes dirty <see cref="RECT"/>s.
        /// </para>
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
        /// <para>
        /// Pointer to a variable that receives the number of bytes
        /// that <see cref="GetFramePointerShape"/> needs to store the new pointer shape pixel data
        /// in the buffer at <paramref name="pPointerShapeBuffer"/>.
        /// </para>
        /// <para>
        /// For more information about returning the required buffer size, see Remarks.
        /// </para>
        /// </param>
        /// <param name="pPointerShapeInfo">
        /// Pointer to a <see cref="DXGI_OUTDUPL_POINTER_SHAPE_INFO"/> structure that receives the pointer shape information.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="GetFramePointerShape"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully retrieved information about the new pointer shape.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="DXGI_ERROR_ACCESS_LOST"/> if the desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid
        /// when a different type of image is displayed on the desktop.
        /// Examples of this situation are:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Desktop switch
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mode change
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Switch from DWM on, DWM off, or other full-screen application
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// In this situation, the application must release the <see cref="IDXGIOutputDuplication"/> interface
        /// and create a new <see cref="IDXGIOutputDuplication"/> for the new content.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_MORE_DATA"/> if the buffer that the calling application provided was not big enough.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application called <see cref="GetFramePointerShape"/> without owning the desktop image.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_INVALIDARG"/> if one of the parameters to <see cref="GetFramePointerShape"/> is incorrect;
        /// for example, if <paramref name="pPointerShapeInfo"/> is <see cref="NullRef{DXGI_OUTDUPL_POINTER_SHAPE_INFO}"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetFramePointerShape"/> stores a size value in the variable at <paramref name="pPointerShapeBufferSizeRequired"/>.
        /// This value specifies the number of bytes that <paramref name="pPointerShapeBufferSizeRequired"/>
        /// needs to store the new pointer shape pixel data.
        /// You can use the value in the following situations to determine the amount of memory
        /// to allocate for future buffers that you pass to <paramref name="pPointerShapeBuffer"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="GetFramePointerShape"/> fails with <see cref="DXGI_ERROR_MORE_DATA"/> because the buffer is not big enough.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="GetFramePointerShape"/> supplies a bigger than necessary buffer.
        /// The size value returned at <paramref name="pPointerShapeBufferSizeRequired"/> informs the caller
        /// how much buffer space was actually used compared to how much buffer space
        /// the caller allocated and specified in the <paramref name="PointerShapeBufferSize"/> parameter.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <paramref name="pPointerShapeInfo"/> parameter describes the new pointer shape.
        /// </para>
        /// </remarks>
        public HRESULT GetFramePointerShape([In] UINT PointerShapeBufferSize, [In] nint pPointerShapeBuffer,
            [Out] out UINT pPointerShapeBufferSizeRequired, [Out] out DXGI_OUTDUPL_POINTER_SHAPE_INFO pPointerShapeInfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, nint, out UINT, out DXGI_OUTDUPL_POINTER_SHAPE_INFO, HRESULT>)_vTable[11])
                    (thisPtr, PointerShapeBufferSize, pPointerShapeBuffer, out pPointerShapeBufferSizeRequired, out pPointerShapeInfo);
            }
        }

        /// <summary>
        /// Provides the CPU with efficient access to a desktop image
        /// if that desktop image is already in system memory.
        /// </summary>
        /// <param name="pLockedRect">
        /// A pointer to a <see cref="DXGI_MAPPED_RECT"/> structure that receives the surface data
        /// that the CPU needs to directly access the surface data.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="MapDesktopSurface"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully retrieved the surface data.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="DXGI_ERROR_ACCESS_LOST"/> if the desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid
        /// when a different type of image is displayed on the desktop.
        /// Examples of this situation are:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Desktop switch
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mode change
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Switch from DWM on, DWM off, or other full-screen application
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// In this situation, the application must release the <see cref="IDXGIOutputDuplication"/> interface
        /// and create a new <see cref="IDXGIOutputDuplication"/> for the new content.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application already has an outstanding map on the desktop image.
        /// The application must call <see cref="UnMapDesktopSurface"/> before it calls <see cref="MapDesktopSurface"/> again.
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> is also returned
        /// if the application did not own the desktop image when it called <see cref="MapDesktopSurface"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_UNSUPPORTED"/> if the desktop image is not in system memory.
        /// In this situation, the application must first transfer the image to a staging surface
        /// and then lock the image by calling the <see cref="IDXGISurface.Map"/> method.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_INVALIDARG"/> if the <paramref name="pLockedRect"/> parameter is incorrect;
        /// for example, if <paramref name="pLockedRect"/> is <see cref="NullRef{DXGI_MAPPED_RECT}"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// You can successfully call <see cref="MapDesktopSurface"/>
        /// if the <see cref="DXGI_OUTDUPL_DESC.DesktopImageInSystemMemory"/> member
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
        /// Invalidates the pointer to the desktop image
        /// that was retrieved by using <see cref="MapDesktopSurface"/>.
        /// </summary>
        /// <returns>
        /// <para>
        /// <see cref="UnMapDesktopSurface"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully completed.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application did not map the desktop surface
        /// by calling <see cref="MapDesktopSurface"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
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
        /// <para>
        /// <see cref="ReleaseFrame"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if it successfully completed.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_INVALID_CALL"/> if the application already released the frame.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="DXGI_ERROR_ACCESS_LOST"/> if the desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid
        /// when a different type of image is displayed on the desktop.
        /// Examples of this situation are:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Desktop switch
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Mode change
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Switch from DWM on, DWM off, or other full-screen application
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// In this situation, the application must release the <see cref="IDXGIOutputDuplication"/> interface
        /// and create a new <see cref="IDXGIOutputDuplication"/> for the new content.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Possibly other error codes that are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The application must release the frame before it acquires the next frame.
        /// After the frame is released, the surface that contains the desktop bitmap becomes invalid;
        /// you will not be able to use the surface in a DirectX graphics operation.
        /// </para>
        /// <para>
        /// For performance reasons, we recommend that you release the frame
        /// just before you call the <see cref="AcquireNextFrame"/> method to acquire the next frame.
        /// When the client does not own the frame, the operating system copies all desktop updates to the surface.
        /// This can result in wasted GPU cycles if the operating system updates the same region for each frame that occurs.
        /// When the client acquires the frame, the client is aware of only the final update to this region;
        /// therefore, any overlapping updates during previous frames are wasted.
        /// When the client acquires a frame, the client owns the surface;
        /// therefore, the operating system can track only the updated regions and cannot copy desktop updates to the surface.
        /// Because of this behavior, we recommend that you minimize the time
        /// between the call to release the current frame and the call to acquire the next frame.
        /// </para>
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
