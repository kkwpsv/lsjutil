using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.BaseTypes.WaitResult;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_RESOURCE_MISC_FLAG;

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
    /// <para>
    /// The <see cref="IDXGIFactory1"/> is required to create a resource capable of supporting the <see cref="IDXGIKeyedMutex"/> interface.
    /// </para>
    /// <para>
    /// An <see cref="IDXGIKeyedMutex"/> should be retrieved for each device sharing a resource.
    /// In Direct3D 10.1, such a resource that is shared between two or more devices
    /// is created with the <see cref="D3D10_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> flag.
    /// In Direct3D 11, such a resource that is shared between two or more devices
    /// is created with the <see cref="D3D11_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> flag.
    /// </para>
    /// <para>
    /// For information about creating a keyed mutex, see the <see cref="AcquireSync"/> method.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "9d8e1289-d7b3-465f-8126-250e349af85d", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 9,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIDeviceSubObject)])]
    public unsafe struct IDXGIKeyedMutex
    {
        IntPtr* _vTable;

        /// <summary>
        /// Using a key, acquires exclusive rendering access to a shared resource.
        /// </summary>
        /// <param name="Key">
        /// A value that indicates which device to give access to.
        /// This method will succeed when the device that currently owns the surface
        /// calls the <see cref="ReleaseSync"/> method using the same value.
        /// This value can be any <see cref="UINT64"/> value.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// This method will return if the interval elapses,
        /// and the keyed mutex has not been released using the specified <paramref name="Key"/>.
        /// If this value is set to zero, the <see cref="AcquireSync"/> method will test
        /// to see if the keyed mutex has been released and returns immediately.
        /// If this value is set to <see cref="INFINITE"/>, the time-out interval will never elapse.
        /// </param>
        /// <returns>
        /// <para>
        /// Return S_OK if successful.
        /// </para>
        /// <para>
        /// If the owning device attempted to create another keyed mutex on the same shared resource, <see cref="AcquireSync"/> returns E_FAIL.
        /// </para>
        /// <para>
        /// <see cref="AcquireSync"/> can also return the following <see cref="DWORD"/> constants.
        /// Therefore, you should explicitly check for these constants.
        /// If you only use the <see cref="SUCCEEDED"/> macro on the return value
        /// to determine if <see cref="AcquireSync"/> succeeded, you will not catch these constants.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="WAIT_ABANDONED"/> - The shared surface and keyed mutex are no longer in a consistent state.
        /// If <see cref="AcquireSync"/> returns this value, you should release and recreate both the keyed mutex and the shared surface.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="WAIT_TIMEOUT"/> - The time-out interval elapsed before the specified key was released.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="AcquireSync"/> method creates a lock to a surface that is shared between multiple devices,
        /// allowing only one device to render to a surface at a time.
        /// </para>
        /// <para>
        /// This method uses a key to determine which device currently has exclusive access to the surface.
        /// </para>
        /// <para>
        /// When a surface is created using the <see cref="D3D10_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> value
        /// of the <see cref="D3D10_RESOURCE_MISC_FLAG"/> enumeration,
        /// you must call the <see cref="AcquireSync"/> method before rendering to the surface.
        /// You must call the <see cref="ReleaseSync"/> method when you are done rendering to a surface.
        /// </para>
        /// <para>
        /// To acquire a reference to the keyed mutex object of a shared resource,
        /// call the <see cref="IUnknown.QueryInterface"/> method of the resource
        /// and pass in the UUID of the <see cref="IDXGIKeyedMutex"/> interface.
        /// For more information about acquiring this reference, see the following code example.
        /// </para>
        /// <para>
        /// The <see cref="AcquireSync"/> method uses the key as follows, depending on the state of the surface:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// On initial creation, the surface is unowned and any device can call the <see cref="AcquireSync"/> method to gain access.
        /// For an unowned device, only a key of 0 will succeed.
        /// Calling the <see cref="AcquireSync"/> method for any other key will stall the calling CPU thread.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the surface is owned by a device when you call the <see cref="AcquireSync"/> method,
        /// the CPU thread that called the <see cref="AcquireSync"/> method will stall
        /// until the owning device calls the <see cref="ReleaseSync"/> method using the same Key.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the surface is unowned when you call the <see cref="AcquireSync"/> method
        /// (for example, the last owning device has already called the <see cref="ReleaseSync"/> method),
        /// the <see cref="AcquireSync"/> method will succeed if you specify the same key
        /// that was specified when the <see cref="ReleaseSync"/> method was last called.
        /// Calling the <see cref="AcquireSync"/> method using any other key will cause a stall.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// When the owning device calls the <see cref="ReleaseSync"/> method with a particular key,
        /// and more than one device is waiting after calling the <see cref="AcquireSync"/> method using the same key,
        /// any one of the waiting devices could be woken up first.
        /// The order in which devices are woken up is undefined.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A keyed mutex does not support recursive calls to the <see cref="AcquireSync"/> method.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
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
        /// This method succeeds when the device that currently owns the surface
        /// calls the <see cref="ReleaseSync"/> method using the same value.
        /// This value can be any <see cref="UINT64"/> value.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns <see cref="S_OK"/> if successful.
        /// </para>
        /// <para>
        /// If the device attempted to release a keyed mutex that is not valid or owned by the device,
        /// <see cref="ReleaseSync"/> returns <see cref="E_FAIL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="ReleaseSync"/> method releases a lock to a surface that is shared between multiple devices.
        /// This method uses a key to determine which device currently has exclusive access to the surface.
        /// </para>
        /// <para>
        /// When a surface is created using the <see cref="D3D10_RESOURCE_MISC_SHARED_KEYEDMUTEX"/> value
        /// of the <see cref="D3D10_RESOURCE_MISC_FLAG"/> enumeration,
        /// you must call the <see cref="AcquireSync"/> method before rendering to the surface.
        /// You must call the <see cref="ReleaseSync"/> method when you are done rendering to a surface.
        /// </para>
        /// <para>
        /// After you call the <see cref="ReleaseSync"/> method,
        /// the shared resource is unset from the rendering pipeline.
        /// </para>
        /// <para>
        /// To acquire a reference to the keyed mutex object of a shared resource,
        /// call the <see cref="IUnknown.QueryInterface"/> method of the resource
        /// and pass in the UUID of the <see cref="IDXGIKeyedMutex"/> interface.
        /// For more information about acquiring this reference, see the following code example.
        /// </para>
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
