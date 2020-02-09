using Lsj.Util.JSON.Processer;
using Lsj.Util.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// JSON Array
    /// </summary>
    public class JSONArray : DynamicObject, IEnumerable<object>
    {
        internal readonly List<object> array = new List<object>();

        /// <summary>
        /// Count
        /// </summary>
        public int Count => array.Count;

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="value"></param>
        public void Add(object value)
        {
            array.Add(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (binder.Name == "Count")
            {
                result = array.Count;
                return true;
            }
            else
            {
                return base.TryGetMember(binder, out result);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="args"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (binder.Name == "Add" && args.Length == 1)
            {
                result = null;
                array.Add(args[0]);
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
        /// <param name="binder"></param>
        /// <param name="indexes"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length == 1 && indexes[0] is int)
            {
                result = array[(int)indexes[0]];
                return true;
            }
            else
            {
                return base.TryGetIndex(binder, indexes, out result);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="indexes"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            if (indexes.Length == 1 && indexes[0] is int)
            {
                array[(int)indexes[0]] = value;
                return true;
            }
            else
            {
                return base.TrySetIndex(binder, indexes, value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<object> GetEnumerator() => array.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => array.GetEnumerator();

        /// <summary>
        /// Specified To
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T SpecifiedTo<T>()
        {
            if (typeof(T).IsList())
            {
                var processer = new ListProcesser(typeof(T));
                processer.SetValue(this);
                return (T)processer.GetResult();
            }
            else
            {
                throw new ArgumentException("T must be IList or IList<>");
            }
        }


    }
}
