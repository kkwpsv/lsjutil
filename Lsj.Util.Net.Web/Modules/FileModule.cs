using Lsj.Util.IO;
using Lsj.Util.Net.Web.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Headers;

namespace Lsj.Util.Net.Web.Modules
{
    public class FileModule : IModule
    {
        public static string[] DefaultPage { get; set; } = { "index.htm", "index.html" };
        public string Path
        {
            get { return m_Path; }
            set
            {
                if (value.IsExistsPath())
                {
                    m_Path = value;
                }
                else
                {
                    throw new Exception("Path doesn't exist");
                }
            }
        }
        static string m_Path = ".";
        public FileModule(string path)
        {
            this.Path = path;
        }
        public HttpResponse Process(HttpRequest request)
        {
            var path = "";
            if (request.uri.EndsWith(@"\"))
            {
                foreach (var a in DefaultPage)
                {
                    if (File.Exists(Path + request.uri + a))
                    {
                        path = Path + request.uri + a;
                    }
                }
            }
            else if (File.Exists(Path + request.uri))
            {
                path = Path + request.uri;
            }
            if (path != "")
            {
                var response = new FileResponse(path,request);
                return response;
            }
            else
            {
                return new ErrorResponse(404);
               
            }
        }
        public bool CanProcess(HttpRequest request,ref int code)
        {
            if (request.uri == @"\website.config")
            {
                code = 403;
                return false;
            }
            if (request.Method == eHttpMethod.GET)
            {
                if (request.uri.EndsWith(@"\"))
                {
                    foreach (var a in DefaultPage)
                    {
                        if (File.Exists(Path + request.uri + a))
                        {
                            return true;
                        }
                    }
                }
                else if (File.Exists(Path + request.uri))
                {
                    return true;
                }
            }
            code = 404;
            return false;
        }
    }
}
