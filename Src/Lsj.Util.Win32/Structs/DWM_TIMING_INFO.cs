using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Dwmapi;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies Desktop Window Manager (DWM) composition timing information.
    /// Used by the <see cref="DwmGetCompositionTimingInfo"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ns-dwmapi-dwm_timing_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Both <see cref="DWM_FRAME_COUNT"/> and <see cref="QPC_TIME"/> are defined in Dwmapi.h as ULONGLONG.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DWM_TIMING_INFO
    {
        /// <summary>
        /// The size of this <see cref="DWM_TIMING_INFO"/> structure.
        /// </summary>
        public UINT32 cbSize;

        /// <summary>
        /// The monitor refresh rate.
        /// </summary>
        public UNSIGNED_RATIO rateRefresh;

        /// <summary>
        /// The monitor refresh period.
        /// </summary>
        public QPC_TIME qpcRefreshPeriod;

        /// <summary>
        /// The composition rate.
        /// </summary>
        public UNSIGNED_RATIO rateCompose;

        /// <summary>
        /// The query performance counter value before the vertical blank.
        /// </summary>
        public QPC_TIME qpcVBlank;

        /// <summary>
        /// The DWM refresh counter.
        /// </summary>
        public DWM_FRAME_COUNT cRefresh;

        /// <summary>
        /// The DirectX refresh counter.
        /// </summary>
        public UINT cDXRefresh;

        /// <summary>
        /// The query performance counter value for a frame composition.
        /// </summary>
        public QPC_TIME qpcCompose;

        /// <summary>
        /// The frame number that was composed at <see cref="qpcCompose"/>.
        /// </summary>
        public DWM_FRAME_COUNT cFrame;

        /// <summary>
        /// The DirectX present number used to identify rendering frames.
        /// </summary>
        public UINT cDXPresent;

        /// <summary>
        /// The refresh count of the frame that was composed at <see cref="qpcCompose"/>.
        /// </summary>
        public DWM_FRAME_COUNT cRefreshFrame;

        /// <summary>
        /// The DWM frame number that was last submitted.
        /// </summary>
        public DWM_FRAME_COUNT cFrameSubmitted;

        /// <summary>
        /// The DirectX present number that was last submitted.
        /// </summary>
        public UINT cDXPresentSubmitted;

        /// <summary>
        /// The DWM frame number that was last confirmed as presented.
        /// </summary>
        public DWM_FRAME_COUNT cFrameConfirmed;

        /// <summary>
        /// The DirectX present number that was last confirmed as presented.
        /// </summary>
        public UINT cDXPresentConfirmed;

        /// <summary>
        /// The target refresh count of the last frame confirmed as completed by the GPU.
        /// </summary>
        public DWM_FRAME_COUNT cRefreshConfirmed;

        /// <summary>
        /// The DirectX refresh count when the frame was confirmed as presented.
        /// </summary>
        public UINT cDXRefreshConfirmed;

        /// <summary>
        /// The number of frames the DWM presented late.
        /// </summary>
        public DWM_FRAME_COUNT cFramesLate;

        /// <summary>
        /// The number of composition frames that have been issued but have not been confirmed as completed.
        /// </summary>
        public UINT cFramesOutstanding;

        /// <summary>
        /// The last frame displayed.
        /// </summary>
        public DWM_FRAME_COUNT cFrameDisplayed;

        /// <summary>
        /// The QPC time of the composition pass when the frame was displayed.
        /// </summary>
        public QPC_TIME qpcFrameDisplayed;

        /// <summary>
        /// The vertical refresh count when the frame should have become visible.
        /// </summary>
        public DWM_FRAME_COUNT cRefreshFrameDisplayed;

        /// <summary>
        /// The ID of the last frame marked as completed.
        /// </summary>
        public DWM_FRAME_COUNT cFrameComplete;

        /// <summary>
        /// The QPC time when the last frame was marked as completed.
        /// </summary>
        public QPC_TIME qpcFrameComplete;

        /// <summary>
        /// The ID of the last frame marked as pending.
        /// </summary>
        public DWM_FRAME_COUNT cFramePending;

        /// <summary>
        /// The QPC time when the last frame was marked as pending.
        /// </summary>
        public QPC_TIME qpcFramePending;

        /// <summary>
        /// The number of unique frames displayed.
        /// This value is valid only after a second call to the <see cref="DwmGetCompositionTimingInfo"/> function.
        /// </summary>
        public DWM_FRAME_COUNT cFramesDisplayed;

        /// <summary>
        /// The number of new completed frames that have been received.
        /// </summary>
        public DWM_FRAME_COUNT cFramesComplete;

        /// <summary>
        /// The number of new frames submitted to DirectX but not yet completed.
        /// </summary>
        public DWM_FRAME_COUNT cFramesPending;

        /// <summary>
        /// The number of frames available but not displayed, used, or dropped.
        /// This value is valid only after a second call to <see cref="DwmGetCompositionTimingInfo"/>.
        /// </summary>
        public DWM_FRAME_COUNT cFramesAvailable;

        /// <summary>
        /// The number of rendered frames that were never displayed because composition occurred too late.
        /// This value is valid only after a second call to <see cref="DwmGetCompositionTimingInfo"/>.
        /// </summary>
        public DWM_FRAME_COUNT cFramesDropped;

        /// <summary>
        /// The number of times an old frame was composed when a new frame should have been used but was not available.
        /// </summary>
        public DWM_FRAME_COUNT cFramesMissed;

        /// <summary>
        /// The frame count at which the next frame is scheduled to be displayed.
        /// </summary>
        public DWM_FRAME_COUNT cRefreshNextDisplayed;

        /// <summary>
        /// The frame count at which the next DirectX present is scheduled to be displayed.
        /// </summary>
        public DWM_FRAME_COUNT cRefreshNextPresented;

        /// <summary>
        /// The total number of refreshes that have been displayed for the application since the <see cref="DwmSetPresentParameters"/> function was last called.
        /// </summary>
        public DWM_FRAME_COUNT cRefreshesDisplayed;

        /// <summary>
        /// The total number of refreshes that have been presented by the application since <see cref="DwmSetPresentParameters"/> was last called.
        /// </summary>
        public DWM_FRAME_COUNT cRefreshesPresented;

        /// <summary>
        /// The refresh number when content for this window started to be displayed.
        /// </summary>
        public DWM_FRAME_COUNT cRefreshStarted;

        /// <summary>
        /// The total number of pixels DirectX redirected to the DWM.
        /// </summary>
        public ULONGLONG cPixelsReceived;

        /// <summary>
        /// The number of pixels drawn.
        /// </summary>
        public ULONGLONG cPixelsDrawn;

        /// <summary>
        /// The number of empty buffers in the flip chain.
        /// </summary>
        public DWM_FRAME_COUNT cBuffersEmpty;
    }
}
