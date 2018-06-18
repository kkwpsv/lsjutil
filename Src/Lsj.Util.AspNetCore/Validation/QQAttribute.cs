using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Lsj.Util.AspNet.Core.Validation
{
    /// <summary>
    /// Validate QQ
    /// </summary>
    public class QQAttribute : ValidationAttribute
    {
        /// <summary>
        /// IsValid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            return value is string text && QQAttribute._regex.IsMatch(text);
        }

        private static Regex _regex = new Regex("^[0-9]{5,10}$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
    }
}
