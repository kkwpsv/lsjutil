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
    /// Callback interface to receive data from the capture engine.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfcaptureengine/nn-mfcaptureengine-imfcaptureengineonsamplecallback"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To set the callback interface, call one of the following methods.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="IMFCapturePhotoSink.SetSampleCallback"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="IMFCapturePreviewSink.SetSampleCallback"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="IMFCaptureRecordSink.SetSampleCallback"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "52150b82-ab39-4467-980f-e48bf0822ecd", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 3, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFCaptureEngineOnSampleCallback
    {
        nint* _vTable;

        /// <summary>
        /// Called when the capture sink receives a sample.
        /// </summary>
        /// <param name="pSample">
        /// A pointer to the <see cref="IMFSample"/> interface.
        /// Use this interface to get the time stamp, duration, and stream data.
        /// For more information, see Media Samples.
        /// This parameter can be <see cref="NULL"/>,
        /// so make sure to check for a <see cref="NULL"/> value before you dereference the pointer.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT OnSample([In] P<IMFSample> pSample)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IMFSample>, HRESULT>)_vTable[3])(thisPtr, pSample);
            }
        }
    }
}
