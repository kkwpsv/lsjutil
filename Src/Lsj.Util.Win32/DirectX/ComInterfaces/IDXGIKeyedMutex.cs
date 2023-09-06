using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a keyed mutex, which allows exclusive access to a shared resource that is used by multiple devices.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgikeyedmutex"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="IDXGIFactory1"/> is required to create a resource capable of supporting the <see cref="IDXGIKeyedMutex"/> interface.
    /// An <see cref="IDXGIKeyedMutex"/> should be retrieved for each device sharing a resource.
    /// In Direct3D 10.1, such a resource that is shared between two or more devices is created with the <see cref="D3D10_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> flag.
    /// In Direct3D 11, such a resource that is shared between two or more devices is created with the <see cref="D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> flag.
    /// For information about creating a keyed mutex, see the <see cref="AcquireSync"/> method.
    /// </remarks>
    public unsafe struct IDXGIKeyedMutex
    {
        IntPtr* _vTable;

        /// <summary>
        /// Using a key, acquires exclusive rendering access to a shared resource.
        /// </summary>
        /// <param name="Key">
        /// A value that indicates which device to give access to.
        /// This method will succeed when the device that currently owns the surface calls the <see cref="ReleaseSync"/> method using the same value.
        /// This value can be any <see cref="UINT64"/> value.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// This method will return if the interval elapses, and the keyed mutex has not been released using the specified <paramref name="Key"/>.
        /// If this value is set to zero, the <see cref="AcquireSync"/> method will test to see if the keyed mutex has been released and returns immediately.
        /// If this value is set to <see cref="INFINITE"/>, the time-out interval will never elapse.
        /// </param>
        /// <returns>
        /// Return <see cref="S_OK"/> if successful.
        /// If the owning device attempted to create another keyed mutex on the same shared resource, <see cref="AcquireSync"/> returns <see cref="E_FAIL"/>.
        /// <see cref="AcquireSync"/> can also return the following DWORD constants.
        /// Therefore, you should explicitly check for these constants.
        /// If you only use the <see cref="SUCCEEDED"/> macro on the return value to determine if <see cref="AcquireSync"/> succeeded, you will not catch these constants.
        /// <see cref="WAIT_ABANDONED"/> - The shared surface and keyed mutex are no longer in a consistent state.
        /// If <see cref="AcquireSync"/> returns this value, you should release and recreate both the keyed mutex and the shared surface.
        /// <see cref="WAIT_TIMEOUT"/> - The time-out interval elapsed before the specified key was released.
        /// </returns>
        /// <remarks>
        /// The AcquireSync method creates a lock to a surface that is shared between multiple devices,
        /// allowing only one device to render to a surface at a time.
        /// This method uses a key to determine which device currently has exclusive access to the surface.
        /// When a surface is created using the <see cref="D3D10_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> value of the <see cref="D3D10_RESOURCE_MISC_FLAG"/> enumeration,
        /// you must call the <see cref="AcquireSync"/> method before rendering to the surface.
        /// You must call the <see cref="ReleaseSync"/> method when you are done rendering to a surface.
        /// To acquire a reference to the keyed mutex object of a shared resource,
        /// call the <see cref="IUnknown.QueryInterface"/> method of the resource and pass in the UUID of the <see cref="IDXGIKeyedMutex"/> interface.
        /// For more information about acquiring this reference, see the following code example.
        /// The <see cref="AcquireSync"/> method uses the key as follows, depending on the state of the surface:
        /// On initial creation, the surface is unowned and any device can call the <see cref="AcquireSync"/> method to gain access.
        /// For an unowned device, only a key of 0 will succeed.
        /// Calling the <see cref="AcquireSync"/> method for any other key will stall the calling CPU thread.
        /// If the surface is owned by a device when you call the <see cref="AcquireSync"/> method,
        /// the CPU thread that called the <see cref="AcquireSync"/> method will stall
        /// until the owning device calls the <see cref="ReleaseSync"/> method using the same <paramref name="Key"/>.
        /// If the surface is unowned when you call the <see cref="AcquireSync"/> method
        /// (for example, the last owning device has already called the <see cref="ReleaseSync"/> method),
        /// the <see cref="AcquireSync"/> method will succeed if you specify the same key that was specified
        /// when the <see cref="ReleaseSync"/> method was last called.
        /// Calling the <see cref="AcquireSync"/> method using any other key will cause a stall.
        /// When the owning device calls the <see cref="ReleaseSync"/> method with a particular key,
        /// and more than one device is waiting after calling the <see cref="AcquireSync"/> method using the same key,
        /// any one of the waiting devices could be woken up first.
        /// The order in which devices are woken up is undefined.
        /// A keyed mutex does not support recursive calls to the <see cref="AcquireSync"/> method.
        /// </remarks>
        public HRESULT AcquireSync([In] UINT64 Key, [In] DWORD dwMilliseconds)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT64, DWORD, HRESULT>)_vTable[8])(thisPtr, Key, dwMilliseconds);
            }
        }

        /// <summary>
        /// Using a key, releases exclusive rendering access to a shared resource.
        /// </summary>
        /// <param name="Key">
        /// A value that indicates which device to give access to.
        /// This method succeeds when the device that currently owns the surface calls the <see cref="ReleaseSync"/> method using the same value.
        /// This value can be any <see cref="UINT64"/> value.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful.
        /// If the device attempted to release a keyed mutex that is not valid or owned by the device, <see cref="ReleaseSync"/> returns <see cref="E_FAIL"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="ReleaseSync"/> method releases a lock to a surface that is shared between multiple devices.
        /// This method uses a key to determine which device currently has exclusive access to the surface.
        /// When a surface is created using the <see cref="D3D10_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> value of the <see cref="D3D10_RESOURCE_MISC_FLAG"/> enumeration,
        /// you must call the <see cref="AcquireSync"/> method before rendering to the surface.
        /// You must call the <see cref="ReleaseSync"/> method when you are done rendering to a surface.
        /// After you call the <see cref="ReleaseSync"/> method, the shared resource is unset from the rendering pipeline.
        /// To acquire a reference to the keyed mutex object of a shared resource,
        /// call the <see cref="IUnknown.QueryInterface"/> method of the resource and pass in the UUID of the <see cref="IDXGIKeyedMutex"/> interface.
        /// For more information about acquiring this reference, see the following code example.
        /// </remarks>
        public HRESULT ReleaseSync([In] UINT64 Key)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT64, HRESULT>)_vTable[9])(thisPtr, Key);
            }
        }
    }
}
