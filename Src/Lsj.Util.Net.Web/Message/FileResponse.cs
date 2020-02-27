using System;
using System.IO;
using System.IO.Compression;
using Lsj.Util.Net.Web.Static;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;

namespace Lsj.Util.Net.Web.Message
{
    class FileResponse : HttpResponse
    {
        public FileResponse(string path, IHttpRequest request) : base()
        {
            var file = new FileInfo(path);
            using var fileStream = file.OpenRead();
            var time = file.LastWriteTime.ToUniversalTime().ToString("r");
            Headers[HttpHeader.ContentType] = MIME.GetContentTypeByExtension(System.IO.Path.GetExtension(path));
            Headers.Add("Last-Modified", file.LastWriteTime.ToUniversalTime().ToString("r"));
            if (time == request.Headers[HttpHeader.IfModifiedSince])
            {
                this.Write304();
            }
            else
            {
                bool is206 = false;
                (long start, long length) fileRange = (0, fileStream.Length);

                var range = request.Headers[HttpHeader.Range]?.Trim();
                if (range != null)
                {
                    if (range.StartsWith("bytes="))
                    {
                        range = range.Substring(6);
                        var rangeSplit = range.Split(new char[] { '-' }, StringSplitOptions.None);
                        if (rangeSplit.Length == 2)
                        {
                            var start = 0L;
                            var end = fileStream.Length - 1;
                            if (long.TryParse(rangeSplit[0], out start) || long.TryParse(rangeSplit[1], out end))
                            {
                                if (start >= 0 && end < fileStream.Length && start < end)
                                {
                                    fileRange = (start, end - start + 1);
                                    is206 = true;
                                }
                            }
                        }
                    }
                }

                fileStream.Seek(fileRange.start, SeekOrigin.Begin);
                Headers[HttpHeader.ContentRange] = $"bytes {fileRange.start}-{fileRange.start + fileRange.length - 1}/{fileStream.Length}";
                this.ErrorCode = is206 ? 206 : 200;

                if (request.Headers[HttpHeader.AcceptEncoding].Contains("gzip"))
                {
                    using (var compress = new GZipStream(content, CompressionMode.Compress, true))
                    {
                        fileStream.CopyToWithCount(compress, fileRange.length);
                    }
                    Headers[HttpHeader.ContentEncoding] = "gzip";
                }
                else
                {
                    Headers[HttpHeader.ContentLength] = fileRange.length.ToString();
                    fileStream.CopyToWithCount(content, fileRange.length);
                }
            }
        }
    }

}
