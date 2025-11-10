using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.MediaFoundation.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.MediaFoundation.GUIDs.MediaFoundationAttributes;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Callback interface for the <see cref="IMFMediaEngine"/> interface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfmediaengine/nn-mfmediaengine-imfmediaenginenotify"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To set the callback pointer on the Media Engine,
    /// set the <see cref="MF_MEDIA_ENGINE_CALLBACK"/> attribute in the <see cref="IMFMediaEngineClassFactory.CreateInstance"/> method.
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "fee7c112-e776-42b5-9bbf-0048524e2bd5", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 3, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFMediaEngineNotify
    {
        IntPtr* _vTable;

        /// <summary>
        /// Notifies the application when a playback event occurs.
        /// </summary>
        /// <param name="event">
        /// A member of the <see cref="MF_MEDIA_ENGINE_EVENT"/> enumeration that specifies the event.
        /// </param>
        /// <param name="param1">
        /// The first event parameter.
        /// The meaning of this parameter depends on the event code.
        /// </param>
        /// <param name="param2">
        /// The second event parameter.
        /// The meaning of this parameter depends on the event code.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT EventNotify([In] MF_MEDIA_ENGINE_EVENT @event, [In] DWORD_PTR param1, [In] DWORD param2)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MF_MEDIA_ENGINE_EVENT, DWORD_PTR, DWORD, HRESULT>)_vTable[3])(thisPtr, @event, param1, param2);
            }
        }
    }
}
