using Lsj.Util.Net.Web.Cookie;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Text;
using System;
using System.IO;
using System.Text;

namespace Lsj.Util.Net.Web.Message
{
    /// <summary>
    /// HttpMessage Base
    /// </summary>
    public abstract class HttpMessageBase : DisposableClass, IHttpMessage
    {
        /// <summary>
        /// Headers
        /// </summary>
        public HttpHeaderDictionary Headers
        {
            get;
        } = new HttpHeaderDictionary();

        /// <summary>
        /// ErrorCode
        /// </summary>
        public int ErrorCode
        {
            get;
            set;
        } = 200;

        /// <summary>
        /// Content
        /// </summary>
        public virtual Stream Content => Stream.Null;

        /// <summary>
        /// Cookies
        /// </summary>
        public HttpCookies Cookies
        {
            get;
        } = new HttpCookies();

        /// <summary>
        /// HttpVersion
        /// </summary>
        public Version HttpVersion
        {
            get;
            protected set;
        }

        /// <summary>
        /// IsError
        /// </summary>
        public bool IsError => ErrorCode >= 400;

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        public bool Read(byte[] buffer, out int read) => Read(buffer, 0, out read);

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        public bool Read(byte[] buffer, int offset, out int read) => InternalRead(buffer, offset, buffer.Length - offset, out read);

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        public bool Read(byte[] buffer, int offset, int length, out int read) => InternalRead(buffer, offset, length, out read);

        /// <summary>
        /// InternalRead
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        unsafe protected bool InternalRead(byte[] buffer, int offset, int length, out int read)
        {
            return InternalRead(buffer.AsSpan(offset, length), out read);
        }

        /// <summary>
        /// InternalRead
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        protected abstract bool InternalRead(Span<byte> buffer, out int read);

        /// <summary>
        /// Parse Line
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="errorcode"></param>
        /// <returns></returns>
        protected unsafe bool ParseLine(Span<byte> buffer, out int errorcode)
        {
            var current = 0;
            for (int i = 0; i < buffer.Length; i++, current++)
            {
                if (buffer[current] == ASCIIChar.Colon)
                {
                    var name = StringHelper.ReadStringFromByteSpan(buffer.Slice(0, i));
                    if (buffer[++current] == ASCIIChar.SPACE)
                    {
                        var content = StringHelper.ReadStringFromByteSpan(buffer.Slice(++current, buffer.Length - i - 2));
                        if (ValidateHeader(name, content, out errorcode))
                        {
                            if (name != HttpHeadersHelper.GetNameByHeader(HttpHeaders.Cookie))
                            {
                                Headers.Add(name, content);
                            }
                            else
                            {
                                Cookies.Add(content);
                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            errorcode = 400;
            return false;
        }

        /// <summary>
        /// Validate Header
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        /// <param name="errorcode"></param>
        /// <returns></returns>
        protected virtual bool ValidateHeader(string name, string content, out int errorcode)
        {
            errorcode = 200;
            return true;
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="str"></param>
        public virtual void WriteContent(string str)
        {
            WriteContent(str.ConvertToBytes(Encoding.UTF8));
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="buffer"></param>
        public abstract void WriteContent(byte[] buffer);

        /// <summary>
        /// GetHttpHeader
        /// </summary>
        /// <returns></returns>
        public virtual string GetHttp1HeaderString()
        {
            throw new NotImplementedException();
        }
    }
}
