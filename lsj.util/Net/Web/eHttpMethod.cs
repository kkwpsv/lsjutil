using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// Http请求方法
    /// </summary>
    public enum eHttpMethod
    {
        UnParsed,
        GET,
        POST,
		PUT,
		HEAD,
		DEBUG,
		DELETE,
        UnKnown
    }
}
