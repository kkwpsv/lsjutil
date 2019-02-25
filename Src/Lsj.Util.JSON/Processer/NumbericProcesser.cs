using Lsj.Util.JSON.Processer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.JSON.Processer
{
    class NumericProcesser : INumericProcesser
    {
        Type type;
        object result;

        public NumericProcesser(Type type)
        {
            this.type = type;
        }

        public object GetResult() => result;

        public void SetValue(object value)
        {
            if (type == null)
            {
                result = value;
            }
            else
            {
                result = Convert.ChangeType(value, type);
            }
        }
    }
}
