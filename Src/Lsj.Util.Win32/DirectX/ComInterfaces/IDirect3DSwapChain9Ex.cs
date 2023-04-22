using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENTFLAG;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3DSwapChain9Ex"/> interface to manipulate a swap chain.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9/nn-d3d9-idirect3dswapchain9ex"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// There is always at least one swap chain for each device, known as the implicit swap chain.
    /// However, an additional swap chain for rendering multiple views from the same device can be created
    /// by calling the <see cref="IDirect3DDevice9.CreateAdditionalSwapChain"/> method.
    /// This interface, like all COM interfaces, inherits from the <see cref="IUnknown"/> interface.
    /// The LPDIRECT3DSWAPCHAIN9 and PDIRECT3DSWAPCHAIN9 types are defined as pointers to the <see cref="IDirect3DSwapChain9"/> interface.
    /// <see cref="IDirect3DSwapChain9Ex"/> objects are returned as a pointer to an <see cref="IDirect3DSwapChain9"/> object
    /// when <see cref="IDirect3DDevice9.GetSwapChain"/> is called on an instance of <see cref="IDirect3DDevice9Ex"/>.
    /// The <see cref="IDirect3DSwapChain9Ex"/> interface is obtained by calling <see cref="IUnknown.QueryInterface"/>
    /// on the instance of <see cref="IDirect3DSwapChain9"/> that was returned by <see cref="IDirect3DDevice9.GetSwapChain"/>.
    /// </remarks>
    public unsafe struct IDirect3DSwapChain9Ex
    {
        IntPtr* _vTable;

        /// <summary>
        /// Returns the number of times the swapchain has been processed.
        /// </summary>
        /// <param name="pLastPresentCount">
        /// Pointer to a <see cref="UINT"/> to be filled with the number of times the <see cref="IDirect3DDevice9Ex.PresentEx"/> method has been called.
        /// The count will also be incremented by calling some other APIs such as <see cref="IDirect3DDevice9.SetDialogBoxMode"/>.
        /// </param>
        /// <returns>
        /// <see cref="S_OK"/> the method was successful.
        /// </returns>
        public HRESULT GetLastPresentCount([Out] out UINT pLastPresentCount)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out UINT, HRESULT>)_vTable[10])(thisPtr, out pLastPresentCount);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPresentationStatistics"></param>
        /// <returns></returns>
        public HRESULT GetPresentStats([Out] out D3DPRESENTSTATS pPresentationStatistics)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DPRESENTSTATS, HRESULT>)_vTable[11])(thisPtr, out pPresentationStatistics);
            }
        }

        /// <summary>
        /// Retrieves the display mode's spatial resolution, color resolution, refresh frequency, and rotation settings.
        /// </summary>
        /// <param name="pMode">
        /// Pointer to a <see cref="D3DDISPLAYMODEEX"/> structure containing data about the display mode of the adapter.
        /// As opposed to the display mode of the device, which may not be active if the device does not own full-screen mode.
        /// </param>
        /// <param name="pRotation">
        /// Pointer to a <see cref="D3DDISPLAYROTATION"/> indicating the type of screen rotation the application will do.
        /// The value returned through this pointer is important when the <see cref="D3DPRESENTFLAG_NOAUTOROTATE"/> flag is used;
        /// otherwise, it can be set to <see cref="NullRef{D3DDISPLAYROTATION}"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        public HRESULT GetDisplayModeEx([Out] out D3DDISPLAYMODEEX pMode, [Out] out D3DDISPLAYROTATION pRotation)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D3DDISPLAYMODEEX, out D3DDISPLAYROTATION, HRESULT>)_vTable[12])(thisPtr, out pMode, out pRotation);
            }
        }
    }
}
