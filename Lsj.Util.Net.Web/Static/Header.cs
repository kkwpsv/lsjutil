using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Static
{
    internal static class Header
    {
        public static string GetNameByHeader(eHttpHeader header)
        {

            switch(header)
            {
                case eHttpHeader.Accept:
                    return "Accept";
                case eHttpHeader.AcceptCharset:
                    return "Accept-Charset";
                case eHttpHeader.AcceptEncoding:
                    return "Accept-Encoding";
                case eHttpHeader.AcceptLanguage:
                    return "Accept-Language";
                case eHttpHeader.AcceptRanges:
                    return "Accept-Ranges";
                case eHttpHeader.Age:
                    return "Age";
                case eHttpHeader.Allow:
                    return "Allow";
                case eHttpHeader.Authorization:
                    return "Authorization";
                case eHttpHeader.CacheControl:
                    return "Cache-Control";
                case eHttpHeader.Clientip:
                    return "Client-ip";
                case eHttpHeader.Connection:
                    return "Connection";
                case eHttpHeader.ContentEncoding:
                    return "Content-Encoding";
                case eHttpHeader.ContentLanguage:
                    return "Content-Language";
                case eHttpHeader.ContentLength:
                    return "Content-Length";
                case eHttpHeader.ContentLocation:
                    return "Content-Location";
                case eHttpHeader.ContentMD5:
                    return "Content-MD5";
                case eHttpHeader.ContentRange:
                    return "Content-Range";
                case eHttpHeader.ContentType:
                    return "Content-Type";
                case eHttpHeader.Cookie:
                    return "Cookie";
                case eHttpHeader.Date:
                    return "Date";
                case eHttpHeader.ETag:
                    return "ETag";
                case eHttpHeader.Expect:
                    return "Expect";
                case eHttpHeader.Expires:
                    return "Expires";
                case eHttpHeader.From:
                    return "From";
                case eHttpHeader.Host:
                    return "Host";
                case eHttpHeader.IfMatch:
                    return "If-Match";
                case eHttpHeader.IfModifiedSince:
                    return "If-Modified-Since";
                case eHttpHeader.IfNoneMatch:
                    return "If-None-Match";
                case eHttpHeader.IfRange:
                    return "If-Range";
                case eHttpHeader.IfUnmodifiedSince:
                    return "If-Unmodified-Since";
                case eHttpHeader.LastModified:
                    return "Last-Modified";
                case eHttpHeader.Location:
                    return "Location";
                case eHttpHeader.MaxForwards:
                    return "Max-Forwards";
                case eHttpHeader.Pragma:
                    return "Pragma";
                case eHttpHeader.ProxyAuthenticate:
                    return "Proxy-Authenciate";
                case eHttpHeader.ProxyAuthorization:
                    return "Proxy-Authorization";
                case eHttpHeader.ProxyConnection:
                    return "Proxy-Connection";
                case eHttpHeader.Range:
                    return "Range";
                case eHttpHeader.Referer:
                    return "Referer";
                case eHttpHeader.RetryAfter:
                    return "Retry-After";
                case eHttpHeader.Server:
                    return "Server";
                case eHttpHeader.SetCookie:
                    return "Set-Cookie";
                case eHttpHeader.TE:
                    return "TE";
                case eHttpHeader.Trailer:
                    return "Trailer";
                case eHttpHeader.TransferEncoding:
                    return "Transfer-Encoding";
                case eHttpHeader.Upgrade:
                    return "Upgrade";
                case eHttpHeader.UserAgent:
                    return "User-Agent";
                case eHttpHeader.Vary:
                    return "Vary";
                case eHttpHeader.Via:
                    return "Via";
                case eHttpHeader.Warning:
                    return "Warning";
                case eHttpHeader.WWWAuthenticate:
                    return "WWWAuthenicate";
                case eHttpHeader.XCache:
                    return "X-Cache";
                default:
                    return "Unknown";
            }
        }
    }
}

