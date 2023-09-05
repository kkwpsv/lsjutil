using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
    /// Use with an <see cref="IDXGIInfoQueue"/> interface.
    /// Note
    /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
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
