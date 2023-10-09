using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The device interface represents a virtual adapter; it is used to create resources.
    /// <see cref="ID3D11Device4"/> adds new methods to those in <see cref="ID3D11Device3"/>,
    /// such as <see cref="RegisterDeviceRemovedEvent"/> and <see cref="UnregisterDeviceRemoved"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11device4"/>
    /// </para>
    /// </summary>
    public unsafe struct ID3D11Device4
    {
        IntPtr* _vTable;

        /// <summary>
        /// Registers the "device removed" event and indicates when a Direct3D device has become removed for any reason,
        /// using an asynchronous notification mechanism.
        /// </summary>
        /// <param name="hEvent">
        /// The handle to the "device removed" event.
        /// </param>
        /// <param name="pdwCookie">
        /// A pointer to information about the "device removed" event,
        /// which can be used in <see cref="UnregisterDeviceRemoved"/> to unregister the event.
        /// </param>
        /// <returns>
        /// See Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// Indicates when a Direct3D device has become removed for any reason,
        /// using an asynchronous notification mechanism, rather than as an <see cref="HRESULT"/> from <see cref="IDXGISwapChain.Present"/>.
        /// The reason for device removal can be retrieved using <see cref="ID3D11Device.GetDeviceRemovedReason"/> after being notified of the occurrence.
        /// Applications register and un-register a Win32 event handle with a particular device.
        /// That event handle will be signaled when the device becomes removed.
        /// A poll into the device's <see cref="ID3D11Device.GetDeviceRemovedReason"/> method indicates that the device is removed.
        /// ISignalableNotifier or SetThreadpoolWait can be used by UWP apps.
        /// When the graphics device is lost, the app or title will receive the graphics event,
        /// so that the app or title knows that its graphics device is no longer valid and it is safe for the app or title to re-create its DirectX devices.
        /// In response to this event, the app or title needs to re-create its rendering device
        /// and pass it into a SetRenderingDevice call on the composition graphics device objects.
        /// After setting this new rendering device, the app or title needs to redraw content of all the pre-existing surfaces
        /// after the composition graphics device's OnRenderingDeviceReplaced event is fired.
        /// This method supports Composition for device loss.
        /// The event is not signaled when it is most ideal to re-create.
        /// So, instead, we recommend iterating through the adapter ordinals and creating the first ordinal that will succeed.
        /// The application can register an event with the device.
        /// The application will be signaled when the device becomes removed.
        /// If the device is already removed, calls to <see cref="RegisterDeviceRemovedEvent"/> will signal the event immediately.
        /// No device-removed error code will be returned from <see cref="RegisterDeviceRemovedEvent"/>.
        /// Each "device removed" event is never signaled, or is signaled only once.
        /// These events are not signaled during device destruction.
        /// These events are unregistered during destruction.
        /// The semantics of <see cref="RegisterDeviceRemovedEvent"/> are similar to <see cref="IDXGIFactory2.RegisterOcclusionStatusEvent"/>.
        /// </remarks>
        public HRESULT RegisterDeviceRemovedEvent([In] HANDLE hEvent, [Out] out DWORD pdwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, out DWORD, HRESULT>)_vTable[63])
                    (thisPtr, hEvent, out pdwCookie);
            }
        }

        /// <summary>
        /// Unregisters the "device removed" event.
        /// </summary>
        /// <param name="dwCookie">
        /// Information about the "device removed" event, retrieved during a successful <see cref="RegisterDeviceRemovedEvent"/> call.
        /// </param>
        /// <remarks>
        /// See <see cref="RegisterDeviceRemovedEvent"/>.
        /// </remarks>
        public void UnregisterDeviceRemoved([In] DWORD dwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DWORD, void>)_vTable[64])(thisPtr, dwCookie);
            }
        }
    }
}
