using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Message;
using Lsj.Util.Net.Web.Error;

namespace Lsj.Util.Net.Web.Modules
{
    /// <summary>
    /// File Module
    /// </summary>
    public class FileModule : IModule
    {
        /// <summary>
        /// DefaultPage
        /// </summary>
        /// <value></value>
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
            var website = o as Website;
            var rootpath = website.Path;
            var request = args.Request;

            var filePath = request.Uri.ToString().Replace('/', Path.DirectorySeparatorChar);
            if (filePath.StartsWith(Path.DirectorySeparatorChar.ToString()))
            {
                filePath = filePath.Substring(1);
            }

            var path = Path.Combine(rootpath, filePath);
            bool found = false;

            if (path.EndsWith(@"/") && Directory.Exists(path))
            {
                foreach (var page in DefaultPage)
                {
                    var tempPath = Path.Combine(path, page);
                    if (File.Exists(tempPath))
                    {
                        path = tempPath;
                        found = true;
                        break;
                    }
                }
            }
            else if (File.Exists(path))
            {
                found = true;
            }

            if (found)
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
