#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Protocol
#else
namespace Lsj.Util.Net.Web.Protocol
#endif
{
    /// <summary>
    /// HttpHeader
    /// </summary>
    public enum eHttpHeader : byte
    {
        /// <summary>
        /// UnKnown
        /// </summary>
        Unknown,
        /// <summary>
        /// Accept
        /// </summary>
        Accept,
        /// <summary>
        /// Accept-Charset
        /// </summary>
        AcceptCharset,
        /// <summary>
        /// Accept-Encoding
        /// </summary>
        AcceptEncoding,
        /// <summary>
        /// Accept-Language
        /// </summary>
        AcceptLanguage,
        /// <summary>
        /// Accept-Ranges
        /// </summary>
        AcceptRanges,
        /// <summary>
        /// Age
        /// </summary>
        Age,
        /// <summary>
        /// Allow
        /// </summary>
        Allow,
        /// <summary>
        /// Authorization
        /// </summary>
        Authorization,
        /// <summary>
        /// Cache-Control
        /// </summary>
        CacheControl,
        /// <summary>
        /// Clientip
        /// </summary>
        Clientip,
        /// <summary>
        /// Connection
        /// </summary>
        Connection,
        /// <summary>
        /// Content-Encoding
        /// </summary>
        ContentEncoding,
        /// <summary>
        /// Content-Language
        /// </summary>
        ContentLanguage,
        /// <summary>
        /// Content-Length
        /// </summary>
        ContentLength,
        /// <summary>
        /// Content-Location
        /// </summary>
        ContentLocation,
        /// <summary>
        /// Content-MD5
        /// </summary>
        ContentMD5,
        /// <summary>
        /// Content-Range
        /// </summary>
        ContentRange,
        /// <summary>
        /// Content-Type
        /// </summary>
        ContentType,
        /// <summary>
        /// Cookie
        /// </summary>
        Cookie,
        /// <summary>
        /// Date
        /// </summary>
        Date,
        /// <summary>
        /// Etag
        /// </summary>
        ETag,
        /// <summary>
        /// Expect
        /// </summary>
        Expect,
        /// <summary>
        /// Expires
        /// </summary>
        Expires,
        /// <summary>
        /// From
        /// </summary>
        From,
        /// <summary>
        /// Host
        /// </summary>
        Host,
        /// <summary>
        /// If-Match
        /// </summary>
        IfMatch,
        /// <summary>
        /// If-Modified-Since
        /// </summary>
        IfModifiedSince,
        /// <summary>
        /// If-None-Match
        /// </summary>
        IfNoneMatch,
        /// <summary>
        /// If-Range
        /// </summary>
        IfRange,
        /// <summary>
        /// If-UnModified-Since
        /// </summary>
        IfUnmodifiedSince,
        /// <summary>
        /// Last-Modified
        /// </summary>
        LastModified,
        /// <summary>
        /// Location
        /// </summary>
        Location,
        /// <summary>
        /// MaxForWards
        /// </summary>
        MaxForwards,
        /// <summary>
        /// Pragma
        /// </summary>
        Pragma,
        /// <summary>
        /// ProxyAuthenticate
        /// </summary>
        ProxyAuthenticate,
        /// <summary>
        /// ProxyAuthorization
        /// </summary>
        ProxyAuthorization,
        /// <summary>
        /// ProxyConnection
        /// </summary>
        ProxyConnection,
        /// <summary>
        /// Range
        /// </summary>
        Range,
        /// <summary>
        /// Referer
        /// </summary>
        Referer,
        /// <summary>
        /// Retry-After
        /// </summary>
        RetryAfter,
        /// <summary>
        /// Server
        /// </summary>
        Server,
        /// <summary>
        /// Set-Cookie
        /// </summary>
        SetCookie,
        /// <summary>
        /// TE
        /// </summary>
        TE,
        /// <summary>
        /// Trailer
        /// </summary>
        Trailer,
        /// <summary>
        /// Transfer-Encoding
        /// </summary>
        TransferEncoding,
        /// <summary>
        /// Upgrade
        /// </summary>
        Upgrade,
        /// <summary>
        /// User-Agent
        /// </summary>
        UserAgent,
        /// <summary>
        /// Via
        /// </summary>
        Via,
        /// <summary>
        /// Vary
        /// </summary>
        Vary,
        /// <summary>
        /// Warning
        /// </summary>
        Warning,
        /// <summary>
        /// WWWAuthenicate
        /// </summary>
        WWWAuthenticate,
        /// <summary>
        /// X-Cache
        /// </summary>
        XCache,
    }
}
