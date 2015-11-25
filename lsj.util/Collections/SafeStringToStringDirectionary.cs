using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Collections
{
    public class SafeStringToStringDirectionary : SafeDictionary<string,string>
    {
        public override string GetNullValue(string key)
        {
            return "";
        }
    }
}
