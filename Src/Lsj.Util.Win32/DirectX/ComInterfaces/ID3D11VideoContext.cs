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
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_AUTHENTICATED_CHANNEL_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_CONTENT_PROTECTION_CAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_QUERY;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_USAGE;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_VIDEO_PROCESSOR_FEATURE_CAPS;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_VIDEO_PROCESSOR_OUTPUT_RATE;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_VIDEO_PROCESSOR_STEREO_FORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides the video functionality of a Microsoft Direct3D 11 device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11videocontext"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To get a pointer to this interface, call <see cref="IUnknown.QueryInterface"/> with an <see cref="ID3D11DeviceContext"/> interface pointer.
    /// </para>
    /// <para>
    /// This interface provides access to several areas of Microsoft Direct3Dvideo functionality:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Hardware-accelerated video decoding
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Video processing
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// GPU-based content protection
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Video encryption and decryption
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// In Microsoft Direct3D 9, the equivalent functions were distributed across several interfaces:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="IDirect3DAuthenticatedChannel9"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="IDirect3DCryptoSession9"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="IDirectXVideoDecoder"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="IDirectXVideoProcessor"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="IDXVAHD_VideoProcessor"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "61F21C45-3C0E-4a74-9CEA-67100D9AD5E4", BeginVTableSlotIndex = 7, EndVTableSlotIndex = 64,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D11DeviceChild)])]
    public unsafe struct ID3D11VideoContext
    {
        nint* _vTable;

        /// <summary>
        /// Gets a pointer to a decoder buffer.
        /// </summary>
        /// <param name="pDecoder">
        /// A pointer to the <see cref="ID3D11VideoDecoder"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoDecoder"/>.
        /// </param>
        /// <param name="Type">
        /// The type of buffer to retrieve, specified as a member of the <see cref="D3D11_VIDEO_DECODER_BUFFER_TYPE"/> enumeration.
        /// </param>
        /// <param name="pBufferSize">
        /// Receives the size of the buffer, in bytes.
        /// </param>
        /// <param name="ppBuffer">
        /// Receives a pointer to the start of the memory buffer.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The graphics driver allocates the buffers that are used for decoding.
        /// This method locks the Microsoft Direct3Dsurface that contains the buffer.
        /// When you are done using the buffer, call <see cref="ReleaseDecoderBuffer"/> to unlock the surface.
        /// </remarks>
        public HRESULT GetDecoderBuffer([In] P<ID3D11VideoDecoder> pDecoder, [In] D3D11_VIDEO_DECODER_BUFFER_TYPE Type, [Out] out UINT pBufferSize, [Out] out nint ppBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, D3D11_VIDEO_DECODER_BUFFER_TYPE, out UINT, out nint, HRESULT>)_vTable[7])
                    (thisPtr, pDecoder, Type, out pBufferSize, out ppBuffer);
            }
        }

        /// <summary>
        /// Releases a buffer that was obtained by calling the <see cref="GetDecoderBuffer"/> method.
        /// </summary>
        /// <param name="pDecoder">
        /// A pointer to the <see cref="ID3D11VideoDecoder"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoDecoder"/>.
        /// </param>
        /// <param name="Type">
        /// The type of buffer to release.
        /// Specify the same value that was used in the Type parameter of the <see cref="GetDecoderBuffer"/> method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT ReleaseDecoderBuffer([In] P<ID3D11VideoDecoder> pDecoder, [In] D3D11_VIDEO_DECODER_BUFFER_TYPE Type)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, D3D11_VIDEO_DECODER_BUFFER_TYPE, HRESULT>)_vTable[8])(thisPtr, pDecoder, Type);
            }
        }

        /// <summary>
        /// Starts a decoding operation to decode a video frame.
        /// </summary>
        /// <param name="pDecoder">
        /// A pointer to the <see cref="ID3D11VideoDecoder"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoDecoder"/>.
        /// </param>
        /// <param name="pView">
        /// A pointer to the <see cref="ID3D11VideoDecoderOutputView"/> interface.
        /// This interface describes the resource that will receive the decoded frame.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoDecoderOutputView"/>.
        /// </param>
        /// <param name="ContentKeySize">
        /// The size of the content key that is specified in <paramref name="pContentKey"/>. 
        /// If <paramref name="pContentKey"/> is <see cref="NULL"/>, set <paramref name="ContentKeySize"/> to zero.
        /// </param>
        /// <param name="pContentKey">
        /// An optional pointer to a content key that was used to encrypt the frame data.
        /// If no content key was used, set this parameter to <see cref="NULL"/>.
        /// If the caller provides a content key, the caller must use the session key to encrypt the content key.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// <see cref="D3DERR_WASSTILLDRAWING"/> or <see cref="E_PENDING"/> is returned if the hardware is busy,
        /// in which case the decoder should try to make the call again.
        /// </returns>
        /// <remarks>
        /// <para>
        /// After this method is called, call <see cref="SubmitDecoderBuffers"/> to perform decoding operations.
        /// When all decoding operations have been executed, call <see cref="DecoderEndFrame"/>.
        /// </para>
        /// <para>
        /// Each call to <see cref="DecoderBeginFrame"/> must have a matching call to <see cref="DecoderEndFrame"/>.
        /// In most cases you cannot nest <see cref="DecoderBeginFrame"/> calls,
        /// but some codecs, such as like VC-1, can have nested <see cref="DecoderBeginFrame"/> calls for special operations like post processing.
        /// </para>
        /// <para>
        /// The following encryption scenarios are supported through the content key:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The decoder can choose to not encrypt every frame, for example it may only encrypt the I frames and not encrypt the P/B frames.
        /// In these scenario, the decoder will specify <paramref name="pContentKey"/> = <see cref="NULL"/>
        /// and <paramref name="ContentKeySize"/> = 0 for those frames that it does not encrypt.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The decoder can choose to encrypt the compressed buffers using the session key.
        /// In this scenario, the decoder will specify a content key containing all zeros.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The decoder can choose to encrypt the compressed buffers using a separate content key.
        /// In this scenario, the decoder will ECB encrypt the content key using the session key and pass the encrypted content key.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT DecoderBeginFrame([In] P<ID3D11VideoDecoder> pDecoder, [In] P<ID3D11VideoDecoderOutputView> pView, [In] UINT ContentKeySize, [In] nint pContentKey)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, P<ID3D11VideoDecoderOutputView>, UINT, nint, HRESULT>)_vTable[9])
                    (thisPtr, pDecoder, pView, ContentKeySize, pContentKey);
            }
        }

        /// <summary>
        /// Signals the end of a decoding operation.
        /// </summary>
        /// <param name="pDecoder">
        /// A pointer to the <see cref="ID3D11VideoDecoder"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoDecoder"/>.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT DecoderEndFrame([In] P<ID3D11VideoDecoder> pDecoder)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, HRESULT>)_vTable[10])(thisPtr, pDecoder);
            }
        }

        /// <summary>
        /// Submits one or more buffers for decoding.
        /// </summary>
        /// <param name="pDecoder">
        /// A pointer to the <see cref="ID3D11VideoDecoder"/> interface.
        /// To get this pointer, call the <see cref="ID3D11VideoDevice.CreateVideoDecoder"/> method.
        /// </param>
        /// <param name="NumBuffers">
        /// The number of buffers submitted for decoding.
        /// </param>
        /// <param name="pBufferDesc">
        /// A pointer to an array of <see cref="D3D11_VIDEO_DECODER_BUFFER_DESC"/> structures.
        /// The <paramref name="NumBuffers"/> parameter specifies the number of elements in the array.
        /// Each element in the array describes a compressed buffer for decoding.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function does not honor a D3D11 predicate that may have been set.
        /// </para>
        /// <para>
        /// If the application uses D3D11 queries, this function may not be accounted
        /// for with <see cref="D3D11_QUERY_EVENT"/> and <see cref="D3D11_QUERY_TIMESTAMP"/> when using feature levels lower than 11.
        /// <see cref="D3D11_QUERY_PIPELINE_STATISTICS"/> will not include this function for any feature level.
        /// </para>
        /// <para>
        /// When using feature levels 9_x, all partially encrypted buffers
        /// must use the same <see cref="D3D11_VIDEO_DECODER_BUFFER_DESC.EncryptedBlockInfo"/>,
        /// and partial encryption cannot be turned off on a per frame basis.
        /// </para>
        /// </remarks>
        public HRESULT SubmitDecoderBuffers([In] P<ID3D11VideoDecoder> pDecoder, [In] UINT NumBuffers, [In] D3D11_VIDEO_DECODER_BUFFER_DESC[] pBufferDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, UINT, D3D11_VIDEO_DECODER_BUFFER_DESC[], HRESULT>)_vTable[11])
                    (thisPtr, pDecoder, NumBuffers, pBufferDesc);
            }
        }

        /// <summary>
        /// Performs an extended function for decoding.
        /// This method enables extensions to the basic decoder functionality.
        /// </summary>
        /// <param name="pDecoder">
        /// A pointer to the <see cref="ID3D11VideoDecoder"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoDecoder"/>.
        /// </param>
        /// <param name="pExtensionData">
        /// A pointer to a <see cref="D3D11_VIDEO_DECODER_EXTENSION"/> structure that contains data for the function.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT DecoderExtension([In] P<ID3D11VideoDecoder> pDecoder, [In] in D3D11_VIDEO_DECODER_EXTENSION pExtensionData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, in D3D11_VIDEO_DECODER_EXTENSION, HRESULT>)_vTable[12])(thisPtr, pDecoder, pExtensionData);
            }
        }

        /// <summary>
        /// Sets the target rectangle for the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="Enable">
        /// Specifies whether to apply the target rectangle.
        /// </param>
        /// <param name="pRect">
        /// A pointer to a <see cref="RECT"/> structure that specifies the target rectangle.
        /// If <paramref name="Enable"/> is <see cref="FALSE"/>, this parameter is ignored.
        /// </param>
        /// <remarks>
        /// <para>
        /// The target rectangle is the area within the destination surface where the output will be drawn.
        /// The target rectangle is given in pixel coordinates, relative to the destination surface.
        /// </para>
        /// <para>
        /// If this method is never called, or if the <paramref name="Enable"/> parameter is <see cref="FALSE"/>,
        /// the video processor writes to the entire destination surface.
        /// </para>
        /// </remarks>
        public void VideoProcessorSetOutputTargetRect([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] BOOL Enable, [In] in RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, BOOL, in RECT, void>)_vTable[13])(thisPtr, pVideoProcessor, Enable, pRect);
            }
        }

        /// <summary>
        /// Sets the background color for the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="YCbCr">
        /// If <see cref="TRUE"/>, the color is specified as a YCbCr value.
        /// Otherwise, the color is specified as an RGB value.
        /// </param>
        /// <param name="pColor">
        /// A pointer to a <see cref="D3D11_VIDEO_COLOR"/> structure that specifies the background color.
        /// </param>
        /// <remarks>
        /// The video processor uses the background color to fill areas of the target rectangle that do not contain a video image.
        /// Areas outside the target rectangle are not affected.
        /// </remarks>
        public void VideoProcessorSetOutputBackgroundColor([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] BOOL YCbCr, [In] in D3D11_VIDEO_COLOR pColor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, BOOL, in D3D11_VIDEO_COLOR, void>)_vTable[14])
                    (thisPtr, pVideoProcessor, YCbCr, pColor);
            }
        }

        /// <summary>
        /// Sets the output color space for the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="pColorSpace">
        /// A pointer to a <see cref="D3D11_VIDEO_PROCESSOR_COLOR_SPACE"/> structure that specifies the color space.
        /// </param>
        public void VideoProcessorSetOutputColorSpace([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] in D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, in D3D11_VIDEO_PROCESSOR_COLOR_SPACE, void>)_vTable[15])
                    (thisPtr, pVideoProcessor, pColorSpace);
            }
        }

        /// <summary>
        /// Sets the alpha fill mode for data that the video processor writes to the render target.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="AlphaFillMode">
        /// The alpha fill mode, specified as a <see cref="D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE"/> value.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of an input stream.
        /// This parameter is used if <paramref name="AlphaFillMode"/> is <see cref="D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_SOURCE_STREAM"/>.
        /// Otherwise, the parameter is ignored.
        /// </param>
        /// <remarks>
        /// <para>
        /// To find out which fill modes the device supports, call the <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/> method.
        /// If the driver reports the <see cref="D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_FILL"/> capability, the driver supports all of the fill modes.
        /// Otherwise, the <paramref name="AlphaFillMode"/> parameter must be <see cref="D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_OPAQUE"/>.
        /// </para>
        /// <para>
        /// The default fill mode is <see cref="D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_OPAQUE"/>.
        /// </para>
        /// </remarks>
        public void VideoProcessorSetOutputAlphaFillMode([In] P<ID3D11VideoProcessor> pVideoProcessor,
            [In] D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE AlphaFillMode, [In] UINT StreamIndex)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE, UINT, void>)_vTable[16])
                    (thisPtr, pVideoProcessor, AlphaFillMode, StreamIndex);
            }
        }

        /// <summary>
        /// Sets the amount of downsampling to perform on the output.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="Enable">
        /// If <see cref="TRUE"/>, downsampling is enabled.
        /// Otherwise, downsampling is disabled and the <paramref name="Size"/> member is ignored.
        /// </param>
        /// <param name="Size">
        /// The sampling size.
        /// </param>
        /// <remarks>
        /// <para>
        /// Downsampling is sometimes used to reduce the quality of premium content
        /// when other forms of content protection are not available. By default, downsampling is disabled.
        /// </para>
        /// <para>
        /// If the <paramref name="Enable"/> parameter is <see cref="TRUE"/>,
        /// the driver downsamples the composed image to the specified size, and then scales it back to the size of the target rectangle.
        /// </para>
        /// <para>
        /// The width and height of <paramref name="Size"/> must be greater than zero.
        /// If the size is larger than the target rectangle, downsampling does not occur.
        /// </para>
        /// <para>
        /// To use this feature, the driver must support downsampling, indicated by the <see cref="D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_CONSTRICTION"/> capability flag.
        /// To query for this capability, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>.
        /// </para>
        /// </remarks>
        public void VideoProcessorSetOutputConstriction([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] BOOL Enable, [In] SIZE Size)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, BOOL, SIZE, void>)_vTable[17])(thisPtr, pVideoProcessor, Enable, Size);
            }
        }

        /// <summary>
        /// Specifies whether the video processor produces stereo video frames.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="Enable">
        /// If <see cref="TRUE"/>, stereo output is enabled.
        /// Otherwise, the video processor produces mono video frames.
        /// </param>
        /// <remarks>
        /// <para>
        /// By default, the video processor produces mono video frames.
        /// </para>
        /// <para>
        /// To use this feature, the driver must support stereo video,
        /// indicated by the <see cref="D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_STEREO"/> capability flag.
        /// To query for this capability, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>.
        /// </para>
        /// </remarks>
        public void VideoProcessorSetOutputStereoMode([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] BOOL Enable)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, BOOL, void>)_vTable[18])(thisPtr, pVideoProcessor, Enable);
            }
        }

        /// <summary>
        /// Sets a driver-specific video processing state.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="pExtensionGuid">
        /// A pointer to a <see cref="GUID"/> that identifies the operation.
        /// The meaning of this <see cref="GUID"/> is defined by the graphics driver.
        /// </param>
        /// <param name="DataSize">
        /// The size of the <paramref name="pData"/> buffer, in bytes.
        /// </param>
        /// <param name="pData">
        /// A pointer to a buffer that contains private state data.
        /// The method passes this buffer directly to the driver without validation.
        /// It is the responsibility of the driver to validate the data.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT VideoProcessorSetOutputExtension([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] in GUID pExtensionGuid,
            [In] UINT DataSize, [In] nint pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, in GUID, UINT, nint, HRESULT>)_vTable[19])
                    (thisPtr, pVideoProcessor, pExtensionGuid, DataSize, pData);
            }
        }

        /// <summary>
        /// Gets the current target rectangle for the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="Enabled">
        /// Receives the value <see cref="TRUE"/> if the target rectangle was explicitly set
        /// using the <see cref="VideoProcessorSetOutputTargetRect"/> method.
        /// Receives the value <see cref="FALSE"/> if the target rectangle was disabled or was never set.
        /// </param>
        /// <param name="pRect">
        /// If <paramref name="Enabled"/> receives the value <see cref="TRUE"/>, this parameter receives the target rectangle.
        /// Otherwise, this parameter is ignored.
        /// </param>
        public void VideoProcessorGetOutputTargetRect([In] P<ID3D11VideoProcessor> pVideoProcessor, [Out] out BOOL Enabled, [Out] out RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, out BOOL, out RECT, void>)_vTable[20])(thisPtr, pVideoProcessor, out Enabled, out pRect);
            }
        }

        /// <summary>
        /// Gets the current background color for the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="pYCbCr">
        /// Receives the value <see cref="TRUE"/> if the background color is a YCbCr color,
        /// or <see cref="FALSE"/> if the background color is an RGB color.
        /// </param>
        /// <param name="pColor">
        /// A pointer to a <see cref="D3D11_VIDEO_COLOR"/> structure.
        /// The method fills in the structure with the background color.
        /// </param>
        public void VideoProcessorGetOutputBackgroundColor([In] P<ID3D11VideoProcessor> pVideoProcessor, [Out] out BOOL pYCbCr, [Out] out D3D11_VIDEO_COLOR pColor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, out BOOL, out D3D11_VIDEO_COLOR, void>)_vTable[21])
                    (thisPtr, pVideoProcessor, out pYCbCr, out pColor);
            }
        }

        /// <summary>
        /// Gets the current output color space for the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="pColorSpace">
        /// A pointer to a <see cref="D3D11_VIDEO_PROCESSOR_COLOR_SPACE"/> structure.
        /// The method fills in the structure with the output color space.
        /// </param>
        public void VideoProcessorGetOutputColorSpace([In] P<ID3D11VideoProcessor> pVideoProcessor, [Out] out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE, void>)_vTable[22])
                    (thisPtr, pVideoProcessor, out pColorSpace);
            }
        }

        /// <summary>
        /// Gets the current alpha fill mode for the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="pAlphaFillMode">
        /// Receives the alpha fill mode, as a <see cref="D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE"/> value.
        /// </param>
        /// <param name="pStreamIndex">
        /// If the alpha fill mode is <see cref="D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_SOURCE_STREAM"/>,
        /// this parameter receives the zero-based index of an input stream.
        /// The input stream provides the alpha values for the alpha fill.
        /// </param>
        public void VideoProcessorGetOutputAlphaFillMode([In] P<ID3D11VideoProcessor> pVideoProcessor,
            [Out] out D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE pAlphaFillMode, [Out] out UINT pStreamIndex)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, out D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE, out UINT, void>)_vTable[23])
                    (thisPtr, pVideoProcessor, out pAlphaFillMode, out pStreamIndex);
            }
        }

        /// <summary>
        /// Gets the current level of downsampling that is performed by the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="pEnabled">
        /// Receives the value <see cref="TRUE"/> if downsampling was explicitly enabled
        /// using the <see cref="VideoProcessorSetOutputConstriction"/> method.
        /// Receives the value <see cref="FALSE"/> if the downsampling was disabled or was never set.
        /// </param>
        /// <param name="pSize">
        /// If <paramref name="pEnabled"/> receives the value <see cref="TRUE"/>, this parameter receives the downsampling size.
        /// Otherwise, this parameter is ignored.
        /// </param>
        public void VideoProcessorGetOutputConstriction([In] P<ID3D11VideoProcessor> pVideoProcessor, [Out] out BOOL pEnabled, [Out] out SIZE pSize)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, out BOOL, out SIZE, void>)_vTable[24])
                    (thisPtr, pVideoProcessor, out pEnabled, out pSize);
            }
        }

        /// <summary>
        /// Queries whether the video processor produces stereo video frames.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="pEnabled">
        /// Receives the value <see cref="TRUE"/> if stereo output is enabled, or <see cref="FALSE"/> otherwise.
        /// </param>
        public void VideoProcessorGetOutputStereoMode([In] P<ID3D11VideoProcessor> pVideoProcessor, [Out] out BOOL pEnabled)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, out BOOL, void>)_vTable[25])(thisPtr, pVideoProcessor, out pEnabled);
            }
        }

        /// <summary>
        /// Gets private state data from the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="pExtensionGuid">
        /// A pointer to a <see cref="GUID"/> that identifies the state.
        /// The meaning of this <see cref="GUID"/> is defined by the graphics driver.
        /// </param>
        /// <param name="DataSize">
        /// The size of the <paramref name="pData"/> buffer, in bytes.
        /// </param>
        /// <param name="pData">
        /// A pointer to a buffer that receives the private state data.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT VideoProcessorGetOutputExtension([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] in GUID pExtensionGuid,
            [In] UINT DataSize, [In] nint pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, in GUID, UINT, nint, HRESULT>)_vTable[26])
                    (thisPtr, pVideoProcessor, pExtensionGuid, DataSize, pData);
            }
        }

        /// <summary>
        /// Specifies whether an input stream on the video processor contains interlaced or progressive frames.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="FrameFormat">
        /// A <see cref="D3D11_VIDEO_FRAME_FORMAT"/> value that specifies the interlacing.
        /// </param>
        public void VideoProcessorSetStreamFrameFormat([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] D3D11_VIDEO_FRAME_FORMAT FrameFormat)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, D3D11_VIDEO_FRAME_FORMAT, void>)_vTable[27])
                    (thisPtr, pVideoProcessor, StreamIndex, FrameFormat);
            }
        }

        /// <summary>
        /// Sets the color space for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pColorSpace">
        /// A pointer to a <see cref="D3D11_VIDEO_PROCESSOR_COLOR_SPACE"/> structure that specifies the color space.
        /// </param>
        public void VideoProcessorSetStreamColorSpace([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] in D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, in D3D11_VIDEO_PROCESSOR_COLOR_SPACE, void>)_vTable[28])
                    (thisPtr, pVideoProcessor, StreamIndex, pColorSpace);
            }
        }

        /// <summary>
        /// Sets the rate at which the video processor produces output frames for an input stream.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="OutputRate">
        /// The output rate, specified as a <see cref="D3D11_VIDEO_PROCESSOR_OUTPUT_RATE"/> value.
        /// </param>
        /// <param name="RepeatFrame">
        /// <para>
        /// Specifies how the driver performs frame-rate conversion, if required.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="TRUE"/>
        /// </term>
        /// <term>
        /// Repeat frames.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FALSE"/>
        /// </term>
        /// <term>
        /// Interpolate frames.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pCustomRate">
        /// A pointer to a <see cref="DXGI_RATIONAL"/> structure.
        /// If <paramref name="OutputRate"/> is <see cref="D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_CUSTOM"/>, this parameter specifies the exact output rate.
        /// Otherwise, this parameter is ignored and can be <see cref="NULL"/>.
        /// </param>
        /// <remarks>
        /// <para>
        /// The standard output rates are normal frame-rate (<see cref="D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_NORMAL"/>)
        /// and half frame-rate (<see cref="D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_HALF"/>).
        /// In addition, the driver might support custom rates for rate conversion or inverse telecine.
        /// To get the list of custom rates, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCustomRate"/>.
        /// </para>
        /// <para>
        /// Depending on the output rate, the driver might need to convert the frame rate.
        /// If so, the value of <paramref name="RepeatFrame"/> controls whether the driver creates interpolated frames or simply repeats input frames.
        /// </para>
        /// </remarks>
        public void VideoProcessorSetStreamOutputRate([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] D3D11_VIDEO_PROCESSOR_OUTPUT_RATE OutputRate, [In] BOOL RepeatFrame, [In] in DXGI_RATIONAL pCustomRate)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, D3D11_VIDEO_PROCESSOR_OUTPUT_RATE, BOOL, in DXGI_RATIONAL, void>)_vTable[29])
                    (thisPtr, pVideoProcessor, StreamIndex, OutputRate, RepeatFrame, pCustomRate);
            }
        }

        /// <summary>
        /// Sets the source rectangle for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="Enable">
        /// Specifies whether to apply the source rectangle.
        /// </param>
        /// <param name="pRect">
        /// A pointer to a <see cref="RECT"/> structure that specifies the source rectangle.
        /// If <paramref name="Enable"/> is <see cref="FALSE"/>, this parameter is ignored.
        /// </param>
        /// <remarks>
        /// <para>
        /// The source rectangle is the portion of the input surface that is blitted to the destination surface.
        /// The source rectangle is given in pixel coordinates, relative to the input surface.
        /// </para>
        /// <para>
        /// If this method is never called, or if the <paramref name="Enable"/> parameter is <see cref="FALSE"/>,
        /// the video processor reads from the entire input surface.
        /// </para>
        /// </remarks>
        public void VideoProcessorSetStreamSourceRect([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] BOOL Enable, [In] in RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, in RECT, void>)_vTable[30])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, pRect);
            }
        }

        /// <summary>
        /// Sets the destination rectangle for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="Enable">
        /// Specifies whether to apply the destination rectangle.
        /// </param>
        /// <param name="pRect">
        /// A pointer to a <see cref="RECT"/> structure that specifies the destination rectangle.
        /// If <paramref name="Enable"/> is <see cref="FALSE"/>, this parameter is ignored.
        /// </param>
        /// <remarks>
        /// <para>
        /// The destination rectangle is the portion of the output surface that receives the blit for this stream.
        /// The destination rectangle is given in pixel coordinates, relative to the output surface.
        /// </para>
        /// <para>
        /// The default destination rectangle is an empty rectangle (0, 0, 0, 0).
        /// If this method is never called, or if the <paramref name="Enable"/> parameter is <see cref="FALSE"/>, no data is written from this stream.
        /// </para>
        /// </remarks>
        public void VideoProcessorSetStreamDestRect([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] BOOL Enable, [In] in RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, in RECT, void>)_vTable[31])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, pRect);
            }
        }

        /// <summary>
        /// Sets the planar alpha for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="Enable">
        /// Specifies whether alpha blending is enabled.
        /// </param>
        /// <param name="Alpha">
        /// The planar alpha value. The value can range from 0.0 (transparent) to 1.0 (opaque).
        /// If <paramref name="Enable"/> is <see cref="FALSE"/>, this parameter is ignored.
        /// </param>
        /// <remarks>
        /// <para>
        /// To use this feature, the driver must support stereo video,
        /// indicated by the <see cref="D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_STREAM"/> capability flag.
        /// To query for this capability, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>.
        /// </para>
        /// <para>
        /// Alpha blending is disabled by default.
        /// </para>
        /// <para>
        /// For each pixel, the destination color value is computed as follows:
        /// </para>
        /// <para>
        /// <c>Cd = Cs * (As * Ap * Ae) + Cd * (1.0 - As * Ap * Ae)</c>
        /// </para>
        /// <para>
        /// where:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <c>Cd</c> = The color value of the destination pixel
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <c>Cs</c> = The color value of the source pixel
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <c>As</c> = The per-pixel source alpha
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <c>Ap</c> = The planar alpha value
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <c>Ae</c> = The palette-entry alpha value, or 1.0 (see Note)
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Palette-entry alpha values apply only to palettized color formats,
        /// and only when the device supports the <see cref="D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_PALETTE"/> capability.
        /// Otherwise, this factor equals 1.0.
        /// </para>
        /// <para>
        /// The destination alpha value is computed according to the alpha fill mode.
        /// For more information, see <see cref="VideoProcessorSetOutputAlphaFillMode"/>.
        /// </para>
        /// </remarks>
        public void VideoProcessorSetStreamAlpha([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] BOOL Enable, [In] FLOAT Alpha)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, FLOAT, void>)_vTable[32])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, Alpha);
            }
        }

        /// <summary>
        /// Sets the color-palette entries for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="Count">
        /// The number of elements in the <paramref name="pEntries"/> array.
        /// </param>
        /// <param name="pEntries">
        /// A pointer to an array of palette entries.
        /// For RGB streams, the palette entries use the <c>DXGI_FORMAT_B8G8R8A8</c> representation.
        /// For YCbCr streams, the palette entries use the <see cref="DXGI_FORMAT_AYUV"/> representation.
        /// The caller allocates the array.
        /// </param>
        /// <remarks>
        /// <para>
        /// This method applies only to input streams that have a palettized color format.
        /// Palettized formats with 4 bits per pixel (bpp) use the first 16 entries in the list. Formats with 8 bpp use the first 256 entries.
        /// </para>
        /// <para>
        /// If a pixel has a palette index greater than the number of entries, the device treats the pixel as white with opaque alpha.
        /// For full-range RGB, this value is (255, 255, 255, 255); for YCbCr the value is (255, 235, 128, 128).
        /// </para>
        /// <para>
        /// If the driver does not report the <see cref="D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_PALETTE"/> capability flag,
        /// every palette entry must have an alpha value of 0xFF (opaque).
        /// To query for this capability, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>.
        /// </para>
        /// </remarks>
        public void VideoProcessorSetStreamPalette([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] UINT Count, [In] UINT[] pEntries)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, UINT, UINT[], void>)_vTable[33])
                    (thisPtr, pVideoProcessor, StreamIndex, Count, pEntries);
            }
        }

        /// <summary>
        /// Sets the pixel aspect ratio for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="Enable">
        /// Specifies whether the <paramref name="pSourceAspectRatio"/> and <paramref name="pDestinationAspectRatio"/> parameters contain valid values.
        /// Otherwise, the pixel aspect ratios are unspecified.
        /// </param>
        /// <param name="pSourceAspectRatio">
        /// A pointer to a <see cref="DXGI_RATIONAL"/> structure that contains the pixel aspect ratio of the source rectangle.
        /// If <paramref name="Enable"/> is <see cref="FALSE"/>, this parameter can be <see cref="NullRef{DXGI_RATIONAL}"/>.
        /// </param>
        /// <param name="pDestinationAspectRatio">
        /// A pointer to a <see cref="DXGI_RATIONAL"/> structure that contains the pixel aspect ratio of the destination rectangle.
        /// If <paramref name="Enable"/> is <see cref="FALSE"/>, this parameter can be <see cref="NullRef{DXGI_RATIONAL}"/>.
        /// </param>
        /// <remarks>
        /// <para>
        /// This function can only be called if the driver reports the <see cref="D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_PIXEL_ASPECT_RATIO"/> capability.
        /// If this capability is not set, this function will have no effect.
        /// </para>
        /// <para>
        /// Pixel aspect ratios of the form 0/n and n/0 are not valid.
        /// </para>
        /// <para>
        /// The default pixel aspect ratio is 1:1 (square pixels).
        /// </para>
        /// </remarks>
        public void VideoProcessorSetStreamPixelAspectRatio([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] BOOL Enable, [In] in DXGI_RATIONAL pSourceAspectRatio, [In] in DXGI_RATIONAL pDestinationAspectRatio)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, in DXGI_RATIONAL, in DXGI_RATIONAL, void>)_vTable[34])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, pSourceAspectRatio, pDestinationAspectRatio);
            }
        }

        /// <summary>
        /// Sets the luma key for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="Enable">
        /// Specifies whether luma keying is enabled.
        /// </param>
        /// <param name="Lower">
        /// The lower bound for the luma key.
        /// The valid range is [0…1].
        /// If <paramref name="Enable"/> is <see cref="FALSE"/>, this parameter is ignored.
        /// </param>
        /// <param name="Upper">
        /// The upper bound for the luma key.
        /// The valid range is [0…1].
        /// If <paramref name="Enable"/> is <see cref="FALSE"/>, this parameter is ignored.
        /// </param>
        /// <remarks>
        /// <para>
        /// To use this feature, the driver must support luma keying, indicated by the <see cref="D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_LUMA_KEY"/> capability flag.
        /// To query for this capability, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>.
        /// In addition, if the input format is RGB, the device must support the <see cref="D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_LUMA_KEY"/> capability.
        /// </para>
        /// <para>
        /// The values of <paramref name="Lower"/> and <paramref name="Upper"/> give the lower and upper bounds of the luma key,
        /// using a nominal range of [0...1]. Given a format with n bits per channel, these values are converted to luma values as follows:
        /// </para>
        /// <para>
        /// <c>val = f * ((1 &lt;&lt; n)-1)</c>
        /// </para>
        /// <para>
        /// Any pixel whose luma value falls within the upper and lower bounds (inclusive) is treated as transparent.
        /// </para>
        /// <para>
        /// For example, if the pixel format uses 8-bit luma, the upper bound is calculated as follows:
        /// </para>
        /// <para>
        /// <c>BYTE Y = BYTE(max(min(1.0, Upper), 0.0) * 255.0)</c>
        /// </para>
        /// <para>
        /// Note that the value is clamped to the range [0...1] before multiplying by 255.
        /// </para>
        /// </remarks>
        public void VideoProcessorSetStreamLumaKey([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] BOOL Enable, [In] FLOAT Lower, [In] FLOAT Upper)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, FLOAT, FLOAT, void>)_vTable[35])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, Lower, Upper);
            }
        }

        /// <summary>
        /// Enables or disables stereo 3D video for an input stream on the video processor.
        /// In addition, this method specifies the layout of the video frames in memory.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="Enable">
        /// Specifies whether stereo 3D is enabled for this stream.
        /// If the value is <see cref="FALSE"/>, the remaining parameters of this method are ignored.
        /// </param>
        /// <param name="Format">
        /// Specifies the layout of the two stereo views in memory, as a <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT"/> value.
        /// </param>
        /// <param name="LeftViewFrame0">
        /// <para>
        /// If <see cref="TRUE"/>, frame 0 contains the left view. Otherwise, frame 0 contains the right view.
        /// </para>
        /// <para>
        /// This parameter is ignored for the following stereo formats:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="BaseViewFrame0">
        /// <para>
        /// If <see cref="TRUE"/>, frame 0 contains the base view. Otherwise, frame 1 contains the base view.
        /// </para>
        /// <para>
        /// This parameter is ignored for the following stereo formats:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// When <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE"/> is used and the application wants to convert the stereo data to mono, it can either:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Specify the base view as a mono input.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Specify both resources and allow the driver to do the conversion from the base view.
        /// In this case, <see cref="D3D11_VIDEO_PROCESSOR_STREAM.pInputSurface"/> is considered frame 0
        /// and <see cref="D3D11_VIDEO_PROCESSOR_STREAM.pInputSurfaceRight"/> is considered frame 1.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="FlipMode">
        /// A flag from the <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE"/> enumeration, specifying whether one of the views is flipped.
        /// </param>
        /// <param name="MonoOffset">
        /// <para>
        /// For <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET"/> format,
        /// this parameter specifies how to generate the left and right views:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If <paramref name="MonoOffset"/> is positive, the right view is shifted to the right by that many pixels,
        /// and the left view is shifted to the left by the same amount.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <paramref name="MonoOffset"/> is negative, the right view is shifted to the left by that many pixels,
        /// and the left view is shifted to right by the same amount.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="Format"/> is not <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET"/>, this parameter must be zero.
        /// </para>
        /// </param>
        public void VideoProcessorSetStreamStereoFormat([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] BOOL Enable,
            [In] D3D11_VIDEO_PROCESSOR_STEREO_FORMAT Format, [In] BOOL LeftViewFrame0, [In] BOOL BaseViewFrame0,
            [In] D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE FlipMode, [In] int MonoOffset)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT,
                    BOOL, BOOL, D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE, int, void>)_vTable[36])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, Format, LeftViewFrame0, BaseViewFrame0, FlipMode, MonoOffset);
            }
        }

        /// <summary>
        /// Enables or disables automatic processing features on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="Enable">
        /// If <see cref="TRUE"/>, automatic processing features are enabled.
        /// If <see cref="FALSE"/>, the driver disables any extra video processing that it might be performing.
        /// </param>
        /// <remarks>
        /// By default, the driver might perform certain processing tasks automatically during the video processor blit.
        /// This method enables the application to disable these extra video processing features.
        /// For example, if you provide your own pixel shader for the video processor, you might want to disable the driver's automatic processing.
        /// </remarks>
        public void VideoProcessorSetStreamAutoProcessingMode([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] BOOL Enable)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, void>)_vTable[37])(thisPtr, pVideoProcessor, StreamIndex, Enable);
            }
        }

        /// <summary>
        /// Enables or disables an image filter for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="Filter">
        /// <para>
        /// The filter, specified as a <see cref="D3D11_VIDEO_PROCESSOR_FILTER"/> value.
        /// </para>
        /// <para>
        /// To query which filters the driver supports, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>.
        /// </para>
        /// </param>
        /// <param name="Enable">
        /// Specifies whether to enable the filter.
        /// </param>
        /// <param name="Level">
        /// <para>
        /// The filter level. If <paramref name="Enable"/> is <see cref="FALSE"/>, this parameter is ignored.
        /// </para>
        /// <para>
        /// To find the valid range of levels for a specified filter,
        /// call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorFilterRange"/>.
        /// </para>
        /// </param>
        public void VideoProcessorSetStreamFilter([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] D3D11_VIDEO_PROCESSOR_FILTER Filter, [In] BOOL Enable, [In] int Level)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, D3D11_VIDEO_PROCESSOR_FILTER, BOOL, int, void>)_vTable[38])
                    (thisPtr, pVideoProcessor, StreamIndex, Filter, Enable, Level);
            }
        }

        /// <summary>
        /// Sets a driver-specific state on a video processing stream.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pExtensionGuid">
        /// A pointer to a <see cref="GUID"/> that identifies the operation.
        /// The meaning of this <see cref="GUID"/> is defined by the graphics driver.
        /// </param>
        /// <param name="DataSize">
        /// The size of the <paramref name="pData"/> buffer, in bytes.
        /// </param>
        /// <param name="pData">
        /// A pointer to a buffer that contains private state data.
        /// The method passes this buffer directly to the driver without validation.
        /// It is the responsibility of the driver to validate the data.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT VideoProcessorSetStreamExtension([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] in GUID pExtensionGuid, [In] UINT DataSize, [In] nint pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, in GUID, UINT, nint, HRESULT>)_vTable[39])
                    (thisPtr, pVideoProcessor, StreamIndex, pExtensionGuid, DataSize, pData);
            }
        }

        /// <summary>
        /// Gets the format of an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pFrameFormat">
        /// Receives a <see cref="D3D11_VIDEO_FRAME_FORMAT"/> value that specifies whether the stream contains interlaced or progressive frames.
        /// </param>
        public void VideoProcessorGetStreamFrameFormat([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [Out] out D3D11_VIDEO_FRAME_FORMAT pFrameFormat)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out D3D11_VIDEO_FRAME_FORMAT, void>)_vTable[40])
                    (thisPtr, pVideoProcessor, StreamIndex, out pFrameFormat);
            }
        }

        /// <summary>
        /// Gets the color space for an input stream of the video processor
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pColorSpace">
        /// Receives a <see cref="D3D11_VIDEO_PROCESSOR_COLOR_SPACE"/> value that specifies the color space.
        /// </param>
        public void VideoProcessorGetStreamColorSpace([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [Out] out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE, void>)_vTable[41])
                    (thisPtr, pVideoProcessor, StreamIndex, out pColorSpace);
            }
        }

        /// <summary>
        /// Gets the rate at which the video processor produces output frames for an input stream.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pOutputRate">
        /// Receives a <see cref="D3D11_VIDEO_PROCESSOR_OUTPUT_RATE"/> value that specifies the output rate.
        /// </param>
        /// <param name="pRepeatFrame">
        /// <para>
        /// Receives a Boolean value that specifies how the driver performs frame-rate conversion, if required.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="TRUE"/>
        /// </term>
        /// <term>
        /// Repeat frames.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FALSE"/>
        /// </term>
        /// <term>
        /// Interpolate frames.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pCustomRate">
        /// A pointer to a <see cref="DXGI_RATIONAL"/> structure.
        /// If the output rate is <see cref="D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_CUSTOM"/>,
        /// the method fills in this structure with the exact output rate.
        /// Otherwise, this parameter is ignored.
        /// </param>
        public void VideoProcessorGetStreamOutputRate([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [Out] out D3D11_VIDEO_PROCESSOR_OUTPUT_RATE pOutputRate, [Out] out BOOL pRepeatFrame, [Out] out DXGI_RATIONAL pCustomRate)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out D3D11_VIDEO_PROCESSOR_OUTPUT_RATE, out BOOL, out DXGI_RATIONAL, void>)_vTable[42])
                    (thisPtr, pVideoProcessor, StreamIndex, out pOutputRate, out pRepeatFrame, out pCustomRate);
            }
        }

        /// <summary>
        /// Gets the source rectangle for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pEnabled">
        /// Receives the value <see cref="TRUE"/> if the source rectangle is enabled, or <see cref="FALSE"/> otherwise.
        /// </param>
        /// <param name="pRect">
        /// A pointer to a <see cref="RECT"/> structure that receives the source rectangle.
        /// </param>
        public void VideoProcessorGetStreamSourceRect([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [Out] out BOOL pEnabled, [Out] out RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out BOOL, out RECT, void>)_vTable[43])
                    (thisPtr, pVideoProcessor, StreamIndex, out pEnabled, out pRect);
            }
        }

        /// <summary>
        /// Gets the destination rectangle for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pEnabled">
        /// Receives the value <see cref="TRUE"/> if the destination rectangle is enabled, or <see cref="FALSE"/> otherwise.
        /// </param>
        /// <param name="pRect">
        /// A pointer to a <see cref="RECT"/> structure that receives the destination rectangle.
        /// </param>
        public void VideoProcessorGetStreamDestRect([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [Out] out BOOL pEnabled, [Out] out RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out BOOL, out RECT, void>)_vTable[44])
                    (thisPtr, pVideoProcessor, StreamIndex, out pEnabled, out pRect);
            }
        }

        /// <summary>
        /// Gets the planar alpha for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pEnabled">
        /// Receives the value <see cref="TRUE"/> if planar alpha is enabled, or <see cref="FALSE"/> otherwise.
        /// </param>
        /// <param name="pAlpha">
        /// Receives the planar alpha value.
        /// The value can range from 0.0 (transparent) to 1.0 (opaque).
        /// </param>
        public void VideoProcessorGetStreamAlpha([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [Out] out BOOL pEnabled, [Out] out FLOAT pAlpha)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out BOOL, out FLOAT, void>)_vTable[45])
                    (thisPtr, pVideoProcessor, StreamIndex, out pEnabled, out pAlpha);
            }
        }

        /// <summary>
        /// Gets the color-palette entries for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="Count">
        /// The number of entries in the <paramref name="pEntries"/> array.
        /// </param>
        /// <param name="pEntries">
        /// A pointer to a <see cref="UINT"/> array allocated by the caller.
        /// The method fills the array with the palette entries.
        /// For RGB streams, the palette entries use the <c>DXGI_FORMAT_B8G8R8A8</c> representation.
        /// For YCbCr streams, the palette entries use the <see cref="DXGI_FORMAT_AYUV"/> representation.
        /// </param>
        /// <remarks>
        /// This method applies only to input streams that have a palettized color format.
        /// Palettized formats with 4 bits per pixel (bpp) use 16 palette entries.
        /// Formats with 8 bpp use 256 entries.
        /// </remarks>
        public void VideoProcessorGetStreamPalette([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] UINT Count, [Out] UINT[] pEntries)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, UINT, UINT[], void>)_vTable[46])
                    (thisPtr, pVideoProcessor, StreamIndex, Count, pEntries);
            }
        }

        /// <summary>
        /// Gets the pixel aspect ratio for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pEnabled">
        /// Receives the value <see cref="TRUE"/> if the pixel aspect ratio is specified.
        /// Otherwise, receives the value <see cref="FALSE"/>.
        /// </param>
        /// <param name="pSourceAspectRatio">
        /// A pointer to a <see cref="DXGI_RATIONAL"/> structure.
        /// If *<paramref name="pEnabled"/> is <see cref="TRUE"/>, this parameter receives the pixel aspect ratio of the source rectangle.
        /// </param>
        /// <param name="pDestinationAspectRatio">
        /// A pointer to a <see cref="DXGI_RATIONAL"/> structure.
        /// If *<paramref name="pEnabled"/> is <see cref="TRUE"/>, this parameter receives the pixel aspect ratio of the destination rectangle.
        /// </param>
        /// <remarks>
        /// When the method returns, if *<paramref name="pEnabled"/> is <see cref="TRUE"/>,
        /// the <paramref name="pSourceAspectRatio"/> and <paramref name="pDestinationAspectRatio"/> parameters contain the pixel aspect ratios.
        /// Otherwise, the default pixel aspect ratio is 1:1 (square pixels).
        /// </remarks>
        public void VideoProcessorGetStreamPixelAspectRatio([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [Out] out BOOL pEnabled, [Out] out DXGI_RATIONAL pSourceAspectRatio, [Out] out DXGI_RATIONAL pDestinationAspectRatio)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out BOOL, out DXGI_RATIONAL, out DXGI_RATIONAL, void>)_vTable[47])
                    (thisPtr, pVideoProcessor, StreamIndex, out pEnabled, out pSourceAspectRatio, out pDestinationAspectRatio);
            }
        }

        /// <summary>
        /// Gets the luma key for an input stream of the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pEnabled">
        /// Receives the value <see cref="TRUE"/> if luma keying is enabled, or <see cref="FALSE"/> otherwise.
        /// </param>
        /// <param name="pLower">
        /// Receives the lower bound for the luma key. The valid range is [0…1].
        /// </param>
        /// <param name="pUpper">
        /// Receives the upper bound for the luma key. The valid range is [0…1].
        /// </param>
        public void VideoProcessorGetStreamLumaKey([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [Out] out BOOL pEnabled, [Out] out FLOAT pLower, [Out] out FLOAT pUpper)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out BOOL, out FLOAT, out FLOAT, void>)_vTable[48])
                    (thisPtr, pVideoProcessor, StreamIndex, out pEnabled, out pLower, out pUpper);
            }
        }

        /// <summary>
        /// Gets the stereo 3D format for an input stream on the video processor
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pEnabled">
        /// Receives the value <see cref="TRUE"/> if stereo 3D is enabled for this stream, or <see cref="FALSE"/> otherwise.
        /// If the value is <see cref="FALSE"/>, ignore the remaining parameters.
        /// </param>
        /// <param name="pFormat">
        /// Receives a <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT"/> value that specifies the layout of the two stereo views in memory.
        /// </param>
        /// <param name="pLeftViewFrame0">
        /// <para>
        /// Receives a Boolean value.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="TRUE"/>
        /// </term>
        /// <term>
        /// Frame 0 contains the left view.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FALSE"/>
        /// </term>
        /// <term>
        /// Frame 0 contains the right view.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pBaseViewFrame0">
        /// <para>
        /// Receives a Boolean value.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="TRUE"/>
        /// </term>
        /// <term>
        /// Frame 0 contains the base view.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FALSE"/>
        /// </term>
        /// <term>
        /// Frame 1 contains the base view.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pFlipMode">
        /// Receives a <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE"/> value.
        /// This value specifies whether one of the views is flipped.
        /// </param>
        /// <param name="pMonoOffset">
        /// Receives the pixel offset used for <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET"/> format.
        /// This parameter is ignored for other stereo formats.
        /// </param>
        public void VideoProcessorGetStreamStereoFormat([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [Out] out BOOL pEnabled,
            [Out] out D3D11_VIDEO_PROCESSOR_STEREO_FORMAT pFormat, [Out] out BOOL pLeftViewFrame0, [Out] out BOOL pBaseViewFrame0,
            [Out] out D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE pFlipMode, [Out] out int pMonoOffset)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out BOOL, out D3D11_VIDEO_PROCESSOR_STEREO_FORMAT,
                    out BOOL, out BOOL, out D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE, out int, void>)_vTable[49])
                    (thisPtr, pVideoProcessor, StreamIndex, out pEnabled, out pFormat, out pLeftViewFrame0, out pBaseViewFrame0, out pFlipMode, out pMonoOffset);
            }
        }

        /// <summary>
        /// Queries whether automatic processing features of the video processor are enabled.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pEnabled">
        /// Receives the value <see cref="TRUE"/> if automatic processing features are enabled, or <see cref="FALSE"/> otherwise.
        /// </param>
        /// <remarks>
        /// Automatic processing refers to additional image processing
        /// that drivers might have performed on the image data prior to the application receiving the data.
        /// </remarks>
        public void VideoProcessorGetStreamAutoProcessingMode([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [Out] out BOOL pEnabled)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out BOOL, void>)_vTable[50])(thisPtr, pVideoProcessor, StreamIndex, out pEnabled);
            }
        }

        /// <summary>
        /// Gets the image filter settings for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="Filter">
        /// The filter to query, specified as a <see cref="D3D11_VIDEO_PROCESSOR_FILTER"/> value.
        /// </param>
        /// <param name="pEnabled">
        /// Receives the value <see cref="TRUE"/> if the image filter is enabled, or <see cref="FALSE"/> otherwise.
        /// </param>
        /// <param name="pLevel">
        /// Receives the filter level.
        /// </param>
        public void VideoProcessorGetStreamFilter([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] D3D11_VIDEO_PROCESSOR_FILTER Filter, [Out] out BOOL pEnabled, [Out] out int pLevel)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, D3D11_VIDEO_PROCESSOR_FILTER, out BOOL, out int, void>)_vTable[51])
                    (thisPtr, pVideoProcessor, StreamIndex, Filter, out pEnabled, out pLevel);
            }
        }

        /// <summary>
        /// Gets a driver-specific state for a video processing stream.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pExtensionGuid">
        /// A pointer to a <see cref="GUID"/> that identifies the state.
        /// The meaning of this <see cref="GUID"/> is defined by the graphics driver.
        /// </param>
        /// <param name="DataSize">
        /// The size of the <paramref name="pData"/> buffer, in bytes.
        /// </param>
        /// <param name="pData">
        /// A pointer to a buffer that receives the private state data.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>. Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT VideoProcessorGetStreamExtension([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] in GUID pExtensionGuid, [In] UINT DataSize, [In] nint pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, in GUID, UINT, nint, HRESULT>)_vTable[52])
                    (thisPtr, pVideoProcessor, StreamIndex, pExtensionGuid, DataSize, pData);
            }
        }

        /// <summary>
        /// Performs a video processing operation on one or more input samples, and writes the result to a Direct3D surface.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call the <see cref="ID3D11VideoDevice.CreateVideoProcessor"/> method.
        /// </param>
        /// <param name="pView">
        /// A pointer to the <see cref="ID3D11VideoProcessorOutputView"/> interface for the output surface.
        /// The output of the video processing operation will be written to this surface.
        /// </param>
        /// <param name="OutputFrame">
        /// The frame number of the output video frame, indexed from zero.
        /// </param>
        /// <param name="StreamCount">
        /// The number of input streams to process.
        /// </param>
        /// <param name="pStreams">
        /// A pointer to an array of <see cref="D3D11_VIDEO_PROCESSOR_STREAM"/> structures that contain information about the input streams.
        /// The caller allocates the array and fills in each structure.
        /// The number of elements in the array is given in the <paramref name="StreamCount"/> parameter.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The maximum value of <paramref name="StreamCount"/> is given
        /// in the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> member of the <see cref="D3D11_VIDEO_PROCESSOR_CAPS"/> structure.
        /// The maximum number of streams that can be enabled at one time
        /// is given in the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxInputStreams"/> member of that structure.
        /// </para>
        /// <para>
        /// If the output stereo mode is <see cref="TRUE"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The output view must contain a texture array of two elements.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// At least one stereo stream must be specified.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If multiple input streams are enabled, it is possible that one or more of the input streams may contain mono data.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Otherwise:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The output view must contain a single element.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The stereo format cannot be <see cref="D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO"/> .
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This function does not honor a D3D11 predicate that may have been set.
        /// </para>
        /// <para>
        /// If the application uses D3D11 queries, this function may not be accounted for
        /// with <see cref="D3D11_QUERY_EVENT"/> and <see cref="D3D11_QUERY_TIMESTAMP"/> when using feature levels lower than 11.
        /// <see cref="D3D11_QUERY_PIPELINE_STATISTICS"/> will not include this function for any feature level.
        /// </para>
        /// </remarks>
        public HRESULT VideoProcessorBlt([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] P<ID3D11VideoProcessorOutputView> pView,
            [In] UINT OutputFrame, [In] UINT StreamCount, [In] D3D11_VIDEO_PROCESSOR_STREAM[] pStreams)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, P<ID3D11VideoProcessorOutputView>,
                    UINT, UINT, D3D11_VIDEO_PROCESSOR_STREAM[], HRESULT>)_vTable[53])
                    (thisPtr, pVideoProcessor, pView, OutputFrame, StreamCount, pStreams);
            }
        }

        /// <summary>
        /// Establishes the session key for a cryptographic session.
        /// </summary>
        /// <param name="pCryptoSession">
        /// A pointer to the <see cref="ID3D11CryptoSession"/> interface of the cryptographic session.
        /// </param>
        /// <param name="DataSize">
        /// The size of the <paramref name="pData"/> byte array, in bytes.
        /// </param>
        /// <param name="pData">
        /// A pointer to a byte array that contains the encrypted session key.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The key exchange mechanism depends on the type of cryptographic session.
        /// </para>
        /// <para>
        /// For RSA Encryption Scheme - Optimal Asymmetric Encryption Padding (RSAES-OAEP), the software decoder generates the secret key,
        /// encrypts the secret key by using the public key with RSAES-OAEP, and places the cipher text in the <paramref name="pData"/> parameter.
        /// The actual size of the buffer for RSAES-OAEP is 256 bytes.
        /// </para>
        /// </remarks>
        public HRESULT NegotiateCryptoSessionKeyExchange([In] P<ID3D11CryptoSession> pCryptoSession, [In] UINT DataSize, [In] nint pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, UINT, nint, HRESULT>)_vTable[54])
                    (thisPtr, pCryptoSession, DataSize, pData);
            }
        }

        /// <summary>
        /// Reads encrypted data from a protected surface.
        /// </summary>
        /// <param name="pCryptoSession">
        /// A pointer to the <see cref="ID3D11CryptoSession"/> interface of the cryptographic session.
        /// </param>
        /// <param name="pSrcSurface">
        /// A pointer to the <see cref="ID3D11Texture2D"/> interface of the protected surface.
        /// </param>
        /// <param name="pDstSurface">
        /// A pointer to the <see cref="ID3D11Texture2D"/> interface of the surface that receives the encrypted data.
        /// </param>
        /// <param name="IVSize">
        /// The size of the <paramref name="pIV"/> buffer, in bytes.
        /// </param>
        /// <param name="pIV">
        /// <para>
        /// A pointer to a buffer that receives the initialization vector (IV).
        /// The caller allocates this buffer, but the driver generates the IV.
        /// </para>
        /// <para>
        /// For 128-bit AES-CTR encryption, <paramref name="pIV"/> points to a <see cref="D3D11_AES_CTR_IV"/> structure.
        /// When the driver generates the first IV, it initializes the structure to a random number.
        /// For each subsequent IV, the driver simply increments the <see cref="D3D11_AES_CTR_IV.IV"/> member of the structure,
        /// ensuring that the value always increases.
        /// The application can validate that the same IV is never used more than once with the same key pair.
        /// </para>
        /// </param>
        /// <remarks>
        /// <para>
        /// Not all drivers support this method.
        /// To query the driver capabilities, call <see cref="ID3D11VideoDevice.GetContentProtectionCaps"/>
        /// and check for the <see cref="D3D11_CONTENT_PROTECTION_CAPS_ENCRYPTED_READ_BACK"/> flag
        /// in the <see cref="D3D11_VIDEO_CONTENT_PROTECTION_CAPS.Caps"/> member of the <see cref="D3D11_VIDEO_CONTENT_PROTECTION_CAPS"/> structure.
        /// </para>
        /// <para>
        /// Some drivers might require a separate key to decrypt the data that is read back.
        /// To check for this requirement, call <see cref="D3D11_VIDEO_CONTENT_PROTECTION_CAPS.GetContentProtectionCaps"/>
        /// and check for the <see cref="D3D11_CONTENT_PROTECTION_CAPS_ENCRYPTED_READ_BACK_KEY"/> flag.
        /// If this flag is present, call <see cref="GetEncryptionBltKey"/> to get the decryption key.
        /// </para>
        /// <para>
        /// This method has the following limitations:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Reading back sub-rectangles is not supported.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Reading back partially encrypted surfaces is not supported.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The protected surface must be either an off-screen plain surface or a render target.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The destination surface must be a <see cref="D3D11_USAGE_STAGING"/> resource.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The protected surface cannot be multisampled.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Stretching and colorspace conversion are not supported.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This function does not honor a D3D11 predicate that may have been set.
        /// </para>
        /// <para>
        /// If the application uses D3D11 queries, this function may not be accounted for
        /// with <see cref="D3D11_QUERY_EVENT"/> and <see cref="D3D11_QUERY_TIMESTAMP"/> when using feature levels lower than 11.
        /// <see cref="D3D11_QUERY_PIPELINE_STATISTICS"/> will not include this function for any feature level.
        /// </para>
        /// </remarks>
        public void EncryptionBlt([In] P<ID3D11CryptoSession> pCryptoSession, [In] P<ID3D11Texture2D> pSrcSurface,
            [In] P<ID3D11Texture2D> pDstSurface, [In] UINT IVSize, [In] nint pIV)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, P<ID3D11Texture2D>, P<ID3D11Texture2D>, UINT, nint, void>)_vTable[55])
                    (thisPtr, pCryptoSession, pSrcSurface, pDstSurface, IVSize, pIV);
            }
        }

        /// <summary>
        /// Writes encrypted data to a protected surface.
        /// </summary>
        /// <param name="pCryptoSession">
        /// A pointer to the <see cref="ID3D11CryptoSession"/> interface.
        /// </param>
        /// <param name="pSrcSurface">
        /// A pointer to the surface that contains the source data.
        /// </param>
        /// <param name="pDstSurface">
        /// A pointer to the protected surface where the encrypted data is written.
        /// </param>
        /// <param name="pEncryptedBlockInfo">
        /// <para>
        /// A pointer to a <see cref="D3D11_ENCRYPTED_BLOCK_INFO"/> structure, or <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// If the driver supports partially encrypted buffers, <paramref name="pEncryptedBlockInfo"/> indicates which portions of the buffer are encrypted.
        /// If the entire surface is encrypted, set this parameter to <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// To check whether the driver supports partially encrypted buffers,
        /// call <see cref="ID3D11VideoDevice.GetContentProtectionCaps"/> and
        /// check for the <see cref="D3D11_CONTENT_PROTECTION_CAPS_PARTIAL_DECRYPTION"/> capabilities flag.
        /// If the driver does not support partially encrypted buffers, set this parameter to <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="ContentKeySize">
        /// The size of the encrypted content key, in bytes.
        /// </param>
        /// <param name="pContentKey">
        /// <para>
        /// A pointer to a buffer that contains a content encryption key, or <see cref="NULL"/>.
        /// To query whether the driver supports the use of content keys,
        /// call <see cref="ID3D11VideoDevice.GetContentProtectionCaps"/>
        /// and check for the <see cref="D3D11_CONTENT_PROTECTION_CAPS_CONTENT_KEY"/> capabilities flag.
        /// </para>
        /// <para>
        /// If the driver supports content keys, use the content key to encrypt the surface.
        /// Encrypt the content key using the session key, and place the resulting cipher text in <paramref name="pContentKey"/>.
        /// If the driver does not support content keys, use the session key to encrypt the surface
        /// and set <paramref name="pContentKey"/> to <see cref="NULL"/>.
        /// </para>
        /// </param>
        /// <param name="IVSize">
        /// The size of the <paramref name="pIV"/> buffer, in bytes.
        /// </param>
        /// <param name="pIV">
        /// <para>
        /// A pointer to a buffer that contains the initialization vector (IV).
        /// </para>
        /// <para>
        /// For 128-bit AES-CTR encryption, <paramref name="pIV"/> points to a <see cref="D3D11_AES_CTR_IV"/> structure.
        /// The caller allocates the structure and generates the IV.
        /// When you generate the first IV, initialize the structure to a random number.
        /// For each subsequent IV, simply increment the <see cref="D3D11_AES_CTR_IV.IV"/> member of the structure, ensuring that the value always increases.
        /// This procedure enables the driver to validate that the same IV is never used more than once with the same key pair.
        /// </para>
        /// <para>
        /// For other encryption types, a different structure might be used, or the encryption might not use an IV.
        /// </para>
        /// </param>
        /// <remarks>
        /// <para>
        /// Not all hardware or drivers support this functionality for all cryptographic types.
        /// This function can only be called when the <see cref="D3D11_CONTENT_PROTECTION_CAPS_DECRYPTION_BLT"/> cap is reported.
        /// </para>
        /// <para>
        /// This method does not support writing to sub-rectangles of the surface.
        /// </para>
        /// <para>
        /// If the hardware and driver support a content key:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The data is encrypted by the caller using the content key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The content key is encrypted by the caller using the session key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The encrypted content key is passed to the driver.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Otherwise, the data is encrypted by the caller using the session key and <see cref="NULL"/> is passed as the content key.
        /// </para>
        /// <para>
        /// If the driver and hardware support partially encrypted buffers,
        /// <paramref name="pEncryptedBlockInfo"/> indicates which portions of the buffer are encrypted and which is not.
        /// If the entire buffer is encrypted, <paramref name="pEncryptedBlockInfo"/> should be <see cref="NullRef{D3D11_ENCRYPTED_BLOCK_INFO}"/>.
        /// </para>
        /// <para>
        /// The <see cref="D3D11_ENCRYPTED_BLOCK_INFO"/> allows the application to indicate which bytes in the buffer are encrypted.
        /// This is specified in bytes, so the application must ensure that the encrypted blocks match the GPU’s crypto block alignment.
        /// </para>
        /// <para>
        /// This function does not honor a D3D11 predicate that may have been set.
        /// </para>
        /// <para>
        /// If the application uses D3D11 queries, this function may not be accounted for
        /// with <see cref="D3D11_QUERY_EVENT"/> and <see cref="D3D11_QUERY_TIMESTAMP"/> when using feature levels lower than 11.
        /// <see cref="D3D11_QUERY_PIPELINE_STATISTICS"/> will not include this function for any feature level.
        /// </para>
        /// </remarks>
        public void DecryptionBlt([In] P<ID3D11CryptoSession> pCryptoSession, [In] P<ID3D11Texture2D> pSrcSurface,
            [In] P<ID3D11Texture2D> pDstSurface, [In] in D3D11_ENCRYPTED_BLOCK_INFO pEncryptedBlockInfo, [In] UINT ContentKeySize,
            [In] nint pContentKey, [In] UINT IVSize, [In] nint pIV)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, P<ID3D11Texture2D>, P<ID3D11Texture2D>,
                    in D3D11_ENCRYPTED_BLOCK_INFO, UINT, nint, UINT, nint, void>)_vTable[56])
                    (thisPtr, pCryptoSession, pSrcSurface, pDstSurface, pEncryptedBlockInfo, ContentKeySize, pContentKey, IVSize, pIV);
            }
        }

        /// <summary>
        /// Gets a random number that can be used to refresh the session key.
        /// </summary>
        /// <param name="pCryptoSession">
        /// A pointer to the <see cref="ID3D11CryptoSession"/> interface.
        /// </param>
        /// <param name="RandomNumberSize">
        /// The size of the <paramref name="pRandomNumber"/> array, in bytes.
        /// The size should match the size of the session key.
        /// </param>
        /// <param name="pRandomNumber">
        /// A pointer to a byte array that receives a random number.
        /// </param>
        /// <remarks>
        /// <para>
        /// To generate a new session key, perform a bitwise XOR between the previous session key and the random number.
        /// The new session key does not take affect until the application calls <see cref="FinishSessionKeyRefresh"/>.
        /// </para>
        /// <para>
        /// To query whether the driver supports this method, call <see cref="ID3D11VideoDevice.GetContentProtectionCaps"/>
        /// and check for the <see cref="D3D11_CONTENT_PROTECTION_CAPS_FRESHEN_SESSION_KEY"/> capabilities flag.
        /// </para>
        /// </remarks>
        public void StartSessionKeyRefresh([In] P<ID3D11CryptoSession> pCryptoSession, [In] UINT RandomNumberSize, [In] nint pRandomNumber)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, UINT, nint, void>)_vTable[57])
                    (thisPtr, pCryptoSession, RandomNumberSize, pRandomNumber);
            }
        }

        /// <summary>
        /// Switches to a new session key.
        /// </summary>
        /// <param name="pCryptoSession">
        /// A pointer to the <see cref="ID3D11CryptoSession"/> interface.
        /// </param>
        /// <remarks>
        /// <para>
        /// This function can only be called when the <see cref="D3D11_CONTENT_PROTECTION_CAPS_FRESHEN_SESSION_KEY"/> cap is reported.
        /// </para>
        /// <para>
        /// Before calling this method, call <see cref="StartSessionKeyRefresh"/>.
        /// The <see cref="StartSessionKeyRefresh"/> method gets a random number from the driver, which is used to create a new session key.
        /// The new session key does not become active until the application calls <see cref="FinishSessionKeyRefresh"/>.
        /// After the application calls <see cref="FinishSessionKeyRefresh"/>, all protected surfaces are encrypted using the new session key.
        /// </para>
        /// </remarks>
        public void FinishSessionKeyRefresh([In] P<ID3D11CryptoSession> pCryptoSession)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, void>)_vTable[58])(thisPtr, pCryptoSession);
            }
        }

        /// <summary>
        /// Gets the cryptographic key to decrypt the data returned by the <see cref="EncryptionBlt"/> method.
        /// </summary>
        /// <param name="pCryptoSession">
        /// A pointer to the <see cref="ID3D11CryptoSession"/> interface.
        /// </param>
        /// <param name="KeySize">
        /// The size of the <paramref name="pReadbackKey"/> array, in bytes.
        /// The size should match the size of the session key.
        /// </param>
        /// <param name="pReadbackKey">
        /// A pointer to a byte array that receives the key.
        /// The key is encrypted using the session key.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method applies only when the driver requires a separate content key for the <see cref="EncryptionBlt"/> method.
        /// For more information, see the Remarks for <see cref="EncryptionBlt"/>.
        /// </para>
        /// <para>
        /// Each time this method is called, the driver generates a new key.
        /// </para>
        /// <para>
        /// The <paramref name="KeySize"/> should match the size of the session key.
        /// </para>
        /// <para>
        /// The read back key is encrypted by the driver/hardware using the session key.
        /// </para>
        /// </remarks>
        public HRESULT GetEncryptionBltKey([In] P<ID3D11CryptoSession> pCryptoSession, [In] UINT KeySize, [In] nint pReadbackKey)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, UINT, nint, HRESULT>)_vTable[59])
                    (thisPtr, pCryptoSession, KeySize, pReadbackKey);
            }
        }

        /// <summary>
        /// Establishes a session key for an authenticated channel.
        /// </summary>
        /// <param name="pChannel">
        /// A pointer to the <see cref="ID3D11AuthenticatedChannel"/> interface.
        /// This method will fail if the channel type is <see cref="D3D11_AUTHENTICATED_CHANNEL_D3D11"/>,
        /// because the Direct3D11 channel does not support authentication.
        /// </param>
        /// <param name="DataSize">
        /// The size of the data in the <paramref name="pData"/> array, in bytes.
        /// </param>
        /// <param name="pData">
        /// A pointer to a byte array that contains the encrypted session key.
        /// The buffer must contain 256 bytes of data, encrypted using RSA Encryption Scheme - Optimal Asymmetric Encryption Padding (RSAES-OAEP).
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method will fail if the channel type is <see cref="D3D11_AUTHENTICATED_CHANNEL_D3D11"/>,
        /// because the Direct3D11 channel does not support authentication.
        /// </remarks>
        public HRESULT NegotiateAuthenticatedChannelKeyExchange([In] P<ID3D11AuthenticatedChannel> pChannel, [In] UINT DataSize, [In] nint pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11AuthenticatedChannel>, UINT, nint, HRESULT>)_vTable[60])
                    (thisPtr, pChannel, DataSize, pData);
            }
        }

        /// <summary>
        /// Sends a query to an authenticated channel.
        /// </summary>
        /// <param name="pChannel">
        /// A pointer to the <see cref="ID3D11AuthenticatedChannel"/> interface.
        /// </param>
        /// <param name="InputSize">
        /// The size of the <paramref name="pInput"/> array, in bytes.
        /// </param>
        /// <param name="pInput">
        /// A pointer to a byte array that contains input data for the query.
        /// This array always starts with a <see cref="D3D11_AUTHENTICATED_QUERY_INPUT"/> structure.
        /// The <see cref="D3D11_AUTHENTICATED_QUERY_INPUT.QueryType"/> member of the structure
        /// specifies the query and defines the meaning of the rest of the array.
        /// </param>
        /// <param name="OutputSize">
        /// The size of the <paramref name="pOutput"/> array, in bytes.
        /// </param>
        /// <param name="pOutput">
        /// A pointer to a byte array that receives the result of the query.
        /// This array always starts with a <see cref="D3D11_AUTHENTICATED_QUERY_OUTPUT"/> structure.
        /// The meaning of the rest of the array depends on the query.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT QueryAuthenticatedChannel([In] P<ID3D11AuthenticatedChannel> pChannel, [In] UINT InputSize,
            [In] nint pInput, [In] UINT OutputSize, [In] nint pOutput)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11AuthenticatedChannel>, UINT, nint, UINT, nint, HRESULT>)_vTable[61])
                    (thisPtr, pChannel, InputSize, pInput, OutputSize, pOutput);
            }
        }

        /// <summary>
        /// Sends a configuration command to an authenticated channel.
        /// </summary>
        /// <param name="pChannel">
        /// A pointer to the <see cref="ID3D11AuthenticatedChannel"/> interface.
        /// </param>
        /// <param name="InputSize">
        /// The size of the <paramref name="pInput"/> array, in bytes.
        /// </param>
        /// <param name="pInput">
        /// A pointer to a byte array that contains input data for the command.
        /// This buffer always starts with a <see cref="D3D11_AUTHENTICATED_CONFIGURE_INPUT"/> structure.
        /// The <see cref="D3D11_AUTHENTICATED_CONFIGURE_INPUT.ConfigureType"/> member of the structure 
        /// specifies the command and defines the meaning of the rest of the buffer.
        /// </param>
        /// <param name="pOutput">
        /// A pointer to a <see cref="D3D11_AUTHENTICATED_CONFIGURE_OUTPUT"/> structure that receives the response to the command.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT ConfigureAuthenticatedChannel([In] P<ID3D11AuthenticatedChannel> pChannel, [In] UINT InputSize,
            [In] nint pInput, [Out] out D3D11_AUTHENTICATED_CONFIGURE_OUTPUT pOutput)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11AuthenticatedChannel>, UINT,
                    nint, out D3D11_AUTHENTICATED_CONFIGURE_OUTPUT, HRESULT>)_vTable[62])
                    (thisPtr, pChannel, InputSize, pInput, out pOutput);
            }
        }

        /// <summary>
        /// Sets the stream rotation for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="Enable">
        /// Specifies if the stream is to be rotated in a clockwise orientation.
        /// </param>
        /// <param name="Rotation">
        /// Specifies the rotation of the stream.
        /// </param>
        /// <remarks>
        /// <para>
        /// This is an optional state and the application should only use it
        /// if <see cref="D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ROTATION"/> is reported in <see cref="D3D11_VIDEO_PROCESSOR_CAPS.FeatureCaps"/>.
        /// </para>
        /// <para>
        /// The stream source rectangle will be specified in the pre-rotation coordinates (typically landscape)
        /// and the stream destination rectangle will be specified in the post-rotation coordinates (typically portrait).
        /// The application must update the stream destination rectangle correctly when using a rotation value other than 0° and 180°.
        /// </para>
        /// </remarks>
        public void VideoProcessorSetStreamRotation([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] BOOL Enable, [In] D3D11_VIDEO_PROCESSOR_ROTATION Rotation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, D3D11_VIDEO_PROCESSOR_ROTATION, void>)_vTable[63])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, Rotation);
            }
        }

        /// <summary>
        /// Gets the stream rotation for an input stream on the video processor.
        /// </summary>
        /// <param name="pVideoProcessor">
        /// A pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// To get this pointer, call <see cref="ID3D11VideoDevice.CreateVideoProcessor"/>.
        /// </param>
        /// <param name="StreamIndex">
        /// The zero-based index of the input stream.
        /// To get the maximum number of streams, call <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/>
        /// and check the <see cref="D3D11_VIDEO_PROCESSOR_CAPS.MaxStreamStates"/> structure member.
        /// </param>
        /// <param name="pEnable">
        /// Specifies if the stream is rotated.
        /// </param>
        /// <param name="pRotation">
        /// Specifies the rotation of the stream in a clockwise orientation.
        /// </param>
        public void VideoProcessorGetStreamRotation([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [Out] out BOOL pEnable, [Out] out D3D11_VIDEO_PROCESSOR_ROTATION pRotation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out BOOL, out D3D11_VIDEO_PROCESSOR_ROTATION, void>)_vTable[63])
                    (thisPtr, pVideoProcessor, StreamIndex, out pEnable, out pRotation);
            }
        }
    }
}
