using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This swap chain interface allows desktop media applications to request a seamless change to a specific refresh rate.
    /// For example, a media application presenting video at a typical framerate of 23.997 frames per second
    /// can request a custom refresh rate of 24 or 48 Hz to eliminate jitter.
    /// If the request is approved, the app starts presenting frames at the custom refresh rate immediately
    /// - without the typical 'mode switch' a user would experience when changing the refresh rate themselves by using the control panel.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nn-dxgi1_3-idxgiswapchainmedia"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Seamless changes to custom framerates can only be done on integrated panels.
    /// Custom frame rates cannot be applied to external displays.
    /// If the DXGI output adapter is attached to an external display
    /// then <see cref="CheckPresentDurationSupport"/> will return (0, 0) for upper and lower bounds,
    /// indicating that the device does not support seamless refresh rate changes.
    /// Custom refresh rates can be used when displaying video with a dynamic framerate.
    /// However, the refresh rate change should be kept imperceptible to the user.
    /// A best practice for keeping the refresh rate transition imperceptible is to only set the custom framerate
    /// if the app determines it can present at that rate for least 5 seconds.
    /// </remarks>
    public unsafe struct IDXGISwapChainMedia
    {
        IntPtr* _vTable;

        /// <summary>
        /// Queries the system for a <see cref="DXGI_FRAME_STATISTICS_MEDIA"/> structure
        /// that indicates whether a custom refresh rate is currently approved by the system.
        /// </summary>
        /// <param name="pStats">
        /// A <see cref="DXGI_FRAME_STATISTICS_MEDIA"/> structure indicating whether the system currently approves the custom refresh rate request.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success, or a DXGI error code on failure.
        /// </returns>
        public HRESULT GetFrameStatisticsMedia([Out] out DXGI_FRAME_STATISTICS_MEDIA pStats)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_FRAME_STATISTICS_MEDIA, HRESULT>)_vTable[3])(thisPtr, out pStats);
            }
        }

        /// <summary>
        /// Requests a custom presentation duration (custom refresh rate).
        /// </summary>
        /// <param name="Duration">
        /// The custom presentation duration, specified in hundreds of nanoseconds.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success, or a DXGI error code on failure.
        /// </returns>
        public HRESULT SetPresentDuration([In] UINT Duration)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, HRESULT>)_vTable[4])(thisPtr, Duration);
            }
        }

        /// <summary>
        /// Queries the graphics driver for a supported frame present duration corresponding to a custom refresh rate.
        /// </summary>
        /// <param name="DesiredPresentDuration">
        /// Indicates the frame duration to check.
        /// This value is the duration of one frame at the desired refresh rate, specified in hundreds of nanoseconds.
        /// For example, set this field to 167777 to check for 60 Hz refresh rate support.
        /// </param>
        /// <param name="pClosestSmallerPresentDuration">
        /// A variable that will be set to the closest supported frame present duration
        /// that's smaller than the requested value, or zero if the device does not support any lower duration.
        /// </param>
        /// <param name="pClosestLargerPresentDuration">
        /// A variable that will be set to the closest supported frame present duration
        /// that's larger than the requested value, or zero if the device does not support any higher duration.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success, or a DXGI error code on failure.
        /// </returns>
        /// <remarks>
        /// If the DXGI output adapter does not support custom refresh rates (for example, an external display)
        /// then the display driver will set upper and lower bounds to (0, 0).
        /// </remarks>
        public HRESULT CheckPresentDurationSupport([In] UINT DesiredPresentDuration, [Out] out UINT pClosestSmallerPresentDuration,
            [Out] out UINT pClosestLargerPresentDuration)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out UINT, out UINT, HRESULT>)_vTable[5])
                    (thisPtr, DesiredPresentDuration, out pClosestSmallerPresentDuration, out pClosestLargerPresentDuration);
            }
        }
    }
}
