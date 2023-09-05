using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the types of messages to allow or deny to pass through a filter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/ns-dxgidebug-dxgi_info_queue_filter_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is a member of the <see cref="DXGI_INFO_QUEUE_FILTER"/> structure.
    /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_INFO_QUEUE_FILTER_DESC
    {
        /// <summary>
        /// The number of message categories to allow or deny.
        /// </summary>
        public UINT NumCategories;

        /// <summary>
        /// An array of <see cref="DXGI_INFO_QUEUE_MESSAGE_CATEGORY"/> enumeration values that describe the message categories to allow or deny.
        /// The array must have at least <see cref="NumCategories"/> number of elements.
        /// </summary>
        public P<DXGI_INFO_QUEUE_MESSAGE_CATEGORY> pCategoryList;

        /// <summary>
        /// The number of message severity levels to allow or deny.
        /// </summary>
        public UINT NumSeverities;

        /// <summary>
        /// An array of <see cref="DXGI_INFO_QUEUE_MESSAGE_SEVERITY"/> enumeration values that describe the message severity levels to allow or deny.
        /// The array must have at least <see cref="NumSeverities"/> number of elements.
        /// </summary>
        public P<DXGI_INFO_QUEUE_MESSAGE_SEVERITY> pSeverityList;

        /// <summary>
        /// The number of message IDs to allow or deny.
        /// </summary>
        public UINT NumIDs;

        /// <summary>
        /// An array of integers that represent the message IDs to allow or deny. The array must have at least NumIDs number of elements.
        /// </summary>
        public P<DXGI_INFO_QUEUE_MESSAGE_ID> pIDList;
    }
}
