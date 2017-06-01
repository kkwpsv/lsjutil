using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
using Lsj.Util.Core.Net.Web.Interfaces;
using Lsj.Util.Core.Net.Web.Event;
using Lsj.Util.Core.Net.Web.Error;
using Lsj.Util.Core.Net.Web.Message;
#else
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Message;
using Lsj.Util.Net.Web.Error;
#endif


#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Modules
#else
namespace Lsj.Util.Net.Web.Modules
#endif
{
    /// <summary>
    /// File module.
    /// </summary>
    public class FileModule :IModule
    {
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
                }
            }
            else if (File.Exists(rootpath + uri))
            {
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
