using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Response
{
    public class HttpFileResponse : HttpResponse
    {
        FileInfo file;
        public override byte[] GetAll()
        {
            var content = file != null ?File.ReadAllBytes(file.FullName):NullBytes;
            return GetHeader().ToString().ConvertToBytes(Encoding.UTF8).Concat(content).ToArray();
        }
        public void WriteFile(string path)
        {
            file = new FileInfo(path);
            ContentLength =file.Length;
            headers.Add("Last-Modified", file.LastWriteTime.ToUniversalTime().ToString("r"));
            Contenttype = GetContengTypeByExtension(System.IO.Path.GetExtension(path));
        }
        private string GetContengTypeByExtension(string Extension)
        {
            switch (Extension)
            {
                case ".css":
                    return "text/css";
                case ".html":
                case ".htm":
                    return "text/html";
                case ".jpg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                default:
                    return "*/*";
            }
        }
    }

}
