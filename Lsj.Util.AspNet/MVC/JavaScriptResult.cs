using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.AspNet.Core.MVC
{
    public class JavaScriptResult : ActionResult
    {
        ContentResult result;
        public JavaScriptResult()
        {
            this.result = new ContentResult();
            result.ContentType = "text/html; charset=utf-8";
        }
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
        public override Task ExecuteResultAsync(ActionContext context)
        {
            return result.ExecuteResultAsync(context);
        }
    }
}
