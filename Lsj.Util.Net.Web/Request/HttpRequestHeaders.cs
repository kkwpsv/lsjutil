using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Headers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Request
{
    public class HttpRequestHeaders : SafeDictionary<eHttpRequestHeader,IHeader>
    {
        public static readonly SafeDictionary<eHttpRequestHeader, IHeader> @default =new SafeDictionary<eHttpRequestHeader, IHeader>
        {
            
        };
        public static readonly headertype HeaderType = new headertype
        {
            {"Accept",eHttpRequestHeader.Accept},
            {"Accept-Charset",eHttpRequestHeader.AcceptCharset },
            {"Accept-DateTime",eHttpRequestHeader.AcceptDatetime},
            {"Accept-Encoding",eHttpRequestHeader.AcceptEncoding },
            {"Accept-Language",eHttpRequestHeader.AcceptLanguage },
            {"Authorization",eHttpRequestHeader.Authorization},

        };
        SafeDictionary<string, IHeader> UnKnownHeaders = new SafeDictionary<string, IHeader>();
        public void Add(string key,string content)
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
