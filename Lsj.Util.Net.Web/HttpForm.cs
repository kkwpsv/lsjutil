using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpForm
    {
        Dictionary<string, string> form = new Dictionary<string, string>();
        private object @lock = new object();
        public HttpForm(Dictionary<string, string> form)
        {
            this.form = form;
            foreach (var a in this.form.Keys)
            {
                Console.WriteLine(a);
                Console.WriteLine(this.form.ContainsKey(a));

            }
           
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
