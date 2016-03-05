using Lsj.Util.Net.Web.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net;

namespace Lsj.Util.Net.Web.Interfaces
{
    /// <summary>
    /// HttpMessage
    /// </summary>
    public interface IHttpMessage
    {
        /// <summary>
        /// Headers
        /// </summary>
        HttpHeaders Headers
        {
            get;
        }

        /// <summary>
        /// ErrorCode
        /// </summary>
        int ErrorCode
        {
            get;
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        bool Read(byte[] buffer, ref int read);
        /// <summary>
        /// ContentLength
        /// </summary>
        int ContentLength
        {
            get;
        }
        /// <summary>
        /// Write
        /// </summary>
        /// <param name="buffer"></param>
        void Write(byte[] buffer);
        /// <summary>
        /// str
        /// </summary>
        /// <param name="str"></param>
        void Write(string str);

    }
}
