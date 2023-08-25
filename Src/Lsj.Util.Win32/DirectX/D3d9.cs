using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// D3d9.dll
    /// </summary>
    public static partial class D3d9
    {
        /// <summary>
        /// D3D_SDK_VERSION
        /// </summary>
        public const uint D3D_SDK_VERSION = 32;

        /// <summary>
        /// <para>
        /// Create an <see cref="IDirect3D9"/> object and return an interface to it.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d9/"/>
        /// </para>
        /// </summary>
        /// <param name="SDKVersion">
        /// The value of this parameter should be <see cref="D3D_SDK_VERSION"/>.
        /// See Remarks.
        /// </param>
        /// <returns>
        /// If successful, this function returns a pointer to an <see cref="IDirect3D9"/> interface; otherwise, a NULL pointer is returned.
        /// </returns>
        /// <remarks>
        /// The Direct3D object is the first Direct3D COM object that your graphical application needs to create
        /// and the last object that your application needs to release.
        /// Functions for enumerating and retrieving capabilities of a device are accessible through the Direct3D object.
        /// This enables applications to select devices without creating them.
        /// Create an IDirect3D9 object as shown here:
        /// <code>
        /// LPDIRECT3D9 g_pD3D = NULL;
        /// if( NULL == (g_pD3D = Direct3DCreate9(D3D_SDK_VERSION)))
        ///     return E_FAIL;
        /// </code>
        /// The IDirect3D9 interface supports enumeration of active display adapters and allows the creation of <see cref="IDirect3DDevice9"/> objects.
        /// If the user dynamically adds adapters (either by adding devices to the desktop, or by hot-docking a laptop),
        /// those devices will not be included in the enumeration.
        /// Creating a new <see cref="IDirect3D9"/> interface will expose the new devices.
        /// <see cref="D3D_SDK_VERSION"/> is passed to this function to ensure that the header files against
        /// which an application is compiled match the version of the runtime DLL's that are installed on the machine.
        /// <see cref="D3D_SDK_VERSION"/> is only changed in the runtime when a header change (or other code change)
        /// would require an application to be rebuilt.
        /// If this function fails, it indicates that the header file version does not match the runtime DLL version.
        /// </remarks>
        [DllImport("D3d9.dll", CharSet = CharSet.Unicode, EntryPoint = "Direct3DCreate9", ExactSpelling = true)]
        public static extern P<IDirect3D9> Direct3DCreate9([In] UINT SDKVersion);

        /// <summary>
        /// <para>
        /// Creates an <see cref="IDirect3D9Ex"/> object and returns an interface to it.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/zh-cn/windows/win32/api/d3d9/nf-d3d9-direct3dcreate9ex"/>
        /// </para>
        /// </summary>
        /// <param name="SDKVersion">
        /// The value of this parameter should be <see cref="D3D_SDK_VERSION"/>.
        /// See Remarks.
        /// </param>
        /// <param name="unnamedParam2">
        /// Address of a pointer to an <see cref="IDirect3D9Ex"/> interface, representing the created <see cref="IDirect3D9Ex"/> object.
        /// If the function fails, NULL is inserted here.
        /// </param>
        /// <returns>
        /// <see cref="D3DERR_NOTAVAILABLE"/> if Direct3DEx features are not supported (no WDDM driver is installed) 
        /// or if the <paramref name="SDKVersion"/> does not match the version of the DLL.
        /// <see cref="E_OUTOFMEMORY"/> if out-of-memory conditions are detected when creating the enumerator object.
        /// <see cref="S_OK"/> if the creation of the enumerator object is successful.
        /// </returns>
        /// <remarks>
        /// The <see cref="IDirect3D9Ex"/> object is the first object that the application creates and the last object that the application releases.
        /// Functions for enumerating and retrieving capabilities of a device are accessible through the <see cref="IDirect3D9Ex"/> object.
        /// This enables applications to select devices without creating them.
        /// The <see cref="IDirect3D9Ex"/> interface supports enumeration of active display adapters and allows the creation of <see cref="IDirect3DDevice9Ex"/> objects.
        /// If the user dynamically adds adapters (either by adding devices to the desktop, or by hot-docking a laptop),
        /// these devices are not included in the enumeration.
        /// Creating a new <see cref="IDirect3D9Ex"/> interface will expose the new devices.
        /// Pass the <see cref="D3D_SDK_VERSION"/> flag to this function to ensure that header files
        /// used in the compiled application match the version of the installed runtime DLLs.
        /// <see cref="D3D_SDK_VERSION"/> is changed in the runtime only when a header or another code change would require rebuilding the application.
        /// If this function fails, it indicates that the versions of the header file and the runtime DLL do not match.
        /// Note
        /// <see cref="Direct3DCreate9Ex"/> is supported only in Windows Vista, Windows Server 2008, and Windows 7.
        /// Earlier versions of the D3D9.dll library do not include Direct3D9Ex and <see cref="Direct3DCreate9Ex"/>.
        /// </remarks>
        [DllImport("D3d9.dll", CharSet = CharSet.Unicode, EntryPoint = "Direct3DCreate9Ex", ExactSpelling = true)]
        public static extern HRESULT Direct3DCreate9Ex([In] UINT SDKVersion, [Out] out P<IDirect3D9Ex> unnamedParam2);

        /// <summary>
        /// <para>
        /// Creates the Direct3D9 active display adapter enumerator with optional overrides to use D3D9On12.
        /// </para>
        /// <para>
        /// From: <see href="https://microsoft.github.io/DirectX-Specs/d3d/TranslationLayerResourceInterop.html"/>
        /// </para>
        /// </summary>
        /// <param name="SDKVersion">
        /// The value of this parameter should be <see cref="D3D_SDK_VERSION"/>.
        /// </param>
        /// <param name="pOverrideList">
        /// The list of per-active adapter overrides indicating if a 9On12 device should be created.
        /// </param>
        /// <param name="NumOverrideEntries">
        /// The count of override entries specified in <paramref name="pOverrideList"/>.
        /// <paramref name="NumOverrideEntries"/> may be zero see remarks.
        /// </param>
        /// <returns>
        /// If successful, this function returns a pointer to an <see cref="IDirect3D9"/> interface; otherwise, a <see cref="NULL"/> pointer is returned.
        /// </returns>
        /// <remarks>
        /// Override entries overried settings for an enumerated display adapter with 9On12 settings.
        /// If zero is specified for <paramref name="NumOverrideEntries"/>, this method behaves like <see cref="Direct3DCreate9"/>.
        /// The <see cref="IDirect3D9"/> interface supports enumeration of active display adapters and allows the creation of <see cref="IDirect3DDevice9"/> objects.
        /// If the user dynamically adds adapters (either by adding devices to the desktop, or by hot-docking a laptop),
        /// those devices will not be included in the enumeration.
        /// Creating a new <see cref="IDirect3D9"/> interface will expose the new devices.
        /// <see cref="D3D_SDK_VERSION"/> is passed to this function to ensure that the header files
        /// against which an application is compiled match the version of the runtime DLL’s that are installed on the machine.
        /// <see cref="D3D_SDK_VERSION"/> is only changed in the runtime when a header change (or other code change) would require an application to be rebuilt.
        /// If this function fails, it indicates that the header file version does not match the runtime DLL version.
        /// See Direct3DCreate9 for additional remarks.
        /// </remarks>
        [DllImport("D3d9.dll", CharSet = CharSet.Unicode, EntryPoint = "Direct3DCreate9On12", ExactSpelling = true)]
        public static extern P<IDirect3D9> Direct3DCreate9On12([In] UINT SDKVersion, [In] D3D9ON12_ARGS[] pOverrideList, [In] UINT NumOverrideEntries);

        /// <summary>
        /// <para>
        /// Creates the Direct3D9Ex active display adapter enumerator with optional overrides to use D3D9On12.
        /// </para>
        /// <para>
        /// From: <see href="https://microsoft.github.io/DirectX-Specs/d3d/TranslationLayerResourceInterop.html"/>
        /// </para>
        /// </summary>
        /// <param name="SDKVersion">
        /// The value of this parameter should be <see cref="D3D_SDK_VERSION"/>.
        /// </param>
        /// <param name="pOverrideList">
        /// The list of per-active adapter overrides indicating if a 9On12 device should be created.
        /// </param>
        /// <param name="NumOverrideEntries">
        /// The count of override entries specified in <paramref name="pOverrideList"/>.
        /// <paramref name="NumOverrideEntries"/> may be zero see remarks.
        /// </param>
        /// <param name="ppOutputInterface">
        /// Returns a pointer to the <see cref="IDirect3D9Ex"/> enumerator.
        /// </param>
        /// <returns>
        /// <see cref="D3DERR_NOTAVAILABLE"/>:
        /// If Direct3DEx features are not supported (no WDDM driver is installed)
        /// or if the <paramref name="SDKVersion"/> does not match the version of the DLL.
        /// <see cref="D3DERR_OUTOFMEMORY"/>:
        /// If out-of-memory conditions are detected when creating the enumerator object.
        /// <see cref="S_OK"/>:
        /// If the creation of the enumerator object is successful.
        /// </returns>
        /// <remarks>
        /// Override entries overried settings for an enumerated display adapter with 9On12 settings.
        /// If zero is specified for <paramref name="NumOverrideEntries"/>, this method behaves like <see cref="Direct3DCreate9Ex"/>.
        /// The <see cref="IDirect3D9Ex"/> object is the first object that the application creates and the last object that the application releases.
        /// Functions for enumerating and retrieving capabilities of a device are accessible through the <see cref="IDirect3D9Ex"/> object.
        /// This enables applications to select devices without creating them.
        /// The <see cref="IDirect3D9Ex"/> interface supports enumeration of active display adapters and allows the creation of <see cref="IDirect3D9Ex"/> objects.
        /// If the user dynamically adds adapters (either by adding devices to the desktop, or by hot-docking a laptop),
        /// these devices are not included in the enumeration.
        /// Creating a new <see cref="IDirect3D9Ex"/> interface will expose the new devices.
        /// Pass the <see cref="D3D_SDK_VERSION"/> flag to this function to ensure that header files
        /// used in the compiled application match the version of the installed runtime DLLs.
        /// <see cref="D3D_SDK_VERSION"/> is changed in the runtime only when a header or another code change would require rebuilding the application.
        /// If this function fails, it indicates that the versions of the header file and the runtime DLL do not match.
        /// See <see cref="Direct3DCreate9Ex"/> for additional remarks.
        /// </remarks>
        [DllImport("D3d9.dll", CharSet = CharSet.Unicode, EntryPoint = "Direct3DCreate9On12Ex", ExactSpelling = true)]
        public static extern HRESULT Direct3DCreate9On12Ex(UINT SDKVersion, D3D9ON12_ARGS[] pOverrideList, UINT NumOverrideEntries, [Out] out P<IDirect3D9Ex> ppOutputInterface);
    }
}
