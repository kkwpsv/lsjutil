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
        /// <summary>
        /// WAVE_MAPPER
        /// </summary>
        public const uint WAVE_MAPPER = unchecked((uint)-1);

        /// <summary>
        /// CALLBACK_NULL
        /// </summary>
        public const uint CALLBACK_NULL = 0x00000000;

        /// <summary>
        /// CALLBACK_WINDOW
        /// </summary>
        public const uint CALLBACK_WINDOW = 0x00010000;

        /// <summary>
        /// CALLBACK_TASK
        /// </summary>
        public const uint CALLBACK_TASK = 0x00020000;

        /// <summary>
        /// CALLBACK_FUNCTION
        /// </summary>
        public const uint CALLBACK_FUNCTION = 0x00030000;

        /// <summary>
        /// CALLBACK_THREAD
        /// </summary>
        public const uint CALLBACK_THREAD = CALLBACK_TASK;

        /// <summary>
        /// CALLBACK_EVENT
        /// </summary>
        public const uint CALLBACK_EVENT = 0x00050000;

#pragma warning disable IDE1006
        /// <summary>
        /// <para>
        /// The <see cref="timeBeginPeriod"/> function requests a minimum resolution for periodic timers.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timeapi/nf-timeapi-timebeginperiod"/>
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timeapi/nf-timeapi-timegetdevcaps"/>
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/timeapi/nf-timeapi-timeendperiod"/>
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
        /// The <see cref="waveOutGetVolume"/> function retrieves the current volume level of the specified waveform-audio output device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutgetvolume"/>
        /// </para>
        /// </summary>
        /// <param name="hwo">
        /// Handle to an open waveform-audio output device. This parameter can also be a device identifier.
        /// </param>
        /// <param name="pdwVolume">
        /// Pointer to a variable to be filled with the current volume setting.
        /// The low-order word of this location contains the left-channel volume setting,
        /// and the high-order word contains the right-channel setting.
        /// A value of 0xFFFF represents full volume, and a value of 0x0000 is silence.
        /// If a device does not support both left and right volume control,
        /// the low-order word of the specified location contains the mono volume level.
        /// The full 16-bit setting(s) set with the <see cref="waveOutSetVolume"/> function is returned,
        /// regardless of whether the device supports the full 16 bits of volume-level control.
        /// </param>
        /// <returns>
        /// Returns <see cref="MMSYSERR_NOERROR"/> if successful or an error otherwise. Possible error values include the following.
        /// <see cref="MMSYSERR_INVALHANDLE"/>: Specified device handle is invalid.
        /// <see cref="MMSYSERR_NODRIVER"/>: No device driver is present.
        /// <see cref="MMSYSERR_NOMEM"/>: Unable to allocate or lock memory.
        /// <see cref="MMSYSERR_NOTSUPPORTED"/>: Function isn't supported.
        /// </returns>
        /// <remarks>
        /// If a device identifier is used, then the result of the <see cref="waveOutGetVolume"/> call
        /// and the information returned in <paramref name="pdwVolume"/> applies to all instances of the device.
        /// If a device handle is used, then the result and information returned
        /// applies only to the instance of the device referenced by the device handle.
        /// Not all devices support volume changes.
        /// To determine whether the device supports volume control, use the <see cref="WAVECAPS_VOLUME"/> flag
        /// to test the <see cref="WAVEOUTCAPS.dwSupport"/> member of the <see cref="WAVEOUTCAPS"/> structure
        /// (filled by the <see cref="waveOutGetDevCaps"/> function).
        /// To determine whether the device supports left- and right-channel volume control,
        /// use the <see cref="WAVECAPS_LRVOLUME"/> flag to test the <see cref="WAVEOUTCAPS.dwSupport"/> member
        /// of the <see cref="WAVEOUTCAPS"/> structure (filled by <see cref="waveOutGetDevCaps"/>).
        /// Volume settings are interpreted logarithmically.
        /// This means the perceived increase in volume is the same
        /// when increasing the volume level from 0x5000 to 0x6000 as it is from 0x4000 to 0x5000.
        /// </remarks>
        [DllImport("Winmm.dll", CharSet = CharSet.Unicode, EntryPoint = "waveOutGetVolume", ExactSpelling = true, SetLastError = true)]
        public static extern MMRESULT waveOutGetVolume([In] HWAVEOUT hwo, [Out] out DWORD pdwVolume);

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
