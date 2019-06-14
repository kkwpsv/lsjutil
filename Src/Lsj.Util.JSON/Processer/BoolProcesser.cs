using Lsj.Util.JSON.Processer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.JSON.Processer
{
    class BoolProcesser : IBoolProcesser
    {
        bool result = false;

        public object GetResult() => result;

        public void SetValue(bool value)
        {
            this.result = value;
        }

        public void SetValue(object value)
        {
            if (value is bool val)
            {
                SetValue(val);
            }
            else
            {
                JSONParser.Error("value must be bool");
            }
        }
    }
}
