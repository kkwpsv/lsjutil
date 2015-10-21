using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Response
{
    public class FileResponse : HttpResponse
    {
        public FileResponse(string path,string ifmodifiedsince)
        {
            file = new FileInfo(path);
            var time = file.LastWriteTime.ToUniversalTime().ToString("r");
            ContentType = GetContengTypeByExtension(System.IO.Path.GetExtension(path));
            if (time==ifmodifiedsince)
            {
                this.Write304();
            }
            else
            {
                ContentLength = file.Length;
                headers.Add("Last-Modified", file.LastWriteTime.ToUniversalTime().ToString("r"));
            }
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
            this.ContentLength = 0;
            this.status = 304;
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
