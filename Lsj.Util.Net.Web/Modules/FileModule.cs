﻿using Lsj.Util.IO;
using Lsj.Util.Net.Web.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Modules
{
    public class FileModule : IModule
    {
        public static string[] DefaultPage { get; set; } = { "index.htm", "index.html" };
        public static string Path
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
        public HttpResponse Process(HttpRequest request)
        {
            var response = new HttpFileResponse();
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
                response.WriteFile(path);
            }
            else
            {
                var x = new HttpResponse();
                x.WriteError(404);
                return x;
            }
            return response;
        }
        public static bool CanProcess(HttpRequest request)
        {
            var b = Path + request.uri;
            bool result = false;
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
            return result;
        }
    }
}
