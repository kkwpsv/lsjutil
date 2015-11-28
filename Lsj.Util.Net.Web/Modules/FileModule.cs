using Lsj.Util.IO;
using Lsj.Util.Net.Web.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Website;

namespace Lsj.Util.Net.Web.Modules
{
    public class FileModule : IModule
    {
        public string[] DefaultPage { get; set; }
        public string[] ForbiddenPage
        {
            get; set;
        }
        public eModuleType ModuleType => eModuleType.File;
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
        string m_Path = ".";
        HttpWebsite website;
        public FileModule(HttpWebsite website)
        {
            this.website = website;
            var config = website.Config;
            this.Path = website.Path;
            this.DefaultPage = config.DefaultPage;
            this.ForbiddenPage = config.ForbiddenPath;
        }
        public HttpResponse Process(HttpRequest request)
        {
            var path = "";
            var z = request.uri.Substring(1);
            foreach (var x in ForbiddenPage)
            {
                if (z.StartsWith(x))
                {
                    request.ErrorCode = 403;
                    return website.ErrorModule.Process(request);
                }
            }
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
                request.ErrorCode = 404;
                return website.ErrorModule.Process(request);
               
            }
        }
        public bool CanProcess(HttpRequest request)
        {
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
            return false;
        }
    }
}
