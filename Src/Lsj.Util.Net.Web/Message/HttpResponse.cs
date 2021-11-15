using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Static;
using Lsj.Util.Text;
using System.IO;
using System.Text;

namespace Lsj.Util.Net.Web.Message
{
    /// <summary>
    /// HttpResponse
    /// </summary>
    public class HttpResponse : HttpMessageBase, IHttpResponse
    {
        /// <summary>
        /// Content
        /// </summary>
        protected Stream _content;

        /// <summary>
        /// ContentLength
        /// </summary>
        public virtual long ContentLength => _content.Length;

        /// <summary>
        /// Content
        /// </summary>
        public override Stream Content
        {
            get
            {
                _content.Seek(0, SeekOrigin.Begin);
                return _content;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Web.Message.HttpResponse"/> class.
        /// </summary>
        public HttpResponse()
        {
            _content = new MemoryStream();
            HttpVersion = new Version(1, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        unsafe protected override bool InternalRead(byte* pts, int offset, int count, ref int read)
        {
            read = 0;
            byte* start = pts;
            byte* ptr = pts;
            for (int i = offset; i < count; i++, ptr++)
            {
                if (*ptr == ASCIIChar.CR && (++i) < count && *(++ptr) == ASCIIChar.LF)
                {
                    if (ptr - start == 2)
                    {
                        read += 2;
                        return true;
                    }
                    int length = (int)(ptr - start) + 1;
                    bool IsEnd = false;

                    if (i + 1 < count && *(ptr + 1) == ASCIIChar.CR && i + 2 < count && *(ptr + 2) == ASCIIChar.LF)
                    {
                        IsEnd = true;
                    }

                    if (!_parsefirst)
                    {
                        if (!ParseFirstLine(start, length - 2))
                        {
                            return true;
                        }
                        read += length;
                    }
                    else
                    {
                        if (!ParseLine(start, length - 2, out var errorCode))
                        {
                            ErrorCode = errorCode;
                            return true;
                        }
                        read += length;
                    }


                    if (!IsEnd)
                    {
                        start = ptr + 1;
                    }
                    else
                    {
                        ptr = ptr + 2;
                        i = i + 2;

                        return true;
                    }
                }
            }
            return false;
        }

        bool _parsefirst = false;

        private unsafe bool ParseFirstLine(byte* ptr, int length)
        {
            //var debug = StringHelper.ReadStringFromBytePoint(ptr, length);
            var left = length;
            if (left >= 9)
            {
                #region ParseVersion
                if (*(ptr) == ASCIIChar.H && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.P && *(++ptr) == ASCIIChar.BackSlash)
                {
                    var major = *(++ptr);
                    if (ASCIIChar.IsNumber(major))
                    {
                        major -= 48;
                        if (*(++ptr) == ASCIIChar.Point)
                        {
                            var minor = *(++ptr);
                            if (ASCIIChar.IsNumber(minor))
                            {
                                minor -= 48;
                                {
                                    this.HttpVersion = new Version(major, minor);
                                    if (left > 1 && *(++ptr) == ASCIIChar.SPACE)
                                    {
                                        left--;
                                        if (left >= 3)
                                        {
                                            left -= 3;
                                            this.ErrorCode = (*(++ptr) - 48) * 100 + (*(++ptr) - 48) * 10 + (*(++ptr) - 48);
                                            if (left > 1 && *(++ptr) == ASCIIChar.SPACE)
                                            {
                                                left--;
                                                if (left >= 1)
                                                {
                                                    _parsefirst = true;
                                                    return true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion ParseVersion
            }
            return false;
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <returns></returns>
        /// <param name="buffer">.</param>
        public override void Write(byte[] buffer)
        {
            _content.Write(buffer);
        }

        /// <summary>
        /// Write 
        /// </summary>
        /// <returns></returns>
        /// <param name="str"></param>
        public override void Write(string str)
        {
            if (Headers[Protocol.HttpHeaders.ContentType] == "")
            {
                Headers[Protocol.HttpHeaders.ContentType] = "text/html;charset=utf-8";
            }
            Write(str.ConvertToBytes(Encoding.UTF8));
        }

        /// <summary>
        /// Write 304
        /// </summary>
        public void Write304()
        {
            ErrorCode = 304;
        }

        /// <summary>
        /// Get HttpHeader
        /// </summary>
        /// <returns></returns>
        public override string GetHttpHeader()
        {
            var sb = new StringBuilder();
            sb.Append($"HTTP/{this.HttpVersion.ToString(2)} {ErrorCode} {StatusCodesHelper.GetStringByCode(ErrorCode)}\r\n");
            foreach (var header in Headers)
            {
                sb.Append($"{header.Key}: {header.Value}\r\n");
            }
            if (Cookies != null)
            {
                foreach (var cookie in Cookies)
                {
                    sb.Append($"Set-Cookie: {cookie.Name}={cookie.Content}; Expires={cookie.Expires.ToUniversalTime().ToString("r")}; domain={cookie.Domain}; path=/ \r\n");
                }
            }
            sb.Append("\r\n");
            return sb.ToString();
        }

        /// <summary>
        /// Return And Redirect
        /// </summary>
        /// <param name="str"></param>
        /// <param name="url"></param>
        public void ReturnAndRedirect(string str, string url)
        {
            Write(@"<script language=""javascript"" charset=""utf-8""> alert(""" + str + @""");document.location.href=""" + url + @""";</script>");
        }

        /// <summary>
        /// Redirect the specified url
        /// </summary>
        /// <returns></returns>
        /// <param name="uri"></param>
        public void Redirect(string uri)
        {
            ErrorCode = 301;
            Headers[Protocol.HttpHeaders.Location] = uri;
        }
    }
}
