using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.JSON.Processer.Interfaces
{
    interface IStringProcesser : IProcesser
    {
        void SetValue(string value);
    }
}
