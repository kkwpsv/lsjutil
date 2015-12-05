using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Lsj.Util.Net.Web.Utils;

namespace Lsj.Util.Net.Web.Request
{
    public class HttpRequestHeaders : SafeStringToStringDirectionary
    {
        public string this[eHttpRequestHeader x]
        {
            get
            {
                return this[HeaderType[x]];
            }
            internal set
            {
                this[HeaderType[x]] = value;
            }
        }
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

        public class headertype : TwoWayDictionary<string,eHttpRequestHeader>
        {
            public override string GetNullKey(eHttpRequestHeader value)
            {
                return "";
            }
            public override eHttpRequestHeader GetNullValue(string key)
            {
                return eHttpRequestHeader.Unknown;
            }
        }

        public string IfModifiedSince =>this[eHttpRequestHeader.IfModifiedSince];
        public eConnectionType Connection=>this[eHttpRequestHeader.Connection].ToLower() == "keep-alive" ? eConnectionType.KeepAlive : eConnectionType.Close;
        public Encoding AcceptCharset => acceptCharset==null?ParseAccepCharset():acceptCharset;

        private Encoding ParseAccepCharset()
        {
            var x = ParseStringArray(this[eHttpRequestHeader.AcceptCharset]);
            var result = Encoding.UTF8;
            foreach (var a in x)
            {
                if (a == "")
                {
                    continue;
                }
                try
                {
                    result = Encoding.GetEncoding(a);
                    break;
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            acceptCharset = result;
            return result;
        }


        Encoding acceptCharset;
        public int ContentLength => this[eHttpRequestHeader.ContentLength].ConvertToInt(0);
        public string[] AcceptEncoding => this[eHttpRequestHeader.AcceptEncoding].Split(',').Trim();

    }
}
