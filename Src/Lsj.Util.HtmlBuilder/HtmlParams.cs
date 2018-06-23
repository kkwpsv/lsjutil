using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Collections;


namespace Lsj.Util.HtmlBuilder
{
    /// <summary>
    /// Html Params
    /// </summary>
    public class HtmlParams : SafeStringToStringDirectionary
    {
        /// <summary>
        /// To String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var a in this)
            {
                sb.Append($@" {a.Key}=""{a.Value}""");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected override void Set(string key, string value)
        {
            key = key.ToLower();
            base.Set(key, value);
        }

        /// <summary>
        /// Add Classes
        /// </summary>
        /// <param name="classes"></param>
        public void AddClasses(params string[] classes)
        {
            if (Contain("class"))
            {
                base.Set("class", $"{this["class"]} "+ string.Join(" ", classes));
            }
            else
            {
                Set("class", string.Join(" ", classes));
            }
        }
    }
}
