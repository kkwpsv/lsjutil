using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the configuration of a Microsoft Direct3D 11 decoder device for DirectX Video Acceleration (DXVA).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_decoder_config"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_DECODER_CONFIG
    {
        /// <summary>
        /// If the bitstream data buffers are encrypted using the D3D11CryptoSession mechanism,
        /// this GUID should be set to zero.
        /// If no encryption is applied, the value is <see cref="DXVA_NoEncrypt"/>.
        /// If <see cref="ConfigBitstreamRaw"/> is 0, the value must be <see cref="DXVA_NoEncrypt"/>.
        /// </summary>
        public GUID guidConfigBitstreamEncryption;

        /// <summary>
        /// If the macroblock control data buffers are encrypted using the D3D11CryptoSession mechanism,
        /// this GUID should be set to zero.
        /// If no encryption is applied, the value is <see cref="DXVA_NoEncrypt"/>. 
        /// If <see cref="ConfigBitstreamRaw"/> is 1, the value must be <see cref="DXVA_NoEncrypt"/>.
        /// </summary>
        public GUID guidConfigMBcontrolEncryption;

        /// <summary>
        /// If the residual difference decoding data buffers are encrypted using the D3D11CryptoSession mechanism,
        /// this GUID should be set to zero.
        /// If no encryption is applied, the value is <see cref="DXVA_NoEncrypt"/>.
        /// If <see cref="ConfigBitstreamRaw"/> is 1, the value must be <see cref="DXVA_NoEncrypt"/>.
        /// </summary>
        public GUID guidConfigResidDiffEncryption;

        /// <summary>
        /// Indicates whether the host-decoder sends raw bit-stream data.
        /// If the value is 1, the data for the pictures will be sent in bit-stream buffers as raw bit-stream content.
        /// If the value is 0, picture data will be sent using macroblock control command buffers.
        /// If either <see cref="ConfigResidDiffHost"/> or <see cref="ConfigResidDiffAccelerator"/> is 1, the value must be 0.
        /// </summary>
        public UINT ConfigBitstreamRaw;

        /// <summary>
        /// Specifies whether macroblock control commands are in raster scan order or in arbitrary order.
        /// If the value is 1, the macroblock control commands
        /// within each macroblock control command buffer are in raster-scan order.
        /// If the value is 0, the order is arbitrary.
        /// For some types of bit streams, forcing raster order
        /// either greatly increases the number of required macroblock control buffers that must be processed,
        /// or requires host reordering of the control information.
        /// Therefore, supporting arbitrary order can be more efficient.
        /// </summary>
        public UINT ConfigMBcontrolRasterOrder;

        /// <summary>
        /// Contains the host residual difference configuration.
        /// If the value is 1, some residual difference decoding data
        /// may be sent as blocks in the spatial domain from the host.
        /// If the value is 0, spatial domain data will not be sent.
        /// </summary>
        public UINT ConfigResidDiffHost;

        /// <summary>
        /// <para>
        /// Indicates the word size used to represent residual difference spatial-domain blocks
        /// for predicted (non-intra) pictures when using host-based residual difference decoding.
        /// </para>
        /// <para>
        /// If <see cref="ConfigResidDiffHost"/> is 1 and <see cref="ConfigSpatialResid8"/> is 1,
        /// the host will send residual difference spatial-domain blocks for non-intra macroblocks
        /// using 8-bit signed samples and for intra macroblocks in predicted (non-intra) pictures
        /// in a format that depends on the value of <see cref="ConfigIntraResidUnsigned"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If <see cref="ConfigIntraResidUnsigned"/> is 0, spatial-domain blocks for intra macroblocks
        /// are sent as 8-bit signed integer values relative to a constant reference value of 2^(BPP–1).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <see cref="ConfigIntraResidUnsigned"/> is 1, spatial-domain blocks for intra macroblocks
        /// are sent as 8-bit unsigned integer values relative to a constant reference value of 0.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <see cref="ConfigResidDiffHost"/> is 1 and <see cref="ConfigSpatialResid8"/> is 0,
        /// the host will send residual difference spatial-domain blocks of data for non-intra macroblocks
        /// using 16-bit signed samples and for intra macroblocks in predicted (non-intra) pictures
        /// in a format that depends on the value of <see cref="ConfigIntraResidUnsigned"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If <see cref="ConfigIntraResidUnsigned"/> is 0, spatial domain blocks for intra macroblocks
        /// are sent as 16-bit signed integer values relative to a constant reference value of 2^(BPP–1).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <see cref="ConfigIntraResidUnsigned"/> is 1, spatial domain blocks for intra macroblocks
        /// are sent as 16-bit unsigned integer values relative to a constant reference value of 0.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <see cref="ConfigResidDiffHost"/> is 0, <see cref="ConfigSpatialResid8"/> must be 0.
        /// </para>
        /// <para>
        /// For intra pictures, spatial-domain blocks must be sent using 8-bit samples if bits-per-pixel (BPP) is 8,
        /// and using 16-bit samples if BPP &gt; 8.
        /// If <see cref="ConfigIntraResidUnsigned"/> is 0,
        /// these samples are sent as signed integer values relative to a constant reference value of 2^(BPP–1),
        /// and if <see cref="ConfigIntraResidUnsigned"/> is 1,
        /// these samples are sent as unsigned integer values relative to a constant reference value of 0.
        /// </para>
        /// </summary>
        public UINT ConfigSpatialResid8;

        /// <summary>
        /// <para>
        /// If the value is 1, 8-bit difference overflow blocks are subtracted rather than added.
        /// The value must be 0 unless <see cref="ConfigSpatialResid8"/> is 1.
        /// </para>
        /// <para>
        /// The ability to subtract differences rather than add them enables 8-bit difference decoding 
        /// to be fully compliant with the full ±255 range of values required in video decoder specifications,
        /// because +255 cannot be represented as the addition of two signed 8-bit numbers,
        /// but any number in the range ±255 can be represented as the difference
        /// between two signed 8-bit numbers (+255 = +127 minus –128).
        /// </para>
        /// </summary>
        public UINT ConfigResid8Subtraction;

        /// <summary>
        /// <para>
        /// If the value is 1, spatial-domain blocks for intra macroblocks must be clipped to an 8-bit range on the host
        /// and spatial-domain blocks for non-intra macroblocks must be clipped to a 9-bit range on the host.
        /// If the value is 0, no such clipping is necessary by the host.
        /// </para>
        /// <para>
        /// The value must be 0 unless <see cref="ConfigSpatialResid8"/> is 0 and <see cref="ConfigResidDiffHost"/> is 1.
        /// </para>
        /// </summary>
        public UINT ConfigSpatialHost8or9Clipping;

        /// <summary>
        /// If the value is 1, any spatial-domain residual difference data must be sent
        /// in a chrominance-interleaved form matching the YUV format chrominance interleaving pattern.
        /// The value must be 0 unless <see cref="ConfigResidDiffHost"/> is 1 and the YUV format is NV12 or NV21.
        /// </summary>
        public UINT ConfigSpatialResidInterleaved;

        /// <summary>
        /// <para>
        /// Indicates the method of representation of spatial-domain blocks of residual difference data
        /// for intra blocks when using host-based difference decoding.
        /// </para>
        /// <para>
        /// If <see cref="ConfigResidDiffHost"/> is 1 and <see cref="ConfigIntraResidUnsigned"/> is 0,
        /// spatial-domain residual difference data blocks for intra macroblocks must be sent as follows:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// In a non-intra picture, if <see cref="ConfigSpatialResid8"/> is 0,
        /// the spatial-domain residual difference data blocks for intra macroblocks
        /// are sent as 16-bit signed integer values relative to a constant reference value of 2^(BPP–1).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// In a non-intra picture, if <see cref="ConfigSpatialResid8"/> is 1,
        /// the spatial-domain residual difference data blocks for intra macroblocks
        /// are sent as 8-bit signed integer values relative to a constant reference value of 2^(BPP–1).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// In an intra picture, if BPP is 8, the spatial-domain residual difference data blocks
        /// for intra macroblocks are sent as 8-bit signed integer values relative to a constant reference value of 2^(BPP–1),
        /// regardless of the value of <see cref="ConfigSpatialResid8"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <see cref="ConfigResidDiffHost"/> is 1 and <see cref="ConfigIntraResidUnsigned"/> is 1,
        /// spatial-domain residual difference data blocks for intra macroblocks must be sent as follows:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// In a non-intra picture, if <see cref="ConfigSpatialResid8"/> is 0,
        /// the spatial-domain residual difference data blocks for intra macroblocks
        /// must be sent as 16-bit unsigned integer values relative to a constant reference value of 0.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// In a non-intra picture, if <see cref="ConfigSpatialResid8"/> is 1,
        /// the spatial-domain residual difference data blocks for intra macroblocks
        /// are sent as 8-bit unsigned integer values relative to a constant reference value of 0.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// In an intra picture, if BPP is 8, the spatial-domain residual difference data blocks
        /// for intra macroblocks are sent as 8-bit unsigned integer values
        /// relative to a constant reference value of 0, regardless of the value of <see cref="ConfigSpatialResid8"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The value of the member must be 0 unless <see cref="ConfigResidDiffHost"/> is 1.
        /// </para>
        /// </summary>
        public UINT ConfigIntraResidUnsigned;

        /// <summary>
        /// <para>
        /// If the value is 1, transform-domain blocks of coefficient data
        /// may be sent from the host for accelerator-based IDCT.
        /// If the value is 0, accelerator-based IDCT will not be used.
        /// If both <see cref="ConfigResidDiffHost"/> and <see cref="ConfigResidDiffAccelerator"/> are 1,
        /// this indicates that some residual difference decoding will be done on the host and some on the accelerator,
        /// as indicated by macroblock-level control commands.
        /// </para>
        /// <para>
        /// The value must be 0 if <see cref="ConfigBitstreamRaw"/> is 1.
        /// </para>
        /// </summary>
        public UINT ConfigResidDiffAccelerator;

        /// <summary>
        /// <para>
        /// If the value is 1, the inverse scan for transform-domain block processing will be performed on the host,
        /// and absolute indices will be sent instead for any transform coefficients.
        /// If the value is 0, the inverse scan will be performed on the accelerator.
        /// </para>
        /// <para>
        /// The value must be 0 if <see cref="ConfigResidDiffAccelerator"/> is 0 or if <see cref="Config4GroupedCoefs"/> is 1.
        /// </para>
        /// </summary>
        public UINT ConfigHostInverseScan;

        /// <summary>
        /// <para>
        /// If the value is 1, the IDCT specified in Annex W of ITU-T Recommendation H.263 is used.
        /// If the value is 0, any compliant IDCT can be used for off-host IDCT.
        /// </para>
        /// <para>
        /// The H.263 annex does not comply with the IDCT requirements of MPEG-2 corrigendum 2,
        /// so the value must not be 1 for use with MPEG-2 video.
        /// </para>
        /// <para>
        /// The value must be 0 if <see cref="ConfigResidDiffAccelerator"/> is 0,
        /// indicating purely host-based residual difference decoding.
        /// </para>
        /// </summary>
        public UINT ConfigSpecificIDCT;

        /// <summary>
        /// If the value is 1, transform coefficients for off-host IDCT
        /// will be sent using the <see cref="DXVA_TCoef4Group"/> structure.
        /// If the value is 0, the <see cref="DXVA_TCoefSingle"/> structure is used.
        /// The value must be 0 if <see cref="ConfigResidDiffAccelerator"/> is 0
        /// or if <see cref="ConfigHostInverseScan"/> is 1.
        /// </summary>
        public UINT Config4GroupedCoefs;

        /// <summary>
        /// Specifies how many frames the decoder device processes at any one time.
        /// </summary>
        public USHORT ConfigMinRenderTargetBuffCount;

        /// <summary>
        /// Contains decoder-specific configuration information.
        /// </summary>
        public USHORT ConfigDecoderSpecific;
    }
}
