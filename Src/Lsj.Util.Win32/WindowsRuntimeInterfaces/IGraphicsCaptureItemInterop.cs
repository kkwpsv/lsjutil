using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// Desktop interop interface for the GraphicsCaptureItem activation factory.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/windows.graphics.capture.interop/nn-windows-graphics-capture-interop-igraphicscaptureiteminterop"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows10, BuildNumbers.Windows10_1903)]
    [ComInterface(BeginVTableSlotIndex = 3, EndVTableSlotIndex = 4, IID = "3628E81B-3CAC-4C60-B7F4-23CE0E0C3356",
        InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IGraphicsCaptureItemInterop
    {
        IntPtr* _vTable;

        /// <summary>
        /// Targets a single window for the creation of a graphics capture item.
        /// </summary>
        /// <param name="appWindow">
        /// The window handle that represents the window to capture.
        /// </param>
        /// <param name="riid">
        /// GUID for the type returned.
        /// Supported value: GraphicsCaptureItem.
        /// </param>
        /// <param name="result">
        /// Out pointer for the object to receive.
        /// </param>
        /// <returns>
        /// The return error code.
        /// </returns>
        public HRESULT CreateForWindow([In] HWND appWindow, [In] in IID riid, [Out] out IntPtr result)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, in IID, out IntPtr, HRESULT>)_vTable[3])(thisPtr, appWindow, riid, out result);
            }
        }

        /// <summary>
        /// Targets a monitor(s) for the creation of a graphics capture item.
        /// </summary>
        /// <param name="monitor">
        /// The monitor handle that represents the monitor to capture.
        /// </param>
        /// <param name="riid">
        /// GUID for the type returned.
        /// Supported value: GraphicsCaptureItem.
        /// </param>
        /// <param name="result">
        /// Out pointer for the object to receive.
        /// </param>
        /// <returns>
        /// The return error code.
        /// </returns>
        public HRESULT CreateForMonitor([In] HMONITOR monitor, [In] in IID riid, [Out] out IntPtr result)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HMONITOR, in IID, out IntPtr, HRESULT>)_vTable[4])(thisPtr, monitor, riid, out result);
            }
        }
    }
}