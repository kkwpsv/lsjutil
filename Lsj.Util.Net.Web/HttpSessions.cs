using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpSessions
    {
        //to do lifetime
        Dictionary<string,object> sessions = new Dictionary<string, object>();
        public object this[string key]
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
    }
}
