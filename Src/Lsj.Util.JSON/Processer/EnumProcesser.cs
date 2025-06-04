using Lsj.Util.JSON.Processer.Interfaces;
using System;

namespace Lsj.Util.JSON.Processer
{
    class EnumProcesser : IStringProcesser, INumericProcesser
    {
        private readonly JSONParser _parser;
        private readonly Type _type;
        private object? _result;

        public EnumProcesser(JSONParser jsonParser, Type type)
        {
            _type = type;
            _parser = jsonParser;
        }

        public object? GetResult() => _result;

        public void SetValue(string val)
        {
            _result = Enum.Parse(_type, val);
        }

        public void SetValue(int val)
        {
            _result = Convert.ChangeType(val, _type);
        }

        public void SetValue(object? value)
        {
            if (value is null)
            {
                throw _parser.Error("Value cannot be null.");
            }
            else if (value is int intVal)
            {
                SetValue(intVal);
            }
            else
            {
                SetValue(value.ToString()!);
            }
        }
    }
}
