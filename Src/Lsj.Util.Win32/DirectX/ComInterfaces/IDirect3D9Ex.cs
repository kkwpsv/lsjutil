using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DCREATE;
using static Lsj.Util.Win32.DirectX.Enums.D3DFORMAT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3D9Ex"/> interface (which inherits from <see cref="IDirect3D9"/>)
    /// to create Microsoft Direct3D 9Ex objects and set up the environment.
    /// This interface includes methods for enumerating and retrieving capabilities of the device and is available
    /// when the underlying device implementation is compliant with Windows Vista.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9/nn-d3d9-idirect3d9ex"/>
    /// </para>
    /// </summary>
    public unsafe struct IDirect3D9Ex
    {
        IntPtr* _vTable;

        /// <summary>
        /// Creates a device to represent the display adapter.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number that denotes the display adapter.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// </param>
        /// <param name="DeviceType">
        /// Specifies the type of device.
        /// See <see cref="D3DDEVTYPE"/>.
        /// If the desired device type is not available, the method will fail.
        /// </param>
        /// <param name="hFocusWindow">
        /// The focus window alerts Direct3D when an application switches from foreground mode to background mode.
        /// For full-screen mode, the window specified must be a top-level window.
        /// For windowed mode, this parameter may be <see cref="NULL"/>
        /// only if the <see cref="D3DPRESENT_PARAMETERS.hDeviceWindow"/> member of <paramref name="pPresentationParameters"/> is set to a valid, non-NULL value.
        /// </param>
        /// <param name="BehaviorFlags">
        /// Combination of one or more options (see <see cref="D3DCREATE"/>) that control device creation.
        /// </param>
        /// <param name="pPresentationParameters">
        /// Pointer to a <see cref="D3DPRESENT_PARAMETERS"/> structure, describing the presentation parameters for the device to be created.
        /// If <paramref name="BehaviorFlags"/> specifies <see cref="D3DCREATE_ADAPTERGROUP_DEVICE"/>, this parameter is an array.
        /// Regardless of the number of heads that exist, only one depth/stencil surface is automatically created.
        /// This parameter is both an input and an output parameter. Calling this method may change several members including:
        /// If <see cref="D3DPRESENT_PARAMETERS.BackBufferCount"/>, <see cref="D3DPRESENT_PARAMETERS.BackBufferWidth"/>,
        /// and <see cref="D3DPRESENT_PARAMETERS.BackBufferHeight"/> are 0 before the method is called, they will be changed when the method returns.
        /// If <see cref="D3DPRESENT_PARAMETERS.BackBufferFormat"/> equals <see cref="D3DFMT_UNKNOWN"/> before the method is called, it will be changed when the method returns.
        /// </param>
        /// <param name="pFullscreenDisplayMode">
        /// The display mode for when the device is set to fullscreen. See <see cref="D3DDISPLAYMODEEX"/>.
        /// If <paramref name="BehaviorFlags"/> specifies <see cref="D3DCREATE_ADAPTERGROUP_DEVICE"/>, this parameter is an array.
        /// This parameter must be <see cref="NullRef{D3DDISPLAYMODEEX}"/> for windowed mode.
        /// </param>
        /// <param name="ppReturnedDeviceInterface">
        /// Address of a pointer to the returned <see cref="IDirect3DDevice9Ex"/>, which represents the created device.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> when rendering device along with swapchain buffers are created successfully.
        /// <see cref="D3DERR_DEVICELOST"/> is returned when any error other than invalid caller input is encountered.
        /// </returns>
        public HRESULT CreateDeviceEx([In] UINT Adapter, [In] D3DDEVTYPE DeviceType, [In] HWND hFocusWindow, [In] D3DCREATE BehaviorFlags,
            [In][Out] ref D3DPRESENT_PARAMETERS pPresentationParameters, [In][Out] ref D3DDISPLAYMODEEX pFullscreenDisplayMode,
            [Out] out P<IDirect3DDevice9Ex> ppReturnedDeviceInterface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3DDEVTYPE, HWND, D3DCREATE, ref D3DPRESENT_PARAMETERS, ref D3DDISPLAYMODEEX, out P<IDirect3DDevice9Ex>, HRESULT>)_vTable[20])
                    (thisPtr, Adapter, DeviceType, hFocusWindow, BehaviorFlags, ref pPresentationParameters, ref pFullscreenDisplayMode, out ppReturnedDeviceInterface);
            }
        }
    }
}
