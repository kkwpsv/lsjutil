using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.AspNetCore.MVC
{
    /// <summary>
    /// JavaScriptResult
    /// </summary>
    public class JavaScriptResult : ActionResult
    {
        ContentResult result;

        /// <summary>
        /// 
        /// </summary>
        public JavaScriptResult()
        {
            this.result = new ContentResult();
            result.ContentType = "text/html; charset=utf-8";
        }

        /// <summary>
        /// Response Content
        /// </summary>
        public string Content
        {
            get
            {
                return result.Content;
            }
            set
            {
                result.Content = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ExecuteResultAsync(ActionContext context)
        {
            return result.ExecuteResultAsync(context);
        }
    }
}
