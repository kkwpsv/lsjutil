using System;
using System.IO;
using System.IO.Compression;
using Lsj.Util.Net.Web.Static;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Text;

namespace Lsj.Util.Net.Web.Message
{
    public class FileResponse : HttpResponse
    {
        public override long ContentLength => Headers[HttpHeaders.ContentLength].ConvertToLong();

        public override Stream Content => _content;

        public FileResponse(string path, IHttpRequest request) : base()
        {
            var file = new FileInfo(path);
            var fileStream = file.OpenRead();
            var time = file.LastWriteTime.ToUniversalTime().ToString("r");
            Headers[HttpHeaders.ContentType] = MIMEHelper.GetContentTypeByExtension(System.IO.Path.GetExtension(path));
            Headers.Add("Last-Modified", file.LastWriteTime.ToUniversalTime().ToString("r"));
            if (time == request.Headers[HttpHeaders.IfModifiedSince])
            {
                Write304();
            }
            else
            {
                bool is206 = false;
                (long start, long length) fileRange = (0, fileStream.Length);

                var range = request.Headers[HttpHeaders.Range]?.Trim();
                if (!range.IsNullOrEmpty())
                {
                    if (range.StartsWith("bytes="))
                    {
                        range = range.Substring(6);
                        var rangeSplit = range.Split(new char[] { '-' }, StringSplitOptions.None);
                        if (rangeSplit.Length == 2)
                        {
                            if (long.TryParse(rangeSplit[0], out var start))
                            {
                                if (!long.TryParse(rangeSplit[1], out var end))
                                {
                                    end = fileStream.Length - 1;
                                }
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

                ErrorCode = is206 ? 206 : 200;

                if (request.Headers[HttpHeaders.AcceptEncoding].Contains("gzip") && fileRange.length < 10 * 1024 * 1024)
                {
                    using (var compress = new GZipStream(_content, CompressionMode.Compress, true))
                    {
                        fileStream.CopyToWithCount(compress, fileRange.length);
                    }
                    _content.Seek(0, SeekOrigin.Begin);
                    Headers[HttpHeaders.ContentEncoding] = "gzip";
                    Headers[HttpHeaders.ContentLength] = _content.Length.ToString();
                }
                else
                {
                    Headers[HttpHeaders.ContentRange] = $"bytes {fileRange.start}-{fileRange.start + fileRange.length - 1}/{fileStream.Length}";
                    Headers[HttpHeaders.ContentLength] = fileRange.length.ToString();
                    _content = fileStream;
                }
            }
        }

        protected override void CleanUpUnmanagedResources()
        {
            _content.Dispose();
        }
    }
}
