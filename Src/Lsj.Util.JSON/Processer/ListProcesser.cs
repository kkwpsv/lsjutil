using Lsj.Util.JSON.Processer.Interfaces;
using Lsj.Util.Reflection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lsj.Util.JSON.Processer
{
    class ListProcesser : IListProcesser, INullableProcesser
    {
        private readonly JSONParser _parser;
        private readonly Type _type;
        private readonly MethodInfo _addMethod;
        private readonly Type? _genericListType;
        object? _result;
        bool _isEmpty = true;

        public ListProcesser(JSONParser parser, Type type)
        {
            _parser = parser;
            _type = type;
            _addMethod = type.GetMethod("Add")!;
            _genericListType = type.GetGenericType(typeof(IList<>));
            _result = Activator.CreateInstance(type);
        }

        public object? GetResult() => _result;

        public Type? GetChildType() => _genericListType?.GetGenericArguments()[0] ?? null;

        public bool IsListEmpty() => _isEmpty;

        public void SetNull() => _result = null;

        public void AddChild(object? value)
        {
            _isEmpty = false;
            _addMethod.Invoke(_result, new object?[] { value });
        }

        public void SetValue(object? value)
        {
            if (value is JSONArray array)
            {
                foreach (var x in array.array)
                {
                    var processer = _parser.GetProcesserByType(GetChildType());
                    processer.SetValue(x);
                    this.AddChild(processer.GetResult());
                }
            }
        }
    }
}
