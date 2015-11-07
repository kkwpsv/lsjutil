using Lsj.Util.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpForm
    {
        SafeDictionary<string, string> form = new SafeDictionary<string, string>();
        private object @lock = new object();
        public HttpForm(SafeDictionary<string, string> form)
        {
            this.form = form;           
        }
        public string this[string key]
        {
            get
            {
                string x;
                lock (@lock)
                {
                    x = this.form.ContainsKey(key) ? this.form[key] : "";
                }
                return x;
            }
        }
    }
}
