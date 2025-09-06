using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This interface enables registration for notifications to detect adapter enumeration state changes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nn-dxgi1_6-idxgifactory7"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows10, 17763)]
    [ComInterface(IID = "a4966eed-76db-44da-84c1-ee9a7afb20a8", BeginVTableSlotIndex = 30, EndVTableSlotIndex = 31,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIFactory), typeof(IDXGIFactory1), typeof(IDXGIFactory2),
            typeof(IDXGIFactory3),typeof(IDXGIFactory4), typeof(IDXGIFactory5), typeof(IDXGIFactory6)])]
    public unsafe struct IDXGIFactory7
    {
        IntPtr* _vTable;

        /// <summary>
        /// Registers to receive notification of changes whenever the adapter enumeration state changes.
        /// </summary>
        /// <param name="hEvent">
        /// A handle to the event object.
        /// </param>
        /// <param name="pdwCookie">
        /// A handle to the event object.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// </returns>
        public HRESULT RegisterAdaptersChangedEvent([In] HANDLE hEvent, [Out] out DWORD pdwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, out DWORD, HRESULT>)_vTable[30])(thisPtr, hEvent, out pdwCookie);
            }
        }

        /// <summary>
        /// Unregisters an event to stop receiving notifications when the adapter enumeration state changes.
        /// </summary>
        /// <param name="dwCookie">
        /// A key value for the event to unregister.
        /// </param>
        /// <remarks>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// </remarks>
        public void UnregisterStereoStatus([In] DWORD dwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DWORD, void>)_vTable[31])(thisPtr, dwCookie);
            }
        }
    }
}
