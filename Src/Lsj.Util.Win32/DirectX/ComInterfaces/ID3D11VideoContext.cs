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
using static Lsj.Util.Win32.DirectX.Enums.D3D11_VIDEO_PROCESSOR_OUTPUT_RATE;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_VIDEO_PROCESSOR_STEREO_FORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
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
        IntPtr* _vTable;

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
        public HRESULT GetDecoderBuffer([In] P<ID3D11VideoDecoder> pDecoder, [In] D3D11_VIDEO_DECODER_BUFFER_TYPE Type, [Out] out UINT pBufferSize, [Out] out IntPtr ppBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, D3D11_VIDEO_DECODER_BUFFER_TYPE, out UINT, out IntPtr, HRESULT>)_vTable[7])
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
        public HRESULT DecoderBeginFrame([In] P<ID3D11VideoDecoder> pDecoder, [In] P<ID3D11VideoDecoderOutputView> pView, [In] UINT ContentKeySize, [In] IntPtr pContentKey)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, P<ID3D11VideoDecoderOutputView>, UINT, IntPtr, HRESULT>)_vTable[9])
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

        public void VideoProcessorSetOutputAlphaFillMode([In] P<ID3D11VideoProcessor> pVideoProcessor,
            [In] D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE AlphaFillMode, [In] UINT StreamIndex)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE, UINT, void>)_vTable[16])
                    (thisPtr, pVideoProcessor, AlphaFillMode, StreamIndex);
            }
        }

        public void VideoProcessorSetOutputConstriction([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] BOOL Enable, [In] SIZE Size)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, BOOL, SIZE, void>)_vTable[17])(thisPtr, pVideoProcessor, Enable, Size);
            }
        }

        public void VideoProcessorSetOutputStereoMode([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] BOOL Enable)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, BOOL, void>)_vTable[18])(thisPtr, pVideoProcessor, Enable);
            }
        }

        public HRESULT VideoProcessorSetOutputExtension([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] in GUID pExtensionGuid,
            [In] UINT DataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, in GUID, UINT, IntPtr, HRESULT>)_vTable[19])
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
            [In] UINT DataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, in GUID, UINT, IntPtr, HRESULT>)_vTable[26])
                    (thisPtr, pVideoProcessor, pExtensionGuid, DataSize, pData);
            }
        }

        public void VideoProcessorSetStreamFrameFormat([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] D3D11_VIDEO_FRAME_FORMAT FrameFormat)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, D3D11_VIDEO_FRAME_FORMAT, void>)_vTable[27])
                    (thisPtr, pVideoProcessor, StreamIndex, FrameFormat);
            }
        }

        public void VideoProcessorSetStreamColorSpace([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] in D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, in D3D11_VIDEO_PROCESSOR_COLOR_SPACE, void>)_vTable[28])
                    (thisPtr, pVideoProcessor, StreamIndex, pColorSpace);
            }
        }

        public void VideoProcessorSetStreamOutputRate([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] D3D11_VIDEO_PROCESSOR_OUTPUT_RATE OutputRate, [In] BOOL RepeatFrame, [In] in DXGI_RATIONAL pCustomRate)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, D3D11_VIDEO_PROCESSOR_OUTPUT_RATE, BOOL, in DXGI_RATIONAL, void>)_vTable[29])
                    (thisPtr, pVideoProcessor, StreamIndex, OutputRate, RepeatFrame, pCustomRate);
            }
        }

        public void VideoProcessorSetStreamSourceRect([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] BOOL Enable, [In] in RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, in RECT, void>)_vTable[30])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, pRect);
            }
        }

        public void VideoProcessorSetStreamDestRect([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] BOOL Enable, [In] in RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, in RECT, void>)_vTable[31])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, pRect);
            }
        }

        public void VideoProcessorSetStreamAlpha([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] BOOL Enable, [In] FLOAT Alpha)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, FLOAT, void>)_vTable[32])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, Alpha);
            }
        }

        public void VideoProcessorSetStreamPalette([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] UINT Count, [In] UINT[] pEntries)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, UINT, UINT[], void>)_vTable[33])
                    (thisPtr, pVideoProcessor, StreamIndex, Count, pEntries);
            }
        }

        public void VideoProcessorSetStreamPixelAspectRatio([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] BOOL Enable, [In] in DXGI_RATIONAL pSourceAspectRatio, [In] in DXGI_RATIONAL pDestinationAspectRatio)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, in DXGI_RATIONAL, in DXGI_RATIONAL, void>)_vTable[34])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, pSourceAspectRatio, pDestinationAspectRatio);
            }
        }

        public void VideoProcessorSetStreamLumaKey([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] BOOL Enable, [In] FLOAT Lower, [In] FLOAT Upper)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, FLOAT, FLOAT, void>)_vTable[35])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, Lower, Upper);
            }
        }

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

        public void VideoProcessorSetStreamAutoProcessingMode([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [In] BOOL Enable)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, void>)_vTable[37])(thisPtr, pVideoProcessor, StreamIndex, Enable);
            }
        }

        public void VideoProcessorSetStreamFilter([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] D3D11_VIDEO_PROCESSOR_FILTER Filter, [In] BOOL Enable, [In] int Level)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, D3D11_VIDEO_PROCESSOR_FILTER, BOOL, int, void>)_vTable[38])
                    (thisPtr, pVideoProcessor, StreamIndex, Filter, Enable, Level);
            }
        }

        public HRESULT VideoProcessorSetStreamExtension([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] in GUID pExtensionGuid, [In] UINT DataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, in GUID, UINT, IntPtr, HRESULT>)_vTable[39])
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
        /// For RGB streams, the palette entries use the <see cref="DXGI_FORMAT_B8G8R8A8"/> representation.
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
            [In] in GUID pExtensionGuid, [In] UINT DataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, in GUID, UINT, IntPtr, HRESULT>)_vTable[52])
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
        public HRESULT NegotiateCryptoSessionKeyExchange([In] P<ID3D11CryptoSession> pCryptoSession, [In] UINT DataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, UINT, IntPtr, HRESULT>)_vTable[54])
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
            [In] P<ID3D11Texture2D> pDstSurface, [In] UINT IVSize, [In] IntPtr pIV)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, P<ID3D11Texture2D>, P<ID3D11Texture2D>, UINT, IntPtr, void>)_vTable[55])
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
            [In] IntPtr pContentKey, [In] UINT IVSize, [In] IntPtr pIV)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, P<ID3D11Texture2D>, P<ID3D11Texture2D>,
                    in D3D11_ENCRYPTED_BLOCK_INFO, UINT, IntPtr, UINT, IntPtr, void>)_vTable[56])
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
        public void StartSessionKeyRefresh([In] P<ID3D11CryptoSession> pCryptoSession, [In] UINT RandomNumberSize, [In] IntPtr pRandomNumber)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, UINT, IntPtr, void>)_vTable[57])
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
        public HRESULT GetEncryptionBltKey([In] P<ID3D11CryptoSession> pCryptoSession, [In] UINT KeySize, [In] IntPtr pReadbackKey)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, UINT, IntPtr, HRESULT>)_vTable[59])
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
        public HRESULT NegotiateAuthenticatedChannelKeyExchange([In] P<ID3D11AuthenticatedChannel> pChannel, [In] UINT DataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11AuthenticatedChannel>, UINT, IntPtr, HRESULT>)_vTable[60])
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
            [In] IntPtr pInput, [In] UINT OutputSize, [In] IntPtr pOutput)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11AuthenticatedChannel>, UINT, IntPtr, UINT, IntPtr, HRESULT>)_vTable[61])
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
            [In] IntPtr pInput, [Out] out D3D11_AUTHENTICATED_CONFIGURE_OUTPUT pOutput)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11AuthenticatedChannel>, UINT,
                    IntPtr, out D3D11_AUTHENTICATED_CONFIGURE_OUTPUT, HRESULT>)_vTable[62])
                    (thisPtr, pChannel, InputSize, pInput, out pOutput);
            }
        }

        public void VideoProcessorSetStreamRotation([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] BOOL Enable, [In] D3D11_VIDEO_PROCESSOR_ROTATION Rotation)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, BOOL, D3D11_VIDEO_PROCESSOR_ROTATION, void>)_vTable[63])
                    (thisPtr, pVideoProcessor, StreamIndex, Enable, Rotation);
            }
        }

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
