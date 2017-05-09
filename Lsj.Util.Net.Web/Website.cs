using Lsj.Util;
using Lsj.Util.Net.Web.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.IO;
using System.IO;
using System.Reflection;
using Lsj.Util.Reflection;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Error;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// Website.
    /// </summary>
    public class Website
    {
        private WebServer server;
        private string hostname;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Web.Website"/> class.
        /// </summary>
        /// <param name="hostname">Hostname.</param>
        public Website(string hostname)
        {
            this.hostname = hostname;
        }
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path
        {
            get;
            set;
        } = "./";




        /// <summary>
        /// Modules
        /// </summary>
        public List<IModule> Modules
        {
            get;
        } = new List<IModule>();



        /// <summary>
        /// Start
        /// </summary>
        public void Start(WebServer server)
        {
            this.server = server;
            if (Modules.Count == 0)
            {
                Modules.Insert(0, new FileModule());
            }
            Modules.ForEach((x) =>
            {
                Process += x.Process;
            });
        }

        /// <summary>
        /// Process
        /// </summary>
        public event EventHandler<ProcessEventArgs> Process;



        internal IHttpResponse OnProcess(HttpContext x)
        {
            try
            {
                if (this.Process != null)
                {
                    var args = new ProcessEventArgs();
                    args.Request = x.Request;
                    args.ServerName = server.Name;
                    args.Log = x.Log;
                    this.Process(this, args);
                    if (args.IsProcessed)
                    {
                        return args.Response;
                    }
                }
                return ErrorHelper.Build(501, 0, server.Name);
            }
            catch (Exception e)
            {
                server.Log.Error(e);
                return ErrorHelper.Build(500, 0, server.Name);
            }
        }


    }
}
