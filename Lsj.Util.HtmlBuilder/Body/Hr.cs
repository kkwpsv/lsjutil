using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder.Body
{
    public class Hr : HtmlNodeWithoutEnd
    {
        public override string Name
        {
            get
            {
                return "hr";
            }
        }
    }
}
