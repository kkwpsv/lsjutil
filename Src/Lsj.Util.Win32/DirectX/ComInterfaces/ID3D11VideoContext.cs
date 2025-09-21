using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;

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

        public HRESULT GetDecoderBuffer([In] P<ID3D11VideoDecoder> pDecoder, [In] D3D11_VIDEO_DECODER_BUFFER_TYPE Type, [Out] out UINT pBufferSize, [Out] out IntPtr ppBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, D3D11_VIDEO_DECODER_BUFFER_TYPE, out UINT, out IntPtr, HRESULT>)_vTable[7])
                    (thisPtr, pDecoder, Type, out pBufferSize, out ppBuffer);
            }
        }

        public HRESULT ReleaseDecoderBuffer([In] P<ID3D11VideoDecoder> pDecoder, [In] D3D11_VIDEO_DECODER_BUFFER_TYPE Type)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, D3D11_VIDEO_DECODER_BUFFER_TYPE, HRESULT>)_vTable[8])(thisPtr, pDecoder, Type);
            }
        }

        public HRESULT DecoderBeginFrame([In] P<ID3D11VideoDecoder> pDecoder, [In] P<ID3D11VideoDecoderOutputView> pView, [In] UINT ContentKeySize, [In] IntPtr pContentKey)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, P<ID3D11VideoDecoderOutputView>, UINT, IntPtr, HRESULT>)_vTable[9])
                    (thisPtr, pDecoder, pView, ContentKeySize, pContentKey);
            }
        }

        public HRESULT DecoderEndFrame([In] P<ID3D11VideoDecoder> pDecoder)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, HRESULT>)_vTable[10])(thisPtr, pDecoder);
            }
        }

        public HRESULT SubmitDecoderBuffers([In] P<ID3D11VideoDecoder> pDecoder, [In] UINT NumBuffers, [In] D3D11_VIDEO_DECODER_BUFFER_DESC[] pBufferDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, UINT, D3D11_VIDEO_DECODER_BUFFER_DESC[], HRESULT>)_vTable[11])
                    (thisPtr, pDecoder, NumBuffers, pBufferDesc);
            }
        }

        public HRESULT DecoderExtension([In] P<ID3D11VideoDecoder> pDecoder, [In] in D3D11_VIDEO_DECODER_EXTENSION pExtensionData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoDecoder>, in D3D11_VIDEO_DECODER_EXTENSION, HRESULT>)_vTable[12])(thisPtr, pDecoder, pExtensionData);
            }
        }


        public void VideoProcessorSetOutputTargetRect([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] BOOL Enable, [In] in RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, BOOL, in RECT, void>)_vTable[13])(thisPtr, pVideoProcessor, Enable, pRect);
            }
        }

        public void VideoProcessorSetOutputBackgroundColor([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] BOOL YCbCr, [In] in D3D11_VIDEO_COLOR pColor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, BOOL, in D3D11_VIDEO_COLOR, void>)_vTable[14])
                    (thisPtr, pVideoProcessor, YCbCr, pColor);
            }
        }

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

        public void VideoProcessorGetOutputTargetRect([In] P<ID3D11VideoProcessor> pVideoProcessor, [Out] out BOOL Enable, [Out] out RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, out BOOL, out RECT, void>)_vTable[20])(thisPtr, pVideoProcessor, out Enable, out pRect);
            }
        }

        public void VideoProcessorGetOutputBackgroundColor([In] P<ID3D11VideoProcessor> pVideoProcessor, [Out] out BOOL pYCbCr, [Out] out D3D11_VIDEO_COLOR pColor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, out BOOL, out D3D11_VIDEO_COLOR, void>)_vTable[21])
                    (thisPtr, pVideoProcessor, out pYCbCr, out pColor);
            }
        }

        public void VideoProcessorGetOutputColorSpace([In] P<ID3D11VideoProcessor> pVideoProcessor, [Out] out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE, void>)_vTable[22])
                    (thisPtr, pVideoProcessor, out pColorSpace);
            }
        }

        public void VideoProcessorGetOutputAlphaFillMode([In] P<ID3D11VideoProcessor> pVideoProcessor,
            [Out] out D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE pAlphaFillMode, [Out] out UINT pStreamIndex)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, out D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE, out UINT, void>)_vTable[23])
                    (thisPtr, pVideoProcessor, out pAlphaFillMode, out pStreamIndex);
            }
        }

        public void VideoProcessorGetOutputConstriction([In] P<ID3D11VideoProcessor> pVideoProcessor, [Out] out BOOL pEnabled, [Out] out SIZE pSize)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, out BOOL, out SIZE, void>)_vTable[24])
                    (thisPtr, pVideoProcessor, out pEnabled, out pSize);
            }
        }

        public void VideoProcessorGetOutputStereoMode([In] P<ID3D11VideoProcessor> pVideoProcessor, [Out] out BOOL pEnabled)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, out BOOL, void>)_vTable[25])(thisPtr, pVideoProcessor, out pEnabled);
            }
        }

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

        public void VideoProcessorGetStreamFrameFormat([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [Out] out D3D11_VIDEO_FRAME_FORMAT pFrameFormat)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out D3D11_VIDEO_FRAME_FORMAT, void>)_vTable[40])
                    (thisPtr, pVideoProcessor, StreamIndex, out pFrameFormat);
            }
        }

        public void VideoProcessorGetStreamColorSpace([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [Out] out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE, void>)_vTable[41])
                    (thisPtr, pVideoProcessor, StreamIndex, out pColorSpace);
            }
        }

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

        public void VideoProcessorGetStreamDestRect([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [Out] out BOOL pEnabled, [Out] out RECT pRect)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out BOOL, out RECT, void>)_vTable[44])
                    (thisPtr, pVideoProcessor, StreamIndex, out pEnabled, out pRect);
            }
        }

        public void VideoProcessorGetStreamAlpha([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [Out] out BOOL pEnabled, [Out] out FLOAT pAlpha)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out BOOL, out FLOAT, void>)_vTable[45])
                    (thisPtr, pVideoProcessor, StreamIndex, out pEnabled, out pAlpha);
            }
        }

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

        public void VideoProcessorGetStreamAutoProcessingMode([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex, [Out] out BOOL pEnabled)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, out BOOL, void>)_vTable[50])(thisPtr, pVideoProcessor, StreamIndex, out pEnabled);
            }
        }

        public void VideoProcessorGetStreamFilter([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] D3D11_VIDEO_PROCESSOR_FILTER Filter, [Out] out BOOL pEnabled, [Out] out int pLevel)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, D3D11_VIDEO_PROCESSOR_FILTER, out BOOL, out int, void>)_vTable[51])
                    (thisPtr, pVideoProcessor, StreamIndex, Filter, out pEnabled, out pLevel);
            }
        }

        public HRESULT VideoProcessorGetStreamExtension([In] P<ID3D11VideoProcessor> pVideoProcessor, [In] UINT StreamIndex,
            [In] in GUID pExtensionGuid, [In] UINT DataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessor>, UINT, in GUID, UINT, IntPtr, HRESULT>)_vTable[52])
                    (thisPtr, pVideoProcessor, StreamIndex, pExtensionGuid, DataSize, pData);
            }
        }

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

        public HRESULT NegotiateCryptoSessionKeyExchange([In] P<ID3D11CryptoSession> pCryptoSession, [In] UINT DataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, UINT, IntPtr, HRESULT>)_vTable[54])
                    (thisPtr, pCryptoSession, DataSize, pData);
            }
        }

        public void EncryptionBlt([In] P<ID3D11CryptoSession> pCryptoSession, [In] P<ID3D11Texture2D> pSrcSurface,
            [In] P<ID3D11Texture2D> pDstSurface, [In] UINT IVSize, [In] IntPtr pIV)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, P<ID3D11Texture2D>, P<ID3D11Texture2D>, UINT, IntPtr, void>)_vTable[55])
                    (thisPtr, pCryptoSession, pSrcSurface, pDstSurface, IVSize, pIV);
            }
        }

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

        public void StartSessionKeyRefresh([In] P<ID3D11CryptoSession> pCryptoSession, [In] UINT RandomNumberSize, [In] IntPtr pRandomNumber)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, UINT, IntPtr, void>)_vTable[57])
                    (thisPtr, pCryptoSession, RandomNumberSize, pRandomNumber);
            }
        }

        public void FinishSessionKeyRefresh([In] P<ID3D11CryptoSession> pCryptoSession)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, void>)_vTable[58])(thisPtr, pCryptoSession);
            }
        }

        public HRESULT GetEncryptionBltKey([In] P<ID3D11CryptoSession> pCryptoSession, [In] UINT RandomNumberSize, [In] IntPtr pReadbackKey)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11CryptoSession>, UINT, IntPtr, HRESULT>)_vTable[59])
                    (thisPtr, pCryptoSession, RandomNumberSize, pReadbackKey);
            }
        }

        public HRESULT NegotiateAuthenticatedChannelKeyExchange([In] P<ID3D11AuthenticatedChannel> pChannel, [In] UINT DataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11AuthenticatedChannel>, UINT, IntPtr, HRESULT>)_vTable[60])
                    (thisPtr, pChannel, DataSize, pData);
            }
        }

        public HRESULT QueryAuthenticatedChannel([In] P<ID3D11AuthenticatedChannel> pChannel, [In] UINT InputSize,
            [In] IntPtr pInput, [In] UINT OutputSize, [In] IntPtr pOutput)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11AuthenticatedChannel>, UINT, IntPtr, UINT, IntPtr, HRESULT>)_vTable[61])
                    (thisPtr, pChannel, InputSize, pInput, OutputSize, pOutput);
            }
        }

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
