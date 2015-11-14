using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    public class HtmlNodeWithoutEnd : HtmlNode
    {
        public override string ToString()
        {
            return $@"<{Name}{Param.ToString()} />";
        }
    }
}
