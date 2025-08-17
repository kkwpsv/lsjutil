using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Indicates options for presenting frames to the swap chain.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/ne-dxgi1_3-dxgi_frame_presentation_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="DXGI_FRAME_STATISTICS_MEDIA"/> structure.
    /// </remarks>
    public enum DXGI_FRAME_PRESENTATION_MODE
    {
        /// <summary>
        /// <para>
        /// Specifies that the presentation mode is a composition surface,
        /// meaning that the conversion from YUV to RGB is happening once per output refresh (for example, 60 Hz).
        /// </para>
        /// <para>
        /// When this value is returned, the media app should discontinue use of the decode swap chain and perform YUV to RGB conversion itself, 
        /// reducing the frequency of YUV to RGB conversion to once per video frame.
        /// </para>
        /// </summary>
        DXGI_FRAME_PRESENTATION_MODE_COMPOSED = 0,

        /// <summary>
        /// <para>
        /// Specifies that the presentation mode is an overlay surface,
        /// meaning that the YUV to RGB conversion is happening efficiently in hardware (once per video frame).
        /// </para>
        /// <para>
        /// When this value is returned, the media app can continue to use the decode swap chain.
        /// </para>
        /// <para>
        /// See <see cref="IDXGIDecodeSwapChain"/>.
        /// </para>
        /// </summary>
        DXGI_FRAME_PRESENTATION_MODE_OVERLAY = 1,

        /// <summary>
        /// No presentation is specified.
        /// </summary>
        DXGI_FRAME_PRESENTATION_MODE_NONE = 2,

        /// <summary>
        /// <para>
        /// An issue occurred that caused content protection to be invalidated in a swap-chain with hardware content protection,
        /// and is usually because the system ran out of hardware protected memory.
        /// The app will need to do one of the following:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Drastically reduce the amount of hardware protected memory used. For example, media applications might be able to reduce their buffering.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Stop using hardware protection if possible.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Note that simply re-creating the swap chain or the device will usually have no impact
        /// as the DWM will continue to run out of memory and will return the same failure.
        /// </para>
        /// </summary>
        DXGI_FRAME_PRESENTATION_MODE_COMPOSITION_FAILURE = 3,
    }
}
