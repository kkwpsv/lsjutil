using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_COMMAND_LIST_TYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the type of query.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_query_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by <see cref="ID3D12GraphicsCommandList.BeginQuery"/>,
    /// <see cref="ID3D12GraphicsCommandList.EndQuery"/> and <see cref="ID3D12GraphicsCommandList.ResolveQueryData"/>.
    /// </remarks>
    public enum D3D12_QUERY_TYPE
    {
        /// <summary>
        /// Indicates the query is for depth/stencil occlusion counts.
        /// </summary>
        D3D12_QUERY_TYPE_OCCLUSION = 0,

        /// <summary>
        /// <para>
        /// Indicates the query is for a binary depth/stencil occlusion statistics.
        /// </para>
        /// <para>
        /// This new query type acts like <see cref="D3D12_QUERY_TYPE_OCCLUSION"/>
        /// except that it returns simply a binary 0/1 result:
        /// 0 indicates that no samples passed depth and stencil testing,
        /// 1 indicates that at least one sample passed depth and stencil testing.
        /// This enables occlusion queries to not interfere with any GPU performance optimization associated with depth/stencil testing.
        /// </para>
        /// </summary>
        D3D12_QUERY_TYPE_BINARY_OCCLUSION = 1,

        /// <summary>
        /// Indicates the query is for high definition GPU and CPU timestamps.
        /// </summary>
        D3D12_QUERY_TYPE_TIMESTAMP = 2,

        /// <summary>
        /// Indicates the query type is for graphics pipeline statistics,
        /// refer to <see cref="D3D12_QUERY_DATA_PIPELINE_STATISTICS"/>.
        /// </summary>
        D3D12_QUERY_TYPE_PIPELINE_STATISTICS = 3,

        /// <summary>
        /// Stream 0 output statistics.
        /// In Direct3D 12 there is no single stream output (SO) overflow query for all the output streams.
        /// Apps need to issue multiple single-stream queries, and then correlate the results.
        /// Stream output is the ability of the GPU to write vertices to a buffer.
        /// The stream output counters monitor progress.
        /// </summary>
        D3D12_QUERY_TYPE_SO_STATISTICS_STREAM0 = 4,

        /// <summary>
        /// Stream 1 output statistics.
        /// </summary>
        D3D12_QUERY_TYPE_SO_STATISTICS_STREAM1 = 5,

        /// <summary>
        /// Stream 2 output statistics.
        /// </summary>
        D3D12_QUERY_TYPE_SO_STATISTICS_STREAM2 = 6,

        /// <summary>
        /// Stream 3 output statistics.
        /// </summary>
        D3D12_QUERY_TYPE_SO_STATISTICS_STREAM3 = 7,

        /// <summary>
        /// <para>
        /// Video decode statistics.
        /// Refer to <see cref="D3D12_QUERY_DATA_VIDEO_DECODE_STATISTICS"/>.
        /// </para>
        /// <para>
        /// Use this query type to determine if a video was successfully decoded.
        /// If decoding fails due to insufficient BitRate or FrameRate parameters set during creation of the decode heap,
        /// then the status field of the query is set to <see cref="D3D12_VIDEO_DECODE_STATUS_RATE_EXCEEDED"/>
        /// and the query also contains new BitRate and FrameRate values that would succeed.
        /// </para>
        /// <para>
        /// This query type can only be performed on video decode command lists <see cref="D3D12_COMMAND_LIST_TYPE_VIDEO_DECODE"/>.
        /// This query type does not use <see cref="ID3D12VideoDecodeCommandList.BeginQuery"/>,
        /// only <see cref="ID3D12VideoDecodeCommandList.EndQuery"/>.
        /// Statistics are recorded only for the most recent <see cref="ID3D12VideoDecodeCommandList.DecodeFrame"/> call in the same command list.
        /// </para>
        /// <para>
        /// Decode status structures are defined by the codec specification.
        /// </para>
        /// </summary>
        D3D12_QUERY_TYPE_VIDEO_DECODE_STATISTICS = 8,

        /// <summary>
        /// 
        /// </summary>
        D3D12_QUERY_TYPE_PIPELINE_STATISTICS1 = 10
    }
}
