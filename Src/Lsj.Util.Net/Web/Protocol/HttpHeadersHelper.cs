using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Net.Web.Protocol
{

    /// <summary>
    /// HttpHeader Helper
    /// </summary>
    public static class HttpHeadersHelper
    {
        /// <summary>
        /// Get Name By Header
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public static string GetNameByHeader(HttpHeaders header)
        {

            switch (header)
            {
                case HttpHeaders.Accept:
                    return "Accept";
                case HttpHeaders.AcceptCharset:
                    return "Accept-Charset";
                case HttpHeaders.AcceptEncoding:
                    return "Accept-Encoding";
                case HttpHeaders.AcceptLanguage:
                    return "Accept-Language";
                case HttpHeaders.AcceptRanges:
                    return "Accept-Ranges";
                case HttpHeaders.Age:
                    return "Age";
                case HttpHeaders.Allow:
                    return "Allow";
                case HttpHeaders.Authorization:
                    return "Authorization";
                case HttpHeaders.CacheControl:
                    return "Cache-Control";
                case HttpHeaders.Clientip:
                    return "Client-ip";
                case HttpHeaders.Connection:
                    return "Connection";
                case HttpHeaders.ContentEncoding:
                    return "Content-Encoding";
                case HttpHeaders.ContentLanguage:
                    return "Content-Language";
                case HttpHeaders.ContentLength:
                    return "Content-Length";
                case HttpHeaders.ContentLocation:
                    return "Content-Location";
                case HttpHeaders.ContentMD5:
                    return "Content-MD5";
                case HttpHeaders.ContentRange:
                    return "Content-Range";
                case HttpHeaders.ContentType:
                    return "Content-Type";
                case HttpHeaders.Cookie:
                    return "Cookie";
                case HttpHeaders.Date:
                    return "Date";
                case HttpHeaders.ETag:
                    return "ETag";
                case HttpHeaders.Expect:
                    return "Expect";
                case HttpHeaders.Expires:
                    return "Expires";
                case HttpHeaders.From:
                    return "From";
                case HttpHeaders.Host:
                    return "Host";
                case HttpHeaders.IfMatch:
                    return "If-Match";
                case HttpHeaders.IfModifiedSince:
                    return "If-Modified-Since";
                case HttpHeaders.IfNoneMatch:
                    return "If-None-Match";
                case HttpHeaders.IfRange:
                    return "If-Range";
                case HttpHeaders.IfUnmodifiedSince:
                    return "If-Unmodified-Since";
                case HttpHeaders.LastModified:
                    return "Last-Modified";
                case HttpHeaders.Location:
                    return "Location";
                case HttpHeaders.MaxForwards:
                    return "Max-Forwards";
                case HttpHeaders.Pragma:
                    return "Pragma";
                case HttpHeaders.ProxyAuthenticate:
                    return "Proxy-Authenciate";
                case HttpHeaders.ProxyAuthorization:
                    return "Proxy-Authorization";
                case HttpHeaders.ProxyConnection:
                    return "Proxy-Connection";
                case HttpHeaders.Range:
                    return "Range";
                case HttpHeaders.Referer:
                    return "Referer";
                case HttpHeaders.RetryAfter:
                    return "Retry-After";
                case HttpHeaders.Server:
                    return "Server";
                case HttpHeaders.SetCookie:
                    return "Set-Cookie";
                case HttpHeaders.TE:
                    return "TE";
                case HttpHeaders.Trailer:
                    return "Trailer";
                case HttpHeaders.TransferEncoding:
                    return "Transfer-Encoding";
                case HttpHeaders.Upgrade:
                    return "Upgrade";
                case HttpHeaders.UserAgent:
                    return "User-Agent";
                case HttpHeaders.Vary:
                    return "Vary";
                case HttpHeaders.Via:
                    return "Via";
                case HttpHeaders.Warning:
                    return "Warning";
                case HttpHeaders.WWWAuthenticate:
                    return "WWWAuthenicate";
                case HttpHeaders.XCache:
                    return "X-Cache";
                default:
                    return "Unknown";
            }
        }
    }
}
