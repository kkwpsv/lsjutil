using Lsj.Util.Net.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
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
        public int ContentLength => content.Length.ConvertToInt();
        protected Stream content;
        public HttpResponse()
        {
            this.content = new MemoryStream();
        }





        public bool Read(byte[] buffer, ref int read)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] buffer)
        {
            this.content.Write(buffer);
        }

        public void Write(string str)
        {
            this.Write(str.ConvertToBytes(Encoding.UTF8));
        }
    }
}
