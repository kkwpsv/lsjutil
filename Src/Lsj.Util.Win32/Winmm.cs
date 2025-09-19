using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.MMRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.WinmmCallbackTypes;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Winmm.dll
    /// </summary>
    public static class Winmm
    {
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
        /// <para>
        /// Call this function immediately before using timer services,
        /// and call the <see cref="timeEndPeriod"/> function immediately after you are finished using the timer services.
        /// </para>
        /// <para>
        /// You must match each call to <see cref="timeBeginPeriod"/> with a call to <see cref="timeEndPeriod"/>,
        /// specifying the same minimum resolution in both calls.
        /// An application can make multiple <see cref="timeBeginPeriod"/> calls as long as each call is matched with a call to <see cref="timeEndPeriod"/>.
        /// </para>
        /// <para>
        /// Prior to Windows 10, version 2004, this function affects a global Windows setting.
        /// For all processes Windows uses the lowest value (that is, highest resolution) requested by any process.
        /// Starting with Windows 10, version 2004, this function no longer affects global timer resolution.
        /// For processes which call this function, Windows uses the lowest value (that is, highest resolution) requested by any process.
        /// For processes which have not called this function, Windows does not guarantee a higher resolution than the default system resolution.
        /// </para>
        /// <para>
        /// Starting with Windows 11, if a window-owning process becomes fully occluded, minimized, or otherwise invisible or inaudible to the end user,
        /// Windows does not guarantee a higher resolution than the default system resolution.
        /// See <see cref="SetProcessInformation"/> for more information on this behavior.
        /// </para>
        /// <para>
        /// Setting a higher resolution can improve the accuracy of time-out intervals in wait functions.
        /// However, it can also reduce overall system performance, because the thread scheduler switches tasks more often.
        /// High resolutions can also prevent the CPU power management system from entering power-saving modes.
        /// Setting a higher resolution does not improve the accuracy of the high-resolution performance counter.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Winmm.dll", CharSet = CharSet.Unicode, EntryPoint = "timeBeginPeriod", ExactSpelling = true)]
        public static extern MMRESULT timeBeginPeriod([In] UINT uPeriod);

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
        /// <para>
        /// Call this function immediately after you are finished using timer services.
        /// </para>
        /// <para>
        /// You must match each call to <see cref="timeBeginPeriod"/> with a call to <see cref="timeEndPeriod"/>,
        /// specifying the same minimum resolution in both calls.
        /// An application can make multiple <see cref="timeBeginPeriod"/> calls as long as each call is matched with a call to <see cref="timeEndPeriod"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Winmm.dll", CharSet = CharSet.Unicode, EntryPoint = "timeEndPeriod", ExactSpelling = true)]
        public static extern MMRESULT timeEndPeriod([In] UINT uPeriod);

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
        /// <para>
        /// Returns <see cref="MMSYSERR_NOERROR"/> if successful or an error code otherwise.
        /// Possible error codes include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="MMSYSERR_ERROR"/>
        /// </term>
        /// <term>
        /// General error code.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="TIMERR_NOCANDO"/>
        /// </term>
        /// <term>
        /// The <paramref name="ptc"/> parameter is <see cref="NULL"/>,
        /// or the <paramref name="cbtc"/> parameter is invalid, or some other error occurred.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Winmm.dll", CharSet = CharSet.Unicode, EntryPoint = "timeGetDevCaps", ExactSpelling = true)]
        public static extern MMRESULT timeGetDevCaps([Out] out TIMECAPS ptc, [In] UINT cbtc);

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
        /// <para>
        /// Pointer to a variable to be filled with the current volume setting.
        /// The low-order word of this location contains the left-channel volume setting, and the high-order word contains the right-channel setting.
        /// A value of 0xFFFF represents full volume, and a value of 0x0000 is silence.
        /// </para>
        /// <para>
        /// If a device does not support both left and right volume control, the low-order word of the specified location contains the mono volume level.
        /// </para>
        /// <para>
        /// The full 16-bit setting(s) set with the <see cref="waveOutSetVolume"/> function is returned,
        /// regardless of whether the device supports the full 16 bits of volume-level control.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="MMSYSERR_NOERROR"/> if successful or an error otherwise.
        /// Possible error values include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="MMSYSERR_INVALHANDLE"/>
        /// </term>
        /// <term>
        /// Specified device handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MMSYSERR_NODRIVER"/>
        /// </term>
        /// <term>
        /// No device driver is present.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MMSYSERR_NOMEM"/>
        /// </term>
        /// <term>
        /// Unable to allocate or lock memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MMSYSERR_NOTSUPPORTED"/>
        /// </term>
        /// <term>
        /// Function isn't supported.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If a device identifier is used, then the result of the <see cref="waveOutGetVolume"/> call
        /// and the information returned in <paramref name="pdwVolume"/> applies to all instances of the device.
        /// If a device handle is used, then the result and information returned
        /// applies only to the instance of the device referenced by the device handle.
        /// </para>
        /// <para>
        /// Not all devices support volume changes.
        /// To determine whether the device supports volume control, use the <see cref="WAVECAPS_VOLUME"/> flag
        /// to test the <see cref="WAVEOUTCAPS.dwSupport"/> member of the <see cref="WAVEOUTCAPS"/> structure
        /// (filled by the <see cref="waveOutGetDevCaps"/> function).
        /// </para>
        /// <para>
        /// To determine whether the device supports left- and right-channel volume control,
        /// use the <see cref="WAVECAPS_LRVOLUME"/> flag to test the <see cref="WAVEOUTCAPS.dwSupport"/> member 
        /// of the <see cref="WAVEOUTCAPS"/> structure (filled by <see cref="waveOutGetDevCaps"/>).
        /// </para>
        /// <para>
        /// Volume settings are interpreted logarithmically.
        /// This means the perceived increase in volume is the same
        /// when increasing the volume level from 0x5000 to 0x6000 as it is from 0x4000 to 0x5000.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Winmm.dll", CharSet = CharSet.Unicode, EntryPoint = "waveOutGetVolume", ExactSpelling = true)]
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
        /// <para>
        /// Identifier of the waveform-audio output device to open.
        /// It can be either a device identifier or a handle of an open waveform-audio input device.
        /// You can also use the following flag instead of a device identifier:
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
        /// <see cref="WAVE_MAPPER"/>
        /// </term>
        /// <term>
        /// The function selects a waveform-audio output device capable of playing the given format.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pwfx">
        /// Pointer to a <see cref="WAVEFORMATEX"/> structure that identifies the format of the waveform-audio data to be sent to the device.
        /// You can free this structure immediately after passing it to <see cref="waveOutOpen"/>.
        /// </param>
        /// <param name="dwCallback">
        /// <para>
        /// Specifies the callback mechanism. The value must be one of the following:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// A pointer to a callback function. For the function signature, see <see cref="waveOutProc"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A handle to a window.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A thread identifier.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A handle to an event.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The value <see cref="NULL"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <paramref name="fdwOpen"/> parameter specifies how the <paramref name="dwCallback"/> parameter is interpreted.
        /// For more information, see Remarks.
        /// </para>
        /// </param>
        /// <param name="dwInstance">
        /// User-instance data passed to the callback mechanism.
        /// This parameter is not used with the window callback mechanism.
        /// </param>
        /// <param name="fdwOpen">
        /// <para>
        /// Flags for opening the device. The following values are defined.
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
        /// <see cref="CALLBACK_EVENT"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwCallback"/> parameter is an event handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CALLBACK_FUNCTION"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwCallback"/> parameter is a callback procedure address.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CALLBACK_NULL"/>
        /// </term>
        /// <term>
        /// No callback mechanism. This is the default setting.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CALLBACK_THREAD"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwCallback"/> parameter is a thread identifier.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CALLBACK_WINDOW"/>
        /// </term>
        /// <term>
        /// The <paramref name="dwCallback"/> parameter is a window handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAVE_ALLOWSYNC"/>
        /// </term>
        /// <term>
        /// If this flag is specified, a synchronous waveform-audio device can be opened.
        /// If this flag is not specified while opening a synchronous driver, the device will fail to open.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAVE_MAPPED_DEFAULT_COMMUNICATION_DEVICE"/>
        /// </term>
        /// <term>
        /// <para>
        /// If this flag is specified and the <paramref name="uDeviceID"/> parameter is <see cref="WAVE_MAPPER"/>,
        /// the function opens the default communication device.
        /// </para>
        /// <para>
        /// This flag applies only when <paramref name="uDeviceID"/> equals <see cref="WAVE_MAPPER"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Requires Windows 7 
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAVE_FORMAT_DIRECT"/>
        /// </term>
        /// <term>
        /// If this flag is specified, the ACM driver does not perform conversions on the audio data.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAVE_FORMAT_QUERY"/>
        /// </term>
        /// <term>
        /// If this flag is specified, <see cref="waveOutOpen"/> queries the device to determine
        /// if it supports the given format, but the device is not actually opened.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAVE_MAPPED"/>
        /// </term>
        /// <term>
        /// If this flag is specified, the <paramref name="uDeviceID"/> parameter specifies a waveform-audio device to be mapped to by the wave mapper.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="MMSYSERR_NOERROR"/> if successful or an error otherwise.
        /// Possible error values include the following.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="MMSYSERR_ALLOCATED"/>
        /// </term>
        /// <term>
        /// Specified resource is already allocated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MMSYSERR_BADDEVICEID"/>
        /// </term>
        /// <term>
        /// Specified device identifier is out of range.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MMSYSERR_NODRIVER"/>
        /// </term>
        /// <term>
        /// No device driver is present.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MMSYSERR_NOMEM"/>
        /// </term>
        /// <term>
        /// Unable to allocate or lock memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAVERR_BADFORMAT"/>
        /// </term>
        /// <term>
        /// Attempted to open with an unsupported waveform-audio format.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WAVERR_SYNC"/>
        /// </term>
        /// <term>
        /// The device is synchronous but <see cref="waveOutOpen"/> was called without using the <see cref="WAVE_ALLOWSYNC"/> flag.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Use the <see cref="waveOutGetNumDevs"/> function to determine the number of waveform-audio output devices present in the system.
        /// If the value specified by the <paramref name="uDeviceID"/> parameter is a device identifier,
        /// it can vary from zero to one less than the number of devices present.
        /// The <see cref="WAVE_MAPPER"/> constant can also be used as a device identifier.
        /// </para>
        /// <para>
        /// The structure pointed to by <paramref name="pwfx"/> can be extended to include type-specific information for certain data formats.
        /// For example, for PCM data, an extra <see cref="UINT"/> is added to specify the number of bits per sample.
        /// Use the <see cref="PCMWAVEFORMAT"/> structure in this case.
        /// For all other waveform-audio formats, use the <see cref="WAVEFORMATEX"/> structure to specify the length of the additional data.
        /// </para>
        /// <para>
        /// If you choose to have a window or thread receive callback information,
        /// the following messages are sent to the window procedure function to indicate the progress of waveform-audio output:
        /// <see cref="MM_WOM_OPEN"/>, <see cref="MM_WOM_CLOSE"/>, and <see cref="MM_WOM_DONE"/>.
        /// </para>
        /// <para>
        /// Callback Mechanism
        /// </para>
        /// <para>
        /// The <paramref name="dwCallback"/> and <paramref name="fdwOpen"/> parameters
        /// specify how the application is notified about the progress of waveform-audio output.
        /// </para>
        /// <para>
        /// If <paramref name="fdwOpen"/> contains the <see cref="CALLBACK_FUNCTION"/> flag,
        /// <paramref name="dwCallback"/> is a pointer to a callback function.
        /// For the function signature, see <see cref="waveOutProc"/>.
        /// The uMsg parameter of the callback indicates the progress of the audio output:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="WOM_OPEN"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WOM_CLOSE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WOM_DONE"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="fdwOpen"/> contains the <see cref="CALLBACK_WINDOW"/> flag, <paramref name="dwCallback"/> is a handle to a window.
        /// The window receives the following messages, indicating the progress:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MM_WOM_OPEN"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MM_WOM_CLOSE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MM_WOM_DONE"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="fdwOpen"/> contains the <see cref="CALLBACK_THREAD"/> flag, <paramref name="dwCallback"/> is a thread identifier.
        /// The thread receives the messages listed previously for <see cref="CALLBACK_WINDOW"/>.
        /// </para>
        /// <para>
        /// If <paramref name="fdwOpen"/> contains the <see cref="CALLBACK_EVENT"/> flag, <paramref name="dwCallback"/> is a handle to an event.
        /// The event is signaled whenever the state of the waveform buffer changes.
        /// The application can use <see cref="WaitForSingleObject"/> or <see cref="WaitForMultipleObjects"/> to wait for the event.
        /// When the event is signaled, you can get the current state of the waveform buffer
        /// by checking the <paramref name="WAVEHDR.dwFlags"/> member of the <see cref="WAVEHDR"/> structure.
        /// (See <see cref="waveOutPrepareHeader"/>.)
        /// </para>
        /// <para>
        /// If <paramref name="fdwOpen"/> contains the <see cref="CALLBACK_NULL"/> flag, <paramref name="dwCallback"/> must be <see cref="NULL"/>.
        /// In that case, no callback mechanism is used.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Winmm.dll", CharSet = CharSet.Unicode, EntryPoint = "waveOutOpen", ExactSpelling = true)]
        public static extern MMRESULT waveOutOpen([Out] out HWAVEOUT phwo, [In] UINT uDeviceID, [In] in WAVEFORMATEX pwfx,
            [In] DWORD_PTR dwCallback, [In] DWORD_PTR dwInstance, [In] DWORD fdwOpen);
    }
}
