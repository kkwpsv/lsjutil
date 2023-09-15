using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="DISPLAYCONFIG_VIDEO_SIGNAL_INFO"/> structure contains information about the video signal for a display.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-displayconfig_video_signal_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_VIDEO_SIGNAL_INFO
    {
        /// <summary>
        /// The pixel clock rate.
        /// </summary>
        [FieldOffset(0)]
        public UINT64 pixelRate;

        /// <summary>
        /// A <see cref="DISPLAYCONFIG_RATIONAL"/> structure that represents horizontal sync.
        /// </summary>
        [FieldOffset(8)]
        public DISPLAYCONFIG_RATIONAL hSyncFreq;

        /// <summary>
        /// A <see cref="DISPLAYCONFIG_RATIONAL"/> structure that represents vertical sync.
        /// </summary>
        [FieldOffset(16)]
        public DISPLAYCONFIG_RATIONAL vSyncFreq;

        /// <summary>
        /// A <see cref="DISPLAYCONFIG_2DREGION"/> structure that specifies the width and height (in pixels) of the active portion of the video signal.
        /// </summary>
        [FieldOffset(24)]
        public DISPLAYCONFIG_2DREGION activeSize;

        /// <summary>
        /// A <see cref="DISPLAYCONFIG_2DREGION"/> structure that specifies the width and height (in pixels) of the entire video signal.
        /// </summary>
        [FieldOffset(32)]
        public DISPLAYCONFIG_2DREGION totalSize;

        /// <summary>
        /// The video standard (if any) that defines the video signal.
        /// For a list of possible values, see the <see cref="D3DKMDT_VIDEO_SIGNAL_STANDARD"/> enumerated type.
        /// </summary>
        [FieldOffset(40)]
        public UINT32 videoStandard;

        /// <summary>
        /// Supported by WDDM 1.3 and later display miniport drivers running on Windows 8.1 and later.
        /// </summary>
        [FieldOffset(40)]
        public DISPLAYCONFIG_VIDEO_SIGNAL_INFO_AdditionalSignalInfo AdditionalSignalInfo;

        /// <summary>
        /// The scan-line ordering (for example, progressive or interlaced) of the video signal.
        /// For a list of possible values, see the <see cref="DISPLAYCONFIG_SCANLINE_ORDERING"/> enumerated type.
        /// </summary>
        [FieldOffset(44)]
        public DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Size = 4)]
        public struct DISPLAYCONFIG_VIDEO_SIGNAL_INFO_AdditionalSignalInfo
        {
            [FieldOffset(0)]
            private uint _value;

            /// <summary>
            /// The video standard (if any) that defines the video signal.
            /// For a list of possible values, see the <see cref="D3DKMDT_VIDEO_SIGNAL_STANDARD"/> enumerated type.
            /// Supported starting with Windows 8.1.
            /// </summary>
#pragma warning disable IDE1006
            public UINT32 videoStandard
#pragma warning restore IDE1006
            {
                get => _value & 0xFFFF;
                set => _value = (_value & 0xFFFF0000) | (_value * 0xFFFF);
            }

            /// <summary>
            /// The ratio of the VSync rate of a monitor that displays through a Miracast connected session to the VSync rate of the Miracast sink.
            /// To avoid visual artifacts, the VSync rate of the display monitor that's connected to the Miracast sink
            /// must be an integer multiple of the VSync rate of the Miracast sink.
            /// The display miniport driver reports the latter rate to the operating system as the refresh rate of the desktop present path.
            /// Note
            /// The operating system fails any attempt by the driver to add a target mode that results in a Miracast target having a VSync rate below 23.9 Hz.
            /// For a non-Miracast target, the driver should set <see cref="vSyncFreqDivider"/> to zero.
            /// Supported starting with Windows 8.1.
            /// </summary>
#pragma warning disable IDE1006
            public UINT32 vSyncFreqDivider
#pragma warning restore IDE1006
            {
                get => (_value & 0x3F0000) >> 16;
                set => _value = (_value & 0xFFC0FFFF) | ((_value * 0x3F) << 16);
            }

            /// <summary>
            /// Reserved for system use.
            /// Do not use in your driver.
            /// Supported starting with Windows 8.1.
            /// </summary>
#pragma warning disable IDE1006
            public UINT32 reserved
#pragma warning restore IDE1006
            {
                get => _value >> 22;
                set => _value = (_value & 0x003FFFFF) | (_value * 0x3FF << 22);
            }
        }
    }
}
