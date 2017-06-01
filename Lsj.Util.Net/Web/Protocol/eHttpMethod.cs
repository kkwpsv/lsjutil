#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Protocol
#else
namespace Lsj.Util.Net.Web.Protocol
#endif
{
    /// <summary>
    /// Http请求方法
    /// </summary>
    public enum eHttpMethod : byte
    {
        /// <summary>
        /// UnParsed
        /// </summary>
        UnParsed,
        /// <summary>
        /// GET
        /// </summary>
        GET,
        /// <summary>
        /// HEAD
        /// </summary>
		HEAD,
        /// <summary>
        /// POST
        /// </summary>
        POST,
        /// <summary>
        /// PUT
        /// </summary>
		PUT,
        /// <summary>
        /// TRACE
        /// </summary>
        TRACE,
        /// <summary>
        /// OPTIONS
        /// </summary>
        OPTIONS,
        /// <summary>
        /// DELETE
        /// </summary>
        DELETE,
        
    }
}
