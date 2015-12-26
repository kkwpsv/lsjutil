using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Lsj.Util.Net.Web.Utils;

namespace Lsj.Util.Net.Web.Message
{
    public class HttpHeaders : SafeStringToStringDirectionary
    {
        public string this[eHttpHeader x]
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
            {"Accept",eHttpHeader.Accept},
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
