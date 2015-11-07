using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Headers
{
    public interface IHeader
    {
        string Content
        {
            get;
        }
        string Name
        {
            get;
        }
    }
}
