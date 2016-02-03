using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Cookie;
using Lsj.Util.Net.Web.Post;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Website;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util;
using Lsj.Util.Net.Web.Static;

namespace Lsj.Util.Net.Web.Message
{
    public class HttpRequest:IHttpMessage
    {
        public HttpRequest()
        {
        }
        internal HttpRequest(HttpClient client)
        {
            this.client = client;
        }

        internal HttpClient client
        {
            get;
            private set;
        }
        internal HttpWebsite website
        {
            get;
            set;
        } = HttpWebsite.InternalWebsite;
        public eHttpMethod Method
        {
            get;
            set;
        } = eHttpMethod.UnParsed;
        public URI Uri
        {
            get;
            private set;
        }
        public HttpHeaders Headers
        {
            get;
        } = new HttpHeaders();
        public int ErrorCode
        {
            get;
            set;
        } = 200;
        public int ExtraErrorCode
        {
            get;
            set;
        } = 0;
        public bool IsError => ErrorCode >= 400;
        bool m_IsCompete = false;
        public bool IsComplete
        {
            get
            {
                return IsError || m_IsCompete;
            }
            private set
            {
                m_IsCompete = value;
            }
        }
        public Version HttpVersion
        {
            get;
            set;
        } = new Version(1, 0);
        public byte[] ContentBytes
        {
            get;
            private set;
        } = new byte[0];
        public HttpCookies Cookies
        {
            get;
            set;
        }
        /*
               public byte[] PostBytes
               {
                   get; private set;
               } = new byte[] { };
               public SafeStringToStringDirectionary QueryString
               {
                   get;
               } = new SafeStringToStringDirectionary();
               
               public HttpSession Session {
                   get
                   {
                       var str = Cookies["SessionID"].content;
                       if (client.website == null)
                       {
                           return new HttpSession();
                       }
                       if (str == ""  || client.website.Session[str] == null)
                       {
                           str = client.website.Session.New();
                       }
                       return client.website.Session[str];
                   }
               }*/

        bool startpostcontent = false;
        long contentindex = 0;
        byte[] left;
        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        public void Read(byte[] buffer) => Read(buffer, buffer.Length);
        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        /// 
        public void Read(byte[] buffer, long count) => InternalRead(buffer, count);
        unsafe void InternalRead(byte[] buffer, long count)
        {
            if (left != null && left.Length > 0)
            {
                var length = left.Length + count;
                if (length > int.MaxValue)
                {
                    //to do 
                }
                else
                {
                    byte* pts = stackalloc byte[(int)length];
                    byte* ptr = pts;
                    UnsafeHelper.Copy(left, ptr, left.Length);
                    UnsafeHelper.Copy(buffer, ptr, count);
                    InternalRead(pts, length);
                }         
            }
            else
            {
                fixed (byte* pts = buffer)
                {
                    InternalRead(pts, count);
                }
            }
        } 
        unsafe void InternalRead(byte* pts, long count)
        {
            byte* start = pts;
            byte* ptr = pts;
            for (int i = 0; i < count; i++,ptr++)
            {
                if (!startpostcontent)
                {
                    if (*ptr == ASCIIChar.CR && (++i) < count && *(++ptr) == ASCIIChar.LF)
                    {
                        #region When End Header
                        if (++i < count && *(++ptr) == ASCIIChar.CR && ++i < count && *(++ptr) == ASCIIChar.LF)
                        {
                            var length = ptr - start - 4;
                            ParseLine(start,length);
                            startpostcontent = true;
                            var contentlength = Headers[eHttpHeader.ContentLength].ConvertToInt(0);
                            if (contentlength != 0)
                            {
                                this.ContentBytes = new byte[contentlength];                               
                                ptr++;
                                i++;
                            }
                            else if (++i < count && *(++ptr) != 0)
                            {
                                ErrorCode = 411;
                                return;
                            }
                            else
                            {
                                break;
                            }
                        }
                        #endregion When End Header
                        else
                        {
                            #region ParseHeader
                            var length = ptr - start - 2;
                            if (this.Method == eHttpMethod.UnParsed)
                            {
                                if (!ParseFirstLine(start,length))
                                {
                                    return;
                                }
                            }
                            else
                            {
                                if (!ParseLine(start, length))
                                {
                                    return;
                                }
                            }
                            #endregion ParseHeader
                            start = ++ptr;
                            i++;
                        }
                    }
                }
                else
                {
                    // to do QuickCopy
                    fixed (byte* contentptr = ContentBytes)
                    {
                        if (contentindex < ContentBytes.Length)
                        {
                            *(contentptr + contentindex) = *ptr;
                            contentindex++;
                        }
                    }
                }

            }
            if (startpostcontent&&contentindex == ContentBytes.Length)
            {
                IsComplete = true;
            }
            else if (ptr != start + count)
            {
                ptr++;
                var length = start + count - ptr;
                left = new byte[length];
                UnsafeHelper.Copy(ptr, left, length);
            }
        }

