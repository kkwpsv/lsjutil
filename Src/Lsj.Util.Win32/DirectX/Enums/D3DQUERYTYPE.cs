using static Lsj.Util.Win32.DirectX.Enums.D3DCREATE;
using static Lsj.Util.Win32.DirectX.Constants;
using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the query type. For information about queries, see Queries (Direct3D 9)
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dquerytype"/>
    /// </para>
    /// </summary>
    public enum D3DQUERYTYPE
    {
        /// <summary>
        /// Query for driver hints about data layout for vertex caching.
        /// </summary>
        D3DQUERYTYPE_VCACHE = 4,

        /// <summary>
        /// Query the resource manager.
        /// For this query, the device behavior flags must include <see cref="D3DCREATE_DISABLE_DRIVER_MANAGEMENT"/>.
        /// </summary>
        D3DQUERYTYPE_RESOURCEMANAGER = 5,

        /// <summary>
        /// Query vertex statistics.
        /// </summary>
        D3DQUERYTYPE_VERTEXSTATS = 6,

        /// <summary>
        /// Query for any and all asynchronous events that have been issued from API calls.
        /// </summary>
        D3DQUERYTYPE_EVENT = 8,

        /// <summary>
        /// An occlusion query returns the number of pixels (or samples when multisampling is enabled) that pass z-testing.
        /// These pixels/samples are for primitives drawn between the issue of <see cref="D3DISSUE_BEGIN"/> and <see cref="D3DISSUE_END"/>.
        /// This enables an application to check the occlusion result against 0.
        /// Zero is fully occluded, which means the pixels/samples are not visible from the current camera position.
        /// To get the number of pixels when a multisampled render target is used, the result should be divided by the sample count of the target.
        /// </summary>
        D3DQUERYTYPE_OCCLUSION = 9,

        /// <summary>
        /// Returns a 64-bit timestamp.
        /// </summary>
        D3DQUERYTYPE_TIMESTAMP = 10,

        /// <summary>
        /// Use this query to notify an application if the counter frequency has changed from the <see cref="D3DQUERYTYPE_TIMESTAMP"/>.
        /// </summary>
        D3DQUERYTYPE_TIMESTAMPDISJOINT = 11,

        /// <summary>
        /// This query result is <see cref="TRUE"/> if the values from <see cref="D3DQUERYTYPE_TIMESTAMP"/> queries
        /// cannot be guaranteed to be continuous throughout the duration of the <see cref="D3DQUERYTYPE_TIMESTAMPDISJOINT"/> query.
        /// Otherwise, the query result is <see cref="FALSE"/>.
        /// </summary>
        D3DQUERYTYPE_TIMESTAMPFREQ = 12,

        /// <summary>
        /// Percent of time processing pipeline data.
        /// </summary>
        D3DQUERYTYPE_PIPELINETIMINGS = 13,

        /// <summary>
        /// Percent of time processing data in the driver.
        /// </summary>
        D3DQUERYTYPE_INTERFACETIMINGS = 14,

        /// <summary>
        /// Percent of time processing vertex shader data.
        /// </summary>
        D3DQUERYTYPE_VERTEXTIMINGS = 15,

        /// <summary>
        /// Percent of time processing pixel shader data.
        /// </summary>
        D3DQUERYTYPE_PIXELTIMINGS = 16,

        /// <summary>
        /// Throughput measurement comparisons for help in understanding the performance of an application.
        /// </summary>
        D3DQUERYTYPE_BANDWIDTHTIMINGS = 17,

        /// <summary>
        /// Measure the cache hit-rate performance for textures and indexed vertices.
        /// </summary>
        D3DQUERYTYPE_CACHEUTILIZATION = 18,

        /// <summary>
        /// Efficiency of memory allocation contained in a <see cref="D3DMEMORYPRESSURE"/> structure.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// <see cref="D3DQUERYTYPE_MEMORYPRESSURE"/> is only available in Direct3D9Ex running on Windows 7 (or more current operating system).
        /// </summary>
        D3DQUERYTYPE_MEMORYPRESSURE = 19
    }
}
