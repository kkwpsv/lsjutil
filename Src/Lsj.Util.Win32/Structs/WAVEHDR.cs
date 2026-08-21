using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.WaveHeaderFlags;
using static Lsj.Util.Win32.Winmm;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="WAVEHDR"/> structure defines the header used to identify a waveform-audio buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-wavehdr"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use the <see cref="WHDR_BEGINLOOP"/> and <see cref="WHDR_ENDLOOP"/> flags in the <see cref="dwFlags"/> member
    /// to specify the beginning and ending data blocks for looping.
    /// To loop on a single block, specify both flags for the same block.
    /// Use the <see cref="dwLoops"/> member in the <see cref="WAVEHDR"/> structure for the first block in the loop to specify the number of times to play the loop.
    /// </para>
    /// <para>
    /// The <see cref="lpData"/>, <see cref="dwBufferLength"/>, and <see cref="dwFlags"/> members must be set
    /// before calling the <see cref="waveInPrepareHeader"/> or <see cref="waveOutPrepareHeader"/> function.
    /// (For either function, the <see cref="dwFlags"/> member must be set to zero.)
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WAVEHDR
    {
        /// <summary>
        /// Pointer to the waveform buffer.
        /// </summary>
        public nint lpData;

        /// <summary>
        /// Length, in bytes, of the buffer.
        /// </summary>
        public DWORD dwBufferLength;

        /// <summary>
        /// When the header is used in input, specifies how much data is in the buffer.
        /// </summary>
        public DWORD dwBytesRecorded;

        /// <summary>
        /// User data.
        /// </summary>
        public DWORD_PTR dwUser;

        /// <summary>
        /// <para>
        /// A bitwise OR of zero or more flags.
        /// The following flags are defined:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Name
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WHDR_BEGINLOOP"/>
        /// </term>
        /// <term>
        /// This buffer is the first buffer in a loop. This flag is used only with output buffers.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHDR_DONE"/>
        /// </term>
        /// <term>
        /// Set by the device driver to indicate that it is finished with the buffer and is returning it to the application.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHDR_ENDLOOP"/>
        /// </term>
        /// <term>
        /// This buffer is the last buffer in a loop. This flag is used only with output buffers.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHDR_INQUEUE"/>
        /// </term>
        /// <term>
        /// Set by Windows to indicate that the buffer is queued for playback.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WHDR_PREPARED"/>
        /// </term>
        /// <term>
        /// Set by Windows to indicate that the buffer has been prepared with the <see cref="waveInPrepareHeader"/> or <see cref="waveOutPrepareHeader"/> function.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public WaveHeaderFlags dwFlags;

        /// <summary>
        /// Number of times to play the loop.
        /// This member is used only with output buffers.
        /// </summary>
        public DWORD dwLoops;

        /// <summary>
        /// Reserved.
        /// </summary>
        public P<WAVEHDR> lpNext;

        /// <summary>
        /// Reserved.
        /// </summary>
        public DWORD_PTR reserved;
    }
}
