using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Lsj.Util.Text;
using Lsj.Util.Net.Web.Cookie;

namespace Lsj.Util.Net.Web.Message
{
    class HttpRequest : HttpMessageBase,IHttpRequest
    {
        public eHttpMethod Method
        {
            get;
            protected set;
        } = eHttpMethod.UnParsed;
        public URI Uri
        {
            get;
            protected set;
        }
        public int ExtraErrorCode
        {
            get;
            set;
        } = 0;

        
        protected MemoryStream m_content;
        public override Stream Content
        {
            get
            {
                if (m_content == null)
                {
                    m_content = new MemoryStream(ContentLength);
                }
                return m_content;
            }
        }
        


        //Fucking Pointer.....
        unsafe protected override bool InternalRead(byte* pts, int offset, int count, ref int read)
        {
            byte* start = pts;
            byte* ptr = pts;
            read = 0;
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
                        if (this.Method == eHttpMethod.UnParsed)
                        {
                            if (!ParseFirstLine(start, length - 2))
                            {
                                this.ErrorCode = 400;
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
                left--;
                var uriptr = ++ptr;
                for (int i = 0; left > 0; i++, ptr++, left--)
                {
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



        public override string GetHttpHeader()
        {
            var sb = new StringBuilder();
            sb.Append($"{Method} {Uri.LocalPath} HTTP/{this.HttpVersion.ToString(2)}\r\n");
            foreach (var header in Headers)
            {
                sb.Append($"{header.Key}: {header.Value}\r\n");
            }
            sb.Append("\r\n");
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        public bool IsReadFinish => this.Content.Length >= this.ContentLength;

        
    }
}


