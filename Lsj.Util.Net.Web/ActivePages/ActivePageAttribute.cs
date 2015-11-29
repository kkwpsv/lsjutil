using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.ActivePages
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ActivePageAttribute:Attribute
    {
        public string uri
        {
            get;
            set;
        }
    }
}
