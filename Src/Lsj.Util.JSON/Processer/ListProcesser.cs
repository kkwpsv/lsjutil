using Lsj.Util.JSON.Processer.Interfaces;
using Lsj.Util.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Lsj.Util.JSON.Processer
{
    class ListProcesser : IListProcesser, INullableProcesser
    {
        object result;
        Type type;
        MethodInfo addMethod;
        Type genericListType;
        bool isEmpty = true;

        public ListProcesser(Type type)
        {
            this.type = type;
            addMethod = type.GetMethod("Add");
            genericListType = type.GetGenericType(typeof(IList<>));
            result = ReflectionHelper.CreateInstance(type);
        }

        public object GetResult() => result;

        public Type GetChildType() => result is ArrayList ? null : genericListType.GetGenericArguments()[0];

        public bool IsListEmpty() => isEmpty;

        public void SetNull() => result = null;

        public void AddChild(object value)
        {
            isEmpty = false;
            addMethod.Invoke(result, new object[] { value });
        }

        public void SetValue(object value)
        {
            if (value is JSONArray array)
            {
                foreach (var x in array.array)
                {
                    var processer = JSONParser.GetProcesserByType(GetChildType());
                    processer.SetValue(x);
                    this.AddChild(processer.GetResult());
                }
            }
        }
    }
}
