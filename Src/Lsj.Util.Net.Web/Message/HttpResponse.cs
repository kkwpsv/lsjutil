using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Static;
using Lsj.Util.Text;
using System;
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

        bool _parsefirst = false;
        bool _parseHeader = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        unsafe protected override bool InternalRead(Span<byte> buffer, out int read)
        {
            read = 0;
            if (_parseHeader)
            {
                return true;
            }
            var start = 0;
            var current = 0;
            for (int i = 0; i < buffer.Length; i++, current++)
            {
                if (buffer[current] == ASCIIChar.CR && (++i) < buffer.Length && buffer[++current] == ASCIIChar.LF)
                {
                    if (current - start == 2)
                    {
                        read += 2;
                        return true;
                    }
                    int length = (int)(current - start) + 1;
                    _parseHeader = false;

                    if (i + 1 < buffer.Length && buffer[current + 1] == ASCIIChar.CR && i + 2 < buffer.Length && buffer[current + 2] == ASCIIChar.LF)
                    {
                        _parseHeader = true;
                    }

                    if (!_parsefirst)
                    {
                        if (!ParseFirstLine(buffer.Slice(start, length - 2)))
                        {
                            return true;
                        }
                        read += length;
                    }
                    else
                    {
                        if (!ParseLine(buffer.Slice(start, length - 2), out var errorCode))
                        {
                            ErrorCode = errorCode;
                            return true;
                        }
                        read += length;
                    }


                    if (!_parseHeader)
                    {
                        start = current + 1;
                    }
                    else
                    {
                        current = current + 2;
                        i = i + 2;

                        return true;
                    }
                }
            }
            return false;
        }

        private unsafe bool ParseFirstLine(Span<byte> buffer)
        {
            var current = 0;
            var left = buffer.Length;
            if (left >= 9)
            {
                #region ParseVersion
                if (buffer[current] == ASCIIChar.H && buffer[++current] == ASCIIChar.T && buffer[++current] == ASCIIChar.T && buffer[++current] == ASCIIChar.P && buffer[++current] == ASCIIChar.BackSlash)
                {
                    var major = buffer[++current];
                    if (ASCIIChar.IsNumber(major))
                    {
                        major -= 48;
                        if (buffer[++current] == ASCIIChar.Point)
                        {
                            var minor = buffer[++current];
                            if (ASCIIChar.IsNumber(minor))
                            {
                                minor -= 48;
                                {
                                    this.HttpVersion = new Version(major, minor);
                                    if (left > 1 && buffer[++current] == ASCIIChar.SPACE)
                                    {
                                        left--;
                                        if (left >= 3)
                                        {
                                            left -= 3;
                                            this.ErrorCode = (buffer[++current] - 48) * 100 + (buffer[++current] - 48) * 10 + (buffer[++current] - 48);
                                            if (left > 1 && buffer[++current] == ASCIIChar.SPACE)
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
        public override void WriteContent(byte[] buffer)
        {
            _content.Write(buffer);
        }

        /// <summary>
        /// Write 
        /// </summary>
        /// <returns></returns>
        /// <param name="str"></param>
        public override void WriteContent(string str)
        {
            if (Headers[Protocol.HttpHeaders.ContentType] == "")
            {
                Headers[Protocol.HttpHeaders.ContentType] = "text/html;charset=utf-8";
            }
            WriteContent(str.ConvertToBytes(Encoding.UTF8));
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
        public override string GetHttp1HeaderString()
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
            WriteContent(@"<script language=""javascript"" charset=""utf-8""> alert(""" + str + @""");document.location.href=""" + url + @""";</script>");
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
