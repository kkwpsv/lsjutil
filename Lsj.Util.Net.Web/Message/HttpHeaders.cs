
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
using Lsj.Util.Core.Collections;
using Lsj.Util.Core.Net.Web.Protocol;
using Lsj.Util.Core.Net.Web.Static;
#else
using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Static;
#endif


#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Message
#else
namespace Lsj.Util.Net.Web.Message
#endif
{
    /// <summary>
    /// HttpHeaders
    /// </summary>
    public class HttpHeaders : SafeStringToStringDirectionary
    {
        /// <summary>
        /// GetHttpHeader
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public string this[eHttpHeader x]
        {
            get
            {
                return this[Header.GetNameByHeader(x)];
            }
            set
            {
                this[Header.GetNameByHeader(x)] = value;
            }
        }   
        internal void Add(eHttpHeader x, string content)
        {
            this.Add(Header.GetNameByHeader(x), content);
        }
       
       
    }
}
