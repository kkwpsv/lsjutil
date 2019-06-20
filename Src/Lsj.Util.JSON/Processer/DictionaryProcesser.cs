using Lsj.Util.JSON.Processer.Interfaces;
using Lsj.Util.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Lsj.Util.JSON.Processer
{
    class DictionaryProcesser : IObjectProcesser, INullableProcesser
    {
        object result;
        MethodInfo addMethod;
        Type genericDicType;

        public DictionaryProcesser(Type type)
        {
            addMethod = type.GetMethod("Add");
            genericDicType = type.GetGenericType(typeof(IDictionary<,>));
            result = genericDicType == null ? new Hashtable() : ReflectionHelper.CreateDictionaryOfType(genericDicType.GetGenericArguments()[0], genericDicType.GetGenericArguments()[1]);
        }

        public object GetResult() => result;

        public Type GetValueType(string name) => result is Hashtable ? null : genericDicType.GetGenericArguments()[1];

        public void Set(string name, object value)
        {
            addMethod.Invoke(result, new object[] { name, value });
        }

        public void SetNull() => result = null;

        public void SetValue(object value)
        {
            if (value is JSONObject obj)
            {
                foreach (var x in obj.data)
                {
                    var processer = JSONParser.GetProcesserByType(this.GetValueType(x.Key));
                    processer.SetValue(x.Value);
                    this.Set(x.Key, processer.GetResult());
                }
            }
        }
    }
}
