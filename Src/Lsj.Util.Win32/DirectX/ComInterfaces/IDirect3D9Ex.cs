using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DCREATE;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.DirectX.Enums.D3DFORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENTFLAG;
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
    /// <remarks>
    /// <para>
    /// The <see cref="IDirect3D9Ex"/> interface is obtained by calling the <see cref="Direct3DCreate9Ex"/> function.
    /// </para>
    /// <para>
    /// The LPDIRECT3D9EX and PDIRECT3D9EX types are defined as pointers to the <see cref="IDirect3D9Ex"/> interface:
    /// </para>
    /// <code>
    /// typedef struct IDirect3D9Ex *LPDIRECT3D9EX, *PDIRECT3D9EX;
    /// </code>
    /// </remarks>
    [ComInterface(IID = "02177241-69FC-400C-8FF1-93A44DF6861D", BeginVTableSlotIndex = 17, EndVTableSlotIndex = 21,
        InheritedFromTypes = [typeof(IUnknown),typeof(IDirect3D9)])]
    public unsafe struct IDirect3D9Ex
    {
        IntPtr* _vTable;

        /// <summary>
        /// Returns the number of display modes available.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number denoting the display adapter from which to retrieve the display mode count.
        /// </param>
        /// <param name="pFilter">
        /// Specifies the characteristics of the desired display mode.
        /// See <see cref="D3DDISPLAYMODEFILTER"/>.
        /// </param>
        /// <returns>
        /// The number of display modes available.
        /// A return of value zero from this method is an indication that
        /// no such display mode is supported or simply this monitor is no longer available.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Events such as display mode changes on other heads of the same hardware,
        /// monitor change or its connection status change,
        /// and desktop extension/unextension could all affect the number of display mode available.
        /// </para>
        /// <para>
        /// To fullscreen applications, <see cref="S_PRESENT_MODE_CHANGED"/> returned
        /// from <see cref="IDirect3DDevice9Ex.PresentEx"/> or <see cref="IDirect3DDevice9Ex.CheckDeviceState"/>
        /// is the indication of display mode setting failure due to those events.
        /// </para>
        /// <para>
        /// To increase the chance of setting a currently available display mode successfully,
        /// fullscreen applications should try to requery the available display mode list
        /// upon receiving <see cref="S_PRESENT_MODE_CHANGED"/>.
        /// </para>
        /// </remarks>
        public UINT GetAdapterModeCountEx([In] UINT Adapter, [In] in D3DDISPLAYMODEFILTER pFilter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, in D3DDISPLAYMODEFILTER, UINT>)_vTable[17])(thisPtr, Adapter, pFilter);
            }
        }

        /// <summary>
        /// This method returns the actual display mode info based on the given mode index.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number denoting the display adapter to enumerate.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// This method returns <see cref="D3DERR_INVALIDCALL"/>
        /// when this value equals or exceeds the number of display adapters in the system.
        /// </param>
        /// <param name="pFilter">
        /// See <see cref="D3DDISPLAYMODEFILTER"/>.
        /// </param>
        /// <param name="Mode">
        /// Represents the display-mode index which is an unsigned integer
        /// between zero and the value returned by <see cref="IDirect3D9.GetAdapterModeCount"/> minus one.
        /// </param>
        /// <param name="pMode">
        /// A pointer to the available display mode of type <see cref="D3DDISPLAYMODEEX"/>.
        /// </param>
        /// <returns>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the device can be used on this adapter, <see cref="D3D_OK"/> is returned.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the Adapter equals or exceeds the number of display adapters in the system, <see cref="D3DERR_INVALIDCALL"/> is returned.
        /// </description>
        /// </item>
        /// </list>
        /// </returns>
        public HRESULT EnumAdapterModesEx([In] UINT Adapter, [In] in D3DDISPLAYMODEFILTER pFilter, [In] UINT Mode, [Out] out D3DDISPLAYMODEEX pMode)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, in D3DDISPLAYMODEFILTER, UINT, out D3DDISPLAYMODEEX, HRESULT>)_vTable[18])
                    (thisPtr, Adapter, pFilter, Mode, out pMode);
            }
        }

        /// <summary>
        /// Retrieves the current display mode and rotation settings of the adapter.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number that denotes the display adapter to query.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// </param>
        /// <param name="pMode">
        /// Pointer to a <see cref="D3DDISPLAYMODEEX"/> structure containing data about the display mode of the adapter.
        /// As opposed to the display mode of the device, which may not be active if the device does not own full-screen mode.
        /// Can be set to <see cref="NullRef{D3DDISPLAYMODEEX}"/>.
        /// </param>
        /// <param name="pRotation">
        /// Pointer to a <see cref="D3DDISPLAYROTATION"/> structure indicating the type of screen rotation the application will do.
        /// The value returned through this pointer is important when the <see cref="D3DPRESENTFLAG_NOAUTOROTATE"/> flag is used;
        /// otherwise, it can be set to <see cref="NullRef{D3DDISPLAYROTATION}"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// </para>
        /// <para>
        /// If <paramref name="Adapter"/> is out of range or <paramref name="pMode"/> is invalid,
        /// this method returns <see cref="D3DERR_INVALIDCALL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetAdapterDisplayModeEx"/> does not return the correct format
        /// when the display is in an extended format, such as 2:10:10:10.
        /// Instead, it returns the format X8R8G8B8.
        /// </para>
        /// <para>
        /// To windowed applications, a value of <see cref="S_PRESENT_MODE_CHANGED"/> returned
        /// from <see cref="IDirect3DDevice9Ex.PresentEx"/> or <see cref="IDirect3DDevice9Ex.CheckDeviceState"/>
        /// indicates that the display mode changed and that the current display mode might have a different format.
        /// To avoid a color-converting Present blt, windowed applications can optionally get new display mode information
        /// by using this method and adjusting its swap chain format accordingly.
        /// This method returns <see cref="D3DERR_NOTAVAILABLE"/>
        /// if this head is no longer part of the desktop or if the monitor is disconnected.
        /// </para>
        /// </remarks>
        public HRESULT GetAdapterDisplayModeEx([In] UINT Adapter, [In][Out] ref D3DDISPLAYMODEEX pMode, [In][Out] ref D3DDISPLAYROTATION pRotation)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, ref D3DDISPLAYMODEEX, ref D3DDISPLAYROTATION, HRESULT>)_vTable[19])
                    (thisPtr, Adapter, ref pMode, ref pRotation);
            }
        }

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
        /// only if the <see cref="D3DPRESENT_PARAMETERS.hDeviceWindow"/> member
        /// of <paramref name="pPresentationParameters"/> is set to a valid, non-NULL value.
        /// </param>
        /// <param name="BehaviorFlags">
        /// Combination of one or more options (see <see cref="D3DCREATE"/>) that control device creation.
        /// </param>
        /// <param name="pPresentationParameters">
        /// <para>
        /// Pointer to a <see cref="D3DPRESENT_PARAMETERS"/> structure,
        /// describing the presentation parameters for the device to be created.
        /// If <paramref name="BehaviorFlags"/> specifies <see cref="D3DCREATE_ADAPTERGROUP_DEVICE"/>, this parameter is an array.
        /// Regardless of the number of heads that exist, only one depth/stencil surface is automatically created.
        /// </para>
        /// <para>
        /// This parameter is both an input and an output parameter.
        /// Calling this method may change several members including:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If <see cref="D3DPRESENT_PARAMETERS .BackBufferCount"/>, <see cref="D3DPRESENT_PARAMETERS .BackBufferWidth"/>,
        /// and <see cref="D3DPRESENT_PARAMETERS .BackBufferHeight"/> are 0 before the method is called,
        /// they will be changed when the method returns.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <see cref="D3DPRESENT_PARAMETERS.BackBufferFormat"/> equals <see cref="D3DFMT_UNKNOWN"/>
        /// before the method is called, it will be changed when the method returns.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
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

        /// <summary>
        /// This method returns a unique identifier for the adapter that is specific to the adapter hardware.
        /// Applications can use this identifier to define robust mappings across various APIs (Direct3D 9, DXGI).
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number denoting the display adapter from which to retrieve the LUID.
        /// </param>
        /// <param name="pLUID">
        /// A unique identifier for the given adapter.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetAdapterLUID([In] UINT Adapter, [Out] out LUID pLUID)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out LUID, HRESULT>)_vTable[21])(thisPtr, Adapter, out pLUID);
            }
        }
    }
}
