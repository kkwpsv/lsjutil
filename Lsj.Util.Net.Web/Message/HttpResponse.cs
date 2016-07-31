using Lsj.Util.Net.Web.Error;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Static;
using Lsj.Util.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Cookie;

namespace Lsj.Util.Net.Web.Message
{
    /// <summary>
    /// HttpResponse
    /// </summary>
    public class HttpResponse : HttpMessageBase, IHttpResponse
    {
        bool parsefirst =false;
        /// <summary>
        /// ContentLength
        /// </summary>
        public override int ContentLength => content.Length.ConvertToInt();

        Stream IHttpMessage.Content
        {
            get
            {
                return new MemoryStream(content.ReadAll(), false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Stream content;
        /// <summary>
        /// 
        /// </summary>
        public HttpResponse()
        {
            this.content = new MemoryStream();
            this.HttpVersion = new Version(1, 1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        //Fucking Pointer.....
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
                    #region When End Header
                    if (i + 1 < count && *(ptr + 1) == ASCIIChar.CR && i + 2 < count && *(ptr + 2) == ASCIIChar.LF)
                    {
                        ptr = ptr + 2;
                        i = i + 2;
                        int length = (int)(ptr - start) + 1;
                        ParseLine(start, length - 2);
                        read += length;
                        return true;
                    }
                    #endregion When End Header
                    else
                    {
                        #region ParseHeader
                        var length = (int)(ptr - start) + 1;
                        if (!parsefirst)
                        {
                            if (!ParseFirstLine(start, length - 2))
                            {
                                return true;
                            }
                            read += length;
                        }
                        else
                        {
                            if (!ParseLine(start, length - 2))
                            {
                                this.ErrorCode = 400;
                                return true;
                            }
                            read += length;
                        }
                        #endregion ParseHeader
                        start = ptr + 1;
                    }
                }
            }
            return false;
        }

        private unsafe bool ParseFirstLine(byte* ptr, int length)
        {
            var debug = StringHelper.ReadStringFromBytePoint(ptr, length);
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
                                                    parsefirst = true;
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
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        public override void Write(byte[] buffer)
        {
            this.content.Write(buffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public override void Write(string str)
        {
            this.Headers[eHttpHeader.ContentType] = "text/html;charset=utf-8";
            this.Write(str.ConvertToBytes(Encoding.UTF8));
        }
        /// <summary>
        /// 
        /// </summary>
        public void Write304()
        {
            this.ErrorCode = 304;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetHttpHeader()
        {
            this.Headers[eHttpHeader.ContentLength] = this.ContentLength.ToString();
            var sb = new StringBuilder();
            sb.Append($"HTTP/{this.HttpVersion.ToString(2)} {ErrorCode} {SatusCode.GetStringByCode(ErrorCode)}\r\n");
            foreach (var header in Headers)
            {
                sb.Append($"{header.Key}: {header.Value}\r\n");
            }           
            if (Cookies != null)
            {
                foreach (var cookie in Cookies)
                {
                    sb.Append($"Set-Cookie: {cookie.name}={cookie.content}; Expires={cookie.expires.ToUniversalTime().ToString("r")}; domain={cookie.domain}; path=/ \r\n");
                }
            }           
            sb.Append("\r\n");
            return sb.ToString();
        }

        /// <summary>
        /// Return And Redirect
        /// </summary>
        /// <param name="str"></param>
        /// <param name="uri"></param>
        public void ReturnAndRedirect(string str, string uri)
        {
            Write(@"<script language=""javascript"" charset=""utf-8""> alert(""" + str + @""");document.location.href=""" + uri + @""";</script>");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        public void Redirect(string uri)
        {
            this.ErrorCode = 301;
            this.Headers[eHttpHeader.Location] = uri;
        }
    }
}
