using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.WAVE_FORMAT;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="WAVEFORMATEX"/> structure defines the format of waveform-audio data.
    /// Only format information common to all waveform-audio data formats is included in this structure.
    /// For formats that require additional information, this structure is included as the first member
    /// in another structure, along with the additional information.
    /// Formats that support more than two channels or sample sizes of more than 16 bits
    /// can be described in a <see cref="WAVEFORMATEXTENSIBLE"/> structure, which includes the <see cref="WAVEFORMATEX"/> structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-waveformatex"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// An example of a format that uses extra information is the Microsoft Adaptive Delta Pulse Code Modulation (MS-ADPCM) format.
    /// The <see cref="wFormatTag"/> for MS-ADPCM is <see cref="WAVE_FORMAT_ADPCM"/>.
    /// The <see cref="cbSize"/> member will typically be set to 32.
    /// The extra information stored for <see cref="WAVE_FORMAT_ADPCM"/> is coefficient pairs required for encoding and decoding the waveform-audio data.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WAVEFORMATEX
    {
        /// <summary>
        /// Waveform-audio format type.
        /// Format tags are registered with Microsoft Corporation for many compression algorithms.
        /// A complete list of format tags can be found in the Mmreg.h header file.
        /// For one- or two-channel PCM data, this value should be <see cref="WAVE_FORMAT_PCM"/>.
        /// When this structure is included in a <see cref="WAVEFORMATEXTENSIBLE"/> structure,
        /// this value must be <see cref="WAVE_FORMAT_EXTENSIBLE"/>.
        /// </summary>
        public WAVE_FORMAT wFormatTag;

        /// <summary>
        /// Number of channels in the waveform-audio data. Monaural data uses one channel and stereo data uses two channels.
        /// </summary>
        public WORD nChannels;

        /// <summary>
        /// Sample rate, in samples per second (hertz).
        /// If <see cref="wFormatTag"/> is <see cref="WAVE_FORMAT_PCM"/>,
        /// then common values for <see cref="nSamplesPerSec"/> are 8.0 kHz, 11.025 kHz, 22.05 kHz, and 44.1 kHz.
        /// For non-PCM formats, this member must be computed according to the manufacturer's specification of the format tag.
        /// </summary>
        public DWORD nSamplesPerSec;

        /// <summary>
        /// Required average data-transfer rate, in bytes per second, for the format tag.
        /// If <see cref="wFormatTag"/> is <see cref="WAVE_FORMAT_PCM"/>, <see cref="nAvgBytesPerSec"/> should be
        /// equal to the product of <see cref="nSamplesPerSec"/> and <see cref="nBlockAlign"/>.
        /// For non-PCM formats, this member must be computed according to the manufacturer's specification of the format tag.
        /// </summary>
        public DWORD nAvgBytesPerSec;

        /// <summary>
        /// Block alignment, in bytes.
        /// The block alignment is the minimum atomic unit of data for the wFormatTag format type.
        /// If <see cref="wFormatTag"/> is <see cref="WAVE_FORMAT_PCM"/> or <see cref="WAVE_FORMAT_EXTENSIBLE"/>,
        /// <see cref="nBlockAlign"/> must be equal to the product of <see cref="nChannels"/> and <see cref="wBitsPerSample"/> divided by 8 (bits per byte).
        /// For non-PCM formats, this member must be computed according to the manufacturer's specification of the format tag.
        /// Software must process a multiple of nBlockAlign bytes of data at a time.
        /// Data written to and read from a device must always start at the beginning of a block.
        /// For example, it is illegal to start playback of PCM data in the middle of a sample (that is, on a non-block-aligned boundary).
        /// </summary>
        public WORD nBlockAlign;

        /// <summary>
        /// Bits per sample for the wFormatTag format type.
        /// If <see cref="wFormatTag"/> is <see cref="WAVE_FORMAT_PCM"/>, then <see cref="wBitsPerSample"/> should be equal to 8 or 16.
        /// For non-PCM formats, this member must be set according to the manufacturer's specification of the format tag.
        /// If <see cref="wFormatTag"/> is <see cref="WAVE_FORMAT_EXTENSIBLE"/>,
        /// this value can be any integer multiple of 8 and represents the container size, not necessarily the sample size;
        /// for example, a 20-bit sample size is in a 24-bit container.
        /// Some compression schemes cannot define a value for <see cref="wBitsPerSample"/>, so this member can be 0.
        /// </summary>
        public WORD wBitsPerSample;

        /// <summary>
        /// Size, in bytes, of extra format information appended to the end of the <see cref="WAVEFORMATEX"/> structure.
        /// This information can be used by non-PCM formats to store extra attributes for the <see cref="wFormatTag"/>.
        /// If no extra information is required by the <see cref="wFormatTag"/>, this member must be set to 0.
        /// For <see cref="WAVE_FORMAT_PCM"/> formats (and only <see cref="WAVE_FORMAT_PCM"/> formats), this member is ignored.
        /// When this structure is included in a <see cref="WAVEFORMATEXTENSIBLE"/> structure, this value must be at least 22.
        /// </summary>
        public WORD cbSize;
    }
}
