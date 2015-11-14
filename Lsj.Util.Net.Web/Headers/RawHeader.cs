using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Headers
{
    public class RawHeader : IHeader
    {
        public string Content
        {
            protected set;
            get;
        } = "";
        public RawHeader(string content)
        {
            this.Content = content;
        }
        public RawHeader() : this("")
        {
        }
        public static IHeader CreateHeader(eHttpRequestHeader type, string content)
        {
            switch (type)
            {
                case eHttpRequestHeader.Accept:
                case eHttpRequestHeader.AcceptCharset:
                case eHttpRequestHeader.AcceptEncoding:
                case eHttpRequestHeader.AcceptLanguage:
                    return new StringArrayHeader(content);

                case eHttpRequestHeader.AcceptDatetime:
                case eHttpRequestHeader.Date:
                case eHttpRequestHeader.IfModifiedSince:
                case eHttpRequestHeader.IfUnmodifiedSince:
                    return new DateTimeHeader(content);

                case eHttpRequestHeader.Connection:
                    return new ConnectionHeader(content);

                case eHttpRequestHeader.ContentLength:
                case eHttpRequestHeader.DNT:
                case eHttpRequestHeader.MaxForwards:
                    return new IntHeader(content);

                default:
                    return new RawHeader(content);
            }
        }
        public static IHeader CreateHeader(eHttpResponseHeader type,string content)
        {
            switch (type)
            {
                case eHttpResponseHeader.Age:
                case eHttpResponseHeader.ContentLength:
                    return new IntHeader(content);
                case eHttpResponseHeader.Date:
                case eHttpResponseHeader.Expires:
                    return new DateTimeHeader(content);

                default:
                    return new RawHeader(content);
            }
        }
        public static implicit operator string(RawHeader x)
        {
            return x.Content;
        }
    }
}
