using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;
using Lsj.Util.Text;

namespace Lsj.Util.Dynamic
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

        /// <summary>
        /// Cast
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Cast<T>(this object obj)
        {
            return (T)obj;
        }

        /// <summary>
        /// Cast and Assign
        /// </summary>
        /// <param name="toAssign"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool AutoCastAndAssign(ref string toAssign, object val)
        {
            toAssign = val.ToString();
            return true;
        }

        /// <summary>
        /// Cast and Assign
        /// </summary>
        /// <param name="toAssign"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool AutoCastAndAssign(ref int toAssign, object val)
        {
            if (val.IsNumeric())
            {
                toAssign = (int)val;
                return true;
            }
            else
            {
                var str = (val as object).ToString();
                var intVal = str.ConvertToIntWithNull();
                if (intVal != null)
                {
                    toAssign = intVal.Value;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Cast and Assign
        /// </summary>
        /// <param name="toAssign"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool AutoCastAndAssign(ref decimal toAssign, object val)
        {
            if (val.IsNumeric())
            {
                toAssign = (int)val;
                return true;
            }
            else
            {
                var str = (val as object).ToString();
                var decimalVal = str.ConvertToDecimalWithNull();
                if (decimalVal != null)
                {
                    toAssign = decimalVal.Value;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
