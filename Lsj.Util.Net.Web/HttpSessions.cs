using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpSessions
    {
        Dictionary<string, HttpSession> sessions = new Dictionary<string, HttpSession>();
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
                    this.sessions.Add(key, value);
                }
            }
        }
        public string New()
        {
            var session = new HttpSession();
            this[session.ID] = session;
            return session.ID;
        }

    }
}
