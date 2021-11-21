using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Text;
using System;
using System.IO;
using System.Text;

namespace Lsj.Util.Net.Web.Message
{
    internal class HttpRequest : HttpMessageBase, IHttpRequest
    {
        public HttpMethods Method
        {
            get;
            protected set;
        } = HttpMethods.UnParsed;

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

        protected MemoryStream _content;
        public override Stream Content
        {
            get
            {
                if (_content == null)
                {
                    _content = new MemoryStream();
                }
                return _content;
            }
        }

        /// <summary>
        /// ContentLength
        /// </summary>
        public virtual int ContentLength => Headers[Protocol.HttpHeaders.ContentLength].ConvertToInt(0);

        private bool _isReadHeader;

        protected override unsafe bool InternalRead(byte* pts, int offset, int count, out int read)
        {
            if (!_isReadHeader)
            {
                _isReadHeader = InternalReadImp(pts, offset, count, out read);
                return _isReadHeader;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        //Fucking Pointer.....
        private unsafe bool InternalReadImp(byte* pts, int offset, int count, out int read)
        {
            byte* start = pts;                      //开始位置
            byte* end = pts + offset + count - 1;   //结束位置
            byte* ptr = pts + offset;               //当前位置
            read = 0;                               //读取字节数

            for (; ptr <= end; ptr++)//循环
            {
                if (*ptr == ASCIIChar.CR && (long)(++ptr) <= (long)end && *ptr == ASCIIChar.LF)//判断是否为行尾
                {
                    var length = (int)(ptr - start) + 1;//读取长度
                    bool isEnd = false;
                    if ((long)(ptr + 2) <= (long)end && *(ptr + 1) == ASCIIChar.CR && *(ptr + 2) == ASCIIChar.LF)//判断是否结束请求头
                    {
                        isEnd = true;
                    }

                    if (Method == HttpMethods.UnParsed)//判断是否Parse首行
                    {
                        if (!ParseFirstLine(start, length - 2/*实际内容长度，减掉CR LF*/))//Parse首行
                        {
                            ErrorCode = 400;
                            return true;
                        }
                        if (HttpVersion == new Version(0, 9))
                        {
                            // No headers with http 0.9
                            read += length;
                            return true;
                        }
                        read += length;//读取字节数增加
                    }
                    else
                    {
                        if (!ParseLine(start, length - 2, out var errorcode))
                        {
                            ErrorCode = errorcode;
                            return true;
                        }
                        read += length;
                    }

                    if (!isEnd)
                    {
                        start = ++ptr;//开始位置和当前位置后移
                    }
                    else
                    {
                        read += 2;
                        return true;
                    }
                }
            }
            return false;
        }

        private unsafe bool ParseFirstLine(byte* ptr, int length)
        {
            var left = length;

            #region ParseMethod
            if (left >= 3 && *ptr == ASCIIChar.G && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.T)
            {
                Method = HttpMethods.GET;
                left -= 3;
            }
            else if (left >= 3 && *ptr == ASCIIChar.P && *(++ptr) == ASCIIChar.U && *(++ptr) == ASCIIChar.T)
            {
                Method = HttpMethods.PUT;
                left -= 3;
            }
            else if (left >= 4 && *ptr == ASCIIChar.H && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.A && *(++ptr) == ASCIIChar.D)
            {
                Method = HttpMethods.HEAD;
                left -= 4;
            }
            else if (left >= 4 && *ptr == ASCIIChar.P && *(++ptr) == ASCIIChar.O && *(++ptr) == ASCIIChar.S && *(++ptr) == ASCIIChar.T)
            {
                Method = HttpMethods.POST;
                left -= 4;
            }
            else if (left >= 5 && *ptr == ASCIIChar.T && *(++ptr) == ASCIIChar.R && *(++ptr) == ASCIIChar.A && *(++ptr) == ASCIIChar.C && *(++ptr) == ASCIIChar.E)
            {
                Method = HttpMethods.TRACE;
                left -= 5;
            }
            else if (left >= 6 && *ptr == ASCIIChar.D && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.L && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.E)
            {
                Method = HttpMethods.DELETE;
                left -= 6;
            }
            else if (left >= 7 && *ptr == ASCIIChar.O && *(++ptr) == ASCIIChar.P && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.I && *(++ptr) == ASCIIChar.O && *(++ptr) == ASCIIChar.N && *(++ptr) == ASCIIChar.S)
            {
                Method = HttpMethods.OPTIONS;
                left -= 7;
            }
            #endregion

            if (Method != HttpMethods.UnParsed && left > 1 && *(++ptr) == ASCIIChar.SPACE)
            {
                left--;
                var uriPtr = ++ptr;

                var uriLength = 0;

                for (; left > 0; uriLength++, ptr++, left--)
                {
                    if (*ptr == ASCIIChar.SPACE)
                    {
                        Uri = new URI(StringHelper.ReadStringFromBytePoint(uriPtr, uriLength));
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
                                                HttpVersion = new Version(major, minor);
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


                // HTTP 0.9 formats: GET /PATH
                Uri = new URI(StringHelper.ReadStringFromBytePoint(uriPtr, uriLength));
                HttpVersion = new Version(0, 9);

                return true;
            }
            else
            {
                return false;
            }
        }

        protected override bool ValidateHeader(string name, string content, out int errorcode)
        {
            errorcode = 200;
            switch (name)
            {
                case "Content-Length":
                    if (content.ConvertToLong(long.MaxValue) < int.MaxValue)
                    {
                        return true;
                    }
                    else
                    {
                        errorcode = 413;
                        return false;
                    }
                default:
                    return base.ValidateHeader(name, content, out errorcode);
            }
        }

        public override string GetHttpHeader()
        {
            var sb = new StringBuilder();
            sb.Append($"{Method} {Uri} HTTP/{this.HttpVersion.ToString(2)}\r\n");
            foreach (var header in Headers)
            {
                sb.Append($"{header.Key}: {header.Value}\r\n");
            }
            sb.Append("\r\n");
            return sb.ToString();
        }

        public bool IsReadFinish => _isReadHeader && Content.Length >= ContentLength;

        public string UserHostAddress
        {
            get; internal set;
        }

        protected override void CleanUpManagedResources()
        {
            _content.Dispose();
            base.CleanUpManagedResources();
        }
    }
}
