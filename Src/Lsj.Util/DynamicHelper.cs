using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Lsj.Util
{
    public static class DynamicHelper
    {
        public static object GetMember(object obj, string memberName)
        {
            var binder = Binder.GetMember(CSharpBinderFlags.None, memberName, obj.GetType(), new List<CSharpArgumentInfo> { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
            var callsite = CallSite<Func<CallSite, object, object>>.Create(binder);
            return callsite.Target(callsite, obj);
        }
        public static object SetMember(object obj, string memberName, object val)
        {
            var binder = Binder.SetMember(CSharpBinderFlags.None, memberName, obj.GetType(), new List<CSharpArgumentInfo> { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
            var callsite = CallSite<Func<CallSite, object, object, object>>.Create(binder);
            return callsite.Target(callsite, obj, val);
        }
    }
}
