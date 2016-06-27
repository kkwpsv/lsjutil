using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net
{
    /// <summary>
    /// URI
    /// </summary>
    public class URI
    {
        private string raw;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        public URI(string uri)
        {
            this.raw = uri;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return raw;
        }
        public string FileName
        {
            get
            {
                var x = raw.Substring(raw.LastIndexOf('/'));
                var a = x.IndexOf('?');
                if (a > 0)
                    return x.Substring(0, a);
                else
                    return x;
            }
        }
    }
}
