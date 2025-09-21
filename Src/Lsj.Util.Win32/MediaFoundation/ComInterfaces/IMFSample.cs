using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a media sample, which is a container object for media data.
    /// For video, a sample typically contains one video frame.
    /// For audio data, a sample typically contains multiple audio samples, rather than a single sample of audio.
    /// </para>
    /// <para>
    /// A media sample contains zero or more buffers.
    /// Each buffer manages a block of memory, and is represented by the <see cref="IMFMediaBuffer"/> interface.
    /// A sample can have multiple buffers.
    /// The buffers are kept in an ordered list and accessed by index value.
    /// It is also valid to have an empty sample with no buffers.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/nn-mfobjects-imfsample"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To create a new media sample, call <see cref="MFCreateSample"/>.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// When you call <see cref="IMFAttributes.CopyAllItems"/>, inherited from the <see cref="IMFAttributes"/> interface,
    /// on an <see cref="IMFSample"/>, the sample time, duration, and flags are not copied to the destination sample.
    /// You must copy these values to the new sample manually.
    /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Windows XP with Service Pack 2 (SP2) and later.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
    /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
    [ComInterface(IID = "c40a00f2-b93a-4d80-ae8c-5a1c634f58e4", BeginVTableSlotIndex = 33, EndVTableSlotIndex = 46,
        InheritedFromTypes = [typeof(IUnknown), typeof(IMFAttributes)])]
    public unsafe struct IMFSample
    {
        IntPtr* _vTable;

        /// <summary>
        /// <para>
        /// Retrieves flags associated with the sample.
        /// </para>
        /// <para>
        /// Currently no flags are defined. Instead, metadata for samples is defined using attributes.
        /// To get attributes from a sample, use the <see cref="IMFAttributes"/> interface, which <see cref="IMFSample"/> inherits.
        /// For a list of sample attributes, see Sample Attributes.
        /// </para>
        /// </summary>
        /// <param name="pdwSampleFlags">
        /// Receives the value zero.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT GetSampleFlags([Out] out DWORD pdwSampleFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DWORD, HRESULT>)_vTable[33])(thisPtr, out pdwSampleFlags);
            }
        }

        /// <summary>
        /// <para>
        /// Sets flags associated with the sample.
        /// </para>
        /// <para>
        /// Currently no flags are defined. Instead, metadata for samples is defined using attributes.
        /// To set attributes on a sample, use the <see cref="IMFAttributes"/> interface, which <see cref="IMFSample"/> inherits.
        /// For a list of sample attributes, see Sample Attributes.
        /// </para>
        /// </summary>
        /// <param name="dwSampleFlags">
        /// Reserved; must be zero.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT SetSampleFlags([In] DWORD dwSampleFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, HRESULT>)_vTable[34])(thisPtr, dwSampleFlags);
            }
        }

        /// <summary>
        /// Retrieves the presentation time of the sample.
        /// </summary>
        /// <param name="phnsSampleTime">
        /// Receives the presentation time, in 100-nanosecond units.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_NO_SAMPLE_TIMESTAMP"/>
        /// </term>
        /// <term>
        /// The sample does not have a presentation time.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT GetSampleTime([Out] out LONGLONG phnsSampleTime)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out LONGLONG, HRESULT>)_vTable[35])(thisPtr, out phnsSampleTime);
            }
        }

        /// <summary>
        /// Sets the presentation time of the sample.
        /// </summary>
        /// <param name="hnsSampleTime">
        /// The presentation time, in 100-nanosecond units.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Some pipeline components require samples that have time stamps.
        /// Generally the component that generates the data for the sample also sets the time stamp.
        /// The Media Session might modify the time stamps.
        /// </para>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT SetSampleTime([In] LONGLONG hnsSampleTime)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, LONGLONG, HRESULT>)_vTable[36])(thisPtr, hnsSampleTime);
            }
        }

        /// <summary>
        /// Retrieves the duration of the sample.
        /// </summary>
        /// <param name="phnsSampleDuration">
        /// Receives the duration, in 100-nanosecond units.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_NO_SAMPLE_DURATION"/>
        /// </term>
        /// <term>
        /// The sample does not have a specified duration.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the sample contains more than one buffer, the duration includes the data from all of the buffers.
        /// </para>
        /// <para>
        /// If the retrieved duration is zero, or if the method returns <see cref="MF_E_NO_SAMPLE_DURATION"/>, the duration is unknown.
        /// In that case, it might be possible to calculate the duration from the media type
        /// —for example, by using the video frame rate or the audio sampling rate.
        /// </para>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT GetSampleDuration([Out] out LONGLONG phnsSampleDuration)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out LONGLONG, HRESULT>)_vTable[37])(thisPtr, out phnsSampleDuration);
            }
        }

        /// <summary>
        /// Sets the duration of the sample.
        /// </summary>
        /// <param name="hnsSampleDuration">
        /// Duration of the sample, in 100-nanosecond units.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method succeeds if the duration is negative, although negative durations are probably not valid for most types of data.
        /// It is the responsibility of the object that consumes the sample to validate the duration.
        /// </para>
        /// <para>
        /// The duration can also be zero. This might be valid for some types of data.
        /// For example, the sample might contain stream metadata with no buffers.
        /// </para>
        /// <para>
        /// Until this method is called, the <see cref="GetSampleDuration"/> method returns <see cref="MF_E_NO_SAMPLE_DURATION"/>.
        /// </para>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT SetSampleDuration([In] LONGLONG hnsSampleDuration)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, LONGLONG, HRESULT>)_vTable[38])(thisPtr, hnsSampleDuration);
            }
        }

        /// <summary>
        /// Retrieves the number of buffers in the sample.
        /// </summary>
        /// <param name="pdwBufferCount">
        /// Receives the number of buffers in the sample.
        /// A sample might contain zero buffers.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT GetBufferCount([Out] out DWORD pdwBufferCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DWORD, HRESULT>)_vTable[39])(thisPtr, out pdwBufferCount);
            }
        }

        /// <summary>
        /// <para>
        /// Gets a buffer from the sample, by index.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// In most cases, it is safer to use the <see cref="ConvertToContiguousBuffer"/> method.
        /// If the sample contains more than one buffer, the <see cref="ConvertToContiguousBuffer"/> method replaces them with a single buffer,
        /// copies the original data into that buffer, and returns the new buffer to the caller.
        /// The copy operation occurs at most once.
        /// On subsequent calls, no data is copied.
        /// </para>
        /// </summary>
        /// <param name="dwIndex">
        /// <para>
        /// Index of the buffer.
        /// To find the number of buffers in the sample, call <see cref="GetBufferCount"/>.
        /// Buffers are indexed from zero.
        /// </para>
        /// </param>
        /// <param name="ppBuffer">
        /// <para>
        /// Receives a pointer to the <see cref="IMFMediaBuffer"/> interface.
        /// The caller must release the interface.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// <see cref="NULL"/> pointer argument, or the index is out of range.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A sample might contain more than one buffer.
        /// Use the <see cref="GetBufferByIndex"/> method to enumerate the individual buffers.
        /// </para>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT GetBufferByIndex([In] DWORD dwIndex, [Out] out P<IMFMediaBuffer> ppBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, out P<IMFMediaBuffer>, HRESULT>)_vTable[40])(thisPtr, dwIndex, out ppBuffer);
            }
        }

        /// <summary>
        /// Converts a sample with multiple buffers into a sample with a single buffer.
        /// </summary>
        /// <param name="ppBuffer">
        /// Receives a pointer to the <see cref="IMFMediaBuffer"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_UNEXPECTED"/>
        /// </term>
        /// <term>
        /// The sample does not contain any buffers.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the sample contains more than one buffer, this method copies the data from the original buffers into a new buffer,
        /// and replaces the original buffer list with the new buffer.
        /// The new buffer is returned in the <paramref name="ppBuffer"/> parameter.
        /// </para>
        /// <para>
        /// If the sample contains a single buffer, this method returns a pointer to the original buffer.
        /// In typical use, most samples do not contain multiple buffers.
        /// </para>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT ConvertToContiguousBuffer([Out] out P<IMFMediaBuffer> ppBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IMFMediaBuffer>, HRESULT>)_vTable[41])(thisPtr, out ppBuffer);
            }
        }

        /// <summary>
        /// Adds a buffer to the end of the list of buffers in the sample.
        /// </summary>
        /// <param name="pBuffer">
        /// Pointer to the buffer's <see cref="IMFMediaBuffer"/> interface.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// <see cref="NULL"/> pointer argument.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For uncompressed video data, each buffer should contain a single video frame, and samples should not contain multiple frames.
        /// In general, storing multiple buffers in a sample is discouraged.
        /// </para>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT AddBuffer([In] P<IMFMediaBuffer> pBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IMFMediaBuffer>, HRESULT>)_vTable[42])(thisPtr, pBuffer);
            }
        }

        /// <summary>
        /// Removes a buffer at a specified index from the sample.
        /// </summary>
        /// <param name="dwIndex">
        /// Index of the buffer.
        /// To find the number of buffers in the sample, call <see cref="GetBufferCount"/>.
        /// Buffers are indexed from zero.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT RemoveBufferByIndex([In] DWORD dwIndex)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, HRESULT>)_vTable[43])(thisPtr, dwIndex);
            }
        }

        /// <summary>
        /// Removes all of the buffers from the sample.
        /// </summary>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT RemoveAllBuffers()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[44])(thisPtr);
            }
        }

        /// <summary>
        /// Retrieves the total length of the valid data in all of the buffers in the sample.
        /// The length is calculated as the sum of the values retrieved by the <see cref="IMFMediaBuffer.GetCurrentLength"/> method.
        /// </summary>
        /// <param name="pcbTotalLength">
        /// Receives the total length of the valid data, in bytes.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT GetTotalLength([Out] out DWORD pcbTotalLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DWORD, HRESULT>)_vTable[45])(thisPtr, out pcbTotalLength);
            }
        }

        /// <summary>
        /// Copies the sample data to a buffer.
        /// This method concatenates the valid data from all of the buffers of the sample, in order.
        /// </summary>
        /// <param name="pBuffer">
        /// Pointer to the <see cref="IMFMediaBuffer"/> interface of the destination buffer.
        /// The buffer must be large enough to hold the valid data in the sample.
        /// To get the size of the data in the sample, call <see cref="GetTotalLength"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// NULL pointer argument.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_BUFFERTOOSMALL"/>
        /// </term>
        /// <term>
        /// The buffer is not large enough to contain the data.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT CopyToBuffer([In] P<IMFMediaBuffer> pBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IMFMediaBuffer>, HRESULT>)_vTable[46])(thisPtr, pBuffer);
            }
        }
    }
}
