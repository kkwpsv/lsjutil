using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Lsj.Util.AspNetCore.Validation
{
    /// <summary>
    /// Validate MobilePhone
    /// </summary>
    public class MobilePhoneAttribute : ValidationAttribute
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
            return value is string text && MobilePhoneAttribute._regex.IsMatch(text);
        }

        private static Regex _regex = new Regex("^(13[0-9]|14[579]|15[0-3,5-9]|16[6]|17[0135678]|18[0-9]|19[89])\\d{8}$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
    }
}
