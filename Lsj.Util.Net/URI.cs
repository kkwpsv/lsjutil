using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net
{
    public class URI
    {
        private string raw;

        public URI(string uri)
        {
            this.raw = uri;
        }
        public override string ToString()
        {
            return raw;
        }
    }
}
