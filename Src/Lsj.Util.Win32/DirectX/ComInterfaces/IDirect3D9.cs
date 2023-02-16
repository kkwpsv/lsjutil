using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Applications use the methods of the <see cref="IDirect3D9"/> interface to create Microsoft Direct3D objects and set up the environment.
    /// This interface includes methods for enumerating and retrieving capabilities of the device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9/nn-d3d9-idirect3d9"/>
    /// </para>
    /// </summary>
    public unsafe struct IDirect3D9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Registers a pluggable software device.
        /// Software devices provide software rasterization enabling applications to access a variety of software rasterizers.
        /// </summary>
        /// <param name="pInitializeFunction">
        /// Pointer to the initialization function for the software device to be registered.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following: <see cref="D3DERR_INVALIDCALL"/>.
        /// The method call is invalid.
        /// For example, a method's parameter may have an invalid value: <see cref="D3DERR_OUTOFVIDEOMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// If the user's computer provides no special hardware acceleration for 3D operations,
        /// your application might emulate 3D hardware in software.
        /// Software rasterization devices emulate the functions of color 3D hardware in software.
        /// A software device runs more slowly than a hal.
        /// However, software devices take advantage of any special instructions supported by the CPU to increase performance.
        /// Instruction sets include the AMD 3DNow! instruction set on some AMD processors
        /// and the MMX instruction set supported by many Intel processors.
        /// Direct3D uses the 3D-Now! instruction set to accelerate transformation and lighting operations
        /// and the MMX instruction set to accelerate rasterization.
        /// Software devices communicate with Direct3D through an interface similar to the hardware device driver interface (DDI).
        /// Software devices are loaded by the application and registered with the <see cref="IDirect3D9"/> object.
        /// Direct3D uses the software device for rendering.
        /// The Direct3D Driver Development Kit (DDK) provides the documentation and headers for developing pluggable software devices.
        /// </remarks>
        public HRESULT RegisterSoftwareDevice([In] IntPtr pInitializeFunction)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, HRESULT>)_vTable[3])(thisPtr, pInitializeFunction);
            }
        }

        /// <summary>
        /// Returns the number of adapters on the system.
        /// </summary>
        /// <returns>
        /// A UINT value that denotes the number of adapters on the system at the time this <see cref="IDirect3D9"/> interface was instantiated.
        /// </returns>
        public UINT GetAdapterCount()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT>)_vTable[4])(thisPtr);
            }
        }

        /// <summary>
        /// Describes the physical display adapters present in the system when the <see cref="IDirect3D9"/> interface was instantiated.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number that denotes the display adapter.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// The minimum value for this parameter is 0, and the maximum value for this parameter
        /// is one less than the value returned by <see cref="GetAdapterCount"/>.
        /// </param>
        /// <param name="Flags">
        /// Flags sets the <see cref="D3DADAPTER_IDENTIFIER9.WHQLLevel"/> member of <see cref="D3DADAPTER_IDENTIFIER9"/>.
        /// Flags can be set to either 0 or <see cref="D3DENUM_WHQL_LEVEL"/>.
        /// If <see cref="D3DENUM_WHQL_LEVEL"/> is specified, this call can connect to the Internet
        /// to download new Microsoft Windows Hardware Quality Labs (WHQL) certificates.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// <see cref="D3DENUM_WHQL_LEVEL"/> is deprecated for Direct3D9Ex running on Windows Vista,
        /// Windows Server 2008, Windows 7, and Windows Server 2008 R2 (or more current operating system).
        /// Any of these operating systems return 1 in the <see cref="D3DADAPTER_IDENTIFIER9.WHQLLevel"/> member
        /// of <see cref="D3DADAPTER_IDENTIFIER9"/> without checking the status of the driver.
        /// </param>
        /// <param name="pIdentifier">
        /// Pointer to a <see cref="D3DADAPTER_IDENTIFIER9"/> structure to be filled with information describing this adapter.
        /// If <paramref name="Adapter"/> is greater than or equal to the number of adapters in the system, this structure will be zeroed.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if <paramref name="Adapter"/> is out of range,
        /// if <paramref name="Flags"/> contains unrecognized parameters,
        /// or if <paramref name="pIdentifier"/> is <see cref="NullRef{D3DADAPTER_IDENTIFIER9}"/> or points to unwritable memory.
        /// </returns>
        public HRESULT GetAdapterIdentifier([In] UINT Adapter, [In] DWORD Flags, [Out] out D3DADAPTER_IDENTIFIER9 pIdentifier)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, DWORD, out D3DADAPTER_IDENTIFIER9, HRESULT>)_vTable[5])(thisPtr, Adapter, Flags, out pIdentifier);
            }
        }

        /// <summary>
        /// Returns the number of display modes available on this adapter.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number that denotes the display adapter.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// </param>
        /// <param name="Format">
        /// Identifies the format of the surface type using <see cref="D3DFORMAT"/>.
        /// Use <see cref="EnumAdapterModes"/> to see the valid formats.
        /// </param>
        /// <returns>
        /// This method returns the number of display modes on this adapter
        /// or zero if <paramref name="Adapter"/> is greater than or equal to the number of adapters on the system.
        /// </returns>
        public UINT GetAdapterModeCount([In] UINT Adapter, [In] D3DFORMAT Format)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3DFORMAT, UINT>)_vTable[6])(thisPtr, Adapter, Format);
            }
        }

        /// <summary>
        /// Queries the device to determine whether the specified adapter supports the requested format and display mode.
        /// This method could be used in a loop to enumerate all the available adapter modes.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number denoting the display adapter to enumerate.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// This method returns <see cref="D3DERR_INVALIDCALL"/> when this value equals or exceeds the number of display adapters in the system.
        /// </param>
        /// <param name="Format">
        /// Allowable pixel formats.
        /// See Remarks.
        /// </param>
        /// <param name="Mode">
        /// Represents the display-mode index which is an unsigned integer between zero
        /// and the value returned by <see cref="GetAdapterModeCount"/> minus one.
        /// </param>
        /// <param name="pMode">
        /// A pointer to the available display mode of type <see cref="D3DDISPLAYMODE"/>.
        /// See Remarks.
        /// </param>
        /// <returns>
        /// If the device can be used on this adapter, <see cref="D3D_OK"/> is returned.
        /// If the Adapter equals or exceeds the number of display adapters in the system, <see cref="D3DERR_INVALIDCALL"/> is returned.
        /// If either surface format is not supported or if hardware acceleration is not available for the specified formats,
        /// <see cref="D3DERR_NOTAVAILABLE"/> is returned.
        /// </returns>
        /// <remarks>
        /// An application supplies a display mode and a format to <see cref="EnumAdapterModes"/> which returns a display mode.
        /// This method could be used in a loop to enumerate all available display modes.
        /// The application specifies a format and the enumeration is restricted to those display modes that exactly match the format (alpha is ignored).
        /// Allowed formats (which are members of <see cref="D3DFORMAT"/>) are as follows:
        /// <see cref="D3DFMT_A1R5G5B5"/>, <see cref="D3DFMT_A2R10G10B10"/>, <see cref="D3DFMT_A8R8G8B8"/>,
        /// <see cref="D3DFMT_R5G6B5"/>, <see cref="D3DFMT_X1R5G5B5"/>, <see cref="D3DFMT_X8R8G8B8"/>
        /// In addition, <see cref="EnumAdapterModes"/> treats pixel formats 565 and 555 as equivalent, and returns the correct version.
        /// The difference comes into play only when the application locks the back buffer
        /// and there is an explicit flag that the application must set in order to accomplish this.
        /// </remarks>
        public HRESULT EnumAdapterModes([In] UINT Adapter, [In] D3DFORMAT Format, [In] UINT Mode, [Out] out D3DDISPLAYMODE pMode)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3DFORMAT, UINT, out D3DDISPLAYMODE, HRESULT>)_vTable[7])(thisPtr, Adapter, Format, Mode, out pMode);
            }
        }
    }
}
