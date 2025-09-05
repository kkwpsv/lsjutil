using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_CONTENT_PROTECTION_CAPS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This interface adds some memory residency methods, for budgeting and reserving physical memory.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nn-dxgi1_4-idxgiadapter3"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For more details, refer to the Residency section of the D3D12 documentation.
    /// </remarks>
    [ComInterface(IID = "645967A4-1392-4310-A798-8053CE3E93FD", BeginVTableSlotIndex = 12, EndVTableSlotIndex = 17,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIAdapter), typeof(IDXGIAdapter1), typeof(IDXGIAdapter2)])]
    public unsafe struct IDXGIAdapter3
    {
        IntPtr* _vTable;

        /// <summary>
        /// Registers to receive notification of hardware content protection teardown events.
        /// </summary>
        /// <param name="hEvent">
        /// A handle to the event object that the operating system sets
        /// when hardware content protection teardown occurs.
        /// The <see cref="CreateEvent"/> or <see cref="OpenEvent"/> function returns this handle.
        /// </param>
        /// <param name="pdwCookie">
        /// A pointer to a key value that an application can pass
        /// to the <see cref="UnregisterHardwareContentProtectionTeardownStatus"/> method
        /// to unregister the notification event that <paramref name="hEvent"/> specifies.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Call <see cref="ID3D11VideoDevice.GetContentProtectionCaps"/> to check for
        /// the presence of the <see cref="D3D11_CONTENT_PROTECTION_CAPS_HARDWARE_TEARDOWN"/> capability
        /// to know whether the hardware contains an automatic teardown mechanism.
        /// </para>
        /// <para>
        /// After the event is signaled, the application can call <see cref="ID3D11VideoContext1.CheckCryptoSessionStatus"/>
        /// to determine the impact of the hardware teardown for a specific <see cref="ID3D11CryptoSession"/> interface.
        /// </para>
        /// </remarks>
        public HRESULT RegisterHardwareContentProtectionTeardownStatusEvent([In] HANDLE hEvent, [Out] out DWORD pdwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, out DWORD, HRESULT>)_vTable[12])(thisPtr, hEvent, out pdwCookie);
            }
        }

        /// <summary>
        /// Unregisters an event to stop it from receiving notification
        /// of hardware content protection teardown events.
        /// </summary>
        /// <param name="dwCookie">
        /// A key value for the window or event to unregister.
        /// The <see cref="RegisterHardwareContentProtectionTeardownStatusEvent"/> method returns this value.
        /// </param>
        public void UnregisterHardwareContentProtectionTeardownStatus([In] DWORD dwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DWORD, void>)_vTable[13])(thisPtr, dwCookie);
            }
        }

        /// <summary>
        /// This method informs the process of the current budget and process usage.
        /// </summary>
        /// <param name="NodeIndex">
        /// Specifies the device's physical adapter for which the video memory information is queried.
        /// For single-GPU operation, set this to zero.
        /// If there are multiple GPU nodes, set this to the index of the node (the device's physical adapter)
        /// for which the video memory information is queried.
        /// See Multi-adapter systems.
        /// </param>
        /// <param name="MemorySegmentGroup">
        /// Specifies a <see cref="DXGI_MEMORY_SEGMENT_GROUP"/> that identifies the group as local or non-local.
        /// </param>
        /// <param name="pVideoMemoryInfo">
        /// Fills in a <see cref="DXGI_QUERY_VIDEO_MEMORY_INFO"/> structure with the current values.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// Applications must explicitly manage their usage of physical memory explicitly
        /// and keep usage within the budget assigned to the application process.
        /// Processes that cannot kept their usage within their assigned budgets will likely experience stuttering,
        /// as they are intermittently frozen and paged-out to allow other processes to run.
        /// </remarks>
        public HRESULT QueryVideoMemoryInfo([In] UINT NodeIndex, [In] DXGI_MEMORY_SEGMENT_GROUP MemorySegmentGroup,
            [Out] out DXGI_QUERY_VIDEO_MEMORY_INFO pVideoMemoryInfo)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, DXGI_MEMORY_SEGMENT_GROUP, out DXGI_QUERY_VIDEO_MEMORY_INFO, HRESULT>)_vTable[14])
                    (thisPtr, NodeIndex, MemorySegmentGroup, out pVideoMemoryInfo);
            }
        }

        /// <summary>
        /// This method sends the minimum required physical memory for an application, to the OS.
        /// </summary>
        /// <param name="NodeIndex">
        /// Specifies the device's physical adapter for which the video memory information is being set.
        /// For single-GPU operation, set this to zero.
        /// If there are multiple GPU nodes, set this to the index of the node (the device's physical adapter)
        /// for which the video memory information is being set.
        /// See Multi-adapter systems.
        /// </param>
        /// <param name="MemorySegmentGroup">
        /// Specifies a <see cref="DXGI_MEMORY_SEGMENT_GROUP"/> that identifies the group as local or non-local.
        /// </param>
        /// <param name="Reservation">
        /// Specifies a <see cref="UINT64"/> that sets the minimum required physical memory, in bytes.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// Applications are encouraged to set a video reservation
        /// to denote the amount of physical memory they cannot go without.
        /// This value helps the OS quickly minimize the impact of large memory pressure situations.
        /// </remarks>
        public HRESULT SetVideoMemoryReservation([In] UINT NodeIndex, [In] DXGI_MEMORY_SEGMENT_GROUP MemorySegmentGroup, [In] UINT64 Reservation)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, DXGI_MEMORY_SEGMENT_GROUP, UINT64, HRESULT>)_vTable[15])
                    (thisPtr, NodeIndex, MemorySegmentGroup, Reservation);
            }
        }

        /// <summary>
        /// This method establishes a correlation between a CPU synchronization object and the budget change event.
        /// </summary>
        /// <param name="hEvent">
        /// Specifies a <see cref="HANDLE"/> for the event.
        /// </param>
        /// <param name="pdwCookie">
        /// A pointer to a key value that you can pass
        /// to the <see cref="UnregisterVideoMemoryBudgetChangeNotification"/> method
        /// to unregister the notification event that <paramref name="hEvent"/> specifies.
        /// </param>
        /// <returns>
        /// This method returns an <see cref="HRESULT"/> success or error code.
        /// </returns>
        /// <remarks>
        /// Instead of calling <see cref="QueryVideoMemoryInfo"/> regularly,
        /// applications can use CPU synchronization objects to efficiently wake threads when budget changes occur.
        /// </remarks>
        public HRESULT RegisterVideoMemoryBudgetChangeNotificationEvent([In] HANDLE hEvent, [Out] out DWORD pdwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, out DWORD, HRESULT>)_vTable[16])(thisPtr, hEvent, out pdwCookie);
            }
        }

        /// <summary>
        /// This method stops notifying a CPU synchronization object whenever a budget change occurs.
        /// An application may switch back to polling the information regularly.
        /// </summary>
        /// <param name="dwCookie">
        /// A key value for the window or event to unregister.
        /// The <see cref="RegisterHardwareContentProtectionTeardownStatusEvent"/> method returns this value.
        /// </param>
        /// <remarks>
        /// An application may switch back to polling for the information regularly.
        /// </remarks>
        public void UnregisterVideoMemoryBudgetChangeNotification([In] DWORD dwCookie)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, DWORD, void>)_vTable[17])(thisPtr, dwCookie);
            }
        }
    }
}
