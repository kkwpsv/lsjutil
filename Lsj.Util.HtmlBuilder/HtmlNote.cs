﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder.Body
{
    /// <summary>
    /// span
    /// </summary>
    public class HtmlNote : HtmlNode
    {
        /// <summary>
        /// HtmlNote
        /// </summary>
        /// <param name="content"></param>
        public HtmlNote(string content)
        {
            this.Content = content;
        }
        /// <summary>
        /// Content
        /// </summary>
        public string Content
        {
            get;
            set;
        } = "";
        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public override string ToString(int i)
        {
            return $@"<!-- {Content} -->";
        }
    }
}