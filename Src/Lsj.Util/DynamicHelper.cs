using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Lsj.Util
{
    /// <summary>
    /// Dynamic Helper
    /// </summary>
    public static class DynamicHelper
    {
        /// <summary>
        /// Get Member
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="memberName">member name</param>
        /// <returns>value</returns>
        public static object GetMember(this object obj, string memberName)
        {
            var binder = Binder.GetMember(CSharpBinderFlags.None, memberName, obj.GetType(), new List<CSharpArgumentInfo> { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
            var callsite = CallSite<Func<CallSite, object, object>>.Create(binder);
            return callsite.Target(callsite, obj);
        }

        /// <summary>
        /// Set Member
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="memberName">member name</param>
        /// <param name="value">value</param>
        public static void SetMember(this object obj, string memberName, object value)
        {
            var binder = Binder.SetMember(CSharpBinderFlags.None, memberName, obj.GetType(), new List<CSharpArgumentInfo> { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
            var callsite = CallSite<Func<CallSite, object, object, object>>.Create(binder);
            callsite.Target(callsite, obj, value);
        }
    }
}
