using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Lsj.Util.AspNetCore.Razor
{
    /// <summary>
    /// Enum Extensions
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Get display name for enum value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum value) => value.GetType().GetMember(value.ToString()).First().GetCustomAttribute<DisplayAttribute>()?.Name ?? value.ToString();
    }
}
