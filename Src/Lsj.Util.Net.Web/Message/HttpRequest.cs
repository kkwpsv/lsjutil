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

        protected override unsafe bool InternalRead(Span<byte> buffer, out int read)
        {
            if (!_isReadHeader)
            {
                _isReadHeader = InternalReadImp(buffer, out read);
                return _isReadHeader;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private unsafe bool InternalReadImp(Span<byte> buffer, out int read)
        {
            var start = 0;
            var current = 0;
            read = 0;

            for (; current <= buffer.Length; current++)//循环
            {
                if (buffer[current] == ASCIIChar.CR && ++current <= buffer.Length && buffer[current] == ASCIIChar.LF)//判断是否为行尾
                {
                    var length = (current - start) + 1;//读取长度
                    bool isEnd = false;
                    if ((current + 2) <= buffer.Length && buffer[current + 1] == ASCIIChar.CR && buffer[current + 2] == ASCIIChar.LF)//判断是否结束请求头
                    {
                        isEnd = true;
                    }

                    if (Method == HttpMethods.UnParsed)//判断是否Parse首行
                    {
                        if (!ParseFirstLine(buffer.Slice(start, length - 2)))//Parse首行
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
                        if (!ParseLine(buffer.Slice(start, length - 2), out var errorcode))
                        {
                            ErrorCode = errorcode;
                            return true;
                        }
                        read += length;
                    }

                    if (!isEnd)
                    {
                        start = ++current;//开始位置和当前位置后移
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

        private unsafe bool ParseFirstLine(Span<byte> buffer)
        {
            var current = 0;
            var left = buffer.Length;

            #region ParseMethod
            if (left >= 3 && buffer[current] == ASCIIChar.G && buffer[++current] == ASCIIChar.E && buffer[++current] == ASCIIChar.T)
            {
                Method = HttpMethods.GET;
                left -= 3;
            }
            else if (left >= 3 && buffer[current] == ASCIIChar.P && buffer[++current] == ASCIIChar.U && buffer[++current] == ASCIIChar.T)
            {
                Method = HttpMethods.PUT;
                left -= 3;
            }
            else if (left >= 4 && buffer[current] == ASCIIChar.H && buffer[++current] == ASCIIChar.E && buffer[++current] == ASCIIChar.A && buffer[++current] == ASCIIChar.D)
            {
                Method = HttpMethods.HEAD;
                left -= 4;
            }
            else if (left >= 4 && buffer[current] == ASCIIChar.P && buffer[++current] == ASCIIChar.O && buffer[++current] == ASCIIChar.S && buffer[++current] == ASCIIChar.T)
            {
                Method = HttpMethods.POST;
                left -= 4;
            }
            else if (left >= 5 && buffer[current] == ASCIIChar.T && buffer[++current] == ASCIIChar.R && buffer[++current] == ASCIIChar.A && buffer[++current] == ASCIIChar.C && buffer[++current] == ASCIIChar.E)
            {
                Method = HttpMethods.TRACE;
                left -= 5;
            }
            else if (left >= 6 && buffer[current] == ASCIIChar.D && buffer[++current] == ASCIIChar.E && buffer[++current] == ASCIIChar.L && buffer[++current] == ASCIIChar.E && buffer[++current] == ASCIIChar.T && buffer[++current] == ASCIIChar.E)
            {
                Method = HttpMethods.DELETE;
                left -= 6;
            }
            else if (left >= 7 && buffer[current] == ASCIIChar.O && buffer[++current] == ASCIIChar.P && buffer[++current] == ASCIIChar.T && buffer[++current] == ASCIIChar.I && buffer[++current] == ASCIIChar.O && buffer[++current] == ASCIIChar.N && buffer[++current] == ASCIIChar.S)
            {
                Method = HttpMethods.OPTIONS;
                left -= 7;
            }
            #endregion

            if (Method != HttpMethods.UnParsed && left > 1 && buffer[++current] == ASCIIChar.SPACE)
            {
                left--;
                var uriOffset = ++current;

                var uriLength = 0;

                for (; left > 0; uriLength++, current++, left--)
                {
                    if (buffer[current] == ASCIIChar.SPACE)
                    {
                        Uri = new URI(StringHelper.ReadStringFromByteSpan(buffer.Slice(uriOffset, uriLength)));
                        if (left == 9)
                        {
                            #region ParseVersion
                            if (buffer[++current] == ASCIIChar.H && buffer[++current] == ASCIIChar.T && buffer[++current] == ASCIIChar.T && buffer[++current] == ASCIIChar.P && buffer[++current] == ASCIIChar.BackSlash)
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
                Uri = new URI(StringHelper.ReadStringFromByteSpan(buffer.Slice(uriOffset, uriLength)));
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

        public override string GetHttp1HeaderString()
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

        public override void WriteContent(byte[] buffer) => throw new NotSupportedException();

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
