using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Dxva2.dll
    /// </summary>
    public static class Dxva2
    {
        /// <summary>
        /// <para>
        /// Closes a handle to a physical monitor.
        /// Call this function to close a monitor handle obtained from the <see cref="GetPhysicalMonitorsFromHMONITOR"/>
        /// or <see cref="GetPhysicalMonitorsFromIDirect3DDevice9"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/physicalmonitorenumerationapi/nf-physicalmonitorenumerationapi-destroyphysicalmonitor"/>
        /// </para>
        /// </summary>
        /// <param name="hMonitor">
        /// Handle to a physical monitor.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Dxva2.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyPhysicalMonitor", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyPhysicalMonitor([In] HANDLE hMonitor);

        /// <summary>
        /// <para>
        /// Closes an array of physical monitor handles.
        /// Call this function to close an array of monitor handles obtained from the <see cref="GetPhysicalMonitorsFromHMONITOR"/>
        /// or <see cref="GetPhysicalMonitorsFromIDirect3DDevice9"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/physicalmonitorenumerationapi/nf-physicalmonitorenumerationapi-destroyphysicalmonitors"/>
        /// </para>
        /// </summary>
        /// <param name="dwPhysicalMonitorArraySize">
        /// Number of elements in the <paramref name="pPhysicalMonitorArray"/> array.
        /// </param>
        /// <param name="pPhysicalMonitorArray">
        /// Pointer to an array of <see cref="PHYSICAL_MONITOR"/> structures.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Dxva2.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyPhysicalMonitors", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyPhysicalMonitors([In] DWORD dwPhysicalMonitorArraySize, [In] PHYSICAL_MONITOR[] pPhysicalMonitorArray);

        /// <summary>
        /// <para>
        /// Creates an instance of the Direct3D Device Manager.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxva2api/nf-dxva2api-dxva2createdirect3ddevicemanager9"/>
        /// </para>
        /// </summary>
        /// <param name="pResetToken">
        /// Receives a token that identifies this instance of the Direct3D device manager.
        /// Use this token when calling <see cref="IDirect3DDeviceManager9.ResetDevice"/>.
        /// </param>
        /// <param name="ppDeviceManager">
        /// Receives a pointer to the <see cref="IDirect3DDeviceManager9"/> interface.
        /// The caller must release the interface.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Windows Store apps must use <see cref="IMFDXGIDeviceManager"/> and Direct3D 11 Video APIs.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Dxva2.dll", CharSet = CharSet.Unicode, EntryPoint = "DXVA2CreateDirect3DDeviceManager9", ExactSpelling = true)]
        public static extern HRESULT DXVA2CreateDirect3DDeviceManager9([Out]out UINT pResetToken, [Out] out P<IDirect3DDeviceManager9> ppDeviceManager);

        /// <summary>
        /// <para>
        /// Retrieves the number of physical monitors associated with an <see cref="HMONITOR"/> monitor handle.
        /// Call this function before calling <see cref="GetPhysicalMonitorsFromHMONITOR"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/physicalmonitorenumerationapi/nf-physicalmonitorenumerationapi-getnumberofphysicalmonitorsfromhmonitor"/>
        /// </para>
        /// </summary>
        /// <param name="hMonitor">
        /// A monitor handle.
        /// Monitor handles are returned by several Multiple Display Monitor functions,
        /// including <see cref="EnumDisplayMonitors"/> and <see cref="MonitorFromWindow"/>,
        /// which are part of the graphics device interface (GDI).
        /// </param>
        /// <param name="pdwNumberOfPhysicalMonitors">
        /// Receives the number of physical monitors associated with the monitor handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Dxva2.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNumberOfPhysicalMonitorsFromHMONITOR", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetNumberOfPhysicalMonitorsFromHMONITOR([In] HMONITOR hMonitor, [Out] out DWORD pdwNumberOfPhysicalMonitors);

        /// <summary>
        /// <para>
        /// Retrieves the number of physical monitors associated with a Direct3D device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/physicalmonitorenumerationapi/nf-physicalmonitorenumerationapi-getnumberofphysicalmonitorsfromidirect3ddevice9"/>
        /// </para>
        /// </summary>
        /// <param name="pDirect3DDevice9">
        /// Pointer to the <see cref="IDirect3DDevice9"/> interface of the Direct3D device.
        /// </param>
        /// <param name="pdwNumberOfPhysicalMonitors">
        /// Receives the number of physical monitors associated with the Direct3D device.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Dxva2.dll", CharSet = CharSet.Unicode, EntryPoint = "GetNumberOfPhysicalMonitorsFromIDirect3DDevice9", ExactSpelling = true)]
        public static extern HRESULT GetNumberOfPhysicalMonitorsFromIDirect3DDevice9([In] P<IDirect3DDevice9> pDirect3DDevice9, [Out] out DWORD pdwNumberOfPhysicalMonitors);

        /// <summary>
        /// <para>
        /// Retrieves the physical monitors associated with an <see cref="HMONITOR"/> monitor handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/physicalmonitorenumerationapi/nf-physicalmonitorenumerationapi-getphysicalmonitorsfromhmonitor"/>
        /// </para>
        /// </summary>
        /// <param name="hMonitor">
        /// A monitor handle.
        /// Monitor handles are returned by several Multiple Display Monitor functions,
        /// including <see cref="EnumDisplayMonitors"/> and <see cref="MonitorFromWindow"/>,
        /// which are part of the graphics device interface (GDI).
        /// </param>
        /// <param name="dwPhysicalMonitorArraySize">
        /// Number of elements in <paramref name="pPhysicalMonitorArray"/>.
        /// To get the required size of the array, call <see cref="GetNumberOfPhysicalMonitorsFromHMONITOR"/>.
        /// </param>
        /// <param name="pPhysicalMonitorArray">
        /// Pointer to an array of <see cref="PHYSICAL_MONITOR"/> structures.
        /// The caller must allocate the array.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A single <see cref="HMONITOR"/> handle can be associated with more than one physical monitor.
        /// This function returns a handle and a text description for each physical monitor.
        /// </para>
        /// <para>
        /// When you are done using the monitor handles,
        /// close them by passing the <paramref name="pPhysicalMonitorArray"/> array
        /// to the <see cref="DestroyPhysicalMonitors"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Dxva2.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPhysicalMonitorsFromHMONITOR", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPhysicalMonitorsFromHMONITOR([In] HMONITOR hMonitor, [In] DWORD dwPhysicalMonitorArraySize, [Out] PHYSICAL_MONITOR[] pPhysicalMonitorArray);

        /// <summary>
        /// <para>
        /// Retrieves the physical monitors associated with a Direct3D device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/physicalmonitorenumerationapi/nf-physicalmonitorenumerationapi-getphysicalmonitorsfromidirect3ddevice9"/>
        /// </para>
        /// </summary>
        /// <param name="pDirect3DDevice9">
        /// Pointer to the <see cref="IDirect3DDevice9"/> interface of the Direct3D device.
        /// </param>
        /// <param name="dwPhysicalMonitorArraySize">
        /// Number of elements in <paramref name="pPhysicalMonitorArray"/>.
        /// To get the required size of the array, call <see cref="GetNumberOfPhysicalMonitorsFromIDirect3DDevice9"/>.
        /// </param>
        /// <param name="pPhysicalMonitorArray">
        /// Pointer to an array of <see cref="PHYSICAL_MONITOR"/> structures.
        /// The caller must allocate the array.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A single Direct3D device can be associated with more than one physical monitor.
        /// This function returns a handle and a text description for each physical monitor.
        /// </para>
        /// <para>
        /// When you are done using the monitor handles,
        /// close them by passing the <paramref name="pPhysicalMonitorArray"/> array
        /// to the <see cref="DestroyPhysicalMonitors"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("Dxva2.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPhysicalMonitorsFromIDirect3DDevice9", ExactSpelling = true)]
        public static extern HRESULT GetPhysicalMonitorsFromIDirect3DDevice9([In] P<IDirect3DDevice9> pDirect3DDevice9,
            [In] DWORD dwPhysicalMonitorArraySize, [Out] PHYSICAL_MONITOR[] pPhysicalMonitorArray);
    }
}
