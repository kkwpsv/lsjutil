using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the current video memory budgeting parameters.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/ns-dxgi1_4-dxgi_query_video_memory_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with <see cref="IDXGIAdapter3.QueryVideoMemoryInfo"/>.
    /// Refer to the remarks for <see cref="D3D12_MEMORY_POOL"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_QUERY_VIDEO_MEMORY_INFO
    {
        /// <summary>
        /// Specifies the OS-provided video memory budget, in bytes, that the application should target.
        /// If <see cref="CurrentUsage"/> is greater than <see cref="Budget"/>, the application may incur stuttering or performance penalties
        /// due to background activity by the OS to provide other applications with a fair usage of video memory.
        /// </summary>
        public UINT64 Budget;

        /// <summary>
        /// Specifies the application’s current video memory usage, in bytes.
        /// </summary>
        public UINT64 CurrentUsage;

        /// <summary>
        /// The amount of video memory, in bytes, that the application has available for reservation.
        /// To reserve this video memory, the application should call <see cref="IDXGIAdapter3.SetVideoMemoryReservation"/>.
        /// </summary>
        public UINT64 AvailableForReservation;

        /// <summary>
        /// The amount of video memory, in bytes, that is reserved by the application.
        /// The OS uses the reservation as a hint to determine the application’s minimum working set.
        /// Applications should attempt to ensure that their video memory usage can be trimmed to meet this requirement.
        /// </summary>
        public UINT64 CurrentReservation;
    }
}
