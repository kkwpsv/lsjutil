using Lsj.Util.Net.Web.Headers;
using Lsj.Util.Net.Web.Request;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Response
{
    public class FileResponse : HttpResponse
    {


        public FileResponse(string path, HttpRequest request) : base(request)
        {
            file = new FileInfo(path);
            var time = file.LastWriteTime.ToUniversalTime().ToString("r");
            this.headers[eHttpResponseHeader.ContentType] = new RawHeader(GetContengTypeByExtension(System.IO.Path.GetExtension(path)) + "; charset=utf-8");
            if (request.headers[eHttpRequestHeader.IfModifiedSince]!=null&&time == request.headers[eHttpRequestHeader.IfModifiedSince].Content)
            {
                this.Write304();
            }
            else
            {
                this.headers[eHttpResponseHeader.ContentLength] = new IntHeader(file.Length.ToString());
                headers.Add("Last-Modified", file.LastWriteTime.ToUniversalTime().ToString("r"));
            }
        }

        private string GetContengTypeByExtension(string v)
        {
            throw new NotImplementedException();
        }

        FileInfo file;


        public override byte[] GetAll()
        {
            if (status == 304)
               return base.GetAll();
            var content = file != null ?File.ReadAllBytes(file.FullName):NullBytes;
            return GetHeader().ToString().ConvertToBytes(Encoding.UTF8).Concat(content).ToArray();
        }
        public void Write304()
        {
            var sb = new StringBuilder("");
            this.content = sb;
            this.headers[eHttpResponseHeader.ContentLength] = new IntHeader(0);
            this.status = 304;
        }
    }

}
