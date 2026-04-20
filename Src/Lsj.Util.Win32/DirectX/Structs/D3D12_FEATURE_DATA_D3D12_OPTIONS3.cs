using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Indicates the level of support that the adapter provides for timestamp queries, format-casting, immediate write, view instancing, and barycentrics.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options3"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_FEATURE_DATA_D3D12_OPTIONS3
    {
        /// <summary>
        /// Indicates whether timestamp queries are supported on copy queues.
        /// </summary>
        public BOOL CopyQueueTimestampQueriesSupported;

        /// <summary>
        /// Indicates whether casting from one fully typed format to another, compatible, format is supported.
        /// </summary>
        public BOOL CastingFullyTypedFormatSupported;

        /// <summary>
        /// Indicates the kinds of command lists that support the ability
        /// to write an immediate value directly from the command stream into a specified buffer.
        /// </summary>
        public D3D12_COMMAND_LIST_SUPPORT_FLAGS WriteBufferImmediateSupportFlags;

        /// <summary>
        /// Indicates the level of support the adapter has for view instancing.
        /// </summary>
        public D3D12_VIEW_INSTANCING_TIER ViewInstancingTier;

        /// <summary>
        /// Indicates whether barycentrics are supported.
        /// </summary>
        public BOOL BarycentricsSupported;
    }
}
