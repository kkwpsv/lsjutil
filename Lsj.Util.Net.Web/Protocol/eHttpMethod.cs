namespace Lsj.Util.Net.Web.Protocol
{
    /// <summary>
    /// Http请求方法
    /// </summary>
    public enum eHttpMethod:byte
    {
        UnParsed,
        GET,
        POST,
		PUT,
		HEAD,
		DEBUG,
		DELETE,
        OPTIONS,
        TRACE,
        PATCH,
        UnKnown
    }
}
