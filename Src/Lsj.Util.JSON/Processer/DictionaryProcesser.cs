using Lsj.Util.JSON.Processer.Interfaces;
using Lsj.Util.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Lsj.Util.JSON.Processer
{
    class DictionaryProcesser : IObjectProcesser, INullableProcesser
    {
        private readonly JSONParser _parser;
        private readonly MethodInfo _addMethod;
        private readonly Type? _genericDicType;
        private object? _result;

        public DictionaryProcesser(JSONParser parser, Type type)
        {
            _parser = parser;
            _addMethod = type.GetMethod("Add")!;
            _genericDicType = type.GetGenericType(typeof(IDictionary<,>));
            _result = _genericDicType == null ? new Hashtable() : ReflectionHelper.CreateDictionaryOfType(_genericDicType.GetGenericArguments()[0], _genericDicType.GetGenericArguments()[1]);
        }

        public object? GetResult() => _result;

        public Type? GetValueType(string name) => _genericDicType?.GetGenericArguments()[1];

        public void Set(string name, object? value)
        {
            _addMethod.Invoke(_result, new object?[] { name, value });
        }

        public void SetNull() => _result = null;

        public void SetValue(object? value)
        {
            if (value is JSONObject obj)
            {
                foreach (var x in obj.Data)
                {
                    var processer = _parser.GetProcesserByType(GetValueType(x.Key));
                    processer.SetValue(x.Value);
                    Set(x.Key, processer.GetResult());
                }
            }
        }
    }
}
