using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpForm
    {
        Dictionary<string, string> form = new Dictionary<string, string>();
        public HttpForm(Dictionary<string, string> form)
        {
            this.form = form;
            Console.Write(form.ContainsKey("user"));
            Console.Write(form.ContainsKey("pass"));
            Console.WriteLine(form.Count);
            foreach (var a in form)
            {
                Console.WriteLine(a.Key+" is " + a.Value);
            }
           
        }
        public string this[string key]
        {
            get
            {
                return form.ContainsKey(key) ? form[key] : "";
            }
        }
    }
}
