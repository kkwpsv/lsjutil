using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDXGIDevice3"/> interface implements a derived class for DXGI objects that produce image data.
    /// The interface exposes a method to trim graphics memory usage by the DXGI device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgidevice2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="IDXGIDevice3"/> interface is designed for use by DXGI objects that need access to other DXGI objects.
    /// This interface is useful to applications that do not use Direct3D to communicate with DXGI.
    /// The Direct3D create device functions return a Direct3D device object.
    /// This Direct3D device object implements the <see cref="IUnknown"/> interface.
    /// You can query this Direct3D device object for the device's corresponding <see cref="IDXGIDevice1"/> interface.
    /// To retrieve the <see cref="IDXGIDevice1"/> interface of a Direct3D device, use the following code:
    /// <code>
    /// IDXGIDevice1 * pDXGIDevice;
    /// hr = g_pd3dDevice->QueryInterface(__uuidof(IDXGIDevice1), (void**)&amp;pDXGIDevice);
    /// </code>
    /// Windows Phone 8: This API is supported.
    /// </remarks>
    public unsafe struct IDXGIDevice3
    {
        IntPtr* _vTable;

        /// <summary>
        /// Trims the graphics memory allocated by the <see cref="IDXGIDevice3"/> DXGI device on the app's behalf.
        /// For apps that render with DirectX, graphics drivers periodically allocate internal memory buffers in order to speed up subsequent rendering requests.
        /// These memory allocations count against the app's memory usage for PLM and in general lead to increased memory usage by the overall system.
        /// Calling this method does not change the rendering state of the graphics device and it has no effect on rendering operations.
        /// There is a brief performance hit when internal buffers are reallocated during the first rendering operations after the <see cref="Trim"/> call,
        /// therefore apps should only call <see cref="Trim"/> when going idle for a period of time (in response to PLM suspend, for example).
        /// Apps should ensure that they call <see cref="Trim"/> as one of the last D3D operations done before going idle.
        /// Direct3D will normally defer the destruction of D3D objects.
        /// Calling <see cref="Trim"/>, however, forces Direct3D to destroy objects immediately.
        /// For this reason, it is not guaranteed that releasing the final reference on Direct3D objects
        /// after calling <see cref="Trim"/> will cause the object to be destroyed and memory to be deallocated before the app suspends.
        /// Similar to <see cref="ID3D11DeviceContext.Flush"/>, apps should call <see cref="ID3D11DeviceContext.ClearState"/> before calling <see cref="Trim"/>.
        /// <see cref="ID3D11DeviceContext.ClearState"/> clears the Direct3D pipeline bindings,
        /// ensuring that Direct3D does not hold any references to the Direct3D objects you are trying to release.
        /// It is also prudent to release references on middleware before calling <see cref="Trim"/>,
        /// as that middleware may also need to release references to Direct3D objects.
        /// </summary>
        public void Trim()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[17])(thisPtr);
            }
        }
    }
}
