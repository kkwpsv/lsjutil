using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DCREATE;
using static Lsj.Util.Win32.DirectX.Enums.D3DFORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DMULTISAMPLE_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENTFLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3DRESOURCETYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3DUSAGE;
using static Lsj.Util.Win32.Enums.WindowMessages;
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

        /// <summary>
        /// Retrieves the current display mode of the adapter.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number that denotes the display adapter to query.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// </param>
        /// <param name="pMode">
        /// Pointer to a <see cref="D3DDISPLAYMODE"/> structure, to be filled with information describing the current adapter's mode.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If <paramref name="Adapter"/> is out of range or <paramref name="pMode"/> is invalid,
        /// this method returns <see cref="D3DERR_INVALIDCALL"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="GetAdapterDisplayMode"/> will not return the correct format when the display is in an extended format,
        /// such as 2:10:10:10. Instead, it returns the format X8R8G8B8.
        /// </remarks>
        public HRESULT GetAdapterDisplayMode([In] UINT Adapter, [In][Out] ref D3DDISPLAYMODE pMode)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, ref D3DDISPLAYMODE, HRESULT>)_vTable[8])(thisPtr, Adapter, ref pMode);
            }
        }

        /// <summary>
        /// Verifies whether a hardware accelerated device type can be used on this adapter.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number denoting the display adapter to enumerate.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// This method returns <see cref="D3DERR_INVALIDCALL"/> when this value equals or exceeds the number of display adapters in the system.
        /// </param>
        /// <param name="DevType">
        /// Member of the <see cref="D3DDEVTYPE"/> enumerated type, indicating the device type to check.
        /// </param>
        /// <param name="AdapterFormat">
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, indicating the format of the adapter display mode
        /// for which the device type is to be checked.
        /// For example, some devices will operate only in 16-bits-per-pixel modes.
        /// </param>
        /// <param name="BackBufferFormat">
        /// Back buffer format.
        /// For more information about formats, see <see cref="D3DFORMAT"/>.
        /// This value must be one of the render-target formats.
        /// You can use <see cref="GetAdapterDisplayMode"/> to obtain the current format.
        /// For windowed applications, the back buffer format does not need to match the display mode format if the hardware supports color conversion.
        /// The set of possible back buffer formats is constrained, but the runtime will allow any valid back buffer format to be presented to any desktop format.
        /// There is the additional requirement that the device be operable in the desktop because devices typically do not operate in 8 bits per pixel modes.
        /// Full-screen applications cannot do color conversion.
        /// <see cref="D3DFMT_UNKNOWN"/> is allowed for windowed mode.
        /// </param>
        /// <param name="bWindowed">
        /// Value indicating whether the device type will be used in full-screen or windowed mode.
        /// If set to <see cref="TRUE"/>, the query is performed for windowed applications; otherwise, this value should be set <see cref="FALSE"/>.
        /// </param>
        /// <returns>
        /// If the device can be used on this adapter, <see cref="D3D_OK"/> is returned.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if Adapter equals or exceeds the number of display adapters in the system.
        /// <see cref="D3DERR_INVALIDCALL"/> is also returned if CheckDeviceType specified a device that does not exist.
        /// <see cref="D3DERR_NOTAVAILABLE"/> is returned if the requested back buffer format is not supported,
        /// or if hardware acceleration is not available for the specified formats.
        /// </returns>
        /// <remarks>
        /// A hal device type requires hardware acceleration.
        /// Applications can use <see cref="CheckDeviceType"/> to determine if the needed hardware and drivers are present to support a hal device.
        /// Full-screen applications should not specify a DisplayFormat that contains an alpha channel.
        /// This will result in a failed call.
        /// Note that an alpha channel can be present in the back buffer but the two display formats must be identical in all other respects.
        /// For example, if <paramref name="AdapterFormat"/> = <see cref="D3DFMT_X1R5G5B5"/>,
        /// valid values for <paramref name="BackBufferFormat"/> include <see cref="D3DFMT_X1R5G5B5"/> and <see cref="D3DFMT_A1R5G5B5"/>
        /// but exclude <see cref="D3DFMT_R5G6B5"/>.
        /// The following code fragment shows how you could use <see cref="CheckDeviceType"/> to test whether a certain device type can be used on this adapter.
        /// <code>
        /// if(SUCCEEDED(pD3Device->CheckDeviceType(D3DADAPTER_DEFAULT,
        ///                                         D3DDEVTYPE_HAL,
        ///                                         DisplayFormat,
        ///                                         BackBufferFormat,
        ///                                         bIsWindowed)))
        /// return S_OK;
        /// // There is no HAL on this adapter using this render-target format.
        /// // Try again, using another format.
        /// </code>
        /// This code returns <see cref="S_OK"/> if the device can be used on the default adapter with the specified surface format.
        /// Using <see cref="CheckDeviceType"/> to test for compatibility between a back buffer that differs from the display format will return appropriate values.
        /// This means that the call will reflect device capabilities.
        /// If the device cannot render to the requested back-buffer format, the call will still return <see cref="D3DERR_NOTAVAILABLE"/>.
        /// If the device can render to the format, but cannot perform the color-converting presentation,
        /// the return value will also be <see cref="D3DERR_NOTAVAILABLE"/>.
        /// Applications can discover hardware support for the presentation itself by calling <see cref="CheckDeviceFormatConversion"/>.
        /// No software emulation for the color-converting presentation itself will be offered.
        /// </remarks>
        public HRESULT CheckDeviceType([In] UINT Adapter, [In] D3DDEVTYPE DevType, [In] D3DFORMAT AdapterFormat,
            [In] D3DFORMAT BackBufferFormat, [In] BOOL bWindowed)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, BOOL, HRESULT>)_vTable[9])
                    (thisPtr, Adapter, DevType, AdapterFormat, BackBufferFormat, bWindowed);
            }
        }

        /// <summary>
        /// Determines whether a surface format is available as a specified resource type and can be used as a texture,
        /// depth-stencil buffer, or render target, or any combination of the three, on a device representing this adapter.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number denoting the display adapter to query.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// This method returns <see cref="D3DERR_INVALIDCALL"/> when this value equals or exceeds the number of display adapters in the system.
        /// </param>
        /// <param name="DeviceType">
        /// Member of the <see cref="D3DDEVTYPE"/> enumerated type, identifying the device type.
        /// </param>
        /// <param name="AdapterFormat">
        /// Member of the <see cref="D3DFORMAT"/> enumerated type, identifying the format of the display mode into which the adapter will be placed.
        /// </param>
        /// <param name="Usage">
        /// Requested usage options for the surface.
        /// Usage options are any combination of <see cref="D3DUSAGE"/> and <see cref="D3DUSAGE_QUERY"/> constants
        /// (only a subset of the <see cref="D3DUSAGE"/> constants are valid for <see cref="CheckDeviceFormat"/>;
        /// see the table on the <see cref="D3DUSAGE"/> page).
        /// </param>
        /// <param name="RType">
        /// Resource type requested for use with the queried format.
        /// Member of <see cref="D3DRESOURCETYPE"/>.
        /// </param>
        /// <param name="CheckFormat">
        /// Format of the surfaces which may be used, as defined by <paramref name="Usage"/>.
        /// Member of <see cref="D3DFORMAT"/>.
        /// </param>
        /// <returns>
        /// If the format is compatible with the specified device for the requested usage, this method returns <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if <paramref name="Adapter"/> equals or exceeds the number of display adapters in the system,
        /// or if <paramref name="DeviceType"/> is unsupported.
        /// <see cref="D3DERR_NOTAVAILABLE"/> is returned if the format is not acceptable to the device for this usage.
        /// </returns>
        /// <remarks>
        /// Here are some examples using <see cref="CheckDeviceFormat"/> to check for hardware support of:
        /// An off-screen plain surface format - Specify <paramref name="Usage"/> = 0 and <paramref name="RType"/> = <see cref="D3DRTYPE_SURFACE"/>.
        /// A depth-stencil format - The following snippet tests for the passed in depth-stencil format:
        /// <code>
        /// BOOL IsDepthFormatExisting(D3DFORMAT DepthFormat, D3DFORMAT AdapterFormat)
        /// {
        ///     HRESULT hr = pD3D->CheckDeviceFormat(D3DADAPTER_DEFAULT,
        ///                                         D3DDEVTYPE_HAL,
        ///                                         AdapterFormat,
        ///                                         D3DUSAGE_DEPTHSTENCIL,
        ///                                         D3DRTYPE_SURFACE,
        ///                                         DepthFormat);
        /// 
        /// return SUCCEEDED(hr);
        /// }
        /// </code>
        /// See Selecting a Device (Direct3D 9) for more detail on the enumeration process.
        /// Can this texture be rendered in a particular format - Given the current display mode,
        /// this example shows how to verify that the texture format is compatible with the specific back-buffer format:
        /// <code>
        /// 
        /// BOOL IsTextureFormatOk( D3DFORMAT TextureFormat, D3DFORMAT AdapterFormat ) 
        /// {
        /// HRESULT hr = pD3D->CheckDeviceFormat( D3DADAPTER_DEFAULT,
        ///                                       D3DDEVTYPE_HAL,
        ///                                       AdapterFormat,
        ///                                       0,
        ///                                       D3DRTYPE_TEXTURE,
        ///                                       TextureFormat);
        /// 
        /// return SUCCEEDED( hr );
        /// }
        /// </code>
        /// Alpha blending in a pixel shader - Set Usage to <see cref="D3DUSAGE_QUERY_POSTPIXELSHADER_BLENDING"/>.
        /// Expect this to fail for all floating-point render targets.
        /// Autogeneration of mipmaps - Set Usage to <see cref="D3DUSAGE_AUTOGENMIPMAP"/>.
        /// If the mipmap automatic generation fails, the application will get a non-mipmapped texture.
        /// Calling this method is considered a hint, so this method can return <see cref="D3DOK_NOAUTOGEN"/> (a valid success code)
        /// if the only thing that fails is the mipmap generation.
        /// For more information about mipmap generation, see Automatic Generation of Mipmaps (Direct3D 9).
        /// When migrating code from Direct3D 9 to Direct3D 10, the Direct3D 10 equivalent to <see cref="CheckDeviceFormat"/>
        /// is <see cref="ID3D10Device.CheckFormatSupport"/>.
        /// </remarks>
        public HRESULT CheckDeviceFormat([In] UINT Adapter, [In] D3DDEVTYPE DeviceType, [In] D3DFORMAT AdapterFormat,
            [In] DWORD Usage, [In] D3DRESOURCETYPE RType, [In] D3DFORMAT CheckFormat)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3DDEVTYPE, D3DFORMAT, DWORD, D3DRESOURCETYPE, D3DFORMAT, HRESULT>)_vTable[10])
                    (thisPtr, Adapter, DeviceType, AdapterFormat, Usage, RType, CheckFormat);
            }
        }

        /// <summary>
        /// Determines if a multisampling technique is available on this device.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number denoting the display adapter to query.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// This method returns <see cref="FALSE"/> when this value equals or exceeds the number of display adapters in the system.
        /// See Remarks.
        /// </param>
        /// <param name="DeviceType">
        /// Member of the <see cref="D3DDEVTYPE"/> enumerated type, identifying the device type.
        /// </param>
        /// <param name="SurfaceFormat">
        /// Member of the <see cref="D3DFORMAT"/> enumerated type that specifies the format of the surface to be multisampled.
        /// For more information, see Remarks.
        /// </param>
        /// <param name="Windowed">
        /// bool value.
        /// Specify <see cref="TRUE"/> to inquire about windowed multisampling,
        /// and specify <see cref="FALSE"/> to inquire about full-screen multisampling.
        /// </param>
        /// <param name="MultiSampleType">
        /// Member of the <see cref="D3DMULTISAMPLE_TYPE"/> enumerated type, identifying the multisampling technique to test.
        /// </param>
        /// <param name="pQualityLevels">
        /// <paramref name="pQualityLevels"/> returns the number of device-specific sampling variations available with the given sample type.
        /// For example, if the returned value is 3, then quality levels 0, 1 and 2 can be used when creating resources with the given sample count.
        /// The meanings of these quality levels are defined by the device manufacturer and cannot be queried through D3D.
        /// For example, for a particular device different quality levels at a fixed sample count might refer to
        /// different spatial layouts of the sample locations or different methods of resolving.
        /// This can be <see cref="NullRef{DWORD}"/> if it is not necessary to return the quality levels.
        /// </param>
        /// <returns>
        /// If the device can perform the specified multisampling method, this method returns <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> is returned if the <paramref name="Adapter"/> or <paramref name="MultiSampleType"/> parameters are invalid.
        /// This method returns <see cref="D3DERR_NOTAVAILABLE"/> if the queried multisampling technique is not supported by this device.
        /// <see cref="D3DERR_INVALIDDEVICE"/> is returned if <paramref name="DeviceType"/> does not apply to this adapter.
        /// </returns>
        /// <remarks>
        /// This method is intended for use with both render-target and depth-stencil surfaces 
        /// because you must create both surfaces multisampled if you want to use them together.
        /// The following code fragment shows how you could use <see cref="CheckDeviceMultiSampleType"/>
        /// to test for devices that support a specific multisampling method.
        /// <code>
        /// 
        /// if(SUCCEEDED(pD3D->CheckDeviceMultiSampleType(pCaps->AdapterOrdinal,
        ///                                               pCaps->DeviceType, BackBufferFormat,
        ///                                               FALSE, D3DMULTISAMPLE_3_SAMPLES, NULL ) ) &amp;&amp;
        ///     SUCCEEDED(pD3D->CheckDeviceMultiSampleType(pCaps->AdapterOrdinal,
        ///                                                pCaps->DeviceType, DepthBufferFormat,
        ///                                                FALSE, D3DMULTISAMPLE_3_SAMPLES, NULL ) ) )
        /// return S_OK;
        /// </code>
        /// The preceding code will return <see cref="S_OK"/> if the device supports
        /// the full-screen <see cref="D3DMULTISAMPLE_3_SAMPLES"/> multisampling method with the surface format.
        /// See the remarks in <see cref="D3DMULTISAMPLE_TYPE"/> for additional information
        /// on working with and setting multisample types and quality levels.
        /// </remarks>
        public HRESULT CheckDeviceMultiSampleType([In] UINT Adapter, [In] D3DDEVTYPE DeviceType, [In] D3DFORMAT SurfaceFormat,
            [In] BOOL Windowed, [In] D3DMULTISAMPLE_TYPE MultiSampleType, [Out] out DWORD pQualityLevels)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3DDEVTYPE, D3DFORMAT, BOOL, D3DMULTISAMPLE_TYPE, out DWORD, HRESULT>)_vTable[11])
                    (thisPtr, Adapter, DeviceType, SurfaceFormat, Windowed, MultiSampleType, out pQualityLevels);
            }
        }

        /// <summary>
        /// Determines whether a depth-stencil format is compatible with a render-target format in a particular display mode.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number denoting the display adapter to query.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// </param>
        /// <param name="DeviceType">
        /// Member of the <see cref="D3DDEVTYPE"/> enumerated type, identifying the device type.
        /// </param>
        /// <param name="AdapterFormat">
        /// Member of the <see cref="D3DFORMAT"/> enumerated type,
        /// identifying the format of the display mode into which the adapter will be placed.
        /// </param>
        /// <param name="RenderTargetFormat">
        /// Member of the <see cref="D3DFORMAT"/> enumerated type,
        /// identifying the format of the render-target surface to be tested.
        /// </param>
        /// <param name="DepthStencilFormat">
        /// Member of the <see cref="D3DFORMAT"/> enumerated type,
        /// identifying the format of the depth-stencil surface to be tested.
        /// </param>
        /// <returns>
        /// If the depth-stencil format is compatible with the render-target format in the display mode, this method returns <see cref="D3D_OK"/>.
        /// <see cref="D3DERR_INVALIDCALL"/> can be returned if one or more of the parameters is invalid.
        /// If a depth-stencil format is not compatible with the render target in the display mode, then this method returns <see cref="D3DERR_NOTAVAILABLE"/>.
        /// </returns>
        /// <remarks>
        /// This method is provided to enable applications to work with hardware requiring that certain depth formats can only work with certain render-target formats.
        /// The behavior of this method has been changed for DirectX 8.1.
        /// This method now pays attention to the D24x8 and D32 depth-stencil formats.
        /// The previous version assumed that these formats would always be usable with 32- or 16-bit render targets.
        /// This method will now return <see cref="D3D_OK"/> for these formats only if the device is capable of mixed-depth operations.
        /// The following code fragment shows how you could use CheckDeviceFormat to validate a depth stencil format.
        /// <code>
        /// BOOL IsDepthFormatOk(D3DFORMAT DepthFormat,
        ///                      D3DFORMAT AdapterFormat,
        ///                      D3DFORMAT BackBufferFormat)
        /// {
        /// 
        ///     // Verify that the depth format exists
        ///     HRESULT hr = pD3D->CheckDeviceFormat(D3DADAPTER_DEFAULT,
        ///                                          D3DDEVTYPE_HAL,
        ///                                          AdapterFormat,
        ///                                          D3DUSAGE_DEPTHSTENCIL,
        ///                                          D3DRTYPE_SURFACE,
        ///                                          DepthFormat);
        /// 
        ///     if(FAILED(hr)) return FALSE;
        ///     
        ///     // Verify that the depth format is compatible
        ///     hr = pD3D->CheckDepthStencilMatch(D3DADAPTER_DEFAULT,
        ///                                       D3DDEVTYPE_HAL,
        ///                                       AdapterFormat,
        ///                                       BackBufferFormat,
        ///                                       DepthFormat);
        ///     
        ///     return SUCCEEDED(hr);
        /// 
        /// }
        /// </code>
        /// The preceding call will return <see cref="FALSE"/> if DepthFormat cannot be used in conjunction with AdapterFormat and BackBufferFormat.
        /// </remarks>
        public HRESULT CheckDepthStencilMatch([In] UINT Adapter, [In] D3DDEVTYPE DeviceType, [In] D3DFORMAT AdapterFormat,
            [In] D3DFORMAT RenderTargetFormat, [In] D3DFORMAT DepthStencilFormat)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, D3DFORMAT, HRESULT>)_vTable[12])
                    (thisPtr, Adapter, DeviceType, AdapterFormat, RenderTargetFormat, DepthStencilFormat);
            }
        }

        /// <summary>
        /// Tests the device to see if it supports conversion from one display format to another.
        /// </summary>
        /// <param name="Adapter">
        /// Display adapter ordinal number.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// This method returns <see cref="D3DERR_INVALIDCALL"/> when this value equals or exceeds the number of display adapters in the system.
        /// </param>
        /// <param name="DeviceType">
        /// Device type.
        /// Member of the <see cref="D3DDEVTYPE"/> enumerated type.
        /// </param>
        /// <param name="SourceFormat">
        /// Source adapter format.
        /// Member of the <see cref="D3DFORMAT"/> enumerated type.
        /// </param>
        /// <param name="TargetFormat">
        /// Target adapter format.
        /// Member of the <see cref="D3DFORMAT"/> enumerated type.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value is <see cref="D3DERR_INVALIDCALL"/>.
        /// The method will return <see cref="D3DERR_NOTAVAILABLE"/> when the hardware does not support conversion between the two formats.
        /// </returns>
        /// <remarks>
        /// Using <see cref="CheckDeviceType"/> to test for compatibility between a back buffer
        /// that differs from the display format will return appropriate values.
        /// This means that the call will reflect device capabilities.
        /// If the device cannot render to the requested back buffer format, the call will still return <see cref="D3DERR_NOTAVAILABLE"/>.
        /// If the device can render to the format, but cannot perform the color-converting presentation,
        /// the return value will also be <see cref="D3DERR_NOTAVAILABLE"/>.
        /// Applications can discover hardware support for the presentation itself by calling <see cref="CheckDeviceFormatConversion"/>.
        /// No software emulation for the color-converting presentation itself will be offered.
        /// <see cref="CheckDeviceFormatConversion"/> can also be used to determine which combinations of source surface formats
        /// and destination surface formats are permissible in calls to <see cref="IDirect3DDevice9.StretchRect"/>.
        /// Color conversion is restricted to the following source and target formats.
        /// The source format must be a FOURCC format or a valid back buffer format.
        /// For a list of these, see FourCC Formats and BackBuffer or Display Formats.
        /// The target format must be one of these unsigned formats:
        /// <see cref="D3DFMT_X1R5G5B5"/>, <see cref="D3DFMT_A1R5G5B5"/>, <see cref="D3DFMT_R5G6B5"/>, <see cref="D3DFMT_R8G8B8"/>,
        /// <see cref="D3DFMT_X8R8G8B8"/>, <see cref="D3DFMT_A8R8G8B8"/>, <see cref="D3DFMT_A2R10G10B10"/>, <see cref="D3DFMT_A16B16G16R16"/>,
        /// <see cref="D3DFMT_A2B10G10R10"/>, <see cref="D3DFMT_A8B8G8R8"/>, <see cref="D3DFMT_X8B8G8R8"/>, <see cref="D3DFMT_A16B16G16R16F"/>,
        /// <see cref="D3DFMT_A32B32G32R32F"/>
        /// </remarks>
        public HRESULT CheckDeviceFormatConversion([In] UINT Adapter, [In] D3DDEVTYPE DeviceType, [In] D3DFORMAT SourceFormat, [In] D3DFORMAT TargetFormat)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3DDEVTYPE, D3DFORMAT, D3DFORMAT, HRESULT>)_vTable[13])
                    (thisPtr, Adapter, DeviceType, SourceFormat, TargetFormat);
            }
        }

        /// <summary>
        /// Retrieves device-specific information about a device.
        /// </summary>
        /// <param name="Adapter">
        /// Ordinal number that denotes the display adapter.
        /// <see cref="D3DADAPTER_DEFAULT"/> is always the primary display adapter.
        /// </param>
        /// <param name="DeviceType">
        /// Member of the <see cref="D3DDEVTYPE"/> enumerated type.
        /// Denotes the device type.
        /// </param>
        /// <param name="pCaps">
        /// Pointer to a <see cref="D3DCAPS9"/> structure to be filled with information describing the capabilities of the device.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following:
        /// <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_INVALIDDEVICE"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>, and <see cref="D3DERR_NOTAVAILABLE"/>.
        /// </returns>
        /// <remarks>
        /// The application should not assume the persistence of vertex processing capabilities across Direct3D device objects.
        /// The particular capabilities that a physical device exposes may depend on parameters supplied to <see cref="CreateDevice"/>.
        /// For example, the capabilities may yield different vertex processing capabilities before and after
        /// creating a Direct3D Device Object with hardware vertex processing enabled.
        /// For more information see the description of <see cref="D3DCAPS9"/>.
        /// </remarks>
        public HRESULT GetDeviceCaps([In] UINT Adapter, [In] D3DDEVTYPE DeviceType, [Out] out D3DCAPS9 pCaps)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3DDEVTYPE, out D3DCAPS9, HRESULT>)_vTable[14])
                    (thisPtr, Adapter, DeviceType, out pCaps);
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
        /// Member of the <see cref="D3DDEVTYPE"/> enumerated type that denotes the desired device type.
        /// If the desired device type is not available, the method will fail.
        /// </param>
        /// <param name="hFocusWindow">
        /// The focus window alerts Direct3D when an application switches from foreground mode to background mode.
        /// See Remarks.
        /// For full-screen mode, the window specified must be a top-level window.
        /// For windowed mode, this parameter may be <see cref="NULL"/> only if the <see cref="D3DPRESENT_PARAMETERS.hDeviceWindow"/> member
        /// of <paramref name="pPresentationParameters"/> is set to a valid, non-NULL value.
        /// </param>
        /// <param name="BehaviorFlags">
        /// Combination of one or more options that control device creation.
        /// For more information, see <see cref="D3DCREATE"/>.
        /// </param>
        /// <param name="pPresentationParameters">
        /// Pointer to a <see cref="D3DPRESENT_PARAMETERS"/> structure, describing the presentation parameters for the device to be created.
        /// If <paramref name="BehaviorFlags"/> specifies <see cref="D3DCREATE_ADAPTERGROUP_DEVICE"/>, <paramref name="pPresentationParameters"/> is an array.
        /// Regardless of the number of heads that exist, only one depth/stencil surface is automatically created.
        /// For Windows 2000 and Windows XP, the full-screen device display refresh rate is set in the following order:
        /// User-specified nonzero ForcedRefreshRate registry key, if supported by the device.
        /// Application-specified nonzero refresh rate value in the presentation parameter.
        /// Refresh rate of the latest desktop, if supported by the device.
        /// 75 hertz if supported by the device.
        /// 60 hertz if supported by the device.
        /// Device default.
        /// An unsupported refresh rate will default to the closest supported refresh rate below it.
        /// For example, if the application specifies 63 hertz, 60 hertz will be used.
        /// There are no supported refresh rates below 57 hertz.
        /// <paramref name="pPresentationParameters"/> is both an input and an output parameter.
        /// Calling this method may change several members including:
        /// If <see cref="D3DPRESENT_PARAMETERS.BackBufferCount"/>, <see cref="D3DPRESENT_PARAMETERS.BackBufferWidth"/>,
        /// and <see cref="D3DPRESENT_PARAMETERS.BackBufferHeight"/> are 0 before the method is called, they will be changed when the method returns.
        /// If <see cref="D3DPRESENT_PARAMETERS.BackBufferFormat"/> equals <see cref="D3DFMT_UNKNOWN"/> before the method is called,
        /// it will be changed when the method returns.
        /// </param>
        /// <param name="ppReturnedDeviceInterface">
        /// Address of a pointer to the returned <see cref="IDirect3DDevice9"/> interface, which represents the created device.
        /// </param>
        /// <returns>
        /// If the method succeeds, the return value is <see cref="D3D_OK"/>.
        /// If the method fails, the return value can be one of the following: <see cref="D3DERR_DEVICELOST"/>,
        /// <see cref="D3DERR_INVALIDCALL"/>, <see cref="D3DERR_NOTAVAILABLE"/>, <see cref="D3DERR_OUTOFVIDEOMEMORY"/>.
        /// </returns>
        /// <remarks>
        /// This method returns a fully working device interface, set to the required display mode (or windowed),
        /// and allocated with the appropriate back buffers.
        /// To begin rendering, the application needs only to create and set a depth buffer
        /// (assuming <see cref="D3DPRESENT_PARAMETERS.EnableAutoDepthStencil"/> is <see cref="FALSE"/> in <see cref="D3DPRESENT_PARAMETERS"/>).
        /// When you create a Direct3D device, you supply two different window parameters:
        /// a focus window (<paramref name="hFocusWindow"/>) and
        /// a device window (the <see cref="D3DPRESENT_PARAMETERS.hDeviceWindow"/> in <see cref="D3DPRESENT_PARAMETERS"/>).
        /// The purpose of each window is:
        /// The focus window alerts Direct3D when an application switches from foreground mode to background mode (via Alt-Tab, a mouse click, or some other method).
        /// A single focus window is shared by each device created by an application.
        /// The device window determines the location and size of the back buffer on screen.
        /// This is used by Direct3D when the back buffer contents are copied to the front buffer during <see cref="IDirect3DDevice9.Present"/>.
        /// This method should not be run during the handling of <see cref="WM_CREATE"/>.
        /// An application should never pass a window handle to Direct3D while handling <see cref="WM_CREATE"/>.
        /// Any call to create, release, or reset the device must be done using the same thread as the window procedure of the focus window.
        /// Note that <see cref="D3DCREATE_HARDWARE_VERTEXPROCESSING"/>, <see cref="D3DCREATE_MIXED_VERTEXPROCESSING"/>,
        /// and <see cref="D3DCREATE_SOFTWARE_VERTEXPROCESSING"/> are mutually exclusive flags,
        /// and at least one of these vertex processing flags must be specified when calling this method.
        /// Back buffers created as part of the device are only lockable
        /// if <see cref="D3DPRESENTFLAG_LOCKABLE_BACKBUFFER"/> is specified in the presentation parameters.
        /// (Multisampled back buffers and depth surfaces are never lockable.)
        /// The methods <see cref="IDirect3DDevice9.Reset"/>, <see cref="IUnknown"/>, and <see cref="IDirect3DDevice9.TestCooperativeLevel"/>
        /// must be called from the same thread that used this method to create a device.
        /// <see cref="D3DFMT_UNKNOWN"/> can be specified for the windowed mode back buffer format
        /// when calling <see cref="CreateDevice"/>, <see cref="IDirect3DDevice9.Reset"/>, and <see cref="IDirect3DDevice9.CreateAdditionalSwapChain"/>.
        /// This means the application does not have to query the current desktop format before calling <see cref="CreateDevice"/> for windowed mode.
        /// For full-screen mode, the back buffer format must be specified.
        /// If you attempt to create a device on a 0x0 sized window, <see cref="CreateDevice"/> will fail.
        /// </remarks>
        public HRESULT CreateDevice([In] UINT Adapter, [In] D3DDEVTYPE DeviceType, [In] HWND hFocusWindow, [In] D3DCREATE BehaviorFlags,
            [In][Out] ref D3DPRESENT_PARAMETERS pPresentationParameters, [Out] out P<IDirect3DDevice9> ppReturnedDeviceInterface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, D3DDEVTYPE, HWND, D3DCREATE, ref D3DPRESENT_PARAMETERS, out P<IDirect3DDevice9>, HRESULT>)_vTable[15])
                    (thisPtr, Adapter, DeviceType, hFocusWindow, BehaviorFlags, ref pPresentationParameters, out ppReturnedDeviceInterface);
            }
        }
    }
}
