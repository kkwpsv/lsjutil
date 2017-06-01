using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Cookie;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Static;
using Lsj.Util.Text;

namespace Lsj.Util.Net.Web.Message
{
    /// <summary>
    /// Http message base.
    /// </summary>
    public abstract class HttpMessageBase : IHttpMessage
    {
        /// <summary>
        /// Headers
        /// </summary>
        public HttpHeaders Headers
        {
            get;
        } = new HttpHeaders();
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
        /// ContentLength
        /// </summary>
        public virtual int ContentLength => Headers[eHttpHeader.ContentLength].ConvertToInt(0);
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
        public bool Read(byte[] buffer, ref int read) => Read(buffer, 0, ref read);
        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        public bool Read(byte[] buffer, int offset, ref int read) => InternalRead(buffer, offset, buffer.Length - offset, ref read);
        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        public bool Read(byte[] buffer, int offset, int length, ref int read) => InternalRead(buffer, offset, length, ref read);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        unsafe protected bool InternalRead(byte[] buffer, int offset, int length, ref int read)
        {
            fixed (byte* pts = buffer)
            {
                return InternalRead(pts, offset, length, ref read);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        unsafe protected virtual bool InternalRead(byte* pts, int offset, int count, ref int read)
        {
            return false;
        }
        /// <summary>
        /// Parse Line
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        protected unsafe bool ParseLine(byte* start, int length)
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
            return false;
        }
        /// <summary>
        /// Write
        /// </summary>
        /// <param name="str"></param>
        public virtual void Write(string str)
        {
            Write(str.ConvertToBytes(Encoding.UTF8));
        }
        /// <summary>
        /// Write
        /// </summary>
        /// <param name="buffer"></param>
        public virtual void Write(byte[] buffer)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// GetHttpHeader
        /// </summary>
        /// <returns></returns>
        public virtual string GetHttpHeader()
        {
            throw new NotImplementedException();
        }


    }
}
