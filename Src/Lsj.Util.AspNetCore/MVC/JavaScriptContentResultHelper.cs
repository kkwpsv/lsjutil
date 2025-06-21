using Microsoft.AspNetCore.Mvc;

namespace Lsj.Util.AspNetCore.MVC
{
    /// <summary>
    /// JavaScript ContentResult Helper
    /// </summary>
    public static class JavaScriptContentResultHelper
    {
        /// <summary>
        /// Return a <see cref="ContentResult"/> which exec JavaScript directly.
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static ContentResult ExecJavaScriptDirectly(string script)
        {
            var html = $@"<script>{script}</script>";

            return new ContentResult
            {
                Content = html,
                ContentType = "text/html; charset=utf-8",
            };
        }

        /// <summary>
        /// Return a <see cref="ContentResult"/> which alert message and then redirect
        /// </summary>
        /// <param name="message"></param>
        /// <param name="redirectUrl"></param>
        /// <returns></returns>
        public static ContentResult AlertMessageAndRedirect(string message, string redirectUrl)
        {
            var script = $"alert('{message}');location.href = '{redirectUrl}';";
            return ExecJavaScriptDirectly(script);
        }
    }
}
