using Lsj.Util.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Error;
using Lsj.Util.Net.Web.Message;
using Lsj.Util.Text;
using Lsj.Util.Logs;

namespace Lsj.Util.Net.Web.Modules
{
    /// <summary>
    /// Proxy with cache module.
    /// </summary>
    public class ProxyWithCacheModule : IModule
    {
        /// <summary>
        /// Src Uri like http://www.example.com
        /// </summary>
        public string SrcUri
        {
            get;
            set;
        } = "http://www.example.com";

        /// <summary>
        /// Gets or sets the default page.
        /// </summary>
        /// <value>The default page.</value>
        public string[] DefaultPage
        {
            get; set;
        } =
        {
            "index.htm"
        };


        /// <summary>
        /// Process.
        /// </summary>
        /// <returns>The process.</returns>
        /// <param name="o">O.</param>
        /// <param name="args">Arguments.</param>
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
                        try
                        {
                            var result = new WebHttpClient().Get(SrcUri + uri + a);
                            File.WriteAllBytes(rootpath + uri + a, result);
                            path = rootpath + uri + a;
                        }
                        catch
                        {

                        }
                    }
                }
            }
            else if (File.Exists(rootpath + uri))
            {
                path = rootpath + uri;
            }
            else
            {
                try
                {
                    var result = new WebHttpClient().Get(SrcUri + uri);
                    File.WriteAllBytes(rootpath + uri, result);
                    path = rootpath + uri;
                }
                catch
                {

                }
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
