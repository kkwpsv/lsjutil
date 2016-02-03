using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Message
{
    class HttpRequest : IHttpRequest
    {
        public eHttpMethod Method
        {
            get;
            private set;
        } = eHttpMethod.UnParsed;
        public HttpHeaders Headers
        {
            get;
        } = new HttpHeaders();
        public Version HttpVersion
        {
            get;
            private set;
        }
        public URI Uri
        {
            get;
            private set;
        }
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

        public int ContentLength => Headers[eHttpHeader.ContentLength].ConvertToInt();

        public bool Read(byte[] buffer,ref int read) => Read(buffer, 0, ref read);

        public bool Read(byte[] buffer, int offset, ref int read) => InternalRead(buffer, offset, buffer.Length - offset, ref read);
        public bool Read(byte[] buffer, int offset, int length, ref int read) => InternalRead(buffer, offset, length, ref read);
        unsafe bool InternalRead(byte[] buffer, int offset, int length, ref int read)
        {
            fixed (byte* pts = buffer)
            {
                return InternalRead(pts, offset, length, ref read);
            }
        }
        //Never Read Again
        //Pointer.....
        unsafe bool InternalRead(byte* pts, int offset, int count, ref int read)
        {
            byte* start = pts;
            byte* ptr = pts;
            read = 0;
            for (int i = offset; i < count; i++, ptr++)
            {
                if (*ptr == ASCIIChar.CR && (++i) < count && *(++ptr) == ASCIIChar.LF)
                {
                    #region When End Header
                    if (++i < count && *(++ptr) == ASCIIChar.CR && ++i < count && *(++ptr) == ASCIIChar.LF)
                    {
                        int length = (int)(ptr - start - 4);
                        ParseLine(start, length);
                        read += length;
                        return true;
                    }
                    #endregion When End Header
                    else
                    {
                        #region ParseHeader
                        var length = (int)(ptr - start - 2);
                        if (this.Method == eHttpMethod.UnParsed)
                        {
                            if (!ParseFirstLine(start, length))
                            {
                                this.ErrorCode = 400;
                                return true;
                            }
                            read += length;
                        }
                        else
                        {
                            if (!ParseLine(start, length))
                            {
                                this.ErrorCode = 400;
                                return true;
                            }
                            read += length;
                        }
                        #endregion ParseHeader
                        start = ++ptr;
                        i++;
                    }
                }
            }
            return false;
        }
        private unsafe bool ParseLine(byte* start, int length)
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

    }
}


