using System.Runtime.InteropServices;
using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the color space for video processing.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_video_processor_color_space"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="RGB_Range"/> member applies to RGB output, while the <see cref="YCbCr_Matrix"/> and <see cref="YCbCr_xvYCC"/> members apply to YCbCr output.
    /// If the driver performs color-space conversion on the background color, it uses the values that apply to both color spaces.
    /// </para>
    /// <para>
    /// If the driver supports extended YCbCr (xvYCC), it returns the <see cref="D3D11_VIDEO_PROCESSOR_DEVICE_CAPS_xvYCC"/> capabilities flag
    /// in the <see cref="ID3D11VideoProcessorEnumerator.GetVideoProcessorCaps"/> method.
    /// Otherwise, the driver ignores the value of <see cref="YCbCr_xvYCC"/> and treats all YCbCr output as conventional YCbCr.
    /// </para>
    /// <para>
    /// If extended YCbCr is supported, it can be used with either transfer matrix.
    /// Extended YCbCr does not change the black point or white point—the black point is still 16 and the white point is still 235.
    /// However, extended YCbCr explicitly allows blacker-than-black values in the range 1–15, and whiter-than-white values in the range 236–254.
    /// When extended YCbCr is used, the driver should not clip the luma values to the nominal 16–235 range.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_VIDEO_PROCESSOR_COLOR_SPACE
    {
        private uint _value;

        /// <summary>
        /// <para>
        /// Specifies whether the output is intended for playback or video processing (such as editing or authoring).
        /// The device can optimize the processing based on the type.
        /// The default state value is 0 (playback).
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
        /// 0
        /// </term>
        /// <term>
        /// Playback
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Video processing
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public uint Usage
        {
            get => _value & 0x1u;
            set => _value = (_value & ~0x1u) | (value & 0x1u);
        }

        /// <summary>
        /// <para>
        /// Specifies the RGB color range.
        /// The default state value is 0 (full range).
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
        /// 0
        /// </term>
        /// <term>
        /// Full range (0-255)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Limited range (16-235)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public uint RGB_Range
        {
            get => (_value >> 1) & 0x1u;
            set => _value = (_value & ~(0x1u << 1)) | ((value & 0x1u) << 1);
        }

        /// <summary>
        /// <para>
        /// Specifies the YCbCr transfer matrix.
        /// The default state value is 0 (BT.601).
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
        /// 0
        /// </term>
        /// <term>
        /// ITU-R BT.601
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// ITU-R BT.709
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public uint YCbCr_Matrix
        {
            get => (_value >> 2) & 0x1u;
            set => _value = (_value & ~(0x1u << 2)) | ((value & 0x1u) << 2);
        }

        /// <summary>
        /// <para>
        /// Specifies whether the output uses conventional YCbCr or extended YCbCr (xvYCC).
        /// The default state value is zero (conventional YCbCr).
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
        /// 0
        /// </term>
        /// <term>
        /// Conventional YCbCr
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Extended YCbCr (xvYCC)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public uint YCbCr_xvYCC
        {
            get => (_value >> 3) & 0x1u;
            set => _value = (_value & ~(0x1u << 3)) | ((value & 0x1u) << 3);
        }

        /// <summary>
        /// <para>
        /// Specifies the <see cref="D3D11_VIDEO_PROCESSOR_NOMINAL_RANGE"/>.
        /// </para>
        /// <para>
        /// Introduced in Windows 8.1.
        /// </para>
        /// </summary>
        public uint Nominal_Range
        {
            get => (_value >> 4) & 0x3u;
            set => _value = (_value & ~(0x3u << 4)) | ((value & 0x3u) << 4);
        }

        /// <summary>
        /// Reserved. Set to zero.
        /// </summary>
        public uint Reserved
        {
            get => (_value >> 6) & 0x03FFFFFFu;
            set => _value = (_value & ~(0x03FFFFFFu << 6)) | ((value & 0x03FFFFFFu) << 6);
        }
    }
}
