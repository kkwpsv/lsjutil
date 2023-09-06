using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DXGI_OUTDUPL_FRAME_INFO"/> structure describes the current desktop image.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ns-dxgi1_2-dxgi_outdupl_frame_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A non-zero <see cref="LastMouseUpdateTime"/> indicates an update to either a mouse pointer position or a mouse pointer position and shape.
    /// That is, the mouse pointer position is always valid for a non-zero <see cref="LastMouseUpdateTime"/>;
    /// however, the application must check the value of the <see cref="PointerShapeBufferSize"/> member to determine whether the shape was updated too.
    /// If only the pointer was updated (that is, the desktop image was not updated),
    /// the <see cref="AccumulatedFrames"/>, <see cref="TotalMetadataBufferSize"/>, and <see cref="LastPresentTime"/> members are set to zero.
    /// An <see cref="AccumulatedFrames"/> value of one indicates that the application completed processing the last frame
    /// before a new desktop image was presented.
    /// If the <see cref="AccumulatedFrames"/> value is greater than one,
    /// more desktop image updates have occurred while the application processed the last desktop update.
    /// In this situation, the operating system accumulated the update regions.
    /// For more information about desktop updates, see Desktop Update Data.
    /// A non-zero <see cref="TotalMetadataBufferSize"/> indicates the total size of the buffers that are required to store all the desktop update metadata.
    /// An application cannot determine the size of each type of metadata.
    /// The application must call the <see cref="IDXGIOutputDuplication.GetFrameDirtyRects"/>, <see cref="IDXGIOutputDuplication.GetFrameMoveRects"/>,
    /// or <see cref="IDXGIOutputDuplication.GetFramePointerShape"/> method to obtain information about each type of metadata.
    /// Note
    /// To correct visual effects, an application must process the move region data before it processes the dirty rectangles.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_OUTDUPL_FRAME_INFO
    {
        /// <summary>
        /// The time stamp of the last update of the desktop image.
        /// The operating system calls the <see cref="QueryPerformanceCounter"/> function to obtain the value.
        /// A zero value indicates that the desktop image was not updated
        /// since an application last called the <see cref="IDXGIOutputDuplication.AcquireNextFrame"/> method to acquire the next frame of the desktop image.
        /// </summary>
        public LARGE_INTEGER LastPresentTime;

        /// <summary>
        /// The time stamp of the last update to the mouse.
        /// The operating system calls the <see cref="QueryPerformanceCounter"/> function to obtain the value.
        /// A zero value indicates that the position or shape of the mouse was not updated
        /// since an application last called the <see cref="IDXGIOutputDuplication.AcquireNextFrame"/> method to acquire the next frame of the desktop image.
        /// The mouse position is always supplied for a mouse update.
        /// A new pointer shape is indicated by a non-zero value in the <see cref="PointerShapeBufferSize"/> member.
        /// </summary>
        public LARGE_INTEGER LastMouseUpdateTime;

        /// <summary>
        /// The number of frames that the operating system accumulated in the desktop image surface
        /// since the calling application processed the last desktop image.
        /// For more information about this number, see Remarks.
        /// </summary>
        public UINT AccumulatedFrames;

        /// <summary>
        /// Specifies whether the operating system accumulated updates by coalescing dirty regions.
        /// Therefore, the dirty regions might contain unmodified pixels.
        /// <see cref="TRUE"/> if dirty regions were accumulated; otherwise, <see cref="FALSE"/>.
        /// </summary>
        public BOOL RectsCoalesced;

        /// <summary>
        /// Specifies whether the desktop image might contain protected content that was already blacked out in the desktop image.
        /// <see cref="TRUE"/> if protected content was already blacked; otherwise, <see cref="FALSE"/>.
        /// The application can use this information to notify the remote user that some of the desktop content might be protected and therefore not visible.
        /// </summary>
        public BOOL ProtectedContentMaskedOut;

        /// <summary>
        /// A <see cref="DXGI_OUTDUPL_POINTER_POSITION"/> structure that describes the most recent mouse position
        /// if the <see cref="LastMouseUpdateTime"/> member is a non-zero value; otherwise, this value is ignored.
        /// This value provides the coordinates of the location where the top-left-hand corner of the pointer shape is drawn;
        /// this value is not the desktop position of the hot spot.
        /// </summary>
        public DXGI_OUTDUPL_POINTER_POSITION PointerPosition;

        /// <summary>
        /// Size in bytes of the buffers to store all the desktop update metadata for this frame.
        /// For more information about this size, see Remarks.
        /// </summary>
        public UINT TotalMetadataBufferSize;

        /// <summary>
        /// Size in bytes of the buffer to hold the new pixel data for the mouse shape.
        /// For more information about this size, see Remarks.
        /// </summary>
        public UINT PointerShapeBufferSize;
    }
}
