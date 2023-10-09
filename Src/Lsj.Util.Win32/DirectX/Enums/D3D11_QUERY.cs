using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Query types.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_query"/>
    /// </para>
    /// </summary>
    public enum D3D11_QUERY
    {
        /// <summary>
        /// Determines whether or not the GPU is finished processing commands.
        /// When the GPU is finished processing commands <see cref="ID3D11DeviceContext.GetData"/> will return <see cref="S_OK"/>,
        /// and pData will point to a <see cref="BOOL"/> with a value of <see cref="TRUE"/>.
        /// When using this type of query, <see cref="ID3D11DeviceContext.Begin"/> is disabled.
        /// </summary>
        D3D11_QUERY_EVENT = 0,

        /// <summary>
        /// Get the number of samples that passed the depth and stencil tests
        /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
        /// <see cref="ID3D11DeviceContext.GetData"/> returns a <see cref="UINT64"/>.
        /// If a depth or stencil test is disabled, then each of those tests will be counted as a pass.
        /// </summary>
        D3D11_QUERY_OCCLUSION,

        /// <summary>
        /// Get a timestamp value where <see cref="ID3D11DeviceContext.GetData"/> returns a <see cref="UINT64"/>.
        /// This kind of query is only useful if two timestamp queries are done in the middle of a <see cref="D3D11_QUERY_TIMESTAMP_DISJOINT"/> query.
        /// The difference of two timestamps can be used to determine how many ticks have elapsed,
        /// and the <see cref="D3D11_QUERY_TIMESTAMP_DISJOINT"/> query will determine if that difference is a reliable value
        /// and also has a value that shows how to convert the number of ticks into seconds.
        /// See <see cref="D3D11_QUERY_DATA_TIMESTAMP_DISJOINT"/>.
        /// When using this type of query, <see cref="ID3D11DeviceContext.Begin"/> is disabled.
        /// </summary>
        D3D11_QUERY_TIMESTAMP,

        /// <summary>
        /// Determines whether or not a <see cref="D3D11_QUERY_TIMESTAMP"/> is returning reliable values,
        /// and also gives the frequency of the processor enabling you to convert the number of elapsed ticks into seconds.
        /// <see cref="ID3D11DeviceContext.GetData"/> will return a <see cref="D3D11_QUERY_DATA_TIMESTAMP_DISJOINT"/>.
        /// This type of query should only be invoked once per frame or less.
        /// </summary>
        D3D11_QUERY_TIMESTAMP_DISJOINT,

        /// <summary>
        /// Get pipeline statistics, such as the number of pixel shader invocations
        /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
        /// <see cref="ID3D11DeviceContext.GetData"/> will return a <see cref="D3D11_QUERY_DATA_PIPELINE_STATISTICS"/>.
        /// </summary>
        D3D11_QUERY_PIPELINE_STATISTICS,

        /// <summary>
        /// Similar to <see cref="D3D11_QUERY_OCCLUSION"/>, except <see cref="ID3D11DeviceContext.GetData"/> returns a <see cref="BOOL"/>
        /// indicating whether or not any samples passed the depth and stencil tests - 
        /// <see cref="TRUE"/> meaning at least one passed, <see cref="FALSE"/> meaning none passed.
        /// </summary>
        D3D11_QUERY_OCCLUSION_PREDICATE,

        /// <summary>
        /// Get streaming output statistics, such as the number of primitives streamed out
        /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
        /// <see cref="ID3D11DeviceContext.GetData"/> will return a <see cref="D3D11_QUERY_DATA_SO_STATISTICS"/> structure.
        /// </summary>
        D3D11_QUERY_SO_STATISTICS,

        /// <summary>
        /// Determines whether or not any of the streaming output buffers overflowed
        /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
        /// <see cref="ID3D11DeviceContext.GetData"/> returns a <see cref="BOOL"/> - 
        /// <see cref="TRUE"/> meaning there was an overflow, <see cref="FALSE"/> meaning there was not an overflow.
        /// If streaming output writes to multiple buffers, and one of the buffers overflows,
        /// then it will stop writing to all the output buffers.
        /// When an overflow is detected by Direct3D it is prevented from happening - no memory is corrupted.
        /// This predication may be used in conjunction with an SO_STATISTICS query
        /// so that when an overflow occurs the SO_STATISTIC query will let the application know how much memory was needed to prevent an overflow.
        /// </summary>
        D3D11_QUERY_SO_OVERFLOW_PREDICATE,

        /// <summary>
        /// Get streaming output statistics for stream 0, such as the number of primitives streamed out
        /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
        /// <see cref="ID3D11DeviceContext.GetData"/> will return a <see cref="D3D11_QUERY_DATA_SO_STATISTICS"/> structure.
        /// </summary>
        D3D11_QUERY_SO_STATISTICS_STREAM0,

        /// <summary>
        /// Determines whether or not the stream 0 output buffers overflowed
        /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
        /// <see cref="ID3D11DeviceContext.GetData"/> returns a <see cref="BOOL"/> - 
        /// <see cref="TRUE"/> meaning there was an overflow, <see cref="FALSE"/> meaning there was not an overflow.
        /// If streaming output writes to multiple buffers, and one of the buffers overflows, then it will stop writing to all the output buffers.
        /// When an overflow is detected by Direct3D it is prevented from happening - no memory is corrupted.
        /// This predication may be used in conjunction with an SO_STATISTICS query
        /// so that when an overflow occurs the SO_STATISTIC query will let the application know how much memory was needed to prevent an overflow.
        /// </summary>
        D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM0,

        /// <summary>
        /// Get streaming output statistics for stream 1, such as the number of primitives streamed out
        /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
        /// <see cref="ID3D11DeviceContext.GetData"/> will return a <see cref="D3D11_QUERY_DATA_SO_STATISTICS"/> structure.
        /// </summary>
        D3D11_QUERY_SO_STATISTICS_STREAM1,

        /// <summary>
        /// Determines whether or not the stream 1 output buffers overflowed
        /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
        /// <see cref="ID3D11DeviceContext.GetData"/> returns a <see cref="BOOL"/> - 
        /// <see cref="TRUE"/> meaning there was an overflow, <see cref="FALSE"/> meaning there was not an overflow.
        /// If streaming output writes to multiple buffers, and one of the buffers overflows, then it will stop writing to all the output buffers.
        /// When an overflow is detected by Direct3D it is prevented from happening - no memory is corrupted.
        /// This predication may be used in conjunction with an SO_STATISTICS query
        /// so that when an overflow occurs the SO_STATISTIC query will let the application know how much memory was needed to prevent an overflow.
        /// </summary>
        D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM1,

        /// <summary>
        /// Get streaming output statistics for stream 2, such as the number of primitives streamed out
        /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
        /// <see cref="ID3D11DeviceContext.GetData"/> will return a <see cref="D3D11_QUERY_DATA_SO_STATISTICS"/> structure.
        /// </summary>
        D3D11_QUERY_SO_STATISTICS_STREAM2,

        /// <summary>
        /// Determines whether or not the stream 2 output buffers overflowed
        /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
        /// <see cref="ID3D11DeviceContext.GetData"/> returns a <see cref="BOOL"/> - 
        /// <see cref="TRUE"/> meaning there was an overflow, <see cref="FALSE"/> meaning there was not an overflow.
        /// If streaming output writes to multiple buffers, and one of the buffers overflows, then it will stop writing to all the output buffers.
        /// When an overflow is detected by Direct3D it is prevented from happening - no memory is corrupted.
        /// This predication may be used in conjunction with an SO_STATISTICS query
        /// so that when an overflow occurs the SO_STATISTIC query will let the application know how much memory was needed to prevent an overflow.
        /// </summary>
        D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM2,

        /// <summary>
        /// Get streaming output statistics for stream 3, such as the number of primitives streamed out
        /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
        /// <see cref="ID3D11DeviceContext.GetData"/> will return a <see cref="D3D11_QUERY_DATA_SO_STATISTICS"/> structure.
        /// </summary>
        D3D11_QUERY_SO_STATISTICS_STREAM3,

        /// <summary>
        /// Determines whether or not the stream 3 output buffers overflowed
        /// in between <see cref="ID3D11DeviceContext.Begin"/> and <see cref="ID3D11DeviceContext.End"/>.
        /// <see cref="ID3D11DeviceContext.GetData"/> returns a <see cref="BOOL"/> - 
        /// <see cref="TRUE"/> meaning there was an overflow, <see cref="FALSE"/> meaning there was not an overflow.
        /// If streaming output writes to multiple buffers, and one of the buffers overflows, then it will stop writing to all the output buffers.
        /// When an overflow is detected by Direct3D it is prevented from happening - no memory is corrupted.
        /// This predication may be used in conjunction with an SO_STATISTICS query
        /// so that when an overflow occurs the SO_STATISTIC query will let the application know how much memory was needed to prevent an overflow.
        /// </summary>
        D3D11_QUERY_SO_OVERFLOW_PREDICATE_STREAM3
    }
}
