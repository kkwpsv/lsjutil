
using Lsj.Util.Net.Web.Request;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System;

namespace Lsj.Util.Net.Web.Response
{
    public class FileResponse : HttpResponse, IDisposable
    {

        protected override void CleanUpManagedResources()
        {
            base.CleanUpManagedResources();
        }
        public FileResponse(string path, HttpRequest request) : base(request)
        {
            file = new FileInfo(path);
            var time = file.LastWriteTime.ToUniversalTime().ToString("r");
            this.headers.ContentType = MIME.MIME.GetContengTypeByExtension(System.IO.Path.GetExtension(path));
            if (time == request.headers.IfModifiedSince)
            {
                this.Write304();
            }
            else
            {              
                headers.Add("Last-Modified", file.LastWriteTime.ToUniversalTime().ToString("r"));
                if (request.client.website.Config.IsCompress&&request.headers.AcceptEncoding.Contains("gzip"))
                {
                    using (var compress = new GZipStream(content, CompressionMode.Compress,true))
                    {
                        compress.Write(file.OpenRead().ReadAll());
                    }
                    headers.Add(eHttpResponseHeader.ContentEncoding, "gzip");
                }
                else
                {
                     file.OpenRead().CopyTo(content);
                }
            }
        }

        FileInfo file;
        public void Write304()
        {
            this.status = 304;
        }
    }

}