        private unsafe bool ParseLine(byte* start, long length)
        {
            byte* ptr = start;
            for (int i = 0; i < length; i++, ptr++)
            {
                if (*ptr == ASCIIChar.Colon)
                {
                    var name = StringHelper.ReadStringFromBytePoint(start, i);
                    if (*(++ptr) == ASCIIChar.SPACE)
                    {
                        var content = StringHelper.ReadStringFromBytePoint((++ptr), length - i - 2);
                        if (name != Header.GetNameByHeader(eHttpHeader.Cookie))
                        {
                            Headers.Add(name, content);
                        }
                        else
                        {
                            //todo Cookie
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /*    private void ParseCookies()
            {
                Cookies = HttpCookies.Parse(headers[eHttpRequestHeader.Cookie]);              
            }

            private void ParseQueryString()
            {
                try
                {         
                    if (uri.IndexOf('?') != -1)
                    {
                        string z = uri.Substring(uri.IndexOf('?') + 1);
                        {
                            var a = z.Split('&');
                            foreach (var b in a)
                            {
                                var c = b.Split('=');
                                if (c.Length >= 2)
                                {
                                    var name = c[0].Trim();
                                    var content = c[1].Trim();
                                    QueryString.Add(c[0], c[1]);
                                }
                            }
                        }
                        uri = uri.Substring(0, uri.IndexOf('?'));
                    }
                }
                catch (Exception e)
                {
                    Log.Log.Default.Warn("Error QueryString \r\n");
                    Log.Log.Default.Warn(e);
                }
            }

            private void ParsePost()
            {
                try
                {

                    var i = headers.ContentLength;
                    if (i!= 0)
                    {
                        if (PostBytes == null)
                        {
                            PostBytes = new byte[i];
                        }
                        Buffer.BlockCopy(postBytes, 0, PostBytes, 0, i);
                        if (headers[eHttpRequestHeader.ContentType]=="application/x-www-form-urlencoded")
                        {
                            var str = PostBytes.ConvertFromBytes();
                            Form = FormParser.Parse(str);
                        }
                    }
                    else
                    {
                        PostBytes = new byte[] { };
                    }
                }
                catch (Exception e)
                {
                    if (PostBytes == null)
                        PostBytes = new byte[] { };
                    Log.Log.Default.Warn("Error Post Bytes \r\n");
                    Log.Log.Default.Warn(e);
                }
            }

            private void ParseLine(string v)
            {
                try
                {
                    var x = v.Split(':');
                    if (x.Length >= 2)
                    {
                        var a = x[0].Trim();
                        var b = v.Substring(x[0].Length+1).Trim();
                        headers.Add(a, b);
                    }
                }
                catch (Exception e)
                {
                    Log.Log.Default.Warn("Error Request Line \r\n" + v);
                    Log.Log.Default.Warn(e);
                }
            }*/
        private unsafe bool ParseFirstLine(byte* ptr, long length)
        {
            var left = length;
            #region ParseMethod
            if (left >= 7)
            {
                if (*ptr == ASCIIChar.G && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.T)
                {
                    this.Method = eHttpMethod.GET;
                    left -= 3;
                }
                else if (*ptr == ASCIIChar.H && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.A && *(++ptr) == ASCIIChar.D)
                {
                    this.Method = eHttpMethod.HEAD;
                    left -= 4;
                }
                else if (*ptr == ASCIIChar.P)
                {
                    if (*(++ptr) == ASCIIChar.O && *(++ptr) == ASCIIChar.S && *(++ptr) == ASCIIChar.T)
                    {
                        this.Method = eHttpMethod.POST;
                        left -= 4;
                    }
                    else if (*(++ptr) == ASCIIChar.U && *(++ptr) == ASCIIChar.T)
                    {
                        this.Method = eHttpMethod.PUT;
                        left -= 3;
                    }
                }
                else if (*ptr == ASCIIChar.T && *(++ptr) == ASCIIChar.R && *(++ptr) == ASCIIChar.A && *(++ptr) == ASCIIChar.C && *(++ptr) == ASCIIChar.E)
                {
                    this.Method = eHttpMethod.TRACE;
                    left -= 5;
                }
                else if (*ptr == ASCIIChar.O && *(++ptr) == ASCIIChar.P && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.I && *(++ptr) == ASCIIChar.O && *(++ptr) == ASCIIChar.N && *(++ptr) == ASCIIChar.S)
                {

                    this.Method = eHttpMethod.OPTIONS;
                    left -= 7;
                }
                else if (*ptr == ASCIIChar.D && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.L && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.E)
                {
                    this.Method = eHttpMethod.DELETE;
                    left -= 6;
                }
            }
            #endregion
            if (this.Method != eHttpMethod.UnParsed && left > 1 && *(++ptr) == ASCIIChar.SPACE)
            {
                var uriptr = ++ptr;
                for (int i = 0; left > 0; i++, ptr++)
                {
                    left--;
                    if (*ptr == ASCIIChar.SPACE)
                    {
                        this.Uri = new URI(StringHelper.ReadStringFromBytePoint(uriptr, i));
                        if (left == 9)
                        {
                            #region ParseVersion
                            if (*(++ptr) == ASCIIChar.H && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.P && *(++ptr) == ASCIIChar.BackSlash)
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
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion ParseVersion
                        }
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }


        public string GetHeader()
        {
            var sb = new StringBuilder();
            sb.Append($"{Method.ToString()} {Uri} HTTP/1.1\r\n");
            foreach (var a in Headers)
            {
                sb.Append($"{a.Key}: {a.Value}\r\n");
            }
            if (Cookies.Count()!=0)
            {
                sb.Append($"Cookie:");
                foreach (var cookie in Cookies)
                {
                    sb.Append($" {cookie.name}={cookie.content};");
                }
                sb.Append("\r\n");
            }
            sb.Append("\r\n");
            return sb.ToString();
        }


        public void WriteContent(byte[] bytes)
        {
            this.ContentBytes = UnsafeHelper.Contact(ContentBytes, bytes);
        }
        public byte[] GetAll()
        {
            return UnsafeHelper.Contact(GetHeader().ConvertToBytes(Encoding.ASCII), ContentBytes);
        }
    }
}
