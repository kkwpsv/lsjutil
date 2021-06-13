using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.MMRESULT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Winmm.dll
    /// </summary>
    public static class Winmm
    {
#pragma warning disable IDE1006
        /// <summary>
        /// <para>
        /// The <see cref="timeBeginPeriod"/> function requests a minimum resolution for periodic timers.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/timeapi/nf-timeapi-timebeginperiod"/>
        /// </para>
        /// </summary>
        /// <param name="uPeriod">
        /// Minimum timer resolution, in milliseconds, for the application or device driver.
        /// A lower value specifies a higher (more accurate) resolution.
        /// </param>
        /// <returns>
        /// Returns <see cref="TIMERR_NOERROR"/> if successful or <see cref="TIMERR_NOCANDO"/>
        /// if the resolution specified in <paramref name="uPeriod"/> is out of range.
        /// </returns>
        /// <remarks>
        /// Call this function immediately before using timer services, and call the <see cref="timeEndPeriod"/> function immediately
        /// after you are finished using the timer services.
        /// You must match each call to <see cref="timeBeginPeriod"/> with a call to <see cref="timeEndPeriod"/>,
        /// specifying the same minimum resolution in both calls.
        /// An application can make multiple <see cref="timeBeginPeriod"/> calls as long as each call is matched with a call to <see cref="timeEndPeriod"/>.
        /// This function affects a global Windows setting. Windows uses the lowest value (that is, highest resolution) requested by any process.
        /// Setting a higher resolution can improve the accuracy of time-out intervals in wait functions.
        /// However, it can also reduce overall system performance, because the thread scheduler switches tasks more often.
        /// High resolutions can also prevent the CPU power management system from entering power-saving modes.
        /// Setting a higher resolution does not improve the accuracy of the high-resolution performance counter.
        /// </remarks>
        [DllImport("Winmm.dll", CharSet = CharSet.Unicode, EntryPoint = "timeBeginPeriod", ExactSpelling = true, SetLastError = true)]
        public static extern MMRESULT timeBeginPeriod([In] UINT uPeriod);

        /// <summary>
        /// <para>
        /// The <see cref="timeGetDevCaps"/> function queries the timer device to determine its resolution.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/timeapi/nf-timeapi-timegetdevcaps"/>
        /// </para>
        /// </summary>
        /// <param name="ptc">
        /// A pointer to a <see cref="TIMECAPS"/> structure.
        /// This structure is filled with information about the resolution of the timer device.
        /// </param>
        /// <param name="cbtc">
        /// The size, in bytes, of the <see cref="TIMECAPS"/> structure.
        /// </param>
        /// <returns>
        /// Returns <see cref="MMSYSERR_NOERROR"/> if successful or an error code otherwise.
        /// Possible error codes include the following.
        /// <see cref="MMSYSERR_ERROR"/>: General error code.
        /// <see cref="TIMERR_NOCANDO"/>: The <paramref name="ptc"/> parameter is <see cref="NullRef{TIMECAPS}"/>,
        /// or the <paramref name="cbtc"/> parameter is invalid, or some other error occurred.
        /// </returns>
        [DllImport("Winmm.dll", CharSet = CharSet.Unicode, EntryPoint = "timeGetDevCaps", ExactSpelling = true, SetLastError = true)]
        public static extern MMRESULT timeGetDevCaps([Out] out TIMECAPS ptc, [In] UINT cbtc);

        /// <summary>
        /// <para>
        /// The <see cref="timeEndPeriod"/> function clears a previously set minimum timer resolution.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/timeapi/nf-timeapi-timeendperiod"/>
        /// </para>
        /// </summary>
        /// <param name="uPeriod">
        /// Minimum timer resolution specified in the previous call to the <see cref="timeBeginPeriod"/> function.
        /// </param>
        /// <returns>
        /// Returns <see cref="TIMERR_NOERROR"/> if successful or <see cref="TIMERR_NOCANDO"/>
        /// if the resolution specified in <paramref name="uPeriod"/> is out of range.
        /// </returns>
        /// <remarks>
        /// Call this function immediately after you are finished using timer services.
        /// You must match each call to <see cref="timeBeginPeriod"/> with a call to <see cref="timeEndPeriod"/>,
        /// specifying the same minimum resolution in both calls.
        /// An application can make multiple <see cref="timeBeginPeriod"/> calls as long as each call is matched with a call to <see cref="timeEndPeriod"/>.
        /// </remarks>
        [DllImport("Winmm.dll", CharSet = CharSet.Unicode, EntryPoint = "timeEndPeriod", ExactSpelling = true, SetLastError = true)]
        public static extern MMRESULT timeEndPeriod([In] UINT uPeriod);
#pragma warning restore IDE1006
    }
}
