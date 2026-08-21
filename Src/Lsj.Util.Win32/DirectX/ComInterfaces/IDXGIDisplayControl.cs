using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDXGIDisplayControl"/> interface exposes methods to indicate user preference
    /// for the operating system's stereoscopic 3D display behavior
    /// and to set stereoscopic 3D display status to enable or disable.
    /// </para>
    /// <para>
    /// We recommend that you not use <see cref="IDXGIDisplayControl"/>
    /// to query or set system-wide stereoscopic 3D settings in your stereoscopic 3D apps.
    /// Instead, for your windowed apps,
    /// call the <see cref="IDXGIFactory2.IsWindowedStereoEnabled"/> method to determine whether to render in stereo;
    /// for your full-screen apps, call the <see cref="IDXGIOutput1.GetDisplayModeList1"/> method
    /// and then determine whether any of the returned display modes support rendering in stereo.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgidisplaycontrol"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Note  The <see cref="IDXGIDisplayControl"/> interface
    /// is only used by the Display app of the operating system's Control Panel
    /// or by control applets from third party graphics vendors.
    /// This interface is not meant for developers of end-user apps.
    /// </para>
    /// <para>
    /// Note  The <see cref="IDXGIDisplayControl"/> interface does not exist for Windows Store apps.
    /// Call <see cref="IUnknown.QueryInterface"/> from a factory object (<see cref="IDXGIFactory"/>,
    /// <see cref="IDXGIFactory1"/> or <see cref="IDXGIFactory2"/>) to retrieve the <see cref="IDXGIDisplayControl"/> interface.
    /// The following code shows how.
    /// </para>
    /// <code>
    /// IDXGIDisplayControl * pDXGIDisplayControl;
    /// hr = g_pDXGIFactory->QueryInterface(__uuidof(IDXGIDisplayControl), (void**)&amp;pDXGIDisplayControl);
    /// </code>
    /// <para>
    /// The operating system processes changes to stereo-enabled configuration asynchronously.
    /// Therefore, these changes might not be immediately visible in every process
    /// that calls <see cref="IsStereoEnabled"/> to query for stereo configuration.
    /// Control applets can use the <see cref="IDXGIFactory2.RegisterStereoStatusEvent"/>
    /// or <see cref="IDXGIFactory2.RegisterStereoStatusWindow"/> method
    /// to register for notifications of all stereo configuration changes.
    /// </para>
    /// <para>
    /// Platform Update for Windows 7:
    /// Stereoscopic 3D display behavior isn’t available with the Platform Update for Windows 7.
    /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "ea9dbf1a-c88e-4486-854a-98aa0138f30c", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 3, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDXGIDisplayControl
    {
        nint* _vTable;

        /// <summary>
        /// Retrieves a Boolean value that indicates whether the operating system's stereoscopic 3D display behavior is enabled.
        /// </summary>
        /// <returns>
        /// <para>
        /// <see cref="IsStereoEnabled"/> returns <see cref="TRUE"/>
        /// when the operating system's stereoscopic 3D display behavior is enabled
        /// and <see cref="FALSE"/> when this behavior is disabled.
        /// </para>
        /// <para>
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="IsStereoEnabled"/> always returns <see cref="FALSE"/>
        /// because stereoscopic 3D display behavior isn’t available with the Platform Update for Windows 7.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </para>
        /// </returns>
        /// <remarks>
        /// You pass a Boolean value to the <see cref="SetStereoEnabled"/> method
        /// to either enable or disable the operating system's stereoscopic 3D display behavior.
        /// <see cref="TRUE"/> enables the operating system's stereoscopic 3D display behavior
        /// and <see cref="FALSE"/> disables it.
        /// </remarks>
        public BOOL IsStereoEnabled()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[3])(thisPtr);
            }
        }

        /// <summary>
        /// Set a Boolean value to either enable or disable the operating system's stereoscopic 3D display behavior.
        /// </summary>
        /// <param name="enabled">
        /// A Boolean value that either enables or disables the operating system's stereoscopic 3D display behavior.
        /// <see cref="TRUE"/> enables the operating system's stereoscopic 3D display behavior
        /// and <see cref="FALSE"/> disables it.
        /// </param>
        /// <returns>
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="SetStereoEnabled"/> doesn't change stereoscopic 3D display behavior
        /// because stereoscopic 3D display behavior isn’t available with the Platform Update for Windows 7.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        public void SetStereoEnabled([In] BOOL enabled)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, BOOL, void>)_vTable[4])(thisPtr, enabled);
            }
        }
    }
}
