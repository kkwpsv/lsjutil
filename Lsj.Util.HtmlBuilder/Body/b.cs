﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.HtmlBuilder.Body
#else
namespace Lsj.Util.HtmlBuilder.Body
#endif
{
    /// <summary>
    /// B.
    /// </summary>
    public class b : HtmlNodeWithoutNewLine
    {
    }
}