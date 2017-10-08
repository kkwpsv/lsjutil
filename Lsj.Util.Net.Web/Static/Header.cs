using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Protocol;

namespace Lsj.Util.Net.Web.Static

{
    internal static class Header
    {
        public static string GetNameByHeader(HttpHeader header)
        {

            switch (header)
            {
                case HttpHeader.Accept:
                    return "Accept";
                case HttpHeader.AcceptCharset:
                    return "Accept-Charset";
                case HttpHeader.AcceptEncoding:
                    return "Accept-Encoding";
                case HttpHeader.AcceptLanguage:
                    return "Accept-Language";
                case HttpHeader.AcceptRanges:
                    return "Accept-Ranges";
                case HttpHeader.Age:
                    return "Age";
                case HttpHeader.Allow:
                    return "Allow";
                case HttpHeader.Authorization:
                    return "Authorization";
                case HttpHeader.CacheControl:
                    return "Cache-Control";
                case HttpHeader.Clientip:
                    return "Client-ip";
                case HttpHeader.Connection:
                    return "Connection";
                case HttpHeader.ContentEncoding:
                    return "Content-Encoding";
                case HttpHeader.ContentLanguage:
                    return "Content-Language";
                case HttpHeader.ContentLength:
                    return "Content-Length";
                case HttpHeader.ContentLocation:
                    return "Content-Location";
                case HttpHeader.ContentMD5:
                    return "Content-MD5";
                case HttpHeader.ContentRange:
                    return "Content-Range";
                case HttpHeader.ContentType:
                    return "Content-Type";
                case HttpHeader.Cookie:
                    return "Cookie";
                case HttpHeader.Date:
                    return "Date";
                case HttpHeader.ETag:
                    return "ETag";
                case HttpHeader.Expect:
                    return "Expect";
                case HttpHeader.Expires:
                    return "Expires";
                case HttpHeader.From:
                    return "From";
                case HttpHeader.Host:
                    return "Host";
                case HttpHeader.IfMatch:
                    return "If-Match";
                case HttpHeader.IfModifiedSince:
                    return "If-Modified-Since";
                case HttpHeader.IfNoneMatch:
                    return "If-None-Match";
                case HttpHeader.IfRange:
                    return "If-Range";
                case HttpHeader.IfUnmodifiedSince:
                    return "If-Unmodified-Since";
                case HttpHeader.LastModified:
                    return "Last-Modified";
                case HttpHeader.Location:
                    return "Location";
                case HttpHeader.MaxForwards:
                    return "Max-Forwards";
                case HttpHeader.Pragma:
                    return "Pragma";
                case HttpHeader.ProxyAuthenticate:
                    return "Proxy-Authenciate";
                case HttpHeader.ProxyAuthorization:
                    return "Proxy-Authorization";
                case HttpHeader.ProxyConnection:
                    return "Proxy-Connection";
                case HttpHeader.Range:
                    return "Range";
                case HttpHeader.Referer:
                    return "Referer";
                case HttpHeader.RetryAfter:
                    return "Retry-After";
                case HttpHeader.Server:
                    return "Server";
                case HttpHeader.SetCookie:
                    return "Set-Cookie";
                case HttpHeader.TE:
                    return "TE";
                case HttpHeader.Trailer:
                    return "Trailer";
                case HttpHeader.TransferEncoding:
                    return "Transfer-Encoding";
                case HttpHeader.Upgrade:
                    return "Upgrade";
                case HttpHeader.UserAgent:
                    return "User-Agent";
                case HttpHeader.Vary:
                    return "Vary";
                case HttpHeader.Via:
                    return "Via";
                case HttpHeader.Warning:
                    return "Warning";
                case HttpHeader.WWWAuthenticate:
                    return "WWWAuthenicate";
                case HttpHeader.XCache:
                    return "X-Cache";
                default:
                    return "Unknown";
            }
        }
    }
}

