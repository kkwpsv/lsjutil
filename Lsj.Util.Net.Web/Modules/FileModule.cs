﻿using System;
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
