using Lsj.Util.Logs;
using Lsj.Util.Net.Web.Listener;
using System.Collections.Generic;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// WebServer
    /// </summary>
    public class WebServer
    {
        List<IListener> listeners = new List<IListener>();
        /// <summary>
        /// LogProvider
        /// </summary>
        public LogProvider Log
        {
            get;
            set;
        } = LogProvider.Default;
        /// <summary>
        /// IsStarted
        /// </summary>
        public bool IsStarted
        {
            get;
            private set;
        }
        /// <summary>
        /// Start
        /// </summary>
        public void Start()
        {
            if (IsStarted)
                return;
            foreach (var listener in listeners)
            {
                StartListener(listener);
            }
        }



        /// <summary>
        /// Add a Listener
        /// </summary>
        /// <param name="listener"></param>
        public void AddListener(IListener listener)
        {
            if (IsStarted)
            {
                StartListener(listener);
            }
            listeners.Add(listener);
        }
        /// <summary>
        /// RemoveListener
        /// </summary>
        /// <param name="listener"></param>
        public void RemoveListener(IListener listener)
        {
            if (!listeners.Contains(listener))
            {
                Log.Warn("Try to remove a listener which hasn't been added");
                return;
            }
            if (IsStarted)
            {
                StopListener(listener);
            }
            listeners.Remove(listener);
        }



        void StartListener(IListener listener)
        {
            listener.Start();

        }
        void StopListener(IListener listener)
        {
            listener.Stop();
        }
    }
}
