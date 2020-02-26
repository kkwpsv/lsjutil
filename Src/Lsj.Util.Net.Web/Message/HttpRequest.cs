using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Text;
using System.IO;
using System.Text;


namespace Lsj.Util.Net.Web.Message
{
    internal class HttpRequest : HttpMessageBase, IHttpRequest
    {
        public HttpMethod Method
        {
            get;
            protected set;
        } = HttpMethod.UnParsed;

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
                    _content = new MemoryStream(ContentLength);
                }
                return _content;
            }
        }

        //Fucking Pointer.....
        unsafe protected override bool InternalRead(byte* pts, int offset, int count, ref int read)
        {
            byte* start = pts;                      //开始位置
            byte* end = pts + offset + count - 1;   //结束位置
            byte* ptr = pts + offset;               //当前位置
            read = 0;                               //读取字节数

            for (; ptr <= end; ptr++)//循环
            {
                if (*ptr == ASCIIChar.CR && (long)(++ptr) <= (long)end && *ptr == ASCIIChar.LF)//判断是否为行尾
                {
                    #region When End Header
                    if ((long)(ptr + 2) <= (long)end && *(ptr + 1) == ASCIIChar.CR && *(ptr + 2) == ASCIIChar.LF)//判断是否结束请求头
                    {
                        var length = (int)(ptr - start) + 1;//读取长度
                        ParseLine(start, length - 2);
                        read += length;
                        read += 2;
                        return true;
                    }
                    #endregion When End Header
                    else
                    {
                        var length = (int)(ptr - start) + 1;//读取长度
                        if (this.Method == HttpMethod.UnParsed)//判断是否Parse首行
                        {
                            if (!ParseFirstLine(start, length - 2/*实际内容长度，减掉CR LF*/))//Parse首行
                            {
                                this.ErrorCode = 400;
                                return true;
                            }
                            read += length;//读取字节数增加
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
                        start = ++ptr;//开始位置和当前位置后移
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
                    this.Method = HttpMethod.GET;
                    left -= 3;
                }
                else if (*ptr == ASCIIChar.H && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.A && *(++ptr) == ASCIIChar.D)
                {
                    this.Method = HttpMethod.HEAD;
                    left -= 4;
                }
                else if (*ptr == ASCIIChar.P)
                {
                    if (*(++ptr) == ASCIIChar.O && *(++ptr) == ASCIIChar.S && *(++ptr) == ASCIIChar.T)
                    {
                        this.Method = HttpMethod.POST;
                        left -= 4;
                    }
                    else if (*(++ptr) == ASCIIChar.U && *(++ptr) == ASCIIChar.T)
                    {
                        this.Method = HttpMethod.PUT;
                        left -= 3;
                    }
                }
                else if (*ptr == ASCIIChar.T && *(++ptr) == ASCIIChar.R && *(++ptr) == ASCIIChar.A && *(++ptr) == ASCIIChar.C && *(++ptr) == ASCIIChar.E)
                {
                    this.Method = HttpMethod.TRACE;
                    left -= 5;
                }
                else if (*ptr == ASCIIChar.O && *(++ptr) == ASCIIChar.P && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.I && *(++ptr) == ASCIIChar.O && *(++ptr) == ASCIIChar.N && *(++ptr) == ASCIIChar.S)
                {

                    this.Method = HttpMethod.OPTIONS;
                    left -= 7;
                }
                else if (*ptr == ASCIIChar.D && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.L && *(++ptr) == ASCIIChar.E && *(++ptr) == ASCIIChar.T && *(++ptr) == ASCIIChar.E)
                {
                    this.Method = HttpMethod.DELETE;
                    left -= 6;
                }
            }
            #endregion
            if (this.Method != HttpMethod.UnParsed && left > 1 && *(++ptr) == ASCIIChar.SPACE)
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
            return sb.ToString();
        }

        public bool IsReadFinish => Content.Length >= ContentLength;

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


