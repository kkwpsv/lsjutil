using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.MMRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Kernel32;
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

        /// <summary>
        /// <para>
        /// The <see cref="waveOutOpen"/> function opens the given waveform-audio output device for playback.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cns/windows/win32/api/mmeapi/nf-mmeapi-waveoutopen"/>
        /// </para>
        /// </summary>
        /// <param name="phwo">
        /// Pointer to a buffer that receives a handle identifying the open waveform-audio output device.
        /// Use the handle to identify the device when calling other waveform-audio output functions.
        /// This parameter might be <see cref="NULL"/> if the <see cref="WAVE_FORMAT_QUERY"/> flag is specified for <paramref name="fdwOpen"/>.
        /// </param>
        /// <param name="uDeviceID">
        /// Identifier of the waveform-audio output device to open. It can be either a device identifier or a handle of an open waveform-audio input device.
        /// You can also use the following flag instead of a device identifier:
        /// <see cref="WAVE_MAPPER"/>: The function selects a waveform-audio output device capable of playing the given format.
        /// </param>
        /// <param name="pwfx">
        /// Pointer to a <see cref="WAVEFORMATEX"/> structure that identifies the format of the waveform-audio data to be sent to the device.
        /// You can free this structure immediately after passing it to <see cref="waveOutOpen"/>.
        /// </param>
        /// <param name="dwCallback">
        /// Specifies the callback mechanism. The value must be one of the following:
        /// A pointer to a callback function. For the function signature, see <see cref="waveOutProc"/>.
        /// A handle to a window.
        /// A thread identifier.
        /// A handle to an event.
        /// The value <see cref="NULL"/>.
        /// The <paramref name="fdwOpen"/> parameter specifies how the <paramref name="dwCallback"/> parameter is interpreted.
        /// For more information, see Remarks.
        /// </param>
        /// <param name="dwInstance">
        /// User-instance data passed to the callback mechanism.
        /// This parameter is not used with the window callback mechanism.
        /// </param>
        /// <param name="fdwOpen">
        /// Flags for opening the device. The following values are defined.
        /// <see cref="CALLBACK_EVENT"/>:
        /// The <paramref name="dwCallback"/> parameter is an event handle.
        /// <see cref="CALLBACK_FUNCTION"/>:
        /// The <paramref name="dwCallback"/> parameter is a callback procedure address.
        /// <see cref="CALLBACK_NULL"/>:
        /// No callback mechanism.This is the default setting.
        /// <see cref="CALLBACK_THREAD"/>:
        /// The <paramref name="dwCallback"/> parameter is a thread identifier.
        /// <see cref="CALLBACK_WINDOW"/>:
        /// The <paramref name="dwCallback"/> parameter is a window handle.
        /// <see cref="WAVE_ALLOWSYNC"/>:
        /// If this flag is specified, a synchronous waveform-audio device can be opened.
        /// If this flag is not specified while opening a synchronous driver, the device will fail to open.
        /// <see cref="WAVE_MAPPED_DEFAULT_COMMUNICATION_DEVICE"/>:
        /// If this flag is specified and the <paramref name="uDeviceID"/> parameter is <see cref="WAVE_MAPPER"/>,
        /// the function opens the default communication device.
        /// This flag applies only when <paramref name="uDeviceID"/> equals <see cref="WAVE_MAPPER"/>.
        /// Note Requires Windows 7
        /// <see cref="WAVE_FORMAT_DIRECT"/>:
        /// If this flag is specified, the ACM driver does not perform conversions on the audio data.
        /// <see cref="WAVE_FORMAT_QUERY"/>:
        /// If this flag is specified, <see cref="waveOutOpen"/> queries the device to determine if it supports the given format,
        /// but the device is not actually opened.
        /// <see cref="WAVE_MAPPED"/>:
        /// If this flag is specified, the <paramref name="uDeviceID"/> parameter specifies a waveform-audio device to be mapped to by the wave mapper.
        /// </param>
        /// <returns>
        /// Returns <see cref="MMSYSERR_NOERROR"/> if successful or an error otherwise.
        /// Possible error values include the following.
        /// <see cref="MMSYSERR_ALLOCATED"/>: Specified resource is already allocated.
        /// <see cref="MMSYSERR_BADDEVICEID"/>: Specified device identifier is out of range.
        /// <see cref="MMSYSERR_NODRIVER"/>: No device driver is present.
        /// <see cref="MMSYSERR_NOMEM"/>: Unable to allocate or lock memory.
        /// <see cref="WAVERR_BADFORMAT"/>: Attempted to open with an unsupported waveform-audio format.
        /// <see cref="WAVERR_SYNC"/>: The device is synchronous but <see cref="waveOutOpen"/> was called without using the <see cref="WAVE_ALLOWSYNC"/> flag.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="waveOutGetNumDevs"/> function to determine the number of waveform-audio output devices present in the system.
        /// If the value specified by the <paramref name="uDeviceID"/> parameter is a device identifier,
        /// it can vary from zero to one less than the number of devices present.
        /// The <see cref="WAVE_MAPPER"/> constant can also be used as a device identifier.
        /// The structure pointed to by pwfx can be extended to include type-specific information for certain data formats.
        /// For example, for PCM data, an extra UINT is added to specify the number of bits per sample.
        /// Use the <see cref="PCMWAVEFORMAT"/> structure in this case.
        /// For all other waveform-audio formats, use the <see cref="WAVEFORMATEX"/> structure to specify the length of the additional data.
        /// If you choose to have a window or thread receive callback information,
        /// the following messages are sent to the window procedure function to indicate the progress of waveform-audio output:
        /// <see cref="MM_WOM_OPEN"/>, <see cref="MM_WOM_CLOSE"/>, and <see cref="MM_WOM_DONE"/>.
        /// Callback Mechanism
        /// The <paramref name="dwCallback"/> and <paramref name="fdwOpen"/> parameters
        /// specify how the application is notified about the progress of waveform-audio output.
        /// If <paramref name="fdwOpen"/>Open contains the <see cref="CALLBACK_FUNCTION"/> flag,
        /// <paramref name="dwCallback"/> is a pointer to a callback function.
        /// For the function signature, see <see cref="waveOutProc"/>.
        /// The uMsg parameter of the callback indicates the progress of the audio output:
        /// <see cref="WOM_OPEN"/>, <see cref="WOM_CLOSE"/>, <see cref="WOM_DONE"/>
        /// If <paramref name="fdwOpen"/> contains the <see cref="CALLBACK_WINDOW"/> flag, <paramref name="dwCallback"/> is a handle to a window.
        /// The window receives the following messages, indicating the progress:
        /// <see cref="MM_WOM_OPEN"/>, <see cref="MM_WOM_CLOSE"/>, <see cref="MM_WOM_DONE"/>
        /// If <paramref name="fdwOpen"/> contains the <see cref="CALLBACK_THREAD"/> flag,
        /// <paramref name="dwCallback"/> is a thread identifier. The thread receives the messages listed previously for <see cref="CALLBACK_WINDOW"/>.
        /// If <paramref name="fdwOpen"/> contains the <see cref="CALLBACK_EVENT"/> flag, <paramref name="dwCallback"/> is a handle to an event.
        /// The event is signaled whenever the state of the waveform buffer changes.
        /// The application can use <see cref="WaitForSingleObject"/> or <see cref="WaitForMultipleObjects"/> to wait for the event.
        /// When the event is signaled, you can get the current state of the waveform buffer
        /// by checking the <see cref="WAVEHDR.dwFlags"/> member of the <see cref="WAVEHDR"/> structure.
        /// (See <see cref="waveOutPrepareHeader"/>.)
        /// If <paramref name="fdwOpen"/> contains the <see cref="CALLBACK_NULL"/> flag, c<paramref name="dwCallback"/> must be <see cref="NULL"/>.
        /// In that case, no callback mechanism is used.
        /// </remarks>
        [DllImport("Winmm.dll", CharSet = CharSet.Unicode, EntryPoint = "waveOutOpen", ExactSpelling = true, SetLastError = true)]
        public static extern MMRESULT waveOutOpen([Out] out HWAVEOUT phwo, [In] UINT uDeviceID, [In] in WAVEFORMATEX pwfx,
            [In] DWORD_PTR dwCallback, [In] DWORD_PTR dwInstance, [In] DWORD fdwOpen);
#pragma warning restore IDE1006
    }
}
