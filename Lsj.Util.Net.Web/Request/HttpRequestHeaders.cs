using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Headers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Request
{
    public class HttpRequestHeaders : SafeDictionary<eHttpRequestHeader, IHeader>
    {
        public static readonly SafeDictionary<eHttpRequestHeader, IHeader> @default = new SafeDictionary<eHttpRequestHeader, IHeader>
        {
            {eHttpRequestHeader.Connection,new ConnectionHeader("Connection","close") },
            {eHttpRequestHeader.ContentLength,new IntHeader("ContentLength")},
            {eHttpRequestHeader.Host,new RawHeader("Host")},
            {eHttpRequestHeader.Cookie,new RawHeader("Cookie")},
        };
        public static readonly headertype HeaderType = new headertype
        {
            {"Accept",eHttpRequestHeader.Accept},
            {"Accept-Charset",eHttpRequestHeader.AcceptCharset},
            {"Accept-DateTime",eHttpRequestHeader.AcceptDatetime},
            {"Accept-Encoding",eHttpRequestHeader.AcceptEncoding},
            {"Accept-Language",eHttpRequestHeader.AcceptLanguage},
            {"Authorization",eHttpRequestHeader.Authorization},
            {"Cache-Control",eHttpRequestHeader.CacheControl},
            {"Connection",eHttpRequestHeader.Connection},
            {"Content-Length",eHttpRequestHeader.ContentLength },
            {"Content-MD5",eHttpRequestHeader.ContentMD5},
            {"Content-Type",eHttpRequestHeader.ContentType},
            {"Cookie",eHttpRequestHeader.Cookie},
            {"Date",eHttpRequestHeader.Date},
            {"DNT",eHttpRequestHeader.DNT},
            {"Expect",eHttpRequestHeader.Expect},
            {"From",eHttpRequestHeader.From },
            {"Host",eHttpRequestHeader.Host },
            {"If-Match",eHttpRequestHeader.IfMatch },
            {"If-Modified-Since",eHttpRequestHeader.IfModifiedSince},
            {"If-None-Match",eHttpRequestHeader.IfNoneMatch },
            {"If-Range",eHttpRequestHeader.IfRange },
            {"If-Unmodified-Since",eHttpRequestHeader.IfUnmodifiedSince},
            {"Max-Forwards",eHttpRequestHeader.MaxForwards},
            {"Origin",eHttpRequestHeader.Origin},
            {"Pragma",eHttpRequestHeader.Pragma },
            {"Proxy-Authorization",eHttpRequestHeader.ProxyAuthorization},
            {"Range",eHttpRequestHeader.Range},
            {"Referer",eHttpRequestHeader.Referer},
            {"Referrer",eHttpRequestHeader.Referer},
            {"TE",eHttpRequestHeader.TE},
            {"Upgrade",eHttpRequestHeader.Upgrade},
            {"User-Agent",eHttpRequestHeader.UserAgent},
            {"Via",eHttpRequestHeader.Via},
            {"Warning",eHttpRequestHeader.Warning},
            {"X-Requested-With",eHttpRequestHeader.XRequestedWith}
        };
        SafeDictionary<string, IHeader> UnKnownHeaders = new SafeDictionary<string, IHeader>();
        public void Add(string key, string content)
        {
            var x = HeaderType[key];
            if (x != eHttpRequestHeader.Unknown)
            {
                this[x] = RawHeader.CreateHeader(x, key, content);
            }
            else
            {
                UnKnownHeaders[key] = RawHeader.CreateHeader(x, key, content);
            }
        }
        public override IHeader GetNullValue(eHttpRequestHeader key)
        {
            return @default[key];
        }
        public class headertype : SafeDictionary<string, eHttpRequestHeader>
        {
            public override eHttpRequestHeader GetNullValue(string key)
            {
                return eHttpRequestHeader.Unknown;
            }
        }
    }
}
