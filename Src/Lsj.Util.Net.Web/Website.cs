using System;
using System.Collections.Generic;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Modules;
using Lsj.Util.Net.Web.Error;
using System.IO;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// Website
    /// </summary>
    public class Website
    {
        private WebServer server;
        private string hostname;
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Net.Web.Website"/> class.
        /// </summary>
        /// <param name="hostname"></param>
        public Website(string hostname)
        {
            this.hostname = hostname;
        }
        /// <summary>
        /// Path
        /// </summary>
        public string Path
        {
            get;
            set;
        } = Environment.CurrentDirectory;




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
                    var args = new ProcessEventArgs
                    {
                        Request = x.Request,
                        ServerName = server.Name,
                        Log = x.Log
                    };
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
