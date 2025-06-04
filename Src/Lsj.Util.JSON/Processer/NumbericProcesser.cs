using Lsj.Util.JSON.Processer.Interfaces;
using System;

namespace Lsj.Util.JSON.Processer
{
    class NumericProcesser : INumericProcesser
    {
        private readonly Type _type;
        private object? _result;

        public NumericProcesser(Type type)
        {
            _type = type;
        }

        public object? GetResult() => _result;

        public void SetValue(object? value)
        {
            if (_type == null)
            {
                _result = value;
            }
            else
            {
                _result = Convert.ChangeType(value, _type);
            }
        }
    }
}
