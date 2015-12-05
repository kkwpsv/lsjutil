using Lsj.Util.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lsj.Util.Net.Web
{
    public class HttpSessions
    {
        public static TimeSpan Timeout = new TimeSpan(0, 15, 0);
        SafeDictionary<string, HttpSession> sessions = new SafeDictionary<string, HttpSession>(true);
        public HttpSessions()
        {
            Thread CheckThread = new Thread(Check);
            CheckThread.Priority = ThreadPriority.BelowNormal;
        }

        private void Check()
        {
            try
            {
                foreach (string key in sessions.Keys.ToList())
                {
                    if (sessions[key].LastUseTime <= DateTime.Now - Timeout)
                    {
                        sessions.Remove(key);
                    }
                }
            }
            finally
            {
                Thread.Sleep(new TimeSpan(0, 5,0));
                Check();
            }
        }

        public HttpSession this[string key]
        {
            get
            {
                return sessions.ContainsKey(key) ? sessions[key] : null;
            }
            set
            {
                if (sessions.ContainsKey(key))
                {
                    sessions[key] = value;
                }
                else
                {
                    sessions.Add(key, value);
                }
            }
        }
        public string New()
        {
            var session = new HttpSession();
            if (this.sessions.ContainsKey(session.ID))
            {
                return New();
            }
            this[session.ID] = session;
            return session.ID;
        }

    }
}
