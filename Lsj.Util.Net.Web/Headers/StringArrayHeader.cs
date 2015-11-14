using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Headers
{
    public class StringArrayHeader : RawHeader,IHeader
    {
        public string[] Array
        {
            private set;
            get;
        }
        public StringArrayHeader(string content) : base (content)
        {
            List<x> z = new List<x>();
            var a = content.Split(',');
            foreach (var b in a)
            {
                var c = b.Split(';');
                var y = new x();
                y.name = c[0].Trim();
                if (c.Length >= 2)
                {
                    y.level = c[1].Trim().ConvertToDecimal(1,0,1);
                }
                else
                {
                    y.level = 1;
                }
                z.Add(y);
            }
            z.Sort((x1,x2)=>(x1.level>x2.level?1:-1));
            Array = z.Select((x) => (x.name)).ToArray();
        }
        struct x
        {
            internal string name;
            internal decimal level;
        }
    }

}
