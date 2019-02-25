using Lsj.Util.JSON.Processer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.JSON.Processer
{
    class StringProcesser : IStringProcesser, INullableProcesser
    {
        string result;

        public object GetResult() => result;
        public void SetNull() => result = null;

        public void SetValue(string value)
        {
            this.result = value;
        }

        public void SetValue(object value) => SetValue(value.ToString());
    }
}
