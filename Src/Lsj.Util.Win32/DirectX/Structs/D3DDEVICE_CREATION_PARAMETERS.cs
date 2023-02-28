using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the creation parameters for a device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddevice-creation-parameters"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DDEVICE_CREATION_PARAMETERS
    {
        /// <summary>
        /// Ordinal number that denotes the display adapter.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// Use this ordinal as the Adapter parameter for any of the <see cref="IDirect3D9"/> methods.
        /// Note that different instances of Direct3D 9.0 objects can use different ordinals.
        /// Adapters can enter or leave a system when users, for example,
        /// add or remove monitors from a multiple-monitor system or when they hot-swap a laptop.
        /// Consequently, use this ordinal only in a Direct3D 9.0 instance known to be valid,
        /// that is, either the Direct3D 9.0 that created this <see cref="IDirect3DDevice9"/> interface
        /// or the Direct3D 9.0 returned from <see cref="IDirect3DDevice9.GetDirect3D"/>, as called through this <see cref="IDirect3DDevice9"/> interface.
        /// </summary>
        public UINT AdapterOrdinal;

        /// <summary>
        /// Member of the <see cref="D3DDEVTYPE"/> enumerated type.
        /// Denotes the amount of emulated functionality for this device.
        /// The value of this parameter mirrors the value passed to the <see cref="IDirect3D9.CreateDevice"/> call that created this device.
        /// </summary>
        public D3DDEVTYPE DeviceType;

        /// <summary>
        /// Window handle to which focus belongs for this Direct3D device.
        /// The value of this parameter mirrors the value passed to the <see cref="IDirect3D9.CreateDevice"/> call that created this device.
        /// </summary>
        public HWND hFocusWindow;

        /// <summary>
        /// A combination of one or more <see cref="D3DCREATE"/> constants that control global behavior of the device.
        /// These constants mirror the constants passed to <see cref="IDirect3D9.CreateDevice"/> when the device was created.
        /// </summary>
        public DWORD BehaviorFlags;

    }
}
