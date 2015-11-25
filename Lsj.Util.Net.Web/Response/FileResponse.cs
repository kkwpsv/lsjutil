
using Lsj.Util.Net.Web.Request;
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
            this.headers.ContentType = MIME.MIME.GetContengTypeByExtension(System.IO.Path.GetExtension(path));
            if (time == request.headers.IfModifiedSince)
            {
                this.Write304();
            }
            else
            {
                this.headers.ContentLength = file.Length.ConvertToInt();
                headers.Add("Last-Modified", file.LastWriteTime.ToUniversalTime().ToString("r"));
            }
        }

        FileInfo file;


        public override byte[] GetAll()
        {
            if (status == 304)
               return base.GetAll();
            var content = file != null ?File.ReadAllBytes(file.FullName):NullBytes;
            return GetHeader().ToString().ConvertToBytes(Encoding.ASCII).Concat(content).ToArray();
        }
        public void Write304()
        {
            var sb = new StringBuilder("");
            this.content = sb;
            this.headers.ContentLength = 0;
            this.status = 304;
        }
    }

}
