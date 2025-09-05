using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_AUTHENTICATED_CHANNEL_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BIND_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_USAGE;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Provides the video decoding and video processing capabilities of a Microsoft Direct3D 11 device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11videodevice"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The Direct3D 11 device supports this interface. To get a pointer to this interface,
    /// call <see cref="IUnknown.QueryInterface"/> with an <see cref="ID3D11Device"/> interface pointer.
    /// </para>
    /// <para>
    /// If you query an <see cref="ID3D11Device"/> for <see cref="ID3D11VideoDevice"/>
    /// and the Direct3D 11 device created is using the reference rasterizer or WARP,
    /// or is a hardware device and you are using the Microsoft Basic Display Adapter,
    /// <see cref="E_NOINTERFACE"/> is returned.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "10EC4D5B-975A-4689-B9E4-D0AAC30FE333", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 19, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct ID3D11VideoDevice
    {
        IntPtr* _vTable;

        /// <summary>
        /// Creates a video decoder device for Microsoft Direct3D 11.
        /// </summary>
        /// <param name="pVideoDesc">
        /// A pointer to a <see cref="D3D11_VIDEO_DECODER_DESC"/> structure
        /// that describes the video stream and the decoder profile.
        /// </param>
        /// <param name="pConfig">
        /// A pointer to a <see cref="D3D11_VIDEO_DECODER_CONFIG"/> structure that specifies the decoder configuration.
        /// </param>
        /// <param name="ppDecoder">
        /// Receives a pointer to the <see cref="ID3D11VideoDecoder"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method allocates the necessary decoder buffers.
        /// </para>
        /// <para>
        /// The <see cref="ID3D11DeviceContext.ClearState"/> method does not affect the internal state of the video decoder.
        /// </para>
        /// </remarks>
        public HRESULT CreateVideoDecoder([In] in D3D11_VIDEO_DECODER_DESC pVideoDesc, [In] in D3D11_VIDEO_DECODER_CONFIG pConfig,
            [Out] out P<ID3D11VideoDecoder> ppDecoder)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_VIDEO_DECODER_DESC, in D3D11_VIDEO_DECODER_CONFIG,
                    out P<ID3D11VideoDecoder>, HRESULT>)_vTable[3])(thisPtr, pVideoDesc, pConfig, out ppDecoder);
            }
        }

        /// <summary>
        /// Gets a cryptographic key-exchange mechanism that is supported by the driver.
        /// </summary>
        /// <param name="pEnum">
        /// A pointer to the <see cref="ID3D11VideoProcessorEnumerator"/> interface.
        /// To get this pointer, call <see cref="CreateVideoProcessorEnumerator"/>.
        /// </param>
        /// <param name="RateConversionIndex">
        /// Specifies the frame-rate conversion capabilities for the video processor.
        /// The value is a zero-based index that corresponds to the TypeIndex parameter
        /// of the <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorRateConversionCaps"/> method.
        /// </param>
        /// <param name="ppVideoProcessor">
        /// Receives a pointer to the <see cref="ID3D11VideoProcessor"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The <see cref="ID3D11DeviceContext.ClearState"/> method
        /// does not affect the internal state of the video processor.
        /// </remarks>
        public HRESULT CreateVideoProcessor([In] P<ID3D11VideoProcessorEnumerator> pEnum, [In] UINT RateConversionIndex,
            [Out] out P<ID3D11VideoProcessor> ppVideoProcessor)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11VideoProcessorEnumerator>, UINT,
                    out P<ID3D11VideoProcessor>, HRESULT>)_vTable[4])(thisPtr, pEnum, RateConversionIndex, out ppVideoProcessor);
            }
        }

        /// <summary>
        /// Creates a channel to communicate with the Microsoft Direct3D device or the graphics driver.
        /// The channel can be used to send commands and queries for content protection.
        /// </summary>
        /// <param name="ChannelType">
        /// Specifies the type of channel,
        /// as a member of the <see cref="D3D11_AUTHENTICATED_CHANNEL_TYPE"/> enumeration.
        /// </param>
        /// <param name="ppAuthenticatedChannel">
        /// Receives a pointer to the <see cref="ID3D11AuthenticatedChannel"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the <paramref name="ChannelType"/> parameter is <see cref="D3D11_AUTHENTICATED_CHANNEL_D3D11"/>,
        /// the method creates a channel with the Direct3D device. This type of channel does not support authentication.
        /// </para>
        /// <para>
        /// If <paramref name="ChannelType"/> is <see cref="D3D11_AUTHENTICATED_CHANNEL_DRIVER_SOFTWARE"/>
        /// or <see cref="D3D11_AUTHENTICATED_CHANNEL_DRIVER_HARDWARE"/>,
        /// the method creates an authenticated channel with the graphics driver.
        /// </para>
        /// </remarks>
        public HRESULT CreateAuthenticatedChannel([In] P<D3D11_AUTHENTICATED_CHANNEL_TYPE> ChannelType,
            [Out] out P<ID3D11AuthenticatedChannel> ppAuthenticatedChannel)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<D3D11_AUTHENTICATED_CHANNEL_TYPE>, out P<ID3D11AuthenticatedChannel>, HRESULT>)_vTable[5])
                    (thisPtr, ChannelType, out ppAuthenticatedChannel);
            }
        }

        /// <summary>
        /// Creates a cryptographic session to encrypt video content that is sent to the graphics driver.
        /// </summary>
        /// <param name="pCryptoType">
        /// <para>
        /// A pointer to a GUID that specifies the type of encryption to use.
        /// The following GUIDs are defined.
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
        /// <see cref="D3D11_CRYPTO_TYPE_AES128_CTR"/>
        /// </term>
        /// <term>
        /// 128-bit Advanced Encryption Standard CTR mode (AES-CTR) block cipher.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pDecoderProfile">
        /// A pointer to a GUID that specifies the decoding profile.
        /// For a list of possible values, see <see cref="GetVideoDecoderProfile"/>.
        /// If decoding will not be used, set this parameter to <see cref="NULL"/>.
        /// </param>
        /// <param name="pKeyExchangeType">
        /// <para>
        /// A pointer to a GUID that specifies the type of key exchange.
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
        /// <see cref="D3D11_KEY_EXCHANGE_RSAES_OAEP"/>
        /// </term>
        /// <term>
        /// The caller will create the session key, encrypt it
        /// with RSA Encryption Scheme - Optimal Asymmetric Encryption Padding (RSAES-OAEP)
        /// by using the driver's public key, and pass the session key to the driver.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="ppCryptoSession">
        /// Receives a pointer to the <see cref="ID3D11CryptoSession"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The <see cref="ID3D11DeviceContext.ClearState"/> method
        /// does not affect the internal state of the cryptographic session.
        /// </remarks>
        public HRESULT CreateCryptoSession([In] in GUID pCryptoType, [In] in GUID pDecoderProfile, [In] in GUID pKeyExchangeType,
            [Out] out P<ID3D11CryptoSession> ppCryptoSession)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, in GUID, in GUID, out P<ID3D11CryptoSession>, HRESULT>)_vTable[6])
                    (thisPtr, pCryptoType, pDecoderProfile, pKeyExchangeType, out ppCryptoSession);
            }
        }

        /// <summary>
        /// Creates a resource view for a video decoder,
        /// describing the output sample for the decoding operation.
        /// </summary>
        /// <param name="pResource">
        /// A pointer to the <see cref="ID3D11Resource"/> interface of the decoder surface.
        /// The resource must be created with the <see cref="D3D11_BIND_DECODER"/> flag.
        /// See <see cref="D3D11_BIND_FLAG"/>.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC"/> structure that describes the view.
        /// </param>
        /// <param name="ppVDOVView">
        /// Receives a pointer to the <see cref="ID3D11VideoDecoderOutputView"/> interface.
        /// The caller must release the interface.
        /// If this parameter is <see cref="NullRef{T}"/>,
        /// the method checks whether the view is supported, but does not create the view.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Set the <paramref name="ppVDOVView"/> parameter to <see cref="NULL"/> to test whether a view is supported.
        /// </remarks>
        public HRESULT CreateVideoDecoderOutputView([In] P<ID3D11Resource> pResource, [In] in D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC pDesc,
            [Out] out P<ID3D11VideoDecoderOutputView> ppVDOVView)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Resource>, in D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC,
                    out P<ID3D11VideoDecoderOutputView>, HRESULT>)_vTable[7])(thisPtr, pResource, pDesc, out ppVDOVView);
            }
        }

        /// <summary>
        /// Creates a resource view for a video processor,
        /// describing the input sample for the video processing operation.
        /// </summary>
        /// <param name="pResource">
        /// A pointer to the <see cref="ID3D11Resource"/> interface of the input surface.
        /// </param>
        /// <param name="pEnum">
        /// A pointer to the <see cref="ID3D11VideoProcessorEnumerator"/> interface that specifies the video processor.
        /// To get this pointer, call <see cref="CreateVideoProcessorEnumerator"/>.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC"/> structure that describes the view.
        /// </param>
        /// <param name="ppVPIView">
        /// Receives a pointer to the <see cref="ID3D11VideoProcessorInputView"/> interface.
        /// The caller must release the resource.
        /// If this parameter is <see cref="NullRef{T}"/>,
        /// the method checks whether the view is supported, but does not create the view.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Set the <paramref name="ppVPIView"/> parameter to <see cref="NullRef{T}"/> to test whether a view is supported.
        /// </para>
        /// <para>
        /// The surface format is given in the <see cref="D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC.FourCC"/> member
        /// of the <see cref="D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC"/> structure.
        /// The method fails if the video processor does not support this format as an input sample.
        /// An app must specify 0 when using 9_1, 9_2, or 9_3 feature levels.
        /// </para>
        /// <para>
        /// Resources used for video processor input views must use the following bind flag combinations:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Any combination of bind flags that includes <see cref="D3D11_BIND_DECODER"/>,
        /// <see cref="D3D11_BIND_VIDEO_ENCODER"/>, <see cref="D3D11_BIND_RENDER_TARGET"/>,
        /// and <see cref="D3D11_BIND_UNORDERED_ACCESS"/> can be used as for video processor input views
        /// (regardless of what other bind flags may be set).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Bind flags = 0 is also allowed for a video processor input view.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Other restrictions will apply such as:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// No multi-sampling is allowed.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The Texture2D must have been created using <see cref="D3D11_USAGE_DEFAULT"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT CreateVideoProcessorInputView([In] P<ID3D11Resource> pResource, [In] P<ID3D11VideoProcessorEnumerator> pEnum,
            [In] in D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC pDesc, [Out] out P<ID3D11VideoProcessorInputView> ppVPIView)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Resource>, P<ID3D11VideoProcessorEnumerator>,
                    in D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC, out P<ID3D11VideoProcessorInputView>, HRESULT>)_vTable[8])
                    (thisPtr, pResource, pEnum, pDesc, out ppVPIView);
            }
        }

        /// <summary>
        /// Creates a resource view for a video processor,
        /// describing the output sample for the video processing operation.
        /// </summary>
        /// <param name="pResource">
        /// A pointer to the <see cref="ID3D11Resource"/> interface of the output surface.
        /// The resource must be created with the <see cref="D3D11_BIND_RENDER_TARGET"/> flag.
        /// See <see cref="D3D11_BIND_FLAG"/>.
        /// </param>
        /// <param name="pEnum">
        /// A pointer to the <see cref="ID3D11VideoProcessorEnumerator"/> interface that specifies the video processor.
        /// To get this pointer, call <see cref="CreateVideoProcessorEnumerator"/>.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC"/> structure that describes the view.
        /// </param>
        /// <param name="ppVPOView">
        /// Receives a pointer to the <see cref="ID3D11VideoProcessorOutputView"/> interface.
        /// The caller must release the resource.
        /// If this parameter is <see cref="NullRef{T}"/>,
        /// the method checks whether the view is supported, but does not create the view.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Set the <paramref name="ppVPOView"/> parameter to <see cref="NullRef{T}"/> to test whether a view is supported.
        /// </para>
        /// <para>
        /// Resources used for video processor output views must use the following <see cref="D3D11_BIND_FLAG"/> combinations:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="D3D11_BIND_RENDER_TARGET"/> indicates that it can be used for a video processor output view.
        /// The following bind flags are allowed to be set with <see cref="D3D11_BIND_RENDER_TARGET"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3D11_BIND_VIDEO_ENCODER"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D11_BIND_SHADER_RESOURCE"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Other restrictions will apply such as:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// No multi-sampling is allowed.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The Texture2D must have been created using <see cref="D3D11_USAGE_DEFAULT"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Some YUV formats can be supported as a video processor output view,
        /// but might not be supported as a 3D render target.
        /// D3D11 will allow the <see cref="D3D11_BIND_RENDER_TARGET"/> flag for these formats,
        /// but <see cref="ID3D11Device.CreateRenderTargetView"/> will not be allowed for these formats.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If stereo output is enabled, the output view must have 2 array elements.
        /// Otherwise, it must only have a single array element.
        /// </para>
        /// </remarks>
        public HRESULT CreateVideoProcessorOutputView([In] P<ID3D11Resource> pResource, [In] P<ID3D11VideoProcessorEnumerator> pEnum,
            [In] in D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC pDesc, [Out] out P<ID3D11VideoProcessorOutputView> ppVPOView)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID3D11Resource>, P<ID3D11VideoProcessorEnumerator>,
                    in D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC, out P<ID3D11VideoProcessorOutputView>, HRESULT>)_vTable[9])
                    (thisPtr, pResource, pEnum, pDesc, out ppVPOView);
            }
        }

        /// <summary>
        /// Enumerates the video processor capabilities of the driver.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D11_VIDEO_PROCESSOR_CONTENT_DESC"/> structure that describes the video content.
        /// </param>
        /// <param name="ppEnum">
        /// Receives a pointer to the <see cref="ID3D11VideoProcessorEnumerator"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// To create the video processor device,
        /// pass the <see cref="ID3D11VideoProcessorEnumerator"/> pointer to the <see cref="CreateVideoProcessor"/> method.
        /// </remarks>
        public HRESULT CreateVideoProcessorEnumerator([In] in D3D11_VIDEO_PROCESSOR_CONTENT_DESC pDesc, [Out] out P<ID3D11VideoProcessorEnumerator> ppEnum)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_VIDEO_PROCESSOR_CONTENT_DESC, out P<ID3D11VideoProcessorEnumerator>, HRESULT>)_vTable[10])
                    (thisPtr, pDesc, out ppEnum);
            }
        }

        /// <summary>
        /// Gets the number of profiles that are supported by the driver.
        /// </summary>
        /// <returns>
        /// Returns the number of profiles.
        /// </returns>
        /// <remarks>
        /// To enumerate the profiles, call <see cref="GetVideoDecoderProfile"/>.
        /// </remarks>
        public UINT GetVideoDecoderProfileCount()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT>)_vTable[11])(thisPtr);
            }
        }

        /// <summary>
        /// Gets a profile that is supported by the driver.
        /// </summary>
        /// <param name="Index">
        /// The zero-based index of the profile.
        /// To get the number of profiles that the driver supports, call <see cref="GetVideoDecoderProfileCount"/>.
        /// </param>
        /// <param name="pDecoderProfile">
        /// Receives a GUID that identifies the profile.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetVideoDecoderProfile([In] UINT Index, [Out] out GUID pDecoderProfile)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out GUID, HRESULT>)_vTable[12])(thisPtr, Index, out pDecoderProfile);
            }
        }

        /// <summary>
        /// Given a profile, checks whether the driver supports a specified output format.
        /// </summary>
        /// <param name="pDecoderProfile">
        /// A pointer to a GUID that identifies the profile.
        /// To get the list of supported profiles, call <see cref="GetVideoDecoderProfile"/>.
        /// </param>
        /// <param name="Format">
        /// A <see cref="DXGI_FORMAT"/> value that specifies the output format.
        /// Typical values include <see cref="DXGI_FORMAT_NV12"/> and <see cref="DXGI_FORMAT_420_OPAQUE"/>.
        /// </param>
        /// <param name="pSupported">
        /// Receives the value <see cref="TRUE"/> if the format is supported, or <see cref="FALSE"/> otherwise.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// If the driver does not support the profile given in <paramref name="pDecoderProfile"/>,
        /// the method returns <see cref="E_INVALIDARG"/>.
        /// If the driver supports the profile, but the DXGI format is not compatible with the profile,
        /// the method succeeds but returns the value <see cref="FALSE"/> in pSupported.
        /// </remarks>
        public HRESULT CheckVideoDecoderFormat([In] in GUID pDecoderProfile, [In] DXGI_FORMAT Format, [Out] out BOOL pSupported)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, DXGI_FORMAT, out BOOL, HRESULT>)_vTable[13])
                    (thisPtr, pDecoderProfile, Format, out pSupported);
            }
        }

        /// <summary>
        /// Gets the number of decoder configurations
        /// that the driver supports for a specified video description.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D11_VIDEO_DECODER_DESC"/> structure that describes the video stream.
        /// </param>
        /// <param name="pCount">
        /// Receives the number of decoder configurations.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// To enumerate the decoder configurations, call <see cref="GetVideoDecoderConfig"/>.
        /// </remarks>
        public HRESULT GetVideoDecoderConfigCount([In] in D3D11_VIDEO_DECODER_DESC pDesc, [Out] out UINT pCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_VIDEO_DECODER_DESC, out UINT, HRESULT>)_vTable[14])(thisPtr, pDesc, out pCount);
            }
        }

        /// <summary>
        /// Gets a decoder configuration that is supported by the driver.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D11_VIDEO_DECODER_DESC"/> structure that describes the video stream.
        /// </param>
        /// <param name="Index">
        /// The zero-based index of the decoder configuration.
        /// To get the number of configurations that the driver supports,
        /// call <see cref="GetVideoDecoderConfigCount"/>.
        /// </param>
        /// <param name="pConfig">
        /// A pointer to a <see cref="D3D11_VIDEO_DECODER_CONFIG"/> structure.
        /// The method fills in the structure with the decoder configuration.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetVideoDecoderConfig([In] in D3D11_VIDEO_DECODER_DESC pDesc, [In] UINT Index, [Out] out D3D11_VIDEO_DECODER_CONFIG pConfig)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_VIDEO_DECODER_DESC, UINT, out D3D11_VIDEO_DECODER_CONFIG, HRESULT>)_vTable[15])
                    (thisPtr, pDesc, Index, out pConfig);
            }
        }

        /// <summary>
        /// Queries the driver for its content protection capabilities.
        /// </summary>
        /// <param name="pCryptoType">
        /// <para>
        /// A pointer to a GUID that specifies the type of encryption to be used.
        /// The following GUIDs are defined.
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
        /// <see cref="D3D11_CRYPTO_TYPE_AES128_CTR"/>
        /// </term>
        /// <term>
        /// 128-bit Advanced Encryption Standard CTR mode (AES-CTR) block cipher.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If no encryption will be used, set this parameter to <see cref="NullRef{GUID}"/>.
        /// </para>
        /// </param>
        /// <param name="pDecoderProfile">
        /// <para>
        /// A pointer to a GUID that specifies the decoding profile.
        /// To get profiles that the driver supports, call <see cref="GetVideoDecoderProfile"/>.
        /// If decoding will not be used, set this parameter to <see cref="NullRef{GUID}"/>.
        /// </para>
        /// <para>
        /// The driver might disallow some combinations of encryption type and profile.
        /// </para>
        /// </param>
        /// <param name="pCaps">
        /// A pointer to a <see cref="D3D11_VIDEO_CONTENT_PROTECTION_CAPS"/> structure.
        /// The method fills in this structure with the driver's content protection capabilities.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetContentProtectionCaps([In] in GUID pCryptoType, [In] in GUID pDecoderProfile,
            [Out] out D3D11_VIDEO_CONTENT_PROTECTION_CAPS pCaps)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, in GUID, out D3D11_VIDEO_CONTENT_PROTECTION_CAPS, HRESULT>)_vTable[16])
                    (thisPtr, pCryptoType, pDecoderProfile, out pCaps);
            }
        }

        /// <summary>
        /// Gets a cryptographic key-exchange mechanism that is supported by the driver.
        /// </summary>
        /// <param name="pCryptoType">
        /// <para>
        /// A pointer to a GUID that specifies the type of encryption to be used.
        /// The following GUIDs are defined.
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
        /// <see cref="D3D11_CRYPTO_TYPE_AES128_CTR"/>
        /// </term>
        /// <term>
        /// 128-bit Advanced Encryption Standard CTR mode (AES-CTR) block cipher.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pDecoderProfile">
        /// A pointer to a <see cref="GUID"/> that specifies the decoding profile.
        /// To get profiles that the driver supports, call <see cref="GetVideoDecoderProfile"/>.
        /// If decoding will not be used, set this parameter to <see cref="NullRef{GUID}"/>.
        /// </param>
        /// <param name="Index">
        /// The zero-based index of the key-exchange type.
        /// The driver reports the number of types
        /// in the <see cref="D3D11_VIDEO_CONTENT_PROTECTION_CAPS.KeyExchangeTypeCount"/> member
        /// of the <see cref="D3D11_VIDEO_CONTENT_PROTECTION_CAPS"/> structure.
        /// </param>
        /// <param name="pKeyExchangeType">
        /// Receives a <see cref="GUID"/> that identifies the type of key exchange.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CheckCryptoKeyExchange([In] in GUID pCryptoType, [In] in GUID pDecoderProfile, [In] UINT Index, [Out] out GUID pKeyExchangeType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, in GUID, UINT, out GUID, HRESULT>)_vTable[17])
                    (thisPtr, pCryptoType, pDecoderProfile, Index, out pKeyExchangeType);
            }
        }

        /// <summary>
        /// Sets private data on the video device and associates that data with a <see cref="GUID"/>.
        /// </summary>
        /// <param name="guid">
        /// The <see cref="GUID"/> associated with the data.
        /// </param>
        /// <param name="DataSize">
        /// The size of the data, in bytes.
        /// </param>
        /// <param name="pData">
        /// A pointer to the data.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT SetPrivateData([In] in GUID guid, [In] UINT DataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, UINT, IntPtr, HRESULT>)_vTable[18])(thisPtr, guid, DataSize, pData);
            }
        }

        /// <summary>
        /// Sets a private <see cref="IUnknown"/> pointer on the video device
        /// and associates that pointer with a <see cref="GUID"/>.
        /// </summary>
        /// <param name="guid">
        /// The <see cref="GUID"/> associated with the pointer.
        /// </param>
        /// <param name="pData">
        /// A pointer to the <see cref="IUnknown"/> interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT SetPrivateDataInterface([In] in GUID guid, [In] P<IUnknown> pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, P<IUnknown>, HRESULT>)_vTable[19])(thisPtr, guid, pData);
            }
        }
    }
}
