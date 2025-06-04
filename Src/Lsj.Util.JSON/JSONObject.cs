using Lsj.Util.Collections;
using Lsj.Util.JSON.Processer;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// JSON Object
    /// </summary>
    public class JSONObject : DynamicObject
    {
        internal SafeDictionary<string, object?> Data { get; } = new SafeDictionary<string, object?>();

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Set(string name, object? value)
        {
            Data[name] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            var name = binder.Name;
            if (Data.ContainsKey(name))
            {
                result = Data[name];
                return true;
            }

            // IgnoreCase
            if (binder.IgnoreCase)
            {
                foreach (var keyValuePair in Data)
                {
                    if (keyValuePair.Key.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        result = keyValuePair.Value;
                        return true;
                    }
                }
            }

            return base.TryGetMember(binder, out result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            Set(binder.Name, value);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="args"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            if (binder.Name == "Set" && args?.Length == 2 && args[0] is string str)
            {
                result = null;
                Data[str] = args[1];
                return true;
            }
            else
            {
                return base.TryInvokeMember(binder, args, out result);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<string> GetDynamicMemberNames() => Data.Keys;


        /// <summary>
        /// Specified To
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T SpecifiedTo<T>()
        {
            var processer = new ObjectProcesser(new JSONParser(), typeof(T));
            processer.SetValue(this);
            return (T)processer.GetResult()!;
        }
    }
}
