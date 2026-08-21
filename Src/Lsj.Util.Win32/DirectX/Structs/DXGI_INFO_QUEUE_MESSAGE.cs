using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a debug message in the information queue.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgidebug/ns-dxgidebug-dxgi_info_queue_message"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="IDXGIInfoQueue.GetMessage"/> returns a pointer to this structure.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This API requires the Windows Software Development Kit (SDK) for Windows 8.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DXGI_INFO_QUEUE_MESSAGE
    {
        /// <summary>
        /// A <see cref="DXGI_DEBUG_ID"/> value that identifies the entity that produced the message.
        /// </summary>
        public DXGI_DEBUG_ID Producer;

        /// <summary>
        /// A <see cref="DXGI_INFO_QUEUE_MESSAGE_CATEGORY"/>-typed value that specifies the category of the message.
        /// </summary>
        public DXGI_INFO_QUEUE_MESSAGE_CATEGORY Category;

        /// <summary>
        /// A <see cref="DXGI_INFO_QUEUE_MESSAGE_SEVERITY"/>-typed value that specifies the severity of the message.
        /// </summary>
        public DXGI_INFO_QUEUE_MESSAGE_SEVERITY Severity;

        /// <summary>
        /// An integer that uniquely identifies the message.
        /// </summary>
        public DXGI_INFO_QUEUE_MESSAGE_ID ID;

        /// <summary>
        /// The message string.
        /// </summary>
        public nint pDescription;

        /// <summary>
        /// The length of the message string at <see cref="pDescription"/>, in bytes.
        /// </summary>
        public SIZE_T DescriptionByteLength;
    }
}
