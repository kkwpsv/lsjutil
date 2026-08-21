using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.CLSIDs;
using static Lsj.Util.Win32.MediaFoundation.Mfplat;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Creates an instance of the capture engine.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfcaptureengine/nn-mfcaptureengine-imfcaptureengineclassfactory"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To get a pointer to this interface, call the <see cref="CoCreateInstance"/> function
    /// and specify the CLSID equal to <see cref="CLSID_MFCaptureEngineClassFactory"/>.
    /// </para>
    /// <para>
    /// Calling the <see cref="MFCreateCaptureEngine"/> function is equivalent to calling <see cref="CreateInstance"/>.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "8f02d140-56fc-4302-a705-3a97c78be779", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 3, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFCaptureEngineClassFactory
    {
        nint* _vTable;

        /// <summary>
        /// Creates an instance of the capture engine.
        /// </summary>
        /// <param name="clsid">
        /// <para>
        /// The CLSID of the object to create.
        /// </para>
        /// <para>
        /// Currently, this parameter must equal <see cref="CLSID_MFCaptureEngine"/>.
        /// </para>
        /// </param>
        /// <param name="riid">
        /// The IID of the requested interface.
        /// The capture engine supports the <see cref="IMFCaptureEngine"/> interface.
        /// </param>
        /// <param name="ppvObject">
        /// Receives a pointer to the requested interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Before calling this method, call the <see cref="MFStartup"/> function.
        /// </remarks>
        public HRESULT CreateInstance([In] in CLSID clsid, [In] in IID riid, [Out] out LPVOID ppvObject)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in CLSID, in IID, out LPVOID, HRESULT>)_vTable[3])(thisPtr, clsid, riid, out ppvObject);
            }
        }
    }
}
