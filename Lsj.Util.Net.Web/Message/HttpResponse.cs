using Lsj.Util.Net.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Message
{
    class HttpResponse : IHttpResponse
    {
        

        public HttpHeaders Headers
        {
            get;
        } = new HttpHeaders();
        public int ErrorCode
        {
            get;
            set;
        }
        public int ContentLength => Headers[eHttpHeader.ContentLength].ConvertToInt();





        public bool Read(byte[] buffer, ref int read)
        {
            throw new NotImplementedException();
        }
    }
}
