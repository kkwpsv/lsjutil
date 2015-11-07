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
        }

        public string Name
        {
            protected set;
            get;
        }
        public RawHeader(string name,string content)
        {
            this.Name = name;
            this.Content = content;
        }
        public RawHeader(string name) : this(name, "")
        {
        }
        public static IHeader CreateHeader(eHttpRequestHeader type, string key, string content)
        {
            switch (type)
            {
                case eHttpRequestHeader.Accept:
                case eHttpRequestHeader.AcceptCharset:
                case eHttpRequestHeader.AcceptEncoding:
                case eHttpRequestHeader.AcceptLanguage:
                    return new StringArrayHeader(key, content);

                case eHttpRequestHeader.AcceptDatetime:
                case eHttpRequestHeader.Date:
                case eHttpRequestHeader.IfModifiedSince:
                case eHttpRequestHeader.IfUnmodifiedSince:
                    return new DateTimeHeader(key, content);

                case eHttpRequestHeader.Connection:
                    return new ConnectionHeader(key, content);

                case eHttpRequestHeader.ContentLength:
                case eHttpRequestHeader.DNT:
                case eHttpRequestHeader.MaxForwards:
                    return new IntHeader(key, content);

                default:
                    return new RawHeader(key, content);
            }
        }
        public static implicit operator string(RawHeader x)
        {
            return x.Content;
        }
    }
}
