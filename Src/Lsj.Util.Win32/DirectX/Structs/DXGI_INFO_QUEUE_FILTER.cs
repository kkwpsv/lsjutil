using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a debug message filter, which contains lists of message types to allow and deny.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/ns-dxgidebug-dxgi_info_queue_filter"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use with an <see cref="IDXGIInfoQueue"/> interface.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_INFO_QUEUE_FILTER
    {
        /// <summary>
        /// A <see cref="DXGI_INFO_QUEUE_FILTER_DESC"/> structure that describes the types of messages to allow.
        /// </summary>
        public DXGI_INFO_QUEUE_FILTER_DESC AllowList;

        /// <summary>
        /// A <see cref="DXGI_INFO_QUEUE_FILTER_DESC"/> structure that describes the types of messages to deny.
        /// </summary>
        public DXGI_INFO_QUEUE_FILTER_DESC DenyList;
    }
}
