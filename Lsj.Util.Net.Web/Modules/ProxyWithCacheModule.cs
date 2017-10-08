using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Error;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Message;

namespace Lsj.Util.Net.Web.Modules
{
    /// <summary>
    /// Proxy with cache Module
    /// </summary>
    public class ProxyWithCacheModule : IModule
    {
        /// <summary>
        /// Source Uri like http://www.example.com
        /// </summary>
        public string SrcUri
        {
            get;
            set;
        } = "http://www.example.com";

        /// <summary>
        /// DefaultPage
        /// </summary>
        public string[] DefaultPage
        {
            get; set;
        } =
        {
            "index.htm"
        };


        /// <summary>
        /// Process
        /// </summary>
        /// <returns></returns>
        /// <param name="o">website</param>
        /// <param name="args">args</param>
        public void Process(object o, ProcessEventArgs args)
        {
            args.IsProcessed = true;
            var path = "";
            var website = o as Website;
            var rootpath = website.Path;
            var request = args.Request;

            var uri = request.Uri.ToString();

            //var z = uri.Substring(1);
            if (uri.EndsWith(@"/"))
            {
                foreach (var a in DefaultPage)
                {
                    if (File.Exists(rootpath + uri + a))
                    {
                        path = rootpath + uri + a;
                        break;
                    }
                    else
                    {
                        var result = new WebHttpClient().Get(SrcUri + uri + a);
                        uri = uri.Substring(0, uri.IndexOf("?"));
                        var file = new FileInfo(rootpath + uri + a);
                        if (!file.Directory.Exists)
                        {
                            file.Directory.Create();
                        }
                        File.WriteAllBytes(rootpath + uri + a, result);
                        path = rootpath + uri + a;
                    }
                }
            }
            else if (File.Exists(rootpath + uri.Substring(0, uri.IndexOf("?") == -1 ? uri.Length : uri.IndexOf("?"))))
            {
                path = rootpath + uri.Substring(0, uri.IndexOf("?") == -1 ? uri.Length : uri.IndexOf("?"));
            }
            else
            {
                var result = new WebHttpClient().Get(SrcUri + uri);
                uri = uri.Substring(0, uri.IndexOf("?") == -1 ? uri.Length : uri.IndexOf("?"));
                var file = new FileInfo(rootpath + uri);
                if (!file.Directory.Exists)
                {
                    file.Directory.Create();
                }
                File.WriteAllBytes(rootpath + uri, result);
                path = rootpath + uri;

            }

            if (path != "")
            {
                args.Response = new FileResponse(path, request);
            }
            else
            {
                args.Response = ErrorHelper.Build(404, 0, args.ServerName);
            }
        }


    }
}
