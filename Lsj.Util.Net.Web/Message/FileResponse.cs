using System.IO;
using System.IO.Compression;
using Lsj.Util.Net.Web.Static;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;

namespace Lsj.Util.Net.Web.Message
{
    class FileResponse : HttpResponse
    {
        readonly FileInfo file;

        public FileResponse(string path, IHttpRequest request) : base()
        {
            file = new FileInfo(path);
            var time = file.LastWriteTime.ToUniversalTime().ToString("r");
            this.Headers[HttpHeader.ContentType] = MIME.GetContentTypeByExtension(System.IO.Path.GetExtension(path));
            if (time == request.Headers[HttpHeader.IfModifiedSince])
            {
                this.Write304();
            }
            else
            {
                Headers.Add("Last-Modified", file.LastWriteTime.ToUniversalTime().ToString("r"));
                if (request.Headers[HttpHeader.AcceptEncoding].Contains("gzip"))
                {
                    using (var compress = new GZipStream(content, CompressionMode.Compress, true))
                    {
                        compress.Write(file.OpenRead().ReadAll());
                    }
                    Headers.Add(HttpHeader.ContentEncoding, "gzip");
                }
                else
                {
                    file.OpenRead().CopyTo(content);
                }
            }
        }



    }

}
