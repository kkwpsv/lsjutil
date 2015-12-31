using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Message
{
    public class HttpHeaders : SafeStringToStringDirectionary
    {
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
        public void Add(eHttpHeader x, string content)
        {
            this.Add(Header.GetNameByHeader(x), content);
        }
       
       
    }
}
