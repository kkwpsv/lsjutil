using Lsj.Util.JSON.Processer.Interfaces;
using Lsj.Util.Reflection;
using System;
using System.Reflection;

namespace Lsj.Util.JSON.Processer
{
    class ArrayProcesser : IListProcesser, INullableProcesser
    {
        private readonly JSONParser _parser;
        private readonly Type _type;
        private readonly Type? _elementType;
        private readonly MethodInfo _addMethod;

        private object? _list;
        private bool _isEmpty = true;

        public ArrayProcesser(JSONParser parser, Type type)
        {
            _parser = parser;
            _type = type;

            _elementType = _type.GetElementType();
            _list = ReflectionHelper.CreateListOfType(_elementType!);
            _addMethod = _list.GetType().GetMethod("Add")!;
        }

        public object? GetResult()
        {
            if (_list == null)
            {
                return null;
            }
            var toArrayMethod = _list.GetType().GetMethod("ToArray")!;
            return toArrayMethod.Invoke(_list, null);
        }

        public Type? GetChildType() => _elementType;

        public bool IsListEmpty() => _isEmpty;

        public void SetNull() => _list = null;

        public void AddChild(object? value)
        {
            _isEmpty = false;
            _addMethod.Invoke(_list, new object?[] { value });
        }

        public void SetValue(object? value)
        {
            if (value is JSONArray array)
            {
                foreach (var x in array.array)
                {
                    var processer = _parser.GetProcesserByType(GetChildType());
                    processer.SetValue(x);
                    AddChild(processer.GetResult());
                }
            }
        }
    }
}
