using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.MediaFoundation.Enums;
using Lsj.Util.Win32.MediaFoundation.Structs;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.MediaFoundation.Enums.MF_MEDIA_ENGINE_EVENT;
using static Lsj.Util.Win32.OleAut32;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables an application to play audio or video files.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/nn-mfmediaengine-imfmediaengine"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The Media Engine implements this interface.
    /// To create an instance of the Media Engine, call <see cref="IMFMediaEngineClassFactory.CreateInstance"/>.
    /// </para>
    /// <para>
    /// This interface is extended with <see cref="IMFMediaEngineEx"/>.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "98a1b0bb-03eb-4935-ae7c-93c1fa0e1c93", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 44, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFMediaEngine
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the most recent error status.
        /// </summary>
        /// <param name="ppError">
        /// Receives either a pointer to the <see cref="IMFMediaError"/> interface, or the value <see cref="NULL"/>.
        /// If the value is non-<see cref="NULL"/>, the caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method returns the last error status, if any, that resulted from loading the media source.
        /// If there has not been an error, <paramref name="ppError"/> receives the value <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// This method corresponds to the <c>error</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// </remarks>
        public HRESULT GetError([Out] out P<IMFMediaError> ppError)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IMFMediaError>, HRESULT>)_vTable[3])(thisPtr, out ppError);
            }
        }

        /// <summary>
        /// Sets the current error code.
        /// </summary>
        /// <param name="error">
        /// The error code, as an <see cref="MF_MEDIA_ENGINE_ERR"/> value.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT SetErrorCode([In] MF_MEDIA_ENGINE_ERR error)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MF_MEDIA_ENGINE_ERR, HRESULT>)_vTable[4])(thisPtr, error);
            }
        }

        /// <summary>
        /// Sets a list of media sources.
        /// </summary>
        /// <param name="pSrcElements">
        /// A pointer to the <see cref="IMFMediaEngineSrcElements"/> interface.
        /// The caller must implement this interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to adding a list of source elements to a media element in HTML5.
        /// </para>
        /// <para>
        /// The Media Engine tries to load each item in the <paramref name="pSrcElements"/> list, until it finds one that loads successfully.
        /// After this method is called, the application can use the <see cref="IMFMediaEngineSrcElements"/> interface to update the list at any time.
        /// To reload the list, call <see cref="Load"/>.
        /// </para>
        /// <para>
        /// This method completes asynchronously.
        /// When the operation starts, the Media Engine sends an <see cref="MF_MEDIA_ENGINE_EVENT_LOADSTART"/> event.
        /// If no errors occur during the <see cref="Load"/> operation, several other events are generated, including the following.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MF_MEDIA_ENGINE_EVENT_LOADEDMETADATA"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_MEDIA_ENGINE_EVENT_LOADEDDATA"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_MEDIA_ENGINE_EVENT_CANPLAY"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_MEDIA_ENGINE_EVENT_CANPLAYTHROUGH"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the Media Engine is unable to load a URL, it sends an <see cref="MF_MEDIA_ENGINE_EVENT_ERROR"/> event.
        /// </para>
        /// <para>
        /// For more information about event handling in the Media Engine, see <see cref="IMFMediaEngineNotify"/>.
        /// </para>
        /// <para>
        /// If the application also calls <see cref="SetSource"/>,
        /// the URL passed to <see cref="SetSource"/> takes precedence over the list given to <see cref="SetSourceElements"/>.
        /// </para>
        /// </remarks>
        public HRESULT SetSourceElements([In] P<IMFMediaEngineSrcElements> pSrcElements)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IMFMediaEngineSrcElements>, HRESULT>)_vTable[5])(thisPtr, pSrcElements);
            }
        }

        /// <summary>
        /// Sets the URL of a media resource.
        /// </summary>
        /// <param name="pUrl">
        /// The URL of the media resource.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to setting the src attribute of the HTMLMediaElement interface in HTML5.
        /// </para>
        /// <para>
        /// The URL specified by this method takes precedence over media resources specified in the <see cref="SetSourceElements"/> method.
        /// To load the URL, call <see cref="Load"/>.
        /// </para>
        /// <para>
        /// This method asynchronously loads the URL.
        /// When the operation starts, the Media Engine sends an <see cref="MF_MEDIA_ENGINE_EVENT_LOADSTART"/> event.
        /// If no errors occur during the <see cref="Load"/> operation, several other events are generated, including the following.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MF_MEDIA_ENGINE_EVENT_LOADEDMETADATA"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_MEDIA_ENGINE_EVENT_LOADEDDATA"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_MEDIA_ENGINE_EVENT_CANPLAY"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_MEDIA_ENGINE_EVENT_CANPLAYTHROUGH"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the Media Engine is unable to load the URL, the Media Engine sends an <see cref="MF_MEDIA_ENGINE_EVENT_ERROR"/> event.
        /// </para>
        /// <para>
        /// For more information about event handling in the Media Engine, see <see cref="IMFMediaEngineNotify"/>.
        /// </para>
        /// </remarks>
        public HRESULT SetSource([In] BSTR pUrl)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, HRESULT>)_vTable[6])(thisPtr, pUrl);
            }
        }

        /// <summary>
        /// Gets the URL of the current media resource, or an empty string if no media resource is present.
        /// </summary>
        /// <param name="ppUrl">
        /// Receives a <see cref="BSTR"/> that contains the URL of the current media resource.
        /// If there is no media resource, <paramref name="ppUrl"/> receives an empty string.
        /// The caller must free the <see cref="BSTR"/> by calling <see cref="SysFreeString"/>.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to the <c>currentSrc</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// <para>
        /// Initially, the current media resource is empty.
        /// It is updated when the Media Engine performs the resource selection algorithm.
        /// </para>
        /// </remarks>
        public HRESULT GetCurrentSource([Out] out BSTR ppUrl)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BSTR, HRESULT>)_vTable[7])(thisPtr, out ppUrl);
            }
        }

        /// <summary>
        /// Gets the current network state of the media engine.
        /// </summary>
        /// <returns>
        /// Returns an <see cref="MF_MEDIA_ENGINE_NETWORK"/> enumeration value.
        /// </returns>
        /// <remarks>
        /// This method corresponds to the <c>networkState</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </remarks>
        public MF_MEDIA_ENGINE_NETWORK GetNetworkState()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MF_MEDIA_ENGINE_NETWORK>)_vTable[8])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the preload flag.
        /// </summary>
        /// <returns>
        /// Returns an <see cref="MF_MEDIA_ENGINE_PRELOAD"/> enumeration value.
        /// </returns>
        /// <remarks>
        /// This method corresponds to the <c>preload</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// The value is a hint to the user-agent whether to preload the media resource.
        /// </remarks>
        public MF_MEDIA_ENGINE_PRELOAD GetPreload()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MF_MEDIA_ENGINE_PRELOAD>)_vTable[9])(thisPtr);
            }
        }

        /// <summary>
        /// Sets the preload flag.
        /// </summary>
        /// <param name="Preload">
        /// An <see cref="MF_MEDIA_ENGINE_PRELOAD"/> value equal to the preload flag.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method corresponds to setting the <c>preload</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// The value is a hint to the user-agent whether to preload the media resource.
        /// </remarks>
        public HRESULT SetPreload([In] MF_MEDIA_ENGINE_PRELOAD Preload)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MF_MEDIA_ENGINE_PRELOAD, HRESULT>)_vTable[10])(thisPtr, Preload);
            }
        }

        /// <summary>
        /// Queries how much resource data the media engine has buffered.
        /// </summary>
        /// <param name="ppBuffered">
        /// Receives a pointer to the <see cref="IMFMediaTimeRange"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to the <c>buffered</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// <para>
        /// The returned <see cref="IMFMediaTimeRange"/> interface represents a list of time ranges.
        /// The time ranges indicate which portions of the media resource have been downloaded.
        /// The time range list can be empty.
        /// </para>
        /// </remarks>
        public HRESULT GetBuffered([Out] out P<IMFMediaTimeRange> ppBuffered)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IMFMediaTimeRange>, HRESULT>)_vTable[11])(thisPtr, out ppBuffered);
            }
        }

        /// <summary>
        /// Loads the current media source.
        /// </summary>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The main purpose of this method is to reload a list of source elements after updating the list.
        /// For more information, see <see cref="SetSourceElements"/>. Otherwise, calling this method is generally not required.
        /// To load a new media source, call <see cref="SetSource"/> or <see cref="SetSourceElements"/>.
        /// </para>
        /// <para>
        /// The <see cref="Load"/> method explicitly invokes the Media Engine's media resource loading algorithm.
        /// Before calling this method, you must set the media resource by calling <see cref="SetSource"/> or <see cref="SetSourceElements"/>.
        /// </para>
        /// <para>
        /// This method completes asynchronously. When the <see cref="Load"/> operation starts,
        /// the Media Engine sends an <see cref="MF_MEDIA_ENGINE_EVENT_LOADSTART"/> event.
        /// If no errors occur during the <see cref="Load"/> operation, several other events are generated, including the following.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="MF_MEDIA_ENGINE_EVENT_LOADEDMETADATA"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_MEDIA_ENGINE_EVENT_LOADEDDATA"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_MEDIA_ENGINE_EVENT_CANPLAY"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="MF_MEDIA_ENGINE_EVENT_CANPLAYTHROUGH"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the Media Engine is unable to load the file, the Media Engine sends an <see cref="MF_MEDIA_ENGINE_EVENT_ERROR"/> event.
        /// </para>
        /// <para>
        /// For more information about event handling in the Media Engine, see <see cref="IMFMediaEngineNotify"/>.
        /// </para>
        /// <para>
        /// This method corresponds to the <c>load</c> method of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// </remarks>
        public HRESULT Load()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[12])(thisPtr);
            }
        }

        /// <summary>
        /// Queries how likely it is that the Media Engine can play a specified type of media resource.
        /// </summary>
        /// <param name="type">
        /// A string that contains a MIME type with an optional codecs parameter, as defined in RFC 4281.
        /// </param>
        /// <param name="pAnswer">
        /// Receives an <see cref="MF_MEDIA_ENGINE_CANPLAY"/> enumeration value.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to the <c>canPlayType</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// <para>
        /// The <c>canPlayType</c> attribute defines the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// "" (empty string)
        /// </term>
        /// <term>
        /// The user-agent cannot play the resource, or the resource type is "application/octet-stream".
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// "probably"
        /// </term>
        /// <term>
        /// The user-agent probably can play the resource.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// "maybe"
        /// </term>
        /// <term>
        /// Neither of the previous values applies.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The value "probably" is used because a MIME type for a media resource is generally not a complete description of the resource.
        /// For example, "video/mp4" specifies an MP4 file with video, but does not describe the codec.
        /// Even with the optional codecs parameter, the MIME type omits some information, such as the actual coded bit rate.
        /// Therefore, it is usually impossible to be certain that playback is possible until the actual media resource is opened.
        /// </para>
        /// </remarks>
        public HRESULT CanPlayType([In] BSTR type, [Out] out MF_MEDIA_ENGINE_CANPLAY pAnswer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, out MF_MEDIA_ENGINE_CANPLAY, HRESULT>)_vTable[13])(thisPtr, type, out pAnswer);
            }
        }

        /// <summary>
        /// Gets the ready state, which indicates whether the current media resource can be rendered.
        /// </summary>
        /// <returns>
        /// Returns an <see cref="MF_MEDIA_ENGINE_READY"/> enumeration value.
        /// </returns>
        /// <remarks>
        /// This method corresponds to the <c>readyState</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </remarks>
        public MF_MEDIA_ENGINE_READY GetReadyState()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MF_MEDIA_ENGINE_READY>)_vTable[14])(thisPtr);
            }
        }

        /// <summary>
        /// Queries whether the Media Engine is currently seeking to a new playback position.
        /// </summary>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the Media Engine is seeking, or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// This method corresponds to the <c>seeking</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </remarks>
        public BOOL IsSeeking()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[15])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the current playback position.
        /// </summary>
        /// <returns>
        /// Returns the playback position, in seconds.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to the <c>currentTime</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// <para>
        /// Note that after you call <see cref="Pause"/>, the time returned by <see cref="GetCurrentTime"/> may not be precisely accurate.
        /// Apps that need a frame-accurate position value, such as media editors,
        /// should call <see cref="IMFMediaEngineEx.FrameStep"/> immediately after calling <see cref="Pause"/> before calling <see cref="GetCurrentTime"/>.
        /// </para>
        /// </remarks>
        public double GetCurrentTime()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, double>)_vTable[16])(thisPtr);
            }
        }

        /// <summary>
        /// Seeks to a new playback position.
        /// </summary>
        /// <param name="seekTime">
        /// The new playback position, in seconds.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to setting the <c>currentTime</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// <para>
        /// The method completes asynchronously.
        /// When the seek operation starts, the Media Engine sends an <see cref="MF_MEDIA_ENGINE_EVENT_SEEKING"/> event.
        /// When the seek operation completes, the Media Engine sends an <see cref="MF_MEDIA_ENGINE_EVENT_SEEKED"/> event.
        /// See <see cref="IMFMediaEngineNotify.EventNotify"/>.
        /// </para>
        /// </remarks>
        public HRESULT SetCurrentTime([In] double seekTime)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, double, HRESULT>)_vTable[17])(thisPtr, seekTime);
            }
        }

        /// <summary>
        /// Gets the initial playback position.
        /// </summary>
        /// <returns>
        /// Returns the initial playback position, in seconds.
        /// </returns>
        /// <remarks>
        /// This method corresponds to the <c>initialTime</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </remarks>
        public double GetStartTime()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, double>)_vTable[18])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the duration of the media resource.
        /// </summary>
        /// <returns>
        /// Returns the duration, in seconds.
        /// If no media data is available, the method returns not-a-number (NaN).
        /// If the duration is unbounded, the method returns an infinite value.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to the <c>duration</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// <para>
        /// If the duration changes, the Media Engine sends an <see cref="MF_MEDIA_ENGINE_EVENT_DURATIONCHANGE"/> event.
        /// See <see cref="IMFMediaEngineNotify.EventNotify"/>.
        /// </para>
        /// </remarks>
        public double GetDuration()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, double>)_vTable[19])(thisPtr);
            }
        }

        /// <summary>
        /// Queries whether playback is currently paused.
        /// </summary>
        /// <returns>
        /// Returns <see cref="TRUE"/> if playback is paused, or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// This method corresponds to the <c>paused</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </remarks>
        public BOOL IsPaused()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[20])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the default playback rate.
        /// </summary>
        /// <returns>
        /// Returns the default playback rate, as a multiple of normal (1×) playback. A negative value indicates reverse playback.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to getting the <c>defaultPlaybackRate</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// <para>
        /// The default playback rate is used for the next call to the <see cref="Play"/> method.
        /// To change the current playback rate, call <see cref="SetPlaybackRate"/>.
        /// </para>
        /// </remarks>
        public double GetDefaultPlaybackRate()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, double>)_vTable[21])(thisPtr);
            }
        }

        /// <summary>
        /// Sets the default playback rate.
        /// </summary>
        /// <param name="Rate">
        /// The default playback rate, as a multiple of normal (1×) playback.
        /// A negative value indicates reverse playback.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method corresponds to getting the <c>defaultPlaybackRate</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </remarks>
        public HRESULT SetDefaultPlaybackRate([In] double Rate)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, double, HRESULT>)_vTable[22])(thisPtr, Rate);
            }
        }

        /// <summary>
        /// Gets the current playback rate.
        /// </summary>
        /// <returns>
        /// Returns the playback rate, as a multiple of normal (1×) playback.
        /// A negative value indicates reverse playback.
        /// </returns>
        /// <remarks>
        /// This method corresponds to getting the <c>playbackRate</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </remarks>
        public double GetPlaybackRate()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, double>)_vTable[23])(thisPtr);
            }
        }

        /// <summary>
        /// Sets the current playback rate.
        /// </summary>
        /// <param name="Rate">
        /// The playback rate, as a multiple of normal (1×) playback.
        /// A negative value indicates reverse playback.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method corresponds to getting the <c>playbackRate</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </remarks>
        public HRESULT SetPlaybackRate([In] double Rate)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, double, HRESULT>)_vTable[24])(thisPtr, Rate);
            }
        }

        /// <summary>
        /// Gets the time ranges that have been rendered.
        /// </summary>
        /// <param name="ppPlayed">
        /// Receives a pointer to the <see cref="IMFMediaTimeRange"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method corresponds to the <c>played</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </remarks>
        public HRESULT GetPlayed([Out] out P<IMFMediaTimeRange> ppPlayed)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IMFMediaTimeRange>, HRESULT>)_vTable[25])(thisPtr, out ppPlayed);
            }
        }

        /// <summary>
        /// Gets the time ranges to which the Media Engine can currently seek.
        /// </summary>
        /// <param name="ppSeekable">
        /// Receives a pointer to the <see cref="IMFMediaTimeRange"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to the <c>seekable</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// <para>
        /// To find out whether the media source supports seeking, call <see cref="IMFMediaEngineEx.GetResourceCharacteristics"/>.
        /// </para>
        /// </remarks>
        public HRESULT GetSeekable([Out] out P<IMFMediaTimeRange> ppSeekable)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IMFMediaTimeRange>, HRESULT>)_vTable[26])(thisPtr, out ppSeekable);
            }
        }

        /// <summary>
        /// Queries whether playback has ended.
        /// </summary>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the direction of playback is forward and playback has reached the end of the media resource.
        /// Returns <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// This method corresponds to the <c>ended</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </remarks>
        public BOOL IsEnded()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[27])(thisPtr);
            }
        }

        /// <summary>
        /// Queries whether the Media Engine automatically begins playback.
        /// </summary>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the Media Engine automatically begins playback, or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to the <c>autoplay</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// <para>
        /// If this method returns <see cref="TRUE"/>, playback begins automatically after the <see cref="Load"/> method completes.
        /// Otherwise, playback begins when the application calls <see cref="Play"/>.
        /// </para>
        /// </remarks>
        public BOOL GetAutoPlay()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[28])(thisPtr);
            }
        }

        /// <summary>
        /// Specifies whether the Media Engine automatically begins playback.
        /// </summary>
        /// <param name="AutoPlay">
        /// If <see cref="TRUE"/>, the Media Engine automatically begins playback after it loads a media source.
        /// Otherwise, playback does not begin until the application calls <see cref="Play"/>.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method corresponds to setting the <c>autoplay</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </remarks>
        public HRESULT SetAutoPlay([In] BOOL AutoPlay)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, HRESULT>)_vTable[29])(thisPtr, AutoPlay);
            }
        }

        /// <summary>
        /// Queries whether the Media Engine will loop playback.
        /// </summary>
        /// <returns>
        /// Returns <see cref="TRUE"/> if looping is enabled, or <see cref="FALSE"/> otherwise.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to getting the <c>loop</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// <para>
        /// If looping is enabled, the Media Engine seeks to the start of the content when playback reaches the end.
        /// </para>
        /// </remarks>
        public BOOL GetLoop()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[30])(thisPtr);
            }
        }

        /// <summary>
        /// Specifies whether the Media Engine loops playback.
        /// </summary>
        /// <param name="Loop">
        /// Specify <see cref="TRUE"/> to enable looping, or <see cref="FALSE"/> to disable looping.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <paramref name="Loop"/> is <see cref="TRUE"/>, playback loops back to the beginning when it reaches the end of the source.
        /// </para>
        /// <para>
        /// This method corresponds to setting the <c>loop</c> attribute of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// </remarks>
        public HRESULT SetLoop([In] BOOL Loop)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, HRESULT>)_vTable[31])(thisPtr, Loop);
            }
        }

        /// <summary>
        /// Starts playback.
        /// </summary>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to the <c>play</c> method of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// <para>
        /// The method completes asynchronously.
        /// When the operation starts, the Media Engine sends an <see cref="MF_MEDIA_ENGINE_EVENT_PLAY"/> event.
        /// When playback is under way, the Media Engine sends an <see cref="MF_MEDIA_ENGINE_EVENT_PLAYING"/> event.
        /// See <see cref="IMFMediaEngineNotify.EventNotify"/>.
        /// </para>
        /// </remarks>
        public HRESULT Play()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[32])(thisPtr);
            }
        }

        /// <summary>
        /// Pauses playback.
        /// </summary>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method corresponds to the <c>pause</c> method of the <c>HTMLMediaElement</c> interface in HTML5.
        /// </para>
        /// <para>
        /// The method completes asynchronously.
        /// When the transition to paused is complete, the Media Engine sends an <see cref="MF_MEDIA_ENGINE_EVENT_PAUSE"/> event.
        /// See <see cref="IMFMediaEngineNotify.EventNotify"/>.
        /// </para>
        /// <para>
        /// Note that after you call <see cref="Pause"/>, the time returned by <see cref="GetCurrentTime"/> may not be precisely accurate.
        /// Apps that need a frame-accurate position value, such as media editors,
        /// should call <see cref="IMFMediaEngineEx.FrameStep"/> immediately after calling <see cref="Pause"/> before calling <see cref="GetCurrentTime"/>.
        /// </para>
        /// </remarks>
        public HRESULT Pause()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[33])(thisPtr);
            }
        }

        /// <summary>
        /// Queries whether the audio is muted.
        /// </summary>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the audio is muted, or <see cref="FALSE"/> otherwise.
        /// </returns>
        public BOOL GetMuted()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[34])(thisPtr);
            }
        }

        /// <summary>
        /// Mutes or unmutes the audio.
        /// </summary>
        /// <param name="Muted">
        /// Specify <see cref="TRUE"/> to mute the audio, or <see cref="FALSE"/> to unmute the audio.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT SetMuted([In] BOOL Muted)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL, HRESULT>)_vTable[35])(thisPtr, Muted);
            }
        }

        /// <summary>
        /// Gets the audio volume level.
        /// </summary>
        /// <returns>
        /// Returns the volume level.
        /// Volume is expressed as an attenuation level, where 0.0 indicates silence and 1.0 indicates full volume (no attenuation).
        /// </returns>
        public double GetVolume()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, double>)_vTable[36])(thisPtr);
            }
        }

        /// <summary>
        /// Sets the audio volume level.
        /// </summary>
        /// <param name="Volume">
        /// The volume level.
        /// Volume is expressed as an attenuation level, where 0.0 indicates silence and 1.0 indicates full volume (no attenuation).
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// When the audio balance changes, the Media Engine sends an <see cref="MF_MEDIA_ENGINE_EVENT_VOLUMECHANGE"/> event.
        /// See <see cref="IMFMediaEngineNotify.EventNotify"/>.
        /// </remarks>
        public HRESULT SetVolume([In] double Volume)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, double, HRESULT>)_vTable[37])(thisPtr, Volume);
            }
        }

        /// <summary>
        /// Queries whether the current media resource contains a video stream.
        /// </summary>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the current media resource contains a video stream.
        /// Returns <see cref="FALSE"/> if there is no media resource or the media resource does not contain a video stream.
        /// </returns>
        public BOOL HasVideo()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[38])(thisPtr);
            }
        }

        /// <summary>
        /// Queries whether the current media resource contains an audio stream.
        /// </summary>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the current media resource contains an audio stream.
        /// Returns <see cref="FALSE"/> if there is no media resource or the media resource does not contain an audio stream.
        /// </returns>
        public BOOL HasAudio()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[39])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the size of the video frame, adjusted for aspect ratio.
        /// </summary>
        /// <param name="cx">
        /// Receives the width in pixels.
        /// </param>
        /// <param name="cy">
        /// Receives the height in pixels.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method adjusts for the correct picture aspect ratio.
        /// For example, if the encoded frame is 720 × 420 and the picture aspect ratio is 4:3,
        /// the method will return a size equal to 640 × 480 pixels.
        /// </remarks>
        public HRESULT GetNativeVideoSize([Out] out DWORD cx, [Out] out DWORD cy)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DWORD, out DWORD, HRESULT>)_vTable[40])(thisPtr, out cx, out cy);
            }
        }

        /// <summary>
        /// Gets the picture aspect ratio of the video stream.
        /// </summary>
        /// <param name="cx">
        /// Receives the x component of the aspect ratio.
        /// </param>
        /// <param name="cy">
        /// Receives the y component of the aspect ratio.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The Media Engine automatically converts the pixel aspect ratio to 1:1 (square pixels).
        /// </remarks>
        public HRESULT GetVideoAspectRatio([Out] out DWORD cx, [Out] out DWORD cy)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DWORD, out DWORD, HRESULT>)_vTable[41])(thisPtr, out cx, out cy);
            }
        }

        /// <summary>
        /// Shuts down the Media Engine and releases the resources it is using.
        /// </summary>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT Shutdown()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[42])(thisPtr);
            }
        }

        /// <summary>
        /// Copies the current video frame to a DXGI surface or WIC bitmap.
        /// </summary>
        /// <param name="pDstSurf">
        /// A pointer to the <see cref="IUnknown"/> interface of the destination surface.
        /// </param>
        /// <param name="pSrc">
        /// A pointer to an <see cref="MFVideoNormalizedRect"/> structure that specifies the source rectangle.
        /// </param>
        /// <param name="pDst">
        /// A pointer to a <see cref="RECT"/> structure that specifies the destination rectangle.
        /// </param>
        /// <param name="pBorderClr">
        /// A pointer to an <see cref="MFARGB"/> structure that specifies the border color.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// In frame-server mode, call this method to blit the video frame to a DXGI or WIC surface.
        /// The application can call this method at any time after the Media Engine loads a video resource.
        /// Typically, however, the application calls <see cref="OnVideoStreamTick"/> first, to determine whether a new frame is available.
        /// If <see cref="OnVideoStreamTick"/> returns <see cref="S_OK"/>, the application then calls <see cref="TransferVideoFrame"/>.
        /// </para>
        /// <para>
        /// The Media Engine scales and letterboxes the video to fit the destination rectangle.
        /// It fills the letterbox area with the border color.
        /// </para>
        /// <para>
        /// For protected content, call the <see cref="IMFMediaEngineProtectedContent.TransferVideoFrame"/> method instead of this method.
        /// </para>
        /// </remarks>
        public HRESULT TransferVideoFrame([In] P<IUnknown> pDstSurf, [In] in MFVideoNormalizedRect pSrc, [In] in RECT pDst, [In] in MFARGB pBorderClr)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IUnknown>, in MFVideoNormalizedRect, in RECT, in MFARGB, HRESULT>)_vTable[43])
                    (thisPtr, pDstSurf, pSrc, pDst, pBorderClr);
            }
        }

        /// <summary>
        /// Queries the Media Engine to find out whether a new video frame is ready.
        /// </summary>
        /// <param name="pPts">
        /// If a new frame is ready, receives the presentation time of the frame.
        /// </param>
        /// <returns>
        /// <para>
        /// This method can return one of these values.
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
        /// <see cref="S_FALSE"/>
        /// </term>
        /// <term>
        /// The method succeeded, but the Media Engine does not have a new frame.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// A new video frame is ready for display.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// In frame-server mode, the application should call this method whenever a vertical blank occurs in the display device.
        /// If the method returns <see cref="S_OK"/>, call <see cref="TransferVideoFrame"/> to blit the frame to the render target.
        /// If the method returns <see cref="S_FALSE"/>, wait for the next vertical blank and call the method again.
        /// </para>
        /// <para>
        /// Do not call this method in rendering mode or audio-only mode.
        /// </para>
        /// </remarks>
        public HRESULT OnVideoStreamTick([Out] out LONGLONG pPts)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out LONGLONG, HRESULT>)_vTable[44])(thisPtr, out pPts);
            }
        }
    }
}
